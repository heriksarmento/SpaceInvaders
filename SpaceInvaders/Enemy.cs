using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Enemy
    {
        public int posX;
        public int posY;
        public int lifes;
        public Rectangle[] points;
        public int type;
        private bool sprite;

        public Enemy() { 
        
        
        }

        public Enemy(int x,int y,int t)
        {
            posX = x;
            posY = y;
            type = t;
            lifes = 3;
            reDraw();
        }

        public void reDraw()
        {
            switch(type)
            {
                case 1:
                        points = new Rectangle[] {
                        new Rectangle(posX - 13,posY-4,2,7),
                        new Rectangle(posX - 11,posY-7,3,5),
                        new Rectangle(posX - 8,posY-9,2,12),
                        new Rectangle(posX - 8,posY-14,2,3),
                        new Rectangle(posX - 6,posY-4,3,5),
                        new Rectangle(posX - 6,posY-12,3,5),
                        new Rectangle(posX - 6,posY+3,5,2),
                        new Rectangle(posX - 3,posY-9,3,10),


                        new Rectangle(posX,posY-9,1,10),

                        new Rectangle(posX + 1,posY-9,3,10),
                        new Rectangle(posX + 2,posY+3,5,2),
                        new Rectangle(posX + 4,posY-12,3,5),
                        new Rectangle(posX + 4,posY-4,3,5),
                        new Rectangle(posX + 7,posY-14,2,3),
                        new Rectangle(posX + 7,posY-9,2,12),
                        new Rectangle(posX + 9,posY-7,3,5),
                        new Rectangle(posX + 12,posY-4,2,7)
                        };
                    break;

                case 2:
                    points = new Rectangle[] {
                    new Rectangle(posX - 7, posY + 4, 2, 2),
                    new Rectangle(posX - 10, posY + 1, 3, 3),
                    new Rectangle(posX - 10, posY - 6, 3, 5),
                    new Rectangle(posX - 7, posY - 9, 2, 10),
                    new Rectangle(posX - 5, posY - 4, 3, 3),
                    new Rectangle(posX - 5, posY - 11, 3, 5),
                    new Rectangle(posX - 2, posY - 14, 2, 15),

                    new Rectangle(posX, posY - 14, 1, 15),

                    new Rectangle(posX + 1, posY - 14, 2, 15),
                    new Rectangle(posX + 3, posY - 11, 3, 5),
                    new Rectangle(posX + 3, posY - 4, 3, 3),
                    new Rectangle(posX + 6, posY - 9, 2, 10),
                    new Rectangle(posX + 8, posY - 6, 3, 5),
                    new Rectangle(posX + 8, posY + 1, 3, 3),
                    new Rectangle(posX + 6, posY + 4, 2, 2),
                    };
                    break;

                case 3:
                    points = new Rectangle[] {
                    new Rectangle(posX - 9, posY + 1, 5, 2),
                    new Rectangle(posX - 11, posY - 1, 5, 2),
                    new Rectangle(posX - 9, posY - 4, 7, 3),
                    new Rectangle(posX - 14, posY - 6, 12, 2),
                    new Rectangle(posX - 14, posY - 11, 7, 5),
                    new Rectangle(posX - 7, posY - 11, 3, 2),
                    new Rectangle(posX - 11, posY - 14, 7, 3),
                    new Rectangle(posX - 4, posY - 16, 2, 7),
                    new Rectangle(posX - 2, posY - 16, 2, 12),

                    new Rectangle(posX, posY - 16, 1, 12),

                    new Rectangle(posX + 5, posY + 1, 5, 2),
                    new Rectangle(posX + 7, posY - 1, 5, 2),
                    new Rectangle(posX + 3, posY - 4, 7, 3),
                    new Rectangle(posX + 3, posY - 6, 12, 2),
                    new Rectangle(posX + 8, posY - 11, 7, 5),
                    new Rectangle(posX + 5, posY - 11, 3, 2),
                    new Rectangle(posX + 5, posY - 14, 7, 3),
                    new Rectangle(posX + 3, posY - 16, 2, 7),
                    new Rectangle(posX + 1, posY - 16, 2, 12),

                    new Rectangle(posX - 2, posY - 1, 5, 2)
                    };
                    break;
            }
        }




    }
}
