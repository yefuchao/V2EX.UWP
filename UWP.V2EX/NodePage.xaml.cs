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
    public sealed partial class NodePage : Page
    {
        public ObservableCollection<ThemeObject> NodetopicList { get; set; }

        public NodePage()
        {
            this.InitializeComponent();

            NodetopicList = new ObservableCollection<ThemeObject>();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
                        
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            var nodename = (string)e.Parameter;

            try
            {
                Task t = V2EXAPIProxy.GetNodeByUsernameAsync(NodetopicList, nodename);
                await t;
            }
            catch (Exception)
            {

                throw;
            }

            Nodename.Text = nodename;
        }

        private void NodeTopic_View_ItemClick(object sender, ItemClickEventArgs e)
        {
            var topic = (ThemeObject)e.ClickedItem;
            Frame.Navigate(typeof(Topic), topic);
        }

    }
}
