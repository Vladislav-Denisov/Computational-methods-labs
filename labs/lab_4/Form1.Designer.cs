namespace Initial_boundary_problem_for_INT_DIF_part_equ
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxInputL = new System.Windows.Forms.TextBox();
            this.textBoxInputT = new System.Windows.Forms.TextBox();
            this.textBoxInputH = new System.Windows.Forms.TextBox();
            this.textBoxInputTau = new System.Windows.Forms.TextBox();
            this.textBoxInputB0 = new System.Windows.Forms.TextBox();
            this.textBoxInputB1 = new System.Windows.Forms.TextBox();
            this.textBoxInputPhi1 = new System.Windows.Forms.TextBox();
            this.labelMain = new System.Windows.Forms.Label();
            this.labelL = new System.Windows.Forms.Label();
            this.labelT = new System.Windows.Forms.Label();
            this.labelH = new System.Windows.Forms.Label();
            this.labelTau = new System.Windows.Forms.Label();
            this.labelParams = new System.Windows.Forms.Label();
            this.labelB0 = new System.Windows.Forms.Label();
            this.labelB1 = new System.Windows.Forms.Label();
            this.labelPhi1 = new System.Windows.Forms.Label();
            this.labelPhi2 = new System.Windows.Forms.Label();
            this.textBoxInputPhi2 = new System.Windows.Forms.TextBox();
            this.labelB2 = new System.Windows.Forms.Label();
            this.textBoxInputB2 = new System.Windows.Forms.TextBox();
            this.labelWarningEnter = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checkBoxGraphA = new System.Windows.Forms.CheckBox();
            this.labelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.LightGray;
            this.chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chart.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea2.AxisX.Title = "X";
            chartArea2.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea2.AxisY.Title = "T";
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 88F;
            chartArea2.Position.Width = 94F;
            chartArea2.Position.X = 3F;
            chartArea2.Position.Y = 3F;
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 5F;
            legend2.Position.Width = 100F;
            legend2.Position.Y = 94F;
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(12, 12);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart.Name = "chart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series4.Legend = "Legend1";
            series4.Name = "Начальная температура";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "Конечная температура";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.Lime;
            series6.Legend = "Legend1";
            series6.Name = "Часть А";
            this.chart.Series.Add(series4);
            this.chart.Series.Add(series5);
            this.chart.Series.Add(series6);
            this.chart.Size = new System.Drawing.Size(607, 404);
            this.chart.TabIndex = 10;
            this.chart.Text = "chart1";
            // 
            // buttonSolve
            // 
            this.buttonSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSolve.Location = new System.Drawing.Point(635, 427);
            this.buttonSolve.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(414, 61);
            this.buttonSolve.TabIndex = 11;
            this.buttonSolve.Text = "Выполнить расчёты и\r\nпостроить график";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxLog.HideSelection = false;
            this.textBoxLog.Location = new System.Drawing.Point(12, 427);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(607, 94);
            this.textBoxLog.TabIndex = 12;
            this.textBoxLog.TabStop = false;
            // 
            // textBoxInputL
            // 
            this.textBoxInputL.Location = new System.Drawing.Point(886, 111);
            this.textBoxInputL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputL.Name = "textBoxInputL";
            this.textBoxInputL.Size = new System.Drawing.Size(71, 22);
            this.textBoxInputL.TabIndex = 13;
            this.textBoxInputL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputL_KeyPress);
            // 
            // textBoxInputT
            // 
            this.textBoxInputT.Location = new System.Drawing.Point(886, 139);
            this.textBoxInputT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputT.Name = "textBoxInputT";
            this.textBoxInputT.Size = new System.Drawing.Size(71, 22);
            this.textBoxInputT.TabIndex = 14;
            this.textBoxInputT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputT_KeyPress);
            // 
            // textBoxInputH
            // 
            this.textBoxInputH.Location = new System.Drawing.Point(886, 167);
            this.textBoxInputH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputH.Name = "textBoxInputH";
            this.textBoxInputH.Size = new System.Drawing.Size(71, 22);
            this.textBoxInputH.TabIndex = 15;
            this.textBoxInputH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputH_KeyPress);
            // 
            // textBoxInputTau
            // 
            this.textBoxInputTau.Location = new System.Drawing.Point(886, 195);
            this.textBoxInputTau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputTau.Name = "textBoxInputTau";
            this.textBoxInputTau.Size = new System.Drawing.Size(71, 22);
            this.textBoxInputTau.TabIndex = 16;
            this.textBoxInputTau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputTau_KeyPress);
            // 
            // textBoxInputB0
            // 
            this.textBoxInputB0.Location = new System.Drawing.Point(695, 251);
            this.textBoxInputB0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputB0.Name = "textBoxInputB0";
            this.textBoxInputB0.Size = new System.Drawing.Size(71, 22);
            this.textBoxInputB0.TabIndex = 17;
            this.textBoxInputB0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputB0_KeyPress);
            // 
            // textBoxInputB1
            // 
            this.textBoxInputB1.Location = new System.Drawing.Point(695, 279);
            this.textBoxInputB1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputB1.Name = "textBoxInputB1";
            this.textBoxInputB1.Size = new System.Drawing.Size(71, 22);
            this.textBoxInputB1.TabIndex = 18;
            this.textBoxInputB1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputB1_KeyPress);
            // 
            // textBoxInputPhi1
            // 
            this.textBoxInputPhi1.Location = new System.Drawing.Point(695, 338);
            this.textBoxInputPhi1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputPhi1.Name = "textBoxInputPhi1";
            this.textBoxInputPhi1.Size = new System.Drawing.Size(71, 22);
            this.textBoxInputPhi1.TabIndex = 19;
            this.textBoxInputPhi1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputPhi1_KeyPress);
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMain.Location = new System.Drawing.Point(629, 9);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(369, 80);
            this.labelMain.TabIndex = 20;
            this.labelMain.Text = "Начальные функции:\r\nφ(х) = 1/l + φ1*cos(πx / l) + φ2*cos(2πx / l) \r\nb(x) = b0 + b" +
    "1*cos(πx / l) + b2*cos(2πx / l) \r\n----------------------------------------------" +
    "--------------";
            // 
            // labelL
            // 
            this.labelL.AutoSize = true;
            this.labelL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelL.Location = new System.Drawing.Point(631, 113);
            this.labelL.Name = "labelL";
            this.labelL.Size = new System.Drawing.Size(162, 20);
            this.labelL.TabIndex = 21;
            this.labelL.Text = "Длина стержня l =\r\n";
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelT.Location = new System.Drawing.Point(631, 141);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(93, 20);
            this.labelT.TabIndex = 22;
            this.labelT.Text = "Время T =\r\n";
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelH.Location = new System.Drawing.Point(631, 169);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(226, 20);
            this.labelH.TabIndex = 23;
            this.labelH.Text = "Шаг (по координате x) h =";
            // 
            // labelTau
            // 
            this.labelTau.AutoSize = true;
            this.labelTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTau.Location = new System.Drawing.Point(631, 197);
            this.labelTau.Name = "labelTau";
            this.labelTau.Size = new System.Drawing.Size(237, 20);
            this.labelTau.TabIndex = 24;
            this.labelTau.Text = "Шаг (по координате t) tau =";
            // 
            // labelParams
            // 
            this.labelParams.AutoSize = true;
            this.labelParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelParams.Location = new System.Drawing.Point(631, 229);
            this.labelParams.Name = "labelParams";
            this.labelParams.Size = new System.Drawing.Size(189, 20);
            this.labelParams.TabIndex = 25;
            this.labelParams.Text = "Параметры функций:";
            // 
            // labelB0
            // 
            this.labelB0.AutoSize = true;
            this.labelB0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelB0.Location = new System.Drawing.Point(631, 253);
            this.labelB0.Name = "labelB0";
            this.labelB0.Size = new System.Drawing.Size(42, 20);
            this.labelB0.TabIndex = 26;
            this.labelB0.Text = "b0 =";
            // 
            // labelB1
            // 
            this.labelB1.AutoSize = true;
            this.labelB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelB1.Location = new System.Drawing.Point(631, 282);
            this.labelB1.Name = "labelB1";
            this.labelB1.Size = new System.Drawing.Size(42, 20);
            this.labelB1.TabIndex = 27;
            this.labelB1.Text = "b1 =";
            // 
            // labelPhi1
            // 
            this.labelPhi1.AutoSize = true;
            this.labelPhi1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPhi1.Location = new System.Drawing.Point(631, 342);
            this.labelPhi1.Name = "labelPhi1";
            this.labelPhi1.Size = new System.Drawing.Size(45, 20);
            this.labelPhi1.TabIndex = 28;
            this.labelPhi1.Text = "φ1 =";
            // 
            // labelPhi2
            // 
            this.labelPhi2.AutoSize = true;
            this.labelPhi2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPhi2.Location = new System.Drawing.Point(631, 371);
            this.labelPhi2.Name = "labelPhi2";
            this.labelPhi2.Size = new System.Drawing.Size(45, 20);
            this.labelPhi2.TabIndex = 29;
            this.labelPhi2.Text = "φ2 =";
            // 
            // textBoxInputPhi2
            // 
            this.textBoxInputPhi2.Location = new System.Drawing.Point(695, 368);
            this.textBoxInputPhi2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputPhi2.Name = "textBoxInputPhi2";
            this.textBoxInputPhi2.Size = new System.Drawing.Size(71, 22);
            this.textBoxInputPhi2.TabIndex = 30;
            this.textBoxInputPhi2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputPhi2_KeyPress);
            // 
            // labelB2
            // 
            this.labelB2.AutoSize = true;
            this.labelB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelB2.Location = new System.Drawing.Point(631, 311);
            this.labelB2.Name = "labelB2";
            this.labelB2.Size = new System.Drawing.Size(42, 20);
            this.labelB2.TabIndex = 32;
            this.labelB2.Text = "b2 =";
            // 
            // textBoxInputB2
            // 
            this.textBoxInputB2.Location = new System.Drawing.Point(695, 309);
            this.textBoxInputB2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxInputB2.Name = "textBoxInputB2";
            this.textBoxInputB2.Size = new System.Drawing.Size(71, 22);
            this.textBoxInputB2.TabIndex = 31;
            this.textBoxInputB2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputB2_KeyPress);
            // 
            // labelWarningEnter
            // 
            this.labelWarningEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarningEnter.Location = new System.Drawing.Point(632, 89);
            this.labelWarningEnter.Name = "labelWarningEnter";
            this.labelWarningEnter.Size = new System.Drawing.Size(417, 20);
            this.labelWarningEnter.TabIndex = 33;
            this.labelWarningEnter.Text = "Подтверждение ввода - нажатие ENTER";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(636, 498);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(321, 23);
            this.progressBar.TabIndex = 34;
            // 
            // checkBoxGraphA
            // 
            this.checkBoxGraphA.AutoSize = true;
            this.checkBoxGraphA.Location = new System.Drawing.Point(636, 395);
            this.checkBoxGraphA.Name = "checkBoxGraphA";
            this.checkBoxGraphA.Size = new System.Drawing.Size(229, 21);
            this.checkBoxGraphA.TabIndex = 35;
            this.checkBoxGraphA.Text = "Отображать решение части А";
            this.checkBoxGraphA.UseVisualStyleBackColor = true;
            this.checkBoxGraphA.CheckedChanged += new System.EventHandler(this.checkBoxGraphA_CheckedChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(963, 498);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(74, 20);
            this.labelTime.TabIndex = 36;
            this.labelTime.Text = "0 s 0 ms";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1061, 533);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.checkBoxGraphA);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelWarningEnter);
            this.Controls.Add(this.labelB2);
            this.Controls.Add(this.textBoxInputB2);
            this.Controls.Add(this.textBoxInputPhi2);
            this.Controls.Add(this.labelPhi2);
            this.Controls.Add(this.labelPhi1);
            this.Controls.Add(this.labelB1);
            this.Controls.Add(this.labelB0);
            this.Controls.Add(this.labelParams);
            this.Controls.Add(this.labelTau);
            this.Controls.Add(this.labelH);
            this.Controls.Add(this.labelT);
            this.Controls.Add(this.labelL);
            this.Controls.Add(this.labelMain);
            this.Controls.Add(this.textBoxInputPhi1);
            this.Controls.Add(this.textBoxInputB1);
            this.Controls.Add(this.textBoxInputB0);
            this.Controls.Add(this.textBoxInputTau);
            this.Controls.Add(this.textBoxInputH);
            this.Controls.Add(this.textBoxInputT);
            this.Controls.Add(this.textBoxInputL);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.chart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Численное решение начально-краевой задачи. Денисов Владислав Львович, 381706-1";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxInputL;
        private System.Windows.Forms.TextBox textBoxInputT;
        private System.Windows.Forms.TextBox textBoxInputH;
        private System.Windows.Forms.TextBox textBoxInputTau;
        private System.Windows.Forms.TextBox textBoxInputB0;
        private System.Windows.Forms.TextBox textBoxInputB1;
        private System.Windows.Forms.TextBox textBoxInputPhi1;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Label labelL;
        private System.Windows.Forms.Label labelT;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Label labelTau;
        private System.Windows.Forms.Label labelParams;
        private System.Windows.Forms.Label labelB0;
        private System.Windows.Forms.Label labelB1;
        private System.Windows.Forms.Label labelPhi1;
        private System.Windows.Forms.Label labelPhi2;
        private System.Windows.Forms.TextBox textBoxInputPhi2;
        private System.Windows.Forms.Label labelB2;
        private System.Windows.Forms.TextBox textBoxInputB2;
        private System.Windows.Forms.Label labelWarningEnter;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox checkBoxGraphA;
        private System.Windows.Forms.Label labelTime;
    }
}

