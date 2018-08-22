using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Luogu
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItemBase item in this.mainNavigation.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Home")
                {
                    mainNavigation.SelectedItem = item;
                    break;
                }
            }
            this.contentFrame = new Frame();
            this.contentFrame.Navigate(typeof(HomePage));
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                this.contentFrame.Navigate(typeof(SettingsPage));
            }
            else
                switch (sender.Tag)
                {
                    case "Home":
                        this.contentFrame.Navigate(typeof(HomePage));
                        break;
                    case "Problem":
                        this.contentFrame.Navigate(typeof(ProblemListPage));
                        break;
                    case "Discuss":
                        this.contentFrame.Navigate(typeof(DiscussListPage));
                        break;
                    case "Benben":
                        this.contentFrame.Navigate(typeof(BenbenPage));
                        break;
                    case "Self":
                        this.contentFrame.Navigate(typeof(SelfPage));
                        break;
                    case "Blog":
                        this.contentFrame.Navigate(typeof(BlogPage));
                        break;
                    default:
                        this.contentFrame.Navigate(typeof(HomePage));
                        break;
                }
        }
    }
}
