using System;
using System.Windows.Forms;

namespace ClassScheduleSupportSystem
{
  public partial class PairInfo : UserControl
  {
    // Метод обработчик клика на пару в расписании
    public Form1.HandlerPairInfoClick PairInfoClick;

    private Schedule _schedule;
    public Schedule Schedule { get { return _schedule; } }
    public byte Number
    {
      get { return _schedule.Number; }
      set
      {
        _schedule.Number = value;
        number.Text = value.ToString();
      }
    }

    public string LectureHall
    {
      get { return _schedule.LectureHall; }
      set
      {
        _schedule.LectureHall = value;
        lectureHall.Text = value;
      }
    }

    public string NamePair
    {
      get { return _schedule.NamePair; }
      set
      {
        _schedule.NamePair = value;
        namePair.Text = value;
      }
    }

    public PairInfo(Schedule schedule)
    {
      InitializeComponent();
      _schedule = schedule;

      number.Text = schedule.Number.ToString();
      namePair.Text = schedule.NamePair;
      lectureHall.Text = schedule.LectureHall;

      var t = Schedule.GetTimePair(schedule.Number);
      timeStartEnd.Text = string.Format("{0}-{1}",
                                        t.Start.ToString("HH:mm"),
                                        t.End.ToString("HH:mm"));

      number.Click += PairInfo_Click;
      lectureHall.Click += PairInfo_Click;
      timeStartEnd.Click += PairInfo_Click;
      namePair.Click += PairInfo_Click;
    }


    public void PairInfo_Click(object sender, EventArgs e)
    {
      PairInfoClick(this);
    }
  }
}
