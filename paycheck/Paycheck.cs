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

        private void ShowGrid()
        {
            listView.Items.Clear();

            SqlDataReader sqlDataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Paycheck", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                while (sqlDataReader.Read())
                {
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["Должность"]),
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

        private void FillComboBox(ComboBox comboBox, String col)
        {

            SqlDataReader sqlDataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand($"SELECT DISTINCT {col} FROM Paycheck", sqlConnection);
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
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Paycheck] (Должность, Дата, Ставка) VALUES (N'{postСomboBox.Text}', '{dateTimePicker.Value.ToString("MM/dd/yyyy")}', '{textBox.Text}')", sqlConnection);
            stateLabel.Text = "Строк обработано: " + command.ExecuteNonQuery().ToString();

            ShowGrid();
        }
    }
}