using System.Collections.Generic;
using BusinessObject.Models;

namespace Repository
{
    public interface ICarRepository
    {
        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int carId);
        Car GetCarById(int carId);
        List<Car> SearchCars(string searchTerm);
    }
}