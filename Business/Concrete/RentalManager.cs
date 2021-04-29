using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //Buradaki tüm validation kodlarını önce Business'ta ValidationRules olarak belirleyip Core'da Utilities/Interceptions - CrossCuttingConcerns/Validation - Aspect/Autofac/Validation içlerindeki classlar ile bu klasörleri birbirine bağladık. 
            //Yapmamız gereken tek şey ise methodun üstüne [ValidationAspect] yazmak oldu

            //Kiralama aşamasında istenen araç henüz kiralamadan dönmeddi ise..
            var result = _rentalDal.GetAll(c => c.CarID == rental.CarID && !c.ReturnDate.HasValue);
            if (!result.Any())
            {
                _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentAdded);
            }
            return new ErrorResult(Messages.RentNotComeBack);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalID==rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentModified);
        }
    }
}
