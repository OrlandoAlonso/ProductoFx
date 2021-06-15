using ProductoFx.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductoFx
{
    public partial class MainFrm : Form
    {
        public ProductoModel productoModel { get; set; }
        public MainFrm()
        {
            InitializeComponent();
            productoModel = new ProductoModel();
        }

        public MainFrm GetMainFrm()
        {
            return this;
        }

        private void mniSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void mniVistaSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void mniCatalogoProducto_Click(object sender, EventArgs e)
        {
            CatalogoProducto catalogoProducto = new CatalogoProducto(this);
            catalogoProducto.MdiParent = this;
            catalogoProducto.Show();
        }

        private void mniVistaProducto_Click(object sender, EventArgs e)
        {
            FrmViewProducto frmViewProducto = new FrmViewProducto(this);
            frmViewProducto.MdiParent = this;
            frmViewProducto.Show();
        }
    }
}
