using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Entities.DTOs
{
    public class UserLoginResultDto : IDto
    {
        public AccessToken AccessToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<OperationClaim> Role { get; set; }
        //public string MobilePhone { get; set; }
        //public string Address { get; set; }
    }
}
