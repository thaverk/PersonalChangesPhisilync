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
using Plugin.Maui.Calendar.Models;
using CommunityToolkit.Maui.Core.Extensions;
//using ThreadNetwork;

namespace PhisilyncFinal.ViewModels
{

    public partial class AthleteDashVM : BaseViewModel, INotifyPropertyChanged
    {

        LocalDb db = new LocalDb();

        private TreatmentAction? _injuryTestDetails;

        public TreatmentAction? InjuryTestDetails
        {
            get { return _injuryTestDetails; }
            set { _injuryTestDetails = value; }
        }

        private InjuryViewModel _injuryViewModel;
        public InjuryViewModel InjuryVM
        {
            get { return _injuryViewModel; }
            set 
            {
                _injuryViewModel = value;

                OnPropertyChanged();
            }
        }

        private EventCollection events;
        public EventCollection Events
        {
            get { return events; }
            set
            {
                events = value;

                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<Event> TreatmentEvents { get; set; }

        public AthleteDashVM(InjuryViewModel injuryViewModel)
        {
            InjuryVM = injuryViewModel;
            db = new();
            OnAppearing();
            OnPropertyChanged();
        }

        public override void OnAppearing()
        {
            TreatmentEvents = new ObservableCollection<Event>(db.GetCurrentTreatment());
            Events = new EventCollection();
            AddEvents();
            base.OnAppearing();
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

        
        public void AddEvents()
        {
            foreach (var treatment in db.GetCurrentTreatment())
            {

                if (!Events.ContainsKey(treatment.EventDate))
                { 
                    Events.Add(treatment.EventDate, new List<Event> { treatment });
                }
                else  
                {
                    List<Event> name = (List<Event>)Events[treatment.EventDate];
                    name.Add(treatment);
                    Events[treatment.EventDate] = name;
                }
                
            }

        }

    }   
    
}   

