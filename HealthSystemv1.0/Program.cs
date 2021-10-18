using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemv1._0
{
    class Program
    {
        static int weapon = 1;
        static int health = 100;
        static int shield = 100;
        static int lives = 3;
        static int healthPotion = 20;
        static int currentHealthStatus = 0;

        static int monsterAttack = 110;
       
        

        static string[] healthStatus = new string[5];
        static string[] weaponName = new string[5];
        static void Main(string[] args)
        {

            // Health Status Array Strings 
            healthStatus[0] = " <Imminent Danger>";
            healthStatus[1] = " <Badly Hurt>";
            healthStatus[2] = " <Hurt>";
            healthStatus[3] = " <Healthy>";
            healthStatus[4] = " <Perfectly Healthy>";

            // Weapon Name Array Strings 
            weaponName[4] = "Long Sword";
            weaponName[3] = "Battle Axe";
            weaponName[2] = "  Daggers";
            weaponName[1] = "   Spear";
            weaponName[0] = "   club";



            TakeDamage(0);
            ShowHUD();
            Console.ReadKey(true);
        }

        static void TakeDamage(int damage)
        {
            shield = shield - monsterAttack;

            if (shield <0)
            {
                health = (shield - monsterAttack) + health;
                shield = 0;

                Console.WriteLine("this is working");
                
            }
        }

        static void ChangeWeapon(int currentWeapon)
        {
            weapon = currentWeapon;
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
            Console.WriteLine("|   Lives:   " +  lives + "                      |      Heal              <Restores " + healthPotion + " points of health>                                     |");
            Console.WriteLine("|   Health: " + health +  healthStatus[currentHealthStatus] + " |   Use Shield           <Protects you from incomming attacks>                              |");
            Console.WriteLine("|   Shield:  " + shield + "                     |   " + weaponName[weapon] + "                                                                                 |");
            Console.WriteLine("+-----------------------------------+-------------------------------------------------------------------------------------------+");
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
