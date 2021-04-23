﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        List<Car> GetByDailyPrice(double min, double max);
        List<CarDetailDto> GetCarDetails();
        Car GetById(int carId);
        IResult Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
