using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace paycheck
{
    public partial class Paycheck : Form
    {
        private SqlConnection sqlConnection = null;
        public Paycheck()
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
                String command = "SELECT * FROM Paycheck";
                //SQL запрос
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                //Чтение ответа на SQL запрос
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                //Добавление строк в ListView
                while (sqlDataReader.Read())
                {
                    //Добавляем строку в ListView как item
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["Должность"]),
                        Convert.ToDateTime(sqlDataReader["Дата"]).ToString("dd.MM.yyyy"),
                        Convert.ToString(sqlDataReader["Ставка"]) });

                    listView.Items.Add(item);
                }
            }
            catch
            {

            }
            finally
            {
                if (sqlDataReader != null && !sqlDataReader.IsClosed) sqlDataReader.Close();
            }
        }

        //Добавление строки
        private void AddRow()
        {
            String command = $"INSERT INTO [Paycheck] (Должность, Дата, Ставка) " +
                             $"VALUES (N'{postСomboBox.Text}', '{dateTimePicker.Value.ToString("MM/dd/yyyy")}'," +
                             $" '{numericUpDown.Value}')";
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
                String command = $"SELECT DISTINCT {col} FROM Paycheck";
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
                if (sqlDataReader != null && !sqlDataReader.IsClosed) sqlDataReader.Close();
            }
        }

        //Проверка ошибок
        private bool allIsGood()
        {
            if (numericUpDown.Value != 0 && postСomboBox.Text != "") return true;
            return false;
        }

        private void Paycheck_Load(object sender, EventArgs e)
        {
            connectionLabel.Text = "Идёт подключение к базе данных";

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString); //Подключаем базу данных
            sqlConnection.Open(); //Открываем подключение

            if (sqlConnection.State == ConnectionState.Open) connectionLabel.Text = "Подключение установлено";
            else connectionLabel.Text = "Подключение не установлено";

            ShowGrid(); //Выводим таблицу
            FillComboBox(postСomboBox, "Должность"); //Заполняем comboBox информацией из базы данных
        }

        private void addButton_Click(object sender, EventArgs e)
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