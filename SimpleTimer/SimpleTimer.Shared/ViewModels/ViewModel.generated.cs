﻿//<auto-generated>
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
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
	using Microsoft.Practices.Prism.Mvvm;

    /// <summary>
    /// グループコンテナ ViewModel のインタフェース
    /// </summary>
    public partial interface IGroupContainerViewModel
    {
        /// <summary>
        /// ヘッダ
        /// </summary>
        string Header { get; set; }

        /// <summary>
        /// コンテンツ ViewModel
        /// </summary>
        ViewModelBase Content { get; set; }

        /// <summary>
        /// アイテム情報 ViewModel
        /// </summary>
        ObservableCollection<ItemContainerViewModel> Items { get; set; }

        /// <summary>
        /// クリック可能フラグ
        /// </summary>
        bool IsClickable { get; set; }

        /// <summary>
        /// コンテンツ ID
        /// </summary>
        string ContentId { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        string UniqueId { get; set; }
    }

    /// <summary>
    /// グループコンテナ ViewModel
    /// </summary>
    public partial class GroupContainerViewModel : ViewModelBase, IGroupContainerViewModel
    {
        #region Header:ヘッダ プロパティ
        /// <summary>
        /// ヘッダ
        /// </summary>
        private string header; 

        /// <summary>
        /// ヘッダ の変更前の処理
        /// </summary>
        partial void OnHeaderChanging(ref string value);

        /// <summary>
        /// ヘッダ の変更後の処理
        /// </summary>
        partial void OnHeaderChanged();

        /// <summary>
        /// ヘッダ の取得および設定
        /// </summary>
        [RestorableState]
        public string Header
        {
            get
            {
                return this.header;
            }

            set
            {
                if (this.header != value)
                {
                    this.OnHeaderChanging(ref value);
                    this.SetProperty<string>(ref this.header, value);
                    this.OnHeaderChanged();
                }
            }
        }
        #endregion //Header:ヘッダ プロパティ

        #region Content:コンテンツ ViewModel プロパティ
        /// <summary>
        /// コンテンツ ViewModel
        /// </summary>
        private ViewModelBase content; 

        /// <summary>
        /// コンテンツ ViewModel の変更前の処理
        /// </summary>
        partial void OnContentChanging(ref ViewModelBase value);

        /// <summary>
        /// コンテンツ ViewModel の変更後の処理
        /// </summary>
        partial void OnContentChanged();

        /// <summary>
        /// コンテンツ ViewModel の取得および設定
        /// </summary>
        [RestorableState]
        public ViewModelBase Content
        {
            get
            {
                return this.content;
            }

            set
            {
                if (this.content != value)
                {
                    this.OnContentChanging(ref value);
                    this.SetProperty<ViewModelBase>(ref this.content, value);
                    this.OnContentChanged();
                }
            }
        }
        #endregion //Content:コンテンツ ViewModel プロパティ

        #region Items:アイテム情報 ViewModel プロパティ
        /// <summary>
        /// アイテム情報 ViewModel
        /// </summary>
        private ObservableCollection<ItemContainerViewModel> items = new ObservableCollection<ItemContainerViewModel>(); 

        /// <summary>
        /// アイテム情報 ViewModel の変更前の処理
        /// </summary>
        partial void OnItemsChanging(ref ObservableCollection<ItemContainerViewModel> value);

        /// <summary>
        /// アイテム情報 ViewModel の変更後の処理
        /// </summary>
        partial void OnItemsChanged();

        /// <summary>
        /// アイテム情報 ViewModel の取得および設定
        /// </summary>
        [RestorableState]
        public ObservableCollection<ItemContainerViewModel> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                if (this.items != value)
                {
                    this.OnItemsChanging(ref value);
                    this.SetProperty<ObservableCollection<ItemContainerViewModel>>(ref this.items, value);
                    this.OnItemsChanged();
                }
            }
        }
        #endregion //Items:アイテム情報 ViewModel プロパティ

        #region IsClickable:クリック可能フラグ プロパティ
        /// <summary>
        /// クリック可能フラグ
        /// </summary>
        private bool isClickable; 

        /// <summary>
        /// クリック可能フラグ の変更前の処理
        /// </summary>
        partial void OnIsClickableChanging(ref bool value);

        /// <summary>
        /// クリック可能フラグ の変更後の処理
        /// </summary>
        partial void OnIsClickableChanged();

        /// <summary>
        /// クリック可能フラグ の取得および設定
        /// </summary>
        [RestorableState]
        public bool IsClickable
        {
            get
            {
                return this.isClickable;
            }

            set
            {
                if (this.isClickable != value)
                {
                    this.OnIsClickableChanging(ref value);
                    this.SetProperty<bool>(ref this.isClickable, value);
                    this.OnIsClickableChanged();
                }
            }
        }
        #endregion //IsClickable:クリック可能フラグ プロパティ

        #region ContentId:コンテンツ ID プロパティ
        /// <summary>
        /// コンテンツ ID
        /// </summary>
        private string contentId; 

        /// <summary>
        /// コンテンツ ID の変更前の処理
        /// </summary>
        partial void OnContentIdChanging(ref string value);

        /// <summary>
        /// コンテンツ ID の変更後の処理
        /// </summary>
        partial void OnContentIdChanged();

        /// <summary>
        /// コンテンツ ID の取得および設定
        /// </summary>
        [RestorableState]
        public string ContentId
        {
            get
            {
                return this.contentId;
            }

            set
            {
                if (this.contentId != value)
                {
                    this.OnContentIdChanging(ref value);
                    this.SetProperty<string>(ref this.contentId, value);
                    this.OnContentIdChanged();
                }
            }
        }
        #endregion //ContentId:コンテンツ ID プロパティ

        #region UniqueId:ID プロパティ
        /// <summary>
        /// ID
        /// </summary>
        private string uniqueId; 

        /// <summary>
        /// ID の変更前の処理
        /// </summary>
        partial void OnUniqueIdChanging(ref string value);

        /// <summary>
        /// ID の変更後の処理
        /// </summary>
        partial void OnUniqueIdChanged();

        /// <summary>
        /// ID の取得および設定
        /// </summary>
        [RestorableState]
        public string UniqueId
        {
            get
            {
                return this.uniqueId;
            }

            set
            {
                if (this.uniqueId != value)
                {
                    this.OnUniqueIdChanging(ref value);
                    this.SetProperty<string>(ref this.uniqueId, value);
                    this.OnUniqueIdChanged();
                }
            }
        }
        #endregion //UniqueId:ID プロパティ
	}

    /// <summary>
    /// アイテムコンテナ ViewModel のインタフェース
    /// </summary>
    public partial interface IItemContainerViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        string UniqueId { get; set; }

        /// <summary>
        /// コンテンツ ViewModel
        /// </summary>
        ViewModelBase Content { get; set; }

        /// <summary>
        /// 横幅
        /// </summary>
        int ColumnSpan { get; set; }

        /// <summary>
        /// 縦幅
        /// </summary>
        int RowSpan { get; set; }

        /// <summary>
        /// クリック可能フラグ
        /// </summary>
        bool IsClickable { get; set; }

        /// <summary>
        /// 選択可能フラグ
        /// </summary>
        bool IsSelectable { get; set; }

        /// <summary>
        /// コンテンツ ID
        /// </summary>
        string ContentId { get; set; }
    }

    /// <summary>
    /// アイテムコンテナ ViewModel
    /// </summary>
    public partial class ItemContainerViewModel : ViewModelBase, IItemContainerViewModel
    {
        #region UniqueId:ID プロパティ
        /// <summary>
        /// ID
        /// </summary>
        private string uniqueId; 

        /// <summary>
        /// ID の変更前の処理
        /// </summary>
        partial void OnUniqueIdChanging(ref string value);

        /// <summary>
        /// ID の変更後の処理
        /// </summary>
        partial void OnUniqueIdChanged();

        /// <summary>
        /// ID の取得および設定
        /// </summary>
        [RestorableState]
        public string UniqueId
        {
            get
            {
                return this.uniqueId;
            }

            set
            {
                if (this.uniqueId != value)
                {
                    this.OnUniqueIdChanging(ref value);
                    this.SetProperty<string>(ref this.uniqueId, value);
                    this.OnUniqueIdChanged();
                }
            }
        }
        #endregion //UniqueId:ID プロパティ

        #region Content:コンテンツ ViewModel プロパティ
        /// <summary>
        /// コンテンツ ViewModel
        /// </summary>
        private ViewModelBase content; 

        /// <summary>
        /// コンテンツ ViewModel の変更前の処理
        /// </summary>
        partial void OnContentChanging(ref ViewModelBase value);

        /// <summary>
        /// コンテンツ ViewModel の変更後の処理
        /// </summary>
        partial void OnContentChanged();

        /// <summary>
        /// コンテンツ ViewModel の取得および設定
        /// </summary>
        [RestorableState]
        public ViewModelBase Content
        {
            get
            {
                return this.content;
            }

            set
            {
                if (this.content != value)
                {
                    this.OnContentChanging(ref value);
                    this.SetProperty<ViewModelBase>(ref this.content, value);
                    this.OnContentChanged();
                }
            }
        }
        #endregion //Content:コンテンツ ViewModel プロパティ

        #region ColumnSpan:横幅 プロパティ
        /// <summary>
        /// 横幅
        /// </summary>
        private int columnSpan; 

        /// <summary>
        /// 横幅 の変更前の処理
        /// </summary>
        partial void OnColumnSpanChanging(ref int value);

        /// <summary>
        /// 横幅 の変更後の処理
        /// </summary>
        partial void OnColumnSpanChanged();

        /// <summary>
        /// 横幅 の取得および設定
        /// </summary>
        [RestorableState]
        public int ColumnSpan
        {
            get
            {
                return this.columnSpan;
            }

            set
            {
                if (this.columnSpan != value)
                {
                    this.OnColumnSpanChanging(ref value);
                    this.SetProperty<int>(ref this.columnSpan, value);
                    this.OnColumnSpanChanged();
                }
            }
        }
        #endregion //ColumnSpan:横幅 プロパティ

        #region RowSpan:縦幅 プロパティ
        /// <summary>
        /// 縦幅
        /// </summary>
        private int rowSpan; 

        /// <summary>
        /// 縦幅 の変更前の処理
        /// </summary>
        partial void OnRowSpanChanging(ref int value);

        /// <summary>
        /// 縦幅 の変更後の処理
        /// </summary>
        partial void OnRowSpanChanged();

        /// <summary>
        /// 縦幅 の取得および設定
        /// </summary>
        [RestorableState]
        public int RowSpan
        {
            get
            {
                return this.rowSpan;
            }

            set
            {
                if (this.rowSpan != value)
                {
                    this.OnRowSpanChanging(ref value);
                    this.SetProperty<int>(ref this.rowSpan, value);
                    this.OnRowSpanChanged();
                }
            }
        }
        #endregion //RowSpan:縦幅 プロパティ

        #region IsClickable:クリック可能フラグ プロパティ
        /// <summary>
        /// クリック可能フラグ
        /// </summary>
        private bool isClickable; 

        /// <summary>
        /// クリック可能フラグ の変更前の処理
        /// </summary>
        partial void OnIsClickableChanging(ref bool value);

        /// <summary>
        /// クリック可能フラグ の変更後の処理
        /// </summary>
        partial void OnIsClickableChanged();

        /// <summary>
        /// クリック可能フラグ の取得および設定
        /// </summary>
        [RestorableState]
        public bool IsClickable
        {
            get
            {
                return this.isClickable;
            }

            set
            {
                if (this.isClickable != value)
                {
                    this.OnIsClickableChanging(ref value);
                    this.SetProperty<bool>(ref this.isClickable, value);
                    this.OnIsClickableChanged();
                }
            }
        }
        #endregion //IsClickable:クリック可能フラグ プロパティ

        #region IsSelectable:選択可能フラグ プロパティ
        /// <summary>
        /// 選択可能フラグ
        /// </summary>
        private bool isSelectable; 

        /// <summary>
        /// 選択可能フラグ の変更前の処理
        /// </summary>
        partial void OnIsSelectableChanging(ref bool value);

        /// <summary>
        /// 選択可能フラグ の変更後の処理
        /// </summary>
        partial void OnIsSelectableChanged();

        /// <summary>
        /// 選択可能フラグ の取得および設定
        /// </summary>
        [RestorableState]
        public bool IsSelectable
        {
            get
            {
                return this.isSelectable;
            }

            set
            {
                if (this.isSelectable != value)
                {
                    this.OnIsSelectableChanging(ref value);
                    this.SetProperty<bool>(ref this.isSelectable, value);
                    this.OnIsSelectableChanged();
                }
            }
        }
        #endregion //IsSelectable:選択可能フラグ プロパティ

        #region ContentId:コンテンツ ID プロパティ
        /// <summary>
        /// コンテンツ ID
        /// </summary>
        private string contentId; 

        /// <summary>
        /// コンテンツ ID の変更前の処理
        /// </summary>
        partial void OnContentIdChanging(ref string value);

        /// <summary>
        /// コンテンツ ID の変更後の処理
        /// </summary>
        partial void OnContentIdChanged();

        /// <summary>
        /// コンテンツ ID の取得および設定
        /// </summary>
        [RestorableState]
        public string ContentId
        {
            get
            {
                return this.contentId;
            }

            set
            {
                if (this.contentId != value)
                {
                    this.OnContentIdChanging(ref value);
                    this.SetProperty<string>(ref this.contentId, value);
                    this.OnContentIdChanged();
                }
            }
        }
        #endregion //ContentId:コンテンツ ID プロパティ
	}

    /// <summary>
    /// トップ画面の ViewModel のインタフェース
    /// </summary>
    public partial interface ITopPageViewModel
    {
        /// <summary>
        /// タイマー設定秒数
        /// </summary>
        int MaxSeconds { get; set; }

        /// <summary>
        /// タイマー一時停止フラグ
        /// </summary>
        bool IsTimerPaused { get; set; }

        /// <summary>
        /// タイマー停止可能フラグ
        /// </summary>
        bool IsEnableStop { get; set; }

        /// <summary>
        /// タイマー開始フラグ
        /// </summary>
        bool IsTimerStated { get; set; }

        /// <summary>
        /// タイマー残り秒数
        /// </summary>
        int TimerValue { get; set; }

        /// <summary>
        /// タイマー開始可能フラグ
        /// </summary>
        bool IsEnableStart { get; set; }

        /// <summary>
        /// タイマー一時停止可能フラグ
        /// </summary>
        bool IsEnablePause { get; set; }
    }

    /// <summary>
    /// トップ画面の ViewModel
    /// </summary>
    public partial class TopPageViewModel : ViewModelBase, ITopPageViewModel
    {
        #region MaxSeconds:タイマー設定秒数 プロパティ
        /// <summary>
        /// タイマー設定秒数
        /// </summary>
        private int maxSeconds; 

        /// <summary>
        /// タイマー設定秒数 の変更前の処理
        /// </summary>
        partial void OnMaxSecondsChanging(ref int value);

        /// <summary>
        /// タイマー設定秒数 の変更後の処理
        /// </summary>
        partial void OnMaxSecondsChanged();

        /// <summary>
        /// タイマー設定秒数 の取得および設定
        /// </summary>
        [RestorableState]
        public int MaxSeconds
        {
            get
            {
                return this.maxSeconds;
            }

            set
            {
                if (this.maxSeconds != value)
                {
                    this.OnMaxSecondsChanging(ref value);
                    this.SetProperty<int>(ref this.maxSeconds, value);
                    this.OnMaxSecondsChanged();
                }
            }
        }
        #endregion //MaxSeconds:タイマー設定秒数 プロパティ

        #region IsTimerPaused:タイマー一時停止フラグ プロパティ
        /// <summary>
        /// タイマー一時停止フラグ
        /// </summary>
        private bool isTimerPaused; 

        /// <summary>
        /// タイマー一時停止フラグ の変更前の処理
        /// </summary>
        partial void OnIsTimerPausedChanging(ref bool value);

        /// <summary>
        /// タイマー一時停止フラグ の変更後の処理
        /// </summary>
        partial void OnIsTimerPausedChanged();

        /// <summary>
        /// タイマー一時停止フラグ の取得および設定
        /// </summary>
        [RestorableState]
        public bool IsTimerPaused
        {
            get
            {
                return this.isTimerPaused;
            }

            set
            {
                if (this.isTimerPaused != value)
                {
                    this.OnIsTimerPausedChanging(ref value);
                    this.SetProperty<bool>(ref this.isTimerPaused, value);
                    this.OnIsTimerPausedChanged();
                }
            }
        }
        #endregion //IsTimerPaused:タイマー一時停止フラグ プロパティ

        #region IsEnableStop:タイマー停止可能フラグ プロパティ
        /// <summary>
        /// タイマー停止可能フラグ
        /// </summary>
        private bool isEnableStop; 

        /// <summary>
        /// タイマー停止可能フラグ の変更前の処理
        /// </summary>
        partial void OnIsEnableStopChanging(ref bool value);

        /// <summary>
        /// タイマー停止可能フラグ の変更後の処理
        /// </summary>
        partial void OnIsEnableStopChanged();

        /// <summary>
        /// タイマー停止可能フラグ の取得および設定
        /// </summary>
        [RestorableState]
        public bool IsEnableStop
        {
            get
            {
                return this.isEnableStop;
            }

            set
            {
                if (this.isEnableStop != value)
                {
                    this.OnIsEnableStopChanging(ref value);
                    this.SetProperty<bool>(ref this.isEnableStop, value);
                    this.OnIsEnableStopChanged();
                }
            }
        }
        #endregion //IsEnableStop:タイマー停止可能フラグ プロパティ

        #region IsTimerStated:タイマー開始フラグ プロパティ
        /// <summary>
        /// タイマー開始フラグ
        /// </summary>
        private bool isTimerStated; 

        /// <summary>
        /// タイマー開始フラグ の変更前の処理
        /// </summary>
        partial void OnIsTimerStatedChanging(ref bool value);

        /// <summary>
        /// タイマー開始フラグ の変更後の処理
        /// </summary>
        partial void OnIsTimerStatedChanged();

        /// <summary>
        /// タイマー開始フラグ の取得および設定
        /// </summary>
        [RestorableState]
        public bool IsTimerStated
        {
            get
            {
                return this.isTimerStated;
            }

            set
            {
                if (this.isTimerStated != value)
                {
                    this.OnIsTimerStatedChanging(ref value);
                    this.SetProperty<bool>(ref this.isTimerStated, value);
                    this.OnIsTimerStatedChanged();
                }
            }
        }
        #endregion //IsTimerStated:タイマー開始フラグ プロパティ

        #region TimerValue:タイマー残り秒数 プロパティ
        /// <summary>
        /// タイマー残り秒数
        /// </summary>
        private int timerValue; 

        /// <summary>
        /// タイマー残り秒数 の変更前の処理
        /// </summary>
        partial void OnTimerValueChanging(ref int value);

        /// <summary>
        /// タイマー残り秒数 の変更後の処理
        /// </summary>
        partial void OnTimerValueChanged();

        /// <summary>
        /// タイマー残り秒数 の取得および設定
        /// </summary>
        [RestorableState]
        public int TimerValue
        {
            get
            {
                return this.timerValue;
            }

            set
            {
                if (this.timerValue != value)
                {
                    this.OnTimerValueChanging(ref value);
                    this.SetProperty<int>(ref this.timerValue, value);
                    this.OnTimerValueChanged();
                }
            }
        }
        #endregion //TimerValue:タイマー残り秒数 プロパティ

        #region IsEnableStart:タイマー開始可能フラグ プロパティ
        /// <summary>
        /// タイマー開始可能フラグ
        /// </summary>
        private bool isEnableStart; 

        /// <summary>
        /// タイマー開始可能フラグ の変更前の処理
        /// </summary>
        partial void OnIsEnableStartChanging(ref bool value);

        /// <summary>
        /// タイマー開始可能フラグ の変更後の処理
        /// </summary>
        partial void OnIsEnableStartChanged();

        /// <summary>
        /// タイマー開始可能フラグ の取得および設定
        /// </summary>
        [RestorableState]
        public bool IsEnableStart
        {
            get
            {
                return this.isEnableStart;
            }

            set
            {
                if (this.isEnableStart != value)
                {
                    this.OnIsEnableStartChanging(ref value);
                    this.SetProperty<bool>(ref this.isEnableStart, value);
                    this.OnIsEnableStartChanged();
                }
            }
        }
        #endregion //IsEnableStart:タイマー開始可能フラグ プロパティ

        #region IsEnablePause:タイマー一時停止可能フラグ プロパティ
        /// <summary>
        /// タイマー一時停止可能フラグ
        /// </summary>
        private bool isEnablePause; 

        /// <summary>
        /// タイマー一時停止可能フラグ の変更前の処理
        /// </summary>
        partial void OnIsEnablePauseChanging(ref bool value);

        /// <summary>
        /// タイマー一時停止可能フラグ の変更後の処理
        /// </summary>
        partial void OnIsEnablePauseChanged();

        /// <summary>
        /// タイマー一時停止可能フラグ の取得および設定
        /// </summary>
        [RestorableState]
        public bool IsEnablePause
        {
            get
            {
                return this.isEnablePause;
            }

            set
            {
                if (this.isEnablePause != value)
                {
                    this.OnIsEnablePauseChanging(ref value);
                    this.SetProperty<bool>(ref this.isEnablePause, value);
                    this.OnIsEnablePauseChanged();
                }
            }
        }
        #endregion //IsEnablePause:タイマー一時停止可能フラグ プロパティ
	}
}
