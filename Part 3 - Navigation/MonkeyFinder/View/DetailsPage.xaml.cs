namespace MonkeyFinder;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(MonkeyDetailsViewModel monkeyDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = monkeyDetailsViewModel;
	}
}