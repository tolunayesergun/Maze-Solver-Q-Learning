﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAreaSize = new System.Windows.Forms.Label();
            this.areaSizeTrack = new System.Windows.Forms.TrackBar();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaSizeTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBoard.Location = new System.Drawing.Point(2, 52);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(931, 810);
            this.pnlBoard.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAreaSize);
            this.panel1.Controls.Add(this.areaSizeTrack);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 48);
            this.panel1.TabIndex = 1;
            // 
            // lblAreaSize
            // 
            this.lblAreaSize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAreaSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAreaSize.Location = new System.Drawing.Point(500, 27);
            this.lblAreaSize.Name = "lblAreaSize";
            this.lblAreaSize.Size = new System.Drawing.Size(415, 21);
            this.lblAreaSize.TabIndex = 4;
            this.lblAreaSize.Text = "25 x 25";
            this.lblAreaSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // areaSizeTrack
            // 
            this.areaSizeTrack.Dock = System.Windows.Forms.DockStyle.Top;
            this.areaSizeTrack.Location = new System.Drawing.Point(500, 0);
            this.areaSizeTrack.Maximum = 40;
            this.areaSizeTrack.Name = "areaSizeTrack";
            this.areaSizeTrack.Size = new System.Drawing.Size(415, 45);
            this.areaSizeTrack.TabIndex = 3;
            this.areaSizeTrack.Value = 15;
            this.areaSizeTrack.Scroll += new System.EventHandler(this.areaSizeTrack_Scroll);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Location = new System.Drawing.Point(375, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 48);
            this.button4.TabIndex = 3;
            this.button4.Text = "Tekrar Harita Oluştur";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btnRestart);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.Location = new System.Drawing.Point(250, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 48);
            this.button5.TabIndex = 4;
            this.button5.Text = "Sonuç";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Location = new System.Drawing.Point(125, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 48);
            this.button3.TabIndex = 2;
            this.button3.Text = "Tekrar Hedef Belirle";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnRedraw);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 48);
            this.button2.TabIndex = 0;
            this.button2.Text = "Başlat ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.startTimer);
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
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(929, 861);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze Solver";
            this.Load += new System.EventHandler(this.Game_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.areaSizeTrack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar areaSizeTrack;
        private System.Windows.Forms.Label lblAreaSize;
        private System.Windows.Forms.Button button5;
    }
}