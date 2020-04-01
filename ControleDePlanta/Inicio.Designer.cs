namespace ControleDePlanta
{
    partial class Inicio
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lstPorts = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lstRegisterValues = new System.Windows.Forms.ListBox();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBotao = new System.Windows.Forms.Label();
            this.btnLoadPortas = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLed = new System.Windows.Forms.Label();
            this.btnLedLiga = new System.Windows.Forms.Button();
            this.btnLedDesliga = new System.Windows.Forms.Button();
            this.lstLogValues = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstPorts
            // 
            this.lstPorts.FormattingEnabled = true;
            this.lstPorts.Location = new System.Drawing.Point(12, 24);
            this.lstPorts.Name = "lstPorts";
            this.lstPorts.Size = new System.Drawing.Size(121, 21);
            this.lstPorts.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(416, 334);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(497, 334);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Parar";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 339);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Pronto";
            // 
            // lstRegisterValues
            // 
            this.lstRegisterValues.FormattingEnabled = true;
            this.lstRegisterValues.Location = new System.Drawing.Point(139, 9);
            this.lstRegisterValues.Name = "lstRegisterValues";
            this.lstRegisterValues.Size = new System.Drawing.Size(23, 17);
            this.lstRegisterValues.TabIndex = 4;
            this.lstRegisterValues.Visible = false;
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Location = new System.Drawing.Point(118, 97);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(13, 13);
            this.lblTemperatura.TabIndex = 5;
            this.lblTemperatura.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Porta de Conexão:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Temperatura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Botão:";
            // 
            // lblBotao
            // 
            this.lblBotao.AutoSize = true;
            this.lblBotao.Location = new System.Drawing.Point(98, 126);
            this.lblBotao.Name = "lblBotao";
            this.lblBotao.Size = new System.Drawing.Size(54, 13);
            this.lblBotao.TabIndex = 9;
            this.lblBotao.Text = "Desligado";
            // 
            // btnLoadPortas
            // 
            this.btnLoadPortas.Location = new System.Drawing.Point(12, 52);
            this.btnLoadPortas.Name = "btnLoadPortas";
            this.btnLoadPortas.Size = new System.Drawing.Size(121, 23);
            this.btnLoadPortas.TabIndex = 10;
            this.btnLoadPortas.Text = "Carregar Portas";
            this.btnLoadPortas.UseVisualStyleBackColor = true;
            this.btnLoadPortas.Click += new System.EventHandler(this.btnLoadPortas_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Led:";
            // 
            // lblLed
            // 
            this.lblLed.AutoSize = true;
            this.lblLed.Location = new System.Drawing.Point(98, 155);
            this.lblLed.Name = "lblLed";
            this.lblLed.Size = new System.Drawing.Size(54, 13);
            this.lblLed.TabIndex = 12;
            this.lblLed.Text = "Desligado";
            // 
            // btnLedLiga
            // 
            this.btnLedLiga.Enabled = false;
            this.btnLedLiga.Location = new System.Drawing.Point(12, 187);
            this.btnLedLiga.Name = "btnLedLiga";
            this.btnLedLiga.Size = new System.Drawing.Size(55, 23);
            this.btnLedLiga.TabIndex = 13;
            this.btnLedLiga.Text = "Liga";
            this.btnLedLiga.UseVisualStyleBackColor = true;
            this.btnLedLiga.Click += new System.EventHandler(this.btnLedLiga_Click);
            // 
            // btnLedDesliga
            // 
            this.btnLedDesliga.Enabled = false;
            this.btnLedDesliga.Location = new System.Drawing.Point(78, 187);
            this.btnLedDesliga.Name = "btnLedDesliga";
            this.btnLedDesliga.Size = new System.Drawing.Size(55, 23);
            this.btnLedDesliga.TabIndex = 14;
            this.btnLedDesliga.Text = "Desliga";
            this.btnLedDesliga.UseVisualStyleBackColor = true;
            this.btnLedDesliga.Click += new System.EventHandler(this.btnLedDesliga_Click);
            // 
            // lstLogValues
            // 
            this.lstLogValues.FormattingEnabled = true;
            this.lstLogValues.Location = new System.Drawing.Point(12, 217);
            this.lstLogValues.Name = "lstLogValues";
            this.lstLogValues.Size = new System.Drawing.Size(560, 108);
            this.lstLogValues.TabIndex = 15;
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Gray;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(168, 9);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            series1.Legend = "Legend1";
            series1.Name = "Temperatura";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(404, 201);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lstLogValues);
            this.Controls.Add(this.btnLedDesliga);
            this.Controls.Add(this.btnLedLiga);
            this.Controls.Add(this.lblLed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLoadPortas);
            this.Controls.Add(this.lblBotao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTemperatura);
            this.Controls.Add(this.lstRegisterValues);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lstPorts);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox lstPorts;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lstRegisterValues;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBotao;
        private System.Windows.Forms.Button btnLoadPortas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLed;
        private System.Windows.Forms.Button btnLedLiga;
        private System.Windows.Forms.Button btnLedDesliga;
        private System.Windows.Forms.ListBox lstLogValues;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}