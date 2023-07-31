using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using PacManGUI.CollisionFramework;
namespace PacMan.GameGL
{
   public class Bullet: GameObject,IBullet
    {
        public GameObjectType PreviousObject = GameObjectType.NONE;
        GameObject player;
     
        public Bullet(Image image, GameCell startCell, GameObject player) : base(GameObjectType.BULLET, image)
        {
            this.CurrentCell = startCell;
            this.player = player;
        }
        public PictureBox GenerateBullet()
        {
            PictureBox pbBullet = new PictureBox();
            Image fire = PacManGUI.Properties.Resources.bullets_removebg_preview__1_;
            pbBullet.Image = fire;
            pbBullet.Width = fire.Width;
            pbBullet.Height = fire.Height;
            pbBullet.BackColor = Color.Transparent;
            System.Drawing.Point fireLocation;
            fireLocation = new System.Drawing.Point();
            fireLocation.X = player.CurrentCell.X + 2;
            fireLocation.Y = player.CurrentCell.Y;
            pbBullet.Location = fireLocation;
            return pbBullet;
        }
        public GameCell MoveBullet(GameDirection direction)
        {
            GameDirection Direction = direction;
            GameCell nextCell = null;
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
          
            return nextCell;       
        }


    }
}
