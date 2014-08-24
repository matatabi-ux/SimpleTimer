#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2014.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace SimpleTimer.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SimpleTimer.Presenters;
    using SimpleTimer.ViewModels;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Presenter つき View のインタフェース
    /// </summary>
    /// <typeparam name="TPresenter">Presenter の型</typeparam>
    public interface IPresenterView
    {
        /// <summary>
        /// 再開時の処理
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        void OnResuming(object sender, object e);
    }

    /// <summary>
    /// Presenter つき View のインタフェース
    /// </summary>
    /// <typeparam name="TPresenter">Presenter の型</typeparam>
    public interface IPresenterView<TPresenter> : IPresenterView where TPresenter : IPresenterBase
    {
        /// <summary>
        /// Presenter
        /// </summary>
        TPresenter Presenter { get; }
    }
}
