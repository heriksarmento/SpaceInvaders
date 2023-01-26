using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class Form1 : Form
    {
        Game game = new Game();
        Timer timer,timer2;
        bool canShoot = true;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += GameTick;

            timer2 = new Timer();
            timer2.Interval = 100;
            timer2.Start();
            timer2.Tick += GameShots;

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;




            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (game.enemies[i, j] != null) { 
                        if (game.enemies[i, j].lifes != 0)
                        {
                            g.FillRectangles(Brushes.White, game.enemies[i, j].points);
                        } else
                        {
                            game.enemies[i, j] = null;
                        }
                    }
                }
            }

            g.FillRectangles(Brushes.LimeGreen,game.player.points);


            Font arial = new Font("Arial", 20);

            g.DrawString("Score: " + game.score.ToString(), arial,Brushes.White,0,0);
            g.DrawString("Lifes: " + game.player.lifes.ToString(), arial, Brushes.White, 0, 570);
            if ((!timer.Enabled)&&(game.player.lifes==0))
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                RectangleF r = new RectangleF(0, 0, Width, Height);
                g.DrawString("GAME OVER", arial, Brushes.White, r, sf);
            }


            foreach (Point p in game.playerShots)
            {
                Rectangle r = new Rectangle(p.X - 1, p.Y - 6, 3, 6);
                g.FillRectangle(Brushes.LimeGreen, r);
            }

            foreach (Point p in game.enemiesShots)
            {
                Rectangle r = new Rectangle(p.X - 1, p.Y - 6, 3, 6);
                g.FillRectangle(Brushes.White, r);
            }
        }

            private void GameShots(object sender, EventArgs e)
            {
            game.Shoot();
            Invalidate();
            }



            private void GameTick(object sender, EventArgs e)
            {
            if (PlayerMotion == PlayerMotionState.MovingLeft)
            {
                game.player.posX -= 5;
                
                if (game.player.posX  - 10 <= 0)
                {
                    game.player.posX = 10;
                }
            }
            else if (PlayerMotion == PlayerMotionState.MovingRight)
            {
                game.player.posX += 5;

                if (game.player.posX + 10 >= 800)
                {
                    game.player.posX = 790;
                }
            }




            game.Move();            
            game.player.reDraw();
            List<Point> lp = game.playerShots.ConvertAll(new Converter<Point, Point>(IncreaseShot));

            for (int i = 0; i < lp.Count; i++)
            {
                if (lp[i].Y <= 0)
                {
                    lp.Remove(lp[i]);
                }
            }
            game.playerShots = lp;

            List<Point> le = game.enemiesShots.ConvertAll(new Converter<Point, Point>(DecreaseShot));

            for (int i = 0; i < le.Count; i++)
            {
                if (le[i].Y >= 600)
                {
                    le.Remove(le[i]);
                }
            }
            game.enemiesShots = le;

            game.checkColision();
            if (game.player.lifes == 0)
            {
                timer.Stop();
                timer2.Stop();
            }

            Invalidate();
        }

        public static Point IncreaseShot(Point pf)
        {
            return new Point(pf.X, pf.Y - 5);
        }

        public static Point DecreaseShot(Point pf)
        {
            return new Point(pf.X, pf.Y + 5);
        }

        private enum PlayerMotionState { MovingLeft, MovingRight, NotMoving };
        PlayerMotionState PlayerMotion = PlayerMotionState.NotMoving;


        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    PlayerMotion = PlayerMotionState.MovingLeft;
                    break;
                case Keys.Right:
                    PlayerMotion = PlayerMotionState.MovingRight;
                    break;
                case Keys.Space:
                    if (canShoot)
                    {
                        game.playerShots.Add(new Point(game.player.posX, game.player.posY - 16));
                        canShoot = false;
                    }  
                    break;
                case Keys.R:
                    if ((!timer.Enabled) && (game.player.lifes == 0))
                    {
                        game = new Game();
                        timer2.Start();
                        Invalidate();
                    }
                    break;

            }

            base.OnKeyDown(e);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Left && PlayerMotion == PlayerMotionState.MovingLeft) ||
               (e.KeyData == Keys.Right && PlayerMotion == PlayerMotionState.MovingRight))
            {
                PlayerMotion = PlayerMotionState.NotMoving;
            }
            if(e.KeyData == Keys.Space)
            {
                canShoot = true;
            }
            base.OnKeyUp(e);
        }

    }
}
