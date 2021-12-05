using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevMarcos.UI.Site.Modulos.Identity.Data
{
    public class AspNetCoreIdentityContext : IdentityDbContext<IdentityUser>
    {
        public AspNetCoreIdentityContext(DbContextOptions<AspNetCoreIdentityContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
