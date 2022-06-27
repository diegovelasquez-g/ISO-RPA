
namespace RPA_Coco.Forms
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.TitleBar = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnMaintenance = new System.Windows.Forms.PictureBox();
            this.pgb = new System.Windows.Forms.ProgressBar();
            this.rtxtSteps = new System.Windows.Forms.RichTextBox();
            this.bgwVariables = new System.ComponentModel.BackgroundWorker();
            this.bgwDirectories = new System.ComponentModel.BackgroundWorker();
            this.bgwEmail = new System.ComponentModel.BackgroundWorker();
            this.btnRestart = new System.Windows.Forms.PictureBox();
            this.bgwCopyFile = new System.ComponentModel.BackgroundWorker();
            this.bgwCocoReport = new System.ComponentModel.BackgroundWorker();
            this.bgwTemplate = new System.ComponentModel.BackgroundWorker();
            this.bgwCopyCocoReport = new System.ComponentModel.BackgroundWorker();
            this.bgwPasteDataTemplate = new System.ComponentModel.BackgroundWorker();
            this.bgwWorkTemplate = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartProcess = new System.Windows.Forms.PictureBox();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.panelWelcome = new System.Windows.Forms.Panel();
            this.TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaintenance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartProcess)).BeginInit();
            this.panelWelcome.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(191)))), ((int)(((byte)(159)))));
            this.TitleBar.Controls.Add(this.btnClose);
            this.TitleBar.Controls.Add(this.lbTitle);
            this.TitleBar.Controls.Add(this.btnMaintenance);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(646, 36);
            this.TitleBar.TabIndex = 0;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
            this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            this.TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(617, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(33, 8);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(130, 18);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "RPA - Reportes";
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.BackgroundImage = global::RPA_Coco.Properties.Resources.Engranaje;
            this.btnMaintenance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintenance.Location = new System.Drawing.Point(583, 5);
            this.btnMaintenance.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(27, 26);
            this.btnMaintenance.TabIndex = 1;
            this.btnMaintenance.TabStop = false;
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // pgb
            // 
            this.pgb.BackColor = System.Drawing.Color.Black;
            this.pgb.Location = new System.Drawing.Point(30, 48);
            this.pgb.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(585, 19);
            this.pgb.TabIndex = 1;
            // 
            // rtxtSteps
            // 
            this.rtxtSteps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(137)))), ((int)(((byte)(202)))));
            this.rtxtSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.rtxtSteps.ForeColor = System.Drawing.Color.White;
            this.rtxtSteps.Location = new System.Drawing.Point(30, 81);
            this.rtxtSteps.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.rtxtSteps.Name = "rtxtSteps";
            this.rtxtSteps.ReadOnly = true;
            this.rtxtSteps.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtSteps.Size = new System.Drawing.Size(587, 235);
            this.rtxtSteps.TabIndex = 2;
            this.rtxtSteps.Text = "";
            // 
            // bgwVariables
            // 
            this.bgwVariables.WorkerReportsProgress = true;
            this.bgwVariables.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwVariables_DoWork);
            this.bgwVariables.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwVariables_ProgressChanged);
            this.bgwVariables.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwVariables_RunWorkerCompleted);
            // 
            // bgwDirectories
            // 
            this.bgwDirectories.WorkerReportsProgress = true;
            this.bgwDirectories.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDirectories_DoWork);
            this.bgwDirectories.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDirectories_ProgressChanged);
            this.bgwDirectories.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDirectories_RunWorkerCompleted);
            // 
            // bgwEmail
            // 
            this.bgwEmail.WorkerReportsProgress = true;
            this.bgwEmail.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwEmail_DoWork);
            this.bgwEmail.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwEmail_ProgressChanged);
            this.bgwEmail.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwEmail_RunWorkerCompleted);
            // 
            // btnRestart
            // 
            this.btnRestart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRestart.BackgroundImage")));
            this.btnRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.Location = new System.Drawing.Point(465, 331);
            this.btnRestart.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(150, 40);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.TabStop = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // bgwCopyFile
            // 
            this.bgwCopyFile.WorkerReportsProgress = true;
            this.bgwCopyFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCopyFile_DoWork);
            this.bgwCopyFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCopyFile_ProgressChanged);
            this.bgwCopyFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCopyFile_RunWorkerCompleted);
            // 
            // bgwCocoReport
            // 
            this.bgwCocoReport.WorkerReportsProgress = true;
            this.bgwCocoReport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCocoReport_DoWork);
            this.bgwCocoReport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCocoReport_ProgressChanged);
            this.bgwCocoReport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCocoReport_RunWorkerCompleted);
            // 
            // bgwTemplate
            // 
            this.bgwTemplate.WorkerReportsProgress = true;
            this.bgwTemplate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTemplate_DoWork);
            this.bgwTemplate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwTemplate_ProgressChanged);
            this.bgwTemplate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTemplate_RunWorkerCompleted);
            // 
            // bgwCopyCocoReport
            // 
            this.bgwCopyCocoReport.WorkerReportsProgress = true;
            this.bgwCopyCocoReport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCopyCocoReport_DoWork);
            this.bgwCopyCocoReport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCopyCocoReport_ProgressChanged);
            this.bgwCopyCocoReport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCopyCocoReport_RunWorkerCompleted);
            // 
            // bgwPasteDataTemplate
            // 
            this.bgwPasteDataTemplate.WorkerReportsProgress = true;
            this.bgwPasteDataTemplate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPasteDataTemplate_DoWork);
            this.bgwPasteDataTemplate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwPasteDataTemplate_ProgressChanged);
            this.bgwPasteDataTemplate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwPasteDataTemplate_RunWorkerCompleted);
            // 
            // bgwWorkTemplate
            // 
            this.bgwWorkTemplate.WorkerReportsProgress = true;
            this.bgwWorkTemplate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwWorkTemplate_DoWork);
            this.bgwWorkTemplate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwWorkTemplate_ProgressChanged);
            this.bgwWorkTemplate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwWorkTemplate_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(191)))), ((int)(((byte)(159)))));
            this.label1.Location = new System.Drawing.Point(183, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido 😃";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(191)))), ((int)(((byte)(159)))));
            this.label2.Location = new System.Drawing.Point(201, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Robotic Process Automation";
            // 
            // btnStartProcess
            // 
            this.btnStartProcess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStartProcess.BackgroundImage")));
            this.btnStartProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartProcess.Location = new System.Drawing.Point(255, 188);
            this.btnStartProcess.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnStartProcess.Name = "btnStartProcess";
            this.btnStartProcess.Size = new System.Drawing.Size(135, 40);
            this.btnStartProcess.TabIndex = 3;
            this.btnStartProcess.TabStop = false;
            this.btnStartProcess.Click += new System.EventHandler(this.btnStartProcess_Click);
            // 
            // lbCopyright
            // 
            this.lbCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbCopyright.Location = new System.Drawing.Point(545, 324);
            this.lbCopyright.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(90, 13);
            this.lbCopyright.TabIndex = 4;
            this.lbCopyright.Text = "Copyright © 2022";
            // 
            // panelWelcome
            // 
            this.panelWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.panelWelcome.Controls.Add(this.lbCopyright);
            this.panelWelcome.Controls.Add(this.btnStartProcess);
            this.panelWelcome.Controls.Add(this.label2);
            this.panelWelcome.Controls.Add(this.label1);
            this.panelWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWelcome.Location = new System.Drawing.Point(0, 36);
            this.panelWelcome.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panelWelcome.Name = "panelWelcome";
            this.panelWelcome.Size = new System.Drawing.Size(646, 346);
            this.panelWelcome.TabIndex = 4;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 382);
            this.Controls.Add(this.panelWelcome);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.rtxtSteps);
            this.Controls.Add(this.pgb);
            this.Controls.Add(this.TitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Shown += new System.EventHandler(this.Home_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Home_Paint);
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaintenance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartProcess)).EndInit();
            this.panelWelcome.ResumeLayout(false);
            this.panelWelcome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox btnMaintenance;
        private System.Windows.Forms.ProgressBar pgb;
        private System.Windows.Forms.RichTextBox rtxtSteps;
        private System.Windows.Forms.PictureBox btnRestart;
        private System.ComponentModel.BackgroundWorker bgwVariables;
        private System.ComponentModel.BackgroundWorker bgwDirectories;
        private System.ComponentModel.BackgroundWorker bgwEmail;
        private System.ComponentModel.BackgroundWorker bgwCopyFile;
        private System.ComponentModel.BackgroundWorker bgwCocoReport;
        private System.ComponentModel.BackgroundWorker bgwTemplate;
        private System.ComponentModel.BackgroundWorker bgwCopyCocoReport;
        private System.ComponentModel.BackgroundWorker bgwPasteDataTemplate;
        private System.ComponentModel.BackgroundWorker bgwWorkTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnStartProcess;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Panel panelWelcome;
    }
}