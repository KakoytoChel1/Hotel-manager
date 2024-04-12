using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Hotels_Manager;

public partial class RoomType : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string _typeName = null!;
    public string TypeName
    {
        get { return _typeName; }
        set { _typeName = value; OnPropertyChanged(nameof(TypeName)); }
    }

    private int _capacity;
    public int Capacity
    {
        get { return _capacity; }
        set { _capacity = value; OnPropertyChanged(nameof(Capacity)); }
    }

    private double _price;
    public double Price
    {
        get { return _price; }
        set { _price = value; OnPropertyChanged(nameof(Price)); }
    }

    public virtual ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
