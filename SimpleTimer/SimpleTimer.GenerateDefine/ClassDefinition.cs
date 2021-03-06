﻿//<auto-generated>
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
    /// クラス定義情報
    /// </summary>
    public class ClassDefinition
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">クラス名称</param>
        /// <param name="baseType">基底クラスの型</param>
        /// <param name="description">クラスの説明</param>
        /// <param name="propertyAttributes">プロパティ属性</param>
        /// <param name="attributes">付帯属性</param>
        public ClassDefinition(string name, Type baseType, string description, PropertyAttribute[] propertyAttributes,
            params string[] attributes)
        {
            this.Name = name;
            this.BaseBaseTypeName = baseType.Name;
            this.Description = description;
            this.PropertyAttributes = propertyAttributes;
            this.Attributes = attributes;
        }

        /// <summary>
        /// クラス名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 基底クラスの型
        /// </summary>
        public string BaseBaseTypeName { get; set; }

        /// <summary>
        /// クラスの説明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// プロパティ属性
        /// </summary>
        public PropertyAttribute[] PropertyAttributes { get; set; }

        /// <summary>
        /// 付帯属性
        /// </summary>
        public string[] Attributes { get; set; }
    }

    /// <summary>
    /// 説明文属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="description">説明文</param>
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        /// <summary>
        /// プロパティ名称
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 付帯属性属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ClassAttributeAttribute : Attribute
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="attribute">説明文</param>
        public ClassAttributeAttribute(string attribute)
        {
            this.Attribute = attribute;
        }

        /// <summary>
        /// プロパティ名称
        /// </summary>
        public string Attribute { get; set; }
    }
}
