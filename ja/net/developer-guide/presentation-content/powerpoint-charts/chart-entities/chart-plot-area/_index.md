---
title: チャートプロットエリア
type: docs
url: /net/chart-plot-area/
keywords: "チャートプロットエリア PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "チャートプロットエリアの幅、高さを取得する。レイアウトモードを設定する。C#または.NETでのPowerPointプレゼンテーション"
---

## **チャートプロットエリアの幅、高さを取得する**
Aspose.Slides for .NETは、シンプルなAPIを提供します。 

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 実際の値を取得するために、メソッド IChart.ValidateChartLayout() を呼び出します。
1. チャート要素の実際のX位置（左）をチャートの左上隅に対して取得します。
1. チャート要素の実際の上部をチャートの左上隅に対して取得します。
1. チャート要素の実際の幅を取得します。
1. チャート要素の実際の高さを取得します。

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// チャート付きのプレゼンテーションを保存
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **チャートプロットエリアのレイアウトモードを設定する**
Aspose.Slides for .NETは、チャートプロットエリアのレイアウトモードを設定するためのシンプルなAPIを提供します。プロパティ **LayoutTargetType** は **ChartPlotArea** および **IChartPlotArea** クラスに追加されました。プロットエリアのレイアウトが手動で定義されている場合、このプロパティは、プロットエリアを内部（軸および軸ラベルを含まない）または外部（軸および軸ラベルを含む）でレイアウトするかどうかを指定します。**LayoutTargetType** 列挙型に定義された2つの可能な値があります。

- **LayoutTargetType.Inner** - プロットエリアのサイズが、目盛りマークおよび軸ラベルを含まないプロットエリアのサイズを決定することを指定します。
- **LayoutTargetType.Outer** - プロットエリアのサイズが、目盛りマークおよび軸ラベルを含むプロットエリアのサイズを決定することを指定します。

サンプルコードは以下の通りです。

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```