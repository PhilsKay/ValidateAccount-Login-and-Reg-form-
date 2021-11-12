using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidateAccount.Models;

namespace ValidateAccount.Data
{
    public class myDbcontext : DbContext
    {
        public myDbcontext(DbContextOptions<myDbcontext> options) : base(options)
        {

        }
        public DbSet<AccountDatails> AccountDatails { get; set; }
    }
}
