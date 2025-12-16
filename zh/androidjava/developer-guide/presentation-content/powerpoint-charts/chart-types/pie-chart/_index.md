---
title: 在 Android 上的演示文稿中自定义饼图
linktitle: 饼图
type: docs
url: /zh/androidjava/pie-chart/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 在 Java 中创建和自定义饼图，并可导出为 PowerPoint，帮助您在几秒钟内提升数据故事表达。"
---

## **饼中饼和条形饼图的第二绘图选项**
Aspose.Slides for Android via Java 现在支持饼中饼或条形饼图的第二绘图选项。在本主题中，我们将展示如何使用 Aspose.Slides 指定这些选项。要指定属性，请执行以下操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 指定图表的第二绘图选项。
1. 将演示文稿写入磁盘。

在下面的示例中，我们已设置饼中饼图的不同属性。
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
Aspose.Slides for Android via Java 提供了一个用于设置自动饼图切片颜色的简易 API。示例代码演示了上述属性的设置。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 设置图表标题。
1. 将第一系列设置为显示数值。
1. 设置图表数据表的索引。
1. 获取图表数据工作表。
1. 删除默认生成的系列和分类。
1. 添加新分类。
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

    // 将第一系列设置为显示数值
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

    // 现在填充系列数据
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**是否支持 “Pie of Pie” 和 “Bar of Pie” 变体？**

是的，库 [supports](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 二次绘图用于饼图，包括 “Pie of Pie” 和 “Bar of Pie” 类型。

**我可以仅将图表导出为图像（例如 PNG）吗？**

是的，您可以 [export the chart itself as an image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)(例如 PNG)，而无需导出整个演示文稿。