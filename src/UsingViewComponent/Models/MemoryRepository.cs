using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingViewComponent.Models
{
    public class MemoryRepository : IRepository
    {
        private List<City> listCity = new List<City>
        {
            new City{Name = "London", Country = "UK", Population = 8539000},
            new City{Name = "New York", Country = "US", Population = 9539000},
            new City{Name = "Ho Chi Minh", Country = "VN", Population = 10539000}
        };

        public IEnumerable<City> Cities => listCity;

        public void AddCity(City newCity)
        {
            listCity.Add(newCity);
        }
    }
}
