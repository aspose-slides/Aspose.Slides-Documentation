---
title: 在 Java 中导出演示文稿图表
linktitle: 导出图表
type: docs
weight: 90
url: /zh/java/export-chart/
keywords:
- 图表
- 图表转图像
- 图表为图像
- 提取图表图像
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 导出演示文稿图表，支持 PPT 和 PPTX 格式，并将报告流畅集成到任何工作流中。"
---

## **获取图表图像**
Aspose.Slides for Java 提供对特定图表图像提取的支持。以下示例代码提供。

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**我可以将图表导出为矢量图（SVG）而不是光栅图像吗？**

是的。图表是一种形状，其内容可以使用[shape-to-SVG 保存方法](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)保存为 SVG。

**如何以像素为单位设置导出图表的精确尺寸？**

使用支持指定尺寸或比例的图像渲染重载——库支持按给定的宽高/比例渲染对象。

**导出后标签和图例中的字体显示不正确，我该怎么办？**

通过[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/)[加载所需的字体](/slides/zh/java/custom-font/)，以确保图表渲染时保持度量和文本外观。

**导出是否遵循 PowerPoint 主题、样式和效果？**

是的。Aspose.Slides 的渲染器遵循演示文稿的格式设置（主题、样式、填充、效果），因此图表外观得以保留。

**在哪里可以找到图表图像之外的可用渲染/导出功能？**

请参阅[API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[文档](/slides/zh/java/convert-powerpoint/)了解输出目标（[PDF](/slides/zh/java/convert-powerpoint-to-pdf/)、[SVG](/slides/zh/java/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh/java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/java/convert-powerpoint-to-html/)等）以及相关渲染选项。