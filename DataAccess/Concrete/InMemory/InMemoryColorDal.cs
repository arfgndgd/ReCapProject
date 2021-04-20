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
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{ ColorID=1,ColorName="Red"},
                new Color{ColorID=2,ColorName="Grey"},
                new Color{ColorID=3,ColorName="Black"}
            };
        }
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorID == color.ColorID);
            _colors.Remove(colorToDelete);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetById(int id)
        {
            return _colors.Where(c=>c.ColorID == id).ToList();
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorID == color.ColorID);
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
