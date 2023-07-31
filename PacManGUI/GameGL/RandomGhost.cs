using PacManGUI;
using PacManGUI.CollisionFramework;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PacMan.GameGL
{
    class RandomGhost : Ghost
    {
     
        Random rand = new Random();
        public RandomGhost(Image G, GameCell start,int speed, GamePacManPlayer targetplayer) : base(G, start,speed, targetplayer)
        {
            Direction = GameDirection.Up;
        }
        public GameDirection ghostDirection()
        {
          
            GameDirection direction=GameDirection.Left;
            int x=rand.Next(0, 4);
            if(x==1)
            {
                direction = GameDirection.Down;

            }
            if (x == 2)
            {
                direction = GameDirection.Up;

            }
            if (x == 3)
            {
                direction = GameDirection.Right;

            }
            return direction;
        }
        public override GameCell Move()
        {
            GameCell nextCell=null;
            for (int i = 0; i <= Speed; i++)
            {
                if (PreviousObject == GameObjectType.REWARD)
                {
                    CurrentCell.setGameObject(Game.getRewardGameObject());
                }
                if (PreviousObject == GameObjectType.POWER)
                {
                    CurrentCell.setGameObject(Game.getPowerGameObject());
                }
                if (PreviousObject == GameObjectType.NONE)
                {
                    CurrentCell.setGameObject(Game.getBlankGameObject());
                }
                GameCell currentCell = this.CurrentCell;
                Direction = ghostDirection();
                nextCell = currentCell.nextCell(Direction);
                if (Collision.CheckBullet(nextCell))
                {
                    Form1.Ghost.Remove(this);
                }
                if (Collision.CheckReward(nextCell))
                {
                    PreviousObject = GameObjectType.REWARD;
                }
                else if (Collision.CheckPower(nextCell))
                {
                    PreviousObject = GameObjectType.POWER;
                }
                else if (Collision.CheckBlank(nextCell))
                {
                    PreviousObject = GameObjectType.NONE;
                }
                this.CurrentCell = nextCell;
               
            }
            return nextCell;
        }
        public override ProgressBar EnemyHealth()
        {
            this.enemyHealth.Top = 800;
            this.enemyHealth.Left = 400;
            this.enemyHealth.Height = 50;
            this.enemyHealth.Width = 90;
            this.enemyHealth.ForeColor = Color.YellowGreen;
            return this.enemyHealth;
        }
    }
}
