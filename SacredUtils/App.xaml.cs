using SacredUtils.resources.bin;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                new GetLoggerConfig().Get();

                new GetGlobalizerLib().Get();

                new GetAppFolders().Get();

                new GetConfigurations().Get(); // � ��������.

                Task.Run(() => new GetRequiredFiles().Get());

                Task.Run(() => new GetStatistic().Get());

                Task.Run(() => new GetAppSettings().Get());

                base.OnStartup(e); // Launch OnStartup method in WPFSharp.Globalizer.

                Task.Run(() => new GetLanguage().Get());
            }
            catch (Exception exception)
            {
                GetLoggerConfig.Log.Fatal("There was a critical error of the program, sorry please, if the program could not start. Contact the Creator of the utility.");

                GetLoggerConfig.Log.Fatal(exception.ToString);
            }
        }
    }
}
