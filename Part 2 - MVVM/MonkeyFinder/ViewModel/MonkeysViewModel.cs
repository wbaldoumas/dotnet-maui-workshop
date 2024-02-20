using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    private readonly IMonkeyService _monkeyService;

    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public MonkeysViewModel(IMonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        _monkeyService = monkeyService;
    }

    [RelayCommand]
    private async Task GetMonkeysAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            var monkeys = await _monkeyService.GetMonkeysAsync();

            if (Monkeys.Count > 0)
            {
                Monkeys.Clear();
            }
            
            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Failed to retrieve monkeys: {exception.Message}.");

            await Shell.Current.DisplayAlert("Error", "Failed to retrieve monkeys.", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
