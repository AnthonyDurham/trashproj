using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProj.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string pickupDay { get; set; }
        public string startTerminationDay { get; set; }
        public string endTerminationDay { get; set; }
        
        [ForeignKey("IdentityUser")]
        public string IDentityUSerId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }  
}
