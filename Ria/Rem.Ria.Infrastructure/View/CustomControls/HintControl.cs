﻿#region License

// Open Behavioral Health Information Technology Architecture (OBHITA.org)
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the <organization> nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
// DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System.Windows;
using System.Windows.Controls;

namespace Rem.Ria.Infrastructure.View.CustomControls
{
    /// <summary>
    /// HintControl class.
    /// </summary>
    public class HintControl : Button
    {
        #region Constants and Fields

        /// <summary>
        /// Dependency Property for TextProperty Property.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register (
                "Text",
                typeof( string ),
                typeof( HintControl ),
                new PropertyMetadata ( null ) );

        private static readonly HintPopup HintPopup = new HintPopup ();
        private static readonly object HintSync = new object ();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HintControl"/> class.
        /// </summary>
        public HintControl ()
        {
            DefaultStyleKey = typeof( HintControl );
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text of the hint.</value>
        public string Text
        {
            get { return ( string )GetValue ( TextProperty ); }
            set { SetValue ( TextProperty, value ); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Controls.Primitives.ButtonBase.Click"/> event.
        /// </summary>
        protected override void OnClick ()
        {
            base.OnClick ();
            lock ( HintSync )
            {
                if ( HintPopup != null && HintPopup.IsOpen )
                {
                    HintPopup.Close ();
                }
                HintPopup.Text = Text;
                HintPopup.IsTabStop = false;
                HintPopup.Show ();
            }
        }

        #endregion
    }
}
