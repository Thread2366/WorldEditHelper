using WorldEditHelper.Ui.ViewModels;

namespace WorldEditHelper.Ui.Models;

public class TabItemModel
{
    public string Header { get; }
    public ViewModelBase Content { get; }
    public bool IsClosable { get; }
    public TabItemModel(string header, ViewModelBase content, bool isClosable = true)
    {
        Header = header;
        Content = content;
        IsClosable = isClosable;
    }
}
