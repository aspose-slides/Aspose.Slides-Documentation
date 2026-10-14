---
title: 在 .NET 中自訂簡報的圓餅圖
linktitle: 圓餅圖
type: docs
url: /zh-hant/net/pie-chart/
keywords:
- 圓餅圖
- 管理圖表
- 自訂圖表
- 圖表選項
- 圖表設定
- 情節選項
- 切片顏色
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 建立並自訂圓餅圖。設定次要情節、顯示資料標籤，並在 PowerPoint 中套用自動切片顏色。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圓餅圖。它展示了如何為「Pie of Pie」和「Bar of Pie」圖表設定次要情節選項，並說明如何為標準圓餅圖啟用自動切片著色。

範例聚焦於圖表自訂工作，例如將圖表加入投影片、調整系列與標籤設定、以自訂類別與數值取代預設圖表資料，並儲存更新後的簡報。

## **Pie of Pie 與 Bar of Pie 圖表的次要情節選項**

Aspose.Slides for .NET 支援 Pie of Pie 與 Bar of Pie 圖表的次要情節選項。這些選項可控制次要情節的大小以及資料點在兩個情節之間的分割方式。

以下範例在新簡報中建立一個 Pie of Pie 圖表，並將資料點值顯示為標籤。[SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) 屬性將次要情節大小設定為主情節的 149%。[PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) 選擇以百分比方式分割，且 [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) 將門檻設定為 53%。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// 顯示值並設定次要情節。
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **選取次要情節的類別**

當您希望將特定類別在次要情節中分組，而不考慮其百分比值時，可使用自訂分割。例如，銷售報告可能會將 Online 和 Events 合併顯示，以便讀者比較這兩個渠道，即使它們分別佔總銷售的 35% 與 10%。

將 [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) 設為 [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) 並透過 [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/) 來選取資料點。集合的 [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) 方法接受系列中的零基索引或資料點物件。在此範例中，索引 1 選取 Online，索引 3 的點選取 Events。Partners 也暫時加入，之後再使用 [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/) 移除。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// 用渠道的銷售資料取代預設資料。
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// 以零基索引選取 Online，並以資料點物件選取 Events。
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// 從選取中排除 Partners，但不刪除其來源資料。
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) 與 Events (10) 以獨立切片出現在次要情節中。於主情節中，它們以一個合併切片顯示，值為 45，並與 Retail (40) 與 Partners (15) 共同呈現。從自訂選取中移除 Partners 只會使其保留在主情節中；不會從圖表的來源資料中刪除該類別或其值。

以下圖片顯示了在 PowerPoint 中儲存的簡報：

![次要情節中包含 Online 與 Events，主情節中其合併值為 45 的 Pie of Pie 圖表](pie_of_pie_custom.png)

## **設定自動圓餅圖切片顏色**

Aspose.Slides for .NET 可以自動為圓餅圖切片指派不同的顏色。以下範例建立一個帶置中標題的圓餅圖，並以三個季度類別及其數值取代預設資料。[ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) 屬性將值 20、50 與 30 顯示為標籤，而 [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) 則為每個切片啟用不同顏色。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// 新增置中圖表標題。
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// 使用第一個工作表取代預設資料。
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// 顯示數值並為切片指定不同顏色。
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **常見問題**

**Are the Pie of Pie and Bar of Pie variations supported?**

是的，函式庫 [支援](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 圓餅圖的次要情節，包括 Pie of Pie 與 Bar of Pie 類型。

**Can I export just the chart as an image (for example, PNG)?**

是的，您可以 [匯出圖表本身為圖像](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)（例如 PNG），而不必匯出整個簡報。