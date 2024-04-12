using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Hotels_Manager;

public partial class Room : INotifyPropertyChanged
{
    public int Id { get; set; }

    private int _number;
    public int Number
    {
        get { return _number; }
        set { _number = value; OnPropertyChanged(nameof(Number)); }
    }

    private int _totalGuests;
    public int TotalGuests
    {
        get { return _totalGuests; }
        set { _totalGuests = value; OnPropertyChanged(nameof(TotalGuests)); }
    }

    private int _roomTypeId;
    public int RoomTypeId
    {
        get { return _roomTypeId; }
        set { _roomTypeId = value; OnPropertyChanged(nameof(RoomTypeId)); }
    }

    private int _floorId;
    public int FloorId
    {
        get { return _floorId; }
        set { _floorId = value; OnPropertyChanged(nameof(FloorId)); }
    }

    private RoomType _roomType = null!;
    public virtual RoomType RoomType
    {
        get { return _roomType; }
        set { _roomType = value; OnPropertyChanged(nameof(RoomType));}
    }

    public virtual Floor Floor { get; set; } = null!;

    public virtual ObservableCollection<Guest> Guests { get; set; } = new ObservableCollection<Guest>();

    public virtual ObservableCollection<Reservation> Reservations { get; set; } = new ObservableCollection<Reservation>();

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
