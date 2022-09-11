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

        //����� ������� ������
        private void ShowGrid()
        {
            listView.Items.Clear();

            SqlDataReader sqlDataReader = null;

            try
            {
                String command = "SELECT * FROM Schedule";
                //SQL ������
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                //������ ������ �� SQL ������
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                //���������� ����� � ListView
                while (sqlDataReader.Read())
                {
                    //��������� ������ � ListView ��� item
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

        //���������� ������
        private void AddRow()
        {
            String command = $"INSERT INTO [Schedule] (�������������, ���������, ����, ����������) " +
                             $"VALUES (N'{unitComboBox.Text}', N'{postComboBox.Text}', " +
                             $"'{dateTimePicker.Value.ToString("MM/dd/yyyy")}', '{numericUpDown.Value}')";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

            stateLabel.ForeColor = Color.Black;
            stateLabel.Text = "����� ���������: " + sqlCommand.ExecuteNonQuery().ToString(); //����� ���������� ����������� �����
        }

        //���������� comboBox ����������� �� �������
        private void FillComboBox(ComboBox comboBox, String col)
        {

            SqlDataReader sqlDataReader = null;

            try
            {
                String command = $"SELECT DISTINCT {col} FROM Schedule";
                //SQL ������
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                //������ ������ �� SQL ������
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
                if (sqlDataReader != null && !sqlDataReader.IsClosed) sqlDataReader.Close(); //��������� sqlDataReader
            }
        }

        //�������� ������
        private bool allIsGood()
        {
            if (numericUpDown.Value != 0 && unitComboBox.Text != "" && postComboBox.Text != "") return true;
            return false;
        }
        private void Schedule_Load(object sender, EventArgs e)
        {

            connectionLabel.ForeColor = Color.Yellow;
            connectionLabel.Text = "��� ����������� � ���� ������";

            //���������� ���� ������
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString); 
            sqlConnection.Open(); //��������� �����������

            if (sqlConnection.State == ConnectionState.Open)
            {
                connectionLabel.Text = "����������� �����������";
                connectionLabel.ForeColor = Color.Green;
            }
            else
            {
                connectionLabel.Text = "����������� �� �����������";
                connectionLabel.ForeColor = Color.Red;
            }

            ShowGrid(); //������� �������

            FillComboBox(unitComboBox, "�������������"); //��������� comboBox ����������� �� ���� ������
            FillComboBox(postComboBox, "���������"); //��������� comboBox ����������� �� ���� ������
        }

        //���������� ���������� ��� �������
        private void button_Click(object sender, EventArgs e) 
        {
            if (allIsGood())
            {
                AddRow(); //��������� ������
                ShowGrid(); //������� �������
            }
            else
            {
                stateLabel.ForeColor = Color.Red;
                stateLabel.Text = "������!"; //����� ��������� �� ������
            }
        }
    }
}