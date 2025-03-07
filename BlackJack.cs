using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace BlackJack
{
	public class Program
	{
		static void returnCards(int i) 
		{
		    if (i < 11) 
			{
		        Console.Write(i + " ");
		    }
		    else if (i == 11) 
			{
		        Console.Write("J ");
		    }
		    else if (i == 12) 
			{
		        Console.Write("Q ");
		    }
		    else if (i == 13) 
			{
		        Console.Write("K ");
		    }
		    else if (i == 14) 
			{
		        Console.Write("A ");
		    }
		}
		static int cardValues(int i)
		{
		    if (i < 11) 
			{
		        return i;
		    }
		    else if (i == 14) 
			{
		        return 11;
		    }
		    else 
			{
		        return 10;
		    }
		}
		
		public static void Main(string[] args)
		{
		    bool ace = false;
		    bool aceDealer = false;
			bool lost = false;
		    int playerScore = 0;
		    int dealerScore = 0;
		    long money = 50000;
		    long bet = 0;
		    int[] playerCards = new int[3];
		    int[] dealerCards = new int[3];
		    Random rnd = new Random();
		    
		    
			Console.WriteLine("Welcome in Random Name Casino one of the best in Vegas");
			Console.WriteLine("Your starting balance is 50000$");
			Console.WriteLine("");
			
			while (money > 0 && money < 1000000) 
			{
				dealerScore = 0;
				playerScore = 0;
				ace = false;
				aceDealer = false;
			    Console.WriteLine("How much do you want to bet?");
			    bet = long.Parse(Console.ReadLine());
			    if (bet > money) 
				{
					Console.WriteLine("You don't have enough money");
					break;
				}
			    playerCards[0] = rnd.Next(2, 15);
			    playerCards[1] = rnd.Next(2, 14);
			    playerCards[2] = rnd.Next(2, 14);
			    dealerCards[0] = rnd.Next(2, 15);
			    dealerCards[1] = rnd.Next(2, 14);
			    dealerCards[2] = rnd.Next(2, 14);
			    
			    Console.Write("Dealer card is: ");
			    returnCards(dealerCards[0]);
			    Console.WriteLine("");
			    Console.Write("Here are your cards: ");
			    returnCards(playerCards[0]);
			    returnCards(playerCards[1]);
		        playerScore += cardValues(playerCards[0]) + cardValues(playerCards[1]);
		        if (cardValues(playerCards[0]) == 11 || cardValues(playerCards[1]) == 11 || cardValues(playerCards[2]) == 11)
				{
		            ace = true;
		        }
				if (cardValues(dealerCards[0]) == 11 || cardValues(dealerCards[1]) == 11 || cardValues(dealerCards[2]) == 11)
				{
		            aceDealer = true;
		        }
			    Console.WriteLine("");
			    Console.WriteLine("");
			    if (cardValues(playerCards[0]) + cardValues(playerCards[1]) == 21) 
				{
			        Console.WriteLine("Congratulations you got BlackJack");
					money += bet;
					continue;
			    }
			    else 
				{
			        Console.WriteLine("Do you want to stand (S) hit (H) or double (D)");
			        char action = char.Parse(Console.ReadLine());
					while (action == 'D' && bet*2 > money) {
						Console.WriteLine("You don't have enough money please choose again");
						action = char.Parse(Console.ReadLine());
					}
			        switch (action)
			        {
			            case 'S':
			                Console.WriteLine("Alright");
							Console.WriteLine("Your score is: " + playerScore);
			                break;
			            case 'H':
			                Console.Write("Your third card is: ");
			                returnCards(playerCards[2]);
			                Console.WriteLine("");
							playerScore += cardValues(playerCards[2]);
			                if (cardValues(playerCards[0]) + cardValues(playerCards[1]) + cardValues(playerCards[2]) > 21 && ace == false) 
							{
			                    Console.WriteLine("You are over 21 so you lose");
								lost = true;
								playerScore -= cardValues(playerCards[2]);
			                }
							else if (cardValues(playerCards[0]) + cardValues(playerCards[1]) + cardValues(playerCards[2]) > 21 && ace == true)
							{
								playerScore -= 10;
								Console.WriteLine("Your score is: " + playerScore);
							}
							else 
							{
								Console.WriteLine("Your score is: " + playerScore);
							}
			                Console.WriteLine("");
			                break;
						case 'D':
							bet *= 2;
			                Console.Write("Your third card is: ");
			                returnCards(playerCards[2]);
			                Console.WriteLine("");
							playerScore += cardValues(playerCards[2]);
			                if (cardValues(playerCards[0]) + cardValues(playerCards[1]) + cardValues(playerCards[2]) > 21 && ace == false)
							{
			                    Console.WriteLine("You are over 21 so you lose");
								lost = true;
								playerScore -= cardValues(playerCards[2]);
			                }
							else if (cardValues(playerCards[0]) + cardValues(playerCards[1]) + cardValues(playerCards[2]) > 21 && ace == true) 
							{
								playerScore -= 10;
								Console.WriteLine("Your score is: " + playerScore);
							}
							else 
							{
								Console.WriteLine("Your score is: " + playerScore);
							}
			                Console.WriteLine("");
			                break;
			        }
			    }
			    Console.WriteLine("Now it's the time for dealer to reveal his card");
				Console.Write("His cards are: ");
				returnCards(dealerCards[0]);
				returnCards(dealerCards[1]);
				dealerScore += cardValues(dealerCards[0]) + cardValues(dealerCards[1]);
				Console.WriteLine("");
			    
				if (lost == true)
				{
					Console.WriteLine("Dealer decided to stand");
				}
				else if (cardValues(dealerCards[0]) + cardValues(dealerCards[1]) < 17 && dealerScore < playerScore) 
				{
				    Console.Write("Dealer decided to hit his last card is: ");
				    returnCards(dealerCards[2]);
					dealerScore += cardValues(dealerCards[2]);
				    Console.WriteLine("");
					if (cardValues(dealerCards[0]) + cardValues(dealerCards[1]) + cardValues(dealerCards[2]) > 21 && aceDealer == false) 
					{
						Console.WriteLine("Dealer score is above 21 so he lose");
						dealerScore -= cardValues(dealerCards[2]);
					}
					else if (cardValues(dealerCards[0]) + cardValues(dealerCards[1]) + cardValues(dealerCards[2]) > 21 && aceDealer == true) 
					{
						dealerScore -= 10;
						Console.WriteLine("Dealer score is: " + dealerScore);
					}
					else 
					{
						Console.WriteLine("Dealer score is: " + dealerScore);
					}
				}
				else 
				{
					Console.WriteLine("Dealer decided to stand");
				}
				if (lost == false && playerScore > dealerScore) 
				{
					Console.WriteLine("YOU WIN!");
					money += bet;
				}
				else if (dealerScore > playerScore && lost == false) 
				{
					Console.WriteLine("Dealer wins");
					money -= bet;
				}
				else if (lost == true && dealerScore < 22) 
				{
					Console.WriteLine("Dealer wins");
					money -= bet;
				}
				else if (dealerScore == playerScore)
				{
					Console.WriteLine("It is a tie");
				}
				else 
				{
					Console.WriteLine("Nobody wins");
					money -= bet;
				}
			    
				Console.WriteLine("");
			    Console.WriteLine("Your balance is now " + money + "$");
			}
			if (money == 0) 
			{
				Console.WriteLine("Random Name Casino took every penny from you");
			}
			else if (money > 1000000)
			{
				Console.WriteLine("You won a ton of money congratulations");
			}
		}
	}
}