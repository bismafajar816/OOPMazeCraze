using PacMan.GameGL;
using PacManGUI;
using PacManGUI.CollisionFramework;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman.GameGL
{
    class VerticalGhost : Ghost
    {
       // GameDirection Direction;
        public VerticalGhost(Image G, GameCell start,int speed, GamePacManPlayer targetplayer) : base(G, start,speed,targetplayer)
        {
            Direction = GameDirection.Up;
        }
       public override GameCell Move()
        {
            GameCell nextCell = null;
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
                if (currentCell == nextCell && Direction == GameDirection.Up)
                {
                    Direction = GameDirection.Down;
                }
                else if (currentCell == nextCell && Direction == GameDirection.Down)
                {
                    Direction = GameDirection.Up;
                }
            }
            return nextCell;
        }
        public override ProgressBar EnemyHealth()
        {
            this.enemyHealth.Top = 650;
            this.enemyHealth.Left = 400;
            this.enemyHealth.Height = 50;
            this.enemyHealth.Width = 90;
            this.enemyHealth.ForeColor = Color.MistyRose;
            return this.enemyHealth;
        }
    }
}
