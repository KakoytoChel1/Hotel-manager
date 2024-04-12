using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Hotels_Manager;

public partial class Floor : INotifyPropertyChanged
{
    public int Id { get; set; }

    private int _number;
    public int Number
    {
        get {return _number; } 
        set { _number = value; OnPropertyChanged(nameof(Number)); }
    }

    private int _totalRooms;
    public int TotalRooms
    {
        get { return _totalRooms; }
        set { _totalRooms = value; OnPropertyChanged(nameof(TotalRooms)); }
    }

    private int _totalGuests;
    public int TotalGuests
    {
        get { return _totalGuests; }
        set { _totalGuests = value; OnPropertyChanged(nameof(TotalGuests)); }
    }

    private int _hotelId;
    public int HotelId
    {
        get { return _hotelId; } 
        set { _hotelId = value; OnPropertyChanged(nameof(HotelId)); }
    }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
