using Ty.Ck.Desktop.Infrastructure;
using Ty.Ck.Desktop.ViewModels.Pages;

namespace Ty.Ck.Desktop.ViewModels;

public sealed class NavigationItemViewModel : ObservableObject
{
    private bool isSelected;

    public NavigationItemViewModel(string title, string glyph, string automationId, WorkspacePageViewModel page)
    {
        Title = title;
        Glyph = glyph;
        AutomationId = automationId;
        Page = page;
    }

    public string Title { get; }

    public string Glyph { get; }

    public string AutomationId { get; }

    public WorkspacePageViewModel Page { get; }

    public bool IsSelected
    {
        get => isSelected;
        set => SetProperty(ref isSelected, value);
    }
}
