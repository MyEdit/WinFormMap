namespace WinFormMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBoxMap = new PictureBox();
            updateTimer = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMap).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxMap
            // 
            pictureBoxMap.Image = (Image)resources.GetObject("pictureBoxMap.Image");
            pictureBoxMap.Location = new Point(12, 12);
            pictureBoxMap.Name = "pictureBoxMap";
            pictureBoxMap.Size = new Size(1468, 509);
            pictureBoxMap.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMap.TabIndex = 0;
            pictureBoxMap.TabStop = false;
            pictureBoxMap.MouseClick += pictureBoxMap_MouseClick;
            // 
            // updateTimer
            // 
            updateTimer.Enabled = true;
            updateTimer.Interval = 3000;
            updateTimer.Tick += UpdateTimer_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(711, 578);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1492, 627);
            Controls.Add(button1);
            Controls.Add(pictureBoxMap);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxMap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxMap;
        private System.Windows.Forms.Timer updateTimer;
        private Button button1;
    }
}
