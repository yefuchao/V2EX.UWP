using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWP.V2EX.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.V2EX
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Topic : Page
    {
        public ObservableCollection<ReplyObject> replys { get; set; }


        public Topic()
        {
            this.InitializeComponent();

            replys = new ObservableCollection<ReplyObject>();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            var topic = (ThemeObject)e.Parameter;

            try
            {
                Task t = V2EXAPIProxy.GetReplaysAsync(replys,topic.id);
                await t;
            }
            catch (Exception)
            {

                throw;
            }

            Title.Text = topic.title;
            Contents.Text = topic.content;
            //Avar.Source = topic.member.avatar_large;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
