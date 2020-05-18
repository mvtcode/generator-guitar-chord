namespace GenChord
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
            this.List_Input = new System.Windows.Forms.ListBox();
            this.BT_OpenList = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BT_Save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BT_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // List_Input
            // 
            this.List_Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List_Input.FormattingEnabled = true;
            this.List_Input.Location = new System.Drawing.Point(12, 12);
            this.List_Input.Name = "List_Input";
            this.List_Input.Size = new System.Drawing.Size(374, 199);
            this.List_Input.TabIndex = 0;
            this.List_Input.SelectedIndexChanged += new System.EventHandler(this.List_Input_SelectedIndexChanged);
            // 
            // BT_OpenList
            // 
            this.BT_OpenList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_OpenList.Location = new System.Drawing.Point(67, 217);
            this.BT_OpenList.Name = "BT_OpenList";
            this.BT_OpenList.Size = new System.Drawing.Size(75, 23);
            this.BT_OpenList.TabIndex = 1;
            this.BT_OpenList.Text = "Add";
            this.BT_OpenList.UseVisualStyleBackColor = true;
            this.BT_OpenList.Click += new System.EventHandler(this.BT_OpenList_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 257);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(374, 218);
            this.textBox1.TabIndex = 3;
            // 
            // BT_Save
            // 
            this.BT_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Save.Location = new System.Drawing.Point(311, 217);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(75, 23);
            this.BT_Save.TabIndex = 4;
            this.BT_Save.Text = "Save";
            this.BT_Save.UseVisualStyleBackColor = true;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(229, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BT_Clear
            // 
            this.BT_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Clear.Location = new System.Drawing.Point(148, 217);
            this.BT_Clear.Name = "BT_Clear";
            this.BT_Clear.Size = new System.Drawing.Size(75, 23);
            this.BT_Clear.TabIndex = 6;
            this.BT_Clear.Text = "Clear";
            this.BT_Clear.UseVisualStyleBackColor = true;
            this.BT_Clear.Click += new System.EventHandler(this.BT_Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 487);
            this.Controls.Add(this.BT_Clear);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BT_Save);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BT_OpenList);
            this.Controls.Add(this.List_Input);
            this.Name = "Form1";
            this.Text = "Gen Guitar Chord code by MVT. Email: macvantan@gmail.com";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox List_Input;
        private System.Windows.Forms.Button BT_OpenList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BT_Save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BT_Clear;
    }
}

