namespace CS5001_Data_Mining_Project
{
    partial class AprioriFRM
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
            this.fileDGV = new System.Windows.Forms.DataGridView();
            this.fileOFD = new System.Windows.Forms.OpenFileDialog();
            this.outputTB = new System.Windows.Forms.TextBox();
            this.clearBTN = new System.Windows.Forms.Button();
            this.submitBTN = new System.Windows.Forms.Button();
            this.maximumSizeTB = new System.Windows.Forms.TextBox();
            this.minimumCoverageTB = new System.Windows.Forms.TextBox();
            this.minimumAccuracyTB = new System.Windows.Forms.TextBox();
            this.bestRulesTB = new System.Windows.Forms.TextBox();
            this.bestRulesLBL = new System.Windows.Forms.Label();
            this.minimumAccuracyLBL = new System.Windows.Forms.Label();
            this.maximumSizeLBL = new System.Windows.Forms.Label();
            this.minimumCoverageLBL = new System.Windows.Forms.Label();
            this.browseBTN = new System.Windows.Forms.Button();
            this.fileTB = new System.Windows.Forms.TextBox();
            this.inputGB = new System.Windows.Forms.GroupBox();
            this.filePathLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileDGV)).BeginInit();
            this.inputGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileDGV
            // 
            this.fileDGV.AllowUserToOrderColumns = true;
            this.fileDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileDGV.Location = new System.Drawing.Point(547, 13);
            this.fileDGV.Name = "fileDGV";
            this.fileDGV.RowTemplate.Height = 23;
            this.fileDGV.Size = new System.Drawing.Size(436, 346);
            this.fileDGV.TabIndex = 7;
            // 
            // fileOFD
            // 
            this.fileOFD.FileName = "sample.arff";
            // 
            // outputTB
            // 
            this.outputTB.Location = new System.Drawing.Point(13, 115);
            this.outputTB.Multiline = true;
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            this.outputTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTB.Size = new System.Drawing.Size(527, 244);
            this.outputTB.TabIndex = 6;
            this.outputTB.TabStop = false;
            this.outputTB.WordWrap = false;
            // 
            // clearBTN
            // 
            this.clearBTN.Location = new System.Drawing.Point(436, 68);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(75, 23);
            this.clearBTN.TabIndex = 7;
            this.clearBTN.Text = "Clear";
            this.clearBTN.UseVisualStyleBackColor = true;
            // 
            // submitBTN
            // 
            this.submitBTN.Enabled = false;
            this.submitBTN.Location = new System.Drawing.Point(436, 40);
            this.submitBTN.Name = "submitBTN";
            this.submitBTN.Size = new System.Drawing.Size(75, 23);
            this.submitBTN.TabIndex = 6;
            this.submitBTN.Text = "Submit";
            this.submitBTN.UseVisualStyleBackColor = true;
            // 
            // maximumSizeTB
            // 
            this.maximumSizeTB.Location = new System.Drawing.Point(380, 42);
            this.maximumSizeTB.Name = "maximumSizeTB";
            this.maximumSizeTB.Size = new System.Drawing.Size(50, 21);
            this.maximumSizeTB.TabIndex = 3;
            // 
            // minimumCoverageTB
            // 
            this.minimumCoverageTB.Location = new System.Drawing.Point(130, 41);
            this.minimumCoverageTB.Name = "minimumCoverageTB";
            this.minimumCoverageTB.Size = new System.Drawing.Size(50, 21);
            this.minimumCoverageTB.TabIndex = 2;
            // 
            // minimumAccuracyTB
            // 
            this.minimumAccuracyTB.Location = new System.Drawing.Point(130, 69);
            this.minimumAccuracyTB.Name = "minimumAccuracyTB";
            this.minimumAccuracyTB.Size = new System.Drawing.Size(50, 21);
            this.minimumAccuracyTB.TabIndex = 4;
            // 
            // bestRulesTB
            // 
            this.bestRulesTB.Location = new System.Drawing.Point(295, 70);
            this.bestRulesTB.Name = "bestRulesTB";
            this.bestRulesTB.Size = new System.Drawing.Size(50, 21);
            this.bestRulesTB.TabIndex = 5;
            // 
            // bestRulesLBL
            // 
            this.bestRulesLBL.AutoSize = true;
            this.bestRulesLBL.Location = new System.Drawing.Point(213, 74);
            this.bestRulesLBL.Name = "bestRulesLBL";
            this.bestRulesLBL.Size = new System.Drawing.Size(167, 12);
            this.bestRulesLBL.TabIndex = 6;
            this.bestRulesLBL.Text = "Show the best         rules";
            // 
            // minimumAccuracyLBL
            // 
            this.minimumAccuracyLBL.AutoSize = true;
            this.minimumAccuracyLBL.Location = new System.Drawing.Point(17, 73);
            this.minimumAccuracyLBL.Name = "minimumAccuracyLBL";
            this.minimumAccuracyLBL.Size = new System.Drawing.Size(107, 12);
            this.minimumAccuracyLBL.TabIndex = 5;
            this.minimumAccuracyLBL.Text = "Minimum accuracy:";
            // 
            // maximumSizeLBL
            // 
            this.maximumSizeLBL.AutoSize = true;
            this.maximumSizeLBL.Location = new System.Drawing.Point(213, 46);
            this.maximumSizeLBL.Name = "maximumSizeLBL";
            this.maximumSizeLBL.Size = new System.Drawing.Size(161, 12);
            this.maximumSizeLBL.TabIndex = 4;
            this.maximumSizeLBL.Text = "Maximum size of item sets:";
            // 
            // minimumCoverageLBL
            // 
            this.minimumCoverageLBL.AutoSize = true;
            this.minimumCoverageLBL.Location = new System.Drawing.Point(17, 45);
            this.minimumCoverageLBL.Name = "minimumCoverageLBL";
            this.minimumCoverageLBL.Size = new System.Drawing.Size(107, 12);
            this.minimumCoverageLBL.TabIndex = 3;
            this.minimumCoverageLBL.Text = "Minimum coverage:";
            // 
            // browseBTN
            // 
            this.browseBTN.Location = new System.Drawing.Point(436, 12);
            this.browseBTN.Name = "browseBTN";
            this.browseBTN.Size = new System.Drawing.Size(75, 23);
            this.browseBTN.TabIndex = 1;
            this.browseBTN.Text = "Browse";
            this.browseBTN.UseVisualStyleBackColor = true;
            // 
            // fileTB
            // 
            this.fileTB.Location = new System.Drawing.Point(94, 13);
            this.fileTB.Name = "fileTB";
            this.fileTB.Size = new System.Drawing.Size(336, 21);
            this.fileTB.TabIndex = 1;
            this.fileTB.TabStop = false;
            // 
            // inputGB
            // 
            this.inputGB.Controls.Add(this.clearBTN);
            this.inputGB.Controls.Add(this.submitBTN);
            this.inputGB.Controls.Add(this.maximumSizeTB);
            this.inputGB.Controls.Add(this.minimumCoverageTB);
            this.inputGB.Controls.Add(this.minimumAccuracyTB);
            this.inputGB.Controls.Add(this.bestRulesTB);
            this.inputGB.Controls.Add(this.bestRulesLBL);
            this.inputGB.Controls.Add(this.minimumAccuracyLBL);
            this.inputGB.Controls.Add(this.maximumSizeLBL);
            this.inputGB.Controls.Add(this.minimumCoverageLBL);
            this.inputGB.Controls.Add(this.browseBTN);
            this.inputGB.Controls.Add(this.fileTB);
            this.inputGB.Controls.Add(this.filePathLBL);
            this.inputGB.Location = new System.Drawing.Point(12, 12);
            this.inputGB.Name = "inputGB";
            this.inputGB.Size = new System.Drawing.Size(528, 96);
            this.inputGB.TabIndex = 5;
            this.inputGB.TabStop = false;
            this.inputGB.Text = "Input";
            // 
            // filePathLBL
            // 
            this.filePathLBL.AutoSize = true;
            this.filePathLBL.Location = new System.Drawing.Point(17, 17);
            this.filePathLBL.Name = "filePathLBL";
            this.filePathLBL.Size = new System.Drawing.Size(71, 12);
            this.filePathLBL.TabIndex = 0;
            this.filePathLBL.Text = "Input File:";
            // 
            // AprioriFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 371);
            this.Controls.Add(this.fileDGV);
            this.Controls.Add(this.outputTB);
            this.Controls.Add(this.inputGB);
            this.Name = "AprioriFRM";
            this.Text = "Apriori";
            ((System.ComponentModel.ISupportInitialize)(this.fileDGV)).EndInit();
            this.inputGB.ResumeLayout(false);
            this.inputGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView fileDGV;
        private System.Windows.Forms.OpenFileDialog fileOFD;
        private System.Windows.Forms.TextBox outputTB;
        private System.Windows.Forms.Button clearBTN;
        private System.Windows.Forms.Button submitBTN;
        private System.Windows.Forms.TextBox maximumSizeTB;
        private System.Windows.Forms.TextBox minimumCoverageTB;
        private System.Windows.Forms.TextBox minimumAccuracyTB;
        private System.Windows.Forms.TextBox bestRulesTB;
        private System.Windows.Forms.Label bestRulesLBL;
        private System.Windows.Forms.Label minimumAccuracyLBL;
        private System.Windows.Forms.Label maximumSizeLBL;
        private System.Windows.Forms.Label minimumCoverageLBL;
        private System.Windows.Forms.Button browseBTN;
        private System.Windows.Forms.TextBox fileTB;
        private System.Windows.Forms.GroupBox inputGB;
        private System.Windows.Forms.Label filePathLBL;


    }
}

