namespace RAGWinApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblQuestion;
        private TextBox txtQuestion;
        private Button btnAsk;
        private Label lblAnswer;
        private Panel panelTop;
        private Panel panelMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblTitle = new Label();
            panelMain = new Panel();
            lblQuestion = new Label();
            txtQuestion = new TextBox();
            btnAsk = new Button();
            lblAnswer = new Label();
            txtAnswer = new RichTextBox();
            panelTop.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(30, 30, 30);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(900, 60);
            panelTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(285, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Azure RAG Assistant";
            // 
            // panelMain
            // 
            panelMain.Controls.Add(txtAnswer);
            panelMain.Controls.Add(lblQuestion);
            panelMain.Controls.Add(txtQuestion);
            panelMain.Controls.Add(btnAsk);
            panelMain.Controls.Add(lblAnswer);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 60);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(900, 540);
            panelMain.TabIndex = 0;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(20, 20);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(143, 28);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Ask a question:";
            // 
            // txtQuestion
            // 
            txtQuestion.BorderStyle = BorderStyle.FixedSingle;
            txtQuestion.Location = new Point(20, 45);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(650, 80);
            txtQuestion.TabIndex = 1;
            // 
            // btnAsk
            // 
            btnAsk.BackColor = Color.FromArgb(0, 120, 215);
            btnAsk.Cursor = Cursors.Hand;
            btnAsk.FlatAppearance.BorderSize = 0;
            btnAsk.FlatStyle = FlatStyle.Flat;
            btnAsk.ForeColor = Color.White;
            btnAsk.Location = new Point(690, 45);
            btnAsk.Name = "btnAsk";
            btnAsk.Size = new Size(120, 40);
            btnAsk.TabIndex = 2;
            btnAsk.Text = "Ask";
            btnAsk.UseVisualStyleBackColor = false;
            btnAsk.Click += btnAsk_Click;
            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.Location = new Point(20, 150);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(79, 28);
            lblAnswer.TabIndex = 3;
            lblAnswer.Text = "Answer:";
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(20, 195);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(868, 333);
            txtAnswer.TabIndex = 5;
            txtAnswer.Text = "";
            // 
            // Form1
            // 
            BackColor = Color.White;
            ClientSize = new Size(900, 600);
            Controls.Add(panelMain);
            Controls.Add(panelTop);
            Font = new Font("Segoe UI", 10F);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RAG Assistant";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        private RichTextBox txtAnswer;
    }
}