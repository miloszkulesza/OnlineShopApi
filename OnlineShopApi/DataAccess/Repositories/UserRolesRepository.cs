using Microsoft.AspNetCore.Identity;
using OnlineShopApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopApi.DataAccess
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private ApplicationDbContext context;

        public UserRolesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<IdentityUserRole<string>> UserRoles => context.UserRoles;
    }
}
