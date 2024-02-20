using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameLibrary;
using GameLibrary.Model;
using Microsoft.AspNetCore.Cors;
using GameLibrary.Request_and_Response;

namespace GameLibrary.Controllers {
  //  [ApiController]
    
    
    public class GameLibraryController:BaseController {
        public GameLibraryController(GameLibraryContext context):base(context){}
        
        [Route ("api/games/add"), HttpPost]
        public BaseResponse add([FromBody] GameRequest req)
        {

            Console.WriteLine("data should be here "+req.name);
            return new BLL.Game(_db).createGame(req);
            
        }
        [Route ("api/games/view"), HttpGet]
        public GameResponse[] Get()
        {
            return new BLL.Game(_db).getGames();
        }
        [Route ("api/games/delete"), HttpPost]
        public BaseResponse delete([FromBody] GameResponse res)
        {
            return new BLL.Game(_db).deleteGame(res);
        }

        [Route ("api/publisher/view"), HttpGet]
        public List<PublisherResponse> PubliserGet()
        {
            
            return new BLL.Game(_db).getPubliser();
        }
        [Route ("api/genre/view"), HttpGet]
        public List<GenreResponse> GenreGet()
        {
            
            return new BLL.Game(_db).getGenre();
        }
    }
 }