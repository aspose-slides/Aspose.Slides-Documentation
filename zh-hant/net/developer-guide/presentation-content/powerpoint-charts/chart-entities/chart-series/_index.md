---
title: 在 .NET 中管理簡報的圖表資料系列
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
description: "了解如何使用 C# 在簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度以及負值。"
---
## **概覽**

圖表將其繪製的資料儲存在圖表資料工作簿中。 [IChartSeries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/) 代表一組相關的值，系列中的每個 [IChartDataPoint](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/) 參照一個或多個工作簿儲存格。 [IChartCategory](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別和資料點值會連結到 [IChartDataCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatacell/) 物件，而非僅以顯示文字保存。

對於典型的類別圖表，預設工作簿使用第 0 列儲存系列名稱，第 0 行儲存類別名稱，剩餘儲存格則存放系列值。傳遞給 [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/getcell/) 的工作表、列與欄索引皆為零基礎。此佈局在建立帶有預設資料的圖表時很有用，但不要假設每個現有圖表都使用它。對於已載入的簡報，請在變更工作簿值之前檢查系列、類別與資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [IChartSeries.Format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/format/)，提供單一系列中所有資料點的預設外觀。
- 資料點層級設定，例如 [IChartDataPoint.Format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/format/)，會覆寫該系列的外觀以套用於單一資料點。
- 群組設定套用於屬於相同 [IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/) 的相容系列。需要設定重疊或間隙寬度等選項時，請透過 [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/parentseriesgroup/) 取得該群組。

當未設定明確的資料點或系列填色時，圖表樣式與佈景主題會決定自動外觀。當系列與資料點格式同時存在時，資料點的格式會優先套用於該資料點。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[IChartSeries.Overlap](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/overlap/) 會回報 2D 圖表中長條或柱狀的重疊程度，範圍為 -100% 到 100%。它是父系列群組設定的唯讀投影。設定 [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/overlap/) 可更新該群組中所有相容的系列。此選項僅適用於顯示群組長條或柱狀的圖表類型；不會影響組合圖表中不相關的系列群組。

以下範例設定包含第一個系列的群組的重疊：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 新增的圖表包含示範系列、類別和數值。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

結果：

![The series overlap](series_overlap.png)

## **變更系列填色**

使用 [IChartSeries.Format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/format/) 來設定整個系列的預設填色。如果資料點已具備明確的填色，則其 [IChartDataPoint.Format](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/format/) 會覆寫該系列的填色。

以下範例將第一個系列套用為純藍色填色：

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

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會顯示在圖例中。在預設的叢集柱狀圖工作簿中，儲存格 B1 位於第 0 列第 1 欄，內含第一個系列的名稱。以下範例中的具名常數明確說明了此結構：

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

您也可以直接更新 [IChartSeries.Name](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/name/) 已參照的儲存格。此做法避免在既有圖表中假設特定的列與欄：

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

![The series name](series_name.png)

## **取得自動系列填色**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) 會回傳依系列索引與圖表樣式計算出的顏色。這是系列填色未明確定義時所使用的顏色。呼叫此方法只會讀取計算出的顏色，並不會指派新的填色。

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

確切的顏色會根據圖表樣式與佈景主題而異。

## **為圖表系列設定負值反轉填色**

對於長條、柱狀與氣泡系列，可使用 [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/invertifnegative/) 以不同的填色顯示負值。將常規系列填色設定為實心，啟用反轉，並透過 [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) 指定負值的顏色。負數在工作簿中仍保持不變，只有顯示顏色會改變。

以下範例以單一系列取代預設圖表資料。工作表第 0 列儲存系列名稱，第 0 欄儲存類別名稱，第 1 欄儲存值：

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

![The inverted solid fill color](inverted_solid_fill_color.png)

您也可以對單一資料點啟用反轉，方法是使用 [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)。以下範例將系列的反轉關閉，僅為選取的資料點啟用，並為該點指定負值以便觀察效果：

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

若要讓某一資料點變為空白而不移除其他點，請將其對應的工作簿儲存格設為 `null`。對於柱狀圖而言，繪製的值可透過 [IChartDataPoint.YValue](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/yvalue/) 取得。資料點仍保留在相同的類別位置，但圖表會根據圖表的空白值設定將其視為空白。

以下範例僅清除第一個系列的第二個資料點：

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

散佈圖使用獨立的 X 與 Y 儲存格，氣泡圖還會使用大小儲存格。僅清除您想移除的值所在的儲存格。若只想保留其他資料點，請勿呼叫 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapointcollection/clear/)，因為該方法會移除集合中的所有資料點。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱狀叢集之間的間距，以長條或柱狀寬度的百分比表示。與重疊相同，它屬於父系列群組而非單一系列。對群組設定一次 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) 即可。較大的值會在叢集之間產生更多空間，較小的值則使叢集更緊密。

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

![The gap width](gap_width.png)

## **常見問題集**

**哪些圖表類型支援資料系列？**

所有由 [ChartType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/charttype/) 列舉表示的圖表類型皆使用圖表資料，但其系列的值結構或設定並不完全相同。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的長條或柱狀群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/) 包含共享群組層級繪圖設定的相容系列。組合圖表可以包含多個群組，因此透過某一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是的。預設情況下，[IShapeCollection.AddChart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addchart/) 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前先清除系列與類別集合。也可使用其他重載以建立不含預設資料的圖表。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤以及資料點值皆參照 [IChartDataWorkbook](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdataworkbook/) 中的儲存格。變更參照的儲存格會更新相應的圖表元素。自行建立自訂資料時，請確保類別列與系列值列對齊，使每個資料點都繪製在預期的類別下。

**如何只清除單一資料點而非整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空白點。僅在您想移除該系列所有資料點時才使用 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapointcollection/clear/)。若同時移除類別，請更新每個系列，使其值仍與類別集合保持對齊。

**空白點會如何顯示？**

顯示結果取決於圖表類型與 [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichart/displayblanksas/)。支援的圖表可以將空白顯示為間隙、零值，或連接相鄰點。請選擇符合您簡報中遺失資料意義的設定。

**負值會如何格式化？**

對於支援的長條、柱狀與氣泡系列，啟用 [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/invertifnegative/) 並設定 [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)。您亦可透過 [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) 為單一資料點覆寫此行為。這些屬性影響格式化，而非儲存的數值。

**當系列與資料點同時設定格式時，哪個會生效？**

明確的資料點格式會優先套用於該點。其他資料點仍使用明確的系列格式，或在未定義系列格式時使用自動圖表樣式與佈景主題。群組屬性（如重疊與間隙寬度）僅控制版面配置，並非資料點層級的格式覆寫。

**圖表能容納的系列數量是否有限制？**

Aspose.Slides 本身未設定固定的系列數量上限。實務上，簡報檔案的限制、可用記憶體、渲染時間以及圖表可讀性會決定實際可用的上限。

**當柱狀圖的欄位過於接近或過於分離時，應如何調整？**

對適當的父系列群組設定 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)。增加值會擴大叢集之間的間距，減少值則會使叢集更靠近。