---
title: Customize Pie Charts in Presentations Using JavaScript
linktitle: Pie Chart
type: docs
url: /nodejs-java/pie-chart/
keywords:
- pie chart
- manage chart
- customize chart
- chart options
- chart settings
- plot options
- slice color
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Learn how to create and customize pie charts in JavaScript with Aspose.Slides for Node.js, exportable to PowerPoint, boosting your data storytelling in seconds."
---

## **Second Plot Options for Pie of Pie and Bar of Pie Chart**
Aspose.Slides for Node.js via Java now supports second plot options for Pie of Pie or Bar of Pie chart. In this topic, we will show you how to specify those options using Aspose.Slides. To specify the properties, do this:

1. Instantiate [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class object.
1. Add chart on the slide.
1. Specify the second plot options of chart.
1. Write presentation to disk.

In the example given below, we have set different properties of Pie of Pie chart.

```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Add chart on slide
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Set different properties
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Write presentation to disk
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Automatic Pie Chart Slice Colors**
Aspose.Slides for Node.js via Java provides a simple API for setting automatic pie chart slide colors. The sample code applies setting the above said properties.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
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

```javascript
// Create an instance of Presentation class
var pres = new aspose.slides.Presentation();
try {
    // Add chart with default data
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Setting chart Title
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Set first series to Show Values
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Setting the index of chart data sheet
    var defaultWorksheetIndex = 0;
    // Getting the chart data worksheet
    var fact = chart.getChartData().getChartDataWorkbook();
    // Delete default generated series and categories
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Adding new categories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Adding new series
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Now populating series data
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Are the 'Pie of Pie' and 'Bar of Pie' variations supported?**

Yes, the library [supports](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) a secondary plot for pie charts, including the 'Pie of Pie' and 'Bar of Pie' types.

**Can I export just the chart as an image (for example, PNG)?**

Yes, you can [export the chart itself as an image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (such as PNG) without the entire presentation.
