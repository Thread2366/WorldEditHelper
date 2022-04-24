using ReactiveUI;
using System.Reactive;

namespace WorldEditHelper.Ui.ViewModels;

public class TabFactoryViewModel : ViewModelBase
{
    public TabFactoryViewModel()
    {
        AddTab = ReactiveCommand.Create(() => { });
    }

    public ReactiveCommand<Unit, Unit> AddTab { get; }
}
