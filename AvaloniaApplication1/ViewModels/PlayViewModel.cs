using System;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;

namespace AvaloniaApplication1.ViewModels;

public partial class PlayViewModel : ViewModelBase
{
    public FAFrame? Frame { get; set; }
    [ObservableProperty] public partial bool IsOnline { get; set; }
    [ObservableProperty] public partial string Username { get; set; } = string.Empty;
    partial void OnIsOnlineChanged(bool value)
    {
        Console.WriteLine($"IsOffline: {value}");
    }
}