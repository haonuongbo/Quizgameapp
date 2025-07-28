using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Đồ_án_ứng_dụng
{
    public partial class frmQuizGame : Form
    {
        // 🔗 Connection string to SQL Server
        private string connectionString = "Server=localhost;Database=QuizDB1;Trusted_Connection=True;";

        // 💾 Data
        private DataTable questionsTable;
        private int currentQuestionIndex = 0;
        private int score = 0;
        private int highScore = 0;
        private int currentUserId;
        private string currentUserName;
        private string topUserName = "";
        public frmQuizGame(int userId, string userName)
        {
            InitializeComponent();
            currentUserId = userId;
            currentUserName = userName;
        }

        // 🚀 Form Load
        private void frmQuizGame_Load(object sender, EventArgs e)
        {
            LoadCategories();
            lblScore.Text = $"Người chơi: {currentUserName} - Điểm: 0";
            LoadHighScore();
        }

        // 🔥 Load categories into ComboBox
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
                if (cbCategory.Items.Count > 0)
                {
                    cbCategory.SelectedIndex = 0;
                }
            }
        }

        // 🏆 Load High Score
        private void LoadHighScore()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT TOP 1 hs.Score, u.UserID 
            FROM HighScores hs
            LEFT JOIN Users u ON hs.UserId = u.ID
            ORDER BY hs.Score DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    highScore = Convert.ToInt32(reader["Score"]);
                    topUserName = reader["UserID"] != DBNull.Value ? reader["UserID"].ToString() : "Không xác định";
                    lblHighScore.Text = $"Kỷ lục: {topUserName} - {highScore} điểm";
                }
                else
                {
                    lblHighScore.Text = "Kỷ lục: (chưa có dữ liệu)";
                    topUserName = "";
                }
                
                conn.Close();
            }
        }



        private void SaveHighScore()
        {
            if (score > highScore)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string insertQuery = "INSERT INTO HighScores (Score, DateAchieved, UserId) VALUES (@score, GETDATE(), @userId)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.Parameters.AddWithValue("@userId", currentUserId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                highScore = score;

                
                LoadHighScore();

                MessageBox.Show("🏆 Bạn đã lập kỷ lục mới!");
            }
        }



        // 🎮 Start New Game
       

        // 🎯 Show Current Question
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
            btnA.Text = "A. " + row["OptionA"].ToString();
            btnB.Text = "B. " + row["OptionB"].ToString();
            btnC.Text = "C. " + row["OptionC"].ToString();
            btnD.Text = "D. " + row["OptionD"].ToString();
        }

        // ✅ Check Answer when Click Button
        private void AnswerButton_Click(object sender, EventArgs e)
        {
            if (questionsTable == null || questionsTable.Rows.Count == 0) return;

            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            string selectedOption = clickedButton.Name.Substring(clickedButton.Name.Length - 1);

            string correctOption = questionsTable.Rows[currentQuestionIndex]["CorrectOption"].ToString();

            if (selectedOption.Equals(correctOption, StringComparison.OrdinalIgnoreCase))
            {
                score += 10;
                lblScore.Text = $"Người chơi: {currentUserName} - Điểm: {score}";
                MessageBox.Show("🎉 Chính xác!");
            }
            else
            {
                MessageBox.Show("❌ Sai rồi! Đáp án đúng là: " + correctOption);
            }

            currentQuestionIndex++;
            ShowQuestion();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmStart startForm = new frmStart();
            startForm.Show();
            this.Hide();
        }

        // 💾 Save High Score



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quiz Game Made by Nguyen Duy Hao - 2474801030018.");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lblHighScore_Click(object sender, EventArgs e)
        {

        }

        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chủ đề trước khi chơi.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 10 * FROM Questions WHERE Category = @category ORDER BY NEWID()";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@category", cbCategory.SelectedItem.ToString());
                questionsTable = new DataTable();
                da.Fill(questionsTable);
            }

            currentQuestionIndex = 0;
            score = 0;
            lblScore.Text = $"Người chơi: {currentUserName} - Điểm: 0";

            if (questionsTable.Rows.Count > 0)
            {
                ShowQuestion();
            }
            else
            {
                MessageBox.Show("Không tìm thấy câu hỏi nào cho chủ đề này.");
            }
        }
        private void frmQuizGame_Resize(object sender, EventArgs e)
        {
            int margin = 30;
            int spacing = 10;

            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            int buttonWidth = (width - 3 * margin) / 2;
            int buttonHeight = (height - 300) / 2;

            // Câu hỏi
            lblQuestion.SetBounds(margin, 50, width - 2 * margin, 80);

            // Các nút đáp án
            btnA.SetBounds(margin, 150, buttonWidth, buttonHeight);
            btnB.SetBounds(margin * 2 + buttonWidth, 150, buttonWidth, buttonHeight);
            btnC.SetBounds(margin, 160 + buttonHeight + spacing, buttonWidth, buttonHeight);
            btnD.SetBounds(margin * 2 + buttonWidth, 160 + buttonHeight + spacing, buttonWidth, buttonHeight);

            // Các thành phần khác
            cbCategory.SetBounds((width - 180) / 2, height - 85, 180, 21);
            lblSelectCategory.Location = new Point(cbCategory.Left + 10, cbCategory.Top - 20);
            btnNewGame.Location = new Point(cbCategory.Left, cbCategory.Bottom + 5);
            btnBack.Location = new Point(width - margin - 75, height - 50);
            

            // ✅ Tăng cỡ chữ theo kích thước form
            int baseFontSize = 12;
            float scaleFactor = (float)Math.Min(width / 750.0, height / 600.0); // scale theo cả chiều rộng và cao
            int newFontSize = Math.Max((int)(baseFontSize * scaleFactor), 10);


            Font newFontBold = new Font("Segoe UI", newFontSize, FontStyle.Bold);
            Font newFontRegular = new Font("Segoe UI", newFontSize, FontStyle.Regular);

            // Gán font mới
            btnA.Font = newFontBold;
            btnB.Font = newFontBold;
            btnC.Font = newFontBold;
            btnD.Font = newFontBold;

            
        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
