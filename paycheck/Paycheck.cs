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

        //����� ������� ������
        private void ShowGrid()
        {
            listView.Items.Clear();

            SqlDataReader sqlDataReader = null;

            try
            {
                String command = "SELECT * FROM Paycheck";
                //SQL ������
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                //������ ������ �� SQL ������
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                //���������� ����� � ListView
                while (sqlDataReader.Read())
                {
                    //��������� ������ � ListView ��� item
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["���������"]),
                        Convert.ToDateTime(sqlDataReader["����"]).ToString("dd.MM.yyyy"),
                        Convert.ToString(sqlDataReader["������"]) });

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

        //���������� ������
        private void AddRow()
        {
            String command = $"INSERT INTO [Paycheck] (���������, ����, ������) " +
                             $"VALUES (N'{post�omboBox.Text}', '{dateTimePicker.Value.ToString("MM/dd/yyyy")}'," +
                             $" '{numericUpDown.Value}')";
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
                String command = $"SELECT DISTINCT {col} FROM Paycheck";
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
                if (sqlDataReader != null && !sqlDataReader.IsClosed) sqlDataReader.Close();
            }
        }

        //�������� ������
        private bool allIsGood()
        {
            if (numericUpDown.Value != 0 && post�omboBox.Text != "") return true;
            return false;
        }

        private void Paycheck_Load(object sender, EventArgs e)
        {
            connectionLabel.Text = "��� ����������� � ���� ������";

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString); //���������� ���� ������
            sqlConnection.Open(); //��������� �����������

            if (sqlConnection.State == ConnectionState.Open) connectionLabel.Text = "����������� �����������";
            else connectionLabel.Text = "����������� �� �����������";

            ShowGrid(); //������� �������
            FillComboBox(post�omboBox, "���������"); //��������� comboBox ����������� �� ���� ������
        }

        private void addButton_Click(object sender, EventArgs e)
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