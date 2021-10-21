using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemv1._0
{
    class Program
    {
        static int weapon = 0;
        static int health = 100;
        static int shield = 100;
        static int lives = 3;
        static int healthPotion = 20;
        static int currentHealthStatus = 0;
        

        static int monsterAttack = 200;
       
        

        static string[] healthStatus = new string[5];
        static string[] weaponName = new string[5];
        static int[]  weaponDamage = new int[5];
        static void Main(string[] args)
        {

            

            StartScreen();
            Console.ReadKey(true);

            Console.Clear();
            

            ArraysInilization();
            ChangeWeapon(3);
            RegenerateShield(1);
            Heal(1);
            ShowHUD();
            Console.ReadKey(true);
        }

       
        
        static void ArraysInilization()
        {
            // Health Status Array Strings 
            healthStatus[0] = " <Imminent Danger>";
            healthStatus[1] = " <Badly Hurt>";
            healthStatus[2] = " <Hurt>";
            healthStatus[3] = " <Healthy>";
            healthStatus[4] = " <Perfectly Healthy>";

            // Weapon Name Array Strings 
            weaponName[4] = "LONG SWORD";
            weaponName[3] = "BATTLE AXE";
            weaponName[2] = "DAGGERS   ";
            weaponName[1] = "SPEAR     ";
            weaponName[0] = " CLUB    ";

            // Weapon Damage Array ints
            weaponDamage[4] = 25;
            weaponDamage[3] = 15;
            weaponDamage[2] = 10;
            weaponDamage[1] =  5;
            weaponDamage[0] =  1;
        }
        static void RegenerateShield(int hp)
        {
            shield = shield + 100;

            // Range Checking.....
            if (shield > 100)
            {
                shield = 100;
                Console.WriteLine("Your Shield Has Regenerated!");
            }

            // Error Checking......
            if (shield < 0)
            {
                Console.WriteLine("Shield is broken....");
            }
        }
        static void Heal(int hp)
        {

            health = health + healthPotion;

            // Range Checking.....
            if ( health > 100)
            {
                health = 100;
            }

            Console.WriteLine("You Have Been Healed!");

            // error Checking....

            if (health < 0)
            {
                Console.WriteLine("Health is broken....");
            }

        }
        static void TakeDamage(int damage)
        {
            shield = shield - monsterAttack;



            // Range Checking and "Spill over effect"
            if (shield < 0)
            {
                health = health + shield;
                shield = 0;

                if (health <= 0)
                {
                    lives = lives - 1;
                    health = 100;
                    shield = 100;

                    if (lives <= 0)
                    {
                        Console.Clear();
                        GameOver();
                    }
                }
            }
            // Error Checking.....
            if (lives < 0)
            {
                Console.WriteLine("Lives are broken.....");
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
            Console.WriteLine("                           HUD                                                                                                         ");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("    Lives:   " + lives + "                                            ");
            Console.WriteLine("    Health: " + health + healthStatus[currentHealthStatus] + "                       ");
            Console.WriteLine("   Shield:  " + shield + "                                           ");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("                                                  ");
            Console.WriteLine("    HEAL             <Player Health goes up>)"  );
            Console.WriteLine("   "  +   weaponName[weapon] + "        <Player does " + weaponDamage[weapon] + " Damage>");
        }

        static void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                  |||||||    ||||     |    |    |||||||     ||||||    |     ||   |||||||   ||||||    ||||");
            Console.WriteLine("                 ||||||||   ||||||   |||  |||  |||||| |    |||  |||  ||     ||  |||||| |  |||  |||   ||||");
            Console.WriteLine("                 ||        |||   ||  |||  |||  ||    |     ||    ||  ||     ||  ||    |   ||    ||   ||||");
            Console.WriteLine("                 ||        ||    ||  ||||||||  ||          ||    ||  ||     ||  ||        ||    ||   ||||");
            Console.WriteLine("                 ||  ||||  ||    ||  ||||||||  ||||||||    ||    ||  ||     ||  ||||||||  ||    ||   ||||");
            Console.WriteLine("                 ||   |||  ||    ||  || || ||  ||||||||    ||    ||  ||     ||  ||||||||  ||||||||    || ");
            Console.WriteLine("                  |    |   ||||||||  ||    ||  ||          ||    ||  ||     ||  ||        |||||||     || ");
            Console.WriteLine("                 ||    ||  ||    ||  ||    ||  ||          ||    ||   ||   ||   ||        ||  ||         ");
            Console.WriteLine("                 ||||||||  ||    ||  ||    ||   |||||||     |||||||   |||||||    |||||||  ||   ||     || ");
            Console.WriteLine("                  |||  |   |      |  ||    ||   |||| ||      |||||     |||       ||||| |  |     ||    || ");
            Console.ResetColor();

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
