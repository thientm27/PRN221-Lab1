using System.Collections.Generic;
using System.Linq;
using BusinessObject.Models;

namespace DataAccessObject
{
    public class CarDAO
    {
        private static CarDAO _instance;
        private static readonly object _lock = new object();

        private readonly MyStockContext _context;

        private CarDAO(MyStockContext context)
        {
            _context = context;
        }

        public static CarDAO Instance(MyStockContext context)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CarDAO(context);
                    }
                }
            }
            return _instance;
        }

        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public Car GetCarById(int carId)
        {
            return _context.Cars.Find(carId);
        }

        public List<Car> SearchCars(string searchTerm)
        {
            return _context.Cars
                .Where(c => c.CarName.Contains(searchTerm) || c.Manufacturer.Contains(searchTerm))
                .ToList();
        }
    }
}