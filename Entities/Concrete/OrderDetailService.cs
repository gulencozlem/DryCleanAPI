using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class OrderDetailService : IEntity
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int ServiceId { get; set; }
    }
}
