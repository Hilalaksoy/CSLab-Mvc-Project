using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cslabWeb.Areas.Admin.Models
{ 
    [Table("Admin")]
    public class AdminCs
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}