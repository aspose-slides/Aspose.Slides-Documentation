---
title: 在 .NET 簡報中管理圖表資料標籤
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
description: "了解如何在 PowerPoint 簡報中使用 Aspose.Slides for .NET 新增與格式化圖表資料標籤，以打造更具吸引力的投影片。"
---
## **簡介**

資料標籤顯示圖表系列和單一資料點的資訊，協助讀者辨識數值並了解圖表。本文說明如何格式化數值、顯示百分比、讀取標籤文字、在軸最大值之外控制標籤、調整類別軸標籤間距，以及設定圓餅圖標籤的位置。

## **計算可見的資料標籤**

使用 [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) 來檢查在發佈簡報之前有多少資料標籤被啟用顯示。不同於 [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/) 會回傳集合中標籤的總數，它會考慮系列的預設值和個別標籤設定。

此範例建立一個具有一個系列和三個資料點的直條圖。它存取該系列的 [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/) 集合，並在設定變更時列印可見計數：**0, 3, 2, 3**。總計數仍為 **3**。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesCell = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

for (int i = 0; i < 3; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var labels = series.Labels;
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // 總計: 3; 可見: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // 可見: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // 可見: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // 可見: 3
```

系列的 [DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) 提供預設設定。啟用 [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) 會為所有三個標籤顯示值。透過單一標籤的 [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) 將其設定為 `false` 會覆寫該標籤的設定。啟用 [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) 使該標籤再次被計為可見，即使其值仍被隱藏。

可見計數僅反映可視性設定，並不衡量標籤是否重疊、被裁切或在渲染的圖表中是否易於閱讀。

## **設定圖表資料標籤的精度**

使用 [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) 來格式化系列值。此範例建立一個具有預設資料的折線圖，顯示其資料表，並為第一個系列啟用值標籤。格式 `#,##0.00` 會顯示千位分隔符號和兩位小數，卻不會更改底層值。

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

若要格式化圖表內嵌工作簿中的數值儲存格，請參閱 [Set Custom Number Formats for Workbook Cells](/slides/zh-hant/net/chart-workbook/#set-custom-number-formats-for-workbook-cells)。該範例亦顯示值標籤遵循來源儲存格的格式，同時保留儲存的數值。

## **以百分比顯示為標籤**

對於堆疊直條圖，將每個值計算為其類別總和的百分比，並將文字指派給 [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)。此範例使用預設圖表資料，並以 8 點字型顯示兩位小數的百分比。總和為零的類別會被略過，以避免除以零。如圖表資料變更，請重新計算自訂標籤文字。

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

當值以分數儲存時，使用 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) 來顯示百分比。將 [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) 設為 `false` 即可讓標籤格式獨立於來源儲存格。

此範例建立一個 100% 堆疊直條圖，包含紅色和藍色系列，分布在四個類別。每對值的總和皆為 1。標籤格式 `0.0%` 會將 0.30 顯示為 30.0%，而垂直軸則使用兩位小數。兩個系列皆使用白色、10 點的標籤文字。

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

使用 [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) 取得資料標籤設定所產生的文字。這在為報告抽取標籤、搜尋簡報內容或驗證產生的圖表時很有用。在下方範例中，預設的 [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) 結合每個類別名稱、系列名稱與值。某個資料點將其值格式化為百分比，另一個則使用來自 [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) 的自訂文字。

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

資料點中儲存的數字仍為 `0.75`，即使其標籤顯示 `75%` 並附帶類別與系列名稱。自訂文字會取代產生的標籤文字。[GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) 無論哪種情況皆會回傳最終的標籤字串。若只想抽取可見的標籤，請如上所示單獨檢查 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/)。

## **在軸最大值之外控制資料標籤**

當手動限制軸範圍時，某些資料點可能超過其最大值。使用 [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) 來控制是否顯示其資料標籤。此設定會變更標籤的可見性，卻不會改變軸範圍或底層資料值。

以下範例建立一個 2D 簇狀直條圖，值為 60 與 120。它在垂直軸上將 [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) 設為 `false`，並將 [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) 設為 100。第一張投影片允許標籤超過最大值；其副本則停用此功能。兩張投影片都儲存為 `DataLabelsOverMaximum.pptx`。

使用 [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) 來啟用值標籤。圖表層級的設定不會自行啟用值顯示，也不會覆寫個別標籤已停用的值顯示。此範例為整個系列啟用值，並使用 [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) 將標籤置於每個直條的外側端點。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

以下圖像顯示 Microsoft PowerPoint 渲染的已儲存投影片。設定為 `true` 時，標籤 **120** 會在上界可見；設定為 `false` 時則隱藏。標籤 **60** 仍保持可見，軸最大值仍為 **100**，且第二個資料點在兩種情況下皆為 **120**。

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint 圖表顯示軸最大值為 100 時的值標籤 120](data-labels-over-maximum-true.png) | ![PowerPoint 圖表在軸最大值為 100 時隱藏值標籤 120](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
此範例使用具有值軸的 2D 直條圖。不具備值軸的圖表（例如圓餅圖和環形圖）沒有此類軸最大值可供限制。
{{% /alert %}}

## **設定標籤與軸之間的距離**

使用 [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) 來控制類別軸標籤與軸之間的距離。該值為軸標籤最大字型大小的百分比。此範例建立一個簇狀直條圖，並將水平軸標籤偏移設定為 500。此設定會影響類別軸標籤，而不是附加於單一資料點的標籤。

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

在圓餅圖上，調整資料標籤位置以改善間距並為引線騰出空間。

此範例顯示第一個資料點的值，將其標籤放置於切片外側，並調整其 [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) 與 [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) 偏移。這些偏移分別相對於圖表的寬度與高度。

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

## **格式化引線**

當圓餅圖標籤位於切片外側時，引線可協助讀者將每個值對應到正確的切片。使用對比色且稍微較粗的線條可以讓這些連接更易於辨識，而加入透明度與虛線樣式則可使線條在視覺上不突兀。

使用 [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) 在系列的資料標籤集合層級格式化引線。`series.Labels.LeaderLinesFormat.Line` 中的設定會套用至整個集合，而非單一標籤。

此範例建立一個具有預設資料的圓餅圖，將值顯示於切片外部，並啟用 [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/)。它使用 [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) 與 [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) 偏移（以圖表寬度與高度的比例表示）將兩個標籤移離切片更遠。此範例不需要輸入簡報。

線條的 [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) 設為實心藍色，alpha 值為 191（在 255 之中），約為 25% 透明度。[Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) 將粗細設定為 2 點，[DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) 則使線條呈虛線。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// 將兩個標籤從其切片向外移動更遠。
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

啟用引線並不保證每個標籤都會出現線條。可見性取決於標籤的放置方式與圖表的版面配置。在此範例中，兩個被移動的標籤具有可見的引線；靠近切片的標籤則不需要引線。

下圖顯示以 Aspose.Slides 呈現的已儲存 `FormattedLeaderLines.pptx`：

![圓餅圖，使用藍色半透明虛線引線將兩個外部標籤連接至其切片](formatted-leader-lines.png)

## **在直條圖上方加入多列資料標籤**

此範例建立一個直條圖，於繪圖區上方放置兩列資料標籤。系列 A 顯示可見的直條，而系列 B 與系列 C 提供額外的標籤。透過移除填色與輪廓將它們的直條隱藏。[Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) 屬性將三個系列對齊於相同的類別中心。

[PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) 設定保留標籤列的空間。於 [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) 計算預設位置後，[X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) 與 [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) 保持水平對齊，並套用垂直偏移以將標籤排列成兩列。這些數字仍是連結至系列值的資料標籤；僅列標題為獨立的文字圖形。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // 隱藏 B 與 C 的柱狀，但保留它們的資料標籤。
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// 將所有三個系列對齊至相同的類別中心。
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// 在此緊湊範例中使用較少的格線。
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// 在繪圖區上方保留空間以放置兩列資料標籤。
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // 保留預設的水平位置。Y 是相對於
        // 預設標籤位置的偏移，以圖表高度的比例表示。
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // 只有列標題是獨立的文字圖形。
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![直條圖，繪圖區上方有兩列資料標籤](multiple-rows-of-labels.png)

## **變更資料標籤形狀**

Aspose.Slides for .NET 26.11 新增了 [IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) 可於單一標籤設定，及 [IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) 可於系列中所有現有標籤設定。這些會變更標籤的形狀，而非其資料點標記。若需設定獨立的標註，請參閱 [Data Label Callouts](/slides/zh-hant/net/callout/)。

集合指派會更新現有標籤，因此請在集合設定之 **後** 再套用個別覆寫。此完整範例需要 [Aspose.Slides for .NET](/slides/zh-hant/net/installation/) 26.11 或更新版本。它會建立可見的值標籤，為第一個系列選取橢圓形，然後將其第一個標籤改為矩形。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var labels = chart.ChartData.Series[0].Labels;
labels.DefaultDataLabelFormat.ShowValue = true;
labels.DefaultLabelShapeType = ShapeType.Ellipse;
labels[0].LabelShapeType = ShapeType.Rectangle;

foreach (var label in labels)
{
    var format = label.DataLabelFormat.Format;
    format.Fill.FillType = FillType.Solid;
    format.Fill.SolidFillColor.Color = Color.LightYellow;
    format.Line.FillFormat.FillType = FillType.Solid;
    format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
}

presentation.Save("label-shapes.pptx", SaveFormat.Pptx);

// 重設目前所有標籤的明確形狀選擇。
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

再次指派集合形狀也會取代先前的個別形狀選擇。[NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) 會清除明確的形狀選取；它不會隱藏標籤或清除其他格式設定。請在填充系列之後再設定所需形狀，而不是假設之後新增的點會繼承先前的指派。此處使用 Rectangle 與 Ellipse；在選擇其他形狀類型時，請檢查渲染結果。

## **常見問題**

**如何防止在密集圖表中資料標籤重疊？**  
結合自動標籤放置、引線與縮小字型；如有需要，可隱藏某些欄位（例如類別），或僅為極端值或關鍵點顯示標籤。

**如何僅對零、負值或空值停用標籤？**  
在啟用標籤之前先篩選資料點，並依據定義的規則關閉 0、負值或缺失值的顯示。

**如何在匯出為 PDF/影像時確保標籤樣式一致？**  
明確設定字型族與大小，並確認該字型在渲染環境中可用，以避免回退。