﻿namespace CharEditor
{
    partial class SettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMSG = new System.Windows.Forms.TextBox();
            this.btnFMSG = new System.Windows.Forms.Button();
            this.btnFSystem = new System.Windows.Forms.Button();
            this.txtSystem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rCA = new System.Windows.Forms.RadioButton();
            this.rDE = new System.Windows.Forms.RadioButton();
            this.rEN = new System.Windows.Forms.RadioButton();
            this.rES = new System.Windows.Forms.RadioButton();
            this.rFR = new System.Windows.Forms.RadioButton();
            this.rIT = new System.Windows.Forms.RadioButton();
            this.rPL = new System.Windows.Forms.RadioButton();
            this.rRU = new System.Windows.Forms.RadioButton();
            this.rPT = new System.Windows.Forms.RadioButton();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSG Folder Path";
            // 
            // txtMSG
            // 
            this.txtMSG.Location = new System.Drawing.Point(12, 28);
            this.txtMSG.Name = "txtMSG";
            this.txtMSG.Size = new System.Drawing.Size(165, 20);
            this.txtMSG.TabIndex = 1;
            // 
            // btnFMSG
            // 
            this.btnFMSG.Location = new System.Drawing.Point(183, 28);
            this.btnFMSG.Name = "btnFMSG";
            this.btnFMSG.Size = new System.Drawing.Size(60, 20);
            this.btnFMSG.TabIndex = 2;
            this.btnFMSG.Text = "Find";
            this.btnFMSG.UseVisualStyleBackColor = true;
            this.btnFMSG.Click += new System.EventHandler(this.btnFMSG_Click);
            // 
            // btnFSystem
            // 
            this.btnFSystem.Location = new System.Drawing.Point(183, 67);
            this.btnFSystem.Name = "btnFSystem";
            this.btnFSystem.Size = new System.Drawing.Size(59, 20);
            this.btnFSystem.TabIndex = 5;
            this.btnFSystem.Text = "Find";
            this.btnFSystem.UseVisualStyleBackColor = true;
            this.btnFSystem.Click += new System.EventHandler(this.btnFSystem_Click);
            // 
            // txtSystem
            // 
            this.txtSystem.Location = new System.Drawing.Point(12, 67);
            this.txtSystem.Name = "txtSystem";
            this.txtSystem.Size = new System.Drawing.Size(165, 20);
            this.txtSystem.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "System Folder Path";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rRU);
            this.groupBox1.Controls.Add(this.rPT);
            this.groupBox1.Controls.Add(this.rPL);
            this.groupBox1.Controls.Add(this.rIT);
            this.groupBox1.Controls.Add(this.rFR);
            this.groupBox1.Controls.Add(this.rES);
            this.groupBox1.Controls.Add(this.rEN);
            this.groupBox1.Controls.Add(this.rDE);
            this.groupBox1.Controls.Add(this.rCA);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 75);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // rCA
            // 
            this.rCA.AutoSize = true;
            this.rCA.Location = new System.Drawing.Point(13, 19);
            this.rCA.Name = "rCA";
            this.rCA.Size = new System.Drawing.Size(37, 17);
            this.rCA.TabIndex = 0;
            this.rCA.TabStop = true;
            this.rCA.Text = "ca";
            this.rCA.UseVisualStyleBackColor = true;
            this.rCA.CheckedChanged += new System.EventHandler(this.rCA_CheckedChanged);
            // 
            // rDE
            // 
            this.rDE.AutoSize = true;
            this.rDE.Location = new System.Drawing.Point(61, 19);
            this.rDE.Name = "rDE";
            this.rDE.Size = new System.Drawing.Size(37, 17);
            this.rDE.TabIndex = 1;
            this.rDE.TabStop = true;
            this.rDE.Text = "de";
            this.rDE.UseVisualStyleBackColor = true;
            this.rDE.CheckedChanged += new System.EventHandler(this.rDE_CheckedChanged);
            // 
            // rEN
            // 
            this.rEN.AutoSize = true;
            this.rEN.Location = new System.Drawing.Point(104, 19);
            this.rEN.Name = "rEN";
            this.rEN.Size = new System.Drawing.Size(37, 17);
            this.rEN.TabIndex = 2;
            this.rEN.TabStop = true;
            this.rEN.Text = "en";
            this.rEN.UseVisualStyleBackColor = true;
            this.rEN.CheckedChanged += new System.EventHandler(this.rEN_CheckedChanged);
            // 
            // rES
            // 
            this.rES.AutoSize = true;
            this.rES.Location = new System.Drawing.Point(147, 19);
            this.rES.Name = "rES";
            this.rES.Size = new System.Drawing.Size(36, 17);
            this.rES.TabIndex = 3;
            this.rES.TabStop = true;
            this.rES.Text = "es";
            this.rES.UseVisualStyleBackColor = true;
            this.rES.CheckedChanged += new System.EventHandler(this.rES_CheckedChanged);
            // 
            // rFR
            // 
            this.rFR.AutoSize = true;
            this.rFR.Location = new System.Drawing.Point(189, 19);
            this.rFR.Name = "rFR";
            this.rFR.Size = new System.Drawing.Size(31, 17);
            this.rFR.TabIndex = 4;
            this.rFR.TabStop = true;
            this.rFR.Text = "fr";
            this.rFR.UseVisualStyleBackColor = true;
            this.rFR.CheckedChanged += new System.EventHandler(this.rFR_CheckedChanged);
            // 
            // rIT
            // 
            this.rIT.AutoSize = true;
            this.rIT.Location = new System.Drawing.Point(40, 42);
            this.rIT.Name = "rIT";
            this.rIT.Size = new System.Drawing.Size(30, 17);
            this.rIT.TabIndex = 5;
            this.rIT.TabStop = true;
            this.rIT.Text = "it";
            this.rIT.UseVisualStyleBackColor = true;
            this.rIT.CheckedChanged += new System.EventHandler(this.rIT_CheckedChanged);
            // 
            // rPL
            // 
            this.rPL.AutoSize = true;
            this.rPL.Location = new System.Drawing.Point(76, 42);
            this.rPL.Name = "rPL";
            this.rPL.Size = new System.Drawing.Size(33, 17);
            this.rPL.TabIndex = 6;
            this.rPL.TabStop = true;
            this.rPL.Text = "pl";
            this.rPL.UseVisualStyleBackColor = true;
            this.rPL.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // rRU
            // 
            this.rRU.AutoSize = true;
            this.rRU.Location = new System.Drawing.Point(153, 42);
            this.rRU.Name = "rRU";
            this.rRU.Size = new System.Drawing.Size(34, 17);
            this.rRU.TabIndex = 8;
            this.rRU.TabStop = true;
            this.rRU.Text = "ru";
            this.rRU.UseVisualStyleBackColor = true;
            this.rRU.CheckedChanged += new System.EventHandler(this.rRU_CheckedChanged);
            // 
            // rPT
            // 
            this.rPT.AutoSize = true;
            this.rPT.Location = new System.Drawing.Point(113, 42);
            this.rPT.Name = "rPT";
            this.rPT.Size = new System.Drawing.Size(34, 17);
            this.rPT.TabIndex = 7;
            this.rPT.TabStop = true;
            this.rPT.Text = "pt";
            this.rPT.UseVisualStyleBackColor = true;
            this.rPT.CheckedChanged += new System.EventHandler(this.rPT_CheckedChanged);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(63, 171);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(123, 23);
            this.btnSaveSettings.TabIndex = 7;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 202);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFSystem);
            this.Controls.Add(this.txtSystem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFMSG);
            this.Controls.Add(this.txtMSG);
            this.Controls.Add(this.label1);
            this.Name = "SettingForm";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMSG;
        private System.Windows.Forms.Button btnFMSG;
        private System.Windows.Forms.Button btnFSystem;
        private System.Windows.Forms.TextBox txtSystem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rPL;
        private System.Windows.Forms.RadioButton rIT;
        private System.Windows.Forms.RadioButton rFR;
        private System.Windows.Forms.RadioButton rES;
        private System.Windows.Forms.RadioButton rEN;
        private System.Windows.Forms.RadioButton rDE;
        private System.Windows.Forms.RadioButton rCA;
        private System.Windows.Forms.RadioButton rRU;
        private System.Windows.Forms.RadioButton rPT;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}