using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotels_Manager.Models;
using Hotels_Manager.Views.Dialogs;
using Hotels_Manager.Views.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Hotels_Manager.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel(MainPage mainPage, HotelPage hotelPage, FloorPage floorPage, RoomPage roomPage,
            GuestPage guestPage, GuestListPage guestListPage, ReservationsListPage reservationsListPage)
        {
            CheckWindowState();

            // Pages setting
            this.mainPage = mainPage;
            this.hotelPage = hotelPage;
            this.floorPage = floorPage;
            this.roomPage = roomPage;
            this.guestPage = guestPage;
            this.guestListPage = guestListPage;
            this.reservationsListPage = reservationsListPage;

            // Data base context initialization
            _context = new ApplicationContext();

            _dataBase = new DataBaseAccess(_context);

            // Loading data from data base
            LoadDataFromDataBase();

            CurrentPage = this.mainPage;

            // Explicit command definition  
            AddNewHotelCommand = new RelayCommand(AddNewHotel, CanAddNewHotel);
            AddNewFloorCommand = new RelayCommand(AddNewFloor, CanAddNewFloor);
            AddNewRoomCommand = new RelayCommand(AddNewRoom, CanAddNewRoom);
            AddNewGuestCommand = new RelayCommand(AddNewGuest, CanAddNewGuest);
            AddNewRoomTypeCommand = new RelayCommand(AddNewRoomType, CanAddNewRoomType);

            // Default properties setting
            SetDefaultProperties();
        }

        // Properties
        #region ...
        private DataBaseAccess _dataBase { get; set; }
        private ApplicationContext _context { get; set; }

        // Pages instances
        #region ...
        private MainPage mainPage { get; set; }
        private HotelPage hotelPage { get; set; }
        private FloorPage floorPage { get; set; }
        private RoomPage roomPage { get; set; }
        private GuestPage guestPage { get; set; }
        private GuestListPage guestListPage { get; set; }
        private ReservationsListPage reservationsListPage { get; set; }
        #endregion

        // Dialogs for creating new entities
        #region ...
        private CreateNewHotelDialog? newHotelDialog { get; set; }
        private CreateNewFloorDialog? newFloorDialog { get; set; }
        private CreateNewRoomDialog? newRoomDialog { get; set; }
        private CreateNewGuestDialog? newGuestDialog { get; set; }
        private CreateNewRoomTypeDialog? newRoomTypeDialog { get; set; }
        #endregion

        private GuestEditingStates GuestEditingStatus { get; set; } = GuestEditingStates.None;
        private enum GuestEditingStates
        {
            FromGuestList,
            FromRoomEditInterface,
            None
        }

        // Binding collections
        #region ...
        [ObservableProperty]
        private ObservableCollection<Hotel>? hotels;

        [ObservableProperty]
        private ObservableCollection<Guest>? guests;

        [ObservableProperty]
        private ObservableCollection<Reservation>? reservations;

        [ObservableProperty]
        private ObservableCollection<RoomType>? roomTypes;
        #endregion

        [ObservableProperty]
        private Visibility _maximizeButtonVisibility;

        [ObservableProperty]
        private Visibility _restoreButtonVisibility;

        [ObservableProperty]
        private Visibility _roomTypeEditingPanelVisibility;

        [ObservableProperty]
        private Thickness _mainBorderThickness;

        [ObservableProperty]
        private Page _currentPage;

        // Selected entities and their old data
        #region ...
        [ObservableProperty]
        private Hotel? _selectedHotel;
        private Hotel? SelectedHotelOldData { get; set; }

        [ObservableProperty]
        private Floor? _selectedFloor;
        private Floor? SelectedFloorOldData { get; set; }

        [ObservableProperty]
        private Room? _selectedRoom;
        private Room? SelectedRoomOldData { get; set; }

        [ObservableProperty]
        private Guest? _selectedGuest;
        private Guest? SelectedGuestOldData { get; set; }

        [ObservableProperty]
        private RoomType? _selectedRoomTypeItem;
        private RoomType? SelectedRoomTypeOldData { get; set; }
        #endregion

        [ObservableProperty]
        private int _totalGuestsForSelectedFloor;

        [ObservableProperty]
        private bool _hotelIsEditing;

        [ObservableProperty]
        private bool _floorIsEditing;

        [ObservableProperty]
        private bool _roomIsEditing;

        [ObservableProperty]
        private bool _guestIsEditing;

        // Fields for entering new data
        #region ...
        private string? _newHotelName;
        public string? NewHotelName
        {
            get => _newHotelName;
            set
            {
                SetProperty(ref _newHotelName, value);
                AddNewHotelCommand.NotifyCanExecuteChanged();
            }
        }

        private string? _newHotelAddress;
        public string? NewHotelAddress
        {
            get => _newHotelAddress;
            set
            {
                SetProperty(ref _newHotelAddress, value);
                AddNewHotelCommand.NotifyCanExecuteChanged();
            }
        }

        private int _newHotelStarCount;
        public int NewHotelStarCount
        {
            get => _newHotelStarCount;
            set
            {
                SetProperty(ref _newHotelStarCount, value);
                AddNewHotelCommand.NotifyCanExecuteChanged();
            }
        }

        private string? _newFloorNumber;
        public string? NewFloorNumber
        {
            get { return _newFloorNumber; }
            set
            {
                SetProperty(ref _newFloorNumber, value);
                AddNewFloorCommand.NotifyCanExecuteChanged();
            }
        }

        private string? _newRoomNumber;
        public string? NewRoomNumber
        {
            get { return _newRoomNumber; }
            set
            {
                SetProperty(ref _newRoomNumber, value);
                AddNewRoomCommand.NotifyCanExecuteChanged();
            }
        }

        private RoomType? _newRoomSelectedRoomType;
        public RoomType? NewRoomSelectedRoomType
        {
            get { return _newRoomSelectedRoomType; }
            set
            {
                SetProperty(ref _newRoomSelectedRoomType, value);
                AddNewRoomCommand.NotifyCanExecuteChanged();
            }
        }

        private string? _newGuestFirstName;
        public string? NewGuestFirstName
        {
            get { return _newGuestFirstName; }
            set
            {
                SetProperty(ref _newGuestFirstName, value);
                AddNewGuestCommand.NotifyCanExecuteChanged();
            }
        }

        private string? _newGuestLastName;
        public string? NewGuestLastName
        {
            get { return _newGuestLastName; }
            set
            {
                SetProperty(ref _newGuestLastName, value);
                AddNewGuestCommand.NotifyCanExecuteChanged();
            }
        }

        private string? _newGuestAge;
        public string? NewGuestAge
        {
            get { return _newGuestAge; }
            set
            {
                SetProperty(ref _newGuestAge, value);
                AddNewGuestCommand.NotifyCanExecuteChanged();
            }
        }

        private string? _newGuestDurationInDays;
        public string? NewGuestDurationInDays
        {
            get { return _newGuestDurationInDays; }
            set
            {
                SetProperty(ref _newGuestDurationInDays, value);
                AddNewGuestCommand.NotifyCanExecuteChanged();
            }
        }

        [ObservableProperty]
        private string? _newGuestReservationDurationInDays;

        private string? _newRoomTypeName;
        public string? NewRoomTypeName
        {
            get { return _newRoomTypeName; }
            set
            {
                SetProperty(ref _newRoomTypeName, value);
                AddNewRoomTypeCommand.NotifyCanExecuteChanged();
            }
        }

        private string? _newRoomTypeCapacity;
        public string? NewRoomTypeCapacity
        {
            get { return _newRoomTypeCapacity; }
            set
            {
                SetProperty(ref _newRoomTypeCapacity, value);
                AddNewRoomTypeCommand.NotifyCanExecuteChanged();
            }
        }

        private string? _newRoomTypePrice;
        public string? NewRoomTypePrice
        {
            get { return _newRoomTypePrice; }
            set
            {
                SetProperty(ref _newRoomTypePrice, value);
                AddNewRoomTypeCommand.NotifyCanExecuteChanged();
            }
        }
        #endregion

        #endregion

        // Commands
        #region ...
        public RelayCommand AddNewHotelCommand { get; }
        public RelayCommand AddNewFloorCommand { get; }
        public RelayCommand AddNewRoomCommand { get; }
        public RelayCommand AddNewGuestCommand { get; }
        public RelayCommand AddNewRoomTypeCommand { get; }

        [RelayCommand]
        private void WindowStateChanged()
        {
            CheckWindowState();
        }

        [RelayCommand]
        private void CloseMainWindow()
        {
            Application.Current.Shutdown();
        }

        [RelayCommand]
        private void ShowMainWindowByTray()
        {
            Application.Current.MainWindow.Show();
        }

        [RelayCommand]
        private void HideMainWindow()
        {
            Application.Current.MainWindow.Hide();
        }

        [RelayCommand]
        private void MinimizeMainWindow()
        {
            SystemCommands.MinimizeWindow(Application.Current.MainWindow);
        }

        [RelayCommand]
        private void MaximizeMainWindow()
        {
            SystemCommands.MaximizeWindow(Application.Current.MainWindow);
        }

        [RelayCommand]
        private void RestoreMainWindow()
        {
            SystemCommands.RestoreWindow(Application.Current.MainWindow);
        }

        // Navigation commands (main, guests, reservations pages)
        #region ...

        [RelayCommand]
        private void SelectMainPage()
        {
            if (GetCancelAccept())
            {
                SetOldDataToItems();
                ChangeEditingStatus(false);
                CurrentPage = this.mainPage;
            }
        }

        [RelayCommand]
        private void SelectGuestListPage()
        {
            if (GetCancelAccept())
            {
                SetOldDataToItems();
                ChangeEditingStatus(false);
                CurrentPage = this.guestListPage;
            }
        }

        [RelayCommand]
        private void SelectReservationListPage()
        {
            if (GetCancelAccept())
            {
                SetOldDataToItems();
                ChangeEditingStatus(false);
                CurrentPage = this.reservationsListPage;
            }
        }
        #endregion

        // Hotel commands
        #region ...

        [RelayCommand]
        private void ShowAddHotelDialog()
        {
            newHotelDialog = new CreateNewHotelDialog(this, Application.Current.MainWindow);
            newHotelDialog.ShowDialog();
        }

        [RelayCommand]
        private void OpenHotelEditPage(Hotel hotel)
        {
            if (hotel != null)
            {
                SelectedHotel = hotel;
                HotelIsEditing = true;
                SelectedHotelOldData = new Hotel()
                {
                    Id = hotel.Id,
                    Name = hotel.Name,
                    Address = hotel.Address,
                    Stars = hotel.Stars,
                    Floors = hotel.Floors
                };

                CurrentPage = this.hotelPage;
            }
        }

        private void AddNewHotel()
        {
            if (Hotels != null && !string.IsNullOrEmpty(NewHotelName) && !string.IsNullOrEmpty(NewHotelAddress) && NewHotelStarCount > 0)
            {
                var hotel = new Hotel { Name = NewHotelName, Address = NewHotelAddress, Stars = NewHotelStarCount };

                _dataBase.Add<Hotel>(hotel);

                Hotels.Add(hotel);

                NewHotelAddress = string.Empty;
                NewHotelName = string.Empty;
                NewHotelStarCount = 5;
            }
        }

        private bool CanAddNewHotel()
        {
            return !string.IsNullOrEmpty(NewHotelName) && !string.IsNullOrEmpty(NewHotelAddress) && NewHotelStarCount > 0;
        }

        [RelayCommand]
        private void RemoveHotel(Hotel hotel)
        {
            if (Hotels != null && hotel != null)
            {
                ConfirmDialog confirmDialog = new ConfirmDialog(description: $"Are you sure you want to delete hotel '{hotel.Name}'? " +
                    "All data associated with it will also be deleted.", windowOwner: Application.Current.MainWindow);

                if (confirmDialog.ShowDialog() == true)
                {
                    _dataBase.Remove<Hotel>(hotel);
                    Hotels.Remove(hotel);
                    UpdateReservationList();
                }
            }
        }

        [RelayCommand]
        private void SaveNewHotelData()
        {
            if(!string.IsNullOrWhiteSpace(SelectedHotel!.Name) && !string.IsNullOrWhiteSpace(SelectedHotel!.Address))
            {
                _dataBase.Update<Hotel>(SelectedHotel);

                HotelIsEditing = false;
                CurrentPage = this.mainPage;
            }
        }

        [RelayCommand]
        private void CancelHotelUpdating()
        {
            ConfirmDialog confirmDialog = new ConfirmDialog(description: "Cancel hotel editing? The entered information will not be saved.", windowOwner: Application.Current.MainWindow);

            if (HotelIsChanged())
            {
                if (confirmDialog.ShowDialog() == true)
                {
                    SetOldDataToSelectedHotel();

                    HotelIsEditing = false;
                    CurrentPage = this.mainPage;
                }
            }
            else
            {
                HotelIsEditing = false;
                CurrentPage = this.mainPage;
            }
        }
        #endregion

        // Floor commands
        #region ...
        [RelayCommand]
        private void ShowAddFloorDialog()
        {
            newFloorDialog = new CreateNewFloorDialog(this, Application.Current.MainWindow);
            NewFloorNumber = (SelectedHotel!.Floors.Count + 1).ToString();

            newFloorDialog.ShowDialog();
        }

        [RelayCommand]
        private void OpenFloorEditPage(Floor floor)
        {
            if (floor != null)
            {
                SelectedFloor = floor;
                UpdateSelectedFloorGuestCount();
                SelectedFloorOldData = new Floor()
                {
                    Id = floor.Id,
                    Number = floor.Number,
                    Hotel = floor.Hotel,
                    HotelId = floor.HotelId,
                    Rooms = floor.Rooms,
                    TotalRooms = floor.TotalRooms
                };

                FloorIsEditing = true;

                CurrentPage = this.floorPage;
            }
        }

        private void AddNewFloor()
        {
            if (!string.IsNullOrEmpty(NewFloorNumber))
            {
                var floor = new Floor
                {
                    Number = int.Parse(NewFloorNumber),
                    HotelId = SelectedHotel!.Id,
                    Hotel = SelectedHotel
                };

                _dataBase.Add<Floor>(floor);

                NewFloorNumber = string.Empty;
            }
        }

        private bool CanAddNewFloor()
        {
            return int.TryParse(NewFloorNumber, out _);
        }

        [RelayCommand]
        private void RemoveFloor(Floor? floor)
        {
            if (floor != null && SelectedHotel!.Floors.Contains(floor))
            {
                ConfirmDialog confirmDialog = new ConfirmDialog(description: $"Are you sure you want to delete the hotel floor '{SelectedHotel.Name}' under the number '{floor.Number}' ? " +
                    "All data associated with it will also be deleted.", windowOwner: Application.Current.MainWindow);

                if (confirmDialog.ShowDialog() == true)
                {
                    _dataBase.Remove<Floor>(floor);
                    UpdateReservationList();
                }
            }
        }

        [RelayCommand]
        private void SaveNewFloorData()
        {
            _dataBase.Update<Floor>(SelectedFloor!);

            FloorIsEditing = false;
            CurrentPage = this.hotelPage;
        }

        [RelayCommand]
        private void CancelFloorUpdating()
        {
            ConfirmDialog confirmDialog = new ConfirmDialog(description: "Cancel floor editing? The entered information will not be saved.", windowOwner: Application.Current.MainWindow);

            if (FloorIsChanged())
            {
                if (confirmDialog.ShowDialog() == true)
                {
                    SetOldDataToSelectedFloor();

                    FloorIsEditing = false;

                    CurrentPage = this.hotelPage;
                }
            }
            else
            {
                FloorIsEditing = false;
                CurrentPage = this.hotelPage;
            }
        }
        #endregion

        // Room commands
        #region ...

        [RelayCommand]
        private void ShowAddRoomDialog()
        {
            newRoomDialog = new CreateNewRoomDialog(this, Application.Current.MainWindow);
            NewRoomNumber = (SelectedFloor!.Rooms.Count + 1).ToString();

            newRoomDialog.ShowDialog();
        }

        [RelayCommand]
        private void OpenRoomEditPage(Room room)
        {
            if (room != null)
            {
                SelectedRoom = room;
                SelectedRoomOldData = new Room()
                {
                    Id = room.Id,
                    Number = room.Number,
                    Floor = room.Floor,
                    FloorId = room.FloorId,
                    Guests = room.Guests,
                    Reservations = room.Reservations,
                    RoomType = room.RoomType,
                    RoomTypeId = room.RoomTypeId,
                    TotalGuests = room.TotalGuests
                };

                RoomIsEditing = true;

                CurrentPage = this.roomPage;
            }
        }

        private void AddNewRoom()
        {
            if (!string.IsNullOrEmpty(NewRoomNumber) && NewRoomSelectedRoomType != null)
            {
                var room = new Room
                {
                    Number = int.Parse(NewRoomNumber),
                    FloorId = SelectedFloor!.Id,
                    Floor = SelectedFloor,
                    RoomTypeId = NewRoomSelectedRoomType.Id,
                    RoomType = NewRoomSelectedRoomType
                };

                _dataBase.Add<Room>(room);

                NewRoomNumber = string.Empty;
            }
        }


        private bool CanAddNewRoom()
        {
            return int.TryParse(NewRoomNumber, out _) && NewRoomSelectedRoomType != null;
        }

        [RelayCommand]
        private void RemoveRoom(Room? room)
        {
            if (room != null && SelectedFloor!.Rooms.Contains(room))
            {
                ConfirmDialog confirmDialog = new ConfirmDialog(description: $"Are you sure you want to delete the room '{SelectedHotel!.Name}' under the number '{room.Number}' ? " +
                    "All data associated with it will also be deleted.", windowOwner: Application.Current.MainWindow);

                if (confirmDialog.ShowDialog() == true)
                {
                    _dataBase.Remove<Room>(room);

                    UpdateReservationList();
                    UpdateSelectedFloorGuestCount();
                }
            }
        }

        [RelayCommand]
        private void SaveNewRoomData()
        {
            _dataBase.Update<Room>(SelectedRoom!);

            RoomIsEditing = false;
            CurrentPage = this.floorPage;
        }

        [RelayCommand]
        private void CancelRoomUpdating()
        {
            ConfirmDialog confirmDialog = new ConfirmDialog(description: "Cancel room editing? The entered information will not be saved.", windowOwner: Application.Current.MainWindow);

            if (RoomIsChanged())
            {
                if (confirmDialog.ShowDialog() == true)
                {
                    SetOldDataToSelectedRoom();

                    RoomIsEditing = false;
                    CurrentPage = this.floorPage;
                }
            }
            else
            {
                RoomIsEditing = false;
                CurrentPage = this.floorPage;
            }
        }
        #endregion

        // Guest commands
        #region ...

        [RelayCommand]
        private void ShowAddGuestDialog()
        {
            newGuestDialog = new CreateNewGuestDialog(this, Application.Current.MainWindow);
            newGuestDialog.ShowDialog();
        }

        // Called by clicking on the button located on the guest item in the selected room page
        [RelayCommand]
        private void OpenGuestEditPage(Guest guest)
        {
            GuestEditingStatus = GuestEditingStates.FromRoomEditInterface;
            OpenGuestEditPageLogic(guest);
        }

        // Called by clicking on the button located on the guest item in the global guest list page
        //[RelayCommand]
        //private void OpenGuestEditPageFromGuestList(Guest guest)
        //{
        //    GuestEditingStatus = GuestEditingStates.FromGuestList;
        //    OpenGuestEditPageLogic(guest);
        //}

        private void OpenGuestEditPageLogic(Guest guest)
        {
            if (guest != null)
            {
                SelectedGuest = guest;
                SelectedGuestOldData = new Guest()
                {
                    Id = guest.Id,
                    FirstName = guest.FirstName,
                    LastName = guest.LastName,
                    Age = guest.Age,
                    Reservation = guest.Reservation,
                    Room = guest.Room,
                    RoomId = guest.RoomId
                };

                NewGuestReservationDurationInDays = CalculateDurationInDays(guest).ToString();

                GuestIsEditing = true;
                CurrentPage = this.guestPage;
            }
        }

        private void AddNewGuest()
        {
            if (Guests != null && RoomTypes != null && Reservations != null && 
                !string.IsNullOrEmpty(NewGuestFirstName) && !string.IsNullOrEmpty(NewGuestAge) 
                && !string.IsNullOrEmpty(NewGuestLastName) && !string.IsNullOrEmpty(NewGuestDurationInDays))
            {

                if (SelectedRoom!.Guests.Count < RoomTypes.FirstOrDefault(rtp => rtp.Id == SelectedRoom.RoomTypeId)!.Capacity)
                {
                    DateTime date = DateTime.Now.Date;

                    var guest = new Guest
                    {
                        FirstName = NewGuestFirstName,
                        LastName = NewGuestLastName,
                        Age = int.Parse(NewGuestAge),
                        RoomId = SelectedRoom.Id,
                        Room = SelectedRoom
                    };

                    _dataBase.Add<Guest>(guest);

                    var reservation = new Reservation
                    {
                        GuestId = guest.Id,
                        Guest = guest,
                        CheckInDate = date.ToString("dd.MM.yyyy"),
                        CheckOutDate = date.AddDays(double.Parse(NewGuestDurationInDays)).ToString("dd.MM.yyyy"),
                        TotalPrice = CalculatePrice(int.Parse(NewGuestDurationInDays),
                        RoomTypes.FirstOrDefault(rtp => rtp.Id == SelectedRoom.RoomTypeId)!.Price)
                    };

                    _dataBase.Add<Reservation>(reservation);

                    Guests.Add(guest);
                    Reservations.Add(reservation);

                    UpdateSelectedFloorGuestCount();

                    NewGuestFirstName = string.Empty;
                    NewGuestLastName = string.Empty;
                    NewGuestAge = string.Empty;
                    NewGuestDurationInDays = string.Empty;
                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog(description: $"The operation has been cancelled! The number of guests in the room type has been exceeded.", 
                        windowOwner: Application.Current.MainWindow);

                    messageDialog.ShowDialog();
                }

            }
        }

        private bool CanAddNewGuest()
        {
            return int.TryParse(NewGuestAge, out _) && int.TryParse(NewGuestDurationInDays, out _) && !string.IsNullOrEmpty(NewGuestFirstName) && !string.IsNullOrEmpty(NewGuestLastName);
        }

        // When room selected
        [RelayCommand]
        private void RemoveGuestFromRoom(Guest? guest)
        {
            if (Reservations != null && Guests != null && guest != null && SelectedRoom!.Guests.Contains(guest))
            {
                ConfirmDialog confirmDialog = new ConfirmDialog(description: $"Ви точно бажаєте видалити гістя готелю '{SelectedHotel!.Name}' призвише ім'я якого: " +
                    $"'{guest.LastName} {guest.FirstName}'? ", windowOwner: Application.Current.MainWindow);

                if (confirmDialog.ShowDialog() == true)
                {
                    _dataBase.Remove<Guest>(guest);

                    UpdateReservationList();

                    UpdateSelectedFloorGuestCount();
                }
            }
        }

        [RelayCommand]
        private void SaveNewGuestData()
        {
            if (!string.IsNullOrWhiteSpace(SelectedGuest!.FirstName) 
                && !string.IsNullOrWhiteSpace(SelectedGuest!.LastName)
                && double.TryParse(NewGuestReservationDurationInDays, out _)
                && Reservations != null)
            {
                // updating guest in data base
                _dataBase.Update<Guest>(SelectedGuest);

                // getting related reservation instance
                var reservation_ = _dataBase.GetAll<Reservation>().FirstOrDefault(res => res.GuestId == SelectedGuest.Id)!;

                // setting new date parameter for related reservation
                reservation_.CheckOutDate = DateTime.ParseExact(reservation_.CheckInDate!, "dd.MM.yyyy", null)
                        .AddDays(double.Parse(NewGuestReservationDurationInDays)).ToString("dd.MM.yyyy");

                // setting new price parameter for related reservation
                reservation_.TotalPrice = CalculatePrice(int.Parse(NewGuestReservationDurationInDays),
                        RoomTypes!.FirstOrDefault(rtp => rtp.Id == SelectedRoom!.RoomTypeId)!.Price);

                // updating reservation
                _dataBase.Update<Reservation>(reservation_);
                Reservations.FirstOrDefault(res => res.GuestId == SelectedGuest.Id)!
                        .CheckOutDate = reservation_.CheckOutDate;

                GuestIsEditing = false;
                ReturnToPreviousPage();
            }
        }

        [RelayCommand]
        private void CancelGuestUpdating()
        {
            ConfirmDialog confirmDialog = new ConfirmDialog(description: "Cancel editing guest data? The entered information will not be saved.", windowOwner: Application.Current.MainWindow);

            if (GuestIsChanged())
            {
                if (confirmDialog.ShowDialog() == true)
                {
                    SetOldDataToSelectedGuest();

                    GuestIsEditing = false;
                    ReturnToPreviousPage();
                }
            }
            else
            {
                GuestIsEditing = false;
                ReturnToPreviousPage();
            }
        }
        #endregion

        // Room type commands
        #region ...

        [RelayCommand]
        private void ShowAddRoomTypeDialog()
        {
            newRoomTypeDialog = new CreateNewRoomTypeDialog(this, Application.Current.MainWindow);
            newRoomTypeDialog.ShowDialog();
        }

        [RelayCommand]
        private void OpenRoomTypeEditPage(RoomType? roomType)
        {
            if (roomType != null)
            {
                SelectedRoomTypeItem = roomType;

                SelectedRoomTypeOldData = new RoomType()
                {
                    Id = roomType.Id,
                    TypeName = roomType.TypeName,
                    Capacity = roomType.Capacity,
                    Price = roomType.Price,
                    Rooms = roomType.Rooms
                };

                RoomTypeEditingPanelVisibility = Visibility.Visible;
            }
        }

        private void AddNewRoomType()
        {
            if (RoomTypes != null && !string.IsNullOrEmpty(NewRoomTypeName)
                && !string.IsNullOrEmpty(NewRoomTypeCapacity) && !string.IsNullOrEmpty(NewRoomTypePrice))
            {
                var roomType = new RoomType
                {
                    TypeName = NewRoomTypeName,
                    Capacity = int.Parse(NewRoomTypeCapacity),
                    Price = double.Parse(NewRoomTypePrice)
                };

                _dataBase.Add<RoomType>(roomType);
                RoomTypes.Add(roomType);

                NewRoomTypeName = string.Empty;
                NewRoomTypeCapacity = string.Empty;
                NewRoomTypePrice = string.Empty;
            }
        }

        private bool CanAddNewRoomType()
        {
            return !string.IsNullOrEmpty(NewRoomTypeName)
                && int.TryParse(NewRoomTypeCapacity, out _) && double.TryParse(NewRoomTypePrice, out _);
        }

        [RelayCommand]
        private void RemoveRoomType(RoomType? roomType)
        {
            if (RoomTypes != null && roomType != null)
            {
                ConfirmDialog confirmDialog = new ConfirmDialog(description: $"Are you sure you want to delete the room type '{roomType.TypeName}'? " +
                    "All rooms associated with it will also be deleted.", windowOwner: Application.Current.MainWindow);

                if (confirmDialog.ShowDialog() == true)
                {
                    _dataBase.Remove<RoomType>(roomType);
                    RoomTypes.Remove(roomType);
                }
            }
        }

        [RelayCommand]
        private void SaveNewRoomTypeData()
        {
            _dataBase.Update<RoomType>(SelectedRoomTypeItem!);
            RoomTypeEditingPanelVisibility = Visibility.Collapsed;
        }

        [RelayCommand]
        private void CancelRoomTypeUpdating()
        {
            ConfirmDialog confirmDialog = new ConfirmDialog(description: "Cancel editing the room type? The entered information will not be saved.", windowOwner: Application.Current.MainWindow);

            if (confirmDialog.ShowDialog() == true)
            {
                SetOldDataToSelectedRoomType();

                RoomTypeEditingPanelVisibility = Visibility.Collapsed;
            }
        }
        #endregion

        #endregion

        // Other methods
        #region ...

        private void CheckWindowState()
        {
            var mainWindow = Application.Current.MainWindow;

            if (mainWindow.WindowState == WindowState.Maximized)
            {
                MaximizeButtonVisibility = Visibility.Collapsed;
                RestoreButtonVisibility = Visibility.Visible;
                MainBorderThickness = new Thickness(7);
            }
            else
            {
                MaximizeButtonVisibility = Visibility.Visible;
                RestoreButtonVisibility = Visibility.Collapsed;
                MainBorderThickness = new Thickness(0);
            }
        }

        // For editing room page and all guests list page
        private void ReturnToPreviousPage()
        {
            if (GuestEditingStatus == GuestEditingStates.FromGuestList)
                CurrentPage = this.guestListPage;
            
            else if (GuestEditingStatus == GuestEditingStates.FromRoomEditInterface)
                CurrentPage = this.roomPage;
        }

        private bool GetCancelAccept()
        {
            if ((HotelIsEditing && SelectedHotel != null) || (FloorIsEditing && SelectedFloor != null) ||
                (RoomIsEditing && SelectedRoom != null) || (GuestIsEditing && SelectedGuest != null))
            {
                ConfirmDialog confirmDialog = new ConfirmDialog(description: "Some items are currently under editing, cancel editing and go? The entered information will not be saved.", windowOwner: Application.Current.MainWindow);

                if (confirmDialog.ShowDialog() == true)
                {
                    return true;
                }
                else { return false; }
            }
            return true;
        }

        private void SetOldDataToItems()
        {
            if (HotelIsEditing && SelectedHotel != null)
            {
                SetOldDataToSelectedHotel();
                HotelIsEditing = false;
            }
            if (FloorIsEditing && SelectedFloor != null)
            {
                SetOldDataToSelectedFloor();
                FloorIsEditing = false;
            }
            if (RoomIsEditing && SelectedRoom != null)
            {
                SetOldDataToSelectedRoom();
                RoomIsEditing = false;
            }
            if (GuestIsEditing && SelectedGuest != null)
            {
                SetOldDataToSelectedGuest();
                GuestIsEditing = false;
            }
        }

        // changing status for all "editing" properties
        private void ChangeEditingStatus(bool status)
        {
            HotelIsEditing = status;
            FloorIsEditing = status;
            RoomIsEditing = status;
            GuestIsEditing = status;
        }

        private void SetDefaultProperties()
        {
            NewHotelStarCount = 5;
            RoomTypeEditingPanelVisibility = Visibility.Collapsed;

            if (RoomTypes != null && RoomTypes.Count > 0)
            {
                NewRoomSelectedRoomType = RoomTypes[0];
            }
        }

        private void UpdateSelectedFloorGuestCount()
        {
            if (SelectedFloor != null)
            {
                TotalGuestsForSelectedFloor = SelectedFloor.Rooms.Sum(room => room.Guests.Count);
            }
        }

        private double CalculatePrice(int daysCount, double pricePerDay)
        {
            return daysCount * pricePerDay;
        }

        private int CalculateDurationInDays(Guest guest)
        {
            var guestReservation = guest.Reservation;
            if (guestReservation != null)
            {
                var checkIn = DateTime.ParseExact(guestReservation.CheckInDate!, "dd.MM.yyyy", null);
                var checkOut = DateTime.ParseExact(guestReservation.CheckOutDate!, "dd.MM.yyyy", null);

                return (checkOut - checkIn).Days;
            }
            return 0;
        }

        // Methods for setting old data to the appropriate properties  
        #region ...

        private bool HotelIsChanged()
        {
            if(SelectedHotel != null && SelectedHotelOldData != null)
            {
                if (SelectedHotel.Name != SelectedHotelOldData.Name ||
                    SelectedHotel.Address != SelectedHotelOldData.Address ||
                        SelectedHotel.Stars != SelectedHotelOldData.Stars)
                    return true;
            }
            return false;
        }

        private bool FloorIsChanged()
        {
            if (SelectedFloor != null && SelectedFloorOldData != null)
            {
                if (SelectedFloor.Number != SelectedFloorOldData.Number)
                    return true;
            }
            return false;
        }

        private bool RoomIsChanged()
        {
            if (SelectedRoom != null && SelectedRoomOldData != null)
            {
                if (SelectedRoom.Number != SelectedRoomOldData.Number)
                    return true;
            }
            return false;
        }

        private bool GuestIsChanged()
        {
            if (SelectedGuest != null && SelectedGuestOldData != null)
            {
                var date1 = SelectedGuest.Reservation.CheckInDate;
                var date2 = SelectedGuestOldData.Reservation.CheckInDate;

                if (SelectedGuest.FirstName != SelectedGuestOldData.FirstName ||
                        SelectedGuest.LastName != SelectedGuestOldData.LastName ||
                            SelectedGuest.Age != SelectedGuestOldData.Age ||
                                CalculateDurationInDays(SelectedGuest) != CalculateDurationInDays(SelectedGuestOldData))
                    return true;
            }
            return false;
        }

        private void SetOldDataToSelectedHotel()
        {
            if(SelectedHotel != null && SelectedHotelOldData != null)
            {
                SelectedHotel.Id = SelectedHotelOldData.Id;
                SelectedHotel.Name = SelectedHotelOldData.Name;
                SelectedHotel.Address = SelectedHotelOldData.Address;
                SelectedHotel.Stars = SelectedHotelOldData.Stars;
                SelectedHotel.Floors = SelectedHotelOldData.Floors;
            }
        }

        private void SetOldDataToSelectedFloor()
        {
            if(SelectedFloor != null && SelectedFloorOldData != null)
            {
                SelectedFloor.Id = SelectedFloorOldData.Id;
                SelectedFloor.Number = SelectedFloorOldData.Number;
                SelectedFloor.HotelId = SelectedFloorOldData.HotelId;
                SelectedFloor.Hotel = SelectedFloorOldData.Hotel;
                SelectedFloor.Rooms = SelectedFloorOldData.Rooms;
                SelectedFloor.TotalRooms = SelectedFloorOldData.TotalRooms;
            }
        }

        private void SetOldDataToSelectedRoom()
        {
            if(SelectedRoom != null && SelectedRoomOldData != null)
            {
                SelectedRoom.Id = SelectedRoomOldData.Id;
                SelectedRoom.Number = SelectedRoomOldData.Number;
                SelectedRoom.Floor = SelectedRoomOldData.Floor;
                SelectedRoom.FloorId = SelectedRoomOldData.FloorId;
                SelectedRoom.Guests = SelectedRoomOldData.Guests;
                SelectedRoom.TotalGuests = SelectedRoomOldData.TotalGuests;
                SelectedRoom.Reservations = SelectedRoomOldData.Reservations;
                SelectedRoom.RoomType = SelectedRoomOldData.RoomType;
                SelectedRoom.RoomTypeId = SelectedRoomOldData.RoomTypeId;
            }
        }

        private void SetOldDataToSelectedGuest()
        {
            if(SelectedGuest != null &&  SelectedGuestOldData != null)
            {
                SelectedGuest.Id = SelectedGuestOldData.Id;
                SelectedGuest.FirstName = SelectedGuestOldData.FirstName;
                SelectedGuest.LastName = SelectedGuestOldData.LastName;
                SelectedGuest.Age = SelectedGuestOldData.Age;
                SelectedGuest.Reservation = SelectedGuestOldData.Reservation;
                SelectedGuest.Room = SelectedGuestOldData.Room;
                SelectedGuest.RoomId = SelectedGuestOldData.RoomId;
            }
        }

        private void SetOldDataToSelectedRoomType()
        {
            if(SelectedRoomTypeItem != null && SelectedRoomTypeOldData != null)
            {
                SelectedRoomTypeItem.Id = SelectedRoomTypeOldData.Id;
                SelectedRoomTypeItem.TypeName = SelectedRoomTypeOldData.TypeName;
                SelectedRoomTypeItem.Capacity = SelectedRoomTypeOldData.Capacity;
                SelectedRoomTypeItem.Price = SelectedRoomTypeOldData.Price;
                SelectedRoomTypeItem.Rooms = SelectedRoomTypeOldData.Rooms;
            }
        }
        #endregion

        private void UpdateReservationList()
        {
            if(Reservations!.Count > _dataBase.GetAll<Reservation>().Count())
            {
                Reservations = new ObservableCollection<Reservation>(_dataBase.GetAll<Reservation>());
            }
        }

        private void LoadDataFromDataBase()
        {
            var hotels = _context.Hotels
                    .Include(h => h.Floors)
                        .ThenInclude(f => f.Rooms)
                            .ThenInclude(r => r.Reservations)
                    .Include(h => h.Floors)
                        .ThenInclude(f => f.Rooms)
                            .ThenInclude(r => r.Guests)
                    .Include(h => h.Floors)
                        .ThenInclude(f => f.Rooms)
                            .ThenInclude(r => r.RoomType)
                    .ToList();

            Hotels = new ObservableCollection<Hotel>(hotels);

            var guests = _context.Guests
                .Include(g => g.Room)
                    .ThenInclude(r => r.RoomType);

            Guests = new ObservableCollection<Guest>(guests);

            var reservations = _context.Reservations
                .Include(reser => reser.Guest)
                    .ThenInclude(g => g.Room)
                        .ThenInclude(r => r.Floor)
                            .ThenInclude(f => f.Hotel);

            Reservations = new ObservableCollection<Reservation>(reservations);

            var roomTypes = _context.RoomTypes
                .Include(rmt => rmt.Rooms)
                    .ThenInclude(r => r.Guests);

            RoomTypes = new ObservableCollection<RoomType>(roomTypes);
        }
        #endregion
    }
}
