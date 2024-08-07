﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models.Models;
using WebApplication1.Models;

namespace WebApp.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRespository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser? applicationUser);
    }
}
