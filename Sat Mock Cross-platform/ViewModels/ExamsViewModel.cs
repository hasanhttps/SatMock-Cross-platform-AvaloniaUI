using System;
using System.Linq;
using MsBox.Avalonia;
using SatMock.Commands;
using System.Windows.Input;
using MsBox.Avalonia.Enums;
using Database.Entities.Concretes;
using System.Collections.ObjectModel;
using static SatMock.Models.DatabaseNamespace.Database;

namespace SatMock.ViewModels;

public class ExamsViewModel : ViewModelBase {

    // Properties

    public ICommand SelectionChangedCommand { get; set; }
    public ObservableCollection<Exam> Exams { get; set; } = new();

    // Constructor

    public ExamsViewModel() {
        SelectionChangedCommand = new RelayCommand(SelectionChanged);

        foreach (var exam in DbContext.Exams.ToList()) {
            Exams.Add(exam);
        }
    }

    
    // Functions
    
    private async void SelectionChanged(object? param) {
        Exam? exam = (param as Exam);
        bool isError = false;

        if (exam != null) {

            if (DateTime.Now < exam.ActivationDate) {
                await MessageBoxManager
                    .GetMessageBoxStandard("Warning", "Exam is not activated yet. Please wait for the activation date and time of the exam.", ButtonEnum.Ok, Icon.Warning, Avalonia.Controls.WindowStartupLocation.CenterScreen)
                    .ShowAsync();
                isError = true;
            }

            if (exam.Modules == null || !exam.Modules.Any()) {
                await MessageBoxManager
                    .GetMessageBoxStandard("Warning", "In this exam, there are no modules. Please notify us.", ButtonEnum.Ok, Icon.Warning, Avalonia.Controls.WindowStartupLocation.CenterScreen)
                    .ShowAsync();
                isError = true;
            }

            if (exam.Modules?.Count != 4) {
                await MessageBoxManager
                    .GetMessageBoxStandard("Warning", "In this exam, modules are not completed. Please notify us.", ButtonEnum.Ok, Icon.Warning, Avalonia.Controls.WindowStartupLocation.CenterScreen)
                    .ShowAsync();
                isError = true;
            }

            //if (isError) MainFrame.Content = new ExamsPage(MainFrame);
            //else MainFrame.Content = new QuizPage(MainFrame, exam);
        }
    }
}