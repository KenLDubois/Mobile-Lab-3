using MobileLab3_UWPClient.DAL;
using MobileLab3_UWPClient.Models;
using MobileLab3_UWPClient.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MobileLab3_UWPClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            fillDropDown();
        }

        private async void fillDropDown()
        {
            //Show Progress
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            ArtTypeRepository r = new ArtTypeRepository();
            try
            {
                List<ArtType> artTypes = await r.GetArtTypes();
                //Add the All Option
                artTypes.Add(new ArtType { ID = 0, Type = " - All ArtTypes" });
                //Save them for the Patient Details 
                App thisApp = Application.Current as App;
                thisApp.ActiveArtTypes = artTypes;
                //Bind to the ComboBox
                ArtTypeCombo.ItemsSource = artTypes.OrderBy(d => d.Type);
                //btnAdd.IsEnabled = true; //Since we have doctors, you can try to add new.
                showArtwork(null);
            }
            catch (ApiException apiEx)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Errors:");
                foreach (var error in apiEx.Errors)
                {
                    sb.AppendLine("-" + error);
                }
                Jeeves.ShowMessage("Could not complete operation:", sb.ToString());
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("connection with the server"))
                {
                    Jeeves.ShowMessage("Error", "No connection with the server. Check that the Web Service is running and available and then click the Refresh button.");
                }
                else
                {
                    Jeeves.ShowMessage("Error", "Could not complete operation.");
                }
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }
        private async void showArtwork(int? ArtTypeID)
        {
            //Show Progress
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            ArtworkRepository r = new ArtworkRepository();
            try
            {
                List<Artwork> artworks;
                if (ArtTypeID.GetValueOrDefault() > 0)
                {
                    artworks = await r.GetArtworksByArtType(ArtTypeID.GetValueOrDefault());
                }
                else
                {
                    artworks = await r.GetArtworks();
                }
                patientList.ItemsSource = artworks.OrderByDescending(e => e.ID);

            }
            catch (ApiException apiEx)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Errors:");
                foreach (var error in apiEx.Errors)
                {
                    sb.AppendLine("-" + error);
                }
                Jeeves.ShowMessage("Could not complete operation:", sb.ToString());
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("server"))
                {
                    Jeeves.ShowMessage("Error", "No connection with the server.");
                }
                else
                {
                    Jeeves.ShowMessage("Error", "Could not complete operation.");
                }
            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }
        private void ArtTypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArtType selArtType = (ArtType)ArtTypeCombo.SelectedItem;
            showArtwork(selArtType?.ID);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            fillDropDown();
        }

    }
}
