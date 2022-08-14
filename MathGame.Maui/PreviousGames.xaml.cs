using MathsGame.Models;
using System;

namespace MathGame.Maui;

public partial class PreviousGames : ContentPage
{
	public PreviousGames()
	{
		InitializeComponent();
		App.GameRepository.GetAllGames();

        List<Game> people = App.GameRepository.GetAllGames();
        gamesList.ItemsSource = people;
    }
}