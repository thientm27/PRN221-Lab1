using System.Collections.Generic;
using BusinessObject.Models;
using DataAccessObject;

namespace Repository.Implemetation
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDAO _carDao;

        public CarRepository(CarDAO carDao)
        {
            _carDao = carDao;
        }

        public void CreateCar(Car car)
        {
            _carDao.CreateCar(car);
        }

        public void UpdateCar(Car car)
        {
            _carDao.UpdateCar(car);
        }

        public void DeleteCar(int carId)
        {
            _carDao.DeleteCar(carId);
        }

        public Car GetCarById(int carId)
        {
            return _carDao.GetCarById(carId);
        }

        public List<Car> SearchCars(string searchTerm)
        {
            return _carDao.SearchCars(searchTerm);
        }
    }
}