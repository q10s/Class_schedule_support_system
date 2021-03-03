
namespace ClassScheduleSupportSystem
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
      this.schedulePanel = new System.Windows.Forms.FlowLayoutPanel();
      this.addPair = new System.Windows.Forms.Button();
      this.calendarPanel = new System.Windows.Forms.Panel();
      this.schedules = new System.Windows.Forms.ComboBox();
      this.weekInCalendar1 = new ClassScheduleSupportSystem.WeekInCalendar();
      this.panelEditingSchedule = new System.Windows.Forms.Panel();
      this.editingClose = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.editingRemove = new System.Windows.Forms.Button();
      this.editingSave = new System.Windows.Forms.Button();
      this.editingLectureHall = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.editingNumberPair = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.editingNamePair = new System.Windows.Forms.TextBox();
      this.schedulePanel.SuspendLayout();
      this.calendarPanel.SuspendLayout();
      this.panelEditingSchedule.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.editingNumberPair)).BeginInit();
      this.SuspendLayout();
      // 
      // schedulePanel
      // 
      this.schedulePanel.AutoScroll = true;
      this.schedulePanel.Controls.Add(this.addPair);
      this.schedulePanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.schedulePanel.Location = new System.Drawing.Point(0, 113);
      this.schedulePanel.Margin = new System.Windows.Forms.Padding(0);
      this.schedulePanel.Name = "schedulePanel";
      this.schedulePanel.Size = new System.Drawing.Size(625, 448);
      this.schedulePanel.TabIndex = 3;
      // 
      // addPair
      // 
      this.addPair.Cursor = System.Windows.Forms.Cursors.Hand;
      this.addPair.Dock = System.Windows.Forms.DockStyle.Top;
      this.addPair.Location = new System.Drawing.Point(0, 5);
      this.addPair.Margin = new System.Windows.Forms.Padding(0, 5, 0, 4);
      this.addPair.Name = "addPair";
      this.addPair.Size = new System.Drawing.Size(624, 34);
      this.addPair.TabIndex = 0;
      this.addPair.Text = "Добавить пару";
      this.addPair.UseVisualStyleBackColor = true;
      this.addPair.Click += new System.EventHandler(this.addPair_Click);
      // 
      // calendarPanel
      // 
      this.calendarPanel.BackColor = System.Drawing.Color.SteelBlue;
      this.calendarPanel.Controls.Add(this.schedules);
      this.calendarPanel.Controls.Add(this.weekInCalendar1);
      this.calendarPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.calendarPanel.Location = new System.Drawing.Point(0, 0);
      this.calendarPanel.Name = "calendarPanel";
      this.calendarPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
      this.calendarPanel.Size = new System.Drawing.Size(625, 113);
      this.calendarPanel.TabIndex = 2;
      // 
      // schedules
      // 
      this.schedules.FormattingEnabled = true;
      this.schedules.Location = new System.Drawing.Point(355, 0);
      this.schedules.Name = "schedules";
      this.schedules.Size = new System.Drawing.Size(220, 28);
      this.schedules.TabIndex = 4;
      this.schedules.SelectedIndexChanged += new System.EventHandler(this.schedules_SelectedIndexChanged);
      this.schedules.KeyDown += new System.Windows.Forms.KeyEventHandler(this.schedules_KeyDown);
      // 
      // weekInCalendar1
      // 
      this.weekInCalendar1.Dock = System.Windows.Forms.DockStyle.Top;
      this.weekInCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.weekInCalendar1.Location = new System.Drawing.Point(0, 0);
      this.weekInCalendar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.weekInCalendar1.Name = "weekInCalendar1";
      this.weekInCalendar1.Size = new System.Drawing.Size(625, 113);
      this.weekInCalendar1.TabIndex = 1;
      // 
      // panelEditingSchedule
      // 
      this.panelEditingSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panelEditingSchedule.BackColor = System.Drawing.Color.Transparent;
      this.panelEditingSchedule.Controls.Add(this.editingClose);
      this.panelEditingSchedule.Controls.Add(this.label4);
      this.panelEditingSchedule.Controls.Add(this.panel2);
      this.panelEditingSchedule.Location = new System.Drawing.Point(0, 0);
      this.panelEditingSchedule.Name = "panelEditingSchedule";
      this.panelEditingSchedule.Size = new System.Drawing.Size(625, 561);
      this.panelEditingSchedule.TabIndex = 3;
      this.panelEditingSchedule.Visible = false;
      // 
      // editingClose
      // 
      this.editingClose.BackColor = System.Drawing.Color.LightCoral;
      this.editingClose.Cursor = System.Windows.Forms.Cursors.Hand;
      this.editingClose.FlatAppearance.BorderSize = 0;
      this.editingClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.editingClose.Location = new System.Drawing.Point(469, 142);
      this.editingClose.Name = "editingClose";
      this.editingClose.Size = new System.Drawing.Size(30, 30);
      this.editingClose.TabIndex = 16;
      this.editingClose.Text = "X";
      this.editingClose.UseVisualStyleBackColor = false;
      this.editingClose.Click += new System.EventHandler(this.editingClose_Click);
      // 
      // label4
      // 
      this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.label4.Location = new System.Drawing.Point(129, 142);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(370, 30);
      this.label4.TabIndex = 1;
      this.label4.Text = "Редактирование расписания";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.panel2.Controls.Add(this.editingRemove);
      this.panel2.Controls.Add(this.editingSave);
      this.panel2.Controls.Add(this.editingLectureHall);
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.editingNumberPair);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.editingNamePair);
      this.panel2.Location = new System.Drawing.Point(129, 175);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(370, 240);
      this.panel2.TabIndex = 0;
      // 
      // editingRemove
      // 
      this.editingRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.editingRemove.Location = new System.Drawing.Point(196, 177);
      this.editingRemove.Name = "editingRemove";
      this.editingRemove.Size = new System.Drawing.Size(134, 34);
      this.editingRemove.TabIndex = 15;
      this.editingRemove.Text = "Удалить";
      this.editingRemove.UseVisualStyleBackColor = true;
      this.editingRemove.Click += new System.EventHandler(this.editingRemove_Click);
      // 
      // editingSave
      // 
      this.editingSave.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.editingSave.Location = new System.Drawing.Point(40, 177);
      this.editingSave.Name = "editingSave";
      this.editingSave.Size = new System.Drawing.Size(134, 34);
      this.editingSave.TabIndex = 14;
      this.editingSave.Text = "Сохранить";
      this.editingSave.UseVisualStyleBackColor = true;
      this.editingSave.Click += new System.EventHandler(this.editingSave_Click);
      // 
      // editingLectureHall
      // 
      this.editingLectureHall.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.editingLectureHall.Location = new System.Drawing.Point(252, 93);
      this.editingLectureHall.Name = "editingLectureHall";
      this.editingLectureHall.Size = new System.Drawing.Size(77, 26);
      this.editingLectureHall.TabIndex = 13;
      // 
      // label3
      // 
      this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(40, 96);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(210, 20);
      this.label3.TabIndex = 12;
      this.label3.Text = "Введите номер кабинета: ";
      // 
      // label2
      // 
      this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(40, 136);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(186, 20);
      this.label2.TabIndex = 11;
      this.label2.Text = "Выберите номер пары: ";
      // 
      // editingNumberPair
      // 
      this.editingNumberPair.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.editingNumberPair.Location = new System.Drawing.Point(252, 134);
      this.editingNumberPair.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
      this.editingNumberPair.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.editingNumberPair.Name = "editingNumberPair";
      this.editingNumberPair.Size = new System.Drawing.Size(77, 26);
      this.editingNumberPair.TabIndex = 10;
      this.editingNumberPair.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(40, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(257, 20);
      this.label1.TabIndex = 9;
      this.label1.Text = "Введите название дисциплины: ";
      // 
      // editingNamePair
      // 
      this.editingNamePair.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.editingNamePair.Location = new System.Drawing.Point(40, 53);
      this.editingNamePair.Name = "editingNamePair";
      this.editingNamePair.Size = new System.Drawing.Size(289, 26);
      this.editingNamePair.TabIndex = 8;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(625, 561);
      this.Controls.Add(this.panelEditingSchedule);
      this.Controls.Add(this.schedulePanel);
      this.Controls.Add(this.calendarPanel);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.MaximumSize = new System.Drawing.Size(641, 600);
      this.MinimumSize = new System.Drawing.Size(641, 600);
      this.Name = "Form1";
      this.Text = "Расписание";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.schedulePanel.ResumeLayout(false);
      this.calendarPanel.ResumeLayout(false);
      this.panelEditingSchedule.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.editingNumberPair)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.FlowLayoutPanel schedulePanel;
    private System.Windows.Forms.Panel calendarPanel;
    private System.Windows.Forms.ComboBox schedules;
    private System.Windows.Forms.Panel panelEditingSchedule;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button editingRemove;
    private System.Windows.Forms.Button editingSave;
    private System.Windows.Forms.TextBox editingLectureHall;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown editingNumberPair;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox editingNamePair;
    private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addPair;
    private WeekInCalendar weekInCalendar1;
    private System.Windows.Forms.Button editingClose;
  }
}

