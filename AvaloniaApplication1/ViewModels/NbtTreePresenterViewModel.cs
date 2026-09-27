using System;
using CommunityToolkit.Mvvm.ComponentModel;
using fNbt;

namespace AvaloniaApplication1.ViewModels;

public partial class NbtTreePresenterViewModel : ViewModelBase
{
    [ObservableProperty] public partial NbtTag NbtTag { get; set; }

    public void Update()
    {
        var n = NbtTag;
        NbtTag = null;
        NbtTag = n; 
        OnPropertyChanged(nameof(NbtTag));
    }
}