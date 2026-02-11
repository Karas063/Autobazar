using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections.Generic;
using System.Windows;
using Autobazar.Models;
using Autobazar.Services;

namespace Autobazar
{
    public partial class MainWindow : Window
    {
        private List<Auto> auta;
        private JsonService jsonService = new JsonService();

        public MainWindow()
        {
            InitializeComponent();
            auta = jsonService.Nacti();
            ObnovTabulku();
        }

        private void ObnovTabulku()
        {
            dataGridAuta.ItemsSource = null;
            dataGridAuta.ItemsSource = auta;
        }

        private void BtnPridat_Click(object sender, RoutedEventArgs e)
        {
            Auto a = new Auto
            {
                Znacka = txtZnacka.Text,
                Model = txtModel.Text,
                Barva = txtBarva.Text,
                SPZ = txtSPZ.Text,
                RokVyroby = int.Parse(txtRok.Text),
                Palivo = txtPalivo.Text,
                Najezd = int.Parse(txtNajezd.Text),
                Vlastnik = new Vlastnik
                {
                    Jmeno = txtJmeno.Text,
                    Prijmeni = txtPrijmeni.Text,
                    Adresa = txtAdresa.Text
                }
            };

            auta.Add(a);
            ObnovTabulku();
        }

        private void BtnSmazat_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridAuta.SelectedItem is Auto vybrane)
            {
                auta.Remove(vybrane);
                ObnovTabulku();
            }
        }

        private void BtnUlozit_Click(object sender, RoutedEventArgs e)
        {
            jsonService.Uloz(auta);
            MessageBox.Show("Uloženo!");
        }
    }
}
