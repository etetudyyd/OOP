using Lr1.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lr1.Accounts
{
    public class VipAccount : BaseAccount
    {

        private double Bonus { get; set; }
        public VipAccount(string name, decimal currentrating, decimal gamecount)
            : base(name, currentrating, gamecount)
        {
            Bonus = 0.5;
        }

        public VipAccount(int bonus,string name, decimal currentrating, decimal gamecount)
            : base(name, currentrating, gamecount)
        {
            Bonus = bonus;
        }

        public override decimal GiveBonusRating(int rating)
        {
            return (decimal)(rating * Bonus);
        }

        public override void LoseGame(BaseAccount player, BaseGame game , int gamemode)
        {
            switch (gamemode)
            {
                case 1:
                    CurrentRating = CurrentRating - GiveBonusRating((int)game.getRating());

                    GameCount++;
                    break;
                case 2:
                    GameCount++;
                    break;
                case 3:
                    Console.WriteLine("Enter player, which rating on risk:\n1 - " + player.Name + "\n2 - " + player.OpponentName);
                    string strriskplayer = Console.ReadLine();
                    int riskplayer = Convert.ToInt32(strriskplayer);


                    switch (riskplayer)
                    {
                        case 1:
                            CurrentRating = CurrentRating - GiveBonusRating((int)game.getRating());
                            GameCount++;
                            break;
                        case 2:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(gamemode), "Exeption catch wrong rating, please enter requiring value!");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gamemode), "Exeption catch wrong rating, please enter requiring value!");


            }
        }
    }
}
