using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PacMan.GameGL;
using EZInput;
using PacManGUI.CollisionFramework;
using Pacman.GameGL;

namespace PacManGUI
{
    public partial class Form1 : Form
    {
        GamePacManPlayer pacman;
        private static List<Ghost> ghost = new List<Ghost>();
        VerticalGhost Figher;
        RandomGhost purple;
        SmartGhost smarty;
        Game Game = new Game();
        HorizontalGhost X;
        Label lable = new Label();

        internal static List<Ghost> Ghost { get => ghost; set => ghost = value; }

        public Form1()
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
        public void MoveEnemyFire()
        {

            foreach (Bullet x in Game.Enemyfires)
            {
                GameCell gameCell = x.MoveBullet(GameDirection.Left);
                if (Collision.CheckCollision(x, pacman))
                {
                    if (pacman.PlayerHealth.Value >= 10)
                    {
                        pacman.PlayerHealth.Value -= 10;
                    }
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int speed = 1;
            GameGrid grid;
            grid = new GameGrid("maze.txt", 18, 65);
            CreateScoreLable(pacman);
            Image playerImage = Game.getGameObjectImage('P');
            Image XImage = Game.getGameObjectImage('D');
            Image SImage = Game.getGameObjectImage('S');

            Image VImage = Game.getGameObjectImage('M');
            GameCell startCell = grid.getCell(3, 33);
            GameCell startSmart = grid.getCell(4, 4);

            GameCell startVertical = grid.getCell(12, 60);
            GameCell startHorizontal = grid.getCell(15, 11);
            pacman = new GamePacManPlayer(playerImage, startCell);



            X = new HorizontalGhost(XImage, startHorizontal, speed, pacman);
            Figher = new VerticalGhost(VImage, startVertical, speed, pacman);
            smarty = new SmartGhost(SImage, startSmart, speed, pacman);
            Ghost.Add(X);
            Ghost.Add(Figher);
            ghost.Add(smarty);

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


        private void gameLoop_Tick(object sender, EventArgs e)
        {
            GameCell startCell = null;
            int t = 0;
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
            MoveFire();
        //    GenerateEnemyBullets();
            if (t / 10 == 0)
            {
       //           MoveEnemyFire();
            }


            for (int i = 0; i < Ghost.Count; i++)
            {

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
                GameCell nextCell = Ghost[i].Move();
            }

            if (pacman.WinningBox)
            {
                gameLoop.Enabled = false;
                this.Hide();

                Level2 level = new Level2();
                level.Show();
            }
            lable.Text = pacman.score.ToString();
            t++;

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
        private void GenerateEnemyBullets()
        {
            Bullet dBullet;
            dBullet = new Bullet(PacManGUI.Properties.Resources.bullet_removebg_preview, new GameCell(Figher.CurrentCell.X, Figher.CurrentCell.Y, Figher.CurrentCell.Grid), Figher);
            PictureBox Ebullet = dBullet.GenerateBullet();
            Game.AddEnemyBulletToList(dBullet);
            this.Controls.Add(Ebullet);
        }
        private void Restart()
        {
            this.Show();
            this.Controls.Clear();
            Label lable = new Label();
            this.Controls.Add(lable);
            int speed = 1;
            GameGrid grid = new GameGrid("maze.txt", 21, 70);
            Image playerImage = Game.getGameObjectImage('P');
            Image darkoImage = Game.getGameObjectImage('D');
            Image spikoImage = Game.getGameObjectImage('S');

            Image mistyImage = Game.getGameObjectImage('M');
            GameCell startCell = grid.getCell(3, 33);
            GameCell startSmart = grid.getCell(4, 4);
            GameCell startVertical = grid.getCell(12, 60);
            GameCell startHorizontal = grid.getCell(11, 20);
            pacman = new GamePacManPlayer(playerImage, startCell);
            pacman.score = 0;
            X = new HorizontalGhost(darkoImage, startHorizontal, speed, pacman);
            Figher = new VerticalGhost(mistyImage, startVertical, speed, pacman);
            smarty = new SmartGhost(spikoImage, startSmart, speed, pacman);
            Ghost.Add(X);
            Ghost.Add(smarty);
            Ghost.Add(Figher);
            printMaze(grid);
            gameLoop.Enabled = true;
        }

    }
}
