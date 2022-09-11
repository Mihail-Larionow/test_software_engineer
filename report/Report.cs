using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace report
{
    public partial class Report : Form
    {
        private SqlConnection sqlConnection = null; //������������� ����������� � ���� ������
        public Report()
        {
            InitializeComponent();
        }

        //����� ������� ������ � �������� �������
        private void ShowGrid()
        {
            listView.Items.Clear();

            String startTime = startDateTimePicker.Value.ToString("MM-dd-yyyy"); //������������� ���� ������ ����������
            String endTime = endDateTimePicker.Value.ToString("MM-dd-yyyy"); //������������� ���� ����� ����������

            SqlDataReader sqlDataReader = null;

            try
            {
                String command = $"SELECT Schedule.�������������, Paycheck.����, Paycheck.������, Schedule.���������� " +
                                 $"FROM Paycheck, Schedule WHERE Paycheck.��������� = Schedule.��������� AND " +
                                 $"Paycheck.���� = Schedule.���� AND Paycheck.���� BETWEEN'{startTime}' AND '{endTime}'";
                //SQL ������
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                //������ ������ �� SQL ������
                sqlDataReader = sqlCommand.ExecuteReader();
               
                ListViewItem item = null;

                //���������� ����� � ListView
                while (sqlDataReader.Read())
                {
                    DateTime lastTime = Convert.ToDateTime(sqlDataReader["����"]).AddMonths(5); //���������� ����� ������ ������
                    if (lastTime > endDateTimePicker.Value) lastTime = endDateTimePicker.Value; //���� ����� ����� ��� ����� ����������
                    //��������� ������ � ListView ��� item
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["�������������"]),
                        Convert.ToString(sqlDataReader["����"]),
                        Convert.ToString(lastTime),
                        Convert.ToString(Convert.ToInt32(sqlDataReader["������"]) * Convert.ToInt32(sqlDataReader["����������"])) });

                    listView.Items.Add(item);
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

        private void Report_Load(object sender, EventArgs e)
        {
            startDateTimePicker.Text = "26-11-2001"; //������������� ��������� ����

            connectionLabel.ForeColor = Color.Yellow; 
            connectionLabel.Text = "��� ����������� � ���� ������";

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString); //���������� ���� ������
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
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            ShowGrid();
        }
    }
}