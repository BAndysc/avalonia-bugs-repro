using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia.Media;

namespace AvaloniaBugs;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

}

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<BigFileViewModel> Files { get; } = new();

    private BigFileViewModel? selectedFile;
    public BigFileViewModel? SelectedFile
    {
        get => selectedFile;
        set => SetField(ref selectedFile, value);
    }

    public void NewTab()
    {
        Files.Add(new BigFileViewModel("Tab " + (Files.Count + 1)));
        SelectedFile = Files[^1];
    }

    public void CloseAllTabs()
    {
        Files.Clear();
        SelectedFile = null;
    }

    public void CloseTab(BigFileViewModel tab)
    {
        Files.Remove(tab);
        if (SelectedFile == tab)
            SelectedFile = Files.Count > 0 ? Files[^1] : null;
    }
}

public class BigFileViewModel : ViewModelBase
{
    public byte[] BigData = new byte[512 * 1024 * 1024];

    public BigFileViewModel(string title)
    {
        Title = title;
    }

    public string Title { get; }
}