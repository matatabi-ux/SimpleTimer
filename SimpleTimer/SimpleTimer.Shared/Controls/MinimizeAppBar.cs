#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2014.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace SimpleTimer.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// 最小化状態を模したアプリバー
    /// </summary>
    public sealed class MinimizeAppBar : Button
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MinimizeAppBar()
        {
            this.DefaultStyleKey = typeof(MinimizeAppBar);
            this.Loaded += this.OnLoaded;
            this.Unloaded += this.OnUnloaded;
        }

        #region 初期化・破棄処理

        /// <summary>
        /// Load 完了時の処理
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= this.OnLoaded;
            this.Click += this.OnClick;
        }

        /// <summary>
        /// Unload 完了時の処理
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= this.OnUnloaded;
            this.Loaded -= this.OnLoaded;
            this.Click -= this.OnClick;
        }

        #endregion //初期化・破棄処理

        /// <summary>
        /// クリック時の処理
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        private void OnClick(object sender, RoutedEventArgs e)
        {
            var rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null && rootFrame.Content is Page && ((Page)rootFrame.Content).BottomAppBar != null)
            {
                // AppBar を表示する
                ((Page)rootFrame.Content).BottomAppBar.IsOpen = true;
            }
        }
    }
}
