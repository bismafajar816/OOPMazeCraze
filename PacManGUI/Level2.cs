using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using EZInput;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacManGUI.CollisionFramework;
using Pacman.GameGL;

namespace PacManGUI
{
    public partial class Level2 : Form
    {
        GamePacManPlayer pacman;
        private static List<Ghost> ghost = new List<Ghost>();
        HorizontalGhost X;
        VerticalGhost Fighter;
        RandomGhost RGhost;
        Obstacle stone;
        SmartGhost smarty;
        Game Game = new Game();
        Label lable = new Label();

        internal static List<Ghost> Ghost { get => ghost; set => ghost = value; }

        // ProgressBar health = new ProgressBar();
        public Level2()
        {
            InitializeComponent();
        }
        public void MoveFire()
        {
            foreach (Bullet x in Game.Fires)
            {
                GameCell gameCell = x.MoveBullet(GameDirection.Left);
            }
        }
        private void Level2_Load(object sender, EventArgs e)
        {
            
            int speed = 1;
            GameGrid grid;
               // MessageBox.Show("Level 2");
                speed = speed * speed;
                grid = new GameGrid("mazeLevel2.txt", 18, 65);
            CreateScoreLable(pacman);
            Image playerImage = Game.getGameObjectImage('P');
            Image XImage = Game.getGameObjectImage('D');
            Image sImage = Game.getGameObjectImage('S');

            Image VImage = Game.getGameObjectImage('M');
            GameCell startCell = grid.getCell(3, 33);
            GameCell startSmart = grid.getCell(4, 4);

            GameCell startVertical = grid.getCell(12, 22);
            GameCell startHorizontal = grid.getCell(13, 22);
            pacman = new GamePacManPlayer(playerImage, startCell);
            


            X = new HorizontalGhost(XImage, startHorizontal, speed, pacman);
            Fighter = new VerticalGhost(VImage, startVertical, speed, pacman);
            smarty = new SmartGhost(sImage, startSmart, speed, pacman);
            Ghost.Add(X);
            Ghost.Add(Fighter);
          //   ghost.Add(smarty);

            printMaze(grid);
            CreateScoreLable(pacman);
            CreatePlayerHealthLable(pacman);

        }
        private void CreatePlayerHealthLable(GamePacManPlayer pacman)
        {
            pacman.PlayerHealth.Top = 500;
            pacman.PlayerHealth.Left = 100;
            pacman.PlayerHealth.Height = 50;
            pacman.PlayerHealth.Width = 100;
            pacman.PlayerHealth.ForeColor = Color.YellowGreen;
            this.Controls.Add(pacman.PlayerHealth);
        }
        private void CreateScoreLable(GamePacManPlayer pacman)
        {

            lable.Top = 500;
            lable.Left = 100;
            lable.ForeColor = Color.White;
            this.Controls.Add(lable);
        }


        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {

                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                    //        printCell(cell);
                }

            }
        }
        public void GenerateObstacle()
        {
            Random rand = new Random();
            int x = rand.Next(1, 60);
            if (pacman != null)
            {
                GameGrid grid = pacman.CurrentCell.Grid;
                Image Stone = Game.getGameObjectImage('O');
                GameCell startStone = grid.getCell(2, x);
                stone = new Obstacle(Stone, startStone, 1, pacman);
                ghost.Add(stone);
            }
        }
        private void gameLoop_Tick(object sender, EventArgs e)
        {
            GameCell startCell = null;
            GenerateObstacle();

            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                startCell = pacman.move(GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                startCell = pacman.move(GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                startCell = pacman.move(GameDirection.Up);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                startCell = pacman.move(GameDirection.Down);

            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                Bullet playerBullet;
                playerBullet = new Bullet(PacManGUI.Properties.Resources.bullet_removebg_preview, new GameCell(pacman.CurrentCell.X, pacman.CurrentCell.Y, pacman.CurrentCell.Grid), pacman);
                PictureBox bullet = playerBullet.GenerateBullet();
                Game.AddBulletsToList(playerBullet);
                this.Controls.Add(bullet);
            }
            if(pacman.WinningBox)
            {
                this.Hide();
                gameLoop.Enabled = false;
                MessageBox.Show("You WIN");
            }
            MoveFire();
            if (Ghost.Count > 0)
            {
                for (int i = 0; i < Ghost.Count; i++)
                {
                    GameCell nextCell = Ghost[i].Move();
                    if (Collision.CheckCollision(pacman, Ghost[i]))
                    {

                        pacman.PlayerHealth.Step -= 10;
                        pacman.PlayerHealth.PerformStep();
                        if (pacman.PlayerHealth.Value == 0)
                        {
                            gameLoop.Enabled = false;
                            this.Hide();
                            ShowGameEnd(PacManGUI.Properties.Resources.pacman_gameover);

                        }
                    }

                }
            }
            lable.Text = pacman.score.ToString();


        }
        private void ShowGameEnd(Image img)
        {
            gameLoop.Enabled = false;
            FrmGameEnd GameOver = new FrmGameEnd(img);
            DialogResult result = GameOver.ShowDialog();
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            if (result == DialogResult.No)
            {
                Restart();
            }
        }
        private void Restart()
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

    }
}
