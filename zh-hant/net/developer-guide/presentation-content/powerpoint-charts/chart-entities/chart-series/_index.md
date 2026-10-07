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
description: "了解如何使用 C# 在簡報中管理圖表系列、資料點、活頁簿儲存格、格式設定、重疊、間隙寬度與負值。"
---
## **概觀**

圖表將其繪製的資料儲存在圖表資料活頁簿中。 [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) 代表一組相關值，系列中的每個 [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) 指向一個或多個活頁簿儲存格。[IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) 物件提供系列共用的標籤或分組值。因此，系列名稱、類別和點的值連結到 [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) 物件，而不是僅以顯示文字儲存。

對於一般的類別圖表，預設活頁簿使用第 0 列儲存系列名稱，第 0 欄儲存類別名稱，剩餘儲存格則存放系列值。傳遞給 [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) 的工作表、列和欄索引皆為零基礎。此布局在建立帶有預設資料的圖表時很有用，但不要假設每個現有圖表都使用此布局。載入簡報時，請在變更活頁簿值之前檢查系列、類別和資料點所參照的儲存格。

圖表設定有三種不同的範圍：

- 系列層級設定，例如 [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)，為單一系列的所有資料點提供預設外觀。
- 資料點設定，例如 [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)，覆寫單一資料點的系列外觀。
- 群組設定套用於屬於相同 [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) 的相容系列。當需要設定諸如重疊或間隙寬度等選項時，請透過 [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) 取得該群組。

當未設定明確的資料點或系列填色時，圖表樣式與主題決定自動外觀。若同時存在系列與資料點的格式設定，則資料點的格式會優先於該點。

![圖表系列 PowerPoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) 報告 2D 圖表中條形或柱形的重疊程度，範圍為 -100% 到 100%。它是父系列群組設定的唯讀投影。設定 [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) 以更新該群組中所有相容的系列。此選項適用於顯示分組條形或柱形的圖表類型；對組合圖表中不相關的系列群組不產生影響。

以下範例設定包含第一個系列的群組的重疊值：

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

![系列重疊](series_overlap.png)

## **變更系列填色**

使用 [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) 為整個系列設定預設填色。如果資料點已具有明確的填色，其 [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) 設定會覆寫該點的系列填色。

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

![系列的顏色](series_color.png)

## **變更系列名稱**

系列名稱儲存在圖表資料活頁簿中，通常顯示於圖例中。在為叢集柱形圖建立的預設活頁簿中，儲存格 B1 位於第 0 列第 1 欄，包含第一個系列的名稱。以下範例中的具名常數明確說明了此結構：

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

您也可以更新已被 [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) 參照的儲存格。此方法避免在現有圖表中假設特定的列與欄：

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

### **從多個儲存格建立系列名稱**

當產品名稱與報告期間分別儲存在不同的活頁簿儲存格時，複合系列名稱相當有用。例如，您可以將 B1 中的 `Product A` 與 C1 中的 `2026` 結合成單一系列名稱，同時保持兩個部分與來源儲存格的連結。

使用 [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) 取得名稱範圍，接著將該集合傳遞給 [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/)。`skipHiddenCells` 參數控制是否包含隱藏儲存格：`true` 表示排除，`false` 表示包含。此範例使用 `false` 以納入名稱範圍內的所有儲存格。

以下範例建立一個包含一個系列與兩個資料點的簡報。儲存格 B1:C1 只提供系列名稱；A2:A3 提供類別標籤，B2:B3 提供數值。

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

// Separate cells supply the categories and numeric data points.
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

產生的系列名稱為 `Product A 2026`，兩個儲存格值之間有一個空格。圖例將其顯示為兩欄的單一項目。以下影像是從儲存的簡報中渲染的：

![具有北部與南部值且圖例中顯示複合系列名稱 Product A 2026 的柱狀圖](composite_series_name.png)

## **取得自動系列填色**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) 會回傳依系列索引與圖表樣式計算出的顏色。這是在系列填色未明確定義時使用的顏色。呼叫此方法僅讀取計算出的顏色，並不會指派新的填色。

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

實際顏色取決於圖表樣式和主題。

## **設定圖表系列的反轉填色**

對於條形、柱形和氣泡系列，[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) 可使用不同的填色顯示負值。將常規系列填色設為實心，啟用反轉，並透過 [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) 指定負值的顏色。負數在活頁簿中保持不變，僅改變其顯示顏色。

以下範例以單一系列取代預設圖表資料。工作表第 0 列包含系列名稱，第 0 欄包含類別名稱，第 1 欄包含數值：

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

![反轉實心填色](inverted_solid_fill_color.png)

您可以透過 [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) 為單一資料點啟用反轉。在以下範例中，系列的反轉被停用，僅對所選資料點啟用。該資料點亦被指定負值，以便顯示效果：

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

若要使單一資料點為空且不移除其他資料點，請將其對應的活頁簿儲存格設為 `null`。對於柱形圖，繪製的數值可透過 [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) 取得。資料點仍保留於相同的類別位置，但圖表會根據空白值設定將其視為空白。

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

散佈圖使用分別的 X 與 Y 儲存格，氣泡圖亦使用大小儲存格。僅清除代表您欲移除之數值的儲存格。若想保留其他資料點，請勿呼叫 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)，因為該方法會移除集合中的所有資料點。

## **控制空白儲存格的顯示**

含有值的隱藏儲存格與空白儲存格屬於不同情況。若要包含或排除來自隱藏工作表列與欄的資料，請參閱 [Include Data from Hidden Rows and Columns](/slides/zh-hant/net/chart-workbook/#include-data-from-hidden-rows-and-columns)。

空白的活頁簿儲存格代表缺少的資料；包含 `0` 的儲存格則代表已知的數值。將 [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) 設為 `null` 即可使儲存格為空。數值零不論空白儲存格設定為何，都仍保留為零。

使用 [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) 來選擇圖表如何顯示空白儲存格。此設定套用於整個圖表。它會改變空白的繪製方式，而不會將空白活頁簿儲存格填入零或插值。

以下獨立範例建立一個包含單一系列的折線圖，清除第 3 天的值，並以每種模式儲存相同的圖表。無需輸入檔案。[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) 使用工作表 0、欄 0 作為類別標籤，欄 1 作為數值；第 0 列保存系列名稱。最終資料為 `10, 20, empty, 30, 40`。

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

// 讓第 3 天真正保持空白，同時保留其類別與資料點。
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

每個輸出檔案在儲存前會記錄所指定的模式：`empty_cells_Gap.pptx`、`empty_cells_Zero.pptx`、`empty_cells_Span.pptx`。若僅想儲存單一版本，可在儲存簡報前指定所需模式，僅執行一次儲存，而非遍歷所有模式。

以下比較顯示三個檔案中相同的資料。第 3 天在所有工作簿中皆為空白：

![折線圖具有相同資料：Gap 在第 3 天斷開線條，Zero 將線條降至零，Span 連接第 2 天與第 4 天。](display_blanks_as.png)

可見的效果取決於圖表類型。折線圖使三種模式皆易於比較。條形圖與柱形圖因缺少連接缺失類別的線條，故 `Span` 無法產生上述的連接段落；缺少的柱形與零高度的柱形也可能看起來相似。同樣地，僅有標記的散佈圖也沒有連接線。不要期待每種圖表類型都有三種明顯不同的結果；請檢查您使用的圖表類型的輸出。

## **設定系列間隙寬度**

間隙寬度是相鄰條形或柱形叢集之間的空間，以條形或柱形寬度的百分比表示。與重疊相似，它屬於父系列群組，而非單一系列。對群組設定一次 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)。較大的值會在叢集間產生更多空間，較小的值則使其更緊密。

以下範例變更間隙寬度，僅儲存最終的簡報：

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

所有由 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 列舉表示的圖表類型皆使用圖表資料，但其系列的值結構與設定並不完全相同。例如，類別圖表使用類別與值，散佈圖使用 X 與 Y 值，氣泡圖則額外加入氣泡大小。請使用與系列類型相符的資料點建立方法。諸如重疊與間隙寬度之類的選項僅適用於相容的條形或柱形群組。

**什麼是圖表系列群組？**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) 包含相容的系列，這些系列共用群組層級的繪製設定。組合圖表可以包含多個群組，因此透過單一系列取得的群組變更不一定會影響圖表中的所有系列。

**新建立的圖表是否包含預設資料？**

是的。預設情況下，[IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) 會建立範例系列、類別與數值。您可以編輯這些儲存格，或在加入完全自訂的資料集之前清除系列與類別集合。亦可使用其他重載建立不含預設資料的圖表。

**圖表物件如何連結至活頁簿儲存格？**

系列名稱、類別標籤與資料點值皆參照 [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) 中的儲存格。變更參照的儲存格會更新對應的圖表元素。建立自訂資料時，請保持類別列與系列值列對齊，以確保每個資料點繪製於預期的類別之下。

**如何只清除單一資料點而非整個系列？**

將相關的數值儲存格設為 `null`，即可保留該點的類別位置而使其成為空白點。僅在想要移除該系列所有資料點時才使用 [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)。如果同時移除類別，請更新所有系列，使其數值仍與類別集合保持對齊。

**空白點如何顯示？**

結果取決於圖表類型以及 [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)。支援的圖表可以將空白顯示為間隙、零值，或透過連接相鄰點的方式。請選擇符合簡報中缺漏資料意涵的設定。參閱 [控制空白儲存格的顯示](#control-the-display-of-empty-cells) 以取得完整範例與視覺比較。

**負值如何格式化？**

對於受支援的條形、柱形與氣泡系列，啟用 [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) 並設定 [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/)。您也可以使用 [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) 針對單一資料點覆寫此行為。這些屬性影響格式設定，而非儲存的數值。

**當系列與資料點同時設定格式時，哪個格式優先？**

對該資料點而言，明確的資料點格式會優先。其他資料點則會繼續使用明確的系列格式，若系列格式未定義，則使用自動圖表樣式與主題。群組屬性（例如重疊與間隙寬度）控制版面配置，並非資料點層級的格式覆寫。

**圖表可包含的系列數量有上限嗎？**

Aspose.Slides 並未設定固定的系列數量上限。實務上，簡報檔案限制、可用記憶體、渲染時間與圖表可讀性會決定實用的上限。

**當柱形過於接近或過於分散時，我該如何調整？**

在相應的父系列群組上設定 [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)。增大數值可擴大叢集間的間距，減小則使叢集更為緊密。