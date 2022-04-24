using ReactiveUI;
using System.Reactive;

namespace WorldEditHelper.Ui.ViewModels;

public class TabContentViewModel : ViewModelBase
{
    public string Text { get; }

    public TabContentViewModel(string text)
    {
        Text = text;

        Close = ReactiveCommand.Create(() => { });
    }

    public ReactiveCommand<Unit, Unit> Close { get; }
}
