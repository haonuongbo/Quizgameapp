using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quizgameapp1;

namespace Đồ_án_ứng_dụng
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            string userID = txtUserID.Text.Trim();

            if (string.IsNullOrEmpty(userID))
            {
                MessageBox.Show("Vui lòng nhập tên người chơi.");
                return;
            }

            int userDbId = -1;
            string connectionString = "Server=localhost;Database=QuizDB1;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra xem user đã tồn tại chưa
                SqlCommand checkCmd = new SqlCommand("SELECT ID FROM Users WHERE UserID = @userID", conn);
                checkCmd.Parameters.AddWithValue("@userID", userID);
                object result = checkCmd.ExecuteScalar();

                if (result != null)
                {
                    userDbId = Convert.ToInt32(result);
                }
                else
                {
                    // Chưa có thì thêm mới
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO Users (UserID, JoinDate) OUTPUT INSERTED.ID VALUES (@userID, GETDATE())", conn);
                    insertCmd.Parameters.AddWithValue("@userID", userID);
                    userDbId = (int)insertCmd.ExecuteScalar();
                }
            }
            string userName = txtUserID.Text.Trim();
            // Truyền cả tên và ID nếu cần
            frmQuizGame quizGame = new frmQuizGame(userDbId, userName);
            quizGame.Show();
            this.Hide();
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            frmLeaderboard leaderboard = new frmLeaderboard();
            leaderboard.ShowDialog(); // hoặc Show()
        }

        private void frmStart_Load_1(object sender, EventArgs e)
        {

        }
    }
}

