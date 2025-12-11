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
description: "使用适用于 Android 的 Aspose.Slides，在 Java 中自定义 PPT 和 PPTX 的图表数据表，以提升演示文稿的效率和吸引力。"
---

## **Set Font Properties for a Chart Data Table**
Aspose.Slides for Android via Java 提供对系列颜色中类别颜色更改的支持。

1. 实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类对象。  
1. 在幻灯片上添加图表。  
1. 设置图表表格。  
1. 设置字体高度。  
1. 保存已修改的演示文稿。

下面给出示例。  
```java
// 创建空白演示文稿
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

**Can I show small legend keys next to the values in the chart’s data table?**

是的。数据表支持[legend keys](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-)，您可以打开或关闭它们。

**Will the data table be preserved when exporting the presentation to PDF, HTML, or images?**

是的。Aspose.Slides 将图表渲染为幻灯片的一部分，因此导出的[PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)/[image](/slides/zh/androidjava/convert-powerpoint-to-png/) 包含带有数据表的图表。

**Are data tables supported for charts that come from a template file?**

是的。对于从现有演示文稿或模板加载的任何图表，您可以使用图表的属性检查并更改数据表是否[is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--)。

**How can I quickly find which charts in a file have the data table enabled?**

检查每个图表的属性，以指示数据表是否[is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--)，然后遍历幻灯片以识别启用数据表的图表。