---
title: 图表系列
type: docs
url: /zh/java/chart-series/
keywords: "图表系列, 系列颜色, PowerPoint演示文稿, Java, Aspose.Slides for Java"
description: "Java中PowerPoint演示文稿的图表系列"
---

系列是绘制在图表中的一行或一列数字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

通过 [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) 属性，您可以指定在二维图表上条形和柱形的重叠程度（范围：-100 到 100）。该属性适用于父系列组的所有系列：这是适当组属性的投影。因此，该属性是只读的。

使用 `ParentSeriesGroup.Overlap` 读/写属性设置您的首选 `Overlap` 值。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 在幻灯片上添加一个聚簇柱形图。
1. 访问第一个图表系列。
1. 访问图表系列的 `ParentSeriesGroup` 并设置您首选的系列重叠值。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码展示了如何为图表系列设置重叠：

```java
Presentation pres = new Presentation();
try {
    // 添加图表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // 设置系列重叠
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // 将演示文稿文件写入磁盘
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改系列颜色**
Aspose.Slides for Java 允许您以以下方式更改系列颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 在幻灯片上添加图表。
1. 访问您想要更改颜色的系列。
1. 设置您首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

以下 Java 代码展示了如何更改系列的颜色：

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改系列类别的颜色**
Aspose.Slides for Java 允许您以以下方式更改系列类别的颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 在幻灯片上添加图表。
1. 访问您想要更改颜色的系列类别。
1. 设置您首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

以下 Java 代码展示了如何更改系列类别的颜色：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改系列名称**

默认情况下，图表的图例名称是每个数据列或行上方单元格的内容。

在我们的示例中（示例图像），

* 列为 *系列 1、系列 2* 和 *系列 3*；
* 行为 *类别 1、类别 2、类别 3* 和 *类别 4*。

Aspose.Slides for Java 允许您更新或更改图表数据和图例中的系列名称。

以下 Java 代码展示了如何在其图表数据 `ChartDataWorkbook` 中更改系列名称：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("新名称");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

以下 Java 代码展示了如何通过 `Series` 更改系列名称在其图例中：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("新名称");
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置图表系列填充颜色**

Aspose.Slides for Java 允许您以以下方式设置图表系列的自动填充颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 根据您首选的类型添加带有默认数据的图表（在下面的示例中，我们使用了 `ChartType.ClusteredColumn`）。
1. 访问图表系列并将填充颜色设置为自动。
1. 将演示文稿保存为 PPTX 文件。

以下 Java 代码展示了如何为图表系列设置自动填充颜色：

```java
Presentation pres = new Presentation();
try {
    // 创建聚簇柱形图
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // 将系列填充格式设置为自动
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // 将演示文稿文件写入磁盘
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置图表系列反转填充颜色**
Aspose.Slides 允许您以以下方式设置图表系列的反转填充颜色：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 根据您首选的类型添加带有默认数据的图表（在下面的示例中，我们使用了 `ChartType.ClusteredColumn`）。
1. 访问图表系列并将填充颜色设置为反转。
1. 将演示文稿保存为 PPTX 文件。

以下 Java 代码演示了该操作：

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 添加新的系列和类别
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "系列 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "类别 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "类别 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "类别 3"));

    // 以图表系列填充其系列数据。
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **当值为负时设置系列反转**
Aspose.Slides 允许您通过 `IChartDataPoint.InvertIfNegative` 和 `ChartDataPoint.InvertIfNegative` 属性设置反转。当通过属性设置反转时，数据点在获取负值时会反转其颜色。

以下 Java 代码演示了该操作：

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **清除特定数据点的数据**
Aspose.Slides for Java 允许您以以下方式清除特定图表系列的 `DataPoints` 数据：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 通过其索引获取图表的引用。
4. 遍历所有图表 `DataPoints` 并将 `X值` 和 `Y值` 设置为 null。
5. 清除特定图表系列的所有 `DataPoints`。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示了该操作：

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置系列间隙宽度**
Aspose.Slides for Java 允许您通过 **`GapWidth`** 属性设置系列的间隙宽度：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 访问第一张幻灯片。
3. 添加带有默认数据的图表。
4. 访问任意图表系列。
5. 设置 `GapWidth` 属性。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码展示了如何设置系列的间隙宽度：

```java
// 创建空演示文稿 
Presentation pres = new Presentation();
try {
    // 访问演示文稿的第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加带有默认数据的图表
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // 设置图表数据工作表的索引
    int defaultWorksheetIndex = 0;
    
    // 获取图表数据工作表
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 添加系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "系列 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "系列 2"), chart.getType());
    
    // 添加类别
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "类别 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "类别 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "类别 3"));
    
    // 获取第二个图表系列
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // 填充系列数据
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // 设置间隙宽度值
    series.getParentSeriesGroup().setGapWidth(50);
    
    // 保存演示文稿到磁盘
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```