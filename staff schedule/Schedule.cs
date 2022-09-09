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
                SqlCommand sqlCommand = new SqlCommand("SELECT �������������, ���������, ����, ���������� FROM Schedule", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                while (sqlDataReader.Read())
                {
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["�������������"]),
                        Convert.ToString(sqlDataReader["���������"]),
                        Convert.ToString(sqlDataReader["����"]),
                        Convert.ToString(sqlDataReader["����������"]) });

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
            connectionLabel.Text = "��� ����������� � ���� ������";

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ScheduleDB"].ConnectionString);
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open) connectionLabel.Text = "����������� �����������";
            else connectionLabel.Text = "����������� �� �����������";

            ShowGrid();
            FillComboBox(unitComboBox, "�������������");
            FillComboBox(postComboBox, "���������");
        }

        private void button_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Schedule] (�������������, ���������, ����, ����������) VALUES (N'{unitComboBox.Text}', N'{postComboBox.Text}', '{dateTimePicker.Value.ToString("MM/dd/yyyy")}', '{textBox.Text}')", sqlConnection);
            stateLabel.Text = command.ExecuteNonQuery().ToString() + "����� ����������";

            ShowGrid();
        }
    }
}