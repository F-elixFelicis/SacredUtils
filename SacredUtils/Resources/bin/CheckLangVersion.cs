﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;
using static SacredUtils.Resources.bin.LanguageConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class CheckLangVersion
    {
        public async Task GetLanguageVersionAsync()
        {
            if (!File.Exists(".SacredUtilsData\\LangVersion.su"))
            {
                File.WriteAllBytes(".SacredUtilsData\\LangVersion.su", Properties.Resources.LangVersion);
            }

            var strings = File.ReadAllLines(".SacredUtilsData\\LangVersion.su", Encoding.ASCII);

            if (!strings[3].Contains("; Current language version = 1"))
            {
                if (String0001 == "Вы обновитесь до версии")
                {
                    System.Random rnd = new System.Random();

                    int rndInt = rnd.Next(220618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_ru_id_{rndInt}.dat"));

                    await Task.Run(() => File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageru));

                    await CreateTempInfoFile("Update", AppLngDataFile, $"{AppLngBackupFolder}\\language_ru_id_{rndInt}.dat");

                    await Task.Run(() => File.WriteAllBytes(".SacredUtilsData\\LangVersion.su", Properties.Resources.LangVersion));

                    Process.Start(AppnameFile); Environment.Exit(0);
                }

                if (String0001 == "You updating to version")
                {
                    System.Random rnd = new System.Random();

                    int rndInt = rnd.Next(220618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_en_id_{rndInt}.dat"));

                    await Task.Run(() => File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageen));

                    await CreateTempInfoFile("Update", AppLngDataFile, $"{AppLngBackupFolder}\\language_en_id_{rndInt}.dat");

                    await Task.Run(() => File.WriteAllBytes(".SacredUtilsData\\LangVersion.su", Properties.Resources.LangVersion));

                    Process.Start(AppnameFile); Environment.Exit(0);
                }

                if (String0001 == "Sie aktualisieren auf Version")
                {
                    System.Random rnd = new System.Random();

                    int rndInt = rnd.Next(220618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_de_id_{rndInt}.dat"));

                    await Task.Run(() => File.WriteAllBytes(AppLngDataFile, Properties.Resources.languagede));

                    await CreateTempInfoFile("Update", AppLngDataFile, $"{AppLngBackupFolder}\\language_de_id_{rndInt}.dat");

                    await Task.Run(() => File.WriteAllBytes(".SacredUtilsData\\LangVersion.su", Properties.Resources.LangVersion));

                    Process.Start(AppnameFile); Environment.Exit(0);
                }

                if (String0001 == "")
                {
                    System.Random rnd = new System.Random();

                    int rndInt = rnd.Next(220618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_any_id_{rndInt}.dat"));

                    await Task.Run(() => File.Delete(AppLngDataFile));

                    await CreateTempInfoFile("Update", AppLngDataFile, $"{AppLngBackupFolder}\\language_any_id_{rndInt}.dat");

                    await Task.Run(() => File.WriteAllBytes(".SacredUtilsData\\LangVersion.su", Properties.Resources.LangVersion));

                    Process.Start(AppnameFile); Environment.Exit(0);
                }
            }
        }

        public async Task CreateTempInfoFile(string reason, string file, string pathToBackupFile)
        {
            try
            {
                if (File.Exists(AppLngErrorFile))
                {
                    await Task.Run(() => File.Delete(AppLngErrorFile));
                }

                await Task.Run(() => Directory.CreateDirectory(AppTempLngFolder));

                StreamWriter textFile = new StreamWriter(AppLngErrorFile);
                textFile.WriteLine(reason);
                textFile.WriteLine(file);
                textFile.WriteLine(pathToBackupFile);
                textFile.Close();
            }
            catch (Exception e)
            {
                FlexibleMessageBox.Show(e.ToString());
            }
        }
    }
}