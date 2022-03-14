using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TruckCatalog.Data.Contexts;
using TruckCatalog.Models.Models;

namespace TruckCatalog.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly TruckCatalogContext _truckCatalogContext;

        public TruckController(TruckCatalogContext truckCatalogContext)
        {
            if (truckCatalogContext == null)
                throw new ArgumentNullException(nameof(truckCatalogContext));

            _truckCatalogContext = truckCatalogContext;
        }

        [HttpGet]
        [Route("list")]
        public List<Truck> GetAllTrucks()
        {
            var allTrucks = _truckCatalogContext.Trucks.ToList();

            return allTrucks;
        }

        [HttpPost]
        [Route("create")]
        public Truck CreateTruck(Truck truck)
        {
            _truckCatalogContext.Trucks.Add(truck);
            _truckCatalogContext.SaveChanges();

            return truck;
        }

        [HttpPut]
        [Route("update/{id}")]
        public Truck UpdateTruck(Guid id, Truck truck)
        {
            Truck updateTruck = _truckCatalogContext.Trucks.Where(truck => truck.Id == id).FirstOrDefault();

            if (updateTruck != null)
            {
                updateTruck.ModelName = truck.ModelName;
                updateTruck.ManufactureYear = truck.ManufactureYear;
                updateTruck.ModelYear = truck.ModelYear;

                _truckCatalogContext.Update(updateTruck);
                _truckCatalogContext.SaveChanges();
            }

            return updateTruck;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Truck DeleteTruck(Guid id)
        {
            Truck deleteTruck = _truckCatalogContext.Trucks.Where(truck => truck.Id == id).FirstOrDefault();

            if (deleteTruck != null)
            {
                _truckCatalogContext.Trucks.Remove(deleteTruck);
                _truckCatalogContext.SaveChanges();
            }

            return deleteTruck;
        }
    }
}
