using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice >0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Günlük kiralama fiyatı 0'dan büyük olmalı");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(double min, double max)
        {
            return _carDal.GetAll(c=>c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c=>c.CarID == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c=>c.BrandID == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorID == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
