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

            label2.Text = "";
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 2;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Rows[0].Cells[0].Value = "0,0";
            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = 1;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Rows[0].Cells[0].Value = "0,0";
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            e.Control.KeyPress -= dataGridView1_KeyPress;
            e.Control.KeyPress += dataGridView1_KeyPress;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tx = ((Control)sender).Text;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
                return;
            if (e.KeyChar == '-' && tx.Length == 0)
                return;
            if (e.KeyChar == (char)Keys.Back)
                return;
            e.KeyChar = '\0';
        }

        // добавление столбиков в dataGridView
        int n1 = 1;
        int n2 = 1;
        Random rnd = new Random();
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int v = (int)numericUpDown1.Value;
            if (v > n1)
            {
                DataGridViewColumn column = new DataGridViewColumn();

                column.CellTemplate = new DataGridViewTextBoxCell();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns.Add(column);
                dataGridView1.Columns[n1-1].Name = (n1-1).ToString();
                DataGridViewColumn column2 = new DataGridViewColumn();

                column2.CellTemplate = new DataGridViewTextBoxCell();
                column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns.Add(column2);
                dataGridView1.Columns[n1].Name = n1.ToString();

                if (radioButton1.Checked)
                    dataGridView1.Rows[0].Cells[n1].Value = "0,0";
                if (radioButton2.Checked)
                    dataGridView1.Rows[0].Cells[n1].Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
                n1+=2;
            }
            else if (v < n1)
            { 
                dataGridView1.Columns.RemoveAt(n1 - 1);
                dataGridView1.Columns.RemoveAt(n1 - 2);
                n1-=2;
            }

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int v = (int)numericUpDown2.Value;
            if (v > n2)
            {
                DataGridViewColumn column = new DataGridViewColumn();

                column.CellTemplate = new DataGridViewTextBoxCell();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns.Add(column);
                dataGridView2.Columns[n2].Name = n2.ToString();
                if (radioButton1.Checked)
                    dataGridView2.Rows[0].Cells[n2].Value = "0,0";
                if (radioButton2.Checked)
                    dataGridView2.Rows[0].Cells[n2].Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
                n2++;
            }
            else if (v < n2)
            {
                dataGridView2.Columns.RemoveAt(n2 - 1);
                n2--;
            }
        }

        // сброс всех значений в 0
        private void radioButton1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[0];
            DataGridViewRow row2 = dataGridView2.Rows[0];

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Value = "0,0";
            }
            foreach (DataGridViewCell cell in row2.Cells)
            {
                cell.Value = "0,0";
            }
        }

        // заполнение ячеек случайным набором чисел
        private void radioButton2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[0];
            DataGridViewRow row2 = dataGridView2.Rows[0];

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
            }
            foreach (DataGridViewCell cell in row2.Cells)
            {
                cell.Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessingArray processing = new ProcessingArray();
            int rows1 = dataGridView1.RowCount;

            label2.Text = "{processing.Main(, )}";
        }

        
    }
}
