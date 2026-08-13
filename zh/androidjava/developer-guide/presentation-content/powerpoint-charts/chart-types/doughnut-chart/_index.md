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
## **概述**

本文展示了如何在 Aspose.Slides 中使用环形图，包括将图表添加到幻灯片、设置中心孔的大小以及保存演示文稿。重点介绍了 `setDoughnutHoleSize` 方法，并演示了在代码中自定义此图表类型的基本步骤。

文中还包含了简短的 FAQ，涵盖了环形图的相关场景，如使用多系列创建多环、使用炸裂环形图以及将图表导出为栅格图像或 SVG。

## **在环形图中指定中心间隙**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java 现已支持指定环形图中心孔的大小。本文将通过示例演示如何设置环形图中心孔的大小。

{{% /alert %}} 

要在环形图中指定中心孔的大小，请按以下步骤操作：

1. 实例化 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation) 对象。
1. 在幻灯片上添加环形图。
1. 指定环形图中心孔的大小。
1. 将演示文稿写入磁盘。

下面的示例演示了如何设置环形图中心孔的大小。

```java
import com.aspose.slides.*;

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

### 能否创建具有多个环的多层环形图？

可以。向单个环形图中添加多个 series——每个 series 将成为一个独立的环。环的顺序由 series 在集合中的顺序决定。

### 是否支持“炸裂”环形图（分离的切片）？

支持。Aspose.Slides 提供了 Exploded Doughnut [chart type](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/charttype/) 并在数据点上提供了 explosion 属性，可用于分离单个切片。

### 如何获取环形图的图像（PNG/SVG）用于报告？

图表本身是一个 shape；您可以将其渲染为 [raster image](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) 或导出为 [SVG image](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)。