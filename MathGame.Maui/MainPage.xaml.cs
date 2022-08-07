using System.Reflection;

namespace MathGame.Maui;

public partial class MainPage : ContentPage
{
   
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnGameChosen(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        Navigation.PushAsync(new GamePage(btn.Text));
    }
}

