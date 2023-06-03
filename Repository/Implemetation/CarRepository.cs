using System.Collections.Generic;
using BusinessObject.Models;
using DataAccessObject;

namespace Repository.Implemetation
{
    public class CarRepository : ICarRepository
    {

        public void CreateCar(Car car)
        {
            CarDAO.Instance.CreateCar(car);
        }

        public void UpdateCar(Car car)
        {
            CarDAO.Instance.UpdateCar(car);
        }

        public void DeleteCar(int carId)
        {
            CarDAO.Instance.DeleteCar(carId);
        }

        public List<Car> GetAllCar()
        {
            return CarDAO.Instance.GetAllCar();
        }

        public Car GetCarById(int carId)
        {
            return CarDAO.Instance.GetCarById(carId);
        }

        public List<Car> SearchCars(string searchTerm)
        {
            return CarDAO.Instance.SearchCars(searchTerm);
        }
    }
}