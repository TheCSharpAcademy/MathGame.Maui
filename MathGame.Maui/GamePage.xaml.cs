namespace MathGame.Maui;

public partial class GamePage : ContentPage
{
    public string GameType { get; set; }    

    public GamePage(string gameType)
    {
        InitializeComponent();
        GameType = gameType;
        this.BindingContext = this;
    }



}