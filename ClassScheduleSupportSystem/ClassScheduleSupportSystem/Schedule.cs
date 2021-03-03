using System;

namespace ClassScheduleSupportSystem
{
  [Serializable]
  public class Schedule
  {
    public byte Number { get; set; }
    public string LectureHall { get; set; }

    public string NamePair { get; set; }
    public static (DateTime Start, DateTime End) GetTimePair(byte number)
    {
      DateTime t = DateTime.Parse("08:00");
      t = t.AddMinutes(100 * (number - 1));

      return (t, t.AddMinutes(90));
    }

    public Schedule(byte number, string lectureHall, string namePair)
    {
      Number = number;
      LectureHall = lectureHall;
      NamePair = namePair;
    }
  }
}
