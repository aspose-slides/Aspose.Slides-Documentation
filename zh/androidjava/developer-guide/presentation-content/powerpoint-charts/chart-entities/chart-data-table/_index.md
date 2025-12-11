---
title: 在 Android 上自定义演示文稿中的图表数据表
linktitle: 数据表
type: docs
url: /zh/androidjava/chart-data-table/
keywords:
- 图表数据
- 数据表
- 字体属性
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中自定义 PPT 和 PPTX 的图表数据表，以提升演示文稿的效率和吸引力。"
---

## **为图表数据表设置字体属性**
Aspose.Slides for Android via Java 提供了更改系列颜色中类别颜色的支持。

1. 实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类对象。
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


## **FAQ**

**我可以在图表数据表的值旁显示小图例键吗？**

是的。数据表支持 [legend keys](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-)，您可以打开或关闭它们。

**在将演示文稿导出为 PDF、HTML 或图像时，数据表会被保留吗？**

是的。Aspose.Slides 将图表渲染为幻灯片的一部分，因此导出的 [PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)/[image](/slides/zh/androidjava/convert-powerpoint-to-png/) 都包含带有数据表的图表。

**模板文件中的图表是否支持数据表？**

是的。对于从现有演示文稿或模板加载的任何图表，您可以使用图表属性检查并更改数据表是否 [is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--)。

**我如何快速找出文件中哪些图表启用了数据表？**

检查每个图表的属性，以判断数据表是否 [is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--)，并遍历幻灯片以识别已启用数据表的图表。