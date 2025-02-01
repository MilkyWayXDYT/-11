using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 1;
            label2.Text = "";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Rows[0].Cells[0].Value = "0,0";
        }


        int n = 1;
        Random rnd = new Random();
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int v = (int)numericUpDown1.Value;
            if (v > n)
            {
                DataGridViewColumn column = new DataGridViewColumn();

                column.CellTemplate = new DataGridViewTextBoxCell();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns.Add(column);
                dataGridView1.Columns[n].Name = n.ToString();
                if (radioButton1.Checked)
                    dataGridView1.Rows[0].Cells[n].Value = "0,0";
                if (radioButton2.Checked)
                    dataGridView1.Rows[0].Cells[n].Value = Math.Round(rnd.NextDouble(), 2);
                n++;
            }
            else if (v < n)
            { 
                dataGridView1.Columns.RemoveAt(n - 1);
                n--;
            }

        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tx = ((Control)sender).Text;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (e.KeyChar == '-' && tx.Length == 0)
                return;
        }


    }
}
