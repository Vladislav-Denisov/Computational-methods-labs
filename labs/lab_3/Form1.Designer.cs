namespace Cauchy_problem_ODE
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelMain = new System.Windows.Forms.Label();
            this.textBoxInputAB = new System.Windows.Forms.TextBox();
            this.labelAB = new System.Windows.Forms.Label();
            this.labelEPS = new System.Windows.Forms.Label();
            this.textBoxInputEPS = new System.Windows.Forms.TextBox();
            this.labelH = new System.Windows.Forms.Label();
            this.textBoxInputH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSigma = new System.Windows.Forms.Label();
            this.textBoxInputSigma = new System.Windows.Forms.TextBox();
            this.labelStart = new System.Windows.Forms.Label();
            this.textBoxInputXZero = new System.Windows.Forms.TextBox();
            this.labelXZero = new System.Windows.Forms.Label();
            this.textBoxInputVZero = new System.Windows.Forms.TextBox();
            this.labeVZero = new System.Windows.Forms.Label();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonManualReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.LightGray;
            this.chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chart.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea1.AxisX.Title = "X";
            chartArea1.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea1.AxisY.Title = "X\'";
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(695, 492);
            this.chart.TabIndex = 9;
            this.chart.Text = "chart1";
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxLog.HideSelection = false;
            this.textBoxLog.Location = new System.Drawing.Point(12, 510);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(695, 94);
            this.textBoxLog.TabIndex = 8;
            this.textBoxLog.TabStop = false;
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMain.Location = new System.Drawing.Point(720, 12);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(384, 80);
            this.labelMain.TabIndex = 10;
            this.labelMain.Text = "Фазовая траектория будет построена для\r\nматематического маятника с диссипацией: \r" +
    "\nx\'\' + δx\' + sin⁡x = 0\r\n--------------------------------------------------------" +
    "----";
            // 
            // textBoxInputAB
            // 
            this.textBoxInputAB.Location = new System.Drawing.Point(970, 110);
            this.textBoxInputAB.Name = "textBoxInputAB";
            this.textBoxInputAB.Size = new System.Drawing.Size(134, 22);
            this.textBoxInputAB.TabIndex = 0;
            this.textBoxInputAB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputAB_KeyPress);
            // 
            // labelAB
            // 
            this.labelAB.AutoSize = true;
            this.labelAB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAB.Location = new System.Drawing.Point(722, 92);
            this.labelAB.Name = "labelAB";
            this.labelAB.Size = new System.Drawing.Size(223, 40);
            this.labelAB.TabIndex = 10;
            this.labelAB.Text = "Отрезок интегрирования\r\nв формате: a; b";
            // 
            // labelEPS
            // 
            this.labelEPS.AutoSize = true;
            this.labelEPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEPS.Location = new System.Drawing.Point(722, 144);
            this.labelEPS.Name = "labelEPS";
            this.labelEPS.Size = new System.Drawing.Size(258, 20);
            this.labelEPS.TabIndex = 10;
            this.labelEPS.Text = "Локальная погрешность eps=\r\n";
            // 
            // textBoxInputEPS
            // 
            this.textBoxInputEPS.Location = new System.Drawing.Point(1037, 144);
            this.textBoxInputEPS.Name = "textBoxInputEPS";
            this.textBoxInputEPS.Size = new System.Drawing.Size(70, 22);
            this.textBoxInputEPS.TabIndex = 1;
            this.textBoxInputEPS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEPS_KeyPress);
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelH.Location = new System.Drawing.Point(722, 173);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(256, 20);
            this.labelH.TabIndex = 10;
            this.labelH.Text = "Шаг (начальное значение) h=";
            // 
            // textBoxInputH
            // 
            this.textBoxInputH.Location = new System.Drawing.Point(1037, 172);
            this.textBoxInputH.Name = "textBoxInputH";
            this.textBoxInputH.Size = new System.Drawing.Size(70, 22);
            this.textBoxInputH.TabIndex = 2;
            this.textBoxInputH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputH_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(722, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Параметры ДУ:";
            // 
            // labelSigma
            // 
            this.labelSigma.AutoSize = true;
            this.labelSigma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSigma.Location = new System.Drawing.Point(722, 231);
            this.labelSigma.Name = "labelSigma";
            this.labelSigma.Size = new System.Drawing.Size(38, 20);
            this.labelSigma.TabIndex = 10;
            this.labelSigma.Text = "δ = ";
            // 
            // textBoxInputSigma
            // 
            this.textBoxInputSigma.Location = new System.Drawing.Point(762, 231);
            this.textBoxInputSigma.Name = "textBoxInputSigma";
            this.textBoxInputSigma.Size = new System.Drawing.Size(58, 22);
            this.textBoxInputSigma.TabIndex = 3;
            this.textBoxInputSigma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputSigma_KeyPress);
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStart.Location = new System.Drawing.Point(720, 274);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(186, 20);
            this.labelStart.TabIndex = 10;
            this.labelStart.Text = "Начальные условия: ";
            // 
            // textBoxInputXZero
            // 
            this.textBoxInputXZero.Font = new System.Drawing.Font("Calibri", 8F);
            this.textBoxInputXZero.Location = new System.Drawing.Point(762, 300);
            this.textBoxInputXZero.Name = "textBoxInputXZero";
            this.textBoxInputXZero.Size = new System.Drawing.Size(58, 24);
            this.textBoxInputXZero.TabIndex = 4;
            this.textBoxInputXZero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputXZero_KeyPress);
            // 
            // labelXZero
            // 
            this.labelXZero.AutoSize = true;
            this.labelXZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXZero.Location = new System.Drawing.Point(722, 303);
            this.labelXZero.Name = "labelXZero";
            this.labelXZero.Size = new System.Drawing.Size(46, 20);
            this.labelXZero.TabIndex = 10;
            this.labelXZero.Text = "x0 = ";
            // 
            // textBoxInputVZero
            // 
            this.textBoxInputVZero.Font = new System.Drawing.Font("Calibri", 8F);
            this.textBoxInputVZero.Location = new System.Drawing.Point(904, 300);
            this.textBoxInputVZero.Name = "textBoxInputVZero";
            this.textBoxInputVZero.Size = new System.Drawing.Size(58, 24);
            this.textBoxInputVZero.TabIndex = 5;
            this.textBoxInputVZero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputVZero_KeyPress);
            // 
            // labeVZero
            // 
            this.labeVZero.AutoSize = true;
            this.labeVZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labeVZero.Location = new System.Drawing.Point(855, 303);
            this.labeVZero.Name = "labeVZero";
            this.labeVZero.Size = new System.Drawing.Size(46, 20);
            this.labeVZero.TabIndex = 10;
            this.labeVZero.Text = "v0 = ";
            // 
            // buttonSolve
            // 
            this.buttonSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSolve.Location = new System.Drawing.Point(726, 510);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(381, 94);
            this.buttonSolve.TabIndex = 6;
            this.buttonSolve.Text = "Построить фазовую траекторию";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // buttonManualReset
            // 
            this.buttonManualReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonManualReset.Location = new System.Drawing.Point(726, 468);
            this.buttonManualReset.Name = "buttonManualReset";
            this.buttonManualReset.Size = new System.Drawing.Size(381, 36);
            this.buttonManualReset.TabIndex = 7;
            this.buttonManualReset.Text = "Удалить всё и начать заново";
            this.buttonManualReset.UseVisualStyleBackColor = true;
            this.buttonManualReset.Click += new System.EventHandler(this.buttonManualReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(855, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "(так переобозначено x\')";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1126, 616);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonManualReset);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.textBoxInputXZero);
            this.Controls.Add(this.labelXZero);
            this.Controls.Add(this.textBoxInputVZero);
            this.Controls.Add(this.labeVZero);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.textBoxInputSigma);
            this.Controls.Add(this.labelSigma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxInputH);
            this.Controls.Add(this.labelH);
            this.Controls.Add(this.textBoxInputEPS);
            this.Controls.Add(this.labelEPS);
            this.Controls.Add(this.labelAB);
            this.Controls.Add(this.textBoxInputAB);
            this.Controls.Add(this.labelMain);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.chart);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Построение фазовых траекторий для ОДУ. Денисов Владислав Львович, 381706-1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.TextBox textBoxInputAB;
        private System.Windows.Forms.Label labelAB;
        private System.Windows.Forms.Label labelEPS;
        private System.Windows.Forms.TextBox textBoxInputEPS;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.TextBox textBoxInputH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSigma;
        private System.Windows.Forms.TextBox textBoxInputSigma;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.TextBox textBoxInputXZero;
        private System.Windows.Forms.Label labelXZero;
        private System.Windows.Forms.TextBox textBoxInputVZero;
        private System.Windows.Forms.Label labeVZero;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonManualReset;
        private System.Windows.Forms.Label label1;
    }
}

