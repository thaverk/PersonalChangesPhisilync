using PhisilyncFinal.ViewModels;
using PhisilyncFinal.Models;
using PhisilyncFinal.Services;

namespace PhisilyncFinal.Views;
public partial class SignUpPageCoach : ContentPage
{
    
    public SignUpPageCoach(SignUpCoachVM vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }

}