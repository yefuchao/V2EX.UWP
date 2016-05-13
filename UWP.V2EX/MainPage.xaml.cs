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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP.V2EX
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<ThemeObject> hots { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            hots = new ObservableCollection<ThemeObject>();
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                Task t = V2EXAPIProxy.GetHotThemsAsync(hots);
                await t;
            }
            catch (Exception)
            {
                throw;
             //   Hot_Title.Text = "加载失败！";
            }

        }

        private void hotsView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var topic = (ThemeObject)e.ClickedItem;
            Frame.Navigate(typeof(Topic),topic);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HomePage));
        }

        private void NodeButton_Click(object sender, RoutedEventArgs e)
        {
            var nodename = (sender as Button).Content;
            Frame.Navigate(typeof(NodePage),nodename);
        }
    }
}
