using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cslabWeb.Areas.Admin.Models
{
    public class AdminContext: DbContext
    {
        public DbSet<AdminCs> admins { get; set; }
        public DbSet<Log> logs { get; set; }
    }
}