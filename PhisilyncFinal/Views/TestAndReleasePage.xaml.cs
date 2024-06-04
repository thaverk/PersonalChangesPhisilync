using PhisilyncFinal.Models;
using PhisilyncFinal.Services;
using PhisilyncFinal.ViewModels;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Plugin.Maui.Calendar.Models;

namespace PhisilyncFinal.Views;

public partial class TestAndReleasePage : ContentPage
{
    
    //public ProviderInjury _injury;
    private LocalDb db;
    
    public TreatmentAction injurieTest { get; set; }
    public TreatmentAction TreatmentAction;
    public Treatment treatment { get; set; }
   
    public EventCollection _event;
    public EventCollection Events { get {return _event; } set {_event=value;OnPropertyChanged(); }}

    public TreatmentAction injurieRelease { get; set ;}
    
    public TestAndReleasePage(ProviderInjury injury)
	{
		InitializeComponent();
        
        db = new();
        injurieTest =  db.GetTestTreatmentAction(injury.providerInjuryID);
        injurieRelease =  db.GetReleaseTreatmentAction(injury.providerInjuryID);
        treatment = db.GetTreatment(injury.providerInjuryID);
        
        BindingContext = this;
        
        OnPropertyChanged();
        OnAppearing();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (treatment.treatmentTreatmentFrequency == 1) 
        { 
            DailyTreatment();
            /*await DisplayAlert("Success", "Treatment Has Been Added To Yout Dashboard", "OK");
            await Shell.Current.GoToAsync(new("/athleteDash"));*/

        }   
        else if (treatment.treatmentTreatmentFrequency == 2)
        {
            WeeklyTreatment();
            /*await DisplayAlert("Success", "Treatment Has Been Added To Yout Dashboard", "OK");
            await Shell.Current.GoToAsync(new("/athleteDash"));*/
        }
        else 
        {
            MonthlyTreatment();
            /*await DisplayAlert("Success", "Treatment Has Been Added To Yout Dashboard", "OK");
            await Shell.Current.GoToAsync(new ("/athleteDash"));*/
        }
        await Shell.Current.GoToAsync("/athleteDash");
    }

    public void DailyTreatment() 
    {
        AthleteDashVM coachDashVM = new(new InjuryViewModel());
        coachDashVM.Events.Add(DateTime.Now, new List<Event>
                {
                   new Event 
                   {  
                        Name = injurieTest.treatmentActionName,
                        Description = injurieTest.treatmentActionStepAction,
                        TreatmentID = injurieTest.treatmentActionTreatment,
                        EventDate = DateTime.Now,
                        UserID = 1,
                   },
                    new Event
                    {
                        Name = injurieRelease.treatmentActionName,
                        Description = injurieRelease.treatmentActionStepAction,
                        TreatmentID = injurieRelease.treatmentActionTreatment,
                        EventDate = DateTime.Now,
                        UserID = 1,
                    }
                });
        

        /*Events = new EventCollection()
        {
                [DateTime.Now] = new List<Event>
                {
                   new Event {  Name = injurieTest.treatmentActionName,
                                 Description = injurieTest.treatmentActionStepAction,
                                 TreatmentID = injurieTest.treatmentActionTreatment,
                                 EventDate = DateTime.Now,
                                 UserID = 1,},
                   new Event{ Name = injurieRelease.treatmentActionName,
                              Description = injurieRelease.treatmentActionStepAction,
                              TreatmentID = injurieRelease.treatmentActionTreatment,
                              EventDate = DateTime.Now,
                              UserID = 1, }
                }
        };*/

        /*for (int i = 0; i == 2; i++)
            {
                Events = new EventCollection()
                {
                    [DateTime.Now.AddDays(7)] = new List<Event>

                    {

                          new Event { Name = injurieTest.treatmentActionName,
                                      Description = injurieTest.treatmentActionStepAction,
                                      TreatmentID = injurieTest.treatmentActionTreatment,
                                      EventDate = DateTime.Now.AddDays(7),
                                      UserID = 1,
                             },

                    new Event { Name = injurieRelease.treatmentActionName,
                                    Description = injurieRelease.treatmentActionStepAction,
                                    TreatmentID = injurieRelease.treatmentActionTreatment,
                                    EventDate = DateTime.Now.AddDays(7),
                                    UserID = 1,},
                }
                };*/
            }
    
    public void WeeklyTreatment() 
    {

    AthleteDashVM coachDashVM = new(new InjuryViewModel());
    coachDashVM.Events.Add(DateTime.Now, new List<Event>
                {
                   new Event
                   {
                        Name = injurieTest.treatmentActionName,
                        Description = injurieTest.treatmentActionStepAction,
                        TreatmentID = injurieTest.treatmentActionTreatment,
                        EventDate = DateTime.Now,
                        UserID = 1,
                   },
                    new Event
                    {
                        Name = injurieRelease.treatmentActionName,
                        Description = injurieRelease.treatmentActionStepAction,
                        TreatmentID = injurieRelease.treatmentActionTreatment,
                        EventDate = DateTime.Now,
                        UserID = 1,
                    }
                });
    //Shell.Current.GoToAsync(nameof(AthleteDash));
    /*Events = new EventCollection()
            {
                [DateTime.Now] = new List<Event>
                {
                  new Event{  Name = injurieTest.treatmentActionName,
                         Description = injurieTest.treatmentActionStepAction,
                            TreatmentID = injurieTest.treatmentActionTreatment,
                            EventDate = DateTime.Now,
                            UserID = 1, },

                  new Event{Name = injurieRelease.treatmentActionName,
                Description = injurieRelease.treatmentActionStepAction,
                TreatmentID = injurieRelease.treatmentActionTreatment,
                EventDate = DateTime.Now,
                UserID = 1,}

                }
            };
           
            

            for (int i = 0; i == 7; i++)
            {
                Events = new EventCollection()
                {
                    [DateTime.Now] = new List<Event>
                    {
                       new Event{ Name = injurieTest.treatmentActionName,
                        Description = injurieTest.treatmentActionStepAction,
                        TreatmentID = injurieTest.treatmentActionTreatment,
                        EventDate = DateTime.Now.AddDays(1),
                        UserID = 1, },

                       new Event{ Name = injurieRelease.treatmentActionName,
                    Description = injurieRelease.treatmentActionStepAction,
                    TreatmentID = injurieRelease.treatmentActionTreatment,
                    EventDate = DateTime.Now.AddDays(1),
                    UserID = 1,}
                    }
                };*/
               

             
            
        
    }
    public void MonthlyTreatment() 
    {
    AthleteDashVM coachDashVM = new(new InjuryViewModel());
    coachDashVM.Events.Add(DateTime.Now, new List<Event>
                {
                   new Event
                   {
                        Name = injurieTest.treatmentActionName,
                        Description = injurieTest.treatmentActionStepAction,
                        TreatmentID = injurieTest.treatmentActionTreatment,
                        EventDate = DateTime.Now,
                        UserID = 1,
                   },
                    new Event
                    {
                        Name = injurieRelease.treatmentActionName,
                        Description = injurieRelease.treatmentActionStepAction,
                        TreatmentID = injurieRelease.treatmentActionTreatment,
                        EventDate = DateTime.Now,
                        UserID = 1,
                    }
                });
    //Shell.Current.GoToAsync(nameof(AthleteDash));

    /*Events = new EventCollection()
            {
                [DateTime.Now] = new List<Event>
                {
                   new Event { Name = injurieTest.treatmentActionName,
                    Description = injurieTest.treatmentActionStepAction,
                    TreatmentID = injurieTest.treatmentActionTreatment,
                    EventDate = DateTime.Now,
                    UserID = 1, },

                     new Event{ Name = injurieRelease.treatmentActionName,
                    Description = injurieRelease.treatmentActionStepAction,
                    TreatmentID = injurieRelease.treatmentActionTreatment,
                    EventDate = DateTime.Now,
                    UserID = 1, },

                }  



            };

           
          

            for (int i = 0; i == 3; i++)
            {
                Events = new EventCollection()
                {
                    [DateTime.Now.AddMonths(1)] = new List<Event>
                    { 
                        new Event
                        { Name = injurieTest.treatmentActionName,
                        Description = injurieTest.treatmentActionStepAction,
                        TreatmentID = injurieTest.treatmentActionTreatment,
                        EventDate = DateTime.Now.AddMonths(1),
                        UserID = 1, },

                        new Event
                        {  Name = injurieRelease.treatmentActionName,
                    Description = injurieRelease.treatmentActionStepAction,
                    TreatmentID = injurieRelease.treatmentActionTreatment,
                    EventDate = DateTime.Now.AddMonths(1),
                    UserID = 1,}
                    }
                };
              

              
            }*/
        
    }

}