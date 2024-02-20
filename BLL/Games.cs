using System;
using System.Collections.Generic;
using System.Linq;
using GameLibrary.Model;
using GameLibrary.Request_and_Response;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.BLL {
    public class Game {
        private readonly GameLibraryContext _db;
        public Game (GameLibraryContext context) {
            _db=context;
        }
        public GameResponse[] getGames(){
            try {
                var db=_db;
            GameResponse[] toReturn;
            GameLibrary.Model.Game[] games =db.games.Include(m=>m.genre).Include(m=>m.publisher).ToArray();
            if(games.Length==0) return new GameResponse[0];
            toReturn=new GameResponse[games.Length];
            for(int i=0; i<games.Length; i++) {
                toReturn[i] =new GameResponse (){
                    name=games[i].name,
                    platform=games[i].platform,
                    genre=games[i].genre.name,
                    release_date=games[i].releaseDate.ToString(),
                    no_of_player=games[i].noOfPlayers,
                    publisher=games[i].publisher.name,
                    file=games[i].boxArt
                };
            }
            return toReturn;
            }
            catch(Exception ex) {
                return new GameResponse[0];
            }
            
        }
        public BaseResponse createGame(GameRequest req) {
            try {
                 var db=_db;
            genre genre= db.genre.Where(c=>c.Id==req.genre).SingleOrDefault();
            Publisher publisher =db.publisher.Where(c => c.Id == req.publisher).SingleOrDefault();
            DateTime release_date= DateTime.Parse(req.release_date);
            int noOfPlayer=int.Parse(req.no_of_player);
            if(db.games.Where(c=>c.name==req.name).FirstOrDefault()!=null) {
                return new BaseResponse() {
                developerMessage="this game already exists, please change the name of the game",
                status=240
            };
            }
            db.games.Add(new GameLibrary.Model.Game() {
                name=req.name,
                platform=req.platform,
                genre=genre,
                releaseDate=release_date,
                noOfPlayers=noOfPlayer,
                publisher=publisher,
                boxArt=req.file
            });
            return (1==db.SaveChanges()) ? new BaseResponse() {
                developerMessage="game created",
                status=200
            }: new BaseResponse() {
                developerMessage="game not created",
                status=500
            };
            }
            catch(Exception ex) {
                return new BaseResponse() {
                developerMessage="Problem with the data",
                status=240
            };
            }
           
        }
        public BaseResponse deleteGame(GameResponse res) {
            var db=_db;
            var gameToRemove= db.games.Where(c=>c.name==res.name).FirstOrDefault();
            
            db.games.Remove(gameToRemove);
             return (1==db.SaveChanges()) ? new BaseResponse() {
                developerMessage="Game deleted successfully",
                status=200
            }: new BaseResponse() {
                developerMessage="not deleted",
                status=500
            };
        }
        public BaseResponse createPubliser(string pub_name) {
            var db=_db;
        
            db.publisher.Add(new Publisher(){
                name=pub_name
            });
            return (1==db.SaveChanges()) ? new BaseResponse() {
                developerMessage="publisher created",
                status=200
            }: new BaseResponse() {
                developerMessage="not created",
                status=500
            };
        }
        public BaseResponse createGenre(string genre_name) {
            var db=_db;
            

            db.genre.Add(new genre(){
                name=genre_name
            });
            return (1==db.SaveChanges()) ? new BaseResponse() {
                developerMessage="Genre created",
                status=200
            }: new BaseResponse() {
                developerMessage="not created",
                status=500
            };
        }

        public List<PublisherResponse> getPubliser() {
            var db=_db;
            List<PublisherResponse> toReturn=new List<PublisherResponse>();
            GameLibrary.Model.Publisher[] _publisher= db.publisher.ToArray();
            if(_publisher.Length==0) {
                seedInitialDataForPublisher();
                _publisher= db.publisher.ToArray();
                }
            foreach(var entity in _publisher) {
                toReturn.Add(new PublisherResponse() {
                    id=entity.Id,
                    name=entity.name
                });
            }
            return toReturn;

        }
        public List<GenreResponse> getGenre() {
            var db=_db;
            List<GenreResponse> toReturn=new List<GenreResponse>();
            GameLibrary.Model.genre[] _genre= db.genre.ToArray();
            if(_genre.Length==0) {
                seedInitialDataForGenre();
                _genre= db.genre.ToArray();
                }
            foreach(var entity in _genre) {
                toReturn.Add(new GenreResponse() {
                    id=entity.Id,
                    name=entity.name
                });
            }
            return toReturn;

        }
        public bool seedInitialDataForGenre(){
            var db=_db;
            List<genre> genreList=new List<genre>();
            if(db.genre.ToList().Count!=0) {
                return true;
            }
            else{
                genreList.Add(new genre(){
                    name="sports"
                });
                genreList.Add(new genre() {
                    name="Fighting"
                });
                genreList.Add(new genre() {
                    name="Role Playing"
                });
                genreList.Add(new genre() {
                    name="1st person shooting"
                });
                genreList.Add(new genre() {
                    name="Open World"
                });
                db.genre.AddRange(genreList);
                db.SaveChanges();
                return true;
            }
            
        }
        public bool seedInitialDataForPublisher(){
            var db=_db;
            List<Publisher> publishers=new List<Publisher>();
            if(db.publisher.ToList().Count!=0) {
                return true;
            }
            else{
                publishers.Add(new Publisher(){
                    name="Sony Interactive Entertainment"
                });
                publishers.Add(new Publisher() {
                    name="Rockstar"
                });
                publishers.Add(new Publisher() {
                    name="EA Sports"
                });
                publishers.Add(new Publisher() {
                    name="Edidos"
                });
                db.publisher.AddRange(publishers);
                db.SaveChanges();
                return true;
            }
            
        }

    }
}