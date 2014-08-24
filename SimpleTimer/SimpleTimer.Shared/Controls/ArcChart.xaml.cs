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
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI;
    using Windows.UI.Text;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Animation;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// 円弧型チャート
    /// </summary>
    public sealed partial class ArcChart : UserControl
    {
        #region Privates

        /// <summary>
        /// 移動距離
        /// </summary>
        private Point manipulationGap = new Point(0, 0);

        #endregion //Privates

        #region Value 依存関係プロパティ
        /// <summary>
        /// Value 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty ValueProperty
            = DependencyProperty.Register(
            "Value",
            typeof(double),
            typeof(ArcChart),
            new PropertyMetadata(
                0d,
                (s, e) =>
                {
                    var control = s as ArcChart;
                    if (control != null)
                    {
                        control.OnValueChanged(s, new DoubleValueChangedEventArgs((double)e.NewValue, (double)e.OldValue));
                    }
                }));

        /// <summary>
        /// 値
        /// </summary>
        public double Value
        {
            get
            {
                return (double)this.GetValue(ValueProperty);
            }

            set
            {
                this.SetValue(ValueProperty, value);
            }
        }
        #endregion //Value 依存関係プロパティ

        #region MaxValue 依存関係プロパティ
        /// <summary>
        /// MaxValue 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty MaxValueProperty
            = DependencyProperty.Register(
            "MaxValue",
            typeof(double),
            typeof(ArcChart),
            new PropertyMetadata(
                100d,
                (s, e) =>
                {
                    var control = s as ArcChart;
                    if (control != null)
                    {
                        control.OnMaxValueChanged();
                    }
                }));

        /// <summary>
        /// MaxValue 変更イベントハンドラ
        /// </summary>
        private void OnMaxValueChanged()
        {
            this.Render();
            this.Arc.EndAngle = this.ComputeAngle(this.Value);
        }

        /// <summary>
        /// 最大値
        /// </summary>
        public double MaxValue
        {
            get { return (double)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value); }
        }
        #endregion //MaxValue 依存関係プロパティ

        #region MinValue 依存関係プロパティ
        /// <summary>
        /// MinValue 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty MinValueProperty
            = DependencyProperty.Register(
            "MinValue",
            typeof(double),
            typeof(ArcChart),
            new PropertyMetadata(
                0d,
                (s, e) =>
                {
                    var control = s as ArcChart;
                    if (control != null)
                    {
                        control.OnMinValueChanged();
                    }
                }));

        /// <summary>
        /// MinValue 変更イベントハンドラ
        /// </summary>
        private void OnMinValueChanged()
        {
        }

        /// <summary>
        /// 最小値
        /// </summary>
        public double MinValue
        {
            get { return (double)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }
        #endregion //MinValue 依存関係プロパティ

        #region StrokeThickness 依存関係プロパティ
        /// <summary>
        /// StrokeThickness 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty StrokeThicknessProperty
            = DependencyProperty.Register(
            "StrokeThickness",
            typeof(double),
            typeof(ArcChart),
            new PropertyMetadata(
                1d,
                (s, e) =>
                {
                    var control = s as ArcChart;
                    if (control != null)
                    {
                        control.OnStrokeThicknessChanged();
                    }
                }));

        /// <summary>
        /// StrokeThickness 変更イベントハンドラ
        /// </summary>
        private void OnStrokeThicknessChanged()
        {
            this.Arc.StrokeThickness = this.StrokeThickness;
        }

        /// <summary>
        /// 円弧の太さ
        /// </summary>
        public double StrokeThickness
        {
            get { return (double)this.GetValue(StrokeThicknessProperty); }
            set { this.SetValue(StrokeThicknessProperty, value); }
        }
        #endregion //StrokeThickness 依存関係プロパティ

        #region Radius 依存関係プロパティ
        /// <summary>
        /// Radius 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty RadiusProperty
            = DependencyProperty.Register(
            "Radius",
            typeof(double),
            typeof(ArcChart),
            new PropertyMetadata(
                100d,
                (s, e) =>
                {
                    var control = s as ArcChart;
                    if (control != null)
                    {
                        control.OnRadiusChanged();
                    }
                }));

        /// <summary>
        /// Radius 変更イベントハンドラ
        /// </summary>
        private void OnRadiusChanged()
        {
            this.Render();
        }

        /// <summary>
        /// 半径
        /// </summary>
        public double Radius
        {
            get { return (double)this.GetValue(RadiusProperty); }
            set { this.SetValue(RadiusProperty, value); }
        }
        #endregion //Radius 依存関係プロパティ

        #region Stroke 依存関係プロパティ
        /// <summary>
        /// Stroke 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty StrokeProperty
            = DependencyProperty.Register(
            "Stroke",
            typeof(Brush),
            typeof(ArcChart),
            new PropertyMetadata(
                new SolidColorBrush(Colors.OrangeRed),
                (s, e) =>
                {
                    var control = s as ArcChart;
                    if (control != null)
                    {
                        control.OnStrokeChanged();
                    }
                }));

        /// <summary>
        /// Stroke 変更イベントハンドラ
        /// </summary>
        private void OnStrokeChanged()
        {
            this.Arc.Stroke = this.Stroke;
        }

        /// <summary>
        /// Shape のアウトラインの描画方法を指定する Brush
        /// </summary>
        public Brush Stroke
        {
            get { return (Brush)this.GetValue(StrokeProperty); }
            set { this.SetValue(StrokeProperty, value); }
        }
        #endregion //Stroke 依存関係プロパティ

        #region HorizontalThreshold 依存関係プロパティ
        /// <summary>
        /// HorizontalThreshold 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty HorizontalThresholdProperty
            = DependencyProperty.Register(
            "HorizontalThreshold",
            typeof(double),
            typeof(ArcChart),
            new PropertyMetadata(
                60d));

        /// <summary>
        /// 水平移動距離のしきい値
        /// </summary>
        public double HorizontalThreshold
        {
            get { return (double)this.GetValue(HorizontalThresholdProperty); }
            set { this.SetValue(HorizontalThresholdProperty, value); }
        }
        #endregion //HorizontalThreshold 依存関係プロパティ

        #region VerticalThreshold 依存関係プロパティ
        /// <summary>
        /// VerticalThreshold 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty VerticalThresholdProperty
            = DependencyProperty.Register(
            "VerticalThreshold",
            typeof(double),
            typeof(ArcChart),
            new PropertyMetadata(
                40d));

        /// <summary>
        /// 垂直移動距離のしきい値
        /// </summary>
        public double VerticalThreshold
        {
            get { return (double)this.GetValue(VerticalThresholdProperty); }
            set { this.SetValue(VerticalThresholdProperty, value); }
        }
        #endregion //VerticalThreshold 依存関係プロパティ

        #region HorizontalPlay 依存関係プロパティ
        /// <summary>
        /// HorizontalPlay 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty HorizontalPlayProperty
            = DependencyProperty.Register(
            "HorizontalPlay",
            typeof(double),
            typeof(ArcChart),
            new PropertyMetadata(
                20d));

        /// <summary>
        /// 水平移動距離のあそび値
        /// </summary>
        public double HorizontalPlay
        {
            get { return (double)this.GetValue(HorizontalPlayProperty); }
            set { this.SetValue(HorizontalPlayProperty, value); }
        }
        #endregion //HorizontalPlay 依存関係プロパティ

        #region VerticalPlay 依存関係プロパティ
        /// <summary>
        /// VerticalPlay 依存関係プロパティ
        /// </summary>
        public static readonly DependencyProperty VerticalPlayProperty
            = DependencyProperty.Register(
            "VerticalPlay",
            typeof(double),
            typeof(ArcChart),
            new PropertyMetadata(
                20d));

        /// <summary>
        /// 垂直移動距離のあそび値
        /// </summary>
        public double VerticalPlay
        {
            get { return (double)this.GetValue(VerticalPlayProperty); }
            set { this.SetValue(VerticalPlayProperty, value); }
        }
        #endregion //VerticalPlay 依存関係プロパティ

        /// <summary>
        /// 値変更後イベント
        /// </summary>
        public event DoubleValueChangedEventHandler ValueChanged;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ArcChart()
        {
            this.InitializeComponent();

            this.OnValueChanged(this, new DoubleValueChangedEventArgs(this.Value, this.MinValue));
        }

        /// <summary>
        /// 描画する
        /// </summary>
        public void Render()
        {
            this.BackgroundArc.Radius = this.Radius;
            this.Arc.Radius = this.Radius;
            this.Number.Text = TimeSpan.FromSeconds(this.Value).ToString(@"h\:mm\:ss");
        }

        /// <summary>
        /// 値から角度を計算する
        /// </summary>
        /// <param name="value">値</param>
        /// <returns>角度</returns>
        private double ComputeAngle(double value)
        {
            return 105d + (((value - this.MinValue) / (this.MaxValue - this.MinValue)) * 330d);
        }

        /// <summary>
        /// 値変更後の処理
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        private void OnValueChanged(object sender, DoubleValueChangedEventArgs e)
        {
            var value = e.NewValue;
            if (value > this.MaxValue)
            {
                value = this.MaxValue;
            }
            if (value < this.MinValue)
            {
                value = this.MinValue;
            }
            if (Math.Abs(e.OldValue - value) <= 0)
            {
                return;
            }

            //this.ValueChangeAnimation.Stop();
            var animation = this.ValueChangeAnimation.Children.First() as DoubleAnimationUsingKeyFrames;
            if (animation == null)
            {
                return;
            }
            //animation.KeyFrames[0].Value = this.ComputeAngle(e.OldValue);
            //animation.KeyFrames[1].Value = this.ComputeAngle(e.NewValue);
            //this.ValueChangeAnimation.Begin();
            this.Arc.EndAngle = this.ComputeAngle(e.NewValue);

            this.Render();

            if (this.ValueChanged != null)
            {
                this.ValueChanged(this, e);
            }
        }

        /// <summary>
        /// ドラッグ移動時の処理
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        private void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            // 水平か垂直かどちらか一方だけに平行移動するようにする
            if (this.ManipulationMode == ManipulationModes.TranslateX || Math.Abs(e.Delta.Translation.X) > Math.Abs(e.Delta.Translation.Y))
            {
                this.manipulationGap.X += e.Delta.Translation.X;
                this.manipulationGap.Y = 0;
                this.ManipulationMode = ManipulationModes.TranslateX;
                e.Handled = true;
            }
            else if (this.ManipulationMode == ManipulationModes.TranslateY || Math.Abs(e.Delta.Translation.X) <= Math.Abs(e.Delta.Translation.Y))
            {
                this.manipulationGap.X = 0;
                this.manipulationGap.Y += e.Delta.Translation.Y;
                this.ManipulationMode = ManipulationModes.TranslateY;
                e.Handled = true;
            }

            // しきい値 + あそび値 を越えて移動しないようにする
            if (Math.Abs(this.manipulationGap.X) > this.HorizontalThreshold + this.HorizontalPlay)
            {
                this.manipulationGap.X = (this.HorizontalThreshold + this.HorizontalPlay) * Math.Sign(this.manipulationGap.X);
            }
            if (Math.Abs(this.manipulationGap.Y) > this.VerticalThreshold + this.VerticalPlay)
            {
                this.manipulationGap.Y = (this.VerticalThreshold + this.VerticalPlay) * Math.Sign(this.manipulationGap.Y);
            }

            // 平行移動させる
            this.Chart.RenderTransform = new TranslateTransform()
            {
                X = this.manipulationGap.X,
                Y = this.manipulationGap.Y,
            };
        }

        /// <summary>
        /// ドラッグ終了時の処理
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="e">イベント引数</param>
        private void OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            // 移動距離がしきい値を越えていた場合、値を増減する
            if (Math.Abs(this.manipulationGap.X) >= this.HorizontalThreshold)
            {
                this.Value += 600 * Math.Sign(this.manipulationGap.X);
            }
            else if (Math.Abs(this.manipulationGap.Y) >= this.VerticalThreshold)
            {
                this.Value += 60 * Math.Sign(this.manipulationGap.Y);
            }

            // 元の位置に戻す
            this.Chart.RenderTransform = new TranslateTransform()
            {
                X = 0,
                Y = 0,
            };
            this.manipulationGap.X = 0;
            this.manipulationGap.Y = 0;
            this.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
        }
    }

    /// <summary>
    /// ValueChanged イベントを処理するメソッドを表します
    /// </summary>
    /// <param name="sender">イベント発行者</param>
    /// <param name="e">イベントのデータ</param>
    public delegate void DoubleValueChangedEventHandler(object sender, DoubleValueChangedEventArgs e);

    /// <summary>
    /// double 値の変更イベントのデータ
    /// </summary>
    public class DoubleValueChangedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// 新しい値
        /// </summary>
        public double NewValue { get; private set; }

        /// <summary>
        /// 古い値
        /// </summary>
        public double OldValue { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="newValue">新しい値</param>
        /// <param name="oldValue">古い値</param>
        public DoubleValueChangedEventArgs(double newValue, double oldValue)
        {
            this.NewValue = newValue;
            this.OldValue = oldValue;
        }
    }
}
