using Paging.Model.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging.Model
{
       public class Users : IUsers
       {
        public int Id { get; set; }
        public string Nameuser { get; set; }
        public string LastNameuser { get; set; }
        public string Email { get; set; }
        }
    
}
