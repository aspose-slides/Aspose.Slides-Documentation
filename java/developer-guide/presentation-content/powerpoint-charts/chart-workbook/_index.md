---
title: Chart Workbook
type: docs
weight: 70
url: /java/chart-workbook/
---


## **Chart Workbook**
### **Set Chart Data from Workbook**
A new property has been added to set chart data from workbook. Now Aspose.Slides does allow [readWorkbookStream()](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--) and [wrtiteWorkbookStream()](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) methods to read and write chart data workbooks containing chart data edited using Aspose.Cells. However, the chart data needs to be organized in same way or of similar type as of source type. Below sample example is given.

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

### **Set WorkBook Cell as Chart DataLabel**
Aspose.Slides for Java provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the Bubble type.
1. Accessing the chart series.
1. Setting Workbook cell as data label.
1. Save the presentation to a PPTX file.

```java
// Create an instance of Presentation class
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

### **Get Chart External Data Source Workbook Path**
Aspose.Slides for Java provides a simple API for getting value from WorkBook Cell used as DataLabel:

1. Create an instance of the [Presentation](http://www.aspose.com/api/java/slides/com.aspose.slides/classes/Presentation) class.
1. Obtain a slide's reference by its index.
1. Create object for chart shape
1. Create object for source type of ChartDataSourceType which represents data source of the chart.
1. If Source Type is equal to external workbook the get chart external data source workbook path.

```java
// Create an instance of Presentation class
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

## **External Workbook**
{{% alert color="primary" %}} 
Aspose.Slides for Java for 19.4 supports external workbooks as a data source for charts.
{{% /alert %}} 

### **Create External Workbook**
This article demonstrates how to create an external workbook from scratch using Aspose.Slides for Java. [**IChartData.readWorkbookStream()**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--) and [**IChartData.setExternalWorkbook()**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartData#setExternalWorkbook-java.lang.String-) methods can be used to create an external workbook from scratch or to make an internal workbook external.

The implementation is demonstrated below in an example.

```java
// Create an instance of Presentation class
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
Using Aspose.Slides for Java, an external workbook can be assigned to a chart as a data source. For this purpose [**IChartData.SetExternalWorkbook**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartData#setExternalWorkbook-java.lang.String-) method has been added.

The method [**setExternalWorkbook()**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartData#setExternalWorkbook-java.lang.String-) can be also used to update a path to the external workbook if it has been moved. Workbooks placed on remote resources unavailable for data editing but still can be assigned as an external data source. If the relative path was provided for an external workbook, it converts to full path automatically.

The implementation is demonstrated below in an example.

```java
// Create an instance of Presentation class
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

The [**setExternalWorkbook(System workbookPath, boolean updateChartData)**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartData#setExternalWorkbook-java.lang.String-boolean-) method has been added with **updateChartData** parameter to the [**IChartData**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartData) interface and [**ChartData**](https://apireference.aspose.com/slides/java/com.aspose.slides/ChartData) class.

The **updateChartData** parameter defines whether an excel workbook will be loaded or not. If the value is ***false*** only the workbook path will be updated. Chart data will not be loaded and updated from the target workbook. This is useful when the target workbook does not yet exist or is not available. If the value is **true** chart data will be updated from the target workbook as the [**setExternalWorkbook(String)**](https://apireference.aspose.com/slides/java/com.aspose.slides/IChartData#setExternalWorkbook-java.lang.String-) method does.

```java
// Create an instance of Presentation class
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

### **Edit Chart Data**
Using Aspose.Slides for Java, Chart data in external workbooks can be edited the same way it works for internal workbooks. If external workbook cannot be loaded an exception is thrown.

The implementation is demonstrated below in an example.

```java
// Create an instance of Presentation class
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