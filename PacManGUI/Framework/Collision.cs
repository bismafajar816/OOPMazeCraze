
using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGUI.CollisionFramework
{
    class Collision
    {
        public static bool CheckCollision(GameObject obj1, GameObject obj2)
        {
            if(obj1.CurrentCell.X == obj2.CurrentCell.X && obj1.CurrentCell.Y == obj2.CurrentCell.Y)
            {
                return true;
            }
            return false;
        }
        public static bool CheckReward(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                return true;
            }
            return false;
        }
        public static bool CheckWinningBox(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.WinningBox)
            {
                return true;
            }
            return false;
        }
        public static bool CheckBullet(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.BULLET)
            {
                return true;
            }
            return false;
        }
        public static bool CheckPower(GameCell cell)
        {
            if (cell.CurrentGameObject.GameObjectType == GameObjectType.POWER)
            {
                return true;
            }
            return false;
        }
        public static bool CheckBlank(GameCell cell)
        {
            if(cell.CurrentGameObject.GameObjectType==GameObjectType.NONE)
            {
                return true;
            }   
            return false;
        }
       
    }
}
