﻿using Paging.common;
using Paging.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paging.Service.common
{
    public interface IUsersService
    {
        Task<List<Users>> Get(PagingList paging, Filtering filter);
    }
}
