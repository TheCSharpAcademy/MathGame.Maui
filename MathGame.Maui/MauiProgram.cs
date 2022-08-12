namespace MathGame.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
				fonts.AddFont("CaveatBrush-Regular.ttf", "CaveatBrush");
            });

		return builder.Build();
	}
}
