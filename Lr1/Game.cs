using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1
{
    public class Game
    {

       public GameAccount Winner { get; set; }
       public decimal IndexGame { get; set; }
       public decimal Game_rating { get; set; }

       

        public Game(GameAccount winner, decimal index_game, decimal game_rating)
        {
            
            Winner = winner;
            IndexGame = index_game;
            Game_rating = game_rating;

        }
    }
}
