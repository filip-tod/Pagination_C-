using Paging.common;
using Paging.Model;
using Paging.Repository;
using Paging.Service.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging.Service
{
    public class UsersService : IUsersService
    {
        public async Task<List<Users>> Get(PagingList paging, Filtering filter, Sorting sortingOrder)
        {
            try
            {
                UsersRepository repository = new UsersRepository();
                var result = await repository.Get(paging, filter);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
