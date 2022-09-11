using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace report
{
    public partial class Report : Form
    {
        private SqlConnection sqlConnection = null; //Инициализация подключения к базе данных
        public Report()
        {
            InitializeComponent();
        }

        //Вывод таблицы данных в границах времени
        private void ShowGrid()
        {
            listView.Items.Clear();

            String startTime = startDateTimePicker.Value.ToString("MM-dd-yyyy"); //Инициализация даты начала промежутка
            String endTime = endDateTimePicker.Value.ToString("MM-dd-yyyy"); //Инициализация даты конца промежутка

            SqlDataReader sqlDataReader = null;

            try
            {
                String command = $"SELECT Schedule.Подразделение, Paycheck.Дата, Paycheck.Ставка, Schedule.Количество " +
                                 $"FROM Paycheck, Schedule WHERE Paycheck.Должность = Schedule.Должность AND " +
                                 $"Paycheck.Дата = Schedule.Дата AND Paycheck.Дата BETWEEN'{startTime}' AND '{endTime}'";
                //SQL запрос
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                //Чтение ответа на SQL запрос
                sqlDataReader = sqlCommand.ExecuteReader();
               
                ListViewItem item = null;

                //Добавление строк в ListView
                while (sqlDataReader.Read())
                {
                    DateTime lastTime = Convert.ToDateTime(sqlDataReader["Дата"]).AddMonths(5); //Добавление срока работы отдела
                    if (lastTime > endDateTimePicker.Value) lastTime = endDateTimePicker.Value; //Дата конца срока или конец промежутка
                    //Добавляем строку в ListView как item
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["Подразделение"]),
                        Convert.ToString(sqlDataReader["Дата"]),
                        Convert.ToString(lastTime),
                        Convert.ToString(Convert.ToInt32(sqlDataReader["Ставка"]) * Convert.ToInt32(sqlDataReader["Количество"])) });

                    listView.Items.Add(item);
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

        private void Report_Load(object sender, EventArgs e)
        {
            startDateTimePicker.Text = "26-11-2001"; //Инициализация начальной даты

            connectionLabel.ForeColor = Color.Yellow; 
            connectionLabel.Text = "Идёт подключение к базе данных";

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString); //Подключаем базу данных
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
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            ShowGrid();
        }
    }
}