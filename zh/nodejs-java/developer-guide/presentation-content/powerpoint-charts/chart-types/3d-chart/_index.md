---
title: 3D 图表
type: docs
url: /zh/nodejs-java/3d-chart/
---

## **设置 3D 图表的 RotationX、RotationY 和 DepthPercents 属性**

Aspose.Slides for Node.js via Java 提供了一个用于设置这些属性的简易 API。本文将帮助您了解如何设置不同的属性，如 **X、Y 旋转、DepthPercents** 等。示例代码演示了上述属性的设置。

1. 创建 Presentation 类的实例。
2. 访问第一张幻灯片。
3. 添加包含默认数据的图表。
4. 设置 Rotation3D 属性。
5. 将修改后的演示文稿写入 PPTX 文件。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 添加带默认数据的图表
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // 设置图表数据工作表的索引
    var defaultWorksheetIndex = 0;
    // 获取图表数据工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 添加系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // 添加类别
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // 设置 Rotation3D 属性
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // 获取第二个图表系列
    var series = chart.getChartData().getSeries().get_Item(1);
    // 现在填充系列数据
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // 设置 OverLap 值
    series.getParentSeriesGroup().setOverlap(100);
    // 将演示文稿写入磁盘
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Aspose.Slides 支持哪些图表类型的 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)枚举公开的相关 3D 类型。有关完整、最新的列表，请查阅您所使用版本的 API 参考中的[ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)成员。

**我可以获取 3D 图表的栅格图像用于报告或网页吗？**

是的。您可以通过[chart API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage)将图表导出为图像，或将整张幻灯片渲染为 PNG、JPEG 等格式。这在需要像素级预览或将图表嵌入文档、仪表盘或网页而无需 PowerPoint 时非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能取决于数据量和视觉复杂度。为获得最佳效果，请尽量保持 3D 效果最小化，避免在墙面和绘图区域使用大量纹理，尽可能限制每个系列的数据点数量，并将渲染输出为适当尺寸（分辨率和尺寸），以匹配目标显示或打印需求。