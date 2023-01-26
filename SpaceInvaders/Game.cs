using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SpaceInvaders
{
    internal class Game
    {
        public Enemy[,] enemies;
        public Player player = new Player();
        public List<Point> playerShots = new List<Point>();
        public List<Point> enemiesShots = new List<Point>();
        public int score;
        private int move=2;
        private int moveY = 0;

        public Game() {
            enemies = new Enemy[5,10];
            score = 0;
            int t = 3;
            for (int i = 0; i < 5; i++)
            {
                if(i == 1)
                {
                    t = 2;
                }else if(i == 3)
                {
                    t = 1;
                }
                enemies[i, 0] = new Enemy(130, (i + 1) * 40 + 20, t);
                enemies[i, 1] = new Enemy(190, (i + 1) * 40 + 20, t);
                enemies[i, 2] = new Enemy(250, (i + 1) * 40 + 20, t);
                enemies[i, 3] = new Enemy(310, (i + 1) * 40 + 20, t);
                enemies[i, 4] = new Enemy(370, (i + 1) * 40 + 20, t);
                enemies[i, 5] = new Enemy(430, (i + 1) * 40 + 20, t);
                enemies[i, 6] = new Enemy(490, (i + 1) * 40 + 20, t);
                enemies[i, 7] = new Enemy(550, (i + 1) * 40 + 20, t);
                enemies[i, 8] = new Enemy(610, (i + 1) * 40 + 20, t);
                enemies[i, 9] = new Enemy(670, (i + 1) * 40 + 20, t);
            }
        }

        public void checkColision()
        {
            foreach(Enemy en in enemies)
            {
                if (en != null)
                {
                    foreach (Rectangle re in en.points)
                    {
                        for (int i = 0; i < playerShots.Count; i++)
                        {
                            Rectangle r = new Rectangle(playerShots[i].X - 1, playerShots[i].Y - 6, 3, 6);
                            if (re.IntersectsWith(r))
                            {
                                playerShots.Remove(playerShots[i]);
                                en.lifes -= 1;
                                if (en.lifes == 0)
                                {
                                    switch (en.type) {
                                        case 1:
                                            score += 5;
                                            break;

                                        case 2:
                                            score += 10;
                                            break;

                                        case 3:
                                            score += 15;
                                            break;
                                    }                                
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < player.points.Length; i++)
            {
                for (int j = 0; j < enemiesShots.Count; j++)
                {
                    Rectangle r = new Rectangle(enemiesShots[j].X - 1, enemiesShots[j].Y - 6, 3, 6);
                    if (player.points[i].IntersectsWith(r))
                    {
                        enemiesShots.Remove(enemiesShots[j]);
                        player.lifes -= 1;
                    }
                }
            }
        }

        public void Move()
        {
            moveY = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (enemies[i, j] != null)
                    {
                        enemies[i, j].posX += move;
                        enemies[i, j].reDraw();

                        if ((enemies[i, j].posX <= 10)||(enemies[i, j].posX >= 790))
                        {
                            moveY = 2;
                        }

                    }  
                }
            }
            if (moveY != 0)
            {
                move *= -1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (enemies[i, j] != null)
                        {
                            enemies[i, j].posY += moveY;
                            enemies[i, j].reDraw();
                        }
                    }
                }
            }
        }

        public void Shoot()
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int p = rnd.Next(1, 10);
                if (p == 1)
                {
                    if (enemies[4, i] == null)
                    {
                        if (enemies[3, i] == null)
                        {
                            if (enemies[2, i] == null)
                            {
                                if (enemies[1, i] == null)
                                {
                                    if (enemies[0, i] != null)
                                    {
                                        enemiesShots.Add(new Point(enemies[0, i].posX, enemies[0, i].posY));
                                    }
                                }
                                else
                                {
                                    enemiesShots.Add(new Point(enemies[1, i].posX, enemies[1, i].posY));
                                }
                            }
                            else
                            {
                                enemiesShots.Add(new Point(enemies[2, i].posX, enemies[2, i].posY));
                            }
                        }
                        else
                        {
                            enemiesShots.Add(new Point(enemies[3, i].posX, enemies[3, i].posY));
                        }
                    }
                    else
                    {
                        enemiesShots.Add(new Point(enemies[4, i].posX, enemies[4, i].posY));
                    }
                }
            }
        }


    }
}
