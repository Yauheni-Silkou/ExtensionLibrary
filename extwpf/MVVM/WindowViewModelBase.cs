using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace WpfExtensions.Mvvm
{
    public abstract class WindowViewModelBase : ViewModelBase
    {
        private double _progressValue;
        private string _progressText;
        private double _width;
        private double _height;
        private ImageSource _icon;
        private string _title;
        private WindowState _windowState;

        private ViewModelBase _presenterViewModel;

        private RelayCommand _minimizeWindowCommand;
        private RelayCommand _maximizeWindowCommand;
        private RelayCommand _closeWindowCommand;

        public double ProgressValue
        {
            get { return _progressValue; }
            set
            {
                if (_progressValue != value)
                {
                    _progressValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ProgressText
        {
            get { return _progressText; }
            set
            {
                if (_progressText != value)
                {
                    _progressText = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged();
                }
            }
        }

        public virtual ImageSource Icon
        {
            get { return _icon; }
            set
            {
                if (_icon != value)
                {
                    _icon = value;
                    OnPropertyChanged();
                }
            }
        }

        public virtual string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public WindowState WindowState
        {
            get { return _windowState; }
            set
            {
                if (_windowState != value)
                {
                    _windowState = value;
                    OnPropertyChanged();
                }
            }
        }

        public ViewModelBase PresenterViewModel
        {
            get { return _presenterViewModel; }
            set
            {
                if (_presenterViewModel != value)
                {
                    _presenterViewModel = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return _minimizeWindowCommand ??
                    (_minimizeWindowCommand = new RelayCommand(parameter =>
                    {
                        (parameter as Window).WindowState = WindowState.Minimized;
                    },
                    (parameter) => parameter != null && parameter is Window));
            }
        }
        
        public RelayCommand MaximizeWindowCommand
        {
            get
            {
                return _maximizeWindowCommand ??
                    (_maximizeWindowCommand = new RelayCommand(parameter =>
                    {
                        var window = parameter as Window;
                        window.WindowState = window.WindowState == WindowState.Normal
                        ? WindowState.Maximized
                        : WindowState.Normal;
                    },
                    (parameter) => parameter != null && parameter is Window));
            }
        }
        
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _closeWindowCommand ??
                    (_closeWindowCommand = new RelayCommand(parameter =>
                    {
                        (parameter as Window).Close();
                    },
                    (parameter) => parameter != null && parameter is Window));
            }
        }
    }
}
