---
title: 在 .NET 中自訂簡報內的圖表座標軸
linktitle: 圖表座標軸
type: docs
url: /zh-hant/net/chart-axis/
keywords:
- 圖表座標軸
- 垂直座標軸
- 水平座標軸
- 自訂座標軸
- 操作座標軸
- 管理座標軸
- 座標軸屬性
- 最大值
- 最小值
- 座標軸線
- 日期格式
- 座標軸標題
- 座標軸位置
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中自訂圖表座標軸，以製作報告與視覺化。"
---
## **概觀**

本文說明如何使用 Aspose.Slides for .NET 自訂圖表座標軸。它涵蓋了計算出的座標軸值、切換圖表列與欄、座標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、座標軸位置以及顯示單位。

## **取得圖表垂直座標軸的最大值**

建立一個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 並加入預設資料的區域圖。 在讀取計算後的座標軸值之前，先呼叫 [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) 以確保圖表版面配置為最新。

讀取 [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) 與 [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) 以取得座標軸的上下限，並讀取 [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) 與 [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) 以取得刻度間隔。 [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) 與 [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) 提供時間單位的比例，與日期座標軸相關。 範例將這些值存入本機變數，並儲存圖表。

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

## **交換座標軸之間的資料**

使用 [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) 交換圖表資料中系列與類別的角色。先前的每個類別會變成系列，先前的每個系列會變成類別。這會改變資料的分組方式，卻不會交換水平與垂直座標軸。範例在切換列與欄之前，使用 [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) 將預設資料綁定至 `Sheet1!A1:D5`（包含標題列與類別欄）。它會儲存一個具有四個系列與三個類別的圖表。

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

## **在折線圖中隱藏垂直座標軸**

將垂直座標軸的 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) 設為 `false` 以隱藏它。範例建立一個預設資料的折線圖，並在隱藏垂直座標軸的情況下儲存。

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

## **在折線圖中隱藏水平座標軸**

將水平座標軸的 [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) 設為 `false` 以隱藏它。範例建立一個預設資料的折線圖，並在隱藏水平座標軸的情況下儲存。

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

## **變更類別座標軸**

將 [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) 設定為日期或文字類別座標軸。本範例需要 `ExistingChart.pptx`，其中圖表位於第一張投影片的第一個圖形，且類別儲存格包含數值型 Excel 日期。它會將水平座標軸變更為日期座標軸。將 [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) 設為 `false`、[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) 設為 `1`，且 [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) 設為月份，便會使主要刻度以一個月為間隔。

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

## **控制類別座標軸標籤間隔**

當圖表有許多類別時，可在不移除類別或資料點的前提下，減少可見的座標軸標籤數量。將 [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) 設為 `false`，再將 [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) 設為欲使用的類別間隔。對於依照正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | 類別 1, 類別 2, 類別 3, ... 類別 24 |
| `2` | 類別 1, 類別 3, 類別 5, ... 類別 23 |
| `3` | 類別 1, 類別 4, 類別 7, ... 類別 22 |

間隔為 `3` 時會顯示每第三個標籤，於顯示的標籤之間隱藏兩個標籤。它不會移除相對應的欄。自動間隔會依可用空間選擇間隔；不一定會顯示每一個標籤。

刻度線有獨立的控制。將 [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) 設為 `false`，並使用 [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) 設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤僅每第三個類別顯示一次。將 [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) 設為可見樣式，以便看到結果。將任一自動間隔屬性重新設為 `true`，圖表會再次自行選擇間隔。

以下獨立範例會建立 24 個類別與一個系列，然後將三張投影片儲存為 `CategoryAxisIntervals.pptx`：自動間隔、具有獨立刻度線的手動標籤間隔，以及還原的自動間隔。兩個副本保留原始圖表資料。不需要輸入簡報。水平標籤文字使密度差異一目了然。

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

// Slide 2: 顯示每三個標籤，但每個類別保留刻度線。
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slide 3: 讓圖表再次自行選擇兩種間隔。
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**自動間隔（第 1 張投影片）：** 在此呈現中，每第二個類別標籤會顯示，且會換行成兩行。自動結果可能因圖表大小、字體與渲染器而異。

![所有 24 欄皆可見的自動類別標籤間隔](category-axis-automatic.png)

**手動間隔（第 2 張投影片）：** 每第三個標籤會在單一行顯示，而刻度線仍保留在每個類別間隔。所有 24 欄（包括未顯示標籤的欄）仍以相同數值可見。第 3 張投影片還原上述的自動外觀。

![所有 24 欄皆可見的手動三倍類別標籤間隔](category-axis-manual.png)

### **選擇正確的座標軸與間隔**

對於文字類別座標軸（例如柱狀圖、折線圖、區域圖或長條圖的類別座標軸），請使用此類別計數間隔。在柱狀圖中，它是水平座標軸。在水平長條圖中，類別座標軸為垂直方向，故將此設定套用至 [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。刻度線間隔同樣適用於具系列座標軸的圖表。

不要使用類別標籤間隔來設定值座標軸的數值刻度。於值座標軸上，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) 指定數值的差距：例如，當座標軸從零開始時，`10` 的主要單位會產生 0、10、20 等刻度。類別標籤間隔 `3` 則是計算類別位置，與其資料值無關。散佈圖與氣泡圖使用值座標軸而非文字類別座標軸。對於日期座標軸，請使用基於時間的主要單位與比例，如 [Change a Category Axis](#change-a-category-axis) 中所述。

## **設定類別座標軸值的日期格式**

此範例將預設圖表資料替換為四個年度值。日期以 OLE Automation 序列號存於第一個工作表（索引 `0`）中。將 [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) 設為日期座標軸，停用 [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)，並將 `yyyy` 指派給 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)，使類別標籤獨立於儲存格格式，顯示四位數年份。

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

## **設定圖表座標軸標題的旋轉角度**

在垂直座標軸上啟用 [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)，提供標題文字，並將 [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) 設定為旋轉角度。角度以度為單位；此範例將柱狀圖的值軸標題旋轉 90 度後儲存。

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

## **設定類別或值座標軸的位置**

使用 [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) 來控制值座標軸是否在類別之間或在類別刻度標記處跨越類別座標軸。此屬性適用於類別座標軸。範例在柱狀圖的水平類別座標軸上將其設為 `true`，並儲存結果。

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

## **設定圖表值座標軸的顯示單位**

將 [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) 設定以在不變更底層資料的情況下縮放值座標軸的標籤。將 [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) 設為 `Millions` 後，60,000,000 會顯示為 60。此範例建立柱狀圖，並將百萬顯示單位套用至其垂直座標軸。

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

## **常見問題**

**如何設定座標軸相交的數值（座標軸交叉點）？**

使用 [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) 以選擇交叉行為。若要指定數值型的交叉點，請設定 [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。這些設定可讓您將座標軸交叉點移動到適當的基準線。

**如何相對於座標軸定位刻度標籤？**

使用 [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) 搭配 [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) 設定：`Low`、`High`、`NextTo` 或 `None`。若要控制刻度線本身，請使用 [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) 或 [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)，它們與標籤位置設定是分開的。