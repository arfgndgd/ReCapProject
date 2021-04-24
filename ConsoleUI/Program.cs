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
            //AddNewUser();
            //AddNewCustomer();
            //AddNewRental();

        }

        private static CustomerManager AddNewCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var addedCustomer = customerManager.Add(new Customer{CustomerID = 2,UserID = 2,CompanyName = "XCompany"});
            Console.WriteLine(addedCustomer.Message);
            var result = customerManager.GetAll();
            if (result.Success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CustomerID + " / " + customer.UserID + " / " + customer.CompanyName);
                }
            }
            return customerManager;
        }

        private static void AddNewRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var addedRental = rentalManager.Add(new Rental
            {
                RentalID = 1,
                CarID = 1,
                CustomerID = 1,
                RentDate = new DateTime(2021, 4, 24)
            });
            if (addedRental.Success == true)
            {
                Console.WriteLine(addedRental.Message);
            }
            else
            {
                Console.WriteLine(addedRental.Message);
            }
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine(rent.CarID + " / " +rent.CustomerID + " / " +rent.RentalID + " / " +rent.RentDate + " / " +rent.ReturnDate);
                }
            }
        }

        private static UserManager AddNewUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var addedUser= userManager.Add(new User { UserID = 1, FirstName = "Arif", LastName = "Gündoğdu", Email = "gundogduarif4@gmail.com", Password = "123" });
            Console.WriteLine(addedUser.Message);
            var result = userManager.GetAll();
            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.UserID + " / " +user.FirstName + " / " + user.LastName + " / " + user.Email + "  " + user.Password);
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
                    Console.WriteLine(car.CarID + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice + " / "  + car.Description);
                }
                Console.WriteLine(result.Message);
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
