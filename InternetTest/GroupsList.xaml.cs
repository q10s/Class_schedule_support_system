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
    public sealed partial class GroupsList : Page
    {
        public GroupsList()
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
            var groups = (List<StudentGroup>) e.Parameter;

            groups = groups
                .Where(sg =>                    
                    !sg.Name.Contains('I') && !sg.Name.Contains('-') &&
                    !sg.Name.Contains('+') && !sg.Name.Contains(".)"))
                .OrderBy(g => g.Name)
                .ToList();
            
            groupList.Items.Clear();
            foreach (var group in groups)
            {
                groupList.Items.Add(group);
            }            
            
        }

        private void groupList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var group = (StudentGroup)e.AddedItems[0];

            MainPage.groupId = group.StudentGroupId;

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["studentGroupName"] = group.Name;

            Frame.GoBack();
        }
    }
}
