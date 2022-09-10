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
                SqlCommand sqlCommand = new SqlCommand("SELECT Должность, Дата, Ставка FROM Paycheck", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                while (sqlDataReader.Read())
                {
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["Должность"]),
                        Convert.ToString(sqlDataReader["Дата"]),
                        Convert.ToString(sqlDataReader["Дата"]),
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

        private void Report_Load(object sender, EventArgs e)
        {
            connectionLabel.Text = "Идёт подключение к базе данных";

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString); //Подключаем базу данных
            sqlConnection.Open(); //Открываем подключение

            if (sqlConnection.State == ConnectionState.Open) connectionLabel.Text = "Подключение установлено";
            else connectionLabel.Text = "Подключение не установлено";

            ShowGrid(); //Выводим таблицу
        }
    }
}