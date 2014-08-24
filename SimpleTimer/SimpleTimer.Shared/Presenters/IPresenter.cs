#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2014.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace SimpleTimer.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SimpleTimer.ViewModels;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Presenter インタフェース
    /// </summary>
    /// <typeparam name="TView">View の型</typeparam>
    /// <typeparam name="TViewModel">ViewModel の型</typeparam>
    public interface IPresenter<TView, TViewModel>
        where TView : Page
        where TViewModel : ViewModelBase
    {
        /// <summary>
        /// View
        /// </summary>
        TView View { get; set; }

        /// <summary>
        /// ViewModel
        /// </summary>
        TViewModel ViewModel { get; set; }
    }
}
