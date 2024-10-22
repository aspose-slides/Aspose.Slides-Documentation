---
title: Chart Workbook
type: docs
weight: 70
url: /nodejs-java/chart-workbook/
keywords: "Chart workbook, chart data, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Chart workbook in PowerPoint presentation in Javascript"
---

## **Set Chart Data from Workbook**
Aspose.Slides provides the [ReadWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) and [WriteWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This Javascript code demonstrates a sample operation:

```javascript
    var pres = new aspose.slides.Presentation("chart.pptx");
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        var data = chart.getChartData();
        var stream = data.readWorkbookStream();
        data.getSeries().clear();
        data.getCategories().clear();
        data.writeWorkbookStream(stream);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Set WorkBook Cell as Chart DataLabel**

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Add a Bubble chart with some data.
1. Access the chart series.
1. Set the workbook cell as a data label.
1. Save the presentation.

This Javascript code shows you to set a workbook cell as a chart data label:

```javascript
    var lbl0 = "Label 0 cell value";
    var lbl1 = "Label 1 cell value";
    var lbl2 = "Label 2 cell value";
    // Instantiates a presentation class that represents a presentation file
    var pres = new aspose.slides.Presentation("chart2.pptx");
    try {
        var slide = pres.getSlides().get_Item(0);
        var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
        var series = chart.getChartData().getSeries();
        var dataLabelCollection = series.get_Item(0).getLabels();
        dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
        var wb = chart.getChartData().getChartDataWorkbook();
        dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
        dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
        dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
        pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Manage Worksheets**

This Javascript code demonstrates an operation where the [ChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) method is used to access a worksheet collection:

```javascript
    var pres = new aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
        var wb = chart.getChartData().getChartDataWorkbook();
        for (var i = 0; i < wb.getWorksheets().size(); i++) {
            console.log(wb.getWorksheets().get_Item(i).getName());
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Specify Data Source Type**

This Javascript code shows you how to specify a type for a data source:

```javascript
    var pres = new aspose.slides.Presentation();
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
        var val = chart.getChartData().getSeries().get_Item(0).getName();
        val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
        val.setData("LiteralString");
        val = chart.getChartData().getSeries().get_Item(1).getName();
        val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
        pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **External Workbook**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-19-4-release-notes/), we implemented support for external workbooks as a data source for charts.
{{% /alert %}} 

### **Create External Workbook**

Using the **`readWorkbookStream`** and **`setExternalWorkbook`** methods, you can either create an external workbook from scratch or make an internal workbook external.

This Javascript code demonstrates the external workbook creation process:

```javascript
    var pres = new aspose.slides.Presentation();
    try {
        final var workbookPath = "externalWorkbook1.xlsx";
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
        try {
            var workbookData = chart.getChartData().readWorkbookStream();
            fileStream.write(workbookData, 0, workbookData.length);
        } finally {
            if (fileStream != null) {
                fileStream.close();
            }
        }
        chart.getChartData().setExternalWorkbook(workbookPath);
        pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (e) {console.log(e);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

### **Set External Workbook**

Using the **`setExternalWorkbook`** method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This Javascript code shows you how to set an external workbook:

```javascript
    // Creates an instance of the Presentation class
    var pres = new aspose.slides.Presentation("chart.pptx");
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
        var chartData = chart.getChartData();
        chartData.setExternalWorkbook("externalWorkbook.xlsx");
        chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
        chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
        chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
        chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
        chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
        chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
        chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
        pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

The `ChartData` parameter (under the `setExternalWorkbook` method) is used to specify whether an excel workbook will be loaded or not. 

* When `ChartData` value is set to `false`, only the workbook path gets updated—the chart data will not be loaded or updated from the target workbook. You may want to use this setting when in a situation where the target workbook is nonexistent or unavailable. 
* When `ChartData` value is set to `true` , the chart data gets updated from the target workbook.

```javascript
    // Creates an instance of the Presentation class
    var pres = new aspose.slides.Presentation("chart.pptx");
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
        var chartData = chart.getChartData();
        chartData.setExternalWorkbook("http://path/doesnt/exists", false);
        pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

### **Get Chart External Data Source Workbook Path**

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Create an object for the chart shape.
1. Create an object for the source (`ChartDataSourceType`) type that represents the chart's data source.
1. Specify the relevant condition based on the source type being the same as the external workbook data source type.

This Javascript code demonstrates the operation:

```javascript
    // Creates an instance of the Presentation class
    var pres = new aspose.slides.Presentation("chart.pptx");
    try {
        var slide = pres.getSlides().get_Item(1);
        var chart = slide.getShapes().get_Item(0);
        var sourceType = chart.getChartData().getDataSourceType();
        if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            var path = chart.getChartData().getExternalWorkbookPath();
        }
        // Saves the presentation
        pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

### **Edit Chart Data**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

This Javascript code is an implementation of the described process:

```javascript
    // Creates an instance of tthe Presentation class
    var pres = new aspose.slides.Presentation("chart.pptx");
    try {
        var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
        var chartData = chart.getChartData();
        chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
        pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
