using System.Windows.Forms;

namespace project_6
{
    public partial class Form1 : Form
    {
        string SavePath = Path.Combine(Application.StartupPath, "save.txt");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value1 = this.textBox1.Text;
            string value2 = this.textBox2.Text;
            string value3 = this.textBox3.Text;
            string value4 = this.textBox4.Text;
            string value5 = this.textBox5.Text;

            if (!string.IsNullOrEmpty(value1) && char.IsUpper(value1[0]))
            {
                if (!string.IsNullOrEmpty(value2) && char.IsUpper(value2[0]))
                {
                    if (!string.IsNullOrEmpty(value3) && char.IsUpper(value3[0]))
                    {
                        int intValue;
                        if (!int.TryParse(value4, out intValue))
                        {
                            MessageBox.Show("Некорректное значение! Введите целое число.");
                        }
                        else
                        {
                            if (!int.TryParse(value5, out intValue))
                            {
                                MessageBox.Show("Некорректное значение! Введите целое число.");
                            }
                            else
                            {
                                dataGridView1.Rows.Add(value1, value2, value3, value4, value5);

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Первая буква НЕ является заглавной.");
                    }
                }
                else
                {
                    MessageBox.Show("Первая буква НЕ является заглавной.");
                }
            }
            else
            {
                MessageBox.Show("Первая буква НЕ является заглавной.");
            }

        }

        private void SaveDataGridViewToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            writer.Write(row.Cells[i].Value.ToString());
                            if (i < dataGridView1.Columns.Count - 1)
                            {
                                writer.Write(",");
                            }
                        }
                        writer.WriteLine();
                    }
                }
            }
        }

        private void LoadFileIntoDataGridView(string filePath)
        {
            dataGridView1.Rows.Clear(); // Очистка существующих данных в DataGridView

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    dataGridView1.Rows.Add(values);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveDataGridViewToFile(SavePath);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadFileIntoDataGridView(SavePath);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Замените yourColumnIndex на индекс вашей колонки
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string value = cell.Value.ToString();

                if (!string.IsNullOrEmpty(value) && char.IsUpper(value[0]))
                {
                }
                else
                {
                    MessageBox.Show("Первая буква НЕ является заглавной.");
                    cell.Value = "null";
                }
            }
            if (e.ColumnIndex == 1 && e.RowIndex >= 0) // Замените yourColumnIndex на индекс вашей колонки
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string value = cell.Value.ToString();

                if (!string.IsNullOrEmpty(value) && char.IsUpper(value[0]))
                {
                }
                else
                {
                    MessageBox.Show("Первая буква НЕ является заглавной.");
                    cell.Value = "null";
                }
            }
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Замените yourColumnIndex на индекс вашей колонки
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string value = cell.Value.ToString();

                if (!string.IsNullOrEmpty(value) && char.IsUpper(value[0]))
                {
                }
                else
                {
                    MessageBox.Show("Первая буква НЕ является заглавной.");
                    cell.Value = "null";
                }
            }
            if (e.ColumnIndex == 3 && e.RowIndex >= 0) // Замените yourColumnIndex на индекс вашей колонки
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string value = cell.Value.ToString();

                // Пример проверки на целое число
                int intValue;
                if (!int.TryParse(value, out intValue))
                {
                    MessageBox.Show("Некорректное значение! Введите целое число.");
                    cell.Value = 0;
                    // Сбросить значение ячейки или применить другие действия по валидации
                }
            }
            if (e.ColumnIndex == 4 && e.RowIndex >= 0) // Замените yourColumnIndex на индекс вашей колонки
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string value = cell.Value.ToString();

                // Пример проверки на целое число
                int intValue;
                if (!int.TryParse(value, out intValue))
                {
                    MessageBox.Show("Некорректное значение! Введите целое число.");
                    cell.Value = 0;
                    // Сбросить значение ячейки или применить другие действия по валидации
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 newForm = new Form2();
            
            
            DialogResult result = newForm.ShowDialog();
            if (result == DialogResult.OK)
            {

            }
            else if (result == DialogResult.Yes)
            {
                SaveDataGridViewToFile(SavePath);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
