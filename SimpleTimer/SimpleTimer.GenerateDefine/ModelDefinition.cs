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
    /// Model 自動生成定義クラス
    /// </summary>
    public static class ModelDefinition
    {
        /// <summary>
        /// Model の自動生成定義を取得する
        /// </summary>
        /// <returns>Model の自動生成定義</returns>
        public static IEnumerable<ClassDefinition> GetDefinitions()
        {
            var types = typeof(ModelDefinition).GetTypeInfo().Assembly.DefinedTypes.Where(
                ti => ti.IsClass
                & !ti.IsAbstract
                && !ti.IsValueType
                && ti.GetCustomAttributes<PropertyAttribute>().Any()
                && !ti.IsSubclassOf(typeof(ViewModelBase)));

            return types.Select(
                t => new ClassDefinition(
                    t.Name,
                    t.BaseType,
                    t.GetCustomAttributes<DescriptionAttribute>().Any() ? t.GetCustomAttributes<DescriptionAttribute>().First().Description : string.Empty,
                    t.GetCustomAttributes<PropertyAttribute>().ToArray(),
                    t.GetCustomAttributes<ClassAttributeAttribute>().Any() ? t.GetCustomAttributes<ClassAttributeAttribute>().Select<ClassAttributeAttribute, string>(a => a.Attribute).ToArray() : null));
        }

        /// <summary>
        /// 永続化リポジトリの自動生成定義を取得する
        /// </summary>
        /// <returns>Model の自動生成定義</returns>
        public static IEnumerable<RepositoryDefinition> GetRepositoryDefinitions()
        {
            var types = typeof(ModelDefinition).GetTypeInfo().Assembly.DefinedTypes.Where(
                ti => ti.IsClass
                & !ti.IsAbstract
                && !ti.IsValueType
                && ti.GetCustomAttributes<RepositoryAttribute>().Any()
                && !ti.IsSubclassOf(typeof(ViewModelBase)));

            return types.Select(
                t => new RepositoryDefinition(
                    t.Name,
                    t.GetCustomAttributes<DescriptionAttribute>().Any() ? t.GetCustomAttributes<DescriptionAttribute>().First().Description : t.Name,
                    t.GetCustomAttributes<RepositoryAttribute>().FirstOrDefault()));
        }
    }

    [Description("アプリケーション設定情報")]
    [ClassAttribute("[XmlRoot(\"app-setting\")]")]
    [Property("MaxSeconds", typeof(int), "タイマー設定秒数", "[XmlAttribute(\"max\")]")]
    [Property("TimerValue", typeof(int), "タイマー残り秒数", "[XmlAttribute(\"value\")]")]
    [Repository(@"app-settings.xml", false, @"ms-appx:///Assets/Data/default-app-settings.xml")]
    class ApplicationSettings
    {
    }
}
