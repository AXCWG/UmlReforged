using System;
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
        FaNavigationView.SelectedItem = Default;
        
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

    // private void Frame_OnNavigated(object sender, FANavigationEventArgs e)
    // {
    //     if (e.SourcePageType == typeof(NBTWindow))
    //     {
    //         (e.Content as NBTWindow).OnNavigated();
    //     }
    // }

   
}