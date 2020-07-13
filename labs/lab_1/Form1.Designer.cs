namespace Splain
{
    partial class FormSplain
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
            this.pictureBoxSplain = new System.Windows.Forms.PictureBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.listBoxPoints = new System.Windows.Forms.ListBox();
            this.buttonManual = new System.Windows.Forms.Button();
            this.textBoxManual = new System.Windows.Forms.TextBox();
            this.labelInfoManual = new System.Windows.Forms.Label();
            this.radioButtonAuto = new System.Windows.Forms.RadioButton();
            this.radioButtonManual = new System.Windows.Forms.RadioButton();
            this.labelInfoAuto = new System.Windows.Forms.Label();
            this.buttonCreateSplain = new System.Windows.Forms.Button();
            this.labelWarning = new System.Windows.Forms.Label();
            this.trackBarScale = new System.Windows.Forms.TrackBar();
            this.labelScale = new System.Windows.Forms.Label();
            this.buttonManualReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSplain
            // 
            this.pictureBoxSplain.BackColor = System.Drawing.Color.White;
            this.pictureBoxSplain.Enabled = false;
            this.pictureBoxSplain.Location = new System.Drawing.Point(381, 12);
            this.pictureBoxSplain.Name = "pictureBoxSplain";
            this.pictureBoxSplain.Size = new System.Drawing.Size(752, 516);
            this.pictureBoxSplain.TabIndex = 0;
            this.pictureBoxSplain.TabStop = false;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Cursor = System.Windows.Forms.Cursors.No;
            this.textBoxLog.HideSelection = false;
            this.textBoxLog.Location = new System.Drawing.Point(381, 534);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(752, 94);
            this.textBoxLog.TabIndex = 6;
            this.textBoxLog.TabStop = false;
            // 
            // listBoxPoints
            // 
            this.listBoxPoints.Enabled = false;
            this.listBoxPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxPoints.FormattingEnabled = true;
            this.listBoxPoints.ItemHeight = 16;
            this.listBoxPoints.Location = new System.Drawing.Point(12, 179);
            this.listBoxPoints.Name = "listBoxPoints";
            this.listBoxPoints.Size = new System.Drawing.Size(357, 148);
            this.listBoxPoints.TabIndex = 7;
            this.listBoxPoints.TabStop = false;
            // 
            // buttonManual
            // 
            this.buttonManual.Enabled = false;
            this.buttonManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonManual.Location = new System.Drawing.Point(191, 81);
            this.buttonManual.Name = "buttonManual";
            this.buttonManual.Size = new System.Drawing.Size(178, 59);
            this.buttonManual.TabIndex = 4;
            this.buttonManual.Text = "Добавить точку";
            this.buttonManual.UseVisualStyleBackColor = true;
            this.buttonManual.Click += new System.EventHandler(this.buttonManual_Click);
            // 
            // textBoxManual
            // 
            this.textBoxManual.Enabled = false;
            this.textBoxManual.Location = new System.Drawing.Point(12, 118);
            this.textBoxManual.Name = "textBoxManual";
            this.textBoxManual.Size = new System.Drawing.Size(173, 22);
            this.textBoxManual.TabIndex = 3;
            this.textBoxManual.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxManual_KeyUp);
            // 
            // labelInfoManual
            // 
            this.labelInfoManual.AutoSize = true;
            this.labelInfoManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfoManual.Location = new System.Drawing.Point(12, 81);
            this.labelInfoManual.Name = "labelInfoManual";
            this.labelInfoManual.Size = new System.Drawing.Size(161, 36);
            this.labelInfoManual.TabIndex = 7;
            this.labelInfoManual.Text = "Введите 8 точек по \r\nодной в формате: x; y";
            // 
            // radioButtonAuto
            // 
            this.radioButtonAuto.AutoSize = true;
            this.radioButtonAuto.Checked = true;
            this.radioButtonAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAuto.Location = new System.Drawing.Point(15, 12);
            this.radioButtonAuto.Name = "radioButtonAuto";
            this.radioButtonAuto.Size = new System.Drawing.Size(256, 26);
            this.radioButtonAuto.TabIndex = 1;
            this.radioButtonAuto.TabStop = true;
            this.radioButtonAuto.Text = "Автоматический ввод точек";
            this.radioButtonAuto.UseCompatibleTextRendering = true;
            this.radioButtonAuto.UseVisualStyleBackColor = true;
            this.radioButtonAuto.CheckedChanged += new System.EventHandler(this.radioButtonAuto_CheckedChanged);
            // 
            // radioButtonManual
            // 
            this.radioButtonManual.AutoSize = true;
            this.radioButtonManual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonManual.Location = new System.Drawing.Point(15, 39);
            this.radioButtonManual.Name = "radioButtonManual";
            this.radioButtonManual.Size = new System.Drawing.Size(200, 24);
            this.radioButtonManual.TabIndex = 2;
            this.radioButtonManual.TabStop = true;
            this.radioButtonManual.Text = "Ручнной ввод точек";
            this.radioButtonManual.UseVisualStyleBackColor = true;
            this.radioButtonManual.CheckedChanged += new System.EventHandler(this.radioButtonManual_CheckedChanged);
            // 
            // labelInfoAuto
            // 
            this.labelInfoAuto.AutoSize = true;
            this.labelInfoAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfoAuto.Location = new System.Drawing.Point(8, 467);
            this.labelInfoAuto.Name = "labelInfoAuto";
            this.labelInfoAuto.Size = new System.Drawing.Size(359, 60);
            this.labelInfoAuto.TabIndex = 10;
            this.labelInfoAuto.Text = "При автоматическом вводе точек от вас\r\nне требуется никаких действий.\r\nНажмите на" +
    " кнопку \"Построить сплайн\".";
            // 
            // buttonCreateSplain
            // 
            this.buttonCreateSplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateSplain.Location = new System.Drawing.Point(12, 534);
            this.buttonCreateSplain.Name = "buttonCreateSplain";
            this.buttonCreateSplain.Size = new System.Drawing.Size(357, 94);
            this.buttonCreateSplain.TabIndex = 5;
            this.buttonCreateSplain.Text = "Построить сплайн";
            this.buttonCreateSplain.UseVisualStyleBackColor = true;
            this.buttonCreateSplain.Click += new System.EventHandler(this.buttonCreateSplain_Click);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarning.Location = new System.Drawing.Point(12, 143);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(331, 20);
            this.labelWarning.TabIndex = 11;
            this.labelWarning.Text = "Диапазон вводимых значений [-10; 10]";
            // 
            // trackBarScale
            // 
            this.trackBarScale.Enabled = false;
            this.trackBarScale.LargeChange = 1;
            this.trackBarScale.Location = new System.Drawing.Point(12, 408);
            this.trackBarScale.Maximum = 25;
            this.trackBarScale.Minimum = 10;
            this.trackBarScale.Name = "trackBarScale";
            this.trackBarScale.Size = new System.Drawing.Size(357, 56);
            this.trackBarScale.TabIndex = 12;
            this.trackBarScale.Value = 17;
            this.trackBarScale.Scroll += new System.EventHandler(this.trackBarScale_Scroll);
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScale.Location = new System.Drawing.Point(12, 385);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(244, 20);
            this.labelScale.TabIndex = 13;
            this.labelScale.Text = "Масштабирование графика";
            // 
            // buttonManualReset
            // 
            this.buttonManualReset.Enabled = false;
            this.buttonManualReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonManualReset.Location = new System.Drawing.Point(12, 333);
            this.buttonManualReset.Name = "buttonManualReset";
            this.buttonManualReset.Size = new System.Drawing.Size(357, 36);
            this.buttonManualReset.TabIndex = 14;
            this.buttonManualReset.Text = "Начать заново";
            this.buttonManualReset.UseVisualStyleBackColor = true;
            this.buttonManualReset.Click += new System.EventHandler(this.buttonManualReset_Click);
            // 
            // FormSplain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1145, 640);
            this.Controls.Add(this.buttonManualReset);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.trackBarScale);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.buttonCreateSplain);
            this.Controls.Add(this.labelInfoAuto);
            this.Controls.Add(this.radioButtonManual);
            this.Controls.Add(this.radioButtonAuto);
            this.Controls.Add(this.labelInfoManual);
            this.Controls.Add(this.textBoxManual);
            this.Controls.Add(this.buttonManual);
            this.Controls.Add(this.listBoxPoints);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.pictureBoxSplain);
            this.MaximizeBox = false;
            this.Name = "FormSplain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа. Кубический сплайн интерполяции. Денисов Владислав Львович, 3" +
    "81706-1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSplain;

        private System.Windows.Forms.RadioButton radioButtonAuto;
        private System.Windows.Forms.RadioButton radioButtonManual;

        private System.Windows.Forms.Label labelInfoManual;
        private System.Windows.Forms.TextBox textBoxManual;
        private System.Windows.Forms.ListBox listBoxPoints;
        private System.Windows.Forms.Button buttonManual;

        private System.Windows.Forms.Label labelInfoAuto;
        private System.Windows.Forms.Button buttonCreateSplain;

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.TrackBar trackBarScale;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Button buttonManualReset;
    }
}

