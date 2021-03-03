
namespace ClassScheduleSupportSystem
{
  partial class PairInfo
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.timeStartEnd = new System.Windows.Forms.Label();
      this.lectureHall = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.number = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.namePair = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
      this.panel1.Controls.Add(this.timeStartEnd);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 30);
      this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(110, 30);
      this.panel1.TabIndex = 0;
      // 
      // timeStartEnd
      // 
      this.timeStartEnd.BackColor = System.Drawing.Color.AliceBlue;
      this.timeStartEnd.Dock = System.Windows.Forms.DockStyle.Fill;
      this.timeStartEnd.Location = new System.Drawing.Point(0, 0);
      this.timeStartEnd.MinimumSize = new System.Drawing.Size(0, 30);
      this.timeStartEnd.Name = "timeStartEnd";
      this.timeStartEnd.Size = new System.Drawing.Size(110, 30);
      this.timeStartEnd.TabIndex = 1;
      this.timeStartEnd.Text = "08:00-09:30";
      this.timeStartEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lectureHall
      // 
      this.lectureHall.BackColor = System.Drawing.Color.LightSteelBlue;
      this.lectureHall.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lectureHall.Location = new System.Drawing.Point(30, 0);
      this.lectureHall.MinimumSize = new System.Drawing.Size(0, 30);
      this.lectureHall.Name = "lectureHall";
      this.lectureHall.Padding = new System.Windows.Forms.Padding(6, 0, 8, 0);
      this.lectureHall.Size = new System.Drawing.Size(80, 30);
      this.lectureHall.TabIndex = 2;
      this.lectureHall.Text = "Г-138";
      this.lectureHall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
      this.panel2.Controls.Add(this.lectureHall);
      this.panel2.Controls.Add(this.number);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(110, 30);
      this.panel2.TabIndex = 4;
      // 
      // number
      // 
      this.number.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.number.Dock = System.Windows.Forms.DockStyle.Left;
      this.number.Location = new System.Drawing.Point(0, 0);
      this.number.Name = "number";
      this.number.Size = new System.Drawing.Size(30, 30);
      this.number.TabIndex = 0;
      this.number.Text = "1";
      this.number.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.panel2);
      this.panel3.Controls.Add(this.panel1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(110, 60);
      this.panel3.TabIndex = 5;
      // 
      // namePair
      // 
      this.namePair.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.namePair.Dock = System.Windows.Forms.DockStyle.Fill;
      this.namePair.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.namePair.Location = new System.Drawing.Point(110, 0);
      this.namePair.Name = "namePair";
      this.namePair.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
      this.namePair.Size = new System.Drawing.Size(510, 60);
      this.namePair.TabIndex = 6;
      this.namePair.Text = "Теория вероятностей и математическая статистика\r\n";
      this.namePair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // PairInfo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.namePair);
      this.Controls.Add(this.panel3);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.Name = "PairInfo";
      this.Size = new System.Drawing.Size(620, 60);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lectureHall;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label timeStartEnd;
    private System.Windows.Forms.Label number;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label namePair;
  }
}
