using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lr1.Accounts;

namespace Lr1.Games
{
    public abstract class BaseGame {

        public decimal IndexGame { get; set; }
        public decimal Game_rating { get; set; }

        public BaseGame(decimal index_game, decimal game_rating)
        {

            IndexGame = index_game;
            Game_rating = game_rating;

        }

        public decimal getRating()
        {
            return Game_rating;
        }

    }
}
