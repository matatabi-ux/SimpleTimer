﻿//<auto-generated>
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
    using System.ComponentModel; 
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// Presenter 配置クラス
    /// </summary>
    public class PresenterLocator
    {
        #region Privates

        /// <summary>
        /// コンテナ
        /// </summary>
        private static readonly UnityContainer Container = new UnityContainer();

        #endregion //Privates

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static PresenterLocator()
        {
            // アプリケーション内の IPresenterBase を実装するクラスをコンテナに一括登録する
            var types = typeof(PresenterLocator).GetTypeInfo().Assembly.DefinedTypes;

            var presenterTypes = types.Where(
                ti => ti.IsClass
                & !ti.IsAbstract
                && !ti.IsValueType
                && ti.IsVisible
                && ti.AsType().GetTypeInfo().ImplementedInterfaces.Contains(typeof(IPresenterBase))).Select(ti => ti.AsType());

            // コンテナ内で Presenter インスタンスをシングルトン化する
            foreach (var type in presenterTypes)
            {
                Container.RegisterType(type, new ContainerControlledLifetimeManager());
            }
        }

        /// <summary>
        /// Presenter を取得する
        /// </summary>
        /// <typeparam name="T">Presenter の型</typeparam>
        /// <returns>Presenter</returns>
        public static T Get<T>() where T : class
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Presenter を取得する
        /// </summary>
        /// <param name="type">Presenter の型</param>
        /// <returns>Presenter</returns>
        public static object Get(Type type)
        {
            return Container.Resolve(type);
        }
    }
}
