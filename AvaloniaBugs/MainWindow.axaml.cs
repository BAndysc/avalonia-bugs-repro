using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace AvaloniaBugs;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        var textBox = new TextBox();
        var adornerLayer = AdornerLayer.GetAdornerLayer(Border);
        adornerLayer.Children.Add(textBox);
        AdornerLayer.SetAdornedElement(textBox, Border);
    }
}