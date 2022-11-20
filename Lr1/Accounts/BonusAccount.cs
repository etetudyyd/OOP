using Lr1.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr1.Accounts
{
    public class BonusAccount : BaseAccount
    {
        private bool WinningStreak;

        private double Bonus { get; set; }
        public BonusAccount(string name, decimal currentrating, decimal gamecount)
            : base(name, currentrating, gamecount)
        {
            Bonus = 1.1;
        }

        public BonusAccount(int bonus, string name, decimal currentrating, decimal gamecount)
            : base(name, currentrating, gamecount)
        {
            Bonus = bonus;
        }

        public override decimal GiveBonusRating(int rating)
        {
            return (decimal)(rating * Bonus);
        }

        public override void WinGame(BaseAccount player, BaseGame game, int gamemode)
        {


            switch (gamemode)
            {
                case 1:
                    if (WinningStreak)
                    {
                        CurrentRating = CurrentRating + GiveBonusRating((int)game.getRating());
                    }
                    else
                    {
                        CurrentRating = CurrentRating + game.getRating();
                    }

                    WinningStreak = true;
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
                            if (WinningStreak)
                            {
                                CurrentRating = CurrentRating + GiveBonusRating((int)game.getRating());
                            }
                            else
                            {
                                CurrentRating = CurrentRating + game.getRating();
                            }

                            WinningStreak = true;
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

        public override void LoseGame(BaseAccount player, BaseGame game, int gamemode)
        {

            switch (gamemode)
            {
                case 1:
                    CurrentRating = CurrentRating - game.getRating();
                    WinningStreak = false;
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
                            CurrentRating = CurrentRating - game.getRating();
                            WinningStreak = false;
                            GameCount++;
                            break;
                        case 2:
                            break;

                 default :
                            throw new ArgumentOutOfRangeException(nameof(gamemode), "Exeption catch wrong rating, please enter requiring value!");

                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gamemode), "Exeption catch wrong rating, please enter requiring value!");
            }
        }


    }
}
