using Avalonia.Controls;
using SatMock.ViewModels;

namespace SatMock.Views;

public partial class ExamsView : UserControl {
    public ExamsView() {
        InitializeComponent();
        DataContext = new ExamsViewModel();
    }

    private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e) {
        var listBox = sender as ListBox;
        var selectedItem = listBox?.SelectedItem;

        // Assuming ViewModel has a SelectionChangedCommand
        if (DataContext is ExamsViewModel viewModel) {
            viewModel.SelectionChangedCommand.Execute(selectedItem);
        }
    }
}