using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAllCar();
            //GetCarsByBrand();
            //GetCarDetail();
            //AddNewCar();
            //UpdateCar();
            AddNewUser();
        }

        private static UserManager AddNewUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var addedResult= userManager.Add(new User { UserID = 1, FirstName = "Arif", LastName = "Gündoğdu", Email = "gundogduarif4@gmail.com", Password = "123" });
            Console.WriteLine(addedResult.Message);
            var result = userManager.GetAll();
            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.UserID + " / " + user.FirstName + " / " + user.LastName + " / " + user.Email + "  " + user.Password);
                }
            }
            return userManager;
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
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarID + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice + "  "  + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void GetCarsByBrand()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByBrandId(2);
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarID);
                }
            }
            
        }

        private static void GetAllCar()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.DailyPrice);
                }
            }
                
        }
    }
}
