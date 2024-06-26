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

    private LocalDb db;
    
    public TreatmentAction injurieTest { get; set; }
    public TreatmentAction TreatmentAction;
    public Treatment treatment { get; set; }
   
    public EventCollection _event;
    public EventCollection Events 
    {
        get {return _event; } 
        set 
        {
            _event=value;
            OnPropertyChanged(); 
        }
    }

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
            await DisplayAlert("Success", "Treatment Has Been Added To Yout Dashboard", "OK");
            //await Shell.Current.GoToAsync(new("/"));

        }   
        else if (treatment.treatmentTreatmentFrequency == 2)
        {
            WeeklyTreatment();
            await DisplayAlert("Success", "Treatment Has Been Added To Yout Dashboard", "OK");
            //await Shell.Current.GoToAsync(new("/athleteDash"));
        }
        else 
        {
            MonthlyTreatment();
            await DisplayAlert("Success", "Treatment Has Been Added To Yout Dashboard", "OK");
            //await Shell.Current.GoToAsync(new ("/athleteDash"));
        }
        await Shell.Current.GoToAsync("athleteDash");
    }

    public void DailyTreatment() 
    {

        for (int i = 1; i < 7; i++)
        {
            db.SaveEvent(new Event
            {
                Name = injurieTest.treatmentActionName,
                Description = injurieTest.treatmentActionStepAction,
                TreatmentID = injurieTest.treatmentActionTreatment,
                EventDate = DateTime.Now.AddDays(i),
                Frequency = 1,
                UserID = 1
            });
            db.SaveEvent(new Event
            {
                Name = injurieRelease.treatmentActionName,
                Description = injurieRelease.treatmentActionStepAction,
                TreatmentID = injurieRelease.treatmentActionTreatment,
                EventDate = DateTime.Now.AddDays(i),
                UserID = 1,
                Frequency = 1
            });
        }

    }
    public void WeeklyTreatment() 
    {
        for (int i = 0; i < 22; i += 7)
        {
            db.SaveEvent(new Event
            {
                Name = injurieTest.treatmentActionName,
                Description = injurieTest.treatmentActionStepAction,
                TreatmentID = injurieTest.treatmentActionTreatment,
                EventDate = DateTime.Now.AddDays(i),
                UserID = 1,
                Frequency = 2
            });
            db.SaveEvent(new Event
            {
                Name = injurieRelease.treatmentActionName,
                Description = injurieRelease.treatmentActionStepAction,
                TreatmentID = injurieRelease.treatmentActionTreatment,
                EventDate = DateTime.Now.AddDays(i),
                UserID = 1,
                Frequency = 2
            });
        }
    }
    public void MonthlyTreatment() 
    {
        for (int i = 0; i < 31; i += 30)
        {
            db.SaveEvent(new Event
            {
                Name = injurieTest.treatmentActionName,
                Description = injurieTest.treatmentActionStepAction,
                TreatmentID = injurieTest.treatmentActionTreatment,
                EventDate = DateTime.Now.AddDays(i),
                UserID = 1,
                Frequency = 3
            });
            db.SaveEvent(new Event
            {
                Name = injurieRelease.treatmentActionName,
                Description = injurieRelease.treatmentActionStepAction,
                TreatmentID = injurieRelease.treatmentActionTreatment,
                EventDate = DateTime.Now.AddDays(i),
                UserID = 1,
                Frequency = 3
            });
        }

    }

}