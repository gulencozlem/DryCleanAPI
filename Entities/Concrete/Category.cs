using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }        
        public bool? IsPopular { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }  

    }
}
