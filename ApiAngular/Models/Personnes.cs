using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAngular.Models
{
    public class Personnes
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public String firstName { get; set; }
        [MaxLength(100)]
        public String lastName { get; set; }
        [MaxLength(80)]
        public String address { get; set; }
        [DataType(DataType.Date)]
        public DateTime birthDay { get; set; }
        [MaxLength(15)]
        public String phone { get; set; }
    }
}