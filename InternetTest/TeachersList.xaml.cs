using NUDispSchedule.Main;
using System;
using System.Collections.Generic;
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
    public sealed partial class TeachersList : Page
    {
        public TeachersList()
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
            var teachers = (List<Teacher>)e.Parameter;

            teacherList.Items.Clear();
            foreach (var teacher in teachers)
            {
                teacherList.Items.Add(teacher);
            }
        }

        private void teacherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var teacher = (Teacher)e.AddedItems[0];

            TeacherSchedule.teacherId = teacher.TeacherId;

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["teacherFIO"] = teacher.FIO;

            Frame.GoBack();
        }
    }
}
