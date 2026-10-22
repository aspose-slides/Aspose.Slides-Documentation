---
title: 在 .NET 中格式化簡報圖表
linktitle: 圖表格式化
type: docs
weight: 60
url: /zh-hant/net/chart-formatting/
keywords:
- 格式化圖表
- 圖表格式化
- 圖表實體
- 圖表屬性
- 圖表設定
- 圖表選項
- 字型屬性
- 圓角邊框
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解在 Aspose.Slides for .NET 中的圖表格式化，並透過自訂座標軸、字型、數字格式和圓角圖表邊框，提升您的 PowerPoint 簡報。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 在 PowerPoint 簡報中格式化圖表。它展示了如何自訂圖表的關鍵元素，如座標軸、格線、標題、圖例、繪圖區域以及牆壁填色，以提升圖表資料的外觀與可讀性。

它同時示範了如何設定圖表文字的字型屬性、將預設數字格式套用到圖表資料，並啟用圖表區域的圓角。這些範例一併說明了如何同時控制簡報中圖表的視覺樣式與資料呈現。

## **格式化圖表實體**

使用 [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) 來格式化圖表標題、座標軸、格線、圖例與繪圖區域。此範例建立一個帶標記的折線圖與預設資料，然後對其值軸與類別軸分別套用文字與線條樣式。字型大小與線寬以點為單位；類別標籤旋轉 45 度。

值軸使用 [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/)，與來源儲存格無關。其刻度從 -2 到 15，主要間隔為 2，次要間隔為 0.5。範例也將百分比格式與 [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) 設為千位結合使用，請依據資料的意義與數值大小調整這些設定。圖例因為已停用 [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/)，所以位於繪圖區域之外。背牆與地板填色透過 [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) 與 [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) 設定，但這些表面僅在 3D 圖表中可見。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **設定圖表字型屬性**

透過 [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) 設定圖表文字的預設字型大小。此範例建立一個叢集柱狀圖，字型大小為 20 點，並透過 [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) 為第一個系列啟用值標籤。具有自行明確字型設定的文字元素會覆寫圖表的預設值。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **設定數字格式**

使用 [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) 為圖表工作表儲存格套用內建數字格式。此範例建立一個叢集柱狀圖，使用預設的、以儲存格為基礎的資料，並將格式索引 10 (`0.00%`) 套用到每個系列的值儲存格。這會改變工作表中值的顯示方式，但不改變底層數字；例如，0.25 會顯示為 25.00%。座標軸與資料標籤的格式也可以分別設定。

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

以下表格列出內建數字格式索引及其在英文（美國）語系下的代表性 Excel 格式。實際的格式字串與顯示方式可能因應用程式與語系而異，特別是貨幣與日期。某些 Excel 格式也與 OOXML 標準的預設不同，如同在 [Microsoft 的數字格式實作說明](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) 中所述。

| 索引 | 格式 |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **設定圖表區域圓角邊框**

啟用 [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) 以讓圖表區域的角落變圓。此範例建立一個叢集柱狀圖，並使用 [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) 為其外框設定實心灰色與單線樣式，最後儲存簡報。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **編輯現有圖表註釋**

圖表可以包含自訂圖形，例如說明報告狀態的文字註釋。可透過 [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/) 取得這些圖形，該屬性同樣在 [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) 中列出於 Chart API 參考。它的 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) 集合包含圖表所擁有的圖形。

放在圖表上方的普通文字方塊屬於投影片，即使看起來像是圖表的一部份。遍歷 [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) 會找到圖表與普通投影片圖形，但不會列舉圖表內部的個別圖形。圖表標題與資料標籤是獨立的圖表元素，並非此集合中的自訂註釋。

下載 [chart-annotations.pptx](chart-annotations.pptx) 並放置於應用程式的工作目錄。其第一張投影片包含一個未分組的註釋「Preliminary results」、一條圖表擁有的線條，以及一個普通投影片文字方塊「Slide overlay」。範例會在該投影片上找到第一個圖表，並在報告準備發布時將註釋改為「Final results」。它會檢查集合是否為空，僅編輯具有非 null [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) 且文字符合預期的 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)。

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

線條與投影片文字方塊保持不變。以下影像顯示編輯前後的結果：

| 編輯前 | 編輯後 |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
此範例僅檢查圖表擁有的頂層圖形。如果註釋位於 [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/) 內，亦需檢查該群組的 [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) 集合。對於巢狀群組，請遞迴執行相同的文字檢查於其子圖形。群組本身僅是容器；不要將其當作文字方塊處理。
{{% /alert %}}

## **常見問題**

**我可以在保持邊框不透明的同時，為柱形/區域設定半透明填色嗎？**

可以。填色透明度與外框分別設定。這在提升密集視覺化中格線與資料的可讀性時相當有用。

**當資料標籤重疊時，我該如何處理？**

縮小字型、停用非必要的標籤元件（例如類別）、調整標籤位置，必要時僅顯示選取點的標籤，或改為「值 + 圖例」的格式。

**我可以對系列套用漸層或圖案填色嗎？**

可以。系列支援實心、漸層與圖案填色。實務上，請節制使用漸層，並避免與格線與文字對比度降低的組合。