using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaBugs;

public partial class SecondWindow : Window
{
    public SecondWindow()
    {
        InitializeComponent();
        DataContext = new VeryBigViewModel();
    }
}