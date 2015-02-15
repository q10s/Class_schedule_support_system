using InternetTest.Core;
using Newtonsoft.Json;
using NUDispSchedule.Main;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace InternetTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Schedule schedule;
        public static int groupId = -1;
        public static bool netAvailable = false;
        public ProgressRing progress;
        public Pivot mainPivot;

        public String defaultGroupName = "12 А";

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            bool scheduleFileExists = await ApplicationData.Current.LocalFolder.FileExists("schedule.txt");
            bool scheduleDateFileExists = await ApplicationData.Current.LocalFolder.FileExists("scheduleDateTime.txt");
            DateTime scheduleDate = new DateTime(2000, 1, 1);
            bool NeedToReloadSchedule = true;

            if (scheduleDateFileExists)
            {
                NeedToReloadSchedule = false;

                var folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await folder.GetFileAsync("scheduleDateTime.txt");
                var contents = await Windows.Storage.FileIO.ReadTextAsync(file);

                try
                {
                    scheduleDate = DateTime.ParseExact(contents, "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture);

                    if ((DateTime.Now - scheduleDate).TotalMinutes > 30)
                    {
                        NeedToReloadSchedule = true;
                    }
                    else
                    {
                        if (schedule == null)
                        {
                            ShowLoading();

                            schedule = await Schedule.LoadScheduleFromFile();

                            ReadyToShow();
                        }
                    }

                }
                catch
                {
                    NeedToReloadSchedule = true;
                    throw;
                }                
            }

            if (NeedToReloadSchedule)
            {
                try
                {
                    ShowLoading();

                    await LoadSchedule();

                    ReadyToShow();

                    netAvailable = true;
                }
                catch
                {
                    netAvailable = false;
                }


                if (!netAvailable)
                {
                    if (scheduleFileExists)
                    {
                        ShowLoading();

                        schedule = await Schedule.LoadScheduleFromFile();

                        ReadyToShow();
                    }
                    else
                    {
                        ReadyToShow();

                        mainPivot.Title = "Нет сети";
                        return;
                    }
                }
            }  
            else
            {
                ReadyToShow();
            }
       
            if (groupId == -1)
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                if (localSettings.Values.ContainsKey("studentGroupName"))
                {
                    var groupName = localSettings.Values["studentGroupName"].ToString();
                    var group = MainPage.schedule.studentGroups.FirstOrDefault(sg => sg.Name == groupName);
                    if (group != null)
                    {
                        groupId = group.StudentGroupId;
                    }
                }
                else
                {
                    var g = schedule.studentGroups.Where(sg => sg.Name == defaultGroupName).FirstOrDefault();
                    if (g != null)
                    {
                        groupId = g.StudentGroupId;
                    }
                }
            }

            ShowGroupSchedule();
        }

        private void ReadyToShow()
        {
            mainPivot = new Pivot();
            mainPivot.Name = "mainPivot";
            mainPivot.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 106, 223));
            this.Content = mainPivot;
        }

        private void ShowLoading()
        {
            var alignGrid = new Grid();
            alignGrid.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
            alignGrid.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Stretch;
            alignGrid.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 199, 73));

            var progressPanel = new StackPanel();
            progressPanel.Orientation = Orientation.Vertical;
            progressPanel.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
            progressPanel.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center;


            var splashImage = new Image();
            splashImage.Source = new BitmapImage { UriSource = new Uri("ms-appx:///Assets/WideLogo.png", UriKind.Absolute) };
            progressPanel.Children.Add(splashImage);

            progress = new ProgressRing();
            progress.Margin = new Thickness(20);
            progress.IsActive = true;
            progress.Foreground = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 240, 240, 240));
            progress.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 199, 73));
            progressPanel.Children.Add(progress);

            alignGrid.Children.Add(progressPanel);

            this.Content = alignGrid;
        }

        private async Task LoadSchedule()
        {
            HttpClient http = new System.Net.Http.HttpClient();
            HttpResponseMessage response = await http.GetAsync("http://wiki.nayanova.edu/api.php?action=bundle");
            String webresponse = await response.Content.ReadAsStringAsync();

            WebSchedule ws = JsonConvert.DeserializeObject<WebSchedule>(webresponse);
            schedule = Schedule.FromWebSchedule(ws);
            await schedule.SaveScheduleToFile();

            var scheduleTime = DateTime.Now.ToString("dd.MM.yyyy H:mm:ss");
            var appFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var tempFile = await appFolder.CreateFileAsync("scheduleDateTime.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(tempFile, scheduleTime);
        }

        private void ShowGroupSchedule()
        {
            Dictionary<int, Dictionary<int, List<WeekScheduleLesson>>> weekLessons = GetGroupedByWeekLesson(groupId);
            var group = schedule.studentGroups.Where(sg => sg.StudentGroupId == groupId).FirstOrDefault();
            String groupName = "";
            if (group != null)
            {
                groupName = group.Name;
            }

            mainPivot.Title = groupName;

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

                            var discNameWithGroup = dowl.DisciplineName;
                            if (dowl.StudentGroupName != groupName)
                                discNameWithGroup += " (" + dowl.StudentGroupName + ")";

                            var lessonData = new TextBlock();
                            lessonData.TextWrapping = TextWrapping.Wrap;
                            lessonData.Text = discNameWithGroup +
                                Environment.NewLine + dowl.TeacherFio +
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

            var semesterStartsString = schedule.configOptions.FirstOrDefault(co => co.Key == "Semester Starts").Value;
            var start = DateTime.ParseExact(semesterStartsString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var diff = DateTime.Now - start;
            if ((diff.TotalDays > 0) && (diff.TotalDays < 18*7))
            {
                var week = ((int)diff.TotalDays / 7) + 1;
                mainPivot.SelectedIndex = week - 1;
            }
        }

        private Dictionary<int, Dictionary<int, List<WeekScheduleLesson>>> GetGroupedByWeekLesson(int groupId)
        {
            var result = new Dictionary<int, Dictionary<int, List<WeekScheduleLesson>>>();

            var semesterStartsString = schedule.configOptions.FirstOrDefault(co => co.Key == "Semester Starts").Value;

            var studentIds = schedule.studentsInGroups
                    .Where(sig => sig.StudentGroup.StudentGroupId == groupId)
                    .ToList()
                    .Select(stig => stig.Student.StudentId);
            var groupsListIds = schedule.studentsInGroups
                .Where(sig => studentIds.Contains(sig.Student.StudentId))
                .ToList()
                .Select(stig => stig.StudentGroup.StudentGroupId);

            var primaryList = schedule.lessons
                    .Where(l =>
                        groupsListIds.Contains(l.TeacherForDiscipline.Discipline.StudentGroup.StudentGroupId) && 
                        (l.IsActive))
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

        private void ShowTeacherSchedule(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TeacherSchedule));
        }

        private void ShowSessionSchedule(object sender, RoutedEventArgs e)
        {

        }

        private void ChooseGroup(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GroupsList), schedule.studentGroups);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            
            deferral.Complete();
        }
    }    
}
