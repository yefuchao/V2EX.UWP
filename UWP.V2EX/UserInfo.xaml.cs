using System;
using System.Collections.Generic;
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
    public sealed partial class UserInfo : Page
    {
        public UserObject user { get; set; }

        public UserInfo()
        {
            this.InitializeComponent();

            user = new UserObject();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //base.OnNavigatedTo(e);
            var username = (string)e.Parameter;

            try
            {
                Task t = V2EXAPIProxy.GetUserInfoAsync(user, username);
                await t;
            }
            catch (Exception)
            {

                throw;
            }

            //UserName.Text = user.username;
            UserName.Text = username;
        }
    }
}
