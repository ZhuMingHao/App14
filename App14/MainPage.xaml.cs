using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App14
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            
        }     
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
               
                foreach(NavigationViewItemBase item in NvTest.MenuItems)
                {
                  if((string) item.Tag == contentFrame.CurrentSourcePageType.Name)
                    {
                        SelectItem = item;
                    }
                }
            }
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            base.OnNavigatedTo(e);
        }

        private NavigationViewItemBase selectItem;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {      
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public NavigationViewItemBase SelectItem
        {
            get
            {
                return selectItem;
            }
            set
            {
                selectItem = value;
                OnPropertyChanged();
            }
        }


        private void NvTest_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var selectedItem = (NavigationViewItem)args.SelectedItem;
            string pageName = "App14." + ((string)selectedItem.Tag);
            if ((string)selectedItem.Tag == "PlayPage")
            {
                this.Frame.Navigate(Type.GetType(pageName));
               
            }
            else
            {
                sender.Header = pageName;
                Type pageType = Type.GetType(pageName);
                contentFrame.Navigate(pageType);              
            }
                   
        }
    }
}
