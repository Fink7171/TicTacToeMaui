using TicTacToeMaui.Views;

namespace TicTacToeMaui;

public partial class App : Application
{
	public App()	
	{
		InitializeComponent();

		App.Current.MainPage = new TicTacToeGamePage();
	}
}
