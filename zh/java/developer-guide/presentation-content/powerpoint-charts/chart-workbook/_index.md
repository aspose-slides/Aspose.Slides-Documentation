---
title: 使用 Java 在演示文稿中管理图表工作簿
linktitle: 图表工作簿
type: docs
weight: 70
url: /zh/java/chart-workbook/
keywords:
- 图表工作簿
- 图表数据
- 工作簿单元格
- 数据标签
- 工作表
- 数据源
- 外部工作簿
- 外部数据
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "发现 Aspose.Slides for Java：轻松在 PowerPoint 和 OpenDocument 格式中管理图表工作簿，以简化您的演示文稿数据。"
---

## **设置工作簿的图表数据**
Aspose.Slides 提供了 [ReadWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#readWorkbookStream--) 和 [WriteWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) 方法，允许您读取和写入图表数据工作簿（包含使用 Aspose.Cells 编辑的图表数据）。**注意**，图表数据必须以相同的方式组织，或具有与源相似的结构。

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


## **将工作簿单元格设为图表数据标签**
1. 创建一个 [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个带有一些数据的气泡图。  
4. 访问图表系列。  
5. 将工作簿单元格设为数据标签。  
6. 保存演示文稿。  

此 Java 代码演示如何将工作簿单元格设为图表数据标签：
```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// 实例化一个表示演示文件的 Presentation 类
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
此 Java 代码演示使用 [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) 方法访问工作表集合的操作：
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
此 Java 代码展示了如何为数据源指定类型：
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


## **外部工作簿**
{{% alert color="primary" %}} 
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/java/aspose-slides-for-java-19-4-release-notes/) 中，我们实现了对外部工作簿作为图表数据源的支持。 
{{% /alert %}} 

### **创建外部工作簿**
使用 **`readWorkbookStream`** 和 **`setExternalWorkbook`** 方法，您可以从头创建外部工作簿，也可以将内部工作簿设为外部工作簿。

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
使用 **`setExternalWorkbook`** 方法，您可以将外部工作簿分配给图表作为其数据源。此方法还可用于更新外部工作簿的路径（如果后者已移动）。

虽然不能编辑存储在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供了外部工作簿的相对路径，它会自动转换为完整路径。

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
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


`setExternalWorkbook` 方法下的 `ChartData` 参数用于指定是否加载 Excel 工作簿。

* 当 `ChartData` 值设为 `false` 时，仅更新工作簿路径——图表数据不会从目标工作簿加载或更新。当目标工作簿不存在或不可用时，可使用此设置。  
* 当 `ChartData` 值设为 `true` 时，图表数据会从目标工作簿更新。  

```java
// 创建 Presentation 类的实例
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


### **获取图表外部数据源工作簿路径**
1. 创建一个 [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 为图表形状创建对象。  
4. 创建表示图表数据源的源 (`ChartDataSourceType`) 类型对象。  
5. 根据源类型与外部工作簿数据源类型相同的条件指定相关条件。  

此 Java 代码演示上述操作：
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
您可以像编辑内部工作簿内容一样编辑外部工作簿的数据。当外部工作簿无法加载时，会抛出异常。

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


## **FAQ**
**我如何判断特定图表是链接到外部工作簿还是嵌入式工作簿？**  
是的。图表具有 [数据源类型](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) 和 [外部工作簿路径](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)；如果源是外部工作簿，您可以读取完整路径以确认使用的是外部文件。

**是否支持外部工作簿的相对路径，且它们是如何存储的？**  
是的。如果指定相对路径，系统会自动将其转换为绝对路径。这对于项目可移植性很方便；但请注意，演示文稿会在 PPTX 文件中存储绝对路径。

**我可以使用位于网络资源/共享上的工作簿吗？**  
可以，这类工作簿可以用作外部数据源。但 Aspose.Slides 不支持直接编辑远程工作簿——只能作为数据源使用。

**保存演示文稿时，Aspose.Slides 会覆盖外部 XLSX 吗？**  
不会。演示文稿仅存储指向外部文件的 [链接](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)，用于读取数据。保存演示文稿时不会修改外部文件本身。

**如果外部文件受密码保护该怎么办？**  
Aspose.Slides 在链接时不接受密码。常见做法是事先移除保护或准备一个已解密的副本（例如使用 [Aspose.Cells](/cells/java/)），然后链接该副本。

**多个图表可以引用同一个外部工作簿吗？**  
可以。每个图表都会存储自己的链接。如果它们都指向同一文件，更新该文件后，下次加载数据时所有图表都会反映更改。