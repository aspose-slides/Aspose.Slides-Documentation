---
title: Manage Chart Workbooks in Presentations Using Java
linktitle: Chart Workbook
type: docs
weight: 70
url: /java/chart-workbook/
keywords:
- chart workbook
- chart data
- workbook cell
- data label
- worksheet
- data source
- external workbook
- external data
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Discover Aspose.Slides for Java: effortlessly manage chart workbooks in PowerPoint and OpenDocument formats to streamline your presentation data."
---

## **Read and Write Chart Data from a Workbook**
Aspose.Slides provides the [ReadWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--) and [WriteWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) methods that allow you to read and write chart data workbooks (containing chart data edited with Aspose.Cells). **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

This Java code demonstrates a sample operation:

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set a WorkBook Cell as a Chart Data Label**

1. Create an instance of the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Add a Bubble chart with some data.
1. Access the chart series.
1. Set the workbook cell as a data label.
1. Save the presentation.

This Java code shows you to set a workbook cell as a chart data label:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Worksheets**

This Java code demonstrates an operation where the [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) method is used to access a worksheet collection:

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

## **Specify the Data Source Type**

This Java code shows you how to specify a type for a data source:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **External Workbook**

{{% alert color="primary" %}} 
In [Aspose.Slides 19.4](https://docs.aspose.com/slides/java/aspose-slides-for-java-19-4-release-notes/), we implemented support for external workbooks as a data source for charts.
{{% /alert %}} 

### **Create an External Workbook**

Using the **`readWorkbookStream`** and **`setExternalWorkbook`** methods, you can either create an external workbook from scratch or make an internal workbook external.

This Java code demonstrates the external workbook creation process:

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Set an External Workbook**

Using the **`setExternalWorkbook`** method, you can assign an external workbook to a chart as its data source. This method can also be used to update a path to the external workbook (if the latter has been moved).

While you cannot edit the data in workbooks stored in remote locations or resources, you can still use such workbooks as an external data source. If the relative path for an external workbook is provided, it gets converted to a full path automatically.

This Java code shows you how to set an external workbook:

```java
// Creates an instance of the Presentation class
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

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

### **Get the External Data Source Workbook Path of a Chart**

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
	
	// Saves the presentation
    pres.save("result.pptx", SaveFormat.Pptx);
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

## **FAQ**

**Can I determine whether a specific chart is linked to an external or an embedded workbook?**

Yes. A chart has a [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) and a [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); if the source is an external workbook, you can read the full path to make sure an external file is being used.

**Are relative paths to external workbooks supported, and how are they stored?**

Yes. If you specify a relative path, it is automatically converted to an absolute path. This is convenient for project portability; however, be aware that the presentation will store the absolute path in the PPTX file.

**Can I use workbooks located on network resources/shares?**

Yes, such workbooks can be used as an external data source. However, editing remote workbooks directly from Aspose.Slides is not supported—they can only be used as a source.

**Does Aspose.Slides overwrite the external XLSX when saving the presentation?**

No. The presentation stores a [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) and uses it for reading data. The external file itself is not modified when the presentation is saved.

**What should I do if the external file is password-protected?**

Aspose.Slides does not accept a password when linking. A common approach is to remove protection in advance or prepare a decrypted copy (for example, using [Aspose.Cells](/cells/java/)) and link to that copy.

**Can multiple charts reference the same external workbook?**

Yes. Each chart stores its own link. If they all point to the same file, updating that file will be reflected in each chart the next time the data is loaded.
