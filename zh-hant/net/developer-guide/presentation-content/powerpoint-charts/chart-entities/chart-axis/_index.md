---
title: 在 .NET 中自訂簡報的圖表坐標軸
linktitle: 圖表坐標軸
type: docs
url: /zh-hant/net/chart-axis/
keywords:
- 圖表坐標軸
- 垂直坐標軸
- 水平坐標軸
- 自訂坐標軸
- 操作坐標軸
- 管理坐標軸
- 坐標軸屬性
- 最大值
- 最小值
- 坐標軸線
- 日期格式
- 坐標軸標題
- 坐標軸位置
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中自訂圖表坐標軸，以用於報告和視覺化。"
---
## **概述**

本文說明如何使用 Aspose.Slides for .NET 自訂圖表坐標軸。它涵蓋計算坐標軸值、切換圖表列與欄、坐標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、坐標軸定位、顯示單位以及對數比例。

## **在圖表上取得垂直坐標軸的最大值**

建立一個[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 並加入預設資料的區域圖表。在讀取計算後的坐標軸值之前，呼叫[ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) 以確保圖表佈局為最新。

讀取[ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/)和[ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/)以取得坐標軸限制，並讀取[ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/)和[ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/)以取得刻度間隔。[ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/)和[ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/)提供時間單位比例，這與日期坐標軸相關。此範例將這些值儲存於本地變數中，並保存圖表。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **在坐標軸之間互換資料**

使用[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) 交換圖表資料中系列與類別的角色。先前的每個類別將變為系列，先前的每個系列將變為類別。此操作會改變資料的分組方式；不會交換水平與垂直坐標軸。此範例在切換列與欄之前，使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) 將預設資料繫結至 `Sheet1!A1:D5`，包括標頭列與類別欄。它會儲存一個包含四個系列和三個類別的圖表。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **反轉坐標軸的繪圖順序**

使用[IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) 反轉類別或數值坐標軸。例如，水平條狀圖可以依工作表的相同順序自上而下顯示專案階段：Planning、Development、Testing。反轉坐標軸會改變繪圖方向；不會對工作簿資料進行排序或重新排列。相比之下，[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) 交換系列與類別的角色。

以下範例建立一個具有三個階段和一個系列的水平條狀圖。它會儲存包含三張投影片的簡報：正常順序、反轉類別以及反轉數值。每個副本使用相同的資料集，且每個副本僅反轉一個坐標軸。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// 第 2 張投影片：將第一個類別顯示在最上方。
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// 將水平數值坐標軸保持在底部。
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// 第 3 張投影片：僅反轉水平數值比例。
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

反轉坐標軸亦可將垂直於其的另一坐標軸移至繪圖的相對側。[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) 控制另一坐標軸在被設定的坐標軸上的交叉位置。在第 2 張投影片中，將其設定為 `Maximum`（於反轉的類別坐標軸）可讓水平數值坐標軸保持在底部。若要指定特定的交叉點，請使用[CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。變更方向時請檢查交叉設定，特別是圖表已有自訂交叉點時。將 `IsPlotOrderReversed` 設回 `false` 可恢復正常的繪圖方向；交叉設定則是獨立的。

| 正常順序（投影片 1） | 反轉類別（投影片 2） | 反轉數值（投影片 3） |
| --- | --- | --- |
| ![水平條狀圖（正常類別與數值坐標軸順序）](axis-order-normal.png) | ![水平條狀圖（類別自上而下顯示）](axis-order-categories-reversed.png) | ![水平條狀圖（反轉數值坐標軸，零位於右側）](axis-order-values-reversed.png) |
| 類別由底部向上排列；數值由左至右遞增。 | Planning、Development、Testing 由上而下排列。數值與工作表列順序保持不變。 | 類別保留其正常順序；數值由右至左遞增。類別坐標軸於右側零點交叉。 |

## **停用折線圖的垂直坐標軸**

將垂直坐標軸的[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) 設為 `false` 以隱藏它。此範例建立具有預設資料的折線圖，並以隱藏垂直坐標軸的方式儲存。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **停用折線圖的水平坐標軸**

將水平坐標軸的[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) 設為 `false` 以隱藏它。此範例建立具有預設資料的折線圖，並以隱藏水平坐標軸的方式儲存。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **變更類別坐標軸**

設定[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) 以選擇日期或文字類別坐標軸。此範例需要 `ExistingChart.pptx`，其圖表位於第一張投影片的第一個形狀，且類別儲存格包含數值型 Excel 日期。它將水平坐標軸變更為日期坐標軸。將[IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) 設為 `false`、[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) 設為 `1`，以及[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) 設為月份，可使主要刻度以一個月間隔呈現。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **控制類別坐標軸標籤間隔**

當圖表有許多類別時，可在不移除類別或資料點的前提下減少可見的坐標軸標籤數量。將[IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) 設為 `false`，然後將[TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) 設為所需的類別間隔。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | 類別 1, 類別 2, 類別 3, ... 類別 24 |
| `2` | 類別 1, 類別 3, 類別 5, ... 類別 23 |
| `3` | 類別 1, 類別 4, 類別 7, ... 類別 22 |

間隔為 `3` 時會顯示每三個標籤，且在顯示的標籤之間隱藏兩個標籤。這不會移除對應的欄。自動間隔會根據可用空間選擇間隔，未必會顯示每個標籤。

刻度線有獨立的控制。將[IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) 設為 `false`，並使用[TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) 設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤僅每三個類別顯示一次。將[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) 設為可見樣式，以便看到結果。將任一自動間隔屬性重新設為 `true`，圖表將再次自行選擇間隔。

以下獨立範例建立 24 個類別和一個系列，然後在 `CategoryAxisIntervals.pptx` 中保存三張投影片：自動間隔、手動標籤間隔（具獨立刻度線）以及恢復自動間隔。兩個副本保留原始圖表資料。無需輸入簡報。水平標籤文字有助於輕易看出密度差異。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// 第 2 張投影片：顯示每三個標籤，但為每個類別保留刻度線。
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// 第 3 張投影片：讓圖表再次自行選擇兩個間隔。
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**自動間隔（投影片 1）：** 在此呈現中，每第二個類別標籤會被顯示，且會換行成兩行。自動結果可能因圖表大小、字型與渲染器而異。

![自動類別標籤間隔（顯示全部 24 欄）](category-axis-automatic.png)

**手動間隔（投影片 2）：** 每第三個標籤顯示在一行，而刻度線仍保留在每個類別間隔。所有 24 欄（包括未顯示標籤的欄）均保持可見且值相同。投影片 3 恢復如上所示的自動外觀。

![手動類別標籤間隔三（顯示全部 24 欄）](category-axis-manual.png)

### **選擇正確的坐標軸與間隔**

對文字類別坐標軸（例如柱狀圖、折線圖、面積圖或條狀圖的類別坐標軸）使用此類別計數間隔。在柱狀圖中，它是水平坐標軸；在水平條狀圖中，類別坐標軸為垂直方向，因此將這些設定套用至[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。刻度間隔也適用於具有系列坐標軸的圖表。

不要使用類別標籤間隔來設定數值坐標軸的數值尺度。在數值坐標軸上，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) 指定數值之差異：例如，當坐標軸從零開始時，`10` 的主要單位會在 0、10、20 等產生刻度。而類別標籤間隔 `3` 則是計算類別位置，與資料值無關。散點圖與氣泡圖使用數值坐標軸而非文字類別坐標軸。對於日期坐標軸，請使用基於時間的主要單位和比例，如[Change a Category Axis](#change-a-category-axis) 中所述。

## **設定類別坐標軸值的日期格式**

此範例以四個年度值取代預設圖表資料。日期以 OLE Automation 序號存於第一個工作表（索引 `0`）。將[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) 設為日期坐標軸，停用[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)，並將 `yyyy` 指派給[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)，使類別標籤以四位數年份顯示，且不受儲存格格式影響。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **設定圖表坐標軸標題的旋轉角度**

在垂直坐標軸上啟用[HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)，提供標題文字，並設定[RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) 以旋轉標題。角度以度數計算；此範例將柱狀圖的數值坐標軸標題旋轉 90 度後儲存。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **設定類別或數值坐標軸的位置**

使用[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) 來控制數值坐標軸是於類別之間還是於類別刻度線上與類別坐標軸交叉。此屬性適用於類別坐標軸。此範例將其設定為 `true`，於柱狀圖的水平類別坐標軸上，並儲存結果。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **設定圖表數值坐標軸的顯示單位**

將[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) 設定，以在不變更底層資料的情況下縮放數值坐標軸的標籤。將[DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) 設為 `Millions` 時，60000000 的值會顯示為 60。此範例建立柱狀圖，並將百萬顯示單位套用至其垂直坐標軸。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **設定對數數值坐標軸**

當正值跨越多個數量級時，對數數值坐標軸相當有用。例如，服務在五個時期可能分別收到 10、100、1,000、10,000 與 100,000 筆請求。使用線性尺度時，較小的值會聚集在接近零的區域。對數尺度則使其相對成長更易比較：等距代表等比例而非等差。

將數值坐標軸的[IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) 設為 `true`，並使用[LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) 以選擇底數。此操作會變更現有值的顯示方式；不會變更資料或新增對數趨勢線。趨勢線是對資料擬合關係的表示，屬於獨立功能。

### **選擇數值坐標軸與底數**

對於折線圖或柱狀圖，數值坐標軸為[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。對於水平條狀圖，則為[HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/)。散點圖與氣泡圖擁有兩個數值坐標軸，故可為 X 值選擇水平坐標軸，為 Y 值選擇垂直坐標軸，或同時套用。不要對類別坐標軸使用對數比例。

預設的對數底數為 `10`。對於 PPTX 圖表，可使用 `2` 至 `1000`（含）之間的底數；亦支援如 `2.5` 等分數底數。以底數 `10` 時，連續的次方 10、100、1,000、10,000 等等間距相等。

### **比較線性與對數比例**

以下獨立範例於第一張投影片建立含五筆請求數的折線圖，然後複製該投影片，於第二張投影片啟用以 10 為底的對數數值坐標軸。兩張投影片保留相同資料。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// 保持第一張投影片為線性，僅變更副本的數值坐標軸比例。
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**線性比例（投影片 1）：** 等距的垂直距離代表請求數的等差。最大值主導圖表，使較小的值難以分辨。

![PowerPoint 折線圖（線性數值坐標軸）顯示五筆請求數](value-axis-linear.png)

**對數比例（投影片 2）：** 等距的垂直距離代表等比例。每個時期的請求數是前一時期的十倍，所以在以 10 為底的比例上，點形成一條直線上升。坐標軸標籤仍顯示原始的請求數。

![PowerPoint（底數 10 對數數值坐標軸）顯示相同的五筆請求數](value-axis-logarithmic.png)

### **處理零與負值**

對數尺度只能顯示嚴格正值。啟用前請檢查資料。若零或負值具有意義，請保留線性尺度或將其另行顯示。若在分析上排除這些值是適當的，請說明排除的原因。不要悄悄將它們替換為小的正數，因為會改變資料意義。對於對數坐標軸，任何手動設定的最小值或最大值亦必須為正值。

## **常見問題**

**如何設定坐標軸交叉的數值（坐標軸交叉點）？**

使用[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) 以選擇交叉行為。若要指定數值型的交叉點，請設定[CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。這些設定可讓您將坐標軸交叉點移至合適的基線。

**如何將刻度標籤相對於坐標軸定位？**

使用[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) 並搭配[TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/)：`Low`、`High`、`NextTo` 或 `None`，來設定刻度標籤相對於坐標軸的位置。若要控制刻度線本身，請使用[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/)或[MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)；這些設定與標籤定位是分開的。