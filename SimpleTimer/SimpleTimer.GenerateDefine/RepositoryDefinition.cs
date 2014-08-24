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
    using System.Reflection;

    /// <summary>
    /// 永続化リポジトリ定義情報
    /// </summary>
    public class RepositoryDefinition
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="modelName">モデルクラス名</param>
        /// <param name="modelDescription">モデル説明文</param>
        /// <param name="attribute">リポジトリ自動生成属性定義</param>
        public RepositoryDefinition(string modelName, string modelDescription, RepositoryAttribute attribute)
        {
            this.ModelName = modelName;
            this.ModelDescription = modelDescription;
            this.FileName = attribute.FileName;
            this.IsRoming = attribute.IsRoming;
            this.DefaultFileName = attribute.DefaultFileName;
        }

        /// <summary>
        /// モデルクラス名
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// モデル説明文
        /// </summary>
        public string ModelDescription { get; set; }

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
        public string DefaultFileName { get; set; }    }
}
