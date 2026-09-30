---
title: 在 .NET 中客製化簡報的圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/net/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 客製化圖表圖例，以量身訂做的圖例格式優化 PowerPoint 簡報。"
---
## **概觀**

Aspose.Slides for .NET 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本文章說明如何定位與調整圖例大小、設定整個圖例的字型大小、格式化單一圖例項目，以及隱藏或復原選取的項目。

FAQ 包含相關行為說明，包括為圖例保留空間、顯示多行標籤，以及從簡報主題繼承格式。

## **圖例位置**

使用圖例的 [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/)、[Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/)、[Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) 與 [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) 屬性，以圖表尺寸的比例指定位置與大小。

此範例建立簡報，並在第一張投影片加入預設資料的群組式直條圖。將圖例的偏移量與尺寸除以圖表的寬度與高度，即可轉換為相對值：圖例距圖表左上角 50 點，大小為 100 x 100 點。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// 表示圖例相對於圖表的位置與大小。
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **設定圖例的字型大小**

使用圖例的 [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) 以存取文字格式，並以點數設定 [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) 。

此範例建立具有預設資料的圖表，並將圖例文字設定為 20 點。它同時停用垂直軸的自動邊界，並將範圍設定為 -5 到 10。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **設定單一圖例項目的字型大小**

使用圖例的 [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) 集合，以存取特定項目的格式。項目索引從零開始，因此索引 `1` 代表第二個項目。

此範例建立預設資料包含至少兩個系列的群組式直條圖。它將第二個圖例項目格式化為粗體、斜體、20 點的藍色文字。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **隱藏單一圖例項目**

若要在保留資料可見的前提下，將輔助系列從圖例中排除，請透過 [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/) 將 [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) 設為 `true`。此方式僅隱藏選取的圖例項目，不會移除系列或其資料點。相較之下，將 [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) 設為 `false` 則會隱藏整個圖例。

以下範例建立具有多個系列的預設資料群組式直條圖。它隱藏第二個系列的圖例項目（索引 `1`），並儲存簡報。接著將 `Hide` 設為 `false` 復原該項目，並儲存第二個副本。兩個檔案的直條皆保持可見。

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// 復原相同的項目而不更改圖表資料。
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

以下比較圖顯示全部項目可見與第二項目被隱藏的同一張圖表。第二系列的直條保持不變。

![比較圖表，所有圖例項目皆可見與第 2 系列在圖例中被隱藏的情況；所有欄位仍保持可見。](hide-legend-entry.png)

在直條圖、長條圖與折線圖中，圖例項目代表系列。對於圓餅圖，圖例項目代表單一資料點（切片），因此請改用 [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) 於選取的切片上。API 為 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 與 `BarOfPie` 圖表類型記錄此資料點屬性。請勿假設此屬性適用於甜甜圈圖，因其未列入上述清單。

## **常見問題**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Yes. Set [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) to `false` to reserve space for the legend instead of allowing it to overlap the plot area.

**Can I make multiline legend labels?**

Yes. Long labels can wrap when the available width is insufficient. You can also use newline characters in series names to request line breaks.

**How do I make the legend follow the presentation theme's color scheme?**

Leave the legend's colors, fills, and fonts unset so that it can inherit theme formatting. Explicit formatting overrides the corresponding theme settings.