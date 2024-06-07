using PhisilyncFinal.Models;
using PhisilyncFinal.Services;
using PhisilyncFinal.ViewModels;

namespace PhisilyncFinal.Views;

public partial class SignUpPageAC : ContentPage
{

    public SignUpPageAC(SignUpACVM vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

}