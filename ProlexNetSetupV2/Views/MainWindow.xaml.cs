﻿using MahApps.Metro.Controls;
using System.Net;
using System.Windows;

namespace ProlexNetSetupV2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void UpdateDownloadProgress(DownloadProgressChangedEventArgs args)
        {
            // Progressbar dos downloads
            Dispatcher.Invoke(() =>
            {
                //ProgressBar.Maximum = args.TotalBytesToReceive;
                //ProgressBar.Value = args.BytesReceived;
                //ProgressBarValue.Content = args.ProgressPercentage + "%";

                //decimal total = args.TotalBytesToReceive;
                //decimal received = args.BytesReceived;
                //ProgressBarSpeed.Content = $"{(received / 1048576):n3} MB / {(total / 1048576):n3} MB";
            });
        }
    }
}