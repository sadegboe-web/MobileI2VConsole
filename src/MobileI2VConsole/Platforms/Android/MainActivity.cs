
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System.IO;

namespace MobileI2VConsole;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize |
                           ConfigChanges.Orientation |
                           ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout |
                           ConfigChanges.SmallestScreenSize |
                           ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        try
        {
            base.OnCreate(savedInstanceState);
        }
        catch (Exception ex)
        {
            try
            {
                var file = Path.Combine(
                    FilesDir!.AbsolutePath,
                    "mobilei2v-startup-error.txt");

                File.WriteAllText(
                    file,
                    $"{DateTime.UtcNow:O}\n{ex}");

                Android.Util.Log.Error(
                    "MobileI2VStartup",
                    ex.ToString());
            }
            catch
            {
                Android.Util.Log.Error(
                    "MobileI2VStartup",
                    "Échec pendant l'enregistrement de l'erreur.");
            }

            throw;
        }
    }
}
