using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog2.Models.Identity
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser> // kullanıcağımız sınıfı gönderdik
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options ) : base(options)
        {

        }
    }
}
