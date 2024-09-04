using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WpfApp6.Services;
using WpfApp6.Services.Launch;

namespace WpfApp6.Pages
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                // Get the current directory where the application is running
                string currentDirectory = Directory.GetCurrentDirectory();

                // Combine the current directory with the relative path to the image file
                string imagePath = Path.Combine(currentDirectory, "skib.png");

                // Load the image dynamically
                Frost.Source = new BitmapImage(new Uri(imagePath));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path69 = UpdateINI.ReadValue("Auth", "Path");
                if (path69 != "NONE") // NONE THE BEST RESPONSE!
                {
                    if (File.Exists(Path.Combine(path69, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe")))
                    {
                        if (UpdateINI.ReadValue("Auth", "Email") == "NONE" || UpdateINI.ReadValue("Auth", "Password") == "NONE")
                        {
                            MessageBox.Show("Please Add Your Frost Info In Settings");
                            return;
                        }

                        // Download necessary files
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile("https://filetransfer.io/data-package/R8u6ZPD0/download", Path.Combine(path69, "Engine\\Binaries\\ThirdParty\\NVIDIA\\NVaftermath\\Win64", "GFSDK_Aftermath_Lib.x64.dll"));

                        // Start processes
                        PSBasics.Start(path69, "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck", UpdateINI.ReadValue("Auth", "Email"), UpdateINI.ReadValue("Auth", "Password"));
                        FakeAC.Start(path69, "FortniteClient-Win64-Shipping_BE.exe", $"-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck", "r");
                        FakeAC.Start(path69, "FortniteLauncher.exe", $"-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck", "dsf");

                        PSBasics._FortniteProcess.WaitForExit();

                        try
                        {
                            FakeAC._FNLauncherProcess.Close();
                            FakeAC._FNAntiCheatProcess.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("There was an error closing: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Add Your Skibidy Info In Settings"); // INV
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }
    }
}
