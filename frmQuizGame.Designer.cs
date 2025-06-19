namespace Đồ_án_ứng_dụng
{
    partial class frmQuizGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblSelectCategory = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.rbA = new System.Windows.Forms.RadioButton();
            this.rbB = new System.Windows.Forms.RadioButton();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.rbD = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // cbCategory
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(150, 25);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(200, 28);
            this.cbCategory.TabIndex = 0;

            // lblSelectCategory
            this.lblSelectCategory.AutoSize = true;
            this.lblSelectCategory.Location = new System.Drawing.Point(30, 30);
            this.lblSelectCategory.Name = "lblSelectCategory";
            this.lblSelectCategory.Size = new System.Drawing.Size(112, 20);
            this.lblSelectCategory.Text = "Chọn chủ đề:";

            // lblQuestion
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.Location = new System.Drawing.Point(30, 70);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(620, 60);
            this.lblQuestion.Text = "Câu hỏi sẽ hiển thị ở đây";

            // rbA
            this.rbA.AutoSize = true;
            this.rbA.Location = new System.Drawing.Point(50, 150);
            this.rbA.Name = "rbA";
            this.rbA.Size = new System.Drawing.Size(85, 24);
            this.rbA.TabIndex = 1;
            this.rbA.TabStop = true;
            this.rbA.Text = "Đáp án A";

            // rbB
            this.rbB.AutoSize = true;
            this.rbB.Location = new System.Drawing.Point(50, 190);
            this.rbB.Name = "rbB";
            this.rbB.Size = new System.Drawing.Size(86, 24);
            this.rbB.TabIndex = 2;
            this.rbB.TabStop = true;
            this.rbB.Text = "Đáp án B";

            // rbC
            this.rbC.AutoSize = true;
            this.rbC.Location = new System.Drawing.Point(50, 230);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(86, 24);
            this.rbC.TabIndex = 3;
            this.rbC.TabStop = true;
            this.rbC.Text = "Đáp án C";

            // rbD
            this.rbD.AutoSize = true;
            this.rbD.Location = new System.Drawing.Point(50, 270);
            this.rbD.Name = "rbD";
            this.rbD.Size = new System.Drawing.Size(87, 24);
            this.rbD.TabIndex = 4;
            this.rbD.TabStop = true;
            this.rbD.Text = "Đáp án D";

            // btnSubmit
            this.btnSubmit.Location = new System.Drawing.Point(300, 320);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 35);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Trả lời";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // btnNewGame
            this.btnNewGame.Location = new System.Drawing.Point(500, 320);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(100, 35);
            this.btnNewGame.TabIndex = 6;
            this.btnNewGame.Text = "Chơi mới";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(30, 380);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(65, 20);
            this.lblScore.Text = "Điểm: 0";

            // lblHighScore
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Location = new System.Drawing.Point(30, 410);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(166, 20);
            this.lblHighScore.Text = "Kỷ lục: (chưa có dữ liệu)";

            // frmQuizGame
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 460);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbD);
            this.Controls.Add(this.rbC);
            this.Controls.Add(this.rbB);
            this.Controls.Add(this.rbA);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblSelectCategory);
            this.Controls.Add(this.cbCategory);
            this.Name = "frmQuizGame";
            this.Text = "Trò chơi Đố Vui Kiến Thức";
            this.Load += new System.EventHandler(this.frmQuizGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lblSelectCategory;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.RadioButton rbA;
        private System.Windows.Forms.RadioButton rbB;
        private System.Windows.Forms.RadioButton rbC;
        private System.Windows.Forms.RadioButton rbD;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblHighScore;
    }
}

