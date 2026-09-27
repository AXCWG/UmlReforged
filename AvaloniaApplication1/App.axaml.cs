using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using System.Text.Json;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.DataType;
using AvaloniaApplication1.ViewModels;
using AvaloniaApplication1.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaApplication1;

public partial class App : Application
{
    public new static App Current => (App)Application.Current!;
    [NotNull]
    public  ServiceProvider Services { get; set; } 
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var sCollection = new ServiceCollection();
        #region HandleAppData

        if (!File.Exists("config.json"))
        {
            var appdata = new ApplicationData
            {
                Folders = [],
                StoredNames = []
            };
            sCollection.AddSingleton(appdata);
        }
        else
        {
            try
            {
                var appdata = JsonSerializer.Deserialize<ApplicationData>(File.ReadAllText("config.json"),
                    AppJsonSerializer.Default.ApplicationData) ?? throw new NullReferenceException();
                sCollection.AddSingleton(appdata);
            }
            catch (Exception)
            {
                File.Delete("config.json");
                sCollection.AddSingleton( new ApplicationData
                {
                    Folders = [],
                    StoredNames = []
                });
            }
            
        }
        #endregion
        //TODO OnClose
        sCollection.AddTransient<MainWindowViewModel>();

        
        sCollection.AddTransient<NbtTreePresenterViewModel>();
        sCollection.AddTransient < PlayViewModel> (); 
        Services =  sCollection.BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Services.GetRequiredService<MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}