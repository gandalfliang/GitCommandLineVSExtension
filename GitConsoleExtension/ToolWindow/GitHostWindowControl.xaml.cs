//------------------------------------------------------------------------------
// <copyright file="GitHostWindowControl.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace GitConsoleExtension
{
    /// <summary>
    /// Interaction logic for GitHostWindowControl.
    /// </summary>
    public partial class GitHostWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GitHostWindowControl"/> class.
        /// </summary>
        public GitHostWindowControl()
        {
            this.InitializeComponent();
            
            Loaded += GitHostWindowControl_Loaded;
        }

        private void GitHostWindowControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Config.Instance.MinttyPath) || !File.Exists(Config.Instance.MinttyPath))
            {
                InfoStackpanel.Visibility = Visibility.Visible;
            }
            else
            {
                ConsoleHost.LoadMinttyHost();
            }
        }

        private void Select_Mintty_clicked(object sender, RoutedEventArgs e)
        {
            var dialog=new OpenFileDialog();
            dialog.FileName = "mintty.exe";
            if (dialog.ShowDialog() == true)
            {
                if (dialog.SafeFileName == "mintty.exe")
                {
                    Config.Instance.MinttyPath = dialog.FileName;
                    ConsoleHost.LoadMinttyHost();
                }
            }
        }

        public void Clean()
        {
            ConsoleHost.Clean();
        }
    }
}