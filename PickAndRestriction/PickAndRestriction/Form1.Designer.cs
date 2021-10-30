namespace PickAndRestriction
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblChoose = new System.Windows.Forms.Label();
            this.btnWater = new System.Windows.Forms.RadioButton();
            this.btnFire = new System.Windows.Forms.RadioButton();
            this.btnTree = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Location = new System.Drawing.Point(238, 138);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(97, 15);
            this.lblChoose.TabIndex = 0;
            this.lblChoose.Text = "選擇初始屬性";
            // 
            // btnWater
            // 
            this.btnWater.AutoSize = true;
            this.btnWater.Checked = true;
            this.btnWater.Location = new System.Drawing.Point(263, 180);
            this.btnWater.Name = "btnWater";
            this.btnWater.Size = new System.Drawing.Size(43, 19);
            this.btnWater.TabIndex = 1;
            this.btnWater.TabStop = true;
            this.btnWater.Text = "水";
            this.btnWater.UseVisualStyleBackColor = true;
            this.btnWater.CheckedChanged += new System.EventHandler(this.btnWater_CheckedChanged);
            // 
            // btnFire
            // 
            this.btnFire.AutoSize = true;
            this.btnFire.Location = new System.Drawing.Point(263, 217);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(43, 19);
            this.btnFire.TabIndex = 2;
            this.btnFire.Text = "火";
            this.btnFire.UseVisualStyleBackColor = true;
            this.btnFire.CheckedChanged += new System.EventHandler(this.btnFire_CheckedChanged);
            // 
            // btnTree
            // 
            this.btnTree.AutoSize = true;
            this.btnTree.Location = new System.Drawing.Point(263, 258);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(43, 19);
            this.btnTree.TabIndex = 3;
            this.btnTree.Text = "木";
            this.btnTree.UseVisualStyleBackColor = true;
            this.btnTree.CheckedChanged += new System.EventHandler(this.btnTree_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(251, 297);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 37);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "開始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 458);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnTree);
            this.Controls.Add(this.btnFire);
            this.Controls.Add(this.btnWater);
            this.Controls.Add(this.lblChoose);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.RadioButton btnWater;
        private System.Windows.Forms.RadioButton btnFire;
        private System.Windows.Forms.RadioButton btnTree;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
    }
}

