using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace staff_schedule
{
    public partial class Schedule : Form
    {
        private SqlConnection sqlConnection = null;
        public Schedule()
        {
            InitializeComponent();
        }

        //Вывод таблицы данных
        private void ShowGrid()
        {
            listView.Items.Clear();

            SqlDataReader sqlDataReader = null;

            try
            {
                String command = "SELECT * FROM Schedule";
                //SQL запрос
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                //Чтение ответа на SQL запрос
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                //Добавление строк в ListView
                while (sqlDataReader.Read())
                {
                    //Добавляем строку в ListView как item
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["Подразделение"]),
                        Convert.ToString(sqlDataReader["Должность"]),
                        Convert.ToString(sqlDataReader["Дата"]),
                        Convert.ToString(sqlDataReader["Количество"]) });

                    listView.Items.Add(item);
                }
            }
            catch
            {

            }
            finally
            {
                if(sqlDataReader != null && !sqlDataReader.IsClosed) sqlDataReader.Close();
            }
        }

        //Добавление строки
        private void AddRow()
        {
            String command = $"INSERT INTO [Schedule] (Подразделение, Должность, Дата, Количество) " +
                             $"VALUES (N'{unitComboBox.Text}', N'{postComboBox.Text}', " +
                             $"'{dateTimePicker.Value.ToString("MM/dd/yyyy")}', '{numericUpDown.Value}')";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

            stateLabel.ForeColor = Color.Black;
            stateLabel.Text = "Строк добавлено: " + sqlCommand.ExecuteNonQuery().ToString(); //Вывод количества добавленных строк
        }

        //Заполнение comboBox информацией из таблицы
        private void FillComboBox(ComboBox comboBox, String col)
        {

            SqlDataReader sqlDataReader = null;

            try
            {
                String command = $"SELECT DISTINCT {col} FROM Schedule";
                //SQL запрос
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                //Чтение ответа на SQL запрос
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    comboBox.Items.Add(Convert.ToString(sqlDataReader[col]));
                }
            }
            catch
            {

            }
            finally
            {
                if (sqlDataReader != null && !sqlDataReader.IsClosed) sqlDataReader.Close(); //Закрываем sqlDataReader
            }
        }

        //Проверка ошибок
        private bool allIsGood()
        {
            if (numericUpDown.Value != 0 && unitComboBox.Text != "" && postComboBox.Text != "") return true;
            return false;
        }
        private void Schedule_Load(object sender, EventArgs e)
        {

            connectionLabel.ForeColor = Color.Yellow;
            connectionLabel.Text = "Идёт подключение к базе данных";

            //Подключаем базу данных
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString); 
            sqlConnection.Open(); //Открываем подключение

            if (sqlConnection.State == ConnectionState.Open)
            {
                connectionLabel.Text = "Подключение установлено";
                connectionLabel.ForeColor = Color.Green;
            }
            else
            {
                connectionLabel.Text = "Подключение не установлено";
                connectionLabel.ForeColor = Color.Red;
            }

            ShowGrid(); //Выводим таблицу

            FillComboBox(unitComboBox, "Подразделение"); //Заполняем comboBox информацией из базы данных
            FillComboBox(postComboBox, "Должность"); //Заполняем comboBox информацией из базы данных
        }

        //Добавление информации при нажатии
        private void button_Click(object sender, EventArgs e) 
        {
            if (allIsGood())
            {
                AddRow(); //Добавляем строку
                ShowGrid(); //Выводим таблицу
            }
            else
            {
                stateLabel.ForeColor = Color.Red;
                stateLabel.Text = "Ошибка!"; //Вывод сообщения об ошибке
            }
        }
    }
}