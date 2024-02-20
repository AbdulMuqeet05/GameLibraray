using System;

namespace GameLibrary.Request_and_Response {

    public class GameResponse {
        
        public string name {get;set;}
        public string platform {get;set;}
        public string genre {get;set;}
        public string release_date {get;set;}
        public int no_of_player {get;set;}
        public string file {get;set;}
        public string publisher {get;set;}
    }
}