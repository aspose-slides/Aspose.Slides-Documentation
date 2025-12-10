---
title: 使用 Java 在演示文稿中自定义图表数据表
linktitle: 数据表
type: docs
url: /zh/java/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中自定义 PPT 和 PPTX 的图表数据表，以提升演示的效率和吸引力。"
---

## **为图表数据表设置字体属性**
Aspose.Slides for Java 提供了更改系列颜色中类别颜色的支持。

1. 实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表数据表。
1. 设置字体高度。
1. 保存修改后的演示文稿。

下面给出示例。 
```java
// 创建空演示文稿
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**我可以在图表数据表的数值旁显示小的图例键吗？**

是的。数据表支持[legend keys](https://reference.aspose.com/slides/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-)，您可以打开或关闭它们。

**导出演示文稿为 PDF、HTML 或图像时，数据表会被保留吗？**

是的。Aspose.Slides 将图表渲染为幻灯片的一部分，因此导出的[PDF](/slides/zh/java/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/java/convert-powerpoint-to-html/)/[image](/slides/zh/java/convert-powerpoint-to-png/) 包含带有数据表的图表。

**来自模板文件的图表是否支持数据表？**

是的。对于从现有演示文稿或模板加载的任何图表，您可以使用图表属性检查并更改数据表是否[显示](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--)。

**如何快速查找文件中哪些图表启用了数据表？**

检查每个图表的属性，以指示数据表是否[显示](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#hasDataTable--)，并遍历幻灯片以识别已启用数据表的图表。