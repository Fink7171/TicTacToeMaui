using TicTacToeMaui.ViewModel;

namespace TicTacToeMaui.Views;

public partial class TicTacToeGamePage : ContentPage
{
	public TicTacToeGamePage()
	{
		InitializeComponent();
		this.BindingContext = new TicTacToeGamePageViewModel();

    }
}