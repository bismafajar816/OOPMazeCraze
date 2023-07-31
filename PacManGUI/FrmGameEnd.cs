using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGUI
{
    public partial class FrmGameEnd : Form
    {
        public FrmGameEnd(Image BackgroundScreen)
        {
            InitializeComponent();
            this.BackgroundImage = BackgroundScreen;
        }
        public FrmGameEnd()
        {
            InitializeComponent();
        }

        private void FrmGameEnd_Load(object sender, EventArgs e)
        {

        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void restart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
