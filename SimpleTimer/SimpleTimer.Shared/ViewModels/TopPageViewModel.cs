#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2014.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace SimpleTimer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// トップ画面の ViewModel
    /// </summary>
    public partial class TopPageViewModel : ViewModelBase, ITopPageViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TopPageViewModel()
        {
            this.isTimerPaused = false;
            this.isTimerStated = false;
            this.isEnableStart = true;
            this.isEnablePause = false;
            this.isEnableStop = false;
            this.maxSeconds = 3 * 60 * 60;
            this.TimerValue = 5 * 60;
        }

        /// <summary>
        /// タイマー開始フラグ の変更後の処理
        /// </summary>
        partial void OnIsTimerStatedChanged()
        {
            this.IsEnableStart = !this.isTimerStated || this.isTimerPaused;
            this.IsEnablePause = this.isTimerStated && !this.isTimerPaused;
            this.IsEnableStop = this.isTimerStated;
        }

        /// <summary>
        /// タイマー一時停止フラグ の変更後の処理
        /// </summary>
        partial void OnIsTimerPausedChanged()
        {
            this.IsEnableStart = !this.isTimerStated || this.isTimerPaused;
            this.IsEnablePause = this.isTimerStated && !this.isTimerPaused;
        }
    }
}
