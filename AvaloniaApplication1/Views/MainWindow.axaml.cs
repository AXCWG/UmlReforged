using System;
using System.Linq;
using Avalonia.Controls;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Media.Animation;
using FluentAvalonia.UI.Navigation;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Frame.Navigate(typeof(Play));

    }

    private void FANavigationView_OnItemInvoked(object? sender, FANavigationViewItemInvokedEventArgs e)
    {
        if (e.IsSettingsInvoked)
        {
            throw new NotImplementedException();
        }else if (e.InvokedItemContainer is FANavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "Play":
                    Frame.Navigate(typeof(Play));
                    break;
                case "Nbt":
                    Frame.Navigate(typeof(NbtWindow));
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void Frame_OnNavigated(object sender, FANavigationEventArgs e)
    {
        FaNavigationView.IsBackEnabled = Frame.CanGoBack;
        
            switch (e.SourcePageType)
            {
                case var t when t == typeof(Play):
                    FaNavigationView.SelectedItem =
                        FaNavigationView.MenuItems.FirstOrDefault(i => ((FANavigationViewItem)i).Tag?.ToString() == "Play");
                    break;
                case var t when t == typeof(NbtWindow):
                    FaNavigationView.SelectedItem =
                        FaNavigationView.MenuItems.FirstOrDefault(i => ((FANavigationViewItem)i).Tag?.ToString() == "Nbt");
                    break; 
            }

            if (e.Content is Play play)
            {
                play.NavigateToSelect = () =>
                {
                    Frame.Navigate(typeof(VersionSelectionView));
                };
                play.NavigateSettings = () =>
                {
                    Frame.Navigate(typeof(VersionSettingsView));
                };
            }
    }
    


    private void FaNavigationView_OnBackRequested(object? sender, FANavigationViewBackRequestedEventArgs e)
    {
        if (Frame.CanGoBack)
        {
            Frame.GoBack();
        }
    }

    private void Frame_OnNavigating(object sender, FANavigatingCancelEventArgs e)
    {
        if (e.SourcePageType == Frame.CurrentSourcePageType)
        {
            e.Cancel = true;
        }
    }
}