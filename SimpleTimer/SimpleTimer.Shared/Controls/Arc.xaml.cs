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
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

/// <summary>
/// 角度指定できる円弧シェイプ
/// </summary>
public sealed partial class Arc : UserControl
{
    #region StartAngle 依存関係プロパティ
    /// <summary>
    /// StartAngle 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StartAngleProperty
        = DependencyProperty.Register(
        "StartAngle",
        typeof(double),
        typeof(Arc),
        new PropertyMetadata(
            0d,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnStartAngleChanged();
                }
            }));

    /// <summary>
    /// StartAngle 変更イベントハンドラ
    /// </summary>
    private void OnStartAngleChanged()
    {
        this.Render();
    }

    /// <summary>
    /// 始点角度
    /// </summary>
    public double StartAngle
    {
        get { return (double)this.GetValue(StartAngleProperty); }
        set { this.SetValue(StartAngleProperty, value); }
    }
    #endregion //StartAngle 依存関係プロパティ

    #region EndAngle 依存関係プロパティ
    /// <summary>
    /// EndAngle 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty EndAngleProperty
        = DependencyProperty.Register(
        "EndAngle",
        typeof(double),
        typeof(Arc),
        new PropertyMetadata(
            360d,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnEndAngleChanged();
                }
            }));

    /// <summary>
    /// EndAngle 変更イベントハンドラ
    /// </summary>
    private void OnEndAngleChanged()
    {
        this.Render();
    }

    /// <summary>
    /// 終点角度
    /// </summary>
    public double EndAngle
    {
        get { return (double)this.GetValue(EndAngleProperty); }
        set { this.SetValue(EndAngleProperty, value); }
    }
    #endregion //EndAngle 依存関係プロパティ

    #region Radius 依存関係プロパティ
    /// <summary>
    /// Radius 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty RadiusProperty
        = DependencyProperty.Register(
        "Radius",
        typeof(double),
        typeof(Arc),
        new PropertyMetadata(
            100d,
            (s, e) =>
            {
                var control = s as Arc;
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

    #region StrokeThickness 依存関係プロパティ
    /// <summary>
    /// StrokeThickness 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StrokeThicknessProperty
        = DependencyProperty.Register(
        "StrokeThickness",
        typeof(double),
        typeof(Arc),
        new PropertyMetadata(
            1d,
            (s, e) =>
            {
                var control = s as Arc;
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
        this.Shape.StrokeThickness = this.StrokeThickness;
    }

    /// <summary>
    /// 枠線の太さ
    /// </summary>
    public double StrokeThickness
    {
        get { return (double)this.GetValue(StrokeThicknessProperty); }
        set { this.SetValue(StrokeThicknessProperty, value); }
    }
    #endregion //StrokeThickness 依存関係プロパティ

    #region StrokeStartLineCap 依存関係プロパティ
    /// <summary>
    /// StrokeStartLineCap 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StrokeStartLineCapProperty
        = DependencyProperty.Register(
        "StrokeStartLineCap",
        typeof(PenLineCap),
        typeof(Arc),
        new PropertyMetadata(
            PenLineCap.Flat,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnStrokeStartLineCapChanged();
                }
            }));

    /// <summary>
    /// StrokeStartLineCap 変更イベントハンドラ
    /// </summary>
    private void OnStrokeStartLineCapChanged()
    {
        this.Shape.StrokeEndLineCap = this.StrokeStartLineCap;
    }

    /// <summary>
    /// Stroke の始点で図形を指定する PenLineCap 列挙型の値
    /// </summary>
    public PenLineCap StrokeStartLineCap
    {
        get { return (PenLineCap)this.GetValue(StrokeStartLineCapProperty); }
        set { this.SetValue(StrokeStartLineCapProperty, value); }
    }
    #endregion //StrokeStartLineCap 依存関係

    #region StrokeMiterLimit 依存関係プロパティ
    /// <summary>
    /// StrokeMiterLimit 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StrokeMiterLimitProperty
        = DependencyProperty.Register(
        "StrokeMiterLimit",
        typeof(double),
        typeof(Arc),
        new PropertyMetadata(
            1d,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnStrokeMiterLimitChanged();
                }
            }));

    /// <summary>
    /// StrokeMiterLimit 変更イベントハンドラ
    /// </summary>
    private void OnStrokeMiterLimitChanged()
    {
        this.Shape.StrokeMiterLimit = this.StrokeMiterLimit;
    }

    /// <summary>
    /// Shape 要素の StrokeThickness に対するマイターの長さの割合に関する制限
    /// </summary>
    public double StrokeMiterLimit
    {
        get { return (double)this.GetValue(StrokeMiterLimitProperty); }
        set { this.SetValue(StrokeMiterLimitProperty, value); }
    }
    #endregion //StrokeMiterLimit 依存関係プロパティ

    #region StrokeLineJoin 依存関係プロパティ
    /// <summary>
    /// StrokeLineJoin 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StrokeLineJoinProperty
        = DependencyProperty.Register(
        "StrokeLineJoin",
        typeof(PenLineJoin),
        typeof(Arc),
        new PropertyMetadata(
            PenLineJoin.Miter,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnStrokeLineJoinChanged();
                }
            }));

    /// <summary>
    /// StrokeLineJoin 変更イベントハンドラ
    /// </summary>
    private void OnStrokeLineJoinChanged()
    {
        this.Shape.StrokeLineJoin = this.StrokeLineJoin;
    }

    /// <summary>
    /// 接合の外観を指定する PenLineJoin 列挙型の値
    /// </summary>
    public PenLineJoin StrokeLineJoin
    {
        get { return (PenLineJoin)this.GetValue(StrokeLineJoinProperty); }
        set { this.SetValue(StrokeLineJoinProperty, value); }
    }
    #endregion //StrokeLineJoin 依存関係プロパティ

    #region StrokeEndLineCap 依存関係プロパティ
    /// <summary>
    /// StrokeEndLineCap 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StrokeEndLineCapProperty
        = DependencyProperty.Register(
        "StrokeEndLineCap",
        typeof(PenLineCap),
        typeof(Arc),
        new PropertyMetadata(
            PenLineCap.Flat,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnStrokeEndLineCapChanged();
                }
            }));

    /// <summary>
    /// StrokeEndLineCap 変更イベントハンドラ
    /// </summary>
    private void OnStrokeEndLineCapChanged()
    {
        this.Shape.StrokeEndLineCap = this.StrokeEndLineCap;
    }

    /// <summary>
    /// PenLineCap の列挙値の 1 つ
    /// </summary>
    public PenLineCap StrokeEndLineCap
    {
        get { return (PenLineCap)this.GetValue(StrokeEndLineCapProperty); }
        set { this.SetValue(StrokeEndLineCapProperty, value); }
    }
    #endregion //StrokeEndLineCap 依存関係プロパティ

    #region StrokeDashOffset 依存関係プロパティ
    /// <summary>
    /// StrokeDashOffset 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StrokeDashOffsetProperty
        = DependencyProperty.Register(
        "StrokeDashOffset",
        typeof(double),
        typeof(Arc),
        new PropertyMetadata(
            0d,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnStrokeDashOffsetChanged();
                }
            }));

    /// <summary>
    /// StrokeDashOffset 変更イベントハンドラ
    /// </summary>
    private void OnStrokeDashOffsetChanged()
    {
        this.Shape.StrokeThickness = this.StrokeThickness;
    }

    /// <summary>
    /// 破線パターン内のダッシュの始点間の距離を表す値
    /// </summary>
    public double StrokeDashOffset
    {
        get { return (double)this.GetValue(StrokeDashOffsetProperty); }
        set { this.SetValue(StrokeDashOffsetProperty, value); }
    }
    #endregion //StrokeDashOffset 依存関係プロパティ

    #region StrokeDashCap 依存関係プロパティ
    /// <summary>
    /// StrokeDashCap 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StrokeDashCapProperty
        = DependencyProperty.Register(
        "StrokeDashCap",
        typeof(PenLineCap),
        typeof(Arc),
        new PropertyMetadata(
            PenLineCap.Flat,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnStrokeDashCapChanged();
                }
            }));

    /// <summary>
    /// StrokeDashCap 変更イベントハンドラ
    /// </summary>
    private void OnStrokeDashCapChanged()
    {
        this.Shape.StrokeDashCap = this.StrokeDashCap;
    }

    /// <summary>
    /// PenLineCap の列挙値の 1 つ
    /// </summary>
    public PenLineCap StrokeDashCap
    {
        get { return (PenLineCap)this.GetValue(StrokeDashCapProperty); }
        set { this.SetValue(StrokeDashCapProperty, value); }
    }
    #endregion //StrokeDashCap 依存関係プロパティ

    #region StrokeDashArray 依存関係プロパティ
    /// <summary>
    /// StrokeDashArray 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StrokeDashArrayProperty
        = DependencyProperty.Register(
        "StrokeDashArray",
        typeof(DoubleCollection),
        typeof(Arc),
        new PropertyMetadata(
            null,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnStrokeDashArrayChanged();
                }
            }));

    /// <summary>
    /// StrokeDashArray 変更イベントハンドラ
    /// </summary>
    private void OnStrokeDashArrayChanged()
    {
        this.Shape.StrokeDashArray = this.StrokeDashArray;
    }

    /// <summary>
    /// ダッシュと空白から成る破線パターンを指定する Double 値のコレクション
    /// </summary>
    public DoubleCollection StrokeDashArray
    {
        get { return (DoubleCollection)this.GetValue(StrokeDashArrayProperty); }
        set { this.SetValue(StrokeDashArrayProperty, value); }
    }
    #endregion //StrokeDashCap 依存関係プロパティ

    #region Stroke 依存関係プロパティ
    /// <summary>
    /// Stroke 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StrokeProperty
        = DependencyProperty.Register(
        "Stroke",
        typeof(Brush),
        typeof(Arc),
        new PropertyMetadata(
            null,
            (s, e) =>
            {
                var control = s as Arc;
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
        this.Shape.Stroke = this.Stroke;
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

    #region Fill 依存関係プロパティ
    /// <summary>
    /// Stretch 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty StretchProperty
        = DependencyProperty.Register(
        "Stretch",
        typeof(Brush),
        typeof(Arc),
        new PropertyMetadata(
            Stretch.None,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnStretchChanged();
                }
            }));

    /// <summary>
    /// Stretch 変更イベントハンドラ
    /// </summary>
    private void OnStretchChanged()
    {
        this.Shape.Stretch = this.Stretch;
    }

    /// <summary>
    /// Stretch 列挙値のいずれか
    /// </summary>
    public Stretch Stretch
    {
        get { return (Stretch)this.GetValue(StretchProperty); }
        set { this.SetValue(StretchProperty, value); }
    }
    #endregion //Stretch 依存関係プロパティ

    #region Fill 依存関係プロパティ
    /// <summary>
    /// Fill 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty FillProperty
        = DependencyProperty.Register(
        "Fill",
        typeof(Brush),
        typeof(Arc),
        new PropertyMetadata(
            null,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnFillChanged();
                }
            }));

    /// <summary>
    /// Fill 変更イベントハンドラ
    /// </summary>
    private void OnFillChanged()
    {
        this.Shape.Fill = this.Fill;
    }

    /// <summary>
    /// Fill のアウトラインの描画方法を指定する Brush
    /// </summary>
    public Brush Fill
    {
        get { return (Brush)this.GetValue(FillProperty); }
        set { this.SetValue(FillProperty, value); }
    }
    #endregion //Fill 依存関係プロパティ

    #region GeometryTransform 依存関係プロパティ
    /// <summary>
    /// Stretch 依存関係プロパティ
    /// </summary>
    public static readonly DependencyProperty GeometryTransformProperty
        = DependencyProperty.Register(
        "GeometryTransform",
        typeof(Transform),
        typeof(Arc),
        new PropertyMetadata(
            null,
            (s, e) =>
            {
                var control = s as Arc;
                if (control != null)
                {
                    control.OnGeometryTransformChanged();
                }
            }));

    /// <summary>
    /// GeometryTransform 変更イベントハンドラ
    /// </summary>
    private void OnGeometryTransformChanged()
    {
        this.Shape.Stretch = this.Stretch;
    }

    /// <summary>
    /// Shape のジオメトリに描画前に適用される Transform
    /// </summary>
    public Transform GeometryTransform
    {
        get { return (Transform)this.GetValue(GeometryTransformProperty); }
        set { this.SetValue(GeometryTransformProperty, value); }
    }
    #endregion //GeometryTransform 依存関係プロパティ

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Arc()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// 描画する
    /// </summary>
    public void Render()
    {
        var start = this.StartAngle;
        var end = this.EndAngle;

        if (this.StartAngle > this.EndAngle)
        {
            start = this.EndAngle;
            end = this.StartAngle;
        }

        var figure = new PathFigure();
        figure.IsClosed = false;
        figure.StartPoint = this.ComputeAngle(start);
        for (double i = start + 1; i < end; i++)
        {
            figure.Segments.Add(new ArcSegment()
            {
                IsLargeArc = false,
                RotationAngle = 0,
                Size = new Size(this.Radius, this.Radius),
                Point = this.ComputeAngle(i),
                SweepDirection = SweepDirection.Counterclockwise,
            });
        }
        if (Math.Floor(this.EndAngle) < this.EndAngle)
        {
            figure.Segments.Add(new ArcSegment()
            {
                IsLargeArc = false,
                RotationAngle = 0,
                Size = new Size(this.Radius, this.Radius),
                Point = this.ComputeAngle(this.EndAngle),
                SweepDirection = SweepDirection.Counterclockwise,
            });
        }
        var geometory = new PathGeometry();
        geometory.Figures.Add(figure);
        this.Shape.Data = geometory;
    }

    /// <summary>
    /// 角度を XY 座標に変換する
    /// </summary>
    /// <param name="angle">角度</param>
    /// <returns>XY 座標</returns>
    private Point ComputeAngle(double angle)
    {
        return new Point(this.Radius + (this.Radius * Math.Cos((360 - angle) * Math.PI / 180)), this.Radius + (this.Radius * Math.Sin((360 - angle) * Math.PI / 180)));
    }
}
}
