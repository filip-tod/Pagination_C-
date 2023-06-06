using Paging.Model;
using Paging.Service;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Paging.common;

namespace Paging.Controllers
{
    public class UsersController : ApiController
    {

        public HttpResponseMessage Get(int pageSize=10,int currentPageNumber=1, int counter= 0, string name="", string lastname="", string email="", string sortingOrder = "", string orderBy = "")
        {
            PagingList paging = new PagingList();
            Filtering filter = new Filtering();
            Sorting sort = new Sorting();
            sort.SortOrder = sortingOrder;
            sort.SortBy = orderBy;
            filter.Name = name;
            filter.LastName = lastname;
            filter.Email = email;   
            paging.PageSize = pageSize; 
            paging.CurrentPageNumber = currentPageNumber;   
            paging.Counter = counter;

            UsersService user = new UsersService();
            Task<List<Users>> result = user.Get(paging, filter, sort);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "We could not find you'r league");
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}