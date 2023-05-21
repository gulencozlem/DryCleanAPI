using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Adress : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string FullAdress { get; set; }
        public short BuildingNumber { get; set; }
        public short Floor { get; set; }
        public short ApartmentNumber { get; set; }
        public string AdressRecipe { get; set; }
    }
}
