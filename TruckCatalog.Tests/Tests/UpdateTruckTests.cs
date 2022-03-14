using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using TruckCatalog.Controllers.Controllers;
using TruckCatalog.Data.Contexts;
using TruckCatalog.Models.Models;
using Xunit;

namespace TruckCatalog.Tests.Tests
{
    public class UpdateTruckTests
    {
        private readonly DbContextOptions<TruckCatalogContext> dbContextOptions;

        public UpdateTruckTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<TruckCatalogContext>()
                .UseInMemoryDatabase(databaseName: "truckCatalog", new InMemoryDatabaseRoot())
                .Options;
        }

        [Fact]
        public void ShouldNotUpdateATruckWithInexistentId()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2022,
                ModelYear = 2022
            };

            // Act
            truckController.CreateTruck(newTruck);

            newTruck.ModelName = "FM";
            newTruck.ManufactureYear = 2022;
            newTruck.ModelYear = 2023;

            Guid inexistentId = new Guid("11111111-1111-1111-1111-111111111111");
            Truck updatedTruck = truckController.UpdateTruck(inexistentId, newTruck);

            // Assert
            Assert.Null(updatedTruck);
        }

        [Fact]
        public void ShouldNotUpdateATruckWithAnWrongModelName()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2022,
                ModelYear = 2022
            };

            // Act
            truckController.CreateTruck(newTruck);

            newTruck.ModelName = "FXYZ";

            Truck updatedTruck = truckController.UpdateTruck(newTruck.Id, newTruck);

            // Assert
            Assert.Equal(newTruck.Id, updatedTruck.Id);
            Assert.Equal(newTruck.ModelName, updatedTruck.ModelName);
            Assert.Equal(newTruck.ManufactureYear, updatedTruck.ManufactureYear);
            Assert.Equal(newTruck.ModelYear, updatedTruck.ModelYear);
        }

        [Fact]
        public void ShouldNotUpdateATruckWithAnWrongManufactureYear()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2022,
                ModelYear = 2022
            };

            // Act
            truckController.CreateTruck(newTruck);

            newTruck.ManufactureYear = 2025;

            Truck updatedTruck = truckController.UpdateTruck(newTruck.Id, newTruck);

            // Assert
            Assert.Equal(newTruck.Id, updatedTruck.Id);
            Assert.Equal(newTruck.ModelName, updatedTruck.ModelName);
            Assert.Equal(newTruck.ManufactureYear, updatedTruck.ManufactureYear);
            Assert.Equal(newTruck.ModelYear, updatedTruck.ModelYear);
        }

        [Fact]
        public void ShouldNotUpdateATruckWithAnWrongModelYear()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2022,
                ModelYear = 2022
            };

            // Act
            truckController.CreateTruck(newTruck);

            newTruck.ModelYear = 2025;

            Truck updatedTruck = truckController.UpdateTruck(newTruck.Id, newTruck);

            // Assert
            Assert.Equal(newTruck.Id, updatedTruck.Id);
            Assert.Equal(newTruck.ModelName, updatedTruck.ModelName);
            Assert.Equal(newTruck.ManufactureYear, updatedTruck.ManufactureYear);
            Assert.Equal(newTruck.ModelYear, updatedTruck.ModelYear);
        }

        [Fact]
        public void ShouldUpdateATruckWithExistentId()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2022,
                ModelYear = 2022
            };

            // Act
            truckController.CreateTruck(newTruck);

            newTruck.ModelName = "FM";
            newTruck.ManufactureYear = 2022;
            newTruck.ModelYear = 2023;

            Truck updatedTruck = truckController.UpdateTruck(newTruck.Id, newTruck);

            // Assert
            Assert.Equal(newTruck.Id, updatedTruck.Id);
            Assert.Equal("FM", updatedTruck.ModelName);
            Assert.Equal(2022, updatedTruck.ManufactureYear);
            Assert.Equal(2023, updatedTruck.ModelYear);
        }
    }
}
