using Hotels_Manager.ViewModels;
using Hotels_Manager.Views.Pages;
using System.Windows;

namespace Hotels_Manager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += GlobalExceptionHandler.OnDispatcherUnhandledException;

            MainWindow mainWindow = new MainWindow();
            //mainWindow.WindowState = WindowState.Maximized;

            MainPage mainPage = new MainPage();
            HotelPage hotelPage = new HotelPage();
            FloorPage floorPage = new FloorPage();
            RoomPage roomPage = new RoomPage();
            GuestPage guestPage = new GuestPage();
            GuestListPage guestListPage = new GuestListPage();
            ReservationsListPage reservationsListPage = new ReservationsListPage();

            MainViewModel mainViewModel = new MainViewModel(mainPage, hotelPage, floorPage, 
                roomPage, guestPage, guestListPage, reservationsListPage);

            mainWindow.DataContext = mainViewModel;
            mainPage.DataContext = mainViewModel;
            hotelPage.DataContext = mainViewModel;
            floorPage.DataContext = mainViewModel;
            roomPage.DataContext = mainViewModel;
            guestPage.DataContext = mainViewModel;
            guestListPage.DataContext = mainViewModel;
            reservationsListPage.DataContext = mainViewModel;

            mainWindow.Show();
        }
    }

}
