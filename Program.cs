using Microsoft.AspNetCore.Builder;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Create SQLite database and table
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
using (var connection = new SqliteConnection(connectionString))
{
    connection.Open();
    var command = connection.CreateCommand();
    command.CommandText = @"
        CREATE TABLE IF NOT EXISTS Designs (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            LayoutName TEXT NOT NULL,
            PanelCount INTEGER NOT NULL,
            Coordinates TEXT NOT NULL,
            CreatedAt TEXT DEFAULT (datetime('now'))
        )";
    command.ExecuteNonQuery();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Comment out HTTPS redirection to avoid errors
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();