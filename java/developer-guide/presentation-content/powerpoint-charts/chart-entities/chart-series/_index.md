---
title: Chart Series
type: docs
url: /java/chart-series/
---


## **Set Chart Series Overlap**
Aspose.Slides for Java provides a simple API interface to set chart series overlap. The [**IChartSeries.getOverlap**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getOverlap--) method specifies how much bars and columns should overlap on 2D charts (in a range from -100 to 100). This method is not only for the referred series but for all series of the parent series group: this is projection of the appropriate group property. Therefore, this property is read-only. Use the [**getParentSeriesGroup**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getParentSeriesGroup--) method to access the parent series group, and then access the [**ParentSeriesGroup.getOverlap**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#getOverlap--) or [**ParentSeriesGroup.setOverlap**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeriesGroup#setOverlap-byte-) method to change or read the value.

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Add a clustered column chart on a slide.
1. Access the first chart series.
1. Access the selected serie's [**getParentSeriesGroup**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getParentSeriesGroup--) and set the chart series overlap value.
1. Write the modified presentation to a PPTX file.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Adding chart
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    if (series.get_Item(0).getOverlap() == 0) {
        // Setting series overlap
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte) -30);
    }

    // Saving presentation
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Change Series Color**
Aspose.Slides for Java provides support for changing series color. 

1. Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

Below sample example is given. 

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
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

## **Change Color of Categories in Series**
Aspose.Slides for Java provides support for changing color of categories in a series color. 

1. Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. Access specific series of chart.
1. Set fill type and fill color.
1. Save modified presentation.

Below sample example is given. 

```java
// Create an instance of Presentation class
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

## **Set Chart Series Fill Colors**
Aspose.Slides for Java provides a simple API for setting automatic fill color for chart series inside plot area:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Accessing the chart series and setting the fill color to Automatic.
1. Save the presentation to a PPTX file.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Creating a clustered column chart
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Setting series fill format to automatic
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Saving presentation
    pres.save("AutoFillSeries.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Chart Series Invert Fill Colors**
Aspose.Slides for Java provides a simple API for setting invert fill color for chart series inside plot area:

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the any of desired type (this example uses **ChartType.ClusteredColumn**).
1. Accessing the chart series and setting the fill color to invert.
1. Save the presentation to a PPTX file.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Adding new series and categories
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Take first chart series and populating series data.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    
    Color seriesColor = series.getAutomaticSeriesColor();
    
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Invert If Negative Property for Individual Series**
The Aspose.Slides for Java lets developers allow to set inverts. Methods [**setInvertIfNegative**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#setInvertIfNegative-boolean-) and [**getInvertIfNegative**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getInvertIfNegative--) methods have been added to [IChartDataPoint](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint) interface and [ChartDataPoint](https://apireference.aspose.com/slides/java/com.aspose.slides/ChartDataPoint) class. This Specifies the data point shall invert its colors if the value is negative. Sample code is given below.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    series.get_Item(0).getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2",-5));
    series.get_Item(0).getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3",3));
    series.get_Item(0).getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4",-2));
    series.get_Item(0).getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5",1));

    series.get_Item(0).setInvertIfNegative(false);
    series.get_Item(0).getInvertIfNegative();
    series.get_Item(0).getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clear Specific Chart Series Data Points Data**
Aspose.Slides for Java provides a simple API to clear specific chart series [**DataPoints**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint) data. To clear specific chart series [**DataPoints**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint) data, please follow the steps below:

- Create an instance of Presentation class and load the desired presentation.
- Obtain the reference of a slide by using its Index
- Obtain the reference of a chart by using its Index
- Iterate through all the [**DataPoints**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getDataPoints--) of chart and set [**XValue**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getXValue--) and [**YValue**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartDataPoint#getYValue--) to null.
- Remove all [**DataPoints**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getDataPoints--) of specific chart series
- Write the modified presentation to a PPTX file

Sample code is given below.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation("Chart.pptx");
try {
    // Accessing the first slide in presentation
    ISlide slide = pres.getSlides().get_Item(0);

    IChart chart = (IChart)slide.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints()) {

        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set GapWidth Property of Chart Series**
Aspose.Slides for Java provides a simple API for setting [**gapWidth**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getGapWidth--) property. The sample code applies setting the [**gapWidth**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartSeries#getGapWidth--) property.

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Access any chart series.
1. Set GapWidth property.
1. Write the modified presentation to a PPTX file.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Access first slide
    ISlide sld = pres.getSlides().get_Item(0);

    // Add chart with default data
    IChart chart = sld.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);

    // Setting the index of chart data sheet
    int defaultWorksheetIndex = 0;
    
    // Getting the chart data worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Add series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Add Catrgories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Take second chart series
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Now populating series data
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Set GapWidth value
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Save presentation with chart
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```