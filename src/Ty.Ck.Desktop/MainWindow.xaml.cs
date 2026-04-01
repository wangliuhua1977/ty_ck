using System.Windows;
using Ty.Ck.Desktop.ViewModels;

namespace Ty.Ck.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}
