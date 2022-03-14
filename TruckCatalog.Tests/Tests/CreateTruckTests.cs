using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TruckCatalog.Controllers.Controllers;
using TruckCatalog.Data.Contexts;
using TruckCatalog.Models.Models;
using TruckCatalog.Validators.Validators;
using Xunit;

namespace TruckCatalog.Tests.Tests
{
    public class CreateTruckTests
    {
        private readonly DbContextOptions<TruckCatalogContext> dbContextOptions;
        private readonly TruckValidator truckValidator = new TruckValidator();

        public CreateTruckTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<TruckCatalogContext>()
                .UseInMemoryDatabase(databaseName: "truckCatalog", new InMemoryDatabaseRoot())
                .Options;
        }

        [Fact]
        public void ShouldCreateATruck_FH_2022_2022()
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
            Truck createdTruck = truckController.CreateTruck(newTruck);

            // Assert
            Assert.Equal(newTruck.Id, createdTruck.Id);
            Assert.Equal(newTruck.ModelName, createdTruck.ModelName);
            Assert.Equal(newTruck.ManufactureYear, createdTruck.ManufactureYear);
            Assert.Equal(newTruck.ModelYear, createdTruck.ModelYear);
        }

        [Fact]
        public void ShouldCreateATruck_FH_2022_2023()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2022,
                ModelYear = 2023
            };

            // Act
            Truck createdTruck = truckController.CreateTruck(newTruck);

            // Assert
            Assert.Equal(newTruck.Id, createdTruck.Id);
            Assert.Equal(newTruck.ModelName, createdTruck.ModelName);
            Assert.Equal(newTruck.ManufactureYear, createdTruck.ManufactureYear);
            Assert.Equal(newTruck.ModelYear, createdTruck.ModelYear);
        }

        [Fact]
        public void ShouldCreateATruck_FM_2022_2022()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FM",
                ManufactureYear = 2022,
                ModelYear = 2022
            };

            // Act
            Truck createdTruck = truckController.CreateTruck(newTruck);

            // Assert
            Assert.Equal(newTruck.Id, createdTruck.Id);
            Assert.Equal(newTruck.ModelName, createdTruck.ModelName);
            Assert.Equal(newTruck.ManufactureYear, createdTruck.ManufactureYear);
            Assert.Equal(newTruck.ModelYear, createdTruck.ModelYear);
        }

        [Fact]
        public void ShouldCreateATruck_FM_2022_2023()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FM",
                ManufactureYear = 2022,
                ModelYear = 2023
            };

            // Act
            Truck createdTruck = truckController.CreateTruck(newTruck);

            // Assert
            Assert.Equal(newTruck.Id, createdTruck.Id);
            Assert.Equal(newTruck.ModelName, createdTruck.ModelName);
            Assert.Equal(newTruck.ManufactureYear, createdTruck.ManufactureYear);
            Assert.Equal(newTruck.ModelYear, createdTruck.ModelYear);
        }

        [Fact]
        public void ShouldNotCreateATruck_FXYZ_2025_2025()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FXYZ",
                ManufactureYear = 2025,
                ModelYear = 2025
            };

            // Act
            Truck createdTruck = truckController.CreateTruck(newTruck);

            // Assert
            truckValidator.TestValidate(createdTruck).ShouldHaveValidationErrorFor(truck => truck.ModelName);
            truckValidator.TestValidate(createdTruck).ShouldHaveValidationErrorFor(truck => truck.ManufactureYear);
            truckValidator.TestValidate(createdTruck).ShouldHaveValidationErrorFor(truck => truck.ModelYear);
        }

        [Fact]
        public void ShouldNotCreateATruck_FXYZ_2022_2022()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FXYZ",
                ManufactureYear = 2022,
                ModelYear = 2022
            };

            // Act
            Truck createdTruck = truckController.CreateTruck(newTruck);

            // Assert
            truckValidator.TestValidate(createdTruck).ShouldHaveValidationErrorFor(truck => truck.ModelName);
            truckValidator.TestValidate(createdTruck).ShouldNotHaveValidationErrorFor(truck => truck.ManufactureYear);
            truckValidator.TestValidate(createdTruck).ShouldNotHaveValidationErrorFor(truck => truck.ModelYear);
        }

        [Fact]
        public void ShouldNotCreateATruck_FH_2025_2022()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2025,
                ModelYear = 2022
            };

            // Act
            Truck createdTruck = truckController.CreateTruck(newTruck);

            // Assert
            truckValidator.TestValidate(createdTruck).ShouldNotHaveValidationErrorFor(truck => truck.ModelName);
            truckValidator.TestValidate(createdTruck).ShouldHaveValidationErrorFor(truck => truck.ManufactureYear);
            truckValidator.TestValidate(createdTruck).ShouldNotHaveValidationErrorFor(truck => truck.ModelYear);
        }

        [Fact]
        public void ShouldNotCreateATruck_FH_2022_2025()
        {
            // Arrange
            TruckCatalogContext truckCatalogContext = new TruckCatalogContext(dbContextOptions);
            TruckController truckController = new TruckController(truckCatalogContext);

            Truck newTruck = new Truck()
            {
                ModelName = "FH",
                ManufactureYear = 2022,
                ModelYear = 2025
            };

            // Act
            Truck createdTruck = truckController.CreateTruck(newTruck);

            // Assert
            truckValidator.TestValidate(createdTruck).ShouldNotHaveValidationErrorFor(truck => truck.ModelName);
            truckValidator.TestValidate(createdTruck).ShouldNotHaveValidationErrorFor(truck => truck.ManufactureYear);
            truckValidator.TestValidate(createdTruck).ShouldHaveValidationErrorFor(truck => truck.ModelYear);
        }
    }
}
