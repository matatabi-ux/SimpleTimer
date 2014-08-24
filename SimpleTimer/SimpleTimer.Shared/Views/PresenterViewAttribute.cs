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
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;
    using SimpleTimer.Presenters;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Presenter 属性
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class PresenterViewAttribute : Attribute
    {
        #region Privates

        /// <summary>
        /// Presenter の型
        /// </summary>
        private Type type;

        #endregion //Privates

        /// <summary>
        /// Presenter の型
        /// </summary>
        public Type Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="type">Presenter の型</param>
        public PresenterViewAttribute(Type type)
        {
            this.type = type;
        }
    }

    /// <summary>
    /// Presenter つき FrameworkElement の拡張クラス
    /// </summary>
    public static class PresenterViewExtention
    {
        /// <summary>
        /// Presenter の型を取得する
        /// </summary>
        /// <param name="view">View</param>
        /// <returns>Presenter の型</returns>
        public static Type GetPresenterType(this FrameworkElement view)
        {
            return PresenterViewExtention.GetAttribute(view).Type;
        }

        /// <summary>
        /// Presenter のインスタンスを取得する
        /// </summary>
        /// <typeparam name="T">Presenter の型</typeparam>
        /// <param name="view">View</param>
        /// <returns>Presenter</returns>
        public static T GetPresenter<T>(this FrameworkElement view) where T : class
        {
            return PresenterLocator.Get(view.GetPresenterType()) as T;
        }

        /// <summary>
        /// Presenter のインスタンスを取得する
        /// </summary>
        /// <param name="view">View</param>
        /// <returns>Presenter</returns>
        public static object GetPresenter(this FrameworkElement view)
        {
            return PresenterLocator.Get(view.GetPresenterType());
        }

        /// <summary>
        /// PresenterView の属性を取得する
        /// </summary>
        /// <param name="view">View</param>
        /// <returns>PresenterView の属性</returns>
        private static PresenterViewAttribute GetAttribute(FrameworkElement view)
        {
            var viewType = view.GetType();
            var attribute = viewType.GetTypeInfo().GetCustomAttribute(typeof(PresenterViewAttribute), false) as PresenterViewAttribute;
            if (attribute == null)
            {
                throw new InvalidOperationException("この Page には PresenterView 属性が指定されていません");
            }

            return attribute;
        }
    }
}
