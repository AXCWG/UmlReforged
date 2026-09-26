using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Platform.Storage;
using Avalonia.VisualTree;
using AvaloniaApplication1.ViewModels;
using AXExpansion;
using fNbt;

namespace AvaloniaApplication1.Views;

public partial class NbtWindow : UserControl
{
    public NbtWindow()
    {
        InitializeComponent();
        DataContext = NBTUserControlStaticState.Instance;
        Console.WriteLine("Created NBTWindow");
        TreeView.DataTemplates.Add(new FuncDataTemplate<NbtTag>( (s, e) => new NbtTreePresenter()
        {
            DataContext = new NbtTreePresenterViewModel()
            {
                NbtTag = s
            },
            Name = s.Uuid.ToString()
        }));
    }

    private async void SaveClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private async void LoadClick(object? sender, RoutedEventArgs e)
    {
        var filePickerFileType = new FilePickerFileType("Dat Files").With(t =>
        {
            t.Patterns = ["*.dat"];
        });
        var res = await TopLevel.GetTopLevel(this)!.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            AllowMultiple = false, FileTypeFilter = [filePickerFileType], SuggestedFileType = filePickerFileType
        });
        ((NBTUserControlStaticState)DataContext).LoadFileCommand(res[0].Path.AbsolutePath);
    }

    private void EditTagValue(object? sender, TappedEventArgs e)
    {
        throw new NotImplementedException();
    }


    private async void TreeView_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var eAddedItem = ((NbtTag?)e.AddedItems[0]);
        if (eAddedItem is null)
        {
            return; 
        }
        if (eAddedItem.TagType != NbtTagType.Compound && eAddedItem.TagType != NbtTagType.List)
        {
            var dialog = new NbtSetValueDialogue(eAddedItem);
            await dialog.ShowDialog((Window)TopLevel.GetTopLevel(this)!);
            ((NbtTreePresenterViewModel)((NbtTreePresenter)TreeView.FindDescendantOfType<NbtTreePresenter>(false,
                o => o.Name == eAddedItem.Uuid.ToString())).DataContext).Update();

        }
    }
}