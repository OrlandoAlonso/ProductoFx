using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductoFx.UsingControl
{
    public partial class ControlProducto : UserControl
    {
        PictureBox pictureBox;
        public ControlProducto()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            this.Controls.Add(pictureBox);
        }

        private string _description;

        [Category("Custom Props")]
        [Editor(typeof(System.Windows.Forms.Design.WindowsFormsComponentEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public String ImageFile { set { Image img = Image.FromFile(value); pictureBox.Image = img; } }

        [Category("Custom Props")]
        public string Description { get { return _description; } set { _description = value; txtDescripcion.Text = value; } }
    }
}
