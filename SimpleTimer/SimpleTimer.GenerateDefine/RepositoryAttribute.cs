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
    using System.Linq;
    using System.Collections;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 永続化リポジトリ自動生成設定属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class RepositoryAttribute : Attribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ストレージファイル名</param>
        /// <param name="isRoming">ローミング領域保存フラグ</param>
        /// <param name="defaultFileName">デフォルト設定ストレージファイル名</param>
        public RepositoryAttribute(string fileName, bool isRoming = false, string defaultFileName = null)
        {
            this.FileName = fileName;
            this.IsRoming = isRoming;
            this.DefaultFileName = defaultFileName;
        }

        /// <summary>
        /// ストレージファイル名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// ローミング領域保存フラグ
        /// </summary>
        public bool IsRoming { get; set; }

        /// <summary>
        /// デフォルト設定ストレージファイル名
        /// </summary>
        public string DefaultFileName { get; set; }
    }
}
