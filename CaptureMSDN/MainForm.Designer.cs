namespace CaptureMSDN
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SavePathText = new System.Windows.Forms.TextBox();
            this.UrllistBox = new System.Windows.Forms.ListBox();
            this.OptionTab = new System.Windows.Forms.TabControl();
            this.RulesTab = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.RulelistBox = new System.Windows.Forms.ListBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Config = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HttpGroupBox = new System.Windows.Forms.GroupBox();
            this.SeedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ReLinklabel = new System.Windows.Forms.Label();
            this.ReGetNumeric = new System.Windows.Forms.NumericUpDown();
            this.UrlBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.OptionTab.SuspendLayout();
            this.RulesTab.SuspendLayout();
            this.Config.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.HttpGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReGetNumeric)).BeginInit();
            this.UrlBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(841, 526);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(10, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(694, 178);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(23, 526);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "本地导入";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(347, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "选择目录";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SavePathText
            // 
            this.SavePathText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SavePathText.Location = new System.Drawing.Point(78, 24);
            this.SavePathText.Name = "SavePathText";
            this.SavePathText.Size = new System.Drawing.Size(263, 21);
            this.SavePathText.TabIndex = 4;
            // 
            // UrllistBox
            // 
            this.UrllistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UrllistBox.FormattingEnabled = true;
            this.UrllistBox.ItemHeight = 12;
            this.UrllistBox.Location = new System.Drawing.Point(6, 20);
            this.UrllistBox.Name = "UrllistBox";
            this.UrllistBox.Size = new System.Drawing.Size(186, 472);
            this.UrllistBox.TabIndex = 5;
            // 
            // OptionTab
            // 
            this.OptionTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionTab.Controls.Add(this.RulesTab);
            this.OptionTab.Controls.Add(this.Config);
            this.OptionTab.Location = new System.Drawing.Point(6, 20);
            this.OptionTab.Name = "OptionTab";
            this.OptionTab.SelectedIndex = 0;
            this.OptionTab.Size = new System.Drawing.Size(702, 261);
            this.OptionTab.TabIndex = 6;
            // 
            // RulesTab
            // 
            this.RulesTab.Controls.Add(this.button9);
            this.RulesTab.Controls.Add(this.RulelistBox);
            this.RulesTab.Controls.Add(this.button7);
            this.RulesTab.Controls.Add(this.button6);
            this.RulesTab.Controls.Add(this.button5);
            this.RulesTab.Location = new System.Drawing.Point(4, 22);
            this.RulesTab.Name = "RulesTab";
            this.RulesTab.Padding = new System.Windows.Forms.Padding(3);
            this.RulesTab.Size = new System.Drawing.Size(694, 235);
            this.RulesTab.TabIndex = 0;
            this.RulesTab.Text = "抓取规则";
            this.RulesTab.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(613, 96);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 5;
            this.button9.Text = "导入";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // RulelistBox
            // 
            this.RulelistBox.FormattingEnabled = true;
            this.RulelistBox.ItemHeight = 12;
            this.RulelistBox.Location = new System.Drawing.Point(8, 8);
            this.RulelistBox.Name = "RulelistBox";
            this.RulelistBox.Size = new System.Drawing.Size(590, 220);
            this.RulelistBox.TabIndex = 4;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(613, 66);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 3;
            this.button7.Text = "删除";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(613, 36);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "修改";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(613, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "新建";
            this.button5.UseMnemonic = false;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // Config
            // 
            this.Config.Controls.Add(this.button4);
            this.Config.Controls.Add(this.groupBox3);
            this.Config.Controls.Add(this.HttpGroupBox);
            this.Config.Location = new System.Drawing.Point(4, 22);
            this.Config.Name = "Config";
            this.Config.Padding = new System.Windows.Forms.Padding(3);
            this.Config.Size = new System.Drawing.Size(694, 235);
            this.Config.TabIndex = 1;
            this.Config.Text = "通用配置";
            this.Config.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(613, 206);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.SavePathText);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(242, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 187);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基础设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "保存路径：";
            // 
            // HttpGroupBox
            // 
            this.HttpGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.HttpGroupBox.Controls.Add(this.SeedNumeric);
            this.HttpGroupBox.Controls.Add(this.label1);
            this.HttpGroupBox.Controls.Add(this.ReLinklabel);
            this.HttpGroupBox.Controls.Add(this.ReGetNumeric);
            this.HttpGroupBox.Location = new System.Drawing.Point(6, 6);
            this.HttpGroupBox.Name = "HttpGroupBox";
            this.HttpGroupBox.Size = new System.Drawing.Size(230, 187);
            this.HttpGroupBox.TabIndex = 0;
            this.HttpGroupBox.TabStop = false;
            this.HttpGroupBox.Text = "网络设置";
            // 
            // SeedNumeric
            // 
            this.SeedNumeric.Location = new System.Drawing.Point(77, 63);
            this.SeedNumeric.Name = "SeedNumeric";
            this.SeedNumeric.Size = new System.Drawing.Size(94, 21);
            this.SeedNumeric.TabIndex = 0;
            this.SeedNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SeedNumeric.ValueChanged += new System.EventHandler(this.SeedNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "下载线程：";
            // 
            // ReLinklabel
            // 
            this.ReLinklabel.AutoSize = true;
            this.ReLinklabel.Location = new System.Drawing.Point(9, 28);
            this.ReLinklabel.Name = "ReLinklabel";
            this.ReLinklabel.Size = new System.Drawing.Size(65, 12);
            this.ReLinklabel.TabIndex = 1;
            this.ReLinklabel.Text = "重连次数：";
            // 
            // ReGetNumeric
            // 
            this.ReGetNumeric.Location = new System.Drawing.Point(77, 24);
            this.ReGetNumeric.Name = "ReGetNumeric";
            this.ReGetNumeric.Size = new System.Drawing.Size(94, 21);
            this.ReGetNumeric.TabIndex = 0;
            this.ReGetNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ReGetNumeric.ValueChanged += new System.EventHandler(this.ReGetNumeric_ValueChanged);
            // 
            // UrlBox
            // 
            this.UrlBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UrlBox.Controls.Add(this.UrllistBox);
            this.UrlBox.Location = new System.Drawing.Point(12, 12);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.Size = new System.Drawing.Size(200, 500);
            this.UrlBox.TabIndex = 7;
            this.UrlBox.TabStop = false;
            this.UrlBox.Text = "待抓网址";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.OptionTab);
            this.groupBox1.Location = new System.Drawing.Point(218, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 290);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(218, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 204);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日志";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(129, 526);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "抓取网址";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(749, 526);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 11;
            this.button10.Text = "暂停";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(655, 526);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 12;
            this.button11.Text = "取消";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UrlBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "网页抓取工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.OptionTab.ResumeLayout(false);
            this.RulesTab.ResumeLayout(false);
            this.Config.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.HttpGroupBox.ResumeLayout(false);
            this.HttpGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReGetNumeric)).EndInit();
            this.UrlBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox SavePathText;
        private System.Windows.Forms.ListBox UrllistBox;
        private System.Windows.Forms.TabControl OptionTab;
        private System.Windows.Forms.TabPage RulesTab;
        private System.Windows.Forms.GroupBox UrlBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage Config;
        private System.Windows.Forms.GroupBox HttpGroupBox;
        private System.Windows.Forms.Label ReLinklabel;
        private System.Windows.Forms.NumericUpDown ReGetNumeric;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown SeedNumeric;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox RulelistBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
    }
}

