using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using PacManGUI.CollisionFramework;

namespace PacMan.GameGL
{
    class GamePacManPlayer : GameObject
    {
        public int score = 0;
        private ProgressBar playerHealth = new ProgressBar();
        public bool WinningBox;

        public ProgressBar PlayerHealth { get => playerHealth; set => playerHealth = value; }

        public GamePacManPlayer(Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.CurrentCell = startCell;
            PlayerHealth.Value = 100;
            WinningBox = false;
        }

        public GameCell move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            if (Collision.CheckWinningBox(nextCell))
            {
                WinningBox = true;
            }          
            if (Collision.CheckReward(nextCell))
            {
                score++;
            }
            if (Collision.CheckPower(nextCell))
            {
                if (PlayerHealth.Value <= 80)
                {
                    PlayerHealth.Value += 20;
                }
                else
                {
                    score += 10;
                }
            }
            this.CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());
            }
            return nextCell;
        }
    }
}
