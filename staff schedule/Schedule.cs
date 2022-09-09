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

        private void ShowGrid()
        {
            listView.Items.Clear();

            SqlDataReader sqlDataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Подразделение, Должность, Дата, Количество FROM Schedule", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                while (sqlDataReader.Read())
                {
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

        private void FillComboBox(ComboBox comboBox, String col)
        {

            SqlDataReader sqlDataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand($"SELECT DISTINCT {col} FROM Schedule", sqlConnection);
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

        private void Schedule_Load(object sender, EventArgs e)
        {
            connectionLabel.Text = "Идёт подключение к базе данных";

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScheduleDB"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open) connectionLabel.Text = "Подключение установлено";
            else connectionLabel.Text = "Подключение не установлено";

            ShowGrid();
            FillComboBox(unitComboBox, "Подразделение");
            FillComboBox(postComboBox, "Должность");
        }

        private void button_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Schedule] (Подразделение, Должность, Дата, Количество) VALUES (N'{unitComboBox.Text}', N'{postComboBox.Text}', '{dateTimePicker.Value.ToString("MM/dd/yyyy")}', '{textBox.Text}')", sqlConnection);
            stateLabel.Text = command.ExecuteNonQuery().ToString() + "строк обработано";

            ShowGrid();
        }
    }
}