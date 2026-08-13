---
title: Aspose.Slides for Java 15.7.0 的公共 API 与向后不兼容更改
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 
此页面列出了所有 [added](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) 或 [removed](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) 类、方法、属性等，以及 Aspose.Slides for Java 15.7.0 API 引入的其他更改。
{{% /alert %}} 
## **公共 API 更改**
#### **枚举 com.aspose.slides.ImagePixelFormat 已添加**
已添加枚举 com.aspose.slides.ImagePixelFormat，用于指定生成图像的像素格式。
#### **已添加 com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() 方法**
此方法根据系列索引、数据点索引、parentSeriesGroup、isColorVaried 值和图表样式返回数据点的自动颜色。如果 fillType 等于 NotDefined，则默认使用此颜色。
#### **已向 com.aspose.slides.ITiffOptions 添加了 getPixelFormat()、setPixelFormat(int) 方法**
已向 com.aspose.slides.ITiffOptions 和 com.aspose.slides.TiffOptions 添加了 getPixelFormat()、setPixelFormat(/ImagePixelFormat/int) 方法，用于指定生成 TIFF 图像的像素格式。
``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```