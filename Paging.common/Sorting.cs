using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging.common
{
    public class Sorting
    {
        public enum SortBy
        {
            Nameuser,
            LastNameuser,
            Email
        }

        public enum SortOrder
        {
            Ascending,  // 0 index
            Descending  // 1 index
        }

        public SortBy SortByField { get; set; }
        public SortOrder SortOrderType { get; set; }
    }
}
