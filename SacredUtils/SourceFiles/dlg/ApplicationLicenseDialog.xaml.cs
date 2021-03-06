﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using SacredUtils.SourceFiles.bin;

namespace SacredUtils.resources.dlg
{
    public partial class ApplicationLicenseDialog
    {
        public ApplicationLicenseDialog() => InitializeComponent();

        private void CloseSacredUtilsBtn_Click(object sender, RoutedEventArgs e) => Process.GetCurrentProcess().Kill();
        
        private void ReadLicenseBtn_Click(object sender, RoutedEventArgs e) => Process.Start("License.txt");

        private void AcceptLicenseBtn_Click(object sender, RoutedEventArgs e)
        {
            BaseDialog.IsOpen = false;

            File.WriteAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su", "true");
            
            MainWindow.MainWindowInstance.UpdateLbl.IsEnabled = true;
            MainWindow.MainWindowInstance.MinimizeBtn.IsEnabled = true;

            GetChangeLogDialogVisibility.Get();
        }
    }
}
