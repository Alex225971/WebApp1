using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess.Repository.IRepository;
using WebApp.Models.Models;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApp.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRespository 
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
    }
}
