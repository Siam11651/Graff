
namespace Graff
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.canvas = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.textBox_expression = new System.Windows.Forms.TextBox();
            this.button_sketch = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.label_zoom_level = new System.Windows.Forms.Label();
            this.button_reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(300, 300);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint_canvas);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_canvas);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_canvas);
            this.canvas.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseWheel_canvas);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 324);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(30, 13);
            this.label.TabIndex = 1;
            this.label.Text = "f(x) =";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_expression
            // 
            this.textBox_expression.Location = new System.Drawing.Point(45, 321);
            this.textBox_expression.Name = "textBox_expression";
            this.textBox_expression.Size = new System.Drawing.Size(186, 20);
            this.textBox_expression.TabIndex = 2;
            // 
            // button_sketch
            // 
            this.button_sketch.Location = new System.Drawing.Point(237, 321);
            this.button_sketch.Name = "button_sketch";
            this.button_sketch.Size = new System.Drawing.Size(75, 23);
            this.button_sketch.TabIndex = 3;
            this.button_sketch.Text = "Sketch";
            this.button_sketch.UseVisualStyleBackColor = true;
            this.button_sketch.Click += new System.EventHandler(this.Click_button_sketch);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(321, 289);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 4;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.Click_button_clear);
            // 
            // label_zoom_level
            // 
            this.label_zoom_level.AutoSize = true;
            this.label_zoom_level.Location = new System.Drawing.Point(318, 12);
            this.label_zoom_level.Name = "label_zoom_level";
            this.label_zoom_level.Size = new System.Drawing.Size(33, 13);
            this.label_zoom_level.TabIndex = 8;
            this.label_zoom_level.Text = "1.00x";
            this.label_zoom_level.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(321, 260);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(75, 23);
            this.button_reset.TabIndex = 9;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.Click_button_reset);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 361);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.label_zoom_level);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_sketch);
            this.Controls.Add(this.textBox_expression);
            this.Controls.Add(this.label);
            this.Controls.Add(this.canvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Graff";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox_expression;
        private System.Windows.Forms.Button button_sketch;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label_zoom_level;
        private System.Windows.Forms.Button button_reset;
    }
}

