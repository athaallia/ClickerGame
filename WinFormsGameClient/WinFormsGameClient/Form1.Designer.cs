namespace WinFormsGameClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblTime = new Label();
            lblScore = new Label();
            txtPlayerName = new TextBox();
            btnStart = new Button();
            btnClick = new Button();
            btnSubmit = new Button();
            btnRefresh = new Button();
            numTop = new NumericUpDown();
            gridLeaderboard = new DataGridView();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)numTop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridLeaderboard).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(143, 36);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(265, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MiniClickerGame";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(433, 120);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(77, 25);
            lblTime.TabIndex = 1;
            lblTime.Text = "Time: 0s";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(43, 162);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(75, 25);
            lblScore.TabIndex = 2;
            lblScore.Text = "Score: 0";
            // 
            // txtPlayerName
            // 
            txtPlayerName.Location = new Point(43, 114);
            txtPlayerName.Name = "txtPlayerName";
            txtPlayerName.Size = new Size(254, 31);
            txtPlayerName.TabIndex = 3;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(306, 114);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 34);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start (10s)";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnClick
            // 
            btnClick.Location = new Point(210, 157);
            btnClick.Name = "btnClick";
            btnClick.Size = new Size(208, 34);
            btnClick.TabIndex = 5;
            btnClick.Text = "CLICK!";
            btnClick.UseVisualStyleBackColor = true;
            btnClick.Click += btnClick_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(41, 205);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(154, 34);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Submit Score";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(210, 205);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(208, 34);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh Leaderboard";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // numTop
            // 
            numTop.Location = new Point(434, 205);
            numTop.Name = "numTop";
            numTop.Size = new Size(76, 31);
            numTop.TabIndex = 8;
            numTop.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // gridLeaderboard
            // 
            gridLeaderboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridLeaderboard.Location = new Point(41, 257);
            gridLeaderboard.Name = "gridLeaderboard";
            gridLeaderboard.RowHeadersWidth = 62;
            gridLeaderboard.Size = new Size(469, 352);
            gridLeaderboard.TabIndex = 9;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 643);
            Controls.Add(gridLeaderboard);
            Controls.Add(numTop);
            Controls.Add(btnRefresh);
            Controls.Add(btnSubmit);
            Controls.Add(btnClick);
            Controls.Add(btnStart);
            Controls.Add(txtPlayerName);
            Controls.Add(lblScore);
            Controls.Add(lblTime);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numTop).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridLeaderboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTime;
        private Label lblScore;
        private TextBox txtPlayerName;
        private Button btnStart;
        private Button btnClick;
        private Button btnSubmit;
        private Button btnRefresh;
        private NumericUpDown numTop;
        private DataGridView gridLeaderboard;
        private System.Windows.Forms.Timer gameTimer;
    }
}
