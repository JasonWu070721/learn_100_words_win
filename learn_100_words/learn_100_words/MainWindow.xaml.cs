using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace learn_100_words
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }



        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // you can also add items in code behind
            NavView.MenuItems.Add(new NavigationViewItemSeparator());
            NavView.MenuItems.Add(new NavigationViewItem()
            { Content = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });

            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                // find NavigationViewItem with Content that equals InvokedItem
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);
            }
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "home":
                    ContentFrame.Navigate(typeof(HomePage));
                    break;

                    //case "apps":
                    //    ContentFrame.Navigate(typeof(AppsPage));
                    //    break;

                    //case "games":
                    //    ContentFrame.Navigate(typeof(GamesPage));
                    //    break;

                    //case "music":
                    //    ContentFrame.Navigate(typeof(MusicPage));
                    //    break;

                    //case "content":
                    //    ContentFrame.Navigate(typeof(MyContentPage));
                    //    break;
            }
        }

        //private Window m_window;

        //private void myButton_Click(object sender, RoutedEventArgs e)
        //{
        //    myButton.Content = "Clicked";
        //}

        //public void SetCurrentNavigationViewItem( NavigationViewItem item)
        //{
        //    if (item == null)
        //    {
        //        return;
        //    }

        //    if (item.Tag == null)
        //    {
        //        return;
        //    }

        //    ContentFrame.Navigate(
        //    Type.GetType(item.Tag.ToString()),
        //    item.Content);
        //    NavigationView.Header = item.Content;
        //    NavigationView.SelectedItem = item;
        //}

        //public List<NavigationViewItem> GetNavigationViewItems()
        //{
        //    var result = new List<NavigationViewItem>();
        //    var items = NavigationView.MenuItems.Select(i => (NavigationViewItem)i).ToList();
        //    items.AddRange(NavigationView.FooterMenuItems.Select(i => (NavigationViewItem)i));
        //    result.AddRange(items);

        //    foreach (NavigationViewItem mainItem in items)
        //    {
        //        result.AddRange(mainItem.MenuItems.Select(i => (NavigationViewItem)i));
        //    }

        //    return result;
        //}

        //public List<NavigationViewItem> GetNavigationViewItems(
        //    Type type)
        //{
        //    return GetNavigationViewItems().Where(i => i.Tag.ToString() == type.FullName).ToList();
        //}

        //public List<NavigationViewItem> GetNavigationViewItems(
        //    Type type,
        //    string title)
        //{
        //    return GetNavigationViewItems(type).Where(ni => ni.Content.ToString() == title).ToList();
        //}

        //private void NavigationView_Loaded( object sender, RoutedEventArgs e)
        //{
        //    // Navigates, but does not update the Menu.
        //    // ContentFrame.Navigate(typeof(HomePage));

        //    SetCurrentNavigationViewItem(GetNavigationViewItems(typeof(HomePage)).First());
        //}
    }
}
