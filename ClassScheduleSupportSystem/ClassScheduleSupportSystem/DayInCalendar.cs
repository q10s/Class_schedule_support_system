using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ClassScheduleSupportSystem
{
  public partial class DayInCalendar : UserControl
  {
    private static List<DayInCalendar> DaysInCalendar = new List<DayInCalendar>();
    public Form1.HandlerCalendarDayClick CalendarDayClick;  // Метод обработчик клика на день в календаре

    private bool _active;
    public bool Active
    {
      get { return _active; }
      set
      {
        if (_active != value)
        {
          if (value)
          {
            foreach (var dayInCalendar in DaysInCalendar)
              if (dayInCalendar.Active)
                dayInCalendar.Active = false;

            labelNumberDay.BackColor = SystemColors.ActiveCaption;
          }
          else labelNumberDay.BackColor = SystemColors.Control;
          _active = value;
        }
      }
    }

    private DateTime _date;

    [DisplayName(@"Date"), Description("Описание"), Category("Данные"), DefaultValue(30)]
    public DateTime Date
    {
      get { return _date; }
      set
      {
        _date = value;
        labelNumberDay.Text = _date.Day.ToString();
        labelText.Text = _date.ToString("ddd").ToUpper();
      }
    }


    public DayInCalendar()
    {
      DaysInCalendar.Add(this);
      InitializeComponent();
      for (int i = 0; i < Controls.Count; i++)
        Controls[i].Click += DayInCalendar_Click;
    }


    public void DayInCalendar_Click(object sender, EventArgs e)
    {
      var cal = new GregorianCalendar();
      // Получаем номер недели
      byte weekNumber = (byte)cal.GetWeekOfYear(_date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
      // Номер дня недели
      byte day = (byte)(cal.GetDayOfWeek(_date));
      day = (byte)((day == 0) ? 6 : day - 1);
      // День по расписанию
      byte scheduleDay = (byte)(day + (((weekNumber & 1) == 1) ? 7 : 0));

      // Вызов метода редактирования расписания
      Active = true;
      CalendarDayClick(scheduleDay);
    }
  }
}
