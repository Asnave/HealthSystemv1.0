using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemv1._0
{
    class Program
    {
        static int health = 60;
        static int shield = 100;
        static int lives = 3;
        static int healthPotion = 20;
        static int currentHealthStatus = 0;

        static string[] healthStatus = new string[5];
        static void Main(string[] args)
        {
            healthStatus[0] = "Imminent Danger";
            healthStatus[1] = "Badly Hurt";
            healthStatus[2] = "Hurt";
            healthStatus[3] = "Healthy";
            healthStatus[4] = "Perfectly Healthy";



            StartScreen();
            Console.ReadKey(true);
            ShowHUD();
            Console.ReadKey(true);
        }

        static void HealthStatusCheck()
        {
            if (health == 1)
            {
                currentHealthStatus = 0;
            }

            if (health >= 11)
            {
                currentHealthStatus = 1;
            }

            if (health <= 50)
            {
                currentHealthStatus = 1;
            }

            if (health >= 51)
            {
                currentHealthStatus = 2;
            }

            if (health >= 76)
            {
                currentHealthStatus = 3;
            }

            if (health == 100)
            {
                currentHealthStatus = 4;
            }

        }
        static void ShowHUD()
        {
            HealthStatusCheck();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                                                                                                                 ");
            Console.WriteLine("+-----------------------------------+-------------------------------------------------------------------------------------------+");
            Console.WriteLine("|   Lives: " + lives + "                        |   ---Heal---           <Restores " + healthPotion + " points of health>                                     |");
            Console.WriteLine("|   Health: " + health + " Health Status: " + healthStatus[currentHealthStatus]);

        }

        static void StartScreen()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("        |||||||||||     ||        ||||    ||||||          ||      ||||||||    ||||||||||    ||||||||||      ||||||          ||  ");
            Console.WriteLine("        |||||||||||||   ||        ||||||  ||||||||        ||    ||||||||||    ||||      ||  |||||||||||     ||||||||        ||  ");
            Console.WriteLine("          ||||||  |||||   ||||      ||||    ||||  ||||      ||  ||||    ||||    ||          ||||      ||||    ||||  ||||      ||");
            Console.WriteLine("          ||||    |||||   ||||      ||||    ||||    ||      ||  ||||      ||    ||          ||||      ||||    ||||    ||      ||");
            Console.WriteLine("          ||||      |||   ||||      ||||    ||||    ||||  ||||  ||||            ||||||      ||||      ||||    ||||    ||||  ||||");
            Console.WriteLine("          ||||      |||   ||||      ||||    ||||      ||  ||||  ||||  ||||||    ||||||      ||||      ||||    ||||      ||  ||||");
            Console.WriteLine("          ||||       ||     ||      ||||    ||||       || ||||  ||||    ||||      ||        ||||      ||||    ||||       || ||||");
            Console.WriteLine("          ||||||     ||     ||      ||||    ||||       || ||||    ||    ||||      ||    ||  ||||      ||||    ||||       || ||||");
            Console.WriteLine("            ||||||||||      ||||||||||      ||||         |||||      ||||||||      ||    ||    |||||||||       ||||         |||||");
            Console.WriteLine("            ||||||||||      ||||||||||      ||||         |||||      ||||||        ||||||||    ||||||||        ||||         |||||");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                            Dungeon Adventure Game                                                              ");
            Console.ResetColor();
            Console.WriteLine("                                          Press any button to begin                                                             ");
        }



    }
}
