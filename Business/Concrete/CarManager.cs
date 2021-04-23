using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if (car.DailyPrice >0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return _carDal.GetAll();
        }

        public IDataResult<List<Car>> GetByDailyPrice(double min, double max)
        {
            return _carDal.GetAll(c=>c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return _carDal.Get(c=>c.CarID == carId);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult (_carDal.GetAll(c=>c.BrandID == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorID == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
