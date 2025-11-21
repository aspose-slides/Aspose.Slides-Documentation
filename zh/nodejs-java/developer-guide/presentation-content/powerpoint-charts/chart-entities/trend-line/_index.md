---
title: 趋势线
type: docs
url: /zh/nodejs-java/trend-line/
---

## **添加趋势线**

Aspose.Slides for Node.js via Java 提供了一个简单的 API，用于管理不同图表的趋势线：

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个带有默认数据的图表，并使用任意所需类型（此示例使用 ChartType.ClusteredColumn）。
1. 为图表系列 1 添加指数趋势线。
1. 为图表系列 1 添加线性趋势线。
1. 为图表系列 2 添加对数趋势线。
1. 为图表系列 2 添加移动平均趋势线。
1. 为图表系列 3 添加多项式趋势线。
1. 为图表系列 3 添加幂趋势线。
1. 将修改后的演示文稿写入 PPTX 文件。

以下代码用于创建带有趋势线的图表。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 创建聚类柱形图
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // 为图表系列 1 添加指数趋势线
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // 为图表系列 1 添加线性趋势线
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 为图表系列 2 添加对数趋势线
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // 为图表系列 2 添加移动平均趋势线
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // 为图表系列 3 添加多项式趋势线
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // 为图表系列 3 添加幂趋势线
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // 保存演示文稿
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **添加自定义线**

Aspose.Slides for Node.js via Java 提供了一个简单的 API，用于在图表中添加自定义线。要向演示文稿的选定幻灯片添加一条简单的普通线，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例
- 使用其 Index 获取幻灯片的引用
- 使用 Shapes 对象提供的 AddChart 方法创建新图表
- 使用 Shapes 对象提供的 AddAutoShape 方法添加 Line 类型的 AutoShape
- 设置形状线条的颜色。
- 将修改后的演示文稿写入 PPTX 文件

以下代码用于创建带有自定义线的图表。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**趋势线的 “forward” 和 “backward” 是什么意思？**

它们是趋势线向前/向后延伸的长度：对于散点（XY）图表，以坐标轴单位表示；对于非散点图表，以类别数量表示。仅允许非负值。

**在将演示文稿导出为 PDF 或 SVG，或将幻灯片渲染为图像时，趋势线会被保留吗？**

是的。Aspose.Slides 将演示文稿转换为 [PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/zh/nodejs-java/render-a-slide-as-an-svg-image/)，并将图表渲染为图像；趋势线作为图表的一部分，在这些操作中会被保留。还提供了一种方法可[导出图表的图像](/slides/zh/nodejs-java/create-shape-thumbnails/)。