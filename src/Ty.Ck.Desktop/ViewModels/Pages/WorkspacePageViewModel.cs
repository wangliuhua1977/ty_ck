namespace Ty.Ck.Desktop.ViewModels.Pages;

public abstract class WorkspacePageViewModel
{
    protected WorkspacePageViewModel(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; }

    public string Description { get; }
}
