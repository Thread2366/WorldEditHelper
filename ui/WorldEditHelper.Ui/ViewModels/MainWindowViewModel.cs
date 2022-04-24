using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using WorldEditHelper.Ui.Models;

namespace WorldEditHelper.Ui.ViewModels;
public class MainWindowViewModel : ViewModelBase
{
    private readonly TabFactoryViewModel _tabFactory = new();

    public MainWindowViewModel()
    {
        _tabFactory.AddTab
            .Take(1)
            .Subscribe(_ => AddItem());
        
        Tabs = new()
        {
            new TabItemModel("One", new TabContentViewModel("First tab content")),
            new TabItemModel("Two", new TabContentViewModel("Second tab content")),
            new TabItemModel("+", _tabFactory, false)
        };
    }

    public ObservableCollection<TabItemModel> Tabs { get; set; }

    public void AddItem()
    {
        Tabs.Insert(Tabs.Count - 1, new TabItemModel("New", new TabContentViewModel("New tab content")));
    }
}
