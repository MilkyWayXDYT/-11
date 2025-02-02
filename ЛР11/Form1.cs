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
            dataGridView1.Rows[0].Cells[1].Value = "0,0";

            dataGridView2.RowCount = 1;
            dataGridView2.ColumnCount = 2;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Rows[0].Cells[0].Value = "0,0";
            dataGridView2.Rows[0].Cells[1].Value = "0,0";
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
            if (e.KeyChar == '.')
                e.KeyChar = ',';
            if (e.KeyChar == ',' && !tx.Contains(",") && tx.Length > 0)
                return;
            e.KeyChar = '\0';
        }

        // добавление столбиков в dataGridView
        int n = 2;
        Random rnd = new Random();
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int v = (int)numericUpDown1.Value;
            if (v > n)
            {
                // first array
                DataGridViewColumn column = new DataGridViewColumn();

                column.CellTemplate = new DataGridViewTextBoxCell();
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns.Add(column);
                dataGridView1.Columns[n].Name = n.ToString();
                DataGridViewColumn column2 = new DataGridViewColumn();

                column2.CellTemplate = new DataGridViewTextBoxCell();
                column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns.Add(column2);
                dataGridView1.Columns[n + 1].Name = (n + 1).ToString();

                if (radioButton1.Checked)
                {
                    dataGridView1.Rows[0].Cells[n].Value = "0,0";
                    dataGridView1.Rows[0].Cells[n + 1].Value = "0,0";
                }
                if (radioButton2.Checked)
                {
                    dataGridView1.Rows[0].Cells[n].Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
                    dataGridView1.Rows[0].Cells[n + 1].Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
                }

                // second array
                DataGridViewColumn column3 = new DataGridViewColumn();

                column3.CellTemplate = new DataGridViewTextBoxCell();
                column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns.Add(column3);
                dataGridView2.Columns[n].Name = n.ToString();

                DataGridViewColumn column4 = new DataGridViewColumn();

                column4.CellTemplate = new DataGridViewTextBoxCell();
                column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns.Add(column4);
                dataGridView2.Columns[n + 1].Name = (n + 1).ToString();

                if (radioButton1.Checked)
                {
                    dataGridView2.Rows[0].Cells[n].Value = "0,0";
                    dataGridView2.Rows[0].Cells[n + 1].Value = "0,0";
                }
                if (radioButton2.Checked)
                {
                    dataGridView2.Rows[0].Cells[n].Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
                    dataGridView2.Rows[0].Cells[n + 1].Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
                }

                n += 2;
            }
            else if (v < n)
            {
                // first array
                dataGridView1.Columns.RemoveAt(n - 1);
                dataGridView1.Columns.RemoveAt(n - 2);
                // second array
                dataGridView2.Columns.RemoveAt(n - 1);
                dataGridView2.Columns.RemoveAt(n - 2);

                n -= 2;
            }

        }

        // сброс всех значений в 0
        private void radioButton1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[0];
            DataGridViewRow row2 = dataGridView2.Rows[0];
            label2.Text = "";

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
            label2.Text = "";

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
            }
            foreach (DataGridViewCell cell in row2.Cells)
            {
                cell.Value = Math.Round(rnd.NextDouble() * (10 + 10) - 10, 2);
            }
        }

        // вычисление
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int columns = dataGridView1.ColumnCount;
                double[] arr1 = new double[columns];
                double[] arr2 = new double[columns];

                for (int i = 0; i < columns; i++)
                {
                    arr1[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[i].Value);
                    arr2[i] = Convert.ToDouble(dataGridView2.Rows[0].Cells[i].Value);
                }

                double res = ProcessingArray.Main(arr1, arr2);
                label2.Text = $"Y = {res}";
            }
            catch
            {
                MessageBox.Show("Некорректно заполнены поля массивов");
            }
        }


    }
}
