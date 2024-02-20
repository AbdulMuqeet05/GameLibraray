using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;

namespace GameLibrary.Model
{
      public class Game:BaseIdentity
    {
        
        public string name {get;set;}
        public virtual genre genre {get;set;}
        public string platform {get;set;}
        public DateTime releaseDate {get;set;}
        public int noOfPlayers {get;set;}
        public string boxArt{get;set;}
        public virtual Publisher publisher {get;set;}

    }

    public class Publisher:BaseIdentity {
        public string name {get;set;}
    }

    public class genre:BaseIdentity {
        public string name {get;set;}
    }
    

}


