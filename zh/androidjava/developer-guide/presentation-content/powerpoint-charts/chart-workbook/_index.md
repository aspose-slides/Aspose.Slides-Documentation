---
title: 图表工作簿
type: docs
weight: 70
url: /androidjava/chart-workbook/
keywords: "图表工作簿, 图表数据, PowerPoint 演示文稿, Java, Aspose.Slides for Android via Java"
description: "Java 中 PowerPoint 演示文稿中的图表工作簿"
---

## **从工作簿设置图表数据**
Aspose.Slides 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) 和 [WriteWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) 方法，允许您读取和写入图表数据工作簿（包含用 Aspose.Cells 编辑的图表数据）。**注意**，图表数据必须以相同的方式组织，或必须具有类似于源的结构。

此 Java 代码演示了一个示例操作：

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

## **将工作簿单元格设置为图表数据标签**

1. 创建 [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加带有一些数据的气泡图。
1. 访问图表系列。
1. 将工作簿单元格设置为数据标签。
1. 保存演示文稿。

此 Java 代码显示您如何将工作簿单元格设置为图表数据标签：

```java
String lbl0 = "标签 0 单元格值";
String lbl1 = "标签 1 单元格值";
String lbl2 = "标签 2 单元格值";

// 实例化表示演示文稿文件的演示文稿类
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

## **管理工作表**

此 Java 代码演示了一种操作，其中使用 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) 方法访问工作表集合：

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

## **指定数据源类型**

此 Java 代码显示您如何为数据源指定类型：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("文字字符串");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "新单元格"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **外部工作簿**

{{% alert color="primary" %}} 
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-19-4-release-notes/) 中，我们实现了将外部工作簿作为图表数据源的支持。
{{% /alert %}} 

### **创建外部工作簿**

使用 **`readWorkbookStream`** 和 **`setExternalWorkbook`** 方法，您可以从头开始创建外部工作簿或将内部工作簿设为外部。

此 Java 代码演示了外部工作簿创建过程：

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

### **设置外部工作簿**

使用 **`setExternalWorkbook`** 方法，您可以将外部工作簿分配给图表作为其数据源。此方法也可用于更新外部工作簿的路径（如果后者已移动）。

虽然您无法编辑存储在远程位置或资源中的工作簿中的数据，但仍然可以使用这些工作簿作为外部数据源。如果提供外部工作簿的相对路径，它会自动转换为完整路径。

此 Java 代码显示您如何设置外部工作簿：

```java
// 创建 Presentation 类的实例
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
    
    pres.save("带外部工作簿的演示文稿.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

`setExternalWorkbook` 方法中的 `ChartData` 参数用于指定是否将加载 Excel 工作簿。

* 当 `ChartData` 值设置为 `false` 时，仅更新工作簿路径—图表数据将不会从目标工作簿加载或更新。您可能希望在目标工作簿不存在或不可用的情况下使用此设置。
* 当 `ChartData` 值设置为 `true` 时，图表数据将从目标工作簿更新。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("带外部工作簿并更新图表数据的演示文稿.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **获取图表外部数据源工作簿路径**

1. 创建 [Presentation](https://apireference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 为图表形状创建一个对象。
1. 为源 (`ChartDataSourceType`) 类型创建一个对象，该对象表示图表的数据源。
1. 根据源类型与外部工作簿数据源类型相同指定相关条件。

此 Java 代码演示了该操作：

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// 保存演示文稿
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **编辑图表数据**

您可以以与修改内部工作簿内容相同的方式编辑外部工作簿中的数据。当无法加载外部工作簿时，将抛出异常。

此 Java 代码是所描述过程的实现：

```java
// 创建 Presentation 类的实例
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