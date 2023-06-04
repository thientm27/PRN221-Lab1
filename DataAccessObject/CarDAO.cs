using System.Collections.Generic;
using System.Linq;
using BusinessObject.Models;

namespace DataAccessObject
{
    public class CarDAO
    {
        private static CarDAO instance = null;
        private static object instanceLook = new object();

        public static CarDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new CarDAO();
                    }
                    return instance;
                }
            }
        }

        readonly MyStockContext _context = new MyStockContext();
        public List<Car> GetAllCar()
        {
            return _context.Cars.ToList();
        }
        public void CreateCar(Car car)
        {
            var maxId = _context.Cars.Max(c => c.CarId);
            car.CarId = maxId + 1;

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