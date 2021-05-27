
namespace Graff
{
    partial class form_main
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.textBox_expression = new System.Windows.Forms.TextBox();
            this.button_sketch = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.groupBox_transform = new System.Windows.Forms.GroupBox();
            this.button_up = new System.Windows.Forms.Button();
            this.button_down = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.button_left = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.groupBox_transform.SuspendLayout();
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
            this.button_clear.Location = new System.Drawing.Point(497, 12);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 4;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.Click_button_clear);
            // 
            // groupBox_transform
            // 
            this.groupBox_transform.Controls.Add(this.button_left);
            this.groupBox_transform.Controls.Add(this.button_right);
            this.groupBox_transform.Controls.Add(this.button_down);
            this.groupBox_transform.Controls.Add(this.button_up);
            this.groupBox_transform.Location = new System.Drawing.Point(372, 42);
            this.groupBox_transform.Name = "groupBox_transform";
            this.groupBox_transform.Size = new System.Drawing.Size(200, 100);
            this.groupBox_transform.TabIndex = 5;
            this.groupBox_transform.TabStop = false;
            this.groupBox_transform.Text = "Transform";
            // 
            // button_up
            // 
            this.button_up.Location = new System.Drawing.Point(62, 19);
            this.button_up.Name = "button_up";
            this.button_up.Size = new System.Drawing.Size(75, 23);
            this.button_up.TabIndex = 0;
            this.button_up.Text = "Up";
            this.button_up.UseVisualStyleBackColor = true;
            this.button_up.Click += new System.EventHandler(this.Click_button_up);
            // 
            // button_down
            // 
            this.button_down.Location = new System.Drawing.Point(62, 71);
            this.button_down.Name = "button_down";
            this.button_down.Size = new System.Drawing.Size(75, 23);
            this.button_down.TabIndex = 1;
            this.button_down.Text = "Down";
            this.button_down.UseVisualStyleBackColor = true;
            this.button_down.Click += new System.EventHandler(this.Click_button_down);
            // 
            // button_right
            // 
            this.button_right.Location = new System.Drawing.Point(120, 45);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(75, 23);
            this.button_right.TabIndex = 2;
            this.button_right.Text = "Right";
            this.button_right.UseVisualStyleBackColor = true;
            this.button_right.Click += new System.EventHandler(this.Click_button_right);
            // 
            // button_left
            // 
            this.button_left.Location = new System.Drawing.Point(6, 45);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(75, 23);
            this.button_left.TabIndex = 3;
            this.button_left.Text = "Left";
            this.button_left.UseVisualStyleBackColor = true;
            this.button_left.Click += new System.EventHandler(this.Click_button_left);
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.groupBox_transform);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_sketch);
            this.Controls.Add(this.textBox_expression);
            this.Controls.Add(this.label);
            this.Controls.Add(this.canvas);
            this.MaximizeBox = false;
            this.Name = "form_main";
            this.Text = "Graff";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.groupBox_transform.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox_expression;
        private System.Windows.Forms.Button button_sketch;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.GroupBox groupBox_transform;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Button button_down;
        private System.Windows.Forms.Button button_up;
    }
}

