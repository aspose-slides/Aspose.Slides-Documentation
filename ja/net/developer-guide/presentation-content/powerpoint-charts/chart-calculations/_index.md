---
title: チャート計算
type: docs
weight: 50
url: /net/chart-calculations/
keywords: "チャート計算, チャート要素, 要素位置, チャート値 C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETにおけるPowerPointチャート計算と値"
---

## **チャート要素の実際の値を計算する**
Aspose.Slides for .NETは、これらのプロパティを取得するためのシンプルなAPIを提供します。これにより、チャート要素の実際の値を計算することができます。実際の値には、IActualLayoutインターフェースを実装する要素の位置（IActualLayout.ActualX、IActualLayout.ActualY、IActualLayout.ActualWidth、IActualLayout.ActualHeight）および実際の軸値（IAxis.ActualMaxValue、IAxis.ActualMinValue、IAxis.ActualMajorUnit、IAxis.ActualMinorUnit、IAxis.ActualMajorUnitScale、IAxis.ActualMinorUnitScale）が含まれます。

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// プレゼンテーションを保存する
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **親チャート要素の実際の位置を計算する**
Aspose.Slides for .NETは、これらのプロパティを取得するためのシンプルなAPIを提供します。IActualLayoutのプロパティは、親チャート要素の実際の位置に関する情報を提供します。プロパティに実際の値を設定するには、IChart.ValidateChartLayout()メソッドを事前に呼び出す必要があります。

```c#
// 空のプレゼンテーションを作成する
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```

## **チャートから情報を隠す**
このトピックは、チャートから情報を隠す方法を理解するのに役立ちます。Aspose.Slides for .NETを使用すると、チャートから**タイトル、縦軸、横軸**、および**グリッド線**を隠すことができます。以下のコード例は、これらのプロパティを使用する方法を示しています。

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // チャートタイトルを隠す
    chart.HasTitle = false;

    // 値軸を隠す
    chart.Axes.VerticalAxis.IsVisible = false;

    // カテゴリー軸の可視性
    chart.Axes.HorizontalAxis.IsVisible = false;

    // 凡例を隠す
    chart.HasLegend = false;

    // メジャーグリッドラインを隠す
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    // シリーズの線の色を設定する
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```