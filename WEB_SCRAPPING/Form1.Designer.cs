namespace WEB_SCRAPPING
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
            progressBar = new ProgressBar();
            dataGridView = new DataGridView();
            ExportBtn = new Button();
            ScrapBtn = new Button();
            comboBoxTeams = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 102);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(915, 36);
            progressBar.TabIndex = 11;
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.Location = new Point(0, 157);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(949, 380);
            dataGridView.TabIndex = 10;
            // 
            // ExportBtn
            // 
            ExportBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ExportBtn.Location = new Point(678, 49);
            ExportBtn.Name = "ExportBtn";
            ExportBtn.Size = new Size(249, 36);
            ExportBtn.TabIndex = 9;
            ExportBtn.Text = "EXPORT TO EXCEL";
            ExportBtn.UseVisualStyleBackColor = true;
            ExportBtn.Click += ExportBtn_Click;
            // 
            // ScrapBtn
            // 
            ScrapBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ScrapBtn.Location = new Point(424, 49);
            ScrapBtn.Name = "ScrapBtn";
            ScrapBtn.Size = new Size(248, 36);
            ScrapBtn.TabIndex = 8;
            ScrapBtn.Text = "SCRAP";
            ScrapBtn.UseVisualStyleBackColor = true;
            ScrapBtn.Click += ScrapBtn_Click;
            // 
            // comboBoxTeams
            // 
            comboBoxTeams.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            comboBoxTeams.FormattingEnabled = true;
            comboBoxTeams.Location = new Point(12, 45);
            comboBoxTeams.Name = "comboBoxTeams";
            comboBoxTeams.Size = new Size(381, 36);
            comboBoxTeams.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 4);
            label1.Name = "label1";
            label1.Size = new Size(159, 31);
            label1.TabIndex = 6;
            label1.Text = "SELECT TEAM";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 537);
            Controls.Add(progressBar);
            Controls.Add(dataGridView);
            Controls.Add(ExportBtn);
            Controls.Add(ScrapBtn);
            Controls.Add(comboBoxTeams);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar;
        private DataGridView dataGridView;
        private Button ExportBtn;
        private Button ScrapBtn;
        private ComboBox comboBoxTeams;
        private Label label1;
    }
}