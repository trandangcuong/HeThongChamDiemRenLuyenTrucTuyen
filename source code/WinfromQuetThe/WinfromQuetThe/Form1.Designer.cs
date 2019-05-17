namespace WinfromQuetThe
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txttag = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtstudname = new System.Windows.Forms.TextBox();
            this.txtrollno = new System.Windows.Forms.TextBox();
            this.comboclass = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_rfid_code = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Thoat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_tensk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_diem = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txttag
            // 
            this.txttag.Location = new System.Drawing.Point(191, 80);
            this.txttag.MaxLength = 5;
            this.txttag.Name = "txttag";
            this.txttag.Size = new System.Drawing.Size(191, 20);
            this.txttag.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(438, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã Sự kiện";
            // 
            // txtstudname
            // 
            this.txtstudname.Location = new System.Drawing.Point(191, 118);
            this.txtstudname.Name = "txtstudname";
            this.txtstudname.Size = new System.Drawing.Size(191, 20);
            this.txtstudname.TabIndex = 6;
            // 
            // txtrollno
            // 
            this.txtrollno.Location = new System.Drawing.Point(191, 155);
            this.txtrollno.Name = "txtrollno";
            this.txtrollno.Size = new System.Drawing.Size(191, 20);
            this.txtrollno.TabIndex = 7;
            // 
            // comboclass
            // 
            this.comboclass.FormattingEnabled = true;
            this.comboclass.Location = new System.Drawing.Point(530, 73);
            this.comboclass.Name = "comboclass";
            this.comboclass.Size = new System.Drawing.Size(191, 21);
            this.comboclass.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_rfid_code
            // 
            this.txt_rfid_code.Location = new System.Drawing.Point(0, 386);
            this.txt_rfid_code.MaxLength = 5;
            this.txt_rfid_code.Name = "txt_rfid_code";
            this.txt_rfid_code.Size = new System.Drawing.Size(10, 20);
            this.txt_rfid_code.TabIndex = 12;
            this.txt_rfid_code.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_diem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_tensk);
            this.groupBox1.Controls.Add(this.Thoat);
            this.groupBox1.Controls.Add(this.txt_rfid_code);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtrollno);
            this.groupBox1.Controls.Add(this.comboclass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtstudname);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txttag);
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 306);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            // 
            // Thoat
            // 
            this.Thoat.BackColor = System.Drawing.Color.Transparent;
            this.Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thoat.ForeColor = System.Drawing.Color.Red;
            this.Thoat.Location = new System.Drawing.Point(659, 255);
            this.Thoat.Name = "Thoat";
            this.Thoat.Size = new System.Drawing.Size(62, 29);
            this.Thoat.TabIndex = 205;
            this.Thoat.Text = "Thoát";
            this.Thoat.UseVisualStyleBackColor = false;
            this.Thoat.Click += new System.EventHandler(this.Thoat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(76, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 201;
            this.label6.Text = "Lớp:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(76, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 17);
            this.label7.TabIndex = 200;
            this.label7.Text = "Tên Sinh Viên:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(76, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 17);
            this.label8.TabIndex = 199;
            this.label8.Text = "Mã Sinh Viên :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(281, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(195, 24);
            this.label12.TabIndex = 198;
            this.label12.Text = "THAM GIA SỰ KIỆN";
            // 
            // txt_tensk
            // 
            this.txt_tensk.Location = new System.Drawing.Point(530, 115);
            this.txt_tensk.Name = "txt_tensk";
            this.txt_tensk.Size = new System.Drawing.Size(191, 20);
            this.txt_tensk.TabIndex = 206;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(438, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 207;
            this.label1.Text = "Tên Sự Kiện";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(438, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 209;
            this.label2.Text = "Điểm";
            // 
            // txt_diem
            // 
            this.txt_diem.Location = new System.Drawing.Point(530, 155);
            this.txt_diem.Name = "txt_diem";
            this.txt_diem.Size = new System.Drawing.Size(191, 20);
            this.txt_diem.TabIndex = 208;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 312);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txttag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtstudname;
        private System.Windows.Forms.TextBox txtrollno;
        private System.Windows.Forms.ComboBox comboclass;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_rfid_code;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Thoat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_diem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tensk;
    }
}

