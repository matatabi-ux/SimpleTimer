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
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Microsoft.Practices.Prism.StoreApps;
    using SimpleTimer.Common;
    using SimpleTimer.Controls;
    using SimpleTimer.Presenters;
    using SimpleTimer.ViewModels;
    using SimpleTimer.Views;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// トップ画面
    /// </summary>
    [PresenterView(typeof(TopPagePresenter))]
    public sealed partial class TopPage : VisualStateAwarePage, IPresenterView<TopPagePresenter>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TopPage()
        {
            this.InitializeComponent();
        }

        #region IPresenterView<TPresenter>

        /// <summary>
        /// この画面の Presenter
        /// </summary>
        public TopPagePresenter Presenter
        {
            get { return this.GetPresenter<TopPagePresenter>(); }
        }

        /// <summary>
        /// 再開時の処理
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        public void OnResuming(object sender, object e)
        {
            Application.Current.Resuming -= this.OnResuming;
            this.Presenter.View = this;
            this.Presenter.ViewModel = this.DataContext as TopPageViewModel;
            this.Presenter.Resume();
        }

        #endregion //IPresenterView<TPresenter>
    }
}
