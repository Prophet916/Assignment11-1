using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11_1
{
    interface CRUD
    {
        void AddRecord(Car car);
        void DeleteRecord(Car car);
        ICollection<Car> GetAll();

        Car FindCar(string VIN);
        void UpdateRecord(string VIN, Car car);
    }

    class CarRepository : CRUD
    {
        CarsEntities1 entities;
        public CarRepository()
        {
            entities = new CarsEntities1();
        }
        public void AddRecord(Car car)
        {
            entities.Cars.Add(car);
            entities.SaveChanges();
        }

        public void DeleteRecord(Car car)
        {
            entities.Cars.Remove(car);
            entities.SaveChanges();
        }

        public Car FindCar(string VIN)
        {
            return entities.Cars.Find(VIN);
        }

        public ICollection<Car> GetAll()
        {
            return entities.Cars.ToList();
        }

        public void UpdateRecord(string VIN, Car car)
        {
            var carToUpdate = entities.Cars.Find(VIN);
            carToUpdate.VIN = car.VIN;
            carToUpdate.Make = car.Make;
            carToUpdate.Model = car.Model;
            carToUpdate.Price = car.Price;
            carToUpdate.Year = car.Year;
            entities.SaveChanges();
        }
    }
}
