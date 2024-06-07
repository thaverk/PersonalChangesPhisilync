using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using PhisilyncFinal.Views;
using PhisilyncFinal.Services;
using PhisilyncFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Plugin.Maui.Calendar.Models;
using System.Collections.ObjectModel;

namespace PhisilyncFinal.ViewModels
{
    public partial class CoachDashVM : BaseViewModel
    {
        LocalDb db = new LocalDb();

        private InjuryViewModel _injuryViewModel1;

        public InjuryViewModel InjuryVM1
        {
            get { return _injuryViewModel1; }
            set
            {
                _injuryViewModel1 = value;

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


        private readonly IPageService _pageService;

        public CoachDashVM(InjuryViewModel _injuryViewModel1)
        {
            db = new();
            InjuryVM1 = _injuryViewModel1;
            AddEvents();
        }



        [RelayCommand]
        private async Task Injury()
        {
            await Shell.Current.GoToAsync("Library");
        }

        [RelayCommand]
        private async Task OnAvatarTapped()
        {
            await Shell.Current.GoToAsync("EditProfile");
        }

        public void PopUpClicked(object sender, EventArgs e)
        {
            var currentPage = _pageService.GetCurrentPage();
            currentPage.ShowPopup(new TeamStatsPopUp());
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
              