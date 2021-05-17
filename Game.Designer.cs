
namespace MazeSolverQLearning
{
    partial class Game
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(7, 5);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(822, 796);
            this.pnlBoard.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(834, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 796);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Başlat ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.startTimer);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Engelleri Tekrar Oluştur";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // moveTimer
            // 
            this.moveTimer.Interval = 10;
            this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 796);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze Solver";
            this.Load += new System.EventHandler(this.Game_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer moveTimer;
    }
}