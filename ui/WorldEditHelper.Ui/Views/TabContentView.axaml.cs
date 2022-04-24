using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace WorldEditHelper.Ui.Views;
public partial class TabContentView : UserControl
{
    public TabContentView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
