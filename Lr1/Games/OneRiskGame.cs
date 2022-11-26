using System;
using Lr1.Accounts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1.Games
{
    public class OneRiskGame : BaseGame
    {
        public OneRiskGame(decimal index_game, decimal game_rating)
            : base(index_game)
        {
            Game_rating = game_rating;
        }

    }
}
