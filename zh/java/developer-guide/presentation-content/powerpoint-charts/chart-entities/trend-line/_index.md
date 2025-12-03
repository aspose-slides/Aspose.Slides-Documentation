---
title: 在 Java 中为演示文稿图表添加趋势线
linktitle: 趋势线
type: docs
url: /zh/java/trend-line/
keywords:
- 图表
- 趋势线
- 指数趋势线
- 线性趋势线
- 对数趋势线
- 移动平均趋势线
- 多项式趋势线
- 幂趋势线
- 自定义趋势线
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 图表中快速添加和自定义趋势线——一份实用指南，帮助您吸引观众。"
---

## **添加趋势线**
Aspose.Slides for Java 提供了简单的 API 用于管理不同图表的趋势线：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个带有默认数据的图表，并选择所需的任意类型（此示例使用 ChartType.ClusteredColumn）。
4. 为图表系列 1 添加指数趋势线。
5. 为图表系列 1 添加线性趋势线。
6. 为图表系列 2 添加对数趋势线。
7. 为图表系列 2 添加移动平均趋势线。
8. 为图表系列 3 添加多项式趋势线。
9. 为图表系列 3 添加幂趋势线。
10. 将修改后的演示文稿写入 PPTX 文件。

下面的代码用于创建带有趋势线的图表。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 创建簇状柱形图表
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
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // 为图表系列 2 添加移动平均趋势线
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
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
Aspose.Slides for Java 提供了简单的 API 用于在图表中添加自定义线。要向演示文稿的选定幻灯片添加一条简单的普通线，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例
- 使用其 Index 获取幻灯片的引用
- 使用 Shapes 对象提供的 AddChart 方法创建新图表
- 使用 Shapes 对象提供的 AddAutoShape 方法添加 Line 类型的 AutoShape
- 设置形状线条的颜色。
- 将修改后的演示文稿写入 PPTX 文件

下面的代码用于创建带有自定义线的图表。
```java
// 创建 Presentation 类的实例
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


## **常见问题**

**趋势线的‘forward’和‘backward’是什么意思？**

它们是趋势线向前/向后投射的长度：对于散点（XY）图表——以坐标轴单位表示；对于非散点图表——以类别数量表示。仅允许非负值。

**在将演示文稿导出为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

是的。Aspose.Slides 可将演示文稿转换为 [PDF](/slides/zh/java/convert-powerpoint-to-pdf/)/[SVG](/slides/zh/java/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；趋势线作为图表的一部分，在这些操作中会被保留。还提供了将图表本身导出为图像的 [方法](/slides/zh/java/create-shape-thumbnails/)。