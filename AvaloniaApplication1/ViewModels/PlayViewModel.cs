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
    private readonly ApplicationData _data;

    /// <inheritdoc/>
    public PlayViewModel(ApplicationData data)
    {
        _data = data;
        Username = new(data.StoredNames, data.SelectedIndex, data);
        IsOnline = data.IsOnline;
    }

    [ObservableProperty] public partial bool IsOnline { get; set; }
    public UsernameAndIndex Username { get;  }

    partial void OnIsOnlineChanged(bool value)
    {
        _data.IsOnline = value;
    }
}

public  sealed partial class UsernameAndIndex : ObservableObject
{
    private readonly ApplicationData? _data;
    // nullable parameter for NOT THE SAME REASON. 
    public UsernameAndIndex(ObservableCollection<string>  usernames , int index , ApplicationData? data = null)
    {
        _data = data;
        Usernames = usernames;
        Index = index;
    }
    public ObservableCollection<string> Usernames { get; private set; }
    [ObservableProperty]
    public partial int Index { get;  set; }

    partial void OnIndexChanged(int value)
    {
        _data?.SelectedIndex = value;
        Console.WriteLine(value);
    }
}