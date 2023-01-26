using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class Player
    {
        public int posX;
        public int posY;
        public Rectangle[] points;
        public int lifes;


    public Player() {
            posX = 400;
            posY = 580;
            lifes = 3;
            reDraw();
        }

        public void reDraw()
        {
            points = new Rectangle[] {
            new Rectangle(posX-10,posY-9,21,10),
            new Rectangle(posX-8,posY-11,17,12),
            new Rectangle(posX-1,posY-16,3,5),
            };
        }



    }
}
