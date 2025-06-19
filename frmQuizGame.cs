using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Đồ_án_ứng_dụng
{
    public partial class frmQuizGame : Form
    {
        private string connectionString = "Server=localhost;Database=QuizDB1;Trusted_Connection=True;";
        private DataTable questionsTable;
        private int currentQuestionIndex = 0;
        private int score = 0;
        private int highScore = 0;

        public frmQuizGame()
        {
            InitializeComponent();
        }

        // Khi Form tải lên
        private void frmQuizGame_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadHighScore();
        }

        private void LoadCategories()
        {
            cbCategory.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Category FROM Questions", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbCategory.Items.Add(reader["Category"].ToString());
                }
                conn.Close();
            }
        }

        private void LoadHighScore()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MAX(Score) FROM HighScores", conn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    highScore = Convert.ToInt32(result);
                    lblHighScore.Text = "Kỷ lục: " + highScore;
                }
                else
                {
                    lblHighScore.Text = "Kỷ lục: (chưa có dữ liệu)";
                }
                conn.Close();
            }
        }

        // Khi nhấn nút "Chơi mới"
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chủ đề trước khi chơi.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Questions WHERE Category = @category ORDER BY NEWID()";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@category", cbCategory.SelectedItem.ToString());
                questionsTable = new DataTable();
                da.Fill(questionsTable);
            }

            currentQuestionIndex = 0;
            score = 0;
            lblScore.Text = "Điểm: 0";

            if (questionsTable.Rows.Count > 0)
            {
                ShowQuestion();
            }
            else
            {
                MessageBox.Show("Không tìm thấy câu hỏi nào cho chủ đề này.");
            }
        }

        private void ShowQuestion()
        {
            if (currentQuestionIndex >= questionsTable.Rows.Count)
            {
                MessageBox.Show("Hết câu hỏi! Tổng điểm: " + score);
                SaveHighScore();
                return;
            }

            DataRow row = questionsTable.Rows[currentQuestionIndex];
            lblQuestion.Text = row["QuestionText"].ToString();
            rbA.Text = "A. " + row["OptionA"].ToString();
            rbB.Text = "B. " + row["OptionB"].ToString();
            rbC.Text = "C. " + row["OptionC"].ToString();
            rbD.Text = "D. " + row["OptionD"].ToString();

            rbA.Checked = rbB.Checked = rbC.Checked = rbD.Checked = false;
        }

        // Khi nhấn nút "Trả lời"
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (questionsTable == null || questionsTable.Rows.Count == 0) return;

            string selectedOption = "";
            if (rbA.Checked) selectedOption = "A";
            else if (rbB.Checked) selectedOption = "B";
            else if (rbC.Checked) selectedOption = "C";
            else if (rbD.Checked) selectedOption = "D";
            else
            {
                MessageBox.Show("Vui lòng chọn một đáp án.");
                return;
            }

            string correctOption = questionsTable.Rows[currentQuestionIndex]["CorrectOption"].ToString();

            if (selectedOption == correctOption)
            {
                score += 10;
                lblScore.Text = "Điểm: " + score;
                MessageBox.Show("Chính xác!");
            }
            else
            {
                MessageBox.Show("Sai rồi! Đáp án đúng là: " + correctOption);
            }

            currentQuestionIndex++;
            ShowQuestion();
        }

        private void SaveHighScore()
        {
            if (score > highScore)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string insertQuery = "INSERT INTO HighScores (Score, DateAchieved) VALUES (@score, GETDATE())";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@score", score);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                highScore = score;
                lblHighScore.Text = "Kỷ lục: " + highScore;
                MessageBox.Show("Bạn đã lập kỷ lục mới!");
            }
        }
    }
}
