#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2014.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using Windows.Storage;
using NotificationsExtensions.TileContent;

namespace SimpleTimer.Presenters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SimpleTimer.ViewModels;
    using SimpleTimer.Views;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.Xaml;
    using Windows.UI.WebUI;
    using Windows.UI.Notifications;

    /// <summary>
    /// トップ画面の Presenter
    /// </summary>
    public class TopPagePresenter : PresenterBase, IPresenter<TopPage, TopPageViewModel>
    {
        #region Privates

        /// <summary>
        /// タイマー
        /// </summary>
        private DispatcherTimer timer = new DispatcherTimer();

        #endregion //Privates

        #region IPresenter<View, ViewModel>

        /// <summary>
        /// View
        /// </summary>
        public TopPage View
        {
            get { return this.PresenterView as TopPage; }
            set { this.PresenterView = value; }
        }

        /// <summary>
        /// ViewModel
        /// </summary>
        public TopPageViewModel ViewModel
        {
            get { return this.PresenterViewModel as TopPageViewModel; }
            set { this.PresenterViewModel = value; }
        }

        #endregion //IPresenter<View, ViewModel>

        /// <summary>
        /// 画面に遷移したときの処理
        /// </summary>
        /// <param name="navigationParameter">遷移パラメータ</param>
        /// <param name="navigationMode">遷移モード</param>
        /// <param name="viewModelState">画面状態データ</param>
        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);

            if (navigationMode == NavigationMode.New)
            {
                this.ViewModel.MaxSeconds = App.AppSettings.Data.MaxSeconds;
                this.ViewModel.TimerValue = App.AppSettings.Data.TimerValue;
                this.timer.Interval = TimeSpan.FromSeconds(1);
                this.timer.Tick += this.OnTick;
                this.UpdateLiveTile();
            }
        }

        /// <summary>
        /// 画面から遷移するときの処理
        /// </summary>
        /// <param name="viewModelState">画面状態データ</param>
        /// <param name="suspending">中断フラグ</param>
        public override void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending)
        {
            if (suspending)
            {
                this.timer.Stop();

                // 中断時の経過時間を記憶
                ApplicationData.Current.LocalSettings.Values["SuspendTime"] = Environment.TickCount;
            }
            base.OnNavigatedFrom(viewModelState, suspending);
        }

        /// <summary>
        /// 再開時の処理
        /// </summary>
        public void Resume()
        {
            // タイマー稼働中だったの場合
            if (this.ViewModel.IsTimerStated && !this.ViewModel.IsTimerPaused)
            {
                // 中断から再開までに経過した時間分を減算
                var suspendSpan = Environment.TickCount - (int)ApplicationData.Current.LocalSettings.Values["SuspendTime"];
                this.ViewModel.TimerValue -= (int)Math.Floor((double)(suspendSpan / 1000d));
                this.UpdateLiveTile();

                if (this.ViewModel.TimerValue < 1)
                {
                    this.ViewModel.TimerValue = 0;
                    this.OnStopClick(this, null);
                }
                else
                {
                    this.timer.Start();
                }
            }
        }

        /// <summary>
        /// タイマーイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        private void OnTick(object sender, object e)
        {
            this.ViewModel.TimerValue--;
            this.UpdateLiveTile();

            if (this.ViewModel.TimerValue < 1)
            {
                this.OnStopClick(this, null);
            }
        }

        /// <summary>
        /// ライブタイルを更新する
        /// </summary>
        private void UpdateLiveTile()
        {
            var time = TimeSpan.FromSeconds(this.ViewModel.TimerValue).ToString(@"h\:mm\:ss");

            var updater = TileUpdateManager.CreateTileUpdaterForApplication();

            updater.EnableNotificationQueue(true);
            updater.Clear();

            // タイマー完了時は非表示
            if (!this.ViewModel.IsTimerStated || this.ViewModel.TimerValue < 1)
            {
                updater.EnableNotificationQueue(false);
                return;
            }

            var tile1 = NotificationsExtensions.TileContent.TileContentFactory.CreateTileSquare150x150Text01();
            tile1.Branding = TileBranding.Logo;
            tile1.TextHeading.Text = time;

            var tile2 = NotificationsExtensions.TileContent.TileContentFactory.CreateTileWide310x150Text01();
            tile2.Branding = TileBranding.Logo;
            tile2.TextHeading.Text = time;
            tile2.Square150x150Content = tile1;

#if WINDOWS_APP
            var tile3 = NotificationsExtensions.TileContent.TileContentFactory.CreateTileSquare310x310Text01();
            tile3.Branding = TileBranding.Logo;
            tile3.TextHeading.Text = time;
            tile3.Wide310x150Content = tile2;

            updater.Update(tile3.CreateNotification());
#endif

#if WINDOWS_PHONE_APP
            updater.Update(tile2.CreateNotification());
#endif
        }

        /// <summary>
        /// 開始ボタンクリックイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        public async void OnStartClick(object sender, RoutedEventArgs e)
        {
            if (this.ViewModel.MaxSeconds == App.AppSettings.Data.MaxSeconds)
            {
                App.AppSettings.Data.TimerValue = this.ViewModel.TimerValue;
                await App.AppSettings.SaveAsync();

                this.ViewModel.MaxSeconds = this.ViewModel.TimerValue;
            }

            this.ViewModel.IsTimerPaused = false;
            this.ViewModel.IsTimerStated = true;

            this.timer.Start();
        }

        /// <summary>
        /// 一時停止ボタンクリックイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        public void OnPauseClick(object sender, RoutedEventArgs e)
        {
            this.timer.Stop();

            this.ViewModel.IsTimerPaused = true;
        }

        /// <summary>
        /// 停止ボタンクリックイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        public void OnStopClick(object sender, RoutedEventArgs e)
        {
            this.timer.Stop();

            this.ViewModel.MaxSeconds = App.AppSettings.Data.MaxSeconds;
            this.ViewModel.TimerValue = App.AppSettings.Data.TimerValue;

            this.ViewModel.IsTimerPaused = false;
            this.ViewModel.IsTimerStated = false;

            this.UpdateLiveTile();
        }
    }
}