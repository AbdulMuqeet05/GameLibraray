using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
namespace GameLibrary.Model {

    public class BaseIdentity {
        [Key]
        public int Id {get;set;}
        public bool enable {get;set;}
        

    }
}