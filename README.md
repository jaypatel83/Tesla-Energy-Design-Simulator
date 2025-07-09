# Tesla: Energy Design Simulator

The **Tesla: Energy Design Simulator** is a mock web application designed to prepare for the Tesla Staff Software Engineer, Energy Design Applications role. It demonstrates proficiency in **C#**, **SQLite** (as a lightweight alternative to MySQL), **REST APIs**, and **design tool integration** (simulating AutoCAD-like functionality), aligning with the job’s requirements for backend development, database management, API integration, and design tool support.

## Job Description
**Staff Software Engineer, Energy Design Applications**  
**Job Category**: Engineering & Information Technology  
**Location**: Fremont, California  
**Job Type**: Full-time  

**What to Expect**  
We are seeking a skilled Staff Software Engineer with a focus on backend development to join our Energy Design team at Tesla. The ideal candidate will be proficient in C# and have hands-on experience with AutoCAD libraries/plugins. This role involves designing, developing, and maintaining backend systems to support Tesla’s Energy Design Model, ensuring seamless integration with various design components and databases like MySQL. You will play a critical role in enhancing our design model architecture and related services.

**What You’ll Do**  
- Design and implement backend solutions to support the Energy Design Model, including Bill of Materials, Site Equipment, Layout, Solar Access, Stringing, and Structure Modules.  
- Develop and maintain APIs for saving designs and integrating with rendering services, ensuring robust data handling and storage.  
- Work with MySQL databases to manage and optimize the Design Model schema, ensuring data integrity and performance.  
- Utilize C# to build scalable and efficient backend systems, focusing on performance and reliability.  
- Integrate AutoCAD libraries/plugins to support design and layout functionalities, enabling precise rendering and manipulation of design data.  
- Collaborate with cross-functional teams to define and implement new models such as Solar Access, Automation, and Production Models.  
- Troubleshoot and resolve issues related to design data save priorities and state management within the design ecosystem.  
- Contribute to the documentation of backend processes and architecture in Confluence to maintain a clear knowledge base for the team.

**What You’ll Bring**  
- Degree in Computer Science, Mechanical/Electrical Engineering, or a related field or equivalent experience.  
- Proven experience as a Backend Developer with strong proficiency in C# programming.  
- Demonstrated experience working with AutoCAD libraries or plugins for design and layout applications.  
- Familiarity with MySQL or similar relational database management systems, including schema design and optimization.  
- Strong problem-solving skills and the ability to work in a fast-paced, collaborative environment.  
- Excellent communication skills to document processes and collaborate with team members effectively.  
- Experience with API development for design data integration.

## Purpose
This app simulates Tesla’s Energy Design Model, allowing users to create, save, retrieve, and visualize solar panel layouts, helping practice:
- **C#**: Developing backend systems with ASP.NET Core for scalability and reliability.
- **SQLite**: Managing and optimizing database schemas (as a proxy for MySQL).
- **REST APIs**: Building APIs for design data storage and integration with rendering services.
- **Design Tools**: Simulating AutoCAD-like functionality via an HTML canvas for layout visualization.

## Project Structure
- **Controllers/**: `DesignsController.cs` (REST API logic).
- **Models/**: `Design.cs` (data model for designs).
- **wwwroot/**: `index.html` (frontend with form and canvas).
- **appsettings.json**: SQLite connection configuration.
- **Program.cs**: App entry point and database setup.
- **EnergyDesignSimulator.csproj**: .NET 9.0 project file.
- **energy_design.db**: SQLite database (created on first run).

## Logic and Flow
### Overview
The app enables users to input design layouts (name, panel count, coordinates), save them to an SQLite database via REST APIs, retrieve and list designs, and visualize panels on an HTML canvas, simulating AutoCAD-like design tools. It uses:
- **C# ASP.NET Core** (.NET 9.0.301): Backend logic and APIs.
- **SQLite**: Lightweight database for storing designs (mimicking MySQL workflows).
- **REST APIs**: Endpoints for creating (`POST /api/designs`), listing (`GET /api/designs`), and retrieving (`GET /api/designs/{id}`) designs.
- **HTML/CSS/JavaScript**: Frontend with Tailwind CSS for professional styling, featuring a form and canvas.

### Flow
1. **Startup** (`Program.cs`):
   - Configures ASP.NET Core, enabling controllers and Swagger for API testing.
   - Creates an SQLite database (`energy_design.db`) and `Designs` table (`Id`, `LayoutName`, `PanelCount`, `Coordinates`, `CreatedAt`) on first run.
2. **Frontend** (`index.html`):
   - Displays a professionally styled form (using Tailwind CSS) for inputting `LayoutName`, `PanelCount`, and `Coordinates` (JSON).
   - Buttons trigger `saveDesign()` (POST to API) and `loadDesigns()` (GET from API).
   - A canvas visualizes panels as 10x10 blue rectangles with labels (e.g., “P1”), simulating AutoCAD layout rendering.
   - Designs are listed with clickable names to update the canvas.
3. **Backend** (`DesignsController.cs`):
   - `GET /api/designs`: Retrieves all designs from SQLite.
   - `POST /api/designs`: Saves a design, validating inputs (e.g., `PanelCount > 0`).
   - `GET /api/designs/{id}`: Retrieves a specific design by ID.
4. **Data Model** (`Design.cs`):
   - Defines the `Design` class (`Id`, `LayoutName`, `PanelCount`, `Coordinates`, `CreatedAt`), mapping to the SQLite table.
5. **Configuration** (`appsettings.json`):
   - Specifies the SQLite connection (`Data Source=energy_design.db`).

### How It Works
1. **User Interaction**:
   - Users enter a design (e.g., `LayoutName: SolarLayout1`, `PanelCount: 4`, `Coordinates: [{"x": 50, "y": 50}]`).
   - “Save Design” sends a POST request to `/api/designs`, storing the design in SQLite.
   - “Load Designs” fetches designs via GET `/api/designs`, displaying them as clickable links.
   - Clicking a design name updates the canvas with its coordinates.
2. **Visualization**:
   - The canvas draws blue rectangles for each coordinate, clamped to 400x200 bounds, with labels (e.g., “P1”).
   - Errors (e.g., invalid JSON) are shown in a red error div.
3. **Backend Processing**:
   - APIs validate inputs, execute parameterized SQLite queries, and return JSON responses (200 OK, 400 Bad Request, 404 Not Found, 500 Error).

## Setup Instructions
1. **Prerequisites**:
   - .NET 9.0.301 SDK (`dotnet --version` to verify).
   - Visual Studio Code with C# Extension (OmniSharp).
   - Optional: Postman (API testing), DB Browser for SQLite (database GUI).
2. **Project Setup**:
   - Unzip `EnergyDesignSimulator_SQLite.zip` or create a folder with files (`Program.cs`, `DesignsController.cs`, `Design.cs`, `index.html`, `appsettings.json`, `.csproj`).
   - Open in VS Code: `File > Open Folder`.
3. **Restore and Run**:
   - Run `dotnet restore` in VS Code’s terminal.
   - Run `dotnet build`.
   - Run `dotnet run` to start at `http://localhost:5000`.
4. **Test**:
   - **Frontend**: At `http://localhost:5000`, input a design (e.g., `LayoutName: SolarLayout1`, `PanelCount: 4`, `Coordinates: [{"x": 50, "y": 50}]`), save, and load designs. Click a design name to update the canvas.
   - **APIs (Postman)**: Test `GET /api/designs`, `POST /api/designs`, `GET /api/designs/{id}`.
   - **Database**: Check `energy_design.db` with `sqlite3 energy_design.db "SELECT * FROM Designs;"`.

## Coding Challenges
These challenges align with Tesla’s job requirements (C#, SQLite/MySQL, REST APIs, design tools, backend systems) to prepare for the technical interview:

1. **C# Coding**:
   - **Task**: Add JSON validation to `CreateDesign` in `DesignsController.cs` before saving to ensure valid `Coordinates`.
   - **Example**: Add `if (!IsValidJson(design.Coordinates)) return BadRequest("Invalid JSON");` using `System.Text.Json`.
   - **Why**: Demonstrates C# proficiency and input validation, critical for backend reliability.
2. **SQLite Optimization** (Proxy for MySQL):
   - **Task**: Add an index to `Designs` table: `CREATE INDEX idx_layout_name ON Designs(LayoutName);`. Write a query: `SELECT * FROM Designs WHERE PanelCount > 5;`.
   - **Why**: Practices schema optimization and query performance, as required for MySQL in the job.
3. **REST API Development**:
   - **Task**: Add a `PUT /api/designs/{id}` endpoint to update designs in `DesignsController.cs`.
   - **Example**: Implement an SQLite UPDATE query, checking ID existence.
   - **Why**: Tests API development for design data integration, per job requirements.
4. **Design Tools**:
   - **Task**: Modify `drawDesign` in `index.html` to add grid lines to the canvas for panel alignment.
   - **Example**: Draw 50px grid lines using `ctx.strokeLine`.
   - **Why**: Simulates AutoCAD-like layout visualization, aligning with design tool integration.
5. **System Design**:
   - **Task**: Add `IMemoryCache` to `GetDesigns` in `DesignsController.cs` to cache results.
   - **Example**: Use `Microsoft.Extensions.Caching.Memory` to cache for 5 minutes.
   - **Why**: Demonstrates scalable backend design, as required for performance.
6. **STAR Stories**:
   - **Task**: Pitch the app in a 1-minute STAR story: “This app demonstrates my ability to build C# backend systems with APIs and design visualization, meeting Tesla’s Energy Design Model needs.”
   - **Why**: Prepares you to articulate technical contributions and mission alignment.
7. **Concurrent Data Access**:
   - **Task**: Add a lock to `CreateDesign` to handle concurrent writes safely.
   - **Example**: Use `lock` or `ConcurrentDictionary` in C#.
   - **Why**: Addresses scalability and reliability for backend systems, per job specs.
8. **Design Data Validation**:
   - **Task**: Enhance `drawDesign` to validate unique panel coordinates.
   - **Example**: Check for duplicate x,y pairs in JavaScript.
   - **Why**: Ensures precision in design data, critical for AutoCAD integration.
9. **API Error Handling**:
   - **Task**: Add custom error codes to `CreateDesign` for specific failures (e.g., duplicate `LayoutName`).
   - **Example**: Check SQLite for existing names, return 409 Conflict.
   - **Why**: Demonstrates robust API design, as needed for design data integration.
10. **Database Performance**:
    - **Task**: Optimize a query in `GetDesigns` to filter by date range (e.g., last 7 days).
    - **Example**: `SELECT * FROM Designs WHERE CreatedAt >= @StartDate;`.
    - **Why**: Practices MySQL-like performance optimization for design data.