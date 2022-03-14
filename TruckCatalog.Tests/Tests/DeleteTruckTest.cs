using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using TruckCatalog.Controllers.Controllers;
using TruckCatalog.Data.Contexts;
using TruckCatalog.Models.Models;
using Xunit;


namespace TruckCatalog.Tests.Tests
{
    public class DeleteTruckTest
    {
        private readonly DbContextOptions<TruckCatalogContext> dbContextOptions;

        public DeleteTruckTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<TruckCatalogContext>()
                .UseInMemoryDatabase(databaseName: "truckCatalog", new InMemoryDatabaseRoot())
                .Options;
        }

        [Fact]
        public void ShouldNotDeleteATruckWithInexistentId()
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

            Guid inexistentId = new Guid("11111111-1111-1111-1111-111111111111");
            Truck updateTruck = truckController.DeleteTruck(inexistentId);

            // Assert
            Assert.Null(updateTruck);
        }

        [Fact]
        public void ShouldDeleteATruckWithExistentId()
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

            Truck deletedTruck = truckController.DeleteTruck(newTruck.Id);

            // Assert
            Assert.Equal(newTruck.Id, deletedTruck.Id);
            Assert.Equal(newTruck.ModelName, deletedTruck.ModelName);
            Assert.Equal(newTruck.ManufactureYear, deletedTruck.ManufactureYear);
            Assert.Equal(newTruck.ModelYear, deletedTruck.ModelYear);
        }
    }
}
