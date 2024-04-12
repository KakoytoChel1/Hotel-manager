using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Hotels_Manager;

public partial class Hotel : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string _name = null!;
    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(nameof(Name)); }
    }

    private string _address = null!;
    public string Address
    {
        get { return _address; }
        set { _address = value; OnPropertyChanged(nameof(Address)); }
    }

    private int? _stars;
    public int? Stars
    {
        get { return _stars; }
        set { _stars = value; OnPropertyChanged(nameof(Stars)); }
    }
    public virtual ObservableCollection<Floor> Floors { get; set; } = new ObservableCollection<Floor>();

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
