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
        static int lives = 1;
        static int healthPotion = 20;
        static int currentHealthStatus = 0;
        


        static int enemyLives = -1;
        static int enemyHealth = 0;
        static int enemyShield = 0;

        static int monsterAttack = 200;



        static string[] healthStatus = new string[6];
        static string[] weaponName = new string[5];
        static int[] weaponDamage = new int[5];
        static void Main(string[] args)
        {

            ArraysInilization();

            StartScreen();
            Console.ReadKey(true);
            Console.Clear();


            ChangeWeapon(3);

            DoDamage(1);
            ShowHUD();
            EnemyHUD();
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
            healthStatus[5] = " <DEAD> ";

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
            weaponDamage[1] = 5;
            weaponDamage[0] = 1;
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
            if (health > 100)
            {
                health = 100;
            }

            Console.WriteLine("You Have Been Healed!");

            // error Checking....

            if (health < 0)
            {
                Console.WriteLine("Health is broken....");
            }
            if (health > 100)
            {
                Console.WriteLine("Health is broken....");
            }

        }

        static void OneUp()
        {
            lives = lives + 1;
            health = 100;
            RegenerateShield(1);

        
            Console.WriteLine("You got a 1UP!");

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
                        lives = 0;
                    }
                }
            }
            // Error Checking.....
            if (lives < 0)
            {
                Console.WriteLine("Lives are broken.....");
            }
        }

        static void DoDamage(int damage)
        {
            enemyShield = enemyShield - weaponDamage[weapon];



            // Range Checking and "Spill over effect"
            if (enemyShield < 0)
            {
                
                enemyHealth = enemyHealth + enemyShield;
                enemyShield = 0;

                if (enemyHealth <= 0)
                {
                    enemyLives = enemyLives - 1;
                    enemyHealth = 100;
                    enemyShield = 100;

                    if (enemyLives <= 0)
                    {
                        Console.WriteLine("You Kill Your Enemy!");
                        YouWin();

                        enemyLives = 0;

                    }
                }
            }
            // Error Checking.....
            if (enemyLives < 0)
            {
                enemyLives = 0;
                Console.WriteLine(" Enemy Lives are broken.....");
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

            if (health == 0)
            {
                currentHealthStatus = 5;
            }



        }

        static void EnemyHUD()
        {
            HealthStatusCheck();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                         ENEMY HUD                                                                                                         ");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("    Lives:  " + enemyLives + "                                            ");
            Console.WriteLine("    Health: " + enemyHealth + healthStatus[currentHealthStatus] + "                       ");
            Console.WriteLine("   Shield:  " + enemyShield + "                                           ");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("");
            Console.ResetColor();
        }
        static void ShowHUD()
        {
            HealthStatusCheck();
           
            Console.WriteLine("                           HUD                                                                                                         ");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("    Lives:  " + lives + "                                            ");
            Console.WriteLine("    Health: " + health + healthStatus[currentHealthStatus] + "                       ");
            Console.WriteLine("   Shield:  " + shield + "                                           ");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("                                                  ");
            Console.WriteLine("    HEAL             <Player Health goes up>)");
            Console.WriteLine("   " + weaponName[weapon] + "        <Player does " + weaponDamage[weapon] + " Damage>");
        }

        static void YouWin()
            {

            // 1UP for winning  //

            OneUp();




            }
        static void GameOver()
        {

            lives = 0;
            health = 0;
            shield = 0;
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
