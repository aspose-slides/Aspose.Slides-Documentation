---
title: 图表工作簿
type: docs
weight: 70
url: /zh/nodejs-java/chart-workbook/
keywords: "图表工作簿, 图表数据, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "JavaScript 中 PowerPoint 演示文稿的图表工作簿"
---

## **设置工作簿的图表数据**
Aspose.Slides 提供了 [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) 和 [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) 方法，允许您读取和写入图表数据工作簿（其中包含使用 Aspose.Cells 编辑的图表数据）。**注意**，图表数据必须以相同的方式组织，或其结构必须类似于源。

以下 JavaScript 代码演示了一个示例操作：
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


## **将工作簿单元格设为图表数据标签**
1. 创建一个 [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有数据的气泡图。
1. 访问图表系列。
1. 将工作簿单元格设置为数据标签。
1. 保存演示文稿。

以下 JavaScript 代码演示如何将工作簿单元格设置为图表数据标签：
```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// 实例化表示演示文件的 Presentation 类
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


## **管理工作表**
以下 JavaScript 代码演示了使用 [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) 方法访问工作表集合的操作：
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


## **指定数据源类型**
以下 JavaScript 代码演示如何为数据源指定类型：
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


## **外部工作簿**
{{% alert color="primary" %}} 
在 [Aspose.Slides 19.4](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-19-4-release-notes/) 中，我们实现了对外部工作簿作为图表数据源的支持。
{{% /alert %}} 

### **创建外部工作簿**
使用 **`readWorkbookStream`** 和 **`setExternalWorkbook`** 方法，您可以从头创建外部工作簿，或将内部工作簿设为外部工作簿。

以下 JavaScript 代码演示外部工作簿的创建过程：
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


### **设置外部工作簿**
使用 **`setExternalWorkbook`** 方法，您可以将外部工作簿分配给图表作为其数据源。此方法还可用于更新外部工作簿的路径（如果工作簿已移动）。

虽然无法编辑存放在远程位置或资源中的工作簿数据，但仍可将此类工作簿用作外部数据源。如果提供外部工作簿的相对路径，它会自动转换为完整路径。

以下 JavaScript 代码演示如何设置外部工作簿：
```javascript
// 创建 Presentation 类的实例
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


`ChartData` 参数（位于 `setExternalWorkbook` 方法下）用于指定是否加载 Excel 工作簿。

* 当 `ChartData` 值设置为 `false` 时，仅更新工作簿路径——图表数据不会从目标工作簿加载或更新。当目标工作簿不存在或不可用时，您可能需要使用此设置。  
* 当 `ChartData` 值设置为 `true` 时，图表数据会从目标工作簿更新。  
```javascript
// 创建 Presentation 类的实例
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


### **获取图表外部数据源工作簿路径**
1. 创建一个 [Presentation](https://apireference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 为图表形状创建对象。
1. 为表示图表数据源的源（`ChartDataSourceType`）类型创建对象。
1. 根据源类型与外部工作簿数据源类型相同的情况指定相关条件。

以下 JavaScript 代码演示此操作：
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // 保存演示文稿
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **编辑图表数据**
您可以像编辑内部工作簿内容一样编辑外部工作簿中的数据。若无法加载外部工作簿，将抛出异常。

以下 JavaScript 代码实现了上述过程：
```javascript
// 创建 Presentation 类的实例
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


## **常见问题**
**我能判断特定图表是链接到外部工作簿还是嵌入的工作簿吗？**  
可以。图表具有 [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) 和 [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/)；如果源是外部工作簿，您可以读取完整路径以确认正在使用外部文件。

**是否支持外部工作簿的相对路径？它们如何存储？**  
是的。如果指定相对路径，它会自动转换为绝对路径。这有助于项目可移植性；但请注意，演示文稿会在 PPTX 文件中存储绝对路径。

**我可以使用位于网络资源/共享上的工作簿吗？**  
可以，这类工作簿可用作外部数据源。但不支持直接从 Aspose.Slides 编辑远程工作簿——它们只能作为数据源使用。

**Aspose.Slides 在保存演示文稿时会覆盖外部 XLSX 吗？**  
不会。演示文稿存储对外部文件的 [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) 并用于读取数据。保存演示文稿时不会修改外部文件本身。

**如果外部文件受密码保护，我该怎么办？**  
Aspose.Slides 在链接时不接受密码。常见做法是事先解除保护或准备一个已解密的副本（例如使用 [Aspose.Cells](/cells/nodejs-java/)），并链接到该副本。

**多个图表可以引用同一个外部工作簿吗？**  
可以。每个图表存储自己的链接。如果它们都指向同一文件，更新该文件后，下次加载数据时每个图表都会体现该更改。