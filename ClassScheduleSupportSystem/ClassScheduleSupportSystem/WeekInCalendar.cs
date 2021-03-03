using System;
using System.Globalization;
using System.Windows.Forms;

namespace ClassScheduleSupportSystem
{
  public partial class WeekInCalendar : UserControl
  {
    // Обработчик клика на конкретный день в расписании
    public Form1.HandlerCalendarDayClick CalendarDayClick
    {
      set
      {
        foreach (var control in calendarPanelDays.Controls)
          if (control.GetType() == typeof(DayInCalendar))
            ((DayInCalendar)control).CalendarDayClick = value;
      }
    }


    public DayInCalendar this[int index]
    {
      get
      {
        return (DayInCalendar)calendarPanelDays.Controls[index];
      }
    }


    DateTime dateStartWeek;


    public WeekInCalendar()
    {
      InitializeComponent();

      dateStartWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
      UpdateWeek();
    }

    private void calendarButtonLeft_Click(object sender, EventArgs e)
    {
      dateStartWeek = dateStartWeek.AddDays(-7);
      UpdateWeek();

      for (byte i = 0; i < calendarPanelDays.Controls.Count; i++)
        if (this[i].Active) this[i].DayInCalendar_Click(null, null);
    }

    private void calendarButtonRight_Click(object sender, EventArgs e)
    {
      dateStartWeek = dateStartWeek.AddDays(7);
      UpdateWeek();

      for (byte i = 0; i < calendarPanelDays.Controls.Count; i++)
        if (this[i].Active) this[i].DayInCalendar_Click(null, null);
    }


    private void UpdateWeek()
    {
      calendarYear.Text = dateStartWeek.Year.ToString() +
                          ((dateStartWeek.Year == dateStartWeek.AddDays(6).Year) ?
                                  "" : " - " + dateStartWeek.AddDays(6).Year.ToString());

      calendarMonth.Text = dateStartWeek.ToString("MMMM") +
                          ((dateStartWeek.Month == dateStartWeek.AddDays(6).Month) ?
                                  "" : " - " + dateStartWeek.AddDays(6).ToString("MMMM"));

      byte i = 6;
      foreach (DayInCalendar day in calendarPanelDays.Controls)
        day.Date = dateStartWeek.AddDays(i--);
    }

    public byte GetDaySchedule(DateTime date)
    {
      var cal = new GregorianCalendar();
      byte weekNumber = (byte)cal.GetWeekOfYear(dateStartWeek, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
      byte day = (byte)(date.DayOfWeek - 1);
      return (byte)(day + (((weekNumber & 1) == 1) ? 7 : 0));
    }
  }
}
