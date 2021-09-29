using ButtonUpdate.Model;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ButtonUpdate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        UpdateManager manager;

        public MainWindow()
        {
            InitializeComponent();

            GetVersion();
            Loaded += Load;

        }

        public void GetVersion()
        {
            Assembly assemly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assemly.Location);

            Dispatcher.Invoke(() =>
            {
                this.Title += $"v + {fileVersionInfo.FileVersion}";
            });
        }

        private async void HasUpdates()
        {
            Task<UpdateInfo> updateInfo = manager.CheckForUpdate();

            if (updateInfo.Result.ReleasesToApply.Count > 0)
            {
                Update();
            }
            else
            {
                MessageBox.Show("No updates found!");
            }

        }

        private async void Load(object sender, RoutedEventArgs e)
        {
            manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/Olezha228/ButttonUpdateClick");
        }

        private async void Update()
        {
            await manager.UpdateApp();

            MessageBox.Show("Выкл и вкл чтобы работало!");
        }



    }
}
