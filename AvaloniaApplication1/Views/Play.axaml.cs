using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.ViewModels;
using AXExpansion;
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
            var playViewModel = ((PlayViewModel)DataContext);
            if (playViewModel?.Username.Usernames.FirstOrDefault(i => i == ((ComboBox?)sender)?.Text) is {} i)
            {
                ((ComboBox)sender).SelectedIndex = playViewModel?.Username.Usernames.IndexOf(i) ?? throw new InvalidOperationException();
                TopLevel.GetTopLevel(this).FocusManager.Focus(null);

                return; 
            }
            playViewModel.Username.Usernames.Add(((ComboBox?)sender)?.Text??throw new NullReferenceException());
            ((ComboBox)sender).SelectedIndex = playViewModel.Username.Usernames.Count - 1;
            TopLevel.GetTopLevel(this).FocusManager.Focus(null);
        }
    }
}