using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Đồ_án_ứng_dụng
{
    public partial class frmLeaderboard : Form
    {
        private string connectionString = "Server=localhost;Database=QuizDB1;Trusted_Connection=True;";

        public frmLeaderboard()
        {
            InitializeComponent();
        }

        private void frmLeaderboard_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
    SELECT TOP 10 
        hs.Id,
        ROW_NUMBER() OVER (ORDER BY hs.Score DESC) AS [#],
        u.UserID AS [Người chơi],
        hs.Score AS [Điểm],
        hs.DateAchieved AS [Ngày lập]
    FROM HighScores hs
    LEFT JOIN Users u ON hs.UserId = u.Id
    ORDER BY hs.Score DESC";


                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.ReadOnly = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmLeaderboard_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnDeleteScore_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng muốn xóa.");
                return;
            }

            // Lấy ID điểm đã chọn từ dòng đầu tiên
            int highScoreId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa điểm này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM HighScores WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", highScoreId);

                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    frmLeaderboard_Load(null, null); // reload lại bảng
                }
                else
                {
                    MessageBox.Show("Không thể xóa!");
                }
            }
        }

    }
}
