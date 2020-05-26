﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProj.Models
{
    public class Employee


    {   [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Zip { get; set; }
        
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
       
        public IdentityUser IdentityUser { get; set; }
    }
}