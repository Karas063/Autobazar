using Autobazar.Models;
using Autobazar.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Autobazar.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly JsonService _jsonService = new JsonService();

        public ObservableCollection<Auto> Auta { get; set; }

        private Auto _vybraneAuto;
        public Auto VybraneAuto
        {
            get => _vybraneAuto;
            set
            {
                _vybraneAuto = value;
                OnPropertyChanged();
            }
        }

        public ICommand PridatCommand { get; }
        public ICommand SmazatCommand { get; }
        public ICommand UlozitCommand { get; }

        public MainViewModel()
        {
            Auta = new ObservableCollection<Auto>(_jsonService.Nacti());

            PridatCommand = new RelayCommand(Pridat);
            SmazatCommand = new RelayCommand(Smazat);
            UlozitCommand = new RelayCommand(Ulozit);
        }

        private void Pridat()
        {
            var noveAuto = new Auto();
            Auta.Add(noveAuto);
            VybraneAuto = noveAuto;
        }

        private void Smazat()
        {
            if (VybraneAuto != null)
                Auta.Remove(VybraneAuto);
        }

        private void Ulozit()
        {
            _jsonService.Uloz(Auta.ToList());
        }
    }
}

