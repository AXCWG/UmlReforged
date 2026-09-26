using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;
using FluentAvalonia.UI.Controls;

namespace AvaloniaApplication1.Views;

public partial class Play : UserControl
{
    public Action? NavigateToSelect { get; set; }
    public Action? NavigateSettings { get; set; }
    public Play()
    {
        InitializeComponent();
        DataContext = new PlayViewModel();
    }

    private void SelectVersionButtonOnClick(object? sender, RoutedEventArgs e)
    {
        NavigateToSelect?.Invoke();
    }

    private void VersionSettingsButtonOnClick(object? sender, RoutedEventArgs e)
    {
        NavigateSettings?.Invoke();
    }
}