using System.Collections.Generic;
using BusinessObject.Models;

namespace Repository
{
    public interface ICarRepository
    {
        public void CreateCar(Car car);
        public void UpdateCar(Car car);
        public void DeleteCar(int carId);
        public List<Car> GetAllCar();
        public Car GetCarById(int carId);
        public List<Car> SearchCars(string searchTerm);
    }
}