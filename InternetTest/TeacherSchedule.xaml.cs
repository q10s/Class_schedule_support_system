using InternetTest.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace InternetTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeacherSchedule : Page
    {
        public static int teacherId = -1;

        public TeacherSchedule()
        {
            this.InitializeComponent();            
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (teacherId == -1)
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                if (localSettings.Values.ContainsKey("teacherFIO"))
                {
                    var teacherFIO = localSettings.Values["teacherFIO"].ToString();
                    var teacher = MainPage.schedule.teachers.FirstOrDefault(t => t.FIO == teacherFIO);
                    if (teacher != null)
                    {
                        teacherId = teacher.TeacherId;
                    }
                }
                else
                {
                    if (MainPage.schedule.teachers.Count > 0)
                    {
                        teacherId = MainPage.schedule.teachers[0].TeacherId;
                    }
                }
            }

            ShowTeacherSchedule();
        }

        private void ShowTeacherSchedule()
        {
            Dictionary<int, Dictionary<int, List<WeekScheduleLesson>>> weekLessons = GetGroupedByWeekTeacher(teacherId);
            var teacher = MainPage.schedule.teachers.Where(t => t.TeacherId == teacherId).FirstOrDefault();
            String teacherFIO = "";
            if (teacher != null)
            {
                teacherFIO = teacher.FIO;
            }

            mainPivot.Title = teacherFIO;

            mainPivot.Items.Clear();

            for (int week = 1; week <= 18; week++)
            {
                //add on the fly pivots
                PivotItem myNewPivotItem = new PivotItem();
                myNewPivotItem.Name = "week_" + week;

                //ID of the pivot 
                myNewPivotItem.Header = week;

                ScrollViewer weekItem = new ScrollViewer();
                weekItem.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                weekItem.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;

                StackPanel mainPanel = new StackPanel();
                mainPanel.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                mainPanel.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
                mainPanel.Orientation = Orientation.Vertical;
                mainPanel.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 114, 170, 255));

                if (weekLessons.ContainsKey(week))
                {
                    foreach (var dowLessons in weekLessons[week])
                    {
                        var dowText = new TextBlock();
                        dowText.Text = Constants.dowLocal[dowLessons.Key] + " (" + dowLessons.Value[0].Date + ")";
                        dowText.TextWrapping = TextWrapping.Wrap;
                        dowText.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                        dowText.FontSize = 14;

                        var dowTextPanel = new StackPanel();
                        dowTextPanel.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 114, 204, 221));
                        dowTextPanel.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                        dowTextPanel.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
                        dowTextPanel.Orientation = Orientation.Vertical;
                        dowTextPanel.Children.Add(dowText);

                        mainPanel.Children.Add(dowTextPanel);

                        foreach (var dowl in dowLessons.Value)
                        {
                            var lessonGrid = new Grid();
                            var col1 = new ColumnDefinition();
                            col1.Width = new GridLength(70);
                            lessonGrid.ColumnDefinitions.Add(col1);
                            var col2 = new ColumnDefinition();
                            lessonGrid.ColumnDefinitions.Add(col2);

                            var timeText = new TextBlock();
                            timeText.Text = dowl.Time;
                            timeText.FontSize = 20;
                            timeText.Width = 60;
                            timeText.Margin = new Thickness(5);
                            timeText.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                            Grid.SetRow(timeText, 0);
                            Grid.SetColumn(timeText, 0);
                            lessonGrid.Children.Add(timeText);
                                                        

                            var lessonData = new TextBlock();
                            lessonData.TextWrapping = TextWrapping.Wrap;
                            lessonData.Text = dowl.StudentGroupName +
                                Environment.NewLine + dowl.DisciplineName +
                                Environment.NewLine + dowl.AuditoriumName;
                            lessonData.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                            lessonData.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Top;
                            Grid.SetRow(lessonData, 0);
                            Grid.SetColumn(lessonData, 1);
                            lessonGrid.Children.Add(lessonData);

                            mainPanel.Children.Add(lessonGrid);
                        }
                    }
                }

                weekItem.Content = mainPanel;


                myNewPivotItem.Content = weekItem;

                //add pivot to main list
                mainPivot.Items.Add(myNewPivotItem);
            }

            var semesterStartsString = MainPage.schedule.configOptions.FirstOrDefault(co => co.Key == "Semester Starts").Value;
            var start = DateTime.ParseExact(semesterStartsString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var diff = DateTime.Now - start;
            if ((diff.TotalDays > 0) && (diff.TotalDays < 18 * 7))
            {
                var week = ((int)diff.TotalDays / 7) + 1;
                mainPivot.SelectedIndex = week - 1;
            }
        }

        private Dictionary<int, Dictionary<int, List<WeekScheduleLesson>>> GetGroupedByWeekTeacher(int teacherId)
        {
            var result = new Dictionary<int, Dictionary<int, List<WeekScheduleLesson>>>();

            var semesterStartsString = MainPage.schedule.configOptions.FirstOrDefault(co => co.Key == "Semester Starts").Value;

            var primaryList = MainPage.schedule.lessons
                .Where(l => l.TeacherForDiscipline.Teacher.TeacherId == teacherId &&
                            l.IsActive)
                .ToList();

            var groupedLessons = primaryList
                    .GroupBy(l => Utilities.CalculateWeekNumber(semesterStartsString, l.Calendar.Date.Date),
                    (w, wl) => new
                    {
                        week = w,
                        weekLessons = wl
                        .GroupBy(l => Constants.DowRemap[(int)(l.Calendar.Date).DayOfWeek] * 2000 +
                            l.Ring.Time.Hour * 60 + l.Ring.Time.Minute,
                            (dowTime, lessons) =>
                            new
                            {
                                DOW = dowTime / 2000,
                                time = ((dowTime - (dowTime / 2000) * 2000) / 60).ToString("D2") + ":" + ((dowTime - (dowTime / 2000) * 2000) - ((dowTime - (dowTime / 2000) * 2000) / 60) * 60).ToString("D2"),
                                Groups = lessons.GroupBy(ls => ls.TeacherForDiscipline.TeacherForDisciplineId.ToString(),
                                    (tfdId, tfdLessons) =>
                                    new
                                    {
                                        TfdId = tfdId,
                                        Lesson = tfdLessons.FirstOrDefault()
                                    }
                                ).ToList()
                            }
                            ).OrderBy(l => l.DOW * 2000 + int.Parse(l.time.Split(':')[0]) * 60 + int.Parse(l.time.Split(':')[1]))
                            .ToList()
                    })
                    .OrderBy(o => o.week).ToList();

            foreach (var weekItem in groupedLessons)
            {
                result.Add(weekItem.week, new Dictionary<int, List<WeekScheduleLesson>>());

                foreach (var dowTimeItem in weekItem.weekLessons)
                {
                    foreach (var group in dowTimeItem.Groups)
                    {
                        var wsl = new WeekScheduleLesson();
                        wsl.Dow = dowTimeItem.DOW;
                        wsl.Time = dowTimeItem.time;

                        wsl.AuditoriumName = group.Lesson.Auditorium.Name;
                        wsl.DisciplineName = group.Lesson.TeacherForDiscipline.Discipline.Name;
                        wsl.StudentGroupName = group.Lesson.TeacherForDiscipline.Discipline.StudentGroup.Name;
                        wsl.TeacherFio = group.Lesson.TeacherForDiscipline.Teacher.FIO;
                        wsl.Date = group.Lesson.Calendar.Date.ToString("dd.MM.yyyy");

                        if (!result[weekItem.week].ContainsKey(wsl.Dow))
                        {
                            result[weekItem.week].Add(wsl.Dow, new List<WeekScheduleLesson>());
                        }

                        result[weekItem.week][wsl.Dow].Add(wsl);
                    }
                }
            }

            return result;
        }

        private void ShowGroupSchedule(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void ShowSessionSchedule(object sender, RoutedEventArgs e)
        {

        }

        private void ChooseTeacher(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TeachersList), MainPage.schedule.teachers.OrderBy(t => t.FIO).ToList());
        }
    }
}
