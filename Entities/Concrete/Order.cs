using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int CustomerId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public bool? IsReady { get; set; }
        public bool? IsPreparing { get; set; }   

    }
}
