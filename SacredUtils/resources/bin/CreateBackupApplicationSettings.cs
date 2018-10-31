﻿using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CreateBackupApplicationSettings
    {
        public static void Create()
        {
            if (AppSettings.ApplicationSettings.RemoveBackupFilesOnOverflow)
            {
                if (Directory.GetFiles("$SacredUtils\\back\\cfg-app").Length >= AppSettings.ApplicationSettings.MaxApplicationBackupFiles)
                {
                    foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-app").EnumerateFiles())
                    {
                        dir.Delete();
                    }
                }
            }

            if (AppSettings.ApplicationSettings.MakeAutoBackupConfigs)
            {
                File.Copy("$SacredUtils\\conf\\settings.json", $"$SacredUtils\\back\\cfg-app\\config_app_id_{AppSummary.RandomSession}.cfg", true);
            }
            else
            {
                foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-app").EnumerateFiles())
                {
                    dir.Delete();
                }
            }
        }
    }
}
