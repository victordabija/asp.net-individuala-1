using AutoShowroom.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoShowroom.Controllers
{
    public class CarsController : Controller
    {
        private static List<Car> _cars = new List<Car>
        {
            new Car
            {
                Id = 1, Brand = "Toyota", Price = 25000, AssemblyDate = new DateTime(2020, 5, 1),
                ImportDate = new DateTime(2020, 6, 1), Manufacturer = "Toyota", CountryOfOrigin = "Japan"
            },
            new Car
            {
                Id = 2, Brand = "Ford", Price = 30000, AssemblyDate = new DateTime(2019, 8, 10),
                ImportDate = new DateTime(2019, 9, 1), Manufacturer = "Ford", CountryOfOrigin = "USA"
            },
            new Car
            {
                Id = 3, Brand = "BMW", Price = 45000, AssemblyDate = new DateTime(2021, 2, 15),
                ImportDate = new DateTime(2021, 3, 1), Manufacturer = "BMW", CountryOfOrigin = "Germany"
            },
            new Car
            {
                Id = 4, Brand = "Audi", Price = 50000, AssemblyDate = new DateTime(2022, 5, 12),
                ImportDate = new DateTime(2022, 6, 1), Manufacturer = "Audi", CountryOfOrigin = "Germany"
            },
            new Car
            {
                Id = 5, Brand = "Tesla", Price = 60000, AssemblyDate = new DateTime(2021, 1, 1),
                ImportDate = new DateTime(2021, 2, 1), Manufacturer = "Tesla", CountryOfOrigin = "USA"
            },
            new Car
            {
                Id = 6, Brand = "Mercedes", Price = 70000, AssemblyDate = new DateTime(2022, 10, 20),
                ImportDate = new DateTime(2022, 11, 1), Manufacturer = "Mercedes", CountryOfOrigin = "Germany"
            },
            new Car
            {
                Id = 7, Brand = "Honda", Price = 20000, AssemblyDate = new DateTime(2018, 7, 15),
                ImportDate = new DateTime(2018, 8, 1), Manufacturer = "Honda", CountryOfOrigin = "Japan"
            }
        };

        public IActionResult Index()
        {
            return View(_cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            car.Id = _cars.Max(c => c.Id) + 1;
            _cars.Add(car);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = _cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            var existingCar = _cars.FirstOrDefault(c => c.Id == car.Id);
            if (existingCar == null)
            {
                return NotFound();
            }

            existingCar.Brand = car.Brand;
            existingCar.Price = car.Price;
            existingCar.AssemblyDate = car.AssemblyDate;
            existingCar.ImportDate = car.ImportDate;
            existingCar.Manufacturer = car.Manufacturer;
            existingCar.CountryOfOrigin = car.CountryOfOrigin;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var car = _cars.FirstOrDefault(c => c.Id == id);
            
            if (car != null)
            {
                _cars.Remove(car);
            }

            return RedirectToAction("Index");
        }
    }
}