using Avalonia.Controls;

namespace AvaloniaBugs;

public partial class MainWindow : Window
{
    public bool IsA => true;
    public bool IsB => true;

    public MainWindow()
    {
        DataContext = this;
        InitializeComponent();
    }
}