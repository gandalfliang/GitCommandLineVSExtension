using System.Windows;
using System.Windows.Controls;

namespace GitConsoleExtension
{
    /// <summary>
    /// ConsoleHostControl.xaml 的交互逻辑
    /// </summary>
    public partial class ConsoleHostControl : UserControl
    {
        private NativeGitConsoleHost _leftHost;
        private NativeGitConsoleHost _rightHost;

        public ConsoleHostControl()
        {
            InitializeComponent();
        }

        private void Splitview_Clicked(object sender, RoutedEventArgs e)
        {
            SplitView();
        }

        public void LoadMinttyHost()
        {
            if (_leftHost == null)
            {
                _leftHost = new NativeGitConsoleHost();
                LeftCol.Children.Add(_leftHost);
            }
        }

        private void SplitView()
        {
            if (_rightHost != null)
            {
                RightColumnDef.Width = GridLength.Auto;
                CleanRight();
                return;
            }

            if(_rightHost==null)
                _rightHost=new NativeGitConsoleHost();
            RightColumnDef.Width= new GridLength(1, GridUnitType.Star);
            RightCol.Children.Add(_rightHost);
        }

        private void CleanRight()
        {
            if (_rightHost != null)
            {
                RightCol.Children.Remove(_rightHost);
                _rightHost.Reset();
                _rightHost = null;
            }
        }

        private void CleanLeft()
        {
            if (_leftHost != null)
            {
                LeftCol.Children.Remove(_leftHost);
                _leftHost.Reset();
                _leftHost = null;
            }
        }

        public void Clean()
        {
            CleanLeft();
            CleanRight();
        }
    }
}
