---
title: 使用 JavaScript 在演示文稿中自定义图表图例
linktitle: 图表图例
type: docs
url: /zh/nodejs-java/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "通过 Aspose.Slides for Node.js via Java 自定义图表图例，以优化 PowerPoint 演示文稿的图例格式。"
---
## **概述**

Aspose.Slides for Node.js via Java 提供了在 PowerPoint 演示文稿中自定义图表图例的选项。本文展示了如何定位和设置图例的大小、为整个图例设置字体大小、格式化单个图例项，以及隐藏或恢复选定的项。

FAQ 部分涵盖了相关行为，包括为图例预留空间、显示多行标签以及从演示文稿主题继承格式。

## **图例定位**

使用图例的 [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/)、[setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/)、[setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) 和 [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) 方法，以图表尺寸的比例指定其位置和大小。

此示例创建一个演示文稿，并在第一张幻灯片中添加带默认数据的聚类柱形图。将所需的图例偏移量和尺寸除以图表的宽度和高度即可转换为相对值：图例相对于图表左上角偏移 50 点，尺寸为 100 × 100 点。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // 相对于图表设置图例的位置和大小。
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置图例的字体大小**

使用图例的 [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) 访问其文本格式，并使用 [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) 以点为单位设置字体大小。

此示例创建一个带默认数据的图表，并将图例文本设置为 20 点。它还禁用垂直轴的自动边界，并将其范围设置为 -5 到 10。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置单个图例项的字体大小**

使用图例的 [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) 方法返回的集合来访问特定项的格式。条目索引从零开始，因此索引 `1` 代表第二个条目。

此示例创建一个默认数据包含至少两个序列的聚类柱形图。它将第二个图例项设置为加粗、斜体、20 点蓝色文本。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **隐藏单个图例项**

要在保持数据可见的同时从图例中排除辅助序列，请通过 [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/) 调用 [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) 并传入 `true`。这仅隐藏选定的图例项，不会删除序列或其数据点。相反，调用 [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) 并传入 `false` 会隐藏整个图例。

下面的示例使用默认数据创建一个包含多个序列的聚类柱形图。它隐藏第二个序列的图例项（索引 `1`）并保存演示文稿。随后通过调用 [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) 并传入 `false` 恢复该项，并保存第二个副本。两份文件中的柱形均保持可见。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // 恢复相同的条目而不更改图表数据。
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下面的比较显示了同一图表在全部条目可见和第二条目隐藏的情况下的效果。第二个序列的柱形保持不变。

![比较全部图例条目可见和隐藏第二条目时的图表；所有柱形均保持可见。](hide-legend-entry.png)

在柱形、条形和折线图中，图例条目标识序列。对于饼图，它们标识单个数据点（切片），因此请在选中的切片上使用 [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/)。API 为 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 和 `BarOfPie` 图表类型记录了此数据点方法。不要假设它适用于环形图，因为环形图未列入该列表。

## **常见问题**

**我能让图表为图例预留空间而不是覆盖吗？**

可以。调用 [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) 并传入 `false`，即可为图例预留空间，而不是让其覆盖绘图区。

**我能使用多行图例标签吗？**

可以。当可用宽度不足时，长标签会自动换行。您也可以在系列名称中使用换行字符来请求换行。

**我如何让图例遵循演示文稿主题的配色方案？**

保持图例的颜色、填充和字体未设置，这样它可以继承主题格式。显式的格式设置会覆盖相应的主题设置。