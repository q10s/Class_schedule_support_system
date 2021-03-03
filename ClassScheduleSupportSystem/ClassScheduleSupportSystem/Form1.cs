using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ClassScheduleSupportSystem
{
  public partial class Form1 : Form
  {
    // Делегат для передачи функции редактирования расписания
    public delegate void HandlerCalendarDayClick(byte numberDay);
    public delegate void HandlerPairInfoClick(PairInfo pairInfo);


    List<Schedule>[] schedulesForDays;
    private byte activeDay;

    string schedulePath = Environment.CurrentDirectory + "\\schedules\\";


    public Form1()
    {
      InitializeComponent();

      // Добавление обработчика клика на день в календаре
      weekInCalendar1.CalendarDayClick = DayClick;
      //
      foreach (var pI in schedulePanel.Controls)
        if (pI.GetType() == typeof(PairInfo))
          ((PairInfo)pI).PairInfoClick = PairInfoClick;

      // Создаем структуру для хранения расписания группы
      ScheduleSetDafaultValue();

      // Определяем существование каталога с рассписаниями
      if (!Directory.Exists(schedulePath))        // Если не существует
        Directory.CreateDirectory(schedulePath);  // Создаем каталог

      // Получаем список каталогов с различными рассписаниями
      List<string> scheduleNames = new List<string>(from path in Directory.EnumerateDirectories(schedulePath) 
                                      select path.Remove(0, path.LastIndexOf('\\') + 1));

      // Добавление всех рассписаний на форму
      foreach (var schedule in scheduleNames)
      {
        if (!schedules.Items.Contains(schedule))
          schedules.Items.Add(schedule);
      }


      // Установка текущего дня в календаре
      activeDay = weekInCalendar1.GetDaySchedule(DateTime.Now);
      weekInCalendar1[6 - activeDay % 7].Active = true;
      DayClick(activeDay);
    }


    // Отрисовка расписания на день
    public void DayClick(byte numberDay)
    {
      activeDay = numberDay;
      // Редактировать расписание
      //MessageBox.Show(numberDay.ToString());

      // Удаляем старое расписание на день
      for (byte i = 0; i < schedulePanel.Controls.Count; i++)
        if (schedulePanel.Controls[i].GetType() == typeof(PairInfo))
          schedulePanel.Controls.RemoveAt(i--);

      // Загружаем новое расписание на день \\
      // Если в расписании есть пары
      if (schedulesForDays[numberDay].Count > 0)
      {
        // Сортируем пары
        schedulesForDays[activeDay] = (from s in schedulesForDays[activeDay] orderby s.Number select s).ToList();
        // Добавляем на панельку
        foreach (Schedule s in schedulesForDays[numberDay])
        {
          schedulePanel.Controls.Add(new PairInfo(s));
          ((PairInfo)schedulePanel.Controls[schedulePanel.Controls.Count - 1]).PairInfoClick = PairInfoClick;
        }
      }
    }

    




    private void ScheduleSetDafaultValue()
    {
      schedulesForDays = new List<Schedule>[14];
      for (byte i = 0; i < 14; i++)
        schedulesForDays[i] = new List<Schedule>(8);
    }

    /* ------------------------------- *\
    |   Редактирование, добавление пар  |
    \* ------------------------------- */

    private PairInfo editingPairInfo;
    // Добавление новой пары в расписание дня
    private void addPair_Click(object sender, EventArgs e)
    {
      if (activeSchedule == null) return;

      Schedule newSched = new Schedule(1, "", "");
      schedulesForDays[activeDay].Add(newSched);

      PairInfo newPairInfo = new PairInfo(newSched);
      newPairInfo.PairInfoClick = PairInfoClick;
      schedulePanel.Controls.Add(newPairInfo);

      PairInfoClick(newPairInfo);
    }
    private void PairInfoClick(PairInfo pairInfo)
    {
      editingNumberPair.Value = pairInfo.Number;
      editingLectureHall.Text = pairInfo.LectureHall;
      editingNamePair.Text = pairInfo.NamePair;

      editingPairInfo = pairInfo;
      panelEditingSchedule.Visible = true;  // Отображение панели редактора
    }

    // Сохранить изменения
    private void editingSave_Click(object sender, EventArgs e)
    {
      panelEditingSchedule.Visible = false;

      editingPairInfo.Number = (byte)editingNumberPair.Value;
      editingPairInfo.LectureHall = editingLectureHall.Text;
      editingPairInfo.NamePair = editingNamePair.Text;

      DayClick(activeDay);  // Отрисовать
    }
    // Удалить пару из расписания
    private void editingRemove_Click(object sender, EventArgs e)
    {
      panelEditingSchedule.Visible = false;

      for (byte i = 0; i < schedulesForDays[activeDay].Count; i++)
        if (editingPairInfo.Schedule.Equals(schedulesForDays[activeDay][i]))
          schedulesForDays[activeDay].RemoveAt(i);

      editingPairInfo.Dispose();
    }
    // Закрыть окно редактирования без сохранения изменений
    private void editingClose_Click(object sender, EventArgs e)
    {
      panelEditingSchedule.Visible = false;
    }





    /* -------------------------------------- *\
    |   Выбор, загрузка, выгрузка расписания   |
    \* -------------------------------------- */

    private string activeSchedule;  // Активное расписание
    // Загрузка рассписания из файла
private void LoadSchedule(string scheduleName)
{
  string path = schedulePath + scheduleName + "\\" + scheduleName + ".sched";
  BinaryFormatter binFormat = new BinaryFormatter();

  // Сохранить объект в локальном файле.
  Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
  schedulesForDays = (List<Schedule>[])binFormat.Deserialize(fStream);
  fStream.Close();
}
// Сохранение рассписания в файл
private void SaveShedule(string scheduleName)
{
  string path = schedulePath + scheduleName + "\\" + scheduleName + ".sched";
  BinaryFormatter binFormat = new BinaryFormatter();

  // Сохранить объект в локальном файле.
  Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
  binFormat.Serialize(fStream, schedulesForDays);
  fStream.Close();
}
    
    // Сохранение данных перед закрытием
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (activeSchedule != null)
        SaveShedule(activeSchedule);
    }
    // Обработчик выбора расписания (comboBox)
    private void schedules_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (activeSchedule != null)
        SaveShedule(activeSchedule);

      if (activeSchedule != schedules.SelectedItem.ToString())
      {
        activeSchedule = schedules.SelectedItem.ToString();
        LoadSchedule(activeSchedule);
        DayClick(activeDay);
      }
    }
    // Клик по выбору расписания (comboBox)
    private void schedules_KeyDown(object sender, KeyEventArgs e)
    {

      // Если в окне выбора расписания ввели новое и нажали Enter
      if (e.KeyCode != Keys.Enter) 
        return;

      schedules.Text = schedules.Text.Trim();
      string path = schedulePath + schedules.Text + "\\";
      // Проверка на существование расписания
      if (Directory.Exists(path))
      {
        foreach (var i in schedules.Items)
          if (i.ToString() == schedules.Text)
            schedules.SelectedItem = i;
        return;
      }

      // Спрашиваем, если такого расписания нет
      DialogResult result = MessageBox.Show(
        "Создать новое рассписание?",
        "Сообщение",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);


      // Создаем новое рассписание
      if (result == DialogResult.Yes)
      {
        if (activeSchedule != null)
          SaveShedule(activeSchedule);

        Directory.CreateDirectory(path);
        activeSchedule = schedules.Text;

        ScheduleSetDafaultValue();
        schedules.Items.Add(schedules.Text);
        schedules.SelectedItem = schedules.Items.Count - 1;
      }
      // Иначе очищаем поле
      else { schedules.Text = ""; }
    }
  }
}
