using System.Windows;

namespace SPACE_SHOOTER_GAME
{
    /// <summary>
    /// Interaction logic for Window_DialogBox.xaml
    /// </summary>
    public partial class Window_DialogBox : Window
    {
        #region Constructor     
        public Window_DialogBox()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
        }
        #endregion

        #region Event Handler Methods
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            UserClickedButton();
            Window_Game nextWindow = new Window_Game();
            nextWindow.ShowDialog();

        }
        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            UserClickedButton();
            Window_Introduction nextWindow = new Window_Introduction();
            nextWindow.ShowDialog();
        }
        #endregion

        #region User Defined Methods
        private void UserClickedButton()
        {
            Window_Game.isUserChoosen = true;
            this.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
