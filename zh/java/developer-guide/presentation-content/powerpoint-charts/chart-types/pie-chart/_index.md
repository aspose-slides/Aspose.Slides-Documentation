---
title: 饼图
type: docs
url: /zh/java/pie-chart/
---

## **饼图和条形图的第二个绘图区选项**
Aspose.Slides for Java 现在支持饼中饼或条形中饼图的第二个绘图区选项。在本主题中，我们将向您展示如何使用 Aspose.Slides 指定这些选项。要指定属性，请执行以下操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 指定图表的第二个绘图区选项。
1. 将演示文稿写入磁盘。

在下面给出的示例中，我们设置了饼中饼图的不同属性。

```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 在幻灯片上添加图表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // 设置不同属性
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
Aspose.Slides for Java 提供了一个简单的 API 用于设置自动饼图幻灯片颜色。示例代码应用上述属性的设置。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加默认数据的图表。
1. 设置图表标题。
1. 将第一个系列设置为显示值。
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
    chart.getChartTitle().addTextFrameForOverriding("示例标题");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // 将第一个系列设置为显示值
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // 设置图表数据表的索引
    int defaultWorksheetIndex = 0;

    // 获取图表数据工作表
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // 删除默认生成的系列和类别
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // 添加新类别
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "第一季度"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "第二季度"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "第三季度"));

    // 添加新系列
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "系列 1"), chart.getType());

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