using System.ComponentModel;

namespace Hotels_Manager;

public partial class Guest : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string _firstName = null!;
    public string FirstName 
    {
        get { return _firstName; }
        set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
    }

    private string _lastName = null!;
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
    }

    private int _age;
    public int Age
    {
        get { return _age; }
        set { _age = value; OnPropertyChanged(nameof(Age)); }
    }

    private int _roomId;
    public int RoomId
    {
        get { return _roomId; }
        set { _roomId = value; OnPropertyChanged(nameof(RoomId)); }
    }

    public virtual Reservation Reservation { get; set; } = new();

    public virtual Room Room { get; set; } = null!;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
