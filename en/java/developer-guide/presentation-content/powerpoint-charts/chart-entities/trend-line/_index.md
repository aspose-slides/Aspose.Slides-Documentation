---
title: Add Trend Lines to Presentation Charts in Java
linktitle: Trend Line
type: docs
url: /java/trend-line/
keywords:
- chart
- trend line
- exponential trend line
- linear trend line
- logarithmic trend line
- moving average trend line
- polynomial trend line
- power trend line
- custom trend line
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Quickly add and customize trend lines in PowerPoint charts with Aspose.Slides for Java — a practical guide to engage your audience."
---

## **Overview**

This article explains how to add trend lines to presentation charts by using Aspose.Slides. It shows how to create a chart, add trend lines to chart series, and work with several trend line types, including exponential, linear, logarithmic, moving average, polynomial, and power.

It also describes how to add a custom line to a chart by inserting a line shape, and includes a short FAQ about forward and backward trend line projection values and whether trend lines are preserved during export to PDF or SVG and when rendering charts as images.

## **Add a Trend Line**

Use [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) to add a trend line to a chart series, selecting its type with [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). The example creates a clustered column chart with default data and adds two trend lines to each of its three series.

The exponential trend line hides its equation and R-squared value through [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) and [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), while the linear trend line is red. The logarithmic trend line uses [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) for a custom label. The moving average uses a [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) of three data points and a custom [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

The polynomial trend line has an [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) of three and extends one category forward through [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). The power trend line extends one category backward through [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set a Trend Line Intercept**

Use [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) to fix a trend line's Y value at X = 0. This setting is supported for linear, exponential, and polynomial trend lines.

For example, a production cost model may need to start at known fixed costs of 100, even when measurements at nonzero production volumes suggest a different baseline. For a linear trend line, fixing the intercept constrains the equation `y = ax + b` to `b = 100`; the slope is fitted to the data under that constraint. It does not simply move an already fitted line. Axis crossing settings control where the chart axes meet, not the coefficients of the fitted trend line.

The following example creates a scatter (XY) chart with production volumes from 1 to 4 and costs of 170, 200, 230, and 260. It saves the chart with the default automatic intercept, sets the intercept to 100, and saves a second PPTX. The two files differ only in the intercept setting. The trend line displays its equation and extends back to X = 0.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

With automatic calculation, these data produce `y = 30x + 140`. Setting the intercept to 100 instead produces approximately `y = 43.33x + 100`: the fitted value at zero matches the known baseline, while the line no longer passes through every data point.

| Automatic intercept | Fixed intercept of 100 |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

Both images use the same data and axis scales. The trend lines are extended back to X = 0 to show their intercepts.

By default, [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) returns `Double.NaN`, which represents an unspecified intercept rather than zero. The intercept is then calculated automatically from the data.

## **Add a Custom Line**

A custom line is a shape drawn over the chart rather than a trend line calculated from series data. This example uses [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) to add a horizontal line to the slide over the chart. The line's position is specified in slide coordinates, measured in points, so it starts at the chart's left edge and sits halfway down the chart. Its width matches the chart's width. The [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) gives the line a solid red color.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**What do 'forward' and 'backward' mean for a trend line?**

They are the lengths of the trend line projected forward/backward: for scatter (XY) charts — in axis units; for non-scatter charts — in number of categories. Only non-negative values are allowed.

**Will the trend line be preserved when exporting the presentation to PDF or SVG, or when rendering a slide to an image?**

Yes. Aspose.Slides converts presentations to [PDF](/slides/java/convert-powerpoint-to-pdf/) or [SVG](/slides/java/render-a-slide-as-an-svg-image/) and renders charts to images; trend lines, as part of the chart, are preserved during these operations. A method is also available to [export an image of the chart](/slides/java/create-shape-thumbnails/) itself.
