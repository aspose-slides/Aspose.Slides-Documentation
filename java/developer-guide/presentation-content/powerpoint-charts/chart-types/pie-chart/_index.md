---
title: Pie Chart
type: docs
url: /java/pie-chart/
---

## **Second Plot Options for Pie of Pie and Bar of Pie Chart**
Aspose.Slides for Java now supports second plot options for Pie of Pie or Bar of Pie chart. In this topic, we will show you how to specify those options using Aspose.Slides. To specify the properties, do this:

1. Instantiate [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. Specify the second plot options of chart.
1. Write presentation to disk.

In the example given below, we have set different properties of Pie of Pie chart.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Add chart on slide
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Set different properties
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Write presentation to disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Automatic Pie Chart Slice Colors**
Aspose.Slides for Java provides a simple API for setting automatic pie chart slide colors. The sample code applies setting the above said properties.

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. Access first slide.
1. Add chart with default data.
1. Set chart Title.
1. Set first series to Show Values.
1. Set the index of chart data sheet.
1. Getting the chart data worksheet.
1. Delete default generated series and categories.
1. Add new categories.
1. Add new series.

Write the modified presentation to a PPTX file.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    // Add chart with default data
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Setting chart Title
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Set first series to Show Values
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Setting the index of chart data sheet
    int defaultWorksheetIndex = 0;

    // Getting the chart data worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Delete default generated series and categories
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Adding new categories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Adding new series
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Now populating series data
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```