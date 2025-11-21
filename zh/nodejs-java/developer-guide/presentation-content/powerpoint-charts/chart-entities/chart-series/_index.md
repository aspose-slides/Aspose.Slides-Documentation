---
title: 图表系列
type: docs
url: /zh/nodejs-java/chart-series/
keywords: "图表系列, 系列颜色, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "JavaScript 中 PowerPoint 演示文稿的图表系列"
---

系列是绘制在图表中的一行或一列数字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

使用 [ChartSeries.getOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) 方法，您可以指定 2D 图表中条形和柱形的重叠程度（范围：-100 到 100）。此属性适用于父系列组的所有系列：它是相应组属性的投影。因此，此属性为只读。

使用 `ParentSeriesGroup.getOverlap` 可读写属性来设置您偏好的 `Overlap` 值。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 在幻灯片上添加一个簇状柱形图。  
3. 访问第一个图表系列。  
4. 访问该系列的 `ParentSeriesGroup` 并为系列设置您偏好的重叠值。  
5. 将修改后的演示文稿写入 PPTX 文件。

此 JavaScript 代码示例演示了如何为图表系列设置重叠：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 添加图表
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // 设置系列重叠
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // 将演示文稿文件写入磁盘
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **更改系列颜色**

Aspose.Slides for Node.js via Java 允许您按以下方式更改系列的颜色：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 在幻灯片上添加图表。  
3. 访问您要更改颜色的系列。  
4. 设置您偏好的填充类型和填充颜色。  
5. 保存修改后的演示文稿。

此 JavaScript 代码示例演示了如何更改系列颜色：
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **更改系列类别的颜色**

Aspose.Slides for Node.js via Java 允许您按以下方式更改系列类别的颜色：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 在幻灯片上添加图表。  
3. 访问您要更改颜色的系列类别。  
4. 设置您偏好的填充类型和填充颜色。  
5. 保存修改后的演示文稿。

此 JavaScript 代码示例演示了如何更改系列类别的颜色：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **更改系列名称** 

默认情况下，图表的图例名称是每列或每行数据上方单元格的内容。

在我们的示例（示例图像）中，

* 列分别为 *Series 1, Series 2,* 和 *Series 3*；  
* 行分别为 *Category 1, Category 2, Category 3,* 和 *Category 4*。

Aspose.Slides for Node.js via Java 允许您在图表数据和图例中更新或更改系列名称。

此 JavaScript 代码示例演示了如何在其图表数据 `ChartDataWorkbook` 中更改系列名称：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


此 JavaScript 代码示例演示了如何通过 `Series` 在图例中更改系列名称：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置图表系列填充颜色**

Aspose.Slides for Node.js via Java 允许您按以下方式为绘图区域内的图表系列设置自动填充颜色：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 根据您偏好的类型（示例中使用 `ChartType.ClusteredColumn`）添加带有默认数据的图表。  
4. 访问图表系列并将填充颜色设为 Automatic。  
5. 将演示文稿保存为 PPTX 文件。

此 JavaScript 代码示例演示了如何为图表系列设置自动填充颜色：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 创建簇状柱形图
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // 将系列填充格式设置为自动
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // 将演示文稿文件写入磁盘
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置图表系列反转填充颜色**

Aspose.Slides 允许您按以下方式为绘图区域内的图表系列设置反转填充颜色：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 根据您偏好的类型（示例中使用 `ChartType.ClusteredColumn`）添加带有默认数据的图表。  
4. 访问图表系列并将填充颜色设为 invert。  
5. 将演示文稿保存为 PPTX 文件。

此 JavaScript 代码演示了该操作：
```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // 添加新的系列和类别
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // 获取第一个图表系列并填充其系列数据。
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **当值为负时设置系列反转**

Aspose.Slides 允许您通过 `ChartDataPoint.setInvertIfNegative` 方法设置反转。当通过属性设置反转时，数据点在获得负值时会反转其颜色。

此 JavaScript 代码演示了该操作：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **清除特定数据点的数据**

Aspose.Slides for Node.js via Java 允许您按以下方式清除特定图表系列的 `DataPoints` 数据：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 通过索引获取图表的引用。  
4. 遍历所有图表 `DataPoints` 并将 `XValue` 和 `YValue` 设为 null。  
5. 为特定图表系列清除所有`DataPoints`。  
6. 将修改后的演示文稿写入 PPTX 文件。

此 JavaScript 代码演示了该操作：
```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置系列间隙宽度**

Aspose.Slides for Node.js via Java 允许您通过 **`GapWidth`** 属性设置系列的间隙宽度：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。  
2. 访问第一张幻灯片。  
3. 添加带有默认数据的图表。  
4. 访问任意图表系列。  
5. 设置 `GapWidth` 属性。  
6. 将修改后的演示文稿写入 PPTX 文件。

此 JavaScript 代码示例演示了如何设置系列的间隙宽度：
```javascript
// Creates empty presentation
var pres = new aspose.slides.Presentation();
try {
    // Accesses the presentation's first slide
    var slide = pres.getSlides().get_Item(0);
    // Adds a chart with default data
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Sets the index of the chart data sheet
    var defaultWorksheetIndex = 0;
    // Gets the chart data worksheet
    var fact = chart.getChartData().getChartDataWorkbook();
    // Adds series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Adds Categories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Takes the second chart series
    var series = chart.getChartData().getSeries().get_Item(1);
    // Populates the series data
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Sets GapWidth value
    series.getParentSeriesGroup().setGapWidth(50);
    // Saves presentation to disk
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**单个图表可以包含的系列数量是否有限制？**

Aspose.Slides 对您添加的系列数量没有固定上限。实际限制取决于图表的可读性以及您的应用程序可用的内存。

**如果簇内的柱形之间间距过近或过远怎么办？**

调整该系列（或其父系列组）的 Gap Width 设置。增大数值会扩大柱形之间的间距，减小数值则会使它们更靠近。