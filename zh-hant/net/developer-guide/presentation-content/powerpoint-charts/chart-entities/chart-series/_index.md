---
title: 在 .NET 簡報中管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/net/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 類別顏色
- 系列名稱
- 資料點
- 系列間隙
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在簡報中使用 C# 管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度及負值。"
---
## **概述**

圖表將繪製的資料儲存在圖表資料工作簿中。[IChartSeries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/) 代表一組相關的值，系列中的每個[IChartDataPoint](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/) 都對應一個或多個工作表儲存格。[IChartCategory](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別與點值是連結到[IChartDataCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/) 物件，而不是僅以顯示文字儲存。

對於一般的類別圖表，預設工作簿使用第 0 列來放系列名稱，第 0 行放類別名稱，其餘儲存格填入系列值。傳遞給[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/getcell/) 的工作表、列與欄索引皆以零為基底。此布局在建立使用預設資料的圖表時很有用，但請勿假設所有現有圖表皆使用此布局。對於已載入的簡報，請在變更工作簿值之前先檢查系列、類別與資料點所參照的儲存格。

圖表設定具有三種不同的範圍：

- 系列層級設定，例如[IChartSeries.Format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/format/)，提供整個系列所有點的預設外觀。
- 資料點層級設定，例如[IChartDataPoint.Format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/format/)，會覆寫該點的系列外觀。
- 群組設定套用於屬於相同[IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/) 的相容系列。當需要設定重疊或間隙寬度等選項時，請透過[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/parentseriesgroup/) 取得群組。

當未明確設定點或系列的填色時，圖表樣式與佈景主題會決定自動外觀。若同時存在系列與點的格式設定，點的格式會優先套用於該點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[IChartSeries.Overlap](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/overlap/) 會回報 2D 圖表中長條或柱狀的重疊程度，範圍從 -100% 到 100%。它是父系列群組設定的唯讀投影。設定[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/overlap/) 即可更新該群組中所有相容的系列。此選項僅套用於顯示分組長條或柱狀的圖表類型；不會影響組合圖表中不相關的系列群組。

以下範例為包含第一個系列的群組設定重疊：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 新圖表包含示範系列、類別和數值。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

結果：

![系列重疊](series_overlap.png)

## **變更系列填色**

使用[IChartSeries.Format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/format/) 為整個系列設定預設填色。如果某個點已經有明確的填色，該點的[IChartDataPoint.Format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/format/) 會覆寫系列的填色。

以下範例為第一個系列套用實心藍色填色：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

結果：

![系列顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會顯示於圖例。對於預設建立的群組直條圖，儲存格 B1（第 0 列第 1 欄）即包含第一個系列的名稱。以下範例中的具名常數示範了此結構：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

您也可以直接更新[IChartSeries.Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/name/) 已參照的儲存格。此作法避免在現有圖表中假設特定的列與欄：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

結果：

![系列名稱](series_name.png)

## **取得自動系列填色**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) 會回傳依系列索引與圖表樣式計算出的顏色。這是未明確定義系列填色時所使用的顏色。呼叫此方法僅會讀取計算出的顏色，不會指派新的填色。

以下範例列印每個預設系列的自動顏色：

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

預設圖表樣式的範例輸出：

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

實際顏色取決於圖表樣式與佈景主題。

## **為圖表系列設定負值倒置填色**

對於長條、柱狀與氣泡系列，[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/invertifnegative/) 能在負值時使用不同的填色。將常規系列填色設定為實心、啟用倒置，並透過[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) 指定負值顏色。負數在工作簿中保持不變，僅改變顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列放系列名稱，第 0 欄放類別名稱，第 1 欄放值：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

結果：

![倒置實心填色](inverted_solid_fill_color.png)

您也可以針對單一資料點啟用倒置，使用[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)。以下範例在系列未啟用倒置的情況下，僅對選取的點啟用，並將該點設定為負值以便顯示效果：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **清除特定資料點的值**

若要讓某個點變為空白而不移除其他點，將其對應的工作簿儲存格設為 `null`。對於直條圖，繪製的值可透過[IChartDataPoint.YValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/yvalue/) 取得。資料點仍保留在相同的類別位置，但圖表會依照空白值設定將其視為空白。

以下範例僅清除第一個系列的第二個點：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除代表您欲移除之值的儲存格。若想保留其他點，請勿呼叫[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapointcollection/clear/)，因為該方法會移除系列中的所有資料點。

## **控制空白儲存格的顯示方式**

隱藏且含有值的儲存格屬於與空白儲存格不同的情況。若要包含或排除來自隱藏工作表列與欄的資料，請參閱[Include Data from Hidden Rows and Columns](/slides/zh-hant/net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空白工作簿儲存格代表遺失的資料；含有 `0` 的儲存格代表已知的數值。將[IChartDataCell.Value](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/value/) 設為 `null` 即可使儲存格變為空白。數值零無論空白儲存格設定為何，都會保持為零。

使用[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/displayblanksas/) 來選擇圖表如何顯示空白儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會把空白工作簿儲存格填成零或插值。

以下自包含範例建立一個包含單一系列的折線圖，清除第 3 天的值，並以每種模式分別儲存相同圖表。此範例不需要輸入檔案。[IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/) 使用工作表 0，第 0 欄作為類別標籤，第 1 欄作為數值；第 0 列放系列名稱。最終資料為 `10, 20, empty, 30, 40`。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

每個輸出檔案會在儲存前記錄所使用的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx` 與 `empty_cells_Span.pptx`。若只想保存單一版本，請設定所需的模式，然後只儲存一次簡報即可，無需針對所有模式迭代。

下表比較了三個檔案中的相同資料。第 3 天在工作簿中皆為空白：

![顯示空白方式的比較：Gap 在第 3 天斷開折線，Zero 將折線降至零，Span 連接第 2 天與第 4 天。](display_blanks_as.png)

可見效果取決於圖表類型。折線圖最適合比較三種模式。長條圖與柱狀圖沒有連線可跨越缺少的類別，因此 `Span` 無法產生上述的連接段落；缺少的柱狀與高度為零的柱狀看起來也很相似。類似地，僅有標記的散佈圖也沒有連線。請勿期望每種圖表類型都有三種截然不同的結果；使用前請檢查實際輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱狀群組之間的空間，以長條或柱狀寬度的百分比表示。與重疊相同，它屬於父系列群組而非單一系列。對群組一次設定[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) 即可。較大的值會在群組之間產生更多空間，較小的值則使群組更密集。

以下範例變更間隙寬度，並僅儲存最終簡報：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

結果：

![間隙寬度](gap_width.png)

## **常見問題**

**哪些圖表類型支援資料系列？**

所有由[ChartType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/charttype/) 列舉的圖表類型皆使用圖表資料，但其系列的值結構或設定並不全部相同。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外有氣泡大小。請使用與系列類型相對應的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/) 包含相容的系列，這些系列共用群組層級的繪製設定。組合圖表可以包含多個群組，因此透過某一系列取得的群組設定不會必然影響圖表中所有系列。

**新建立的圖表會包含預設資料嗎？**

會。預設情況下，[IShapeCollection.AddChart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addchart/) 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入自訂資料集之前先清除系列與類別集合。亦有可不產生預設資料的重載可供使用。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照[IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/) 中的儲存格。變更被參照的儲存格會更新對應的圖表元素。建立自訂資料時，請保持類別列與系列值列對齊，以確保每個點皆繪製在正確的類別下。

**如何只清除單一資料點而不是整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空白點。僅在欲移除該系列所有點時才使用[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapointcollection/clear/)。若同時移除類別，請更新所有系列，使其值仍與類別集合對齊。

**空白點會如何顯示？**

結果取決於圖表類型與[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/displayblanksas/)。支援的圖表可將空白顯示為間隙、零值，或連接相鄰點。請選擇符合您簡報中遺失資料意涵的設定。完整範例與視覺比較請參閱[控制空白儲存格的顯示方式](#control-the-display-of-empty-cells)。

**負值會如何格式化？**

對於受支援的長條、柱狀與氣泡系列，啟用[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/invertifnegative/) 並設定[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)。您也可以使用[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) 為單一點覆寫此行為。這些屬性影響外觀格式，並不會改變儲存的數值。

**當系列與資料點同時設定格式時，哪個會優先？**

明確的資料點格式會優先套用於該點。其他點仍會使用明確的系列格式，若系列格式未定義，則使用自動的圖表樣式與佈景主題。群組屬性如重疊與間隙寬度屬於版面配置，並非點層級的格式覆寫。

**圖表可以容納多少系列？是否有上限？**

Aspose.Slides 本身不限制系列數量。實務上，簡報檔案本身的限制、可用記憶體、渲染時間以及圖表可讀性會決定實際可容納的上限。

**當柱狀過於靠近或過於分散時應如何調整？**

對相應的父系列群組設定[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)。增加數值可擴大群組間的間距，減少數值則使群組更靠近。