---
title: 使用 Java 在演示文稿中自定义图表图例
linktitle: 图表图例
type: docs
url: /zh/java/chart-legend/
keywords:
- 图表图例
- 图例位置
- 字体大小
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 自定义图表图例，以针对性图例格式优化 PowerPoint 演示文稿。"
---
## **概述**

Aspose.Slides for Java 提供了在 PowerPoint 演示文稿中自定义图表图例的选项。本文展示了如何定位和设置图例的大小、为整个图例设置字体大小、格式化单个图例项以及隐藏或恢复所选项。

常见问题解答覆盖了相关行为，包括为图例预留空间、显示多行标签以及从演示文稿主题继承格式。

## **图例定位**

使用图例的 [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), 和 [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) 方法可将其位置和大小指定为图表尺寸的比例。

此示例创建一个演示文稿并在第一张幻灯片上添加一个带默认数据的簇状柱形图。将所需的图例偏移量和尺寸除以图表的宽度和高度即可转换为相对值：图例相对于图表左上角偏移 50 点，大小为 100 × 100 点。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // 表示相对于图表的图例位置和大小。
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置图例的字体大小**

使用图例的 [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) 访问其文本格式，并使用 [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) 以点为单位设置字体大小。

此示例创建一个带默认数据的图表，并将图例文本设置为 20 点。它还禁用了垂直轴的自动界限，并将范围设为 -5 到 10。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置单个图例项的字体大小**

使用图例的 [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) 方法返回的集合来访问特定项的格式。条目索引从零开始，因此索引 `1` 指的是第二个条目。

此示例创建一个默认数据至少包含两个系列的簇状柱形图。它将第二个图例项格式化为加粗、斜体、20 点蓝色文本。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **隐藏单个图例项**

要在保持数据可见的同时将辅助系列从图例中排除，请通过 [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--) 调用 [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) 并传入 `true`。这仅隐藏所选的图例项；不会删除系列或其数据点。相反，调用 [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) 并传入 `false` 会隐藏整个图例。

下面的示例使用默认数据创建一个包含多个系列的簇状柱形图。它隐藏第二个系列的图例项（索引 `1`）并保存演示文稿。随后通过调用 [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) 并传入 `false` 恢复该项，并保存第二个副本。两份文件中的柱形均保持可见。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // 在不更改图表数据的情况下恢复相同的条目。
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下图比较展示了相同的图表在所有条目可见和第二条目在图例中隐藏两种情况。第二系列的柱形保持不变。

![所有图例项可见且第二系列在图例中隐藏的图表比较；所有柱形均保持可见。](hide-legend-entry.png)

在柱形、条形和折线图中，图例项标识系列。对于饼图，它们标识单个数据点（切片），因此请在选定的切片上使用 [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--)。API 为 `Pie`、`Pie3D`、`ExplodedPie`、`ExplodedPie3D`、`PieOfPie` 和 `BarOfPie` 图表类型记录了此数据点方法。不要认为它适用于环形图，因为环形图未列入此列表。

## **常见问题解答**

**我可以让图表为图例预留空间而不是覆盖它吗？**

可以。调用 [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) 并传入 `false`，即可为图例预留空间，而不是让其覆盖绘图区。

**我可以让图例标签换成多行吗？**

可以。当可用宽度不足时，长标签会自动换行。也可以在系列名称中使用换行符来实现换行。

**如何使图例遵循演示文稿主题的配色方案？**

保持图例的颜色、填充和字体未设置，使其能够继承主题格式。显式设置的格式会覆盖相应的主题设置。