# elective-inventory-order-tracker

E-Commerce Inventory & Order Tracking Subsystem built with ASP.NET Core MVC and Entity Framework Core (SQL Server).

Architecture: `Browser View -> MVC Controller -> Unit of Work / Repository -> EF Core DbContext -> SQL Server`. Controllers depend only on `IUnitOfWork` and never inject `ApplicationDbContext` directly.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server LocalDB (installed with Visual Studio, or via the [SQL Server Express LocalDB installer](https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb))
- The [EF Core CLI tools](https://learn.microsoft.com/ef/core/cli/dotnet), if not already installed:

  ```powershell
  dotnet tool install --global dotnet-ef
  ```

## Setup

1. Restore dependencies and build:

   ```powershell
   dotnet restore
   dotnet build
   ```

2. The connection string is in `appsettings.json` under `ConnectionStrings:DefaultConnection`, pointing at `(localdb)\mssqllocaldb` by default. Update it if you're using a different SQL Server instance.
3. Apply the migrations to create the database:

   ```powershell
   dotnet ef database update
   ```

## Running the app

```powershell
dotnet run
```

or, for automatic rebuild/reload on file changes:

```powershell
dotnet watch run
```

The app listens on the URLs configured in `Properties/launchSettings.json` (`https://localhost:7180` / `http://localhost:5243`). The root URL routes to `ProductsController/Index`, showing the Products list with Create/Edit/Details/Delete pages.

## Adding a new migration

After changing an entity or `ApplicationDbContext.OnModelCreating`:

```powershell
dotnet ef migrations add <MigrationName>
dotnet ef database update
```
