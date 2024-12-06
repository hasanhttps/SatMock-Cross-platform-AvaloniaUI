using SatMock.Views;

namespace SatMock.ViewModels;

public partial class MainViewModel : ViewModelBase {

    // Fields

    private object _currentView;

    // Properties

    public object CurrentView {
        get => _currentView;
        set { 
            _currentView = value; 
        }
    }

    // Constructor

    public MainViewModel() {

        CurrentView = new ExamsView();
    }

    //public void NavigateToSettings()
    //{
    //    CurrentView = new SettingsView();
    //}
}
