namespace РГР
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn2players = new System.Windows.Forms.Button();
            this.btn3players = new System.Windows.Forms.Button();
            this.btn4players = new System.Windows.Forms.Button();
            this.btn5players = new System.Windows.Forms.Button();
            this.btn6players = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblTrump = new System.Windows.Forms.Label();
            this.lbCards = new System.Windows.Forms.ListBox();
            this.btnPlayCard = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Оберіть кількість гравців:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn2players
            // 
            this.btn2players.Location = new System.Drawing.Point(203, 23);
            this.btn2players.Name = "btn2players";
            this.btn2players.Size = new System.Drawing.Size(68, 43);
            this.btn2players.TabIndex = 1;
            this.btn2players.Text = "2";
            this.btn2players.UseVisualStyleBackColor = true;
            this.btn2players.Click += new System.EventHandler(this.btn2players_Click);
            // 
            // btn3players
            // 
            this.btn3players.Location = new System.Drawing.Point(277, 23);
            this.btn3players.Name = "btn3players";
            this.btn3players.Size = new System.Drawing.Size(68, 43);
            this.btn3players.TabIndex = 2;
            this.btn3players.Text = "3";
            this.btn3players.UseVisualStyleBackColor = true;
            this.btn3players.Click += new System.EventHandler(this.btn3players_Click);
            // 
            // btn4players
            // 
            this.btn4players.Location = new System.Drawing.Point(351, 23);
            this.btn4players.Name = "btn4players";
            this.btn4players.Size = new System.Drawing.Size(68, 43);
            this.btn4players.TabIndex = 3;
            this.btn4players.Text = "4";
            this.btn4players.UseVisualStyleBackColor = true;
            this.btn4players.Click += new System.EventHandler(this.btn4players_Click);
            // 
            // btn5players
            // 
            this.btn5players.Location = new System.Drawing.Point(425, 23);
            this.btn5players.Name = "btn5players";
            this.btn5players.Size = new System.Drawing.Size(68, 43);
            this.btn5players.TabIndex = 4;
            this.btn5players.Text = "5";
            this.btn5players.UseVisualStyleBackColor = true;
            this.btn5players.Click += new System.EventHandler(this.btn5players_Click);
            // 
            // btn6players
            // 
            this.btn6players.Location = new System.Drawing.Point(499, 23);
            this.btn6players.Name = "btn6players";
            this.btn6players.Size = new System.Drawing.Size(68, 43);
            this.btn6players.TabIndex = 5;
            this.btn6players.Text = "6";
            this.btn6players.UseVisualStyleBackColor = true;
            this.btn6players.Click += new System.EventHandler(this.btn6players_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Обрана кількість гравців:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(202, 92);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(14, 16);
            this.lblPlayers.TabIndex = 7;
            this.lblPlayers.Text = "2";
            this.lblPlayers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(313, 175);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(149, 108);
            this.btnStartGame.TabIndex = 8;
            this.btnStartGame.Text = "Start game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(37, 36);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(57, 16);
            this.lbl1.TabIndex = 9;
            this.lbl1.Text = "Козирь:";
            this.lbl1.Click += new System.EventHandler(this.lblTrump_Click);
            // 
            // lblTrump
            // 
            this.lblTrump.AutoSize = true;
            this.lblTrump.Location = new System.Drawing.Point(97, 36);
            this.lblTrump.Name = "lblTrump";
            this.lblTrump.Size = new System.Drawing.Size(11, 16);
            this.lblTrump.TabIndex = 10;
            this.lblTrump.Text = "-";
            // 
            // lbCards
            // 
            this.lbCards.FormattingEnabled = true;
            this.lbCards.ItemHeight = 16;
            this.lbCards.Location = new System.Drawing.Point(28, 95);
            this.lbCards.Name = "lbCards";
            this.lbCards.Size = new System.Drawing.Size(125, 340);
            this.lbCards.TabIndex = 11;
            this.lbCards.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnPlayCard
            // 
            this.btnPlayCard.Location = new System.Drawing.Point(177, 336);
            this.btnPlayCard.Name = "btnPlayCard";
            this.btnPlayCard.Size = new System.Drawing.Size(118, 99);
            this.btnPlayCard.TabIndex = 12;
            this.btnPlayCard.Text = "Зіграти карту";
            this.btnPlayCard.UseVisualStyleBackColor = true;
            this.btnPlayCard.Click += new System.EventHandler(this.btnPlayCard_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Оберіть карту:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Зараз хід:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Ваш";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ходять на:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(425, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Player1";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(330, 156);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(0, 16);
            this.lblEvent.TabIndex = 19;
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(512, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Перша карта:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(512, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Бита:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(512, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Бита:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(512, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Третя карта:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(512, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Бита:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(512, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "Друга карта:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(512, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Бита:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(512, 221);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 16);
            this.label15.TabIndex = 27;
            this.label15.Text = "Четверта карта:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(512, 283);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 16);
            this.label16.TabIndex = 30;
            this.label16.Text = "Бита:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(512, 267);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 16);
            this.label17.TabIndex = 29;
            this.label17.Text = "П\'ята карта:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(512, 325);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 16);
            this.label18.TabIndex = 32;
            this.label18.Text = "Бита:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(512, 309);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 16);
            this.label19.TabIndex = 31;
            this.label19.Text = "Шоста карта:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(655, 95);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 16);
            this.label20.TabIndex = 33;
            this.label20.Text = "-";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(655, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(11, 16);
            this.label21.TabIndex = 34;
            this.label21.Text = "-";
            this.label21.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(655, 152);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(11, 16);
            this.label22.TabIndex = 36;
            this.label22.Text = "-";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(655, 136);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 16);
            this.label23.TabIndex = 35;
            this.label23.Text = "-";
            this.label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(655, 191);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(11, 16);
            this.label24.TabIndex = 38;
            this.label24.Text = "-";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(655, 175);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(11, 16);
            this.label25.TabIndex = 37;
            this.label25.Text = "-";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(655, 237);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(11, 16);
            this.label26.TabIndex = 40;
            this.label26.Text = "-";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(655, 221);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(11, 16);
            this.label27.TabIndex = 39;
            this.label27.Text = "-";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(655, 283);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(11, 16);
            this.label28.TabIndex = 42;
            this.label28.Text = "-";
            this.label28.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(655, 267);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(11, 16);
            this.label29.TabIndex = 41;
            this.label29.Text = "-";
            this.label29.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(655, 325);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(11, 16);
            this.label30.TabIndex = 44;
            this.label30.Text = "-";
            this.label30.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(655, 309);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(11, 16);
            this.label31.TabIndex = 43;
            this.label31.Text = "-";
            this.label31.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(37, 20);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(97, 16);
            this.label32.TabIndex = 45;
            this.label32.Text = "Карт в колоді:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(129, 20);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(21, 16);
            this.label33.TabIndex = 46;
            this.label33.Text = "36";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(348, 156);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(0, 16);
            this.lblPass.TabIndex = 47;
            this.lblPass.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPlayCard);
            this.Controls.Add(this.lbCards);
            this.Controls.Add(this.lblTrump);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn6players);
            this.Controls.Add(this.btn5players);
            this.Controls.Add(this.btn4players);
            this.Controls.Add(this.btn3players);
            this.Controls.Add(this.btn2players);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn2players;
        private System.Windows.Forms.Button btn3players;
        private System.Windows.Forms.Button btn4players;
        private System.Windows.Forms.Button btn5players;
        private System.Windows.Forms.Button btn6players;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblTrump;
        private System.Windows.Forms.ListBox lbCards;
        private System.Windows.Forms.Button btnPlayCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblPass;
    }
}

