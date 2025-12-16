---
title: 在 Android 上的演示文稿中自定义环形图
linktitle: 环形图
type: docs
weight: 30
url: /zh/androidjava/doughnut-chart/
keywords:
- 环形图
- 中心间隙
- 孔大小
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android via Java 中创建和自定义环形图，支持 PowerPoint 格式的动态演示文稿。"
---

## **指定环形图的中心间隙**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 现在支持指定环形图中心孔的大小。在本主题中，我们将通过示例了解如何指定环形图中心孔的大小。

{{% /alert %}} 

要指定环形图中心孔的大小，请遵循以下步骤：

1. 实例化 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 对象。  
2. 在幻灯片上添加环形图。  
3. 指定环形图中心孔的大小。  
4. 将演示文稿写入磁盘。  

在下面的示例中，我们已经设置了环形图中心孔的大小。  
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


## **常见问题**

**我可以创建具有多个环的多层环形图吗？**

是的。向单个环形图添加多个系列——每个系列都会成为一个独立的环。环的顺序由集合中系列的顺序决定。

**是否支持“炸开”环形图（分离切片）？**

是的。提供 Exploded Doughnut [chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) 图表类型以及数据点的 explode 属性；您可以分离各个切片。

**如何获取环形图的图像（PNG/SVG）用于报告？**

图表是一种形状；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) 或将图表导出为 [SVG image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。