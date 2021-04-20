using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.DailyPrice);
            }

            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car in carManager1.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.CarID);
            }
        }
    }
}
