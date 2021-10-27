using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HealthSystemv1._0
{
    class Program
    {
        // Players ints //
        static int weapon = 0;
        static int health = 100;
        static int shield = 100;
        static int lives = 3;
        static int currentHealthStatus = 0;


        //Enemy ints //
        static int enemyLives = 1;
        static int enemyHealth = 100;
        static int enemyShield = 50;
        static int eCurrentHealthStatus = 0;
        static int monsterAttack = 20;


        // Arrays //
        static string[] healthStatus = new string[6];
        static string[] weaponName = new string[5];
        static int[] weaponDamage = new int[5];
        static void Main(string[] args)
        {

            ArraysInilization();

            UnityTesting();
            Console.ReadKey(true);
            Console.Clear();

            StartScreen();
            Console.ReadKey(true);
            health = 100;
            shield = 100;
            lives = 2;
            enemyHealth = 100;
            enemyHealth = 100;
            enemyLives = 1;

            ChangeWeapon(3);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" You travel down a long, torch lit halway.");
            Console.WriteLine(" A chest lies underneath one of the clutter filled spaces");
            Console.WriteLine(" Oviously you opne it, revealing:" + weaponName[weapon]);
            Console.WriteLine(" Picking it up you contiune down the hall until you reach a door");
            Console.WriteLine(" You go through the doorway.........");
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("A-HA!");
            Console.WriteLine("A Goblin Apears! Ready to attack!");
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            TakeDamage(2);
            ShowHUD();
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("You Get Ready to Attack!");
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            DoDamage(3);
            EnemyHUD();
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Goblin starts to snicker when comming in for another attack!");
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            TakeDamage(5);
            ShowHUD();
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("feeling weak, you use this turn to possibly heal and regenerate shield");
            RegenerateShield(100);
            Heal(30);
            ShowHUD();
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Goblin goes in for a attack!");
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            TakeDamage(0);
            ShowHUD();
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("You feel really charged up since the last attack!");
            DoDamage(10);
            ShowHUD();
            EnemyHUD();
            Console.ReadKey(true);

            Console.Clear();



        }

        static void UnityTesting()
        {

            // Heal Debugs 
           //Console.WriteLine("Testing Heal(int hp) should respect <= 100");
            health = 100;
            Heal(10);
            ///HealthStatusCheck();
            ///Console.WriteLine( "Health:" + health + " " + healthStatus[currentHealthStatus]);
            Debug.Assert(health <= 100);

            health = 80;
            Heal(10);
            Debug.Assert(health > 80);
            Debug.Assert(health <= 100);

            //Console.WriteLine("Testing Heal (int -10hp) shouldnt register a negative heal");
            health = 100;
            Heal(-10);
            Debug.Assert(health == 100);

            //RegenerateShield Debug
            //Console.WriteLine("Testing RegenerateShield(int hp) should respect <= 100");
            shield = 100;
            RegenerateShield(10);
            //Console.WriteLine("Shield:" + shield);
            Debug.Assert(shield <= 100);

            shield = 80;
            RegenerateShield(10);
            Debug.Assert(shield > 80);
            Debug.Assert(shield <= 100);

            //Console.WriteLine("Testing RegenerateShield(int -10hp) shouldnt register a negative heal");
            shield = 100;
            RegenerateShield(-10);
            Debug.Assert(shield == 100);

            // spill over 
            // Console.WriteLine("TakeDamage(int 15 hits) *300 DAMAGE* Modifing health, shield, lives");
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(15);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 2);
           // Console.WriteLine("TakeDamage(int 12 hits) *240 DAMAGE* Modifing health, shield, lives");
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(12);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 2);
            //Console.WriteLine("TakeDamage(int 3 hits) *60 DAMAGE* Modifing health, shield, lives");
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(3);
            Debug.Assert(shield == 40);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);
            //Console.WriteLine("TakeDamage(int 6 hits) *120 DAMAGE* Modifing health, shield, lives");
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(6);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 80);
            Debug.Assert(lives == 3);
            //Take Damage and Heal
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(6);
            Heal(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 90);
            Debug.Assert(lives == 3);
            //Take Damage and Regenerate Shield
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(3);
            RegenerateShield(10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);
            // Lives Range Checking 
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(100);
            Console.WriteLine(shield + " " + health + " " + lives);
            Debug.Assert(lives == 0);


            // Health Status ....

            //Console.WriteLine("Perfectly Healthy");
            health = 100;
            HealthStatusCheck();
            //Console.WriteLine("Health:" + health + " " + healthStatus[currentHealthStatus]);
            Debug.Assert(currentHealthStatus == 4);

            //Console.WriteLine("Healthy");
            health = 80;
            HealthStatusCheck();
            //Console.WriteLine("Health:" + health + " " + healthStatus[currentHealthStatus]);
            Debug.Assert(currentHealthStatus ==3);

            //Console.WriteLine("Hurt");
            health = 70;
            HealthStatusCheck();
            //Console.WriteLine("Health:" + health + " " + healthStatus[currentHealthStatus]);
            Debug.Assert(currentHealthStatus ==2);

            //Console.WriteLine("Badly Hurt");
            health = 50;
            HealthStatusCheck();
            //Console.WriteLine("Health:" + health + " " + healthStatus[currentHealthStatus]);
            Debug.Assert(currentHealthStatus == 1);

            //Console.WriteLine("Dead");
            health = 0;
            HealthStatusCheck();
            //Console.WriteLine("Health:" + health + " " + healthStatus[currentHealthStatus]);
            Debug.Assert(currentHealthStatus == 5);
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
            if (hp < 0)
            {
                hp = 0;
            }
            shield = shield + hp;
            Console.WriteLine("Your Shield Has Regenerated! " + hp + " hp");
           
            // Range Checking.....
            if (shield > 100)
            {

                shield = 100;

            }

            ErrorCheck();

        }
        static void Heal(int hp)
        {
            if (hp < 0)
            {
                hp = 0;
            }

            health = health + hp;

            // Range Checking.....
            if (health > 100)
            {
                health = 100;
            }

            
            Console.WriteLine("You Have Been Healed! " + hp + " hp");

            


        }

        static void OneUp()
        {
            lives = lives + 1;
            health = 100;
            shield = 100;


            Console.WriteLine("You got a 1UP!");

        }
        static void TakeDamage(int hits)
        {
            shield = shield - (hits * monsterAttack);
            if (hits == 0)
            {
                Console.WriteLine("Goblin Misses Attack!");
            }
            Console.WriteLine("Goblin Attacks! he hits " + hits + " Times and does " + (hits * monsterAttack) + " Damage!");


            // Range Checking and "Spill over effect"
            if (shield < 0)
            {
                health = health + shield;
                shield = 0;

                if (health <= 0)
                {
                    lives = lives - 1;
                    shield = 100;
                    shield = shield + health;
                    health = 100;

                    if (shield <0)
                    {
                        health = health + shield;
                        shield = 0;

                        if (health <= 0)
                        {
                            lives = lives - 1;
                            shield = 100;
                            shield = shield + health;
                            health = 100;

                            if (shield <0)
                            {
                                health = health + shield;
                                shield = 0;

                                if (health <= 0)
                                {
                                    lives = 0;
                                    health = 0;
                                    shield = 0;
                                }
                            }
                        }
                    }
                  

                }
            }
            ErrorCheck();
        }

        static void DoDamage(int hits)
        {
            enemyShield = enemyShield - (hits * weaponDamage[weapon]);

            Console.WriteLine("You Attack! you hit " + hits + " Times and does " + (hits * weaponDamage[weapon]) + " damage! with your " + weaponName[weapon] + "!");

            // Range Checking and "Spill over effect"
            if (enemyShield < 0)
            {

                enemyHealth = enemyHealth + enemyShield;
                enemyShield = 0;

                if (enemyHealth <= 0)
                {
                    enemyLives = enemyLives - 1;
                    enemyShield = 100;
                    shield = shield + health;
                    health = 100;

                    if (enemyLives <= 0)
                    {
                        Console.WriteLine("You Killed Your Enemy!");
                        YouWin();

                        enemyLives = 0;
                        enemyHealth = 0;
                        enemyShield = 0;

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

            /////// Enemy Health Status Check /////
            if (enemyHealth == 1)
            {
                eCurrentHealthStatus = 0;
            }

            if (enemyHealth >= 11)
            {
                eCurrentHealthStatus = 1;
            }

            if (enemyHealth <= 50)
            {
                eCurrentHealthStatus = 1;
            }

            if (enemyHealth >= 51)
            {
                eCurrentHealthStatus = 2;
            }

            if (enemyHealth >= 76)
            {
                eCurrentHealthStatus = 3;
            }

            if (enemyHealth == 100)
            {
                eCurrentHealthStatus = 4;
            }

            if (enemyHealth == 0)
            {
                eCurrentHealthStatus = 5;
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
            Console.WriteLine("    Health: " + enemyHealth + healthStatus[eCurrentHealthStatus] + "                       ");
            Console.WriteLine("   Shield:  " + enemyShield + "                                           ");
            Console.WriteLine("+---------------------------------------------------------+");
            Console.WriteLine("");
            Console.ResetColor();
        }
        static void ShowHUD()
        {
            HealthStatusCheck();
            Console.WriteLine("");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                 |||  |||   ||||||     |     ||    ||    ||   ||   |    ||  ||||");
            Console.WriteLine("                 |||  |||  |||  |||   ||     ||    ||    ||   ||  |||   ||  ||||");
            Console.WriteLine("                 |||  |||  ||    ||   ||     ||    ||    ||       ||||  ||  ||||");
            Console.WriteLine("                 |||  |||  ||    ||   ||     ||    ||    ||   ||  || || ||  ||||");
            Console.WriteLine("                  ||  ||   ||    ||   ||     ||    || || ||   ||  || || ||  ||||");
            Console.WriteLine("                   ||||    ||    ||   ||     ||    ||||||||   ||  || || ||   || ");
            Console.WriteLine("                   ||||    ||    ||   ||     ||    ||||||||   ||  || || ||   || ");
            Console.WriteLine("                    ||     ||    ||   ||     ||    |||  |||   ||  || || ||      ");
            Console.WriteLine("                    ||      |||||||   ||   ||      |||  |||   ||  ||  ||||   || ");
            Console.WriteLine("                    ||       |||||    |||||||       |    |    ||  ||    ||   || ");
            Console.ResetColor();


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

        static void ErrorCheck()
        {
           

            if (lives < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lives are broken.....");
                Console.ResetColor();

            }

            if (lives > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Lives are broken.....");
                Console.ResetColor();
            }

            if (health < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Health is broken....");
                Console.ResetColor();

            }
            if (health > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Health is broken....");
                Console.ResetColor();


            }

            if (shield < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Shield is broken....");
                Console.ResetColor();

            }

            if (shield > 100)
            {
                 Console.ForegroundColor = ConsoleColor.Red;
                 Console.WriteLine("Shield is broken....");
                 Console.ResetColor();

            }
            

        }
    }
}
