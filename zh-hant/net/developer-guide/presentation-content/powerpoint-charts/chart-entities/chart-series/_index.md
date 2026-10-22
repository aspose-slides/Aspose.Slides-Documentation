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
description: "了解如何使用 C# 在簡報中管理圖表系列、資料點、工作簿儲存格、格式設定、重疊、間隙寬度與負值。"
---
## **概觀**

圖表可以將繪製的數值儲存在工作簿儲存格中，或直接作為數值文字常數。**[IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/)** 代表一組相關的數值，而每個 **[IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/)** 代表該系列中的一個點。**[IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/)** 物件提供系列共用的標籤或分組值。 在使用預設資料建立的圖表中，系列名稱、類別和點的數值皆使用來自圖表工作簿的 **[IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/)** 物件。

對於一般的類別圖表，預設工作簿使用第 0 列作為系列名稱，第 0 欄作為類別名稱，剩餘儲存格則存放系列值。傳遞給 **[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/)** 的工作表、列和欄索引均為零基礎。此配置在建立使用預設資料的圖表時很有用，但不要假設每個現有圖表都使用此布局。對於已載入的簡報，請在變更工作簿值之前，先檢查系列、類別和資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 **[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)**，為整個系列的所有點提供預設外觀。
- 資料點層級設定，例如 **[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)**，會覆寫該點的系列外觀。
- 群組設定套用於屬於同一 **[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/)** 的相容系列。需要設定重疊或間隙寬度等選項時，請透過 **[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/)** 取得群組。

當未明確設定點或系列的填色時，圖表樣式與主題會決定自動外觀。當同時存在系列與點的格式設定時，點的格式設定優先。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **使用數值文字常數設定系列值**

當系列值來自應用程式資料或計算且不需要工作表儲存格參照時，使用數值文字常數。將 **[DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/)** 設為 **[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/)**，再透過 **[AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/)** 為每個點的 **[Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/)** 指定值。

集合設定控制該系列所有點值的來源類型。每個點的 **[Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/)** 會回報所選類型；請透過集合設定變更它。使用 `Worksheet` 時，使用 **[AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/)** 取得參照的儲存格。使用 `DoubleLiterals` 時，使用 `AsLiteralDouble` 直接讀寫數字。

以下範例建立一個具有預設系列與類別的柱狀圖，然後為其第一個系列的現有點指派計算得到的 10、20 等值。接著儲存簡報、重新開啟，並列印儲存的值。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

點值的來源類型與 **[IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/)** 不同，後者用於識別圖表的內部或外部工作簿配置。使用數值文字常數本身不會移除嵌入的工作簿。在此範例中，工作簿仍保留供類別標籤、系列名稱以及其他系列使用。請參閱 [圖表工作簿](/slides/zh-hant/net/chart-workbook/) 了解工作簿管理。

對於散佈圖與氣泡圖，設定 **[DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/)** 與 **[DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/)** 以選擇 **[XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/)** 與 **[YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/)** 的來源。氣泡圖亦使用 **[DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/)** 來設定 **[BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/)**。在透過相應值的 `AsLiteralDouble` 指定數字之前，將每個適用的來源設為 `DoubleLiterals`。

## **設定圖表系列的重疊比例**

**[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/)** 回報 2D 圖表中長條或柱形的重疊程度，範圍為 -100 至 100 百分比。它是父系列群組設定的唯讀投射。將 **[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/)** 設為新值，即可更新該群組中所有相容系列。此選項僅適用於顯示分組長條或柱形的圖表類型；對組合圖中不相關的系列群組不產生影響。

以下範例設定包含第一個系列的群組的重疊比例：

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// 新圖表包含範例系列、類別和數值。
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

結果：

![The series overlap](series_overlap.png)

## **變更系列填色**

使用 **[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)** 為整個系列設定預設填色。若某個點已設定明確的填色，則其 **[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)** 會覆寫系列的填色。

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

![The color of the series](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料工作簿中，通常會顯示於圖例。對於預設建立的聚集柱狀圖，儲存格 B1 位於第 0 列第 1 欄，存放第一個系列的名稱。以下範例中的命名常數將此結構明確化：

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

您也可以直接更新 **[IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/)** 已參照的儲存格。此方式避免假設既有圖表中使用特定的列與欄：

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

### **建立由多個儲存格組成的系列名稱**

當產品名稱與報告期間分別儲存在不同工作簿儲存格時，複合系列名稱非常有用。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 結合為單一系列名稱，同時保留兩個部分與來源儲存格的連結。

使用 **[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/)** 取得名稱範圍，然後將該集合傳遞給 **[IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/)**。`skipHiddenCells` 參數控制是否包含隱藏儲存格：`true` 會排除，`false` 會包含。本範例使用 `false` 以包含名稱範圍內的所有儲存格。

以下範例建立一個包含一個系列與兩個資料點的簡報。儲存格 B1:C1 只供應系列名稱；A2:A3 提供類別標籤；B2:B3 提供數值。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// 這兩個儲存格提供系列名稱。
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// 分別的儲存格提供類別和數值資料點。
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

產生的系列名稱為 `Product A 2026`，兩個儲存格值之間有空格。圖例會將其顯示為單一條目。下圖為從已儲存的簡報渲染的圖表：

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **取得自動系列填色**

**[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/)** 會回傳依系列索引與圖表樣式計算出的顏色。此顏色在系列填色未明確定義時使用。呼叫此方法僅會讀取計算出的顏色，不會新增填色。

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

預設圖表樣式的輸出範例：

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

實際顏色會因圖表樣式與主題而異。

## **為圖表系列設定負值倒轉填色**

對於長條、柱形與氣泡系列，**[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)** 可在負值時顯示不同的填色。先將系列的常規填色設為實心，啟用倒轉，然後透過 **[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)** 指定負值的顏色。負數在工作簿中保持不變，僅改變其顯示顏色。

以下範例以一個系列取代預設圖表資料。工作表第 0 列放置系列名稱，第 0 欄放置類別名稱，第 1 欄放置數值：

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

您也可以透過 **[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)** 為單一點啟用倒轉。以下範例在系列層面停用倒轉，僅為選取的點啟用，同時為該點指派負值以顯示效果：

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

若要使某一點為空而不移除其他點，請將其對應的工作簿儲存格設為 `null`。對於柱狀圖，繪製的數值可透過 **[IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/)** 取得。資料點仍保留在相同類別位置，但圖表會根據其空白值設定將該值視為空白。

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

散佈圖使用獨立的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除您欲移除的值所對應的儲存格。若只想保留其他點，請勿呼叫 **[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)**，因為該方法會移除該系列的全部資料點。

## **控制空儲存格的顯示方式**

隱藏的儲存格即使包含值，也屬於與空儲存格不同的情況。若要包含或排除隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空的工作簿儲存格表示缺失資料；儲存格內含 `0` 表示已知的數值。將 **[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/)** 設為 `null` 即可使儲存格為空。數值零不會受到空儲存格設定的影響，仍然是零。

使用 **[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)** 來選擇圖表如何顯示空儲存格。此設定套用於整個圖表，會改變空白的繪製方式，而不會把空儲存格以零或插補值填入。

以下自足範例建立一個具有單一系列的折線圖，清除第 3 天的值，並以每種模式分別儲存同一圖表。此範例不需要輸入檔案。**[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)** 使用工作表 0，欄 0 為類別標籤，欄 1 為數值；列 0 保存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

每個輸出檔案在儲存前皆已設定對應模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。若只需一個版本，請先指定所需模式，然後只儲存一次簡報，而非對所有模式迭代。

下表比較三個檔案的相同資料。第 3 天在所有工作簿中皆為空：

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

可見效果取決於圖表類型。折線圖可清楚比較三種模式。長條與柱形圖因缺少連接線，`Span` 無法產生上圖所示的連接段落；缺失的柱形與零高度的柱形也可能看起來相似。類似地，僅顯示標記的散佈圖也沒有連接線。不要期望每種圖表類型皆有三種明顯結果；請依實際使用的圖表類型檢視輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰長條或柱形叢集之間的空間，表示為長條或柱形寬度的百分比。與重疊比例類似，它屬於父系列群組而非單一系列。對群組一次設定 **[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)** 即可。較大的數值會在叢集之間產生更大的空間，較小的數值則使叢集更為緊密。

以下範例變更間隙寬度，並僅儲存最終的簡報：

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

所有由 **[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)** 列舉的圖表類型都使用圖表資料，但其系列的值結構與設定並不完全相同。例如，類別圖使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用與系列類型相符的資料點建立方法。重疊與間隙寬度等選項僅適用於相容的長條或柱形群組。

**什麼是圖表系列群組？**

**[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/)** 包含共享群組層級繪製設定的相容系列。組合圖可能包含多個群組，因此透過單一系列取得的群組設定不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是的。預設情況下，**[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/)** 會建立範例系列、類別與值。您可以編輯這些儲存格，或在加入完全自訂的資料集前先清除系列與類別集合。亦可使用不含預設資料的重載。

**圖表物件如何與工作簿儲存格連結？**

系列名稱、類別標籤與資料點值皆參照 **[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)** 中的儲存格。變更參照的儲存格會更新對應的圖表元素。建立自訂資料時，請保持類別列與系列值列對齊，以確保每個點繪製於正確的類別之下。

**如何只清除單一點而不是整個系列？**

將相關的值儲存格設為 `null`，即可保留該點的類別位置作為空白點。只有在您確實想移除該系列所有點時，才使用 **[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)**。如果同時移除類別，請確保所有系列的值仍與類別集合保持對齊。

**空白點會如何顯示？**

結果取決於圖表類型與 **[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)** 的設定。支援的圖表可將空白顯示為間隙、零值或連接相鄰點。請選擇與簡報中缺失資料意義相符的設定。完整範例與視覺比較請參閱 [控制空儲存格的顯示方式](#control-the-display-of-empty-cells)。

**負值的格式如何設定？**

對於支援的長條、柱形與氣泡系列，啟用 **[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)** 並設定 **[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)**。您也可以使用 **[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/)** 為單一點覆寫此行為。這些屬性影響格式，而不會改變儲存的數值。

**當系列與點同時設定格式時，哪一個會生效？**

明確的資料點格式會優先於系列格式，僅對該點生效。其他點仍使用明確的系列格式，或在未定義系列格式時使用自動圖表樣式與主題。群組屬性如重疊與間隙寬度屬於版面配置，並非點層級的格式覆寫。

**圖表可包含多少系列有上限嗎？**

Aspose.Slides 本身沒有固定的系列數上限。實務上，簡報檔案限制、可用記憶體、渲染時間以及圖表可讀性會決定實際可用的上限。

**當柱形或長條過於靠近或過於分散時該如何調整？**

在相應的父系列群組上設定 **[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)**。將數值增大會擴大叢集之間的間距，減小則使叢集更為緊密。