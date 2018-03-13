﻿using Newtonsoft.Json;
using ProlexNetSetupV2.Models;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace ProlexNetSetupV2.Library
{
    internal class DownloadParameters
    {
        public static ApplicationList Instance { get; private set; }

        public static async Task ApplicationListAsync()
        {
            WebClient client = new WebClient();

            try
            {
                var json = await client.DownloadStringTaskAsync(Constants.DownloadServerUrl);
                Instance = JsonConvert.DeserializeObject<ApplicationList>(json);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{nameof(DownloadParameters)}:{nameof(ApplicationListAsync)}:{ex.Message}");
                MessageBox.Show("Servidor de downloads fora do ar. Informe ao setor de desenvolvimento.", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
        }
    }
}