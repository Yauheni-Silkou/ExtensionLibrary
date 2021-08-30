using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using static WpfExtensions.CanvasEx;

namespace WpfExtensions
{
    public abstract class TransparentWindow : Window
    {
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;
            WindowsServices.SetWindowExTransparent(hwnd);
        }
        public TransparentWindow() : base()
        {
            AllowsTransparency = true;
        }
    }
}
