using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingViewComponent.Models
{
    public interface IRepository
    {
        IEnumerable<City> Cities { get; }
        void AddCity(City newCity);
    }
}
