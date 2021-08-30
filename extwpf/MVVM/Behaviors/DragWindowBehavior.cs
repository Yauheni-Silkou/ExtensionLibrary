﻿using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfExtensions.Mvvm.Behaviors
{
    public class DragWindowBehavior : Behavior<FrameworkElement>
    {
        public Window TargetWindow
        {
            get { return (Window)GetValue(TargetWindowProperty); }
            set { SetValue(TargetWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetWindowProperty =
            DependencyProperty.Register("TargetWindow", typeof(Window), typeof(DragWindowBehavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseDown += OnMouseDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseDown -= OnMouseDown;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                TargetWindow.DragMove();
            }
        }
    }
}
