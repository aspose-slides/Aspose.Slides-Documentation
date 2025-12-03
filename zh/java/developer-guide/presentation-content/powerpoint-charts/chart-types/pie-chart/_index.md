---
title: 使用 Java 自定义演示文稿中的饼图
linktitle: 饼图
type: docs
url: /zh/java/pie-chart/
keywords:
- 饼图
- 管理图表
- 自定义图表
- 图表选项
- 图表设置
- 绘图选项
- 切片颜色
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Java 中创建和自定义饼图，并导出为 PowerPoint，在几秒钟内提升数据叙事。"
---

## **饼图中的饼图和条形图的第二绘图选项**
Aspose.Slides for Java 现在支持饼图中的饼图或条形图的第二绘图选项。在本主题中，我们将展示如何使用 Aspose.Slides 指定这些选项。要指定属性，请执行以下操作：

1. 实例化[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类对象。
1. 在幻灯片上添加图表。
1. 指定图表的第二绘图选项。
1. 将演示文稿写入磁盘。

在下面的示例中，我们为饼图中的饼图设置了不同的属性。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 在幻灯片上添加图表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // 设置不同的属性
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // 将演示文稿写入磁盘
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **设置自动饼图切片颜色**
Aspose.Slides for Java 提供了一个简单的 API 来设置自动饼图切片颜色。示例代码演示了上述属性的设置。

1. 创建[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
1. 访问第一张幻灯片。
1. 添加带默认数据的图表。
1. 设置图表标题。
1. 将第一系列设置为显示值。
1. 设置图表数据表的索引。
1. 获取图表数据工作表。
1. 删除默认生成的系列和类别。
1. 添加新类别。
1. 添加新系列。

将修改后的演示文稿写入 PPTX 文件。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 添加默认数据的图表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // 设置图表标题
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 将第一系列设置为显示值
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // 设置图表数据表的索引
    int defaultWorksheetIndex = 0;

    // 获取图表数据工作表
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // 删除默认生成的系列和类别
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 添加新类别
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // 添加新系列
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // 正在填充系列数据
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**是否支持“饼图中的饼图”和“条形图中的饼图”变体？**

是的，库[支持](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/)饼图的次要绘图，包括“饼图中的饼图”和“条形图中的饼图”类型。

**我可以仅将图表导出为图像（例如 PNG）吗？**

是的，您可以[将图表本身导出为图像](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-)(例如 PNG)，而无需导出整个演示文稿。