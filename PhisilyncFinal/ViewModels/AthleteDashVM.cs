 using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using PhisilyncFinal.Services;
using PhisilyncFinal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhisilyncFinal.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using System.ComponentModel;
//using ThreadNetwork;

namespace PhisilyncFinal.ViewModels
{
    
    public partial class AthleteDashVM : BaseViewModel ,INotifyPropertyChanged
    {
        private InjuryViewModel _injuryViewModel;

        private LocalDb db;
        
        public InjuryViewModel InjuryVM
        {
            get { return _injuryViewModel; }
            set { _injuryViewModel = value;

                OnPropertyChanged();
            }
        }

        //private ObservableCollection<Event> _events;
     
        public ObservableCollection<Event> Events { get; set; }
        
           




        //private LocalDb _database;
        //private ObservableCollection<TreatmentAction> _treatmentaction;

        //public ObservableCollection<TreatmentAction> Dashboard
        //{
        //    get => _treatmentaction;
        //    set
        //    {
        //        _treatmentaction = value;
        //        OnPropertyChanged();
        //    }
        //}

        public AthleteDashVM(InjuryViewModel injuryViewModel)
        {
            // _database = database;
            InjuryVM = injuryViewModel;
            db = new();
            LoadData();
            Events = new ObservableCollection<Event>(db.GetCurrentTreatment());
            OnAppearing();
            OnPropertyChanged();


        }

        public override void Initialize()
        {
            base.Initialize();

        }

        private void LoadData()
        {
            Events = new ObservableCollection<Event>(db.GetCurrentTreatment());
        }



        //Commands
        [RelayCommand]
        private async Task Injury()
        {
            await Shell.Current.GoToAsync("SelectInjury");
        }

        [RelayCommand]
        private async Task AthleteInjury() 
        {
            await Shell.Current.GoToAsync("treatmentPage");
        }

        [RelayCommand]
        private async Task OnAvatarTapped()
        {
            await Shell.Current.GoToAsync("EditProfile");
        }

        
    }




}
