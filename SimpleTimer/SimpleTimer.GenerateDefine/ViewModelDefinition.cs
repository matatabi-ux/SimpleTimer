#region License
//-----------------------------------------------------------------------
// <copyright>
//     Copyright matatabi-ux 2014.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace SimpleTimer.GenerateDefine
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ViewModel 自動生成定義クラス
    /// </summary>
    public static class ViewModelDefinition
    {
        /// <summary>
        /// ViewModel の自動生成定義を取得する
        /// </summary>
        /// <returns>ViewModel の自動生成定義</returns>
        public static IEnumerable<ClassDefinition> GetDefinitions()
        {
            var types = typeof(ViewModelDefinition).GetTypeInfo().Assembly.DefinedTypes.Where(
                ti => ti.IsClass
                & !ti.IsAbstract
                && !ti.IsValueType
                && ti.IsSubclassOf(typeof(ViewModelBase)));

            return types.Select(
                t => new ClassDefinition(
                    t.Name,
                    t.BaseType,
                    t.GetCustomAttributes<DescriptionAttribute>().Any() ? t.GetCustomAttributes<DescriptionAttribute>().First().Description : string.Empty,
                    t.GetCustomAttributes<PropertyAttribute>().ToArray()));
        }
    }

    /// <summary>
    /// ViewModel 基底クラス定義
    /// </summary>
    class ViewModelBase
    {
    }

    [Description("グループコンテナ ViewModel")]
    [Property("uniqueId", typeof(string), "ID", "[RestorableState]")]
    [Property("contentId", typeof(string), "コンテンツ ID", "[RestorableState]")]
    [Property("content", typeof(ViewModelBase), "コンテンツ ViewModel", "[RestorableState]")]
    [Property("header", typeof(string), "ヘッダ", "[RestorableState]")]
    [Property("items", typeof(ObservableCollection<ItemContainerViewModel>), "アイテム情報 ViewModel", "[RestorableState]")]
    [Property("isClickable", typeof(bool), "クリック可能フラグ", "[RestorableState]")]
    class GroupContainerViewModel : ViewModelBase
    {
    }

    [Description("アイテムコンテナ ViewModel")]
    [Property("uniqueId", typeof(string), "ID", "[RestorableState]")]
    [Property("contentId", typeof(string), "コンテンツ ID", "[RestorableState]")]
    [Property("content", typeof(ViewModelBase), "コンテンツ ViewModel", "[RestorableState]")]
    [Property("columnSpan", typeof(int), "横幅", "[RestorableState]")]
    [Property("rowSpan", typeof(int), "縦幅", "[RestorableState]")]
    [Property("isClickable", typeof(bool), "クリック可能フラグ", "[RestorableState]")]
    [Property("isSelectable", typeof(bool), "選択可能フラグ", "[RestorableState]")]
    class ItemContainerViewModel : ViewModelBase
    {
    }

    [Description("トップ画面の ViewModel")]
    [Property("MaxSeconds", typeof(int), "タイマー設定秒数", "[RestorableState]")]
    [Property("TimerValue", typeof(int), "タイマー残り秒数", "[RestorableState]")]
    [Property("IsTimerStated", typeof(bool), "タイマー開始フラグ", "[RestorableState]")]
    [Property("IsTimerPaused", typeof(bool), "タイマー一時停止フラグ", "[RestorableState]")]
    [Property("IsEnableStart", typeof(bool), "タイマー開始可能フラグ", "[RestorableState]")]
    [Property("IsEnablePause", typeof(bool), "タイマー一時停止可能フラグ", "[RestorableState]")]
    [Property("IsEnableStop", typeof(bool), "タイマー停止可能フラグ", "[RestorableState]")]
    class TopPageViewModel : ViewModelBase
    {
    }
}
