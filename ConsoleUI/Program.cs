using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllCar();
            //GetCarsByBrand();
            GetCarDetail();
            //AddNewCar();
            //UpdateCar();
        }

        private static CarManager AddNewCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car {CarID=7, BrandID = 2, ColorID = 1, ModelYear = 2020, DailyPrice = 400, Description = "Fenasın..." });
            return carManager;
        }

        private static CarManager UpdateCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { CarID = 7, BrandID = 3, ColorID = 1, ModelYear = 2020, DailyPrice = 400, Description = "Fenasın..." });
            return carManager;
        }
        private static void GetCarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarID + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice + " / "  + car.Description);
            }
        }

        private static void GetCarsByBrand()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.CarID);
            }
        }

        private static void GetAllCar()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
