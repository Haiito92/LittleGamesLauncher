using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Windows.UI;
using Windows.Graphics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LittleGamesLauncher.Views.Windows
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            if (AppWindow.Presenter is not OverlappedPresenter overlappedPresenter) return;

            AppWindow.Resize(new SizeInt32(1600,900));

            overlappedPresenter.IsMaximizable = false;
            overlappedPresenter.IsResizable = false;

            ExtendsContentIntoTitleBar = true;

            SetTitleBarColors();

            if (Content is FrameworkElement rootElement)
            {
                rootElement.ActualThemeChanged += OnThemeChanged;
            }
        }

        private void SetTitleBarColors()
        {
            AppWindowTitleBar titleBar = AppWindow.TitleBar;

            if (titleBar == null) return;

            if (Application.Current.Resources.TryGetValue("SecondaryColor", out object secondaryColor))
            {
                titleBar.ButtonBackgroundColor = (Color)secondaryColor;
            }

            if (Application.Current.Resources.TryGetValue("HoverSecondaryColor", out object hoverSecondaryColor))
            {
                titleBar.ButtonHoverBackgroundColor = (Color)hoverSecondaryColor;
            }

            if (Application.Current.Resources.TryGetValue("PressedSecondaryColor", out object pressedSecondaryColor))
            {
                titleBar.ButtonPressedBackgroundColor = (Color)pressedSecondaryColor;
            }

            if (Application.Current.Resources.TryGetValue("NeutralColor", out object neutralColor))
            {
                titleBar.ButtonForegroundColor = (Color)neutralColor;
                titleBar.ButtonHoverForegroundColor = (Color)neutralColor;
                titleBar.ButtonPressedForegroundColor = (Color)neutralColor;
            }

            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        private void OnThemeChanged(FrameworkElement sender, object args)
        {
            SetTitleBarColors();
        }
    }   
}
