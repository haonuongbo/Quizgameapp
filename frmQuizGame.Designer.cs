using System.Drawing;
using System.Windows.Forms;

namespace Đồ_án_ứng_dụng
{
    partial class frmQuizGame
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cbCategory = new ComboBox();
            this.lblSelectCategory = new Label();
            this.lblQuestion = new Label();
            this.btnA = new Button();
            this.btnB = new Button();
            this.btnC = new Button();
            this.btnD = new Button();
            this.btnNewGame = new Button();
            this.btnBack = new Button();
            this.lblScore = new Label();
            this.lblHighScore = new Label();
            this.menuStrip1 = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.newGameToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.aboutToolStripMenuItem = new ToolStripMenuItem();

            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // cbCategory
            this.cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbCategory.Location = new Point(299, 415);
            this.cbCategory.Size = new Size(180, 21);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.Anchor = AnchorStyles.Bottom;

            // lblSelectCategory
            this.lblSelectCategory.AutoSize = true;
            this.lblSelectCategory.Location = new Point(355, 399);
            this.lblSelectCategory.Size = new Size(72, 13);
            this.lblSelectCategory.Text = "Chọn chủ đề:";
            this.lblSelectCategory.Anchor = AnchorStyles.Bottom;

            // lblQuestion
            this.lblQuestion.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblQuestion.Location = new Point(22, 50);
            this.lblQuestion.Size = new Size(700, 80);
            this.lblQuestion.Text = "Câu hỏi sẽ hiển thị ở đây";
            this.lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
            this.lblQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.lblQuestion.Click += new System.EventHandler(this.lblQuestion_Click);

            // btnA
            this.btnA.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnA.Location = new Point(50, 150);
            this.btnA.Size = new Size(315, 108);
            this.btnA.Text = "Đáp án A";
            this.btnA.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.btnA.Click += new System.EventHandler(this.AnswerButton_Click);

            // btnB
            this.btnB.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnB.Location = new Point(409, 150);
            this.btnB.Size = new Size(313, 108);
            this.btnB.Text = "Đáp án B";
            this.btnB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.btnB.Click += new System.EventHandler(this.AnswerButton_Click);

            // btnC
            this.btnC.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnC.Location = new Point(50, 277);
            this.btnC.Size = new Size(315, 103);
            this.btnC.Text = "Đáp án C";
            this.btnC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.btnC.Click += new System.EventHandler(this.AnswerButton_Click);

            // btnD
            this.btnD.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnD.Location = new Point(409, 277);
            this.btnD.Size = new Size(313, 103);
            this.btnD.Text = "Đáp án D";
            this.btnD.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.btnD.Click += new System.EventHandler(this.AnswerButton_Click);

            // btnNewGame
            this.btnNewGame.Location = new Point(332, 450);
            this.btnNewGame.Size = new Size(112, 30);
            this.btnNewGame.Text = "Chơi mới";
            this.btnNewGame.Anchor = AnchorStyles.Bottom;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);

            // btnBack
            this.btnBack.Location = new Point(640, 450);
            this.btnBack.Size = new Size(75, 30);
            this.btnBack.Text = "⬅ Trở về";
            this.btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblScore.Location = new Point(50, 450);
            this.lblScore.Text = "Điểm: 0";
            this.lblScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            // lblHighScore
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Location = new Point(50, 480);
            this.lblHighScore.Text = "Kỷ lục: (chưa có dữ liệu)";
            this.lblHighScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.lblHighScore.Click += new System.EventHandler(this.lblHighScore_Click);

            // menuStrip1
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
                this.fileToolStripMenuItem, this.helpToolStripMenuItem
            });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Size = new Size(750, 24);

            // fileToolStripMenuItem
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.newGameToolStripMenuItem, this.exitToolStripMenuItem
            });
            this.fileToolStripMenuItem.Text = "File";

            // newGameToolStripMenuItem
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.btnNewGame_Click);

            // exitToolStripMenuItem
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);

            // helpToolStripMenuItem
            this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.aboutToolStripMenuItem
            });
            this.helpToolStripMenuItem.Text = "Help";

            // aboutToolStripMenuItem
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);

            // frmQuizGame
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(750, 520);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblSelectCategory);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnBack);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmQuizGame";
            this.Text = "Trò chơi Đố Vui Kiến Thức";
            this.Load += new System.EventHandler(this.frmQuizGame_Load);
            this.Resize += new System.EventHandler(this.frmQuizGame_Resize);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private ComboBox cbCategory;
        private Label lblSelectCategory;
        private Label lblQuestion;
        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
        private Button btnNewGame;
        private Label lblScore;
        private Label lblHighScore;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button btnBack;
    }
}
