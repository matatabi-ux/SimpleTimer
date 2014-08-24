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
    using Microsoft.Practices.Prism.StoreApps.Interfaces;
    using SimpleTimer.Views;
    using SimpleTimer.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.WebUI;

    /// <summary>
    /// Presenter 基底クラスインタフェース
    /// </summary>
    public interface IPresenterBase : INavigationAware
    {
        /// <summary>
        /// View
        /// </summary>
        FrameworkElement PresenterView { get; set; }

        /// <summary>
        /// ViewModel
        /// </summary>
        ViewModelBase PresenterViewModel { get; set; }

        /// <summary>
        /// 戻り遷移可否
        /// </summary>
        bool CanGoBack { get; }

        /// <summary>
        /// 戻るボタンクリックイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        void OnBackButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e);

        /// <summary>
        /// 破棄可能にする
        /// </summary>
        void Discard();
    }

    /// <summary>
    /// Presenter 基底クラス
    /// </summary>
    public abstract class PresenterBase : IPresenterBase
    {
        /// <summary>
        /// View
        /// </summary>
        public FrameworkElement PresenterView { get; set; }

        /// <summary>
        /// ViewModel
        /// </summary>
        public ViewModelBase PresenterViewModel { get; set; }

        /// <summary>
        /// 画面に遷移したときの処理
        /// </summary>
        /// <param name="navigationParameter">遷移パラメータ</param>
        /// <param name="navigationMode">遷移モード</param>
        /// <param name="viewModelState">画面状態データ</param>
        public virtual void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            if (viewModelState == null || this.PresenterViewModel == null)
            {
                return;
            }
            this.PresenterViewModel.Restore(viewModelState);
        }

        /// <summary>
        /// 画面から遷移するときの処理
        /// </summary>
        /// <param name="viewModelState">画面状態データ</param>
        /// <param name="suspending">中断フラグ</param>
        public virtual void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending)
        {
            if (suspending)
            {
                var view = this.PresenterView as IPresenterView;
                if (view != null)
                {
                    Application.Current.Resuming += view.OnResuming;
                }
            }
            if (viewModelState == null || this.PresenterViewModel == null)
            {
                return;
            }
            this.PresenterViewModel.FillState(viewModelState);
            this.Discard();
        }

        /// <summary>
        /// 戻り遷移可否
        /// </summary>
        public virtual bool CanGoBack
        {
            get { return App.NavigationService.CanGoBack(); }
        }

        /// <summary>
        /// 戻るボタンクリックイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        public virtual void OnBackButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            App.NavigationService.GoBack();
        }

        /// <summary>
        /// 破棄可能にする
        /// </summary>
        public virtual void Discard()
        {
            this.PresenterView = null;
            this.PresenterViewModel = null;
        }
    }
}
