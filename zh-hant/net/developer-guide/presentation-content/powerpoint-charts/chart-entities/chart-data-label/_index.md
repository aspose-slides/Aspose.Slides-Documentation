---
title: 在 .NET 中管理簡報的圖表資料標籤
linktitle: 資料標籤
type: docs
url: /zh-hant/net/chart-data-label/
keywords:
- 圖表
- 資料標籤
- 資料精度
- 百分比
- 標籤距離
- 標籤位置
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習使用 Aspose.Slides for .NET 在 PowerPoint 簡報中新增與格式化圖表資料標籤，以製作更具吸引力的投影片。"
---
## **簡介**

資料標籤顯示圖表系列與個別資料點的資訊，協助讀者辨識數值並了解圖表。本篇說明如何格式化數值、顯示百分比、讀取標籤文字、調整類別軸標籤間距，以及設定圓餅圖標籤位置。

## **在圖表資料標籤中設定資料精度**

使用 [NumberFormatOfValues](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/numberformatofvalues/) 來格式化系列值。此範例建立一個具有預設資料的折線圖，顯示其資料表，並為第一個系列啟用數值標籤。格式 `#,##0.00` 會顯示千位分隔符號和兩位小數，且不會變更底層的值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **將百分比作為標籤顯示**

對於堆疊柱狀圖，將每個值計算為其類別總和的百分比，並將文字指派給 [TextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)。此範例使用預設圖表資料，並以 8 點字型顯示兩位小數的百分比。總和為零的類別會被略過，以避免除以零。若圖表資料變更，請重新計算自訂標籤文字。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **在圖表資料標籤中設定百分號**

當值以分數方式儲存時，使用 [NumberFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatalabelformat/numberformat/) 來顯示百分比。將 [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) 設為 `false`，即可讓標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊柱狀圖，紅色與藍色系列跨四個類別。每對值的總和為 1。標籤格式 `0.0%` 會將 0.30 顯示為 30.0%，而垂直軸使用兩位小數。兩個系列皆使用白色 10 點的標籤文字。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **讀取資料標籤的實際文字**

使用 [GetActualLabelText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatalabel/getactuallabeltext/) 取得資料標籤設定所產生的文字。這在為報告提取標籤、搜尋簡報內容或驗證產生的圖表時相當有用。在下方範例中，預設的 [資料標籤格式](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatalabelformat/) 結合了每個類別名稱、系列名稱與數值。其中一個點將其數值格式化為百分比，另一個則使用來自 [TextFrameForOverriding](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) 的自訂文字。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

儲存在資料點中的數字仍為 `0.75`，即使其標籤顯示 `75%` 並包含類別與系列名稱。自訂文字會取代產生的標籤文字。無論哪種情況，[GetActualLabelText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatalabel/getactuallabeltext/) 都會回傳最終的標籤字串。若只想提取可見標籤，請如上所示單獨檢查 [IsVisible](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatalabel/isvisible/)。

## **設定標籤與坐標軸的距離**

使用 [LabelOffset](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/iaxis/labeloffset/) 來控制類別軸標籤與坐標軸之間的距離。該值為軸標籤最大字型大小的百分比。此範例建立一個群組柱狀圖，並將水平軸標籤偏移設為 500。此設定會影響類別軸標籤，而不是附加於單一資料點的標籤。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **調整標籤位置**

在圓餅圖上，調整資料標籤位置以改善間距並為指引線留出空間。

此範例顯示第一個資料點的數值，將其標籤放置在切片外側，並調整其 [X](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ilayoutable/x/) 與 [Y](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ilayoutable/y/) 偏移。這些偏移分別相對於圖表的寬度與高度。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![調整資料標籤位置的圓餅圖](pie-chart-adjusted-label.png)

## **常見問題**

**如何防止在密集圖表中資料標籤重疊？**

結合自動標籤放置、指引線與縮小字型；必要時，可隱藏某些欄位（例如類別），或僅對極端值或關鍵點顯示標籤。

**如何僅對零、負值或空值停用標籤？**

在啟用標籤前先篩選資料點，並根據既定規則對 0、負值或缺失值關閉顯示。

**如何在匯出為 PDF/影像時確保標籤樣式一致？**

明確設定字型家族與大小，並確認渲染環境中存在該字型，以避免回退。