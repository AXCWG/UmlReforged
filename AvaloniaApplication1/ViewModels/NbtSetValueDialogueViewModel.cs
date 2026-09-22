using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public partial class NbtSetValueDialogueViewModel<T> : ViewModelBase 
{
    [ObservableProperty]
    public required partial string? Name { get; set; }
    [ObservableProperty]
    public required partial  T Value { get; set; }

    partial void OnNameChanged(string? value)
    {
        Console.WriteLine("Name changed. ");
    }

    partial void OnValueChanged(T value)
    {
        Console.WriteLine("Value changed. ");
    }
}