using ProductoFx.model;
using ProductoFx.pojo;
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
    public partial class CatalogoProducto : Form
    {
        private MainFrm mainFrm;
        public CatalogoProducto(MainFrm frameMain)
        {
            InitializeComponent();
            mainFrm = frameMain;
            if (mainFrm.productoModel.GetAll() == null)
            {
                MessageBox.Show("Aun no hay productos que mostrar!");
            }
            else
            {
                loadDataGridView();
            }
        }

        private void loadDataGridView()
        {
            dgvData.DataSource = mainFrm.productoModel.GetAll();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ProductoFrm productoFrm = new ProductoFrm(false, mainFrm, 0);
            productoFrm.Show();
            this.Dispose();
        }

        private void btnToUpdate_Click(object sender, EventArgs e)
        {
            if(dgvData.RowCount > 0)
            {
                int indice = dgvData.CurrentCell.RowIndex;
                int index = 0;
                foreach(DataGridViewRow dataGridView in dgvData.Rows)
                {
                    if(dataGridView.Index == indice)
                    {
                        index = (int) dataGridView.Cells[0].Value;
                    }
                }
                if (indice < 0)
                {
                    MessageBox.Show("Por favor seleccione una fila!");
                    return;
                }
                ProductoFrm productoFrm = new ProductoFrm(true, mainFrm, index);
                productoFrm.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No hay producto registrado por ende no puede actualizar informacion!!");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvData.Rows.Count == 0)
            {
                return;
            }

            int indice = dgvData.CurrentCell.RowIndex;
            mainFrm.productoModel.Remove(indice);
            dgvData.DataSource = mainFrm.productoModel.GetAll();
        }
    }
}
