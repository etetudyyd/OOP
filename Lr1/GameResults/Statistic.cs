using Lr1.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1.GameResults
{
    public class Statistic
    {
        public BaseAccount Winner { get; set; }
        public decimal IndexGame { get; set; }
        public decimal Game_rating { get; set; }
        public decimal CurrentRating { get; set; }

        public Statistic(BaseAccount winner, decimal index_game, decimal game_rating, decimal current_rating)
        {

            Winner = winner;
            IndexGame = index_game;
            Game_rating = game_rating;
            CurrentRating = current_rating;

        }
    }
}
