using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Ty.Ck.Desktop.Infrastructure;
using Ty.Ck.Desktop.ViewModels.Pages;

namespace Ty.Ck.Desktop.ViewModels;

public sealed class MainWindowViewModel : ObservableObject
{
    private NavigationItemViewModel? selectedNavigationItem;
    private WorkspacePageViewModel? currentPage;

    public MainWindowViewModel()
    {
        NavigationItems =
        [
            new NavigationItemViewModel("首页", "\uE80F", "NavHome", new HomePageViewModel()),
            new NavigationItemViewModel("巡检任务", "\uE9D9", "NavTasks", new InspectionTasksPageViewModel()),
            new NavigationItemViewModel("设备台账", "\uE7F4", "NavDevices", new DeviceLedgerPageViewModel()),
            new NavigationItemViewModel("总览", "\uE7C3", "NavOverview", new OverviewPageViewModel()),
            new NavigationItemViewModel("异常复核", "\uE9CE", "NavReview", new ReviewPageViewModel()),
            new NavigationItemViewModel("通知记录", "\uE8BD", "NavNotifications", new NotificationRecordsPageViewModel()),
            new NavigationItemViewModel("系统设置", "\uE713", "NavSettings", new SettingsPageViewModel())
        ];

        NavigateCommand = new RelayCommand(
            parameter =>
            {
                if (parameter is NavigationItemViewModel item)
                {
                    SelectedNavigationItem = item;
                }
            });

        CurrentDateText = DateTime.Now.ToString("yyyy年M月d日 dddd", CultureInfo.GetCultureInfo("zh-CN"));
        SelectedNavigationItem = NavigationItems.First();
    }

    public ObservableCollection<NavigationItemViewModel> NavigationItems { get; }

    public ICommand NavigateCommand { get; }

    public string CurrentDateText { get; }

    public NavigationItemViewModel? SelectedNavigationItem
    {
        get => selectedNavigationItem;
        set
        {
            if (!SetProperty(ref selectedNavigationItem, value))
            {
                return;
            }

            foreach (var item in NavigationItems)
            {
                item.IsSelected = ReferenceEquals(item, value);
            }

            CurrentPage = value?.Page;
            OnPropertyChanged(nameof(CurrentPageTitle));
            OnPropertyChanged(nameof(CurrentPageDescription));
        }
    }

    public WorkspacePageViewModel? CurrentPage
    {
        get => currentPage;
        private set => SetProperty(ref currentPage, value);
    }

    public string CurrentPageTitle => CurrentPage?.Title ?? string.Empty;

    public string CurrentPageDescription => CurrentPage?.Description ?? string.Empty;
}
