using System.ComponentModel;

namespace Hotels_Manager;

public partial class Reservation : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string? _checkInDate = null!;
    public string? CheckInDate
    {
        get { return _checkInDate; }
        set { _checkInDate = value; OnPropertyChanged(nameof(CheckInDate)); }
    }

    private string? _checkOutDate = null!;
    public string? CheckOutDate
    {
        get { return _checkOutDate; }
        set { _checkOutDate = value; OnPropertyChanged(nameof(CheckOutDate)); }
    }

    private double _totalPrice;
    public double TotalPrice
    {
        get { return _totalPrice; }
        set { _totalPrice = value; OnPropertyChanged(nameof(TotalPrice)); }
    }

    private int _guestId;
    public int GuestId 
    {
        get { return _guestId; }
        set { _guestId = value; OnPropertyChanged(nameof(GuestId)); }
    }

    private Guest _guest = null!;
    public virtual Guest Guest
    {
        get { return _guest; }
        set { _guest = value; OnPropertyChanged(nameof(Guest)); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
