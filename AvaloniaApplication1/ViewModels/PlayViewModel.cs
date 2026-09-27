using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvaloniaApplication1.DataType;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;

namespace AvaloniaApplication1.ViewModels;

public partial class PlayViewModel : ViewModelBase
{
    /// <inheritdoc/>
    public PlayViewModel(ApplicationData data)
    {
        Username = new()
        {
            Usernames = new ObservableCollection<string>(data.StoredNames),
            Index = 0
        };
        Username.PropertyChanged += (sender, args) =>
        {
            OnPropertyChanged(nameof(Username));
        };
    }

    [ObservableProperty] public partial bool IsOnline { get; set; }
    [ObservableProperty] public partial UsernameAndIndex Username { get; private set; } 
    partial void OnIsOnlineChanged(bool value)
    {
        Console.WriteLine($"IsOffline: {value}");
    }
    
}

public  sealed partial class UsernameAndIndex  : ObservableObject
{
    public  ObservableCollection<string> Usernames { get; set; } = [];
    [ObservableProperty]
    public partial int Index { get; set; }
}