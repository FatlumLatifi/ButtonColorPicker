using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Color = System.Windows.Media.Color;


namespace WPFColorPicker
{
    public class ButtonColorPicker : System.Windows.Controls.Button
    {

        /// <summary>
        /// Gets or sets the currently selected color. Changing this property updates the background color and raises the
        /// ColorChanged event.
        /// </summary>
        /// <remarks>The SelectedColor property allows users to specify a color that will be reflected in the
        /// background. When the color is changed, the ColorChanged event is triggered, allowing subscribers to respond to
        /// the change.</remarks>
        public Color SelectedColor
        {
            get
            {
                return field;
            }
            set
            {
                Background = new SolidColorBrush(value);
                OnColorSelection?.Invoke(this, value);
                field = value;
            }
        }

        protected override void OnClick()
        {
            OpenColorDialog();
            base.OnClick();
        }


        /// <summary>
        /// Occurs when the color value changes.
        /// </summary>
        /// <remarks>Subscribers can handle this event to respond to changes in the associated color. The
        /// event handler receives the new color as an argument.  </remarks>
        public event EventHandler<Color>? OnColorSelection;


        /// <summary>
        /// Displays a color selection dialog that allows the user to choose a color and updates the SelectedColor
        /// property with the selected value.
        /// </summary>
        /// <remarks>This method opens a modal color picker dialog. The dialog is blocking, so the user
        /// must close it before interacting with the rest of the application. After the dialog is closed, the
        /// SelectedColor property is set to the color chosen by the user.</remarks>
        public void OpenColorDialog()
        {
            ColorDialog cd = new();
            cd.AllowFullOpen = true;
            DialogResult dr = cd.ShowDialog();
            if (dr == DialogResult.OK || dr == DialogResult.Yes)
            {
               SelectedColor = Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B);
            }
        }
    }
}
