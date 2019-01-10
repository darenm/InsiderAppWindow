using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Core.Preview;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewSdkTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private AppWindow _newWindow;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += this.MainPage_Loaded;

            ApplicationView.GetForCurrentView().Consolidated += OnConsolidated;
        }

        private void OnConsolidated(ApplicationView sender, ApplicationViewConsolidatedEventArgs args)
        {
            _newWindow?.CloseAsync();
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await CreateChildWindowAsync();
        }

        private async Task CreateChildWindowAsync()
        {
            _newWindow = await AppWindow.TryCreateAsync();
            _newWindow.RequestSize(new Size(200, 200));
            _newWindow.RequestMoveAdjacentToCurrentView();
            _newWindow.Frame.SetFrameStyle(AppWindowFrameStyle.NoFrame);
            _newWindow.Presenter.RequestPresentation(AppWindowPresentationKind.CompactOverlay);
            await _newWindow.TryShowAsync();
        }
    }
}
