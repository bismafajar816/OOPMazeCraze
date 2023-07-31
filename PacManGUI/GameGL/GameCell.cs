using System.Windows.Forms;
using System.Drawing;
namespace PacMan.GameGL
{

    public class GameCell
    {
        int row;
        int col;
        GameObject currentGameObject;
        GameGrid grid;
        PictureBox pictureBox;
        const int width = 18;  
        const int height = 25;
        public GameCell()
        {

        }
        public GameCell(int row, int col,GameGrid grid) {
            this.Row =row;
            this.Col = col;
            PictureBox1 = new PictureBox();
            PictureBox1.Left = col * Width;
            PictureBox1.Top = row * Height;
            PictureBox1.Size = new Size(Width,Height); 
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.BackColor = Color.Transparent;
            PictureBox1.BorderStyle = BorderStyle.None;
            this.Grid = grid;
        }
        public void setGameObject(GameObject gameObject) {
            CurrentGameObject1 = gameObject;
            PictureBox1.Image = gameObject.Image;

        }
        public GameCell nextCell(GameDirection direction)
        {
          
            if (direction == GameDirection.Left) {
                if (this.Col > 0) {
                    GameCell ncell = Grid.getCell(Row, Col-1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL) {
                        return ncell;
                    }
                }    
            }

            if (direction == GameDirection.Right)
            {
                if (this.Col < Grid.Cols-1)
                {
                    GameCell ncell = Grid.getCell(this.Row, this.Col+1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }

            if (direction == GameDirection.Up)
            {
                if (this.Row > 0)
                {
                    GameCell ncell = Grid.getCell(this.Row-1, this.Col);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }

            if (direction == GameDirection.Down)
            {
                if (this.Row < Grid.Rows - 1)
                {
                    GameCell ncell = Grid.getCell(this.Row+1, this.Col);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }
            return this; // if can not return next cell return its own reference
        }
        public int X { get => Row; set => Row = value; }
        public int Y { get => Col; set => Col = value; }
        public GameObject CurrentGameObject { get => CurrentGameObject1;}
        public PictureBox PictureBox { get => PictureBox1; set => PictureBox1 = value; }
        public int Row { get => row; set => row = value; }
        public int Col { get => col; set => col = value; }
        public GameObject CurrentGameObject1 { get => currentGameObject; set => currentGameObject = value; }
        public GameGrid Grid { get => grid; set => grid = value; }
        public PictureBox PictureBox1 { get => pictureBox; set => pictureBox = value; }

        public static int Width => width;

        public static int Height => height;
    }
}
