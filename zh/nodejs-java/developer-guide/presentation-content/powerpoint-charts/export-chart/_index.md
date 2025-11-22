---
title: 导出图表
type: docs
weight: 90
url: /zh/nodejs-java/export-chart/
---

## **获取图表图像**
Aspose.Slides for Node.js via Java 提供了提取特定图表图像的支持。以下示例代码给出。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以将图表导出为矢量（SVG）而不是栅格图像吗？**

是的。图表是一个形状，其内容可以使用[shape-to-SVG 保存方法](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/)保存为 SVG。

**如何以像素为单位设置导出图表的精确尺寸？**

使用允许指定尺寸或比例的图像渲染重载——库支持按给定的尺寸/比例渲染对象。

**导出后如果标签和图例中的字体显示错误，我该怎么办？**

[加载所需的字体](/slides/zh/nodejs-java/custom-font/)通过[FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/)以确保图表渲染保留度量和文本外观。

**导出是否遵循 PowerPoint 的主题、样式和效果？**

是的。Aspose.Slides 的渲染器遵循演示文稿的格式设置（主题、样式、填充、效果），因此图表的外观得以保留。

**在哪里可以找到图表图像之外的可用渲染/导出功能？**

请参阅[API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/)/[文档](/slides/zh/nodejs-java/convert-powerpoint/)以了解输出目标（[PDF](/slides/zh/nodejs-java/convert-powerpoint-to-pdf/)、[SVG](/slides/zh/nodejs-java/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh/nodejs-java/convert-powerpoint-to-xps/)、[HTML](/slides/zh/nodejs-java/convert-powerpoint-to-html/)、等）以及相关的渲染选项。