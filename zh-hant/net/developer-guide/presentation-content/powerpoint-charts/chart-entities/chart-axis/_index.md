---
title: 在 .NET 環境中自訂簡報的圖表座標軸
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
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 簡報中自訂圖表座標軸，以製作報告與視覺化。"
---
## **概述**

本文說明如何使用 Aspose.Slides for .NET 來自訂圖表座標軸。內容涵蓋計算後的座標軸值、切換圖表列與欄、座標軸可見性、類別標籤與刻度間隔、日期類別與格式設定、標題旋轉、座標軸位置、顯示單位以及對數縮放。

## **在圖表的垂直座標軸上取得最大值**

建立一個[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)，並以預設資料新增區域圖。於讀取計算後的座標軸值之前，先呼叫[ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/)，以確保圖表版面已更新。

讀取[ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/)與[ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/)取得座標軸上下限，並讀取[ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/)與[ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/)取得刻度間隔。[ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/)與[ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/)提供時間單位比例，適用於日期座標軸。範例將這些值存入本機變數，並儲存圖表。

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

## **在座標軸之間交換資料**

使用[SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/)以交換系列與類別在圖表資料中的角色。先前的每個類別會變成系列，先前的每個系列會變成類別。此變更僅影響資料分組方式，並不交換水平與垂直座標軸。範例使用[SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/)將預設資料繫結至`Sheet1!A1:D5`（包含標題列與類別欄），然後切換列與欄。最後儲存一個具有四個系列與三個類別的圖表。

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

## **為折線圖停用垂直座標軸**

在垂直座標軸上將[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)設為`false`以隱藏它。範例建立一個預設資料的折線圖，並以隱藏垂直座標軸的方式儲存。

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

## **為折線圖停用水平座標軸**

在水平座標軸上將[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/)設為`false`以隱藏它。範例建立一個預設資料的折線圖，並以隱藏水平座標軸的方式儲存。

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

將[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/)設定為日期或文字類別座標軸。本範例需要`ExistingChart.pptx`，其中第一張投影片的第一個形狀是圖表，類別儲存格包含 Excel 數值日期。它將水平座標軸變更為日期座標軸。將[IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/)設為`false`、[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/)設為`1`，以及[MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/)設定為月份，便會使主要刻度以每月間隔顯示。

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

當圖表擁有大量類別時，可在不移除類別或資料點的前提下，減少可見的座標軸標籤數量。將[IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/)設為`false`，再將[TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/)設定為所需的類別間隔。對於正常順序的文字類別，計數從第一個類別開始：

| 間隔 | 範例中顯示的標籤 |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

間隔為`3`時會顯示每第三個標籤，兩個隱藏標籤位於顯示標籤之間。此設定不會移除相對應的欄。自動間隔會根據可用空間自行決定間隔，未必會顯示全部標籤。

刻度線有獨立的控制。將[IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/)設為`false`，並使用[TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/)設定其間隔。例如，`1` 會在每個類別間隔保留刻度線，而標籤只在每第三個類別顯示。將[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/)設為可見樣式，以便看到結果。將任一自動間隔屬性重新設為`true`，即可讓圖表再次自動選擇間隔。

以下自足例子會建立 24 個類別與一個系列，然後在 `CategoryAxisIntervals.pptx` 中儲存三張投影片：自動間隔、手動標籤間隔（刻度線獨立）以及恢復自動間隔。兩個副本保留原始圖表資料，無需輸入投影片。水平標籤文字使密度差異一目了然。

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

// 投影片 2：顯示每三個標籤，但每個類別保留刻度線。
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// 投影片 3：讓圖表再次自行選擇兩個間隔。
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**自動間隔（投影片 1）**：此呈現中，每第二個類別標籤會顯示，且會換行成兩行。自動結果可能因圖表大小、字型與渲染器而異。

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**手動間隔（投影片 2）**：每第三個標籤會在單行顯示，而刻度線仍保留在每個類別間隔。所有 24 個欄位（包括未標籤的欄位）仍保持可見且值未變。投影片 3 會恢復上述的自動外觀。

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **選取正確的座標軸與間隔**

在文字類別座標軸（例如柱狀圖、折線圖、區域圖或條形圖的類別座標軸）使用此類別計數間隔。於柱狀圖中，此為水平座標軸；於水平條形圖中，類別座標軸為垂直座標軸，請將設定套用至[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。刻度線間隔同樣適用於具有系列座標軸的圖表。

請勿使用類別標籤間隔來設定數值座標軸的數值刻度。在數值座標軸上，[MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) 表示值的差距，例如 `10` 的主要單位會在 0、10、20… 等位置產生刻度。類別標籤間隔 `3` 則是以類別位置計算，與實際資料值無關。散佈圖與氣泡圖使用數值座標軸而非文字類別座標軸。對於日期座標軸，請參考[變更類別座標軸](#變更類別座標軸)中描述的時間基礎主要單位與比例設定。

## **設定類別座標軸值的日期格式**

此範例以四筆年度值取代預設圖表資料。日期以 OLE Automation 序號儲存在第一個工作表（索引 `0`）中。將[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) 設為日期座標軸，停用[IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/)，並將 `yyyy` 指派給[NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/)，使類別標籤顯示四位數年份且不受儲存格格式影響。

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

## **為圖表座標軸標題設定旋轉角度**

在垂直座標軸上啟用[HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/)，提供標題文字，並將[RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) 設為所需角度以旋轉標題。角度以度為單位；此範例將柱狀圖的數值座標軸標題旋轉 90 度後儲存。

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

## **在類別或數值座標軸上設定座標軸位置**

使用[AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) 來控制數值座標軸是跨越類別之間還是跨越類別刻度線。此屬性適用於類別座標軸。範例在柱狀圖的水平類別座標軸上將其設為 `true`，然後儲存結果。

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

## **在圖表數值座標軸上設定顯示單位**

將[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) 設為所需單位，以縮放數值座標軸上的標籤而不改變底層資料。將[DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) 設為 `Millions`，則 60,000,000 會顯示為 60。此範例建立一個柱狀圖，並將垂直座標軸的顯示單位設為百萬。

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

## **設定對數數值座標軸**

當正值跨越多個數量級時，對數數值座標軸相當有用。例如，某服務在五個時期內分別收到 10、100、1,000、10,000 與 100,000 筆請求。在線性比例下，較小的值會聚集在接近零的位置。對數比例則讓相對成長更易比較：相等的距離代表相等的比例而非相等的差距。

將[IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) 設為 `true`，再使用[LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) 選擇基底。此設定僅改變現有值的顯示方式，並不會改變資料或加入對數趨勢線。趨勢線是資料的擬合關係，屬於另一個功能。

### **選取數值座標軸與基底**

對於折線圖或柱狀圖，數值座標軸為[VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/)。對於水平條形圖，則為[HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/)。散佈圖與氣泡圖擁有兩條數值座標軸，請為 X 軸（水平）與 Y 軸（垂直）分別設定，或同時設定。請勿將對數縮放套用於類別座標軸。

預設的對數基底為 `10`。對於 PPTX 圖表，基底可選 `2` 至 `1000`（含），亦支援 `2.5` 等分數基底。使用基底 `10` 時，連續的次方 10、100、1,000、10,000 會等距排列。

### **比較線性與對數縮放**

以下自足例子會在第一張投影片建立包含五筆請求計數的折線圖，然後複製該投影片並在第二張上啟用基底為 10 的對數數值座標軸。兩張投影片保留相同資料。

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

// 保留第一張投影片為線性，且僅更改其副本的數值座標軸比例。
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**線性比例（投影片 1）**：相等的垂直距離代表相等的請求數差距。最高值會主導圖表，使較小的值難以辨識。

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**對數比例（投影片 2）**：相等的垂直距離代表相等的比例。每個時期的請求數是前一時期的十倍，因此在基底為 10 的比例上，點會形成一條直線上升。座標軸標籤仍顯示原始的請求數。

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **處理零與負值**

對數比例只能顯示嚴格正值。啟用前請先檢查資料。若零或負值具有意義，請保留線性比例或另行顯示。若排除這些值符合分析需求，請說明省略的原因。切勿自行以小的正數取代，因會改變資料意義。任何手動設定的對數座標軸最小值或最大值亦必須為正。

## **常見問題**

**如何設定一條座標軸與另一條座標軸交叉的值（交叉點）？**

使用[CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) 來選取交叉行為。若要指定數值交叉點，請設定[CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/)。這些設定可讓您將座標軸交叉位置移至適當的基線。

**如何相對於座標軸定位刻度標籤？**

使用[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) 搭配[TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) 設為 `Low`、`High`、`NextTo` 或 `None`。若要控制刻度線本身，請使用[MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) 或[MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/)，這些與標籤位置是分開的設定。