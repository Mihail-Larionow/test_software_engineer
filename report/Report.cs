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
                SqlCommand sqlCommand = new SqlCommand("SELECT ���������, ����, ������ FROM Paycheck", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                while (sqlDataReader.Read())
                {
                    item = new ListViewItem(new String[] {Convert.ToString(sqlDataReader["���������"]),
                        Convert.ToString(sqlDataReader["����"]),
                        Convert.ToString(sqlDataReader["����"]),
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

        private void Report_Load(object sender, EventArgs e)
        {
            connectionLabel.Text = "��� ����������� � ���� ������";

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString); //���������� ���� ������
            sqlConnection.Open(); //��������� �����������

            if (sqlConnection.State == ConnectionState.Open) connectionLabel.Text = "����������� �����������";
            else connectionLabel.Text = "����������� �� �����������";

            ShowGrid(); //������� �������
        }
    }
}