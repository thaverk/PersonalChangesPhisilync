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
//using ThreadNetwork;

namespace PhisilyncFinal.ViewModels
{
    [QueryProperty(nameof(TreatmentAction), "InjuryTestDetails")]
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
            set { _injuryViewModel = value;

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
            Events = new();
            db = new();
            AddEvents(Events);
            //LoadData();
            OnAppearing();
            OnPropertyChanged();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        /*private void LoadData()
        {
            Events = new ObservableCollection<Event>(db.GetCurrentTreatment());
        }*/



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

        public void AddEvents(EventCollection evnts)
        {
            int evntID = 0;
            foreach(var treatment in db.GetCurrentTreatment())
            {
                if (treatment.Frequency == 1 && treatment.EventID != evntID + 1)
                {
                    for (int i = 0; i < 7; i++)
                    { 
                        evnts.Add(treatment.EventDate.AddDays(i), db.GetEventsByTreatmentId(treatment.TreatmentID));
                    }
                }
                evntID++;
                /*else if (treatment.Frequency == 2)
                {
                    for(int i = 0; i < 15; i+=7)
                        evnts.Add(DateTime.Now.AddDays(i), db.GetCurrentTreatment());

                }
                else if (treatment.Frequency == 3)
                {
                    for (int i = 0; i < 61; i += 30)
                        evnts.Add(DateTime.Now.AddDays(i), db.GetCurrentTreatment());
                }*/

            }
        }
            //{ evnts.Add(DateTime.Now, db.GetCurrentTreatment()); }
            //    evnts.Add(DateTime.Now.AddDays(5), new List<Event>
            //{
            //    new Event { Name = "Cool event2", Description = "This is Cool event2's description!", EventDate = DateTime.Now.AddDays(5)},
            //});
            //    evnts.Add(DateTime.Now.AddDays(-3), new List<Event>
            //{
            //    new Event { Name = "Cool event3", Description = "This is Cool event3's description!", EventDate = DateTime.Now.AddDays(-3)},
            //});
    }
}

