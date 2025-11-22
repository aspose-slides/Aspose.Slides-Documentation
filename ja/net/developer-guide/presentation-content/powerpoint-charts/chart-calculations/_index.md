---
title: チャート計算
type: docs
weight: 50
url: /ja/net/chart-calculations/
keywords: "チャート計算, チャート要素, 要素の位置, チャート値 C#, C#, Aspose.Slides for .NET"
description: "PowerPoint のチャート計算と値（C# または .NET）"
---

## **チャート要素の実際の値を計算**
Aspose.Slides for .NET は、これらのプロパティを取得するためのシンプルな API を提供します。これにより、チャート要素の実際の値を計算できます。実際の値には、IActualLayout インターフェイスを実装する要素の位置 (IActualLayout.ActualX、IActualLayout.ActualY、IActualLayout.ActualWidth、IActualLayout.ActualHeight) と、実際の軸の値 (IAxis.ActualMaxValue、IAxis.ActualMinValue、IAxis.ActualMajorUnit、IAxis.ActualMinorUnit、IAxis.ActualMajorUnitScale、IAxis.ActualMinorUnitScale) が含まれます。
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
    
    // プレゼンテーションを保存
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **親チャート要素の実際の位置を計算**
Aspose.Slides for .NET は、これらのプロパティを取得するためのシンプルな API を提供します。IActualLayout のプロパティは、親チャート要素の実際の位置に関する情報を提供します。実際の値でプロパティを埋めるには、事前に IChart.ValidateChartLayout() メソッドを呼び出す必要があります。
```c#
// 空のプレゼンテーションを作成
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


## **チャートから情報を非表示にする**
このトピックでは、チャートから情報を非表示にする方法を解説します。Aspose.Slides for .NET を使用すると、**タイトル、垂直軸、水平軸** および **グリッド線** をチャートから非表示にできます。以下のコード例は、これらのプロパティの使用方法を示しています。
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //チャートのタイトルを非表示にする
    chart.HasTitle = false;

    ///値軸を非表示にする
    chart.Axes.VerticalAxis.IsVisible = false;

    //カテゴリ軸の表示
    chart.Axes.HorizontalAxis.IsVisible = false;

    //凡例を非表示にする
    chart.HasLegend = false;

    //主要グリッド線を非表示にする
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

    //系列の線の色を設定する
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**外部の Excel ワークブックをデータ ソースとして使用できますか？また、再計算にどのように影響しますか？**

はい。チャートは外部ワークブックを参照できます。外部ソースに接続または更新すると、数式と値はそのワークブックから取得され、チャートは開く/編集する操作中に更新を反映します。API を使用すると、[外部ワークブックを指定](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) パスを設定し、リンクされたデータを管理できます。

**自分で回帰分析を実装せずにトレンドラインを計算・表示できますか？**

はい。[トレンドライン](/slides/ja/net/trend-line/)（線形、指数など）は Aspose.Slides によって追加・更新され、パラメータはシリーズ データから自動的に再計算されるため、独自の計算を実装する必要はありません。

**プレゼンテーションに外部リンクを持つ複数のチャートがある場合、各チャートが計算値に使用するワークブックを制御できますか？**

はい。各チャートはそれぞれの[外部ワークブック](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) を指すことができ、他のチャートとは独立してチャートごとに外部ワークブックを作成または置き換えることも可能です。