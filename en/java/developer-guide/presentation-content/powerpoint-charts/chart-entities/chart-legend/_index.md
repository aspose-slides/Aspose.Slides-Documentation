---
title: Customize Chart Legends in Presentations Using Java
linktitle: Chart Legend
type: docs
url: /java/chart-legend/
keywords:
- chart legend
- legend position
- font size
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Customize chart legends with Aspose.Slides for Java to optimize PowerPoint presentations with tailored legend formatting."
---

## **Overview**

Aspose.Slides for Java provides options for customizing chart legends in PowerPoint presentations. This article shows how to position and size a legend, set the font size for the whole legend, format an individual legend entry, and hide or restore selected entries.

The FAQ covers related behaviors, including reserving space for the legend, displaying multiline labels, and inheriting formatting from the presentation theme.

## **Legend Positioning**

Use the legend's [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), and [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) methods to specify its position and size as fractions of the chart's dimensions.

This example creates a presentation and adds a clustered column chart with default data to the first slide. Dividing the desired legend offsets and dimensions by the chart's width and height converts them to relative values: the legend is offset by 50 points from the chart's top-left corner and sized to 100 by 100 points.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Express the legend's position and size relative to the chart.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Font Size of a Legend**

Use the legend's [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) to access its text formatting and use [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) to set the font size in points.

This example creates a chart with default data and sets the legend text to 20 points. It also disables automatic bounds for the vertical axis and sets its range to -5 through 10.

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

## **Set the Font Size of an Individual Legend Entry**

Use the collection returned by the legend's [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) method to access formatting for a specific entry. Entry indices are zero-based, so index `1` refers to the second entry.

This example creates a clustered column chart whose default data includes at least two series. It formats the second legend entry with bold, italic, and 20-point blue text.

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

## **Hide Individual Legend Entries**

To exclude an auxiliary series from the legend while keeping its data visible, call [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) with `true` through [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). This hides only the selected legend entry; it does not remove the series or its data points. Calling [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) with `false`, in contrast, hides the entire legend.

The example below creates a clustered column chart with multiple series using default data. It hides the second series' legend entry (index `1`) and saves the presentation. It then restores the entry by calling [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) with `false` and saves a second copy. The columns remain visible in both files.

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

    // Restore the same entry without changing the chart data.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The comparison below shows the same chart with all entries visible and with the second entry hidden. The second series' columns remain unchanged.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

In column, bar, and line charts, legend entries identify series. For pie charts, they identify individual data points (slices), so use [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) on the selected slice instead. The API documents this data-point method for the `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, and `BarOfPie` chart types. Do not assume it applies to doughnut charts, which are not included in that list.

## **FAQ**

**Can I make the chart allocate space for the legend instead of overlaying it?**

Yes. Call [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) with `false` to reserve space for the legend instead of allowing it to overlap the plot area.

**Can I make multiline legend labels?**

Yes. Long labels can wrap when the available width is insufficient. You can also use newline characters in series names to request line breaks.

**How do I make the legend follow the presentation theme's color scheme?**

Leave the legend's colors, fills, and fonts unset so that it can inherit theme formatting. Explicit formatting overrides the corresponding theme settings.
