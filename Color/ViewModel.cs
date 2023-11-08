using Colorado;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<ColorItem> colors;
    public SolidColorBrush SelectedColor { get; private set; }
    private byte alpha;
    private byte red;
    private byte green;
    private byte blue;
    private bool isAlphaActive = true;
    private bool isRedActive = true;
    private bool isGreenActive = true;
    private bool isBlueActive = true;

    public ObservableCollection<ColorItem> Colors
    {
        get { return colors; }
        set
        {
            colors = value;
            OnPropertyChanged(nameof(Colors));
        }
    }


    public byte Alpha
    {
        get { return alpha; }
        set
        {
            alpha = value;
            OnPropertyChanged(nameof(Alpha));
            UpdateSelectedColor();
        }
    }
    public bool IsGreenActive
    {
        get { return isGreenActive; }
        set
        {
            isGreenActive = value;
            OnPropertyChanged(nameof(IsGreenActive));
        }
    }
    public byte Blue
    {
        get { return blue; }
        set
        {
            blue = value;
            OnPropertyChanged(nameof(Blue));
            UpdateSelectedColor();
        }
    }
    public byte Green
    {
        get { return green; }
        set
        {
            green = value;
            OnPropertyChanged(nameof(Green));
            UpdateSelectedColor();
        }
    }
    public bool IsRedActive
    {
        get { return isRedActive; }
        set
        {
            isRedActive = value;
            OnPropertyChanged(nameof(IsRedActive));
        }
    }
 
    public bool IsAlphaActive
    {
        get { return isAlphaActive; }
        set
        {
            isAlphaActive = value;
            OnPropertyChanged(nameof(IsAlphaActive));
        }
    }

    public byte Red
    {
        get { return red; }
        set
        {
            red = value;
            OnPropertyChanged(nameof(Red));
            UpdateSelectedColor();
        }
    }
 
    public bool IsBlueActive
    {
        get { return isBlueActive; }
        set
        {
            isBlueActive = value;
            OnPropertyChanged(nameof(IsBlueActive));
        }
    }
    private void UpdateSelectedColor()
    {
        SelectedColor = new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));
        OnPropertyChanged(nameof(SelectedColor));
    }
    public ICommand AddColorCommand { get; }
    public ICommand DeleteColorCommand { get; }

    public ViewModel()
    {
        colors = new ObservableCollection<ColorItem>();
        AddColorCommand = new RelayCommand((parameter) => AddColor(), (parameter) => CanAddColor());
        DeleteColorCommand = new RelayCommand((parameter) => DeleteColor(parameter), (parameter) => CanDeleteColor(parameter));
    }

    private void AddColor()
    {
        ColorItem color = new ColorItem(alpha, red, green, blue);
        colors.Add(color);
    }

    private bool CanAddColor()
    {
        return true;
    }

    private void DeleteColor(object parameter)
    {
        if (parameter is ColorItem colorToDelete)
        {
            colors.Remove(colorToDelete);
        }
    }

    private bool CanDeleteColor(object parameter)
    {
        return parameter is ColorItem;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
public class RelayCommand : ICommand
{
    private readonly Action<object> execute;
    private readonly Func<object, bool> canExecute;

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        this.execute = execute ?? throw new ArgumentNullException("execute");
        this.canExecute = canExecute;
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
        return canExecute == null || canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        execute(parameter);
    }
}