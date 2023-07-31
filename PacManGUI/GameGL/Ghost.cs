  using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PacMan.GameGL
{
   abstract class Ghost:GameObject
    {
        protected GameDirection Direction;
        public GameObjectType PreviousObject = GameObjectType.NONE;
        protected int Speed;
        public  GamePacManPlayer player;
        public ProgressBar enemyHealth = new ProgressBar();
        public Ghost(Image enemy, GameCell start,int Speed, GamePacManPlayer player) : base(GameObjectType.ENEMY, enemy)
        {
            this.CurrentCell = start;
            this.Speed = Speed;
            this.player = player;
            enemyHealth.Value = 100;

        }
         public abstract GameCell Move();
        public abstract ProgressBar EnemyHealth();
    }
}
