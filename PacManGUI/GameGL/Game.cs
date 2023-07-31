using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PacMan.GameGL;
namespace PacMan.GameGL
{
   public class Game
    {
        private List<Bullet> fires = new List<Bullet>();
        private List<Bullet> enemyfires = new List<Bullet>();
        public List<Bullet> Fires { get => fires; set => fires = value; }
        public List<Bullet> Enemyfires { get => enemyfires; set => enemyfires = value; }
        public void AddEnemyBulletToList(Bullet bullet)
        {
            enemyfires.Add(bullet);
        }
        public void AddBulletsToList(Bullet bullet)
        {
            Fires.Add(bullet);
        }
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE,null);
            return blankGameObject;
        }
        public static GameObject getRewardGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.REWARD, PacManGUI.Properties.Resources.Food);
            return blankGameObject;
        }
        public static GameObject getPowerGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.POWER, PacManGUI.Properties.Resources.pallet_removebg_preview);
            return blankGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = null;
            if (displayCharacter == '|' || displayCharacter == '%')
            { 
                img = PacManGUI.Properties.Resources.vertical;
            }
            if (displayCharacter == '*')
            {
                img = PacManGUI.Properties.Resources.Power;
            }
            if (displayCharacter == '#')
            {
                img = PacManGUI.Properties.Resources.horizontal;
            }

            if (displayCharacter == '.' || displayCharacter == ':')
            {
                img = PacManGUI.Properties.Resources.Food;
            }
            if (displayCharacter == 'P' || displayCharacter == 'p') 
            {
                img = PacManGUI.Properties.Resources.candy__1_;
            }
            if (displayCharacter == 'D' || displayCharacter == 'D')
            {
                img = PacManGUI.Properties.Resources.Fighter;
            }
            if (displayCharacter == 'M' || displayCharacter == 'M')
            {
                img = PacManGUI.Properties.Resources.Rhino;
            }
            if (displayCharacter == 'S' || displayCharacter == 'S')
            {
                img = PacManGUI.Properties.Resources.Spiko_removebg_preview;
            }
            if (displayCharacter == 'O' || displayCharacter == 'O')
            {
                img = PacManGUI.Properties.Resources.obstacle_removebg_preview__1_;
            }
            return img;
        }
    }
}
