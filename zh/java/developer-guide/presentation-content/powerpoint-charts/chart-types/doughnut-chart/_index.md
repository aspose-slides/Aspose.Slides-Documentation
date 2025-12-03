---
title: 使用 Java 在演示文稿中自定义环形图
linktitle: 环形图
type: docs
weight: 30
url: /zh/java/doughnut-chart/
keywords:
- 环形图
- 中心间隙
- 孔大小
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中创建和自定义环形图，支持 PowerPoint 格式的动态演示文稿。"
---

## **更改环形图中心间隙**
{{% alert color="primary" %}} 

Aspose.Slides for Java 现已支持指定环形图中孔的大小。本文将通过示例演示如何设置环形图的孔径。

{{% /alert %}} 

要指定环形图中孔的大小，请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 对象。
1. 在幻灯片上添加环形图。
1. 指定环形图中孔的大小。
1. 将演示文稿写入磁盘。

下面的示例中，我们已设置环形图的孔径大小。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // 将演示文稿写入磁盘
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**我可以创建具有多个环的多层环形图吗？**

可以。向单个环形图添加多个系列——每个系列会成为一个独立的环。环的顺序由系列在集合中的顺序决定。

**是否支持“爆炸”环形图（分离切片）？**

支持。存在 Exploded Doughnut [chart type](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) 并且数据点上有爆炸属性；您可以分离各个切片。

**如何获取环形图的图像（PNG/SVG）用于报告？**

环形图是一个形状；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) 或导出为 [SVG image](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。