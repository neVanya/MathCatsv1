
namespace MathCats
{
    partial class MathCats
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_integral = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_integral
            // 
            this.button_integral.BackColor = System.Drawing.Color.DarkOrange;
            this.button_integral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_integral.Font = new System.Drawing.Font("Microsoft Uighur", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_integral.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_integral.Location = new System.Drawing.Point(411, 0);
            this.button_integral.Name = "button_integral";
            this.button_integral.Size = new System.Drawing.Size(40, 40);
            this.button_integral.TabIndex = 0;
            this.button_integral.Text = "∫";
            this.button_integral.UseVisualStyleBackColor = false;
            this.button_integral.Click += new System.EventHandler(this.Button_integral_Click);
            this.button_integral.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.button_integral.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMoveInStartRectangle);
            this.button_integral.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkOrange;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(456, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "f(x)";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ButtonFunctionXYZ_Click);
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.button3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMoveInStartRectangle);
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkOrange;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(501, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "M";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.button4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMoveInStartRectangle);
            this.button4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkOrange;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(547, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 5;
            this.button5.Text = "GR";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.button5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMoveInStartRectangle);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // MathCats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(667, 618);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_integral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MathCats";
            this.Text = "MathCats";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MathCats_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MathCats_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_integral;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

