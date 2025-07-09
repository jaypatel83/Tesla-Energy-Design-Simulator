using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using EnergyDesignSimulator.Models;
using System.Text.Json;
using EnergyDesignSimulator.Utility;

namespace EnergyDesignSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignsController : ControllerBase
    {
        private readonly string _connectionString;

        public DesignsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // GET: api/designs
        [HttpGet]
        public async Task<IActionResult> GetDesigns()
        {
            var designs = new List<Design>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, LayoutName, PanelCount, Coordinates, CreatedAt FROM Designs";
                using (var command = new SqliteCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        designs.Add(new Design
                        {
                            Id = reader.GetInt32(0),
                            LayoutName = reader.GetString(1),
                            PanelCount = reader.GetInt32(2),
                            Coordinates = reader.GetString(3),
                            CreatedAt = DateTime.Parse(reader.GetString(4))
                        });
                    }
                }
            }
            return Ok(designs);
        }

        // POST: api/designs
        [HttpPost]
        public async Task<IActionResult> CreateDesign([FromBody] Design design)
        {
            if (!JsonValidator.IsValidJson(design.Coordinates)) return BadRequest("Invalid JSON");
            if (!ModelState.IsValid || design.PanelCount <= 0 || string.IsNullOrEmpty(design.LayoutName))
                return BadRequest("Invalid design data");

            try
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = "INSERT INTO Designs (LayoutName, PanelCount, Coordinates) VALUES (@LayoutName, @PanelCount, @Coordinates)";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LayoutName", design.LayoutName);
                        command.Parameters.AddWithValue("@PanelCount", design.PanelCount);
                        command.Parameters.AddWithValue("@Coordinates", design.Coordinates);
                        await command.ExecuteNonQueryAsync();
                    }
                }
                return CreatedAtAction(nameof(GetDesigns), new { id = design.Id }, design);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        // GET: api/designs/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesign(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, LayoutName, PanelCount, Coordinates, CreatedAt FROM Designs WHERE Id = @Id";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var design = new Design
                            {
                                Id = reader.GetInt32(0),
                                LayoutName = reader.GetString(1),
                                PanelCount = reader.GetInt32(2),
                                Coordinates = reader.GetString(3),
                                CreatedAt = DateTime.Parse(reader.GetString(4))
                            };
                            return Ok(design);
                        }
                    }
                }
            }
            return NotFound();
        }
    }
}