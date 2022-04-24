using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace WorldEditHelper.Ui.Views;
public partial class TabFactoryView : UserControl
{
    public TabFactoryView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
