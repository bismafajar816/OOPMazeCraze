using PacMan.GameGL;
using PacManGUI.CollisionFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan.GameGL
{
    class Obstacle:Ghost
    {
       public Obstacle(Image G, GameCell start, int speed,GamePacManPlayer player) : base(G, start, speed,player)
        {
            Direction = GameDirection.Down;
        }
        public override GameCell Move()
        {
            GameCell nextCell = null;
            for (int i = 0; i <= Speed; i++)
            {
                if(Collision.CheckCollision(this,player))
                {
                    if (player.PlayerHealth.Value>=10)
                    {

                    player.PlayerHealth.Value -= 10;
                    }
                }
                if (PreviousObject == GameObjectType.REWARD)
                {
                    CurrentCell.setGameObject(Game.getRewardGameObject());
                }
                if (PreviousObject == GameObjectType.NONE)
                {
                    CurrentCell.setGameObject(Game.getBlankGameObject());
                }
                GameCell currentCell = this.CurrentCell;
                nextCell = currentCell.nextCell(Direction);
                if (Collision.CheckReward(nextCell))
                {
                    PreviousObject = GameObjectType.REWARD;
                }
                else if (Collision.CheckBlank(nextCell))
                {
                    PreviousObject = GameObjectType.NONE;
                } 
                this.CurrentCell = nextCell;
                if (currentCell == nextCell)
                {
                    nextCell.setGameObject(Game.getBlankGameObject());
                }
            }
            return nextCell;
        }
        public override ProgressBar EnemyHealth()
        {
            throw new NotImplementedException();
        }
    }
}
