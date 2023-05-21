using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
    }
}
