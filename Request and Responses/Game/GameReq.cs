using System;

namespace GameLibrary.Request_and_Response {

    public class GameRequest {
        
        public string name {get;set;}
        public string platform {get;set;}
        public int genre {get;set;}
        public string release_date {get;set;}
        public string no_of_player {get;set;}
        public string file {get;set;}
        public int publisher {get;set;}
    }
}