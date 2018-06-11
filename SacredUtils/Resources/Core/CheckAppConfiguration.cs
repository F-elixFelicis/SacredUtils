﻿using System;
using System.IO;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    public class CheckAppConfiguration
    {
        public void GetAvailableAppConfig() // Проверяем наличие конфигураций.
        {
            Log.Info("Проверяем наличие файла конфигурации SacredUnderworld.");

            if (!File.Exists(SacredSettings))  
            {
                Log.Warn("Файл конфигурации SacredUnderworld не был найден в директории.");

                Log.Info("Создаем файл конфигурации SacredUnderworld из ресурсов SacredUtils.");

                try
                {
                    File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);

                    Log.Info("Файл конфигурации SacredUnderworld был создан без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Fatal("При создании файла конфигурации SacredUnderworld произошла ошибка."); Log.Fatal(exception.ToString());

                    Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
                }
            }
            else if(File.Exists(SacredSettings))
            {
                Log.Info("Файл конфигурации SacredUnderworld был найден, продолжаем работу.");
            }

            if (File.Exists(SacredSettings) && File.Exists(AppSettings))
            {
                var fileText = File.ReadAllText(AppSettings);
                
                var fileTextSacred = File.ReadAllText(SacredSettings);
                
                Log.Info("Получаем статус активности функции \"Автовостановление настроек\"");

                try
                {
                    if (fileText.Contains("Restore Settings.cfg if it is corrupted = true"))
                    {
                        Log.Info("Функция \"Автовостановление настроек\" включена, продолжаем работу.");

                        Log.Info("Получаем статус о целостности нужных для игры функций.");

                        if (!fileTextSacred.Contains("COMPAT_VIDEO") || !fileTextSacred.Contains("DEFAULT_SKILLS") ||
                            !fileTextSacred.Contains("DETAILLEVEL") || !fileTextSacred.Contains("FONTAA") ||
                            !fileTextSacred.Contains("FONTFILTER") || !fileTextSacred.Contains("FSAA_FILTER") ||
                            !fileTextSacred.Contains("FULLSCREEN") || !fileTextSacred.Contains("GFX32") ||
                            !fileTextSacred.Contains("LANGUAGE") || !fileTextSacred.Contains("MUSICVOLUME") ||
                            !fileTextSacred.Contains("PICKUPANIM") || !fileTextSacred.Contains("PICKUPAUTO") ||
                            !fileTextSacred.Contains("SFXVOLUME") || !fileTextSacred.Contains("SHOWMOVIE") ||
                            !fileTextSacred.Contains("SHOWPOTIONS") || !fileTextSacred.Contains("SHOW_ENEMYINFO") ||
                            !fileTextSacred.Contains("SOUND") || !fileTextSacred.Contains("SOUNDQUALITY") ||
                            !fileTextSacred.Contains("VOICEVOLUME") || !fileTextSacred.Contains("WARNING_LEVEL"))
                        {
                            Log.Warn("Файл конфигурации SacredUnderworld поврежден, мы его восстановим.");

                            Log.Info("Восстанавливаем файл конфигурации SacredUnderworld.");

                            try
                            {
                                File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);

                                Log.Info("Файл конфигурации SacredUnderworld был восстановлен без ошибок.");
                            }
                            catch (Exception exception)
                            {
                                Log.Error("Проверка на ошибки в файле Settings.cfg завершилось с ошибкой."); Log.Error(exception.ToString());
                            }
                        }
                        else
                        {
                            Log.Info("Файл конфигурации SacredUnderworld не содержит ошибок.");
                        }
                    }
                    else if (fileText.Contains("Restore Settings.cfg if it is corrupted = false"))
                    {
                        Log.Info("Функция \"Автовостановление настроек\" выключена, продолжаем работу.");
                    }
                }
                catch (Exception exception)
                {
                    Log.Error("Получение статуса активности функции \"Автовостановление настроек\" завершилось с ошибкой."); Log.Error(exception.ToString());
                }
            }
            else if (!File.Exists(SacredSettings) || !File.Exists(AppSettings))
            {
                Log.Error("Получение статуса активности функции \"Автовостановление настроек\" завершилось с ошибкой.");
            }

            if (!File.Exists(AppSettings))
            {
                Log.Warn("Файл конфигурации SacredUtils не был найден в директории.");

                Log.Info("Создаем файл конфигурации SacredUtils из ресурсов SacredUtils.");

                try
                {
                    File.WriteAllBytes(AppSettings, Properties.Resources.AppSettings);

                    Log.Info("Файл конфигурации SacredUtils был создан без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Fatal("При создании файла конфигурации SacredUtils произошла ошибка."); Log.Fatal(exception.ToString());

                    Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
                }
            }
            else if (File.Exists(AppSettings))
            {
                Log.Info("Файл конфигурации SacredUtils был найден, продолжаем работу.");
            }
        }
    }
}
