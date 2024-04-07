using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MathCats
{

    public partial class mat : Form
    {
        double[,] arr1 = new double[10, 10];
        double[,] arr2 = new double[10, 10];
        double[,] arr3 = new double[10, 10];
        private const string _TABLE_PANEL_NAME = "_tableLayoutPanel";
        private const string _TABLE_PANEL_NAME1 = "_tableLayoutPanel1";
        public mat()
        {
            InitializeComponent();
            _comboBox.SelectedValueChanged += _comboBox_SelectedValueChanged;
            comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged;
        }
        private void _comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //значение выбора
            var item = _comboBox.SelectedItem.ToString();

            //извлекаем требуемые количества для строк и столбцов
            int rowCount = Int32.Parse(item.Substring(0, 1));
            int columnCount = Int32.Parse(item.Substring(2, 1));

            //отобразить матрицу
            ShowMatrix(rowCount, columnCount);
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //значение выбора
            var item = comboBox1.SelectedItem.ToString();

            //извлекаем требуемые количества для строк и столбцов
            int rowCount = Int32.Parse(item.Substring(0, 1));
            int columnCount = Int32.Parse(item.Substring(2, 1));

            //отобразить матрицу
            ShowMatrix1(rowCount, columnCount);
        }

        //отображение матрицы
        private void ShowMatrix(int rowCount, int columnCount)
        {
            //создание TableLayoutPanel
            CreateTablePanel(rowCount, columnCount);

            //находим по имени только что созданную TableLayoutPanel
            var tablePanel = this.Controls
                                    .Find(_TABLE_PANEL_NAME, true)
                                    .First() as TableLayoutPanel;

            //вставляем текстбоксы
            for (int i = 0; i < columnCount; i++)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    var txt = $"{i},{j}";
                    //новый текстбокс с текстовкой, именем, шириной
                    var tb = new System.Windows.Forms.TextBox { Text = txt, Name = txt, Width = 30 };
                    arr1[i, j] = Convert.ToDouble(txt);
                    tablePanel.Controls.Add(tb);
                }
            }

        }
        private void ShowMatrix1(int rowCount1, int columnCount1)
        {
            //создание TableLayoutPanel
            CreateTablePanel1(rowCount1, columnCount1);

            //находим по имени только что созданную TableLayoutPanel
            var tablePanel = this.Controls
                                    .Find(_TABLE_PANEL_NAME1, true)
                                    .First() as TableLayoutPanel;

            //вставляем текстбоксы
            for (int i = 0; i < columnCount1; i++)
            {
                for (int j = 0; j < rowCount1; j++)
                {
                    var txt = $"{i},{j}";
                    //новый текстбокс с текстовкой, именем, шириной
                    var tb = new System.Windows.Forms.TextBox { Text = txt, Name = txt, Width = 30 };
                    //добавляем
                    arr2[i, j] = Convert.ToDouble(txt);

                    tablePanel.Controls.Add(tb);
                }
            }

        }
        private void umn(double[,] arr1, double x, int rowCount, int columnCount) // подпрограмма умножения, работает неверно умножая начальную матрицу
                                                                                  // на число а не матрицу существующую
        {
            CreateTablePanel(rowCount, columnCount);

            //находим по имени только что созданную TableLayoutPanel
            var tablePanel = this.Controls
                                    .Find(_TABLE_PANEL_NAME, true)
                                    .First() as TableLayoutPanel;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    arr1[i, j] = arr1[i, j] * x;
                }
            }
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    var txt = $"{arr1[i, j]}";
                    var tb = new System.Windows.Forms.TextBox { Text = txt, Name = txt, Width = 30 };
                    tablePanel.Controls.Add(tb);
                }
            }

        }
        private void plus(double[,] arr1, double[,] arr2, int rowCount, int columnCount, int rowCount1, int columnCount1)
        {
            if (rowCount == rowCount1)
            {
                if (columnCount == columnCount1)
                {
                    CreateTablePanel(rowCount, columnCount);
                    var tablePanel = this.Controls
                                           .Find(_TABLE_PANEL_NAME, true)
                                           .First() as TableLayoutPanel;
                    CreateTablePanel1(rowCount1, columnCount1);
                    var tablePanel1 = this.Controls
                                           .Find(_TABLE_PANEL_NAME, true)
                                           .First() as TableLayoutPanel;

                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            arr1[i, j] = arr1[i, j] + arr2[i, j];
                        }
                    }
                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            var txt = $"{arr1[i, j]}";
                            var tb = new System.Windows.Forms.TextBox { Text = txt, Name = txt, Width = 30 };
                            tablePanel.Controls.Add(tb);
                        }
                    }
                }
            }

        }
        private void minus(double[,] arr1, double[,] arr2, int rowCount, int columnCount, int rowCount1, int columnCount1)
        {
            if (rowCount == rowCount1)
            {
                if (columnCount == columnCount1)
                {


                    CreateTablePanel(rowCount, columnCount);
                    var tablePanel = this.Controls
                                           .Find(_TABLE_PANEL_NAME, true)
                                           .First() as TableLayoutPanel;
                    CreateTablePanel1(rowCount1, columnCount1);
                    var tablePanel1 = this.Controls
                                           .Find(_TABLE_PANEL_NAME, true)
                                           .First() as TableLayoutPanel;

                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            arr1[i, j] = arr1[i, j] - arr2[i, j];
                        }
                    }
                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            var txt = $"{arr1[i, j]}";
                            var tb = new System.Windows.Forms.TextBox { Text = txt, Name = txt, Width = 30 };
                            tablePanel.Controls.Add(tb);
                        }
                    }
                }
            }

        }
        private void multiplication(double[,] arr1, double[,] arr2, int rowCount, int columnCount, int rowCount1, int columnCount1)
        {
            if (rowCount == rowCount1)
            {
                if (columnCount == columnCount1)
                {


                    CreateTablePanel(rowCount, columnCount);
                    var tablePanel = this.Controls
                                           .Find(_TABLE_PANEL_NAME, true)
                                           .First() as TableLayoutPanel;
                    CreateTablePanel1(rowCount1, columnCount1);
                    var tablePanel1 = this.Controls
                                           .Find(_TABLE_PANEL_NAME, true)
                                           .First() as TableLayoutPanel;

                    for (int i = 0; i < arr1.GetLength(0); i++)
                    {
                        for (int j = 0; j < arr2.GetLength(1); j++)
                        {
                            for (int k = 0; k < arr2.GetLength(0); k++)
                            {
                                arr3[i, j] += arr1[i, k] * arr2[k, j];
                            }
                        }
                    }
                    for (int i = 0; i < rowCount; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            var txt = $"{arr3[i, j]}";
                            var tb = new System.Windows.Forms.TextBox { Text = txt, Name = txt, Width = 30 };
                            tablePanel.Controls.Add(tb);
                        }
                    }
                }
            }

        }
        //создание новой панели
        private void CreateTablePanel(int rowCount, int columnCount)
        {
            //если были ранее созданы с тем же именем TableLayoutPanel
            //то удаляем их
            var oldPanels = this.Controls.Find(_TABLE_PANEL_NAME, true);
            Array.ForEach(oldPanels, new Action<Control>(c => this.Controls.Remove(c)));

            //позиция для новой панели
            Point pos = new Point { X = 10, Y = 75 };

            TableLayoutPanel tablePanel = new TableLayoutPanel
            {
                Location = pos,
                Name = _TABLE_PANEL_NAME,
                RowCount = rowCount,
                ColumnCount = columnCount
            };

            //назначаем размеры для строк и столбцов
            for (int i = 0; i < tablePanel.RowStyles.Count; i++)
            {
                tablePanel.RowStyles[i].SizeType = SizeType.Absolute;
                tablePanel.RowStyles[i].Height = 30;
            }
            for (int i = 0; i < tablePanel.ColumnStyles.Count; i++)
            {
                tablePanel.ColumnStyles[i].SizeType = SizeType.Absolute;
                tablePanel.ColumnStyles[i].Width = 40;
            }

            //добавляем панель
            this.Controls.Add(tablePanel);
        }
        private void CreateTablePanel1(int rowCount1, int columnCount1)
        {
            //если были ранее созданы с тем же именем TableLayoutPanel
            //то удаляем их
            var oldPanels1 = this.Controls.Find(_TABLE_PANEL_NAME1, true);
            Array.ForEach(oldPanels1, new Action<Control>(c => this.Controls.Remove(c)));

            //позиция для новой панели
            Point pos1 = new Point { X = 210, Y = 75 };

            TableLayoutPanel tablePanel1 = new TableLayoutPanel
            {
                Location = pos1,
                Name = _TABLE_PANEL_NAME1,
                RowCount = rowCount1,
                ColumnCount = columnCount1
            };

            //назначаем размеры для строк и столбцов
            for (int i = 0; i < tablePanel1.RowStyles.Count; i++)
            {
                tablePanel1.RowStyles[i].SizeType = SizeType.Absolute;
                tablePanel1.RowStyles[i].Height = 30;
            }
            for (int i = 0; i < tablePanel1.ColumnStyles.Count; i++)
            {
                tablePanel1.ColumnStyles[i].SizeType = SizeType.Absolute;
                tablePanel1.ColumnStyles[i].Width = 40;
            }

            //добавляем панель
            this.Controls.Add(tablePanel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = _comboBox.SelectedItem.ToString();

            //извлекаем требуемые количества для строк и столбцов
            int rowCount = Int32.Parse(item.Substring(0, 1));
            int columnCount = Int32.Parse(item.Substring(2, 1));
            double x = Convert.ToDouble(textBox1.Text);
            umn(arr1, x, rowCount, columnCount);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var item = _comboBox.SelectedItem.ToString();
            var item1 = comboBox1.SelectedItem.ToString();
            int rowCount = Int32.Parse(item.Substring(0, 1));
            int columnCount = Int32.Parse(item.Substring(2, 1));
            int rowCount1 = Int32.Parse(item1.Substring(0, 1));
            int columnCount1 = Int32.Parse(item1.Substring(2, 1));
            plus(arr1, arr2, rowCount, columnCount, rowCount1, columnCount1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var item = _comboBox.SelectedItem.ToString();
            var item1 = comboBox1.SelectedItem.ToString();
            int rowCount = Int32.Parse(item.Substring(0, 1));
            int columnCount = Int32.Parse(item.Substring(2, 1));
            int rowCount1 = Int32.Parse(item1.Substring(0, 1));
            int columnCount1 = Int32.Parse(item1.Substring(2, 1));
            minus(arr1, arr2, rowCount, columnCount, rowCount1, columnCount1);
        }

        private void mat_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.FillRectangle(Brushes.Orange, 0, 0, 615, 230);
            graphics.FillRectangle(Brushes.White, 5, 5, 600, 200);
            graphics.DrawRectangle(Pens.Black, 5, 5, 600, 200);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var item = _comboBox.SelectedItem.ToString();
            var item1 = comboBox1.SelectedItem.ToString();
            int rowCount = Int32.Parse(item.Substring(0, 1));
            int columnCount = Int32.Parse(item.Substring(2, 1));
            int rowCount1 = Int32.Parse(item1.Substring(0, 1));
            int columnCount1 = Int32.Parse(item1.Substring(2, 1));
            multiplication(arr1, arr2, rowCount, columnCount, rowCount1, columnCount1);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            var item = _comboBox.SelectedItem.ToString();
            var item1 = comboBox1.SelectedItem.ToString();
            int rowCount = Int32.Parse(item.Substring(0, 1));
            int columnCount = Int32.Parse(item.Substring(2, 1));
            int rowCount1 = Int32.Parse(item1.Substring(0, 1));
            int columnCount1 = Int32.Parse(item1.Substring(2, 1));
         
         
            for (int i = 0; i < columnCount1; i++)
            {
                for (int j = 0; j < rowCount1; j++)
                {
                    var tablePanel = this.Controls
                                  .Find(_TABLE_PANEL_NAME, true)
                                  .First() as TableLayoutPanel;
                    arr1[i, j] = Convert.ToDouble(tablePanel); // не работает, написан бред - настучать по башке Артёму

                }

            }
        }
    }
}


