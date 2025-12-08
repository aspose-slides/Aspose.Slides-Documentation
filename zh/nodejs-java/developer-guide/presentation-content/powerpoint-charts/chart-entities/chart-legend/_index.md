---
title: 图表图例
type: docs
url: /zh/nodejs-java/chart-legend/
---

## **图例定位**

为了设置图例属性，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
- 获取幻灯片的引用。
- 在幻灯片上添加图表。
- 设置图例的属性。
- 将演示文稿写入为 PPTX 文件。

在下面的示例中，我们已为图表图例设置位置和大小。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    // 获取幻灯片的引用
    var slide = pres.getSlides().get_Item(0);
    // 在幻灯片上添加聚簇柱形图
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // 设置图例属性
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // 将演示文稿写入磁盘
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置图例字体大小**

Aspose.Slides for Node.js via Java 允许开发人员设置图例的字体大小。请按以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类。
- 创建默认图表。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **设置单个图例项的字体大小**

Aspose.Slides for Node.js via Java 允许开发人员设置单个图例项的字体大小。请按以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类。
- 创建默认图表。
- 访问图例项。
- 设置字体大小。
- 设置最小轴值。
- 设置最大轴值。
- 将演示文稿写入磁盘。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以启用图例，使图表自动为其分配空间而不是覆盖它吗？**

是的。使用非覆盖模式（[setOverlay(false)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/)）；在这种情况下，绘图区域会收缩以容纳图例。

**我可以创建多行图例标签吗？**

是的。当空间不足时，长标签会自动换行；通过在系列名称中使用换行符可以实现强制换行。

**如何使图例遵循演示文稿主题的配色方案？**

不要为图例或其文本显式设置颜色、填充或字体。这样它们会继承主题的配色，并在设计更改时自动更新。