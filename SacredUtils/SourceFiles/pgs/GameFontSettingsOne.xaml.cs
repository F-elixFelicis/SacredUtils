﻿using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using SacredUtils.SourceFiles.bin;
using SacredUtils.SourceFiles.dlg;
using SacredUtils.SourceFiles.prp;
using SacredUtils.SourceFiles.settings;
using Theme = SacredUtils.SourceFiles.theme.Theme;

namespace SacredUtils.SourceFiles.pgs
{
    public partial class GameFontSettingsOne
    {
        public GameFontSettingsOne()
        {
            InitializeComponent(); DataContext = new GameFontSettingsOneProperty();

            if (!ApplicationSettingsManager.Settings.UseCustomFontSizeValue)
            {
                Border1.Margin = new Thickness(0, 169, 0, 0);
                Border2.Margin = new Thickness(0, 220, 0, 0);
                Border3.Margin = new Thickness(0, 271, 0, 0);
                Border4.Visibility = Visibility.Collapsed;
                Border5.Margin = new Thickness(0, 373, 0, 0);
                Border6.Margin = new Thickness(38, 322, 447, 0);
                Border7.Margin = new Thickness(446, 322, 38, 0);
            }
            else
            {
                FontSizesTxBox.Text = ApplicationSettingsManager.Settings.SacredFontSizeArray;

                FontSizesTxBox.TextChanged += (s, e) => ChangeSizeForFont();
                FontSizesTxBox.PreviewTextInput += ValidateValue;
            }

            Logger.Log.Info("Initialization components for game font settings one done!");
        }

        private void ValidateValue(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^0-9|]+").IsMatch(e.Text);

        private void FontNameCmbBox_DropDownClosed(object sender, EventArgs e) => GC.Collect();
        
        private void ChangeSizeForFont()
        {
            FontSizesTxBox.Text = FontSizesTxBox.Text.Replace(" ", "");

            ApplicationSettingsManager.Settings.SacredFontSizeArray = FontSizesTxBox.Text;

            if (FontNameCmbBox.Text == "") { return; }

            ChangeSacredGameSettingsValue.ChangeSettingFontValue(FontNameCmbBox.Text);
        }

        private void InstallDefaultFontsButton_Click(object sender, RoutedEventArgs e) => InstallDefaultSacredGameFonts.Install();

        private void RemoveConfigurableFontsButton_Click(object sender, RoutedEventArgs e) => RemoveSacredGameConfigFonts.Remove();

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ApplicationFontSizesDialog applicationFontSizesDialog = new ApplicationFontSizesDialog();

            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationFontSizesDialog;

            if (ApplicationSettingsManager.Settings.ApplicationUiTheme == Theme.Dark)
            {
                applicationFontSizesDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }
            
            applicationFontSizesDialog.BaseDialog.IsOpen = true;
        }
    }
}
