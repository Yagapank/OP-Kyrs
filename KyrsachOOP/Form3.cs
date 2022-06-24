using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KyrsachOOP

{
    public partial class Form3 : Form
    {
        DataBase1 dataBase = new DataBase1();

        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColums()
        {
            dataGridView1.Columns.Add("Number", "Номер");
            dataGridView1.Columns.Add("Stroka1", "Строка 1");
            dataGridView1.Columns.Add("Stroka2", "Строка 2");
            dataGridView1.Columns.Add("Answer", "Ответ");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var str1 = textBox1.Text;
            var str2 = textBox2.Text;
            string str21 = Convert.ToString(StringDistance.LevenshteinDistance(str1, str2));
            textBox3.Text = str21;
            string addanswer = $"insert into Answer(Answer, Stroka1, Stroka2) values ('{str21}', '{str1}', '{str2}')";

            SqlCommand command = new SqlCommand(addanswer, dataBase.getConnection());
            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Произведена запись в БД");
                Form3 adddanswer = new Form3();
                this.Hide();
                adddanswer.ShowDialog();
            }
            else
            {
                MessageBox.Show("Запись в БД не прошла");
            }

            dataBase.closeConnection();


        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "logpassDataSet2.answer". При необходимости она может быть перемещена или удалена.
            this.answerTableAdapter.Fill(this.logpassDataSet2.answer);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
