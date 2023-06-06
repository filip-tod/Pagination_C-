using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging.Model.common
{
    public interface IUsers
    {
         int Id { get; set; }
         string Nameuser { get; set; }
         string LastNameuser { get; set; }
         string Email { get; set; }

    }
}
