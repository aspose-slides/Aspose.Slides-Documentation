---
title: Chart Workbook
type: docs
weight: 70
url: /java/chart-workbook/
keywords: "Chart workbook, chart data, PowerPoint presentation, Java, Aspose.Slides for Java"
description: "Chart workbook in PowerPoint presentation in Java"
---

## **Set Chart Data from Workbook**
Aspose.Slides provides the [ReadWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--) and [WriteWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This Java code demonstrates a sample operation:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    chart.getChartData().getChartDataWorkbook().clear(0);

    Workbook workbook = new Workbook("a1.xlsx");

    ByteArrayOutputStream mem = new ByteArrayOutputStream();
    workbook.save(mem, com.aspose.cells.SaveFormat.XLSX);

    chart.getChartData().writeWorkbookStream(mem.toByteArray());

    chart.getChartData().setRange("Sheet1!$A$1:$B$9");
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("response2.pptx", SaveFormat.Pptx);
} catch (Exception ex) {
    ex.printStackTrace();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set WorkBook Cell as Chart DataLabel**

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Add a Bubble chart with some data.
1. Access the chart series.
1. Set the workbook cell as a data label.
1. Save the presentation.

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    series.getLabels().get_Item(0).setValueFromCell(wb.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(wb.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(wb.getCell(0, "A12", "Label 2 cell value"));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Worksheets**

This Java code demonstrates an operation where the [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) property is used to access a worksheet collection:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Specify Data Source Type**

This Java code shows you how to specify a type for a data source:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IChartDataPoint point = series.get_Item(0).getDataPoints().getOrCreateDataPointByIdx(2);

    // set data source type as "double literals"
    point.getValue().setDataSourceType(DataSourceType.DoubleLiterals);
    point.getValue().setAsLiteralDouble(5);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **External Workbook**

{{% alert color="primary" %}} 
In [Aspose.Slides](https://docs.aspose.com/slides/java/aspose-slides-for-java-19-4-release-notes/) 19.4, we implemented support for external workbooks as a data source for charts.
{{% /alert %}} 

### **Create External Workbook**

Using the **`readWorkbookStream`** and **`setExternalWorkbook`** methods, you can either create an external workbook from scratch or make an internal workbook external.

This Java code demonstrates the external workbook creation process:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("chart.pptx");
try {
    String externalWbPath = dataPath + "externalWorkbook1.xlsx";
    
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);

    java.io.File file = new File(externalWbPath);
    if (file.exists())
        file.delete();

    byte[] worbookData = chart.getChartData().readWorkbookStream();
    FileOutputStream outputStream = new FileOutputStream(file);
    outputStream.write(worbookData);
    outputStream.close();

    chart.getChartData().setExternalWorkbook(externalWbPath);

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Set External Workbook**

Using the **`setExternalWorkbook`** method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This Java code shows you how to set an external workbook:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook(dataPath +"externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

The `ChartData` parameter (under the `setExternalWorkbook` method) is used to specify whether an excel workbook will be loaded or not. 

* When `ChartData` value is set to `false`, only the workbook path gets updated—the chart data will not be loaded or updated from the target workbook. You may want to use this setting when in a situation where the target workbook is nonexistent or unavailable. 
* When `ChartData` value is set to `true` , the chart data gets updated from the target workbook.

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Get Chart External Data Source Workbook Path**

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Create an object for the chart shape.
1. Create an object for the source (`ChartDataSourceType`) type that represents the chart's data source.
1. Specify the relevant condition based on the source type being the same as the external workbook data source type.

This Java code demonstrates the operation:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **Edit Chart Data**

You can edit the data in external workbooks the same way you make changes to the contents of internal workbooks. When an external workbook cannot be loaded, an exception is thrown.

This Java code is an implementation of the described process:

```java
// Creates an instance of tthe Presentation class
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```