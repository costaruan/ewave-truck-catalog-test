using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using TruckCatalog.Controllers.Controllers;
using TruckCatalog.Data.Contexts;
using TruckCatalog.Models.Models;
using Xunit;

namespace TruckCatalog.Tests.Tests
{
    public class GetAllTrucksTests
    {
        private readonly DbContextOptions<TruckCatalogContext> dbContextOptions;

        public GetAllTrucksTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<TruckCatalogContext>()
                .UseInMemoryDatabase(databaseName: "truckCatalog", new InMemoryDatabaseRoot())
                .Options;
        }

        [Fact]
        public void ShouldReturnAnEmptyTruckList()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            // Act
            List<Truck> listTrucks = truckController.GetAllTrucks();

            // Assert
            Assert.Empty(listTrucks);
        }

        [Fact]
        public void ShouldReturnATruckListWithFourTrucks()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck firstTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2022,
                ModelYear = 2022
            };

            Truck secondTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2022,
                ModelYear = 2023
            };

            Truck thirdTruck = new Truck()
            {
                ModelName = "FM",
                ManufactureYear = 2022,
                ModelYear = 2022
            };

            Truck fourthTruck = new Truck()
            {
                ModelName = "FM",
                ManufactureYear = 2022,
                ModelYear = 2023
            };

            // Act
            truckController.CreateTruck(firstTruck);
            truckController.CreateTruck(secondTruck);
            truckController.CreateTruck(thirdTruck);
            truckController.CreateTruck(fourthTruck);

            List<Truck> listTrucks = truckController.GetAllTrucks();

            // Assert
            Assert.NotEmpty(listTrucks);
            Assert.Equal(4, listTrucks.Count);
        }
    }
}
