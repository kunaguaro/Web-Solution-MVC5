using AppWebGen.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppGen.Infrastructure;
using WebAppGen.Model.Entities;

namespace AppWebGen.Service.Services
{
    public interface ICountryService 
    {
        Country GetById(int? Id);
        IEnumerable<Country> GetAll();
        Country Insertar(Country country);
        Country Actualizar(Country country);
        int Delete(int id);
    }
}
