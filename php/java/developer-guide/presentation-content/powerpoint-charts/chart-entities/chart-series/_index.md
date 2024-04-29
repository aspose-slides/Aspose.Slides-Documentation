---
title: Chart Series
type: docs
url: /java/chart-series/
keywords: "Chart series, series color, PowerPoint presentation, Java, Aspose.Slides for PHP via Java"
description: "Chart series in PowerPoint presentations in Java"
---

A series is a row or column of numbers plotted in a chart.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Set Chart Series Overlap**

With the [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) property, you can specify how much bars and columns should overlap on a 2D chart (range: -100 to 100). This property applies to all series of the parent series group: this is a projection of the appropriate group property. Therefore, this property is read-only. 

Use the `ParentSeriesGroup.Overlap` read/write property to set your preferred value for `Overlap`. 

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
1. Add a clustered column chart on a slide.
1. Access the first chart series.
1. Access the chart series' `ParentSeriesGroup` and set your preferred overlap value for the series. 
1. Write the modified presentation to a PPTX file.

This Java code shows you how to set the overlap for a chart series:

```java
Presentation pres = new Presentation();
try {
    // Adds chart
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Sets series overlap
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Writes the presentation file to disk
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change Series Color**
Aspose.Slides for PHP via Java allows you to change a series' color this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
1. Add chart on the slide.
1. Access the series whose color you want to change. 
1. Set your preferred fill type and fill color.
1. Save the modified presentation.

This Java code shows you how to change a series' color:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change Series Category's Color**
Aspose.Slides for PHP via Java allows you to change a series category's color this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
1. Add chart on the slide.
1. Access the series category whose color you want to change.
1. Set your preferred fill type and fill color.
1. Save the modified presentation.

This code in Java shows you how to change a series category's color:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change Series' Name** 

By default, the legend names for a chart are the contents of cells above each column or row of data. 

In our example (sample image), 

* the columns are *Series 1, Series 2,* and *Series 3*;
* the rows are *Category 1, Category 2, Category 3,* and *Category 4.* 

Aspose.Slides for PHP via Java allows you to update or change a series name in its chart data and legend.

This Java code shows you how to change a series' name in its chart data `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

This Java code shows you how to change a series name in its legend through`Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Chart Series Fill Color**

Aspose.Slides for PHP via Java allows you to set the automatic fill color for chart series inside a plot area this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data based on your preferred type (in the example below, we used `ChartType.ClusteredColumn`).
1. Access the chart series and set the fill color to Automatic.
1. Save the presentation to a PPTX file.

This Java code shows you how to set the automatic fill color for a chart series:

```java
Presentation pres = new Presentation();
try {
    // Creates a clustered column chart
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Sets series fill format to automatic
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Writes the presentation file to disk
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Chart Series Invert Fill Colors**
Aspose.Slides allows you to set the invert fill color for chart series inside a plot area this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data based on your preferred type (in the example below, we used `ChartType.ClusteredColumn`).
1. Access the chart series and set the fill color to invert.
1. Save the presentation to a PPTX file.

This Java code demonstrates the operation:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Adds new series and categories
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Takes the first chart series and populates its series data.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Set Series to Invert When Value is Negative**
Aspose.Slides allows you to set inverts through the`IChartDataPoint.InvertIfNegative` and `ChartDataPoint.InvertIfNegative` properties. When an invert is set using the properties, the data point inverts its colors when it gets a negative value. 

This Java code demonstrates the operation:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Clear Specific Data Points' Data**
Aspose.Slides for PHP via Java allows you to clear the `DataPoints` data for a specific chart series this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
2. Obtain the reference of a slide through its index.
3. Obtain the reference of a chart through its index.
4. Iterate through all the chart `DataPoints` and set `XValue` and `YValue` to null.
5. Clear all`DataPoints` for specific chart series.
6. Write the modified presentation to a PPTX file.

This Java code demonstrates the operation:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Series Gap Width**
Aspose.Slides for PHP via Java allows you to set a series' Gap Width through the **`GapWidth`** property this way:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set the `GapWidth` property.
1. Write the modified presentation to a PPTX file.

This code in Java shows you how to set a series' Gap Width:

```java
// Creates empty presentation 
Presentation pres = new Presentation();
try {
    // Accesses the presentation's first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adds a chart with default data
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Sets the index of the chart data sheet
    int defaultWorksheetIndex = 0;
    
    // Gets the chart data worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Adds series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Adds Categories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Takes the second chart series
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Populates the series data
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Sets GapWidth value
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Saves presentation to disk
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```