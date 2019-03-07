using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cslabWeb.Areas.Admin.Models
{
    [Table("Log")]
    public class Log
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Macaddress { get; set; }
        public string Status { get; set; }
        public DateTime Datetime  { get; set; }
    }
}