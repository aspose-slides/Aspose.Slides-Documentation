---
title: 趋势线
type: docs
url: /java/trend-line/
---

## **添加趋势线**
Aspose.Slides for Java 提供了一种简单的 API 来管理不同图表的趋势线：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表以及任何所需类型（此示例使用 ChartType.ClusteredColumn）。
1. 为图表系列 1 添加指数趋势线。
1. 为图表系列 1 添加线性趋势线。
1. 为图表系列 2 添加对数趋势线。
1. 为图表系列 2 添加移动平均趋势线。
1. 为图表系列 3 添加多项式趋势线。
1. 为图表系列 3 添加幂趋势线。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建带有趋势线的图表。

```java
// 创建一个 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 创建一个集群柱状图
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // 为图表系列 1 添加指数趋势线
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // 为图表系列 1 添加线性趋势线
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // 为图表系列 2 添加对数趋势线
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("新的对数趋势线");
    
    // 为图表系列 2 添加移动平均趋势线
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("新的趋势线名称");
    
    // 为图表系列 3 添加多项式趋势线
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // 为图表系列 3 添加幂趋势线
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // 保存演示文稿
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **添加自定义线**
Aspose.Slides for Java 提供了一个简单的 API 来在图表中添加自定义线。要在演示文稿的选定幻灯片上添加一条简单的实线，请遵循以下步骤：

- 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例
- 通过使用其索引获取幻灯片的引用
- 使用 Shapes 对象提供的 AddChart 方法创建一个新图表
- 使用 Shapes 对象提供的 AddAutoShape 方法添加一个线型的 AutoShape
- 设置形状线条的颜色。
- 将修改后的演示文稿写入 PPTX 文件

以下代码用于创建带有自定义线的图表。

```java
// 创建一个 Presentation 类的实例
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```