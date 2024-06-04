﻿using CommunityToolkit.Mvvm.Input;
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
            InjuryVM1 = _injuryViewModel1;
            Events = new();
            AddEvents(Events);
            /*Events = new EventCollection()

            {
                [DateTime.Now] = new List<Event>
                {
                    new Event { Name = "Cool event1", Description = "This is Cool event1's description!", EventDate = DateTime.Now},
                },

                [DateTime.Now.AddDays(5)] = new List<Event>
                {
                    new Event { Name = "Cool event2", Description = "This is Cool event2's description!", EventDate = DateTime.Now.AddDays(5)},
                }
            };*/
            //new Event { Name = "Cool event1", Description = "This is Cool event1's description!", EventDate = DateTime.Now };
            //new Event { Name = "Cool event2", Description = "This is Cool event2's description!", EventDate = DateTime.Now.AddDays(5) };
            //new Event { Name = "Cool event3", Description = "This is Cool event3's description!", EventDate = DateTime.Now.AddDays(-3) };
            //new Event { Name = "Cool event4", Description = "This is Cool event4's description!", EventDate = new DateTime(2020, 3, 16) };
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

        public void AddEvents(EventCollection evnts)
        {
            evnts.Add(DateTime.Now, new List<Event>
            {
                new Event { Name = "Cool event1", Description = "This is Cool event1's description!", EventDate = DateTime.Now},
            });
            evnts.Add(DateTime.Now.AddDays(5), new List<Event>
            {
                new Event { Name = "Cool event2", Description = "This is Cool event2's description!", EventDate = DateTime.Now.AddDays(5)},
            });
            evnts.Add(DateTime.Now.AddDays(-3), new List<Event>
            {
                new Event { Name = "Cool event3", Description = "This is Cool event3's description!", EventDate = DateTime.Now.AddDays(-3)},
            });
        }


    }
}
              