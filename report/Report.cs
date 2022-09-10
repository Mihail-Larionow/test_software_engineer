using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace report
{
    public partial class Report : Form
    {
        private SqlConnection sqlConnection = null;
        public Report()
        {
            InitializeComponent();
        }

        private void ShowGrid()
        {
            listView.Items.Clear();

            SqlDataReader sqlDataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Schedule.Подразделение, Paycheck.Дата, Paycheck.Ставка, Schedule.Количество FROM Paycheck, Schedule WHERE Paycheck.Должность = Schedule.Должность AND Paycheck.Дата = Schedule.Дата", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
               
                ListViewItem item = null;

                while (sqlDataReader.Read())
                {
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["Подразделение"]),
                        Convert.ToString(sqlDataReader["Дата"]),
                        Convert.ToString(sqlDataReader["Дата"]),
                        Convert.ToString(Convert.ToInt32(sqlDataReader["Ставка"]) * Convert.ToInt32(sqlDataReader["Количество"])) });

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

        private void Report_Load(object sender, EventArgs e)
        {
            connectionLabel.Text = "Идёт подключение к базе данных";

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString); //Подключаем базу данных
            sqlConnection.Open(); //Открываем подключение

            if (sqlConnection.State == ConnectionState.Open) connectionLabel.Text = "Подключение установлено";
            else connectionLabel.Text = "Подключение не установлено";

            ShowGrid(); //Выводим таблицу
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();

            SqlDataReader sqlDataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand($"SELECT Schedule.Подразделение, Paycheck.Дата, Paycheck.Ставка, Schedule.Количество FROM Paycheck, Schedule WHERE Paycheck.Должность = Schedule.Должность AND Paycheck.Дата = Schedule.Дата AND Paycheck.Дата BETWEEN '{startDateTimePicker.Text}' AND '{endDateTimePicker.Text}'", sqlConnection);
                stateLabel.Text = "Выбрано строк: " + sqlCommand.ExecuteNonQuery();
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                while (sqlDataReader.Read())
                {
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["Подразделение"]),
                        Convert.ToString(sqlDataReader["Дата"]),
                        Convert.ToString(endDateTimePicker.Text),
                        Convert.ToString(Convert.ToInt32(sqlDataReader["Ставка"]) * Convert.ToInt32(sqlDataReader["Количество"])) });

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
    }
}