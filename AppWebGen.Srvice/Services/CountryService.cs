using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppGen.Infrastructure;
using WebAppGen.Model.Entities;

namespace AppWebGen.Service.Services
{
    public class CountryService : EntityService<Country>, ICountryService
    {
        new IContext _context;

        public CountryService(IContext context): base(context)
        {
            _context = context;
            _dbset = _context.Set<Country>();
        }

        public Country GetById(int? Id)
        {
            return _dbset.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<Country> GetAll()
        {
            return _dbset.AsEnumerable<Country>();
        }

        public Country Insertar(Country country)
        {
            _dbset.Add(country);
            return country;
        }

        public int Delete(int id)
        {
            Country country = _dbset.Find(id);
            if (country == null)
            {
                return -1;
            }
            _dbset.Remove(country);
            _context.SaveChanges();
            return 0;
        }

        public Country Actualizar(Country country)
        {
            Country myCountry = new Country();
            myCountry = _dbset.Where(c => c.Id == country.Id).FirstOrDefault();
            myCountry.Id = country.Id;
            myCountry.Name = country.Name;
            _context.Entry(myCountry).State = EntityState.Modified;
            _context.SaveChanges();
           
            return country;
        }
    }
}
