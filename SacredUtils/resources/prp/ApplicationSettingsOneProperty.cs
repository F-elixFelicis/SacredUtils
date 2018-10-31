﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using WPFSharp.Globalizer;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.prp
{
    public class ApplicationSettingsOneProperty
    {
        public int Language
        {
            get
            {
                if (AppSettings.ApplicationSettings.AppUiLanguage == "based on system")
                {
                    return CultureInfo.InstalledUICulture.TwoLetterISOLanguageName == "ru" ? 0 : 1;
                }

                return AppSettings.ApplicationSettings.AppUiLanguage == "ru" ? 0 : 1;
            }

            set
            {
                if (value == 0)
                {
                    AppSettings.ApplicationSettings.AppUiLanguage = "ru";

                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("ru-RU", true);

                    Log.Info("SacredUtils application language changed state to ru by user");
                }

                if (value == 1)
                {
                    AppSettings.ApplicationSettings.AppUiLanguage = "en";

                    GlobalizedApplication.Instance.GlobalizationManager.SwitchLanguage("en-US", true);

                    Log.Info("SacredUtils application language changed state to en by user");
                }
            }
        }
        
        public int Theme
        {
            get => AppSettings.ApplicationSettings.ColorTheme == "light" ? 0 : 1;

            set
            {
                if (value == 0)
                {
                    AppSettings.ApplicationSettings.ColorTheme = "light";

                    GlobalizedApplication.Instance.StyleManager.SwitchStyle("light.xaml");

                    Log.Info("SacredUtils application theme changed state to light by user");
                }

                if (value == 1)
                {
                    AppSettings.ApplicationSettings.ColorTheme = "dark";

                    GlobalizedApplication.Instance.StyleManager.SwitchStyle("dark.xaml");

                    Log.Info("SacredUtils application theme changed state to dark by user");
                }
            }
        }

        public int StartParams
        {
            get => AppSettings.ApplicationSettings.SacredStartArgs;

            set
            {
                AppSettings.ApplicationSettings.SacredStartArgs = value;

                Log.Info($"Sacred game startup params changed to {value} by user");
            }
        }

        public string UiScale
        {
            get => $"{Convert.ToInt32(AppSettings.ApplicationSettings.SacredUtilsGuiScale * 100)}%";

            set
            {
                ChangeScale(Convert.ToDouble(value.Replace("%", "")) / 100D);
                Log.Info($"SacredUtils Ui scale changed state to {value} by user");
            }
        }

        private static void ChangeScale(double scale)
        {
            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).Height = 720 * scale;
                ((MainWindow)window).Width = 1086 * scale;
                ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(scale, scale);
            }

            AppSettings.ApplicationSettings.SacredUtilsGuiScale = scale;
        }
    }
}
