using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging.common
{
    public class PagingList
    {
        public int PageSize { get; set; }

        public int CurrentPageNumber { get; set; }

        public int Counter { get; set; }
    }
}
