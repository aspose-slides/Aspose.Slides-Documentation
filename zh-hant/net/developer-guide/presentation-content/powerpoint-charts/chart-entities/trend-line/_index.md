---
title: 在 .NET 中為簡報圖表新增趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/net/trend-line/
keywords:
- 圖表
- 趨勢線
- 指數趨勢線
- 線性趨勢線
- 對數趨勢線
- 移動平均趨勢線
- 多項式趨勢線
- 冪次趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint 圖表中快速新增與自訂趨勢線 — 一本實用指南，幫助您吸引觀眾。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 為簡報圖表新增趨勢線。它展示了如何建立圖表、為圖表系列新增趨勢線，以及使用多種趨勢線類型，包括指數、線性、對數、移動平均、多項式和冪次。

此外，還說明了如何透過插入線形圖案的方式為圖表新增自訂線，並提供了關於前向與後向趨勢線投射值，以及在匯出為 PDF 或 SVG、或將圖表呈現為影像時趨勢線是否會被保留的簡短 FAQ。

## **新增趨勢線**

使用 [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) 為圖表系列新增趨勢線，並以 [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/) 選擇其類型。範例建立一個預設資料的叢集柱狀圖，並為其三個系列各自新增兩條趨勢線。

指數趨勢線透過 [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) 與 [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/) 隱藏其方程式與 R 平方值；線性趨勢線則為紅色。對數趨勢線使用 [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) 來自訂標籤。移動平均使用三個資料點的 [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) 與自訂的 [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/)。

多項式趨勢線的 [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) 為三，並透過 [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/) 向前延伸一個類別。冪次趨勢線則透過 [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/) 向後延伸一個類別。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **設定趨勢線截距**

使用 [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) 可在 X = 0 時固定趨勢線的 Y 值。此設定支援線性、指數與多項式趨勢線。

例如，生產成本模型可能需要在已知固定成本 100 的情況下開始，即使非零產量的測量值顯示出不同的基線。對於線性趨勢線，固定截距會將方程式 `y = ax + b` 限制為 `b = 100`；斜率則在此限制下依資料擬合。這並非僅僅移動已擬合的直線。座標軸交叉設定控制圖表座標軸相交的位置，而非擬合趨勢線的係數。

以下範例建立一個散佈 (XY) 圖表，產量從 1 到 4，成本分別為 170、200、230 與 260。它先以預設自動截距儲存圖表，然後將截距設定為 100 再儲存第二個 PPTX。兩個檔案唯一的差異在於截距設定。趨勢線會顯示其方程式並延伸回 X = 0。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

在自動計算下，這些資料產生 `y = 30x + 140`。將截距設定為 100 則約產生 `y = 43.33x + 100`：在零點的擬合值符合已知基線，但此線不再通過所有資料點。

| 自動截距 | 固定截距 100 |
| --- | --- |
| ![自動計算截距 140 的線性趨勢線](intercept-automatic.png) | ![固定截距 100 的線性趨勢線](intercept-fixed.png) |

兩張圖片使用相同的資料與座標軸比例。趨勢線均延伸回 X = 0 以顯示其截距。

預設情況下，屬性值為 `double.NaN`，代表未指定的截距而非零。此時截距會自動從資料計算得出。

## **新增自訂線**

自訂線是繪製於圖表之上的圖形，而非由系列資料計算的趨勢線。此範例使用 [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) 在圖表上方的投影片加入一條水平線。線的位置以投影片座標（以點為單位）指定，從圖表左邊緣開始，位於圖表高度的中間。其寬度與圖表寬度相同。[LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) 為線條設定實心紅色。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **常見問題**

**趨勢線的「forward」和「backward」意味著什麼？**

它們是趨勢線向前/向後投射的長度：對於散佈 (XY) 圖表，以座標軸單位計算；對於非散佈圖表，以類別數計算。僅允許非負值。

**在將簡報匯出為 PDF 或 SVG，或將投影片轉換為影像時，趨勢線會被保留嗎？**

會。Aspose.Slides 可將簡報轉換為 [PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/) 或 [SVG](/slides/zh-hant/net/render-a-slide-as-an-svg-image/) 並將圖表渲染為影像；趨勢線作為圖表的一部分，在這些操作中會被保留。此外，亦提供將 [匯出圖表的影像](/slides/zh-hant/net/create-shape-thumbnails/) 的方法。