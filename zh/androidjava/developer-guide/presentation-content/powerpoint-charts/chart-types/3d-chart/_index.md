---
title: 在 Android 上自定义演示文稿中的 3D 图表
linktitle: 3D 图表
type: docs
url: /zh/androidjava/3d-chart/
keywords:
- 3D 图表
- 旋转
- 深度
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android via Java 中创建和自定义 3D 图表，支持 PPT 和 PPTX 文件——立即提升您的演示文稿。"
---

## **设置 3D 图表的 RotationX、RotationY 和 DepthPercents 属性**
Aspose.Slides for Android via Java 提供了一个简洁的 API 用于设置这些属性。下面的文章将帮助您设置不同的属性，例如 **X、Y 旋转、DepthPercents** 等。示例代码演示了上述属性的设置。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 设置 Rotation3D 属性。
1. 将修改后的演示文稿写入 PPTX 文件。
```java
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加带默认数据的图表
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // 设置图表数据工作表的索引
    int defaultWorksheetIndex = 0;
    
    // 获取图表数据工作表
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 添加系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // 添加类别
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // 设置 Rotation3D 属性
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // 获取第二个图表系列
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // 现在填充系列数据
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // 设置 OverLap 值
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // 将演示文稿写入磁盘
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**哪种图表类型在 Aspose.Slides 中支持 3D 模式？**

Aspose.Slides 支持柱形图的 3D 变体，包括 Column 3D、Clustered Column 3D、Stacked Column 3D 和 100% Stacked Column 3D，以及通过 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 类公开的相关 3D 类型。要获取准确的最新列表，请在已安装版本的 API 参考中查看 [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 成员。

**是否可以获取 3D 图表的栅格图像用于报告或网页？**

是的。您可以通过 [chart API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) 将图表导出为图像，或者将整张幻灯片[渲染](/slides/zh/androidjava/convert-powerpoint-to-png/)为 PNG、JPEG 等格式。当您需要像素级精确的预览，或希望将图表嵌入文档、仪表盘或网页而无需 PowerPoint 时，这非常有用。

**构建和渲染大型 3D 图表的性能如何？**

性能受数据量和视觉复杂度的影响。为获得最佳效果，请保持 3D 效果最小化，避免在墙面和绘图区域使用大纹理，尽可能限制每个系列的数据点数量，并将渲染输出为适当尺寸（分辨率和尺寸），以匹配目标显示或打印需求。