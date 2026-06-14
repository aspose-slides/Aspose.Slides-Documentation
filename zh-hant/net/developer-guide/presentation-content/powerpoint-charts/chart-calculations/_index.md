---
title: 在 .NET 中優化簡報的圖表計算
linktitle: 圖表計算
type: docs
weight: 50
url: /zh-hant/net/chart-calculations/
keywords:
- 圖表計算
- 圖表元素
- 元素位置
- 真實位置
- 子元素
- 父元素
- 圖表值
- 真實值
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解在 Aspose.Slides for .NET 中對 PPT 和 PPTX 進行圖表計算、資料更新與精確度控制，並提供實用的 C# 程式碼範例。"
---
## **概觀**

Aspose.Slides 提供用於在簡報中處理圖表計算與版面配置資料的 API。本篇文章說明如何取得圖表元素的實際值，包括實作 `IActualLayout` 的元素之真實位置與大小，以及圖表座標軸的實際值。亦說明這些值會在圖表版面配置驗證之後才會填入。

此外，本文還示範如何取得父圖表元素的實際位置，以及如何隱藏圖表元件（如標題、座標軸、圖例與格線）。透過這些範例，您可以程式化檢視 PowerPoint 簡報中圖表的版面資訊，並控制圖表元素的可見性。

## **計算圖表元素的實際值**
Aspose.Slides for .NET 提供簡易的 API 以取得這些屬性。這將協助您 **計算圖表元素的實際值**。實際值包括實作 IActualLayout 介面的元素之位置（IActualLayout.ActualX、IActualLayout.ActualY、IActualLayout.ActualWidth、IActualLayout.ActualHeight）以及實際座標軸值（IAxis.ActualMaxValue、IAxis.ActualMinValue、IAxis.ActualMajorUnit、IAxis.ActualMinorUnit、IAxis.ActualMajorUnitScale、IAxis.ActualMinorUnitScale）。

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// 儲存簡報
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **計算父圖表元素的實際位置**
Aspose.Slides for .NET 提供簡易的 API 以取得這些屬性。IActualLayout 的屬性提供父圖表元素的實際位置資訊。必須先呼叫 `IChart.ValidateChartLayout()` 方法，以在屬性中填入實際值。

```c#
 // 建立空白簡報
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

## **隱藏圖表元素**
本主題說明如何隱藏圖表中的資訊。使用 Aspose.Slides for .NET，您可以隱藏圖表的 **標題、垂直座標軸、水平座標軸** 與 **格線**。以下程式碼範例示範如何使用這些屬性。

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //隱藏圖表標題
    chart.HasTitle = false;

    ///隱藏數值座標軸
    chart.Axes.VerticalAxis.IsVisible = false;

    //類別座標軸可見性
    chart.Axes.HorizontalAxis.IsVisible = false;

    //隱藏圖例
    chart.HasLegend = false;

    //隱藏主要格線
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

    //設定系列線條顏色
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**外部 Excel 活頁簿可以作為資料來源嗎？這會如何影響重新計算？**

是。圖表可以參照外部活頁簿：當您連接或重新整理外部來源時，公式與值會從該活頁簿取得，圖表在開啟/編輯時會反映更新。API 讓您[指定外部活頁簿](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/setexternalworkbook/)路徑並管理已連結的資料。

**我能在不自行實作回歸的情況下計算並顯示趨勢線嗎？**

是。[趨勢線](/slides/zh-hant/net/trend-line/)（線性、指數等）由 Aspose.Slides 自動新增與更新；其參數會根據系列資料自動重新計算，您不必自行實作計算。

**如果簡報中有多個圖表帶有外部連結，我可以控制每個圖表使用哪一本活頁簿來計算值嗎？**

是。每個圖表都可以指向自己的[外部活頁簿](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/setexternalworkbook/)，或您可以針對每個圖表獨立建立/取代外部活頁簿，而不受其他圖表影響。