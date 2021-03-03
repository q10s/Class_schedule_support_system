
namespace ClassScheduleSupportSystem
{
  partial class DayInCalendar
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

    #region Код, автоматически созданный конструктором компонентов

    /// <summary> 
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.labelText = new System.Windows.Forms.Label();
      this.labelNumberDay = new System.Windows.Forms.Label();
      this.labelCountPars = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // labelText
      // 
      this.labelText.BackColor = System.Drawing.SystemColors.ControlDark;
      this.labelText.Dock = System.Windows.Forms.DockStyle.Top;
      this.labelText.Location = new System.Drawing.Point(0, 0);
      this.labelText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelText.Name = "labelText";
      this.labelText.Size = new System.Drawing.Size(75, 20);
      this.labelText.TabIndex = 0;
      this.labelText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelNumberDay
      // 
      this.labelNumberDay.Dock = System.Windows.Forms.DockStyle.Fill;
      this.labelNumberDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.labelNumberDay.Location = new System.Drawing.Point(0, 20);
      this.labelNumberDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.labelNumberDay.Name = "labelNumberDay";
      this.labelNumberDay.Size = new System.Drawing.Size(75, 40);
      this.labelNumberDay.TabIndex = 1;
      this.labelNumberDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // labelCountPars
      // 
      this.labelCountPars.BackColor = System.Drawing.SystemColors.ControlDark;
      this.labelCountPars.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.labelCountPars.Location = new System.Drawing.Point(0, 60);
      this.labelCountPars.Name = "labelCountPars";
      this.labelCountPars.Size = new System.Drawing.Size(75, 15);
      this.labelCountPars.TabIndex = 2;
      this.labelCountPars.Text = "***";
      this.labelCountPars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // DayInCalendar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.labelNumberDay);
      this.Controls.Add(this.labelCountPars);
      this.Controls.Add(this.labelText);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "DayInCalendar";
      this.Size = new System.Drawing.Size(75, 75);
      this.Click += new System.EventHandler(this.DayInCalendar_Click);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label labelText;
    private System.Windows.Forms.Label labelNumberDay;
    private System.Windows.Forms.Label labelCountPars;
  }
}
