using PacManGUI;
using PacManGUI.CollisionFramework;
using System.Drawing;
using System.Windows.Forms;

namespace PacMan.GameGL
{
    class HorizontalGhost : Ghost
    {
        public HorizontalGhost(Image G, GameCell start, int speed, GamePacManPlayer targetplayer) : base(G, start, speed, targetplayer)
        {
            Direction = GameDirection.Right;
        }
        public override GameCell Move()
        {
            GameCell nextCell = null;
            for (int i = 0; i <= Speed; i++)
            {
                if (PreviousObject == GameObjectType.POWER)
                {
                    CurrentCell.setGameObject(Game.getPowerGameObject());
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

                if (Collision.CheckBullet(nextCell))
                {
                    Form1.Ghost.Remove(this);
                }
                if (Collision.CheckPower(nextCell))
                {
                    PreviousObject = GameObjectType.POWER;
                }
                if (Collision.CheckReward(nextCell))
                {
                    PreviousObject = GameObjectType.REWARD;
                }
                else if (Collision.CheckBlank(nextCell))
                {
                    PreviousObject = GameObjectType.NONE;
                }
                this.CurrentCell = nextCell;
                if (currentCell == nextCell && Direction == GameDirection.Right)
                {
                    Direction = GameDirection.Left;
                }
                else if (currentCell == nextCell && Direction == GameDirection.Left)
                {
                    Direction = GameDirection.Right;
                }
            }
            return nextCell;
        }
        public  ProgressBar CreateEnemyHealthLable()
        {
            this.enemyHealth.Top = 400;
            this.enemyHealth.Left = 400;
            this.enemyHealth.Height = 50;
            this.enemyHealth.Width = 100;
            this.enemyHealth.ForeColor = Color.DarkKhaki;
            return this.enemyHealth;
        }
        public override ProgressBar EnemyHealth()
        {
            this.enemyHealth.Top = 400;
            this.enemyHealth.Left = 400;
            this.enemyHealth.Height = 50;
            this.enemyHealth.Width = 100;
            this.enemyHealth.ForeColor = Color.DarkKhaki;
            return this.enemyHealth;
        }
    }
}
