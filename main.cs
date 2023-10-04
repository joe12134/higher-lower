using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace higherlowergame
{
    internal class Program
    {
        const string cards= "A23456789TJQK";
        const string suits = "♥♦♣♠";
        
        public static string GetCard(List<string> usedCards)
        {
            Random ri = new Random();
            int cardNum = ri.Next(12);
            int suit = ri.Next(3);
            string card = cards[cardNum].ToString() + suits[suit].ToString();

            if (usedCards.Contains(card))
            {
                return GetCard(usedCards);
            }
            usedCards.Add(card);
            return card;
            


        }
        public static void DisplayCard(string card)
        {
            Console.BackgroundColor = ConsoleColor.White;
            string suit = card[1].ToString();
            if (suit == "♥" || suit == "♦")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            } else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;

            int cardWidth = 8;
            int cardHeight = 6;

            Console.WriteLine($"{card}       \n         \n         \n         \n         \n       {card}\n");
            int endX = Console.CursorLeft;
            int endY = Console.CursorTop;

            int cardNum;
            string cns = card[0].ToString();

            if (cns == "A")
            {
                cardNum = 1;
            } else if (cns == "J" || cns =="Q" || cns ==  "K")
            {
                cardNum = -1;

            } else
            {
                cardNum = int.Parse(cns);
            }

            int xInterval = 3;
            int yInterval = 2;

            for (int n = startY; n<=startY+cardHeight; n++)
            {
                for (int i = startX; i <= startX+cardWidth; i++)
                {
                   
                    Console.SetCursorPosition(i, n);
                    if ( n-startY>=1 && n - startY< startY+cardHeight-1 && i - startX >= 1 && i - startX < startX+cardWidth)
                    {
                        if (cardNum > 0 && i%xInterval==0 )
                        {
                            Console.Write(suit);
                            
                            cardNum--;
                        } else if (cardNum == -1)
                        {
                            Console.Write(cns);
                        }
                        
                    }
                       
                    
                    
                }

            }
           



            Console.SetCursorPosition(endX, endY);
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;


        }
        
        static void Main(string[] args)
        {
            List<String> usedCards = new List<string>();
            string card = GetCard(usedCards);
            DisplayCard(card);
            
        }


    
}
}
