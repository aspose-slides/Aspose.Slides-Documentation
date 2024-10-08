---
title: 图表数据表
type: docs
url: /zh/androidjava/chart-data-table/
---

## **为图表数据表设置字体属性**
Aspose.Slides for Android via Java 提供了更改系列颜色中类别颜色的支持。

1. 实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类对象。
1. 在幻灯片上添加图表。
1. 设置图表表格。
1. 设置字体高度。
1. 保存修改后的演示文稿。

下面给出示例代码。

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