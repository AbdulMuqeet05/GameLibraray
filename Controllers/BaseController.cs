using GameLibrary.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Controllers {
    
    public abstract class BaseController:Controller {
        protected readonly GameLibraryContext _db;

        public BaseController(GameLibraryContext context)
        {
             _db=context;
        }
    }
}