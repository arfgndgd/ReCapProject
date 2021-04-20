using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarID =1, BrandID = 1,ColorID=1,ModelYear= 2015,DailyPrice=150000,Description="Çok iyi" },
                new Car{CarID =2, BrandID = 1,ColorID=2,ModelYear= 2017,DailyPrice=140000,Description="Aşırı rahat" },
                new Car{CarID =3, BrandID = 2,ColorID=3,ModelYear= 2015,DailyPrice=160000,Description="Fiyat/Performans" },
                new Car{CarID =4, BrandID = 3,ColorID=1,ModelYear= 2018,DailyPrice=1430000,Description="Daha iyisi yok" },
                new Car{CarID =5, BrandID = 2,ColorID=3,ModelYear= 2005,DailyPrice=130000,Description="Aman aman " }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarID == car.CarID);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c=>c.CarID == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarID == car.CarID);
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
