using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;
using FluentAvalonia.UI.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaApplication1.Views;

public partial class Play : UserControl
{
    public Action? NavigateToSelect { get; set; }
    public Action? NavigateSettings { get; set; }
    public Play()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetRequiredService<PlayViewModel>();
    }

    private void SelectVersionButtonOnClick(object? sender, RoutedEventArgs e)
    {
        NavigateToSelect?.Invoke();
    }

    private void VersionSettingsButtonOnClick(object? sender, RoutedEventArgs e)
    {
        NavigateSettings?.Invoke();
    }

    private void InputElement_OnKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            ((PlayViewModel)DataContext).Username.Usernames.Add(((ComboBox?)sender)?.Text??throw new NullReferenceException());
            ((ComboBox)sender).SelectedIndex = ((PlayViewModel)DataContext).Username.Usernames.Count - 1;
            TopLevel.GetTopLevel(this).FocusManager.Focus(null);
        }
    }
}