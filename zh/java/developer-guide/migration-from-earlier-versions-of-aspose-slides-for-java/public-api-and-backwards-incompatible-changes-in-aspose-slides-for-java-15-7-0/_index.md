---
title: Aspose.Slides for Java 15.7.0 的公共 API 和向后不兼容的更改
type: docs
weight: 150
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

此页面列出了在 Aspose.Slides for Java 15.7.0 API 中添加的所有[class added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/)或[class removed](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) 的类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **添加了枚举 com.aspose.slides.ImagePixelFormat**
添加了枚举 com.aspose.slides.ImagePixelFormat，用于指定生成图像的像素格式。
#### **添加了 com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() 方法**
此方法根据系列索引、数据点索引、parentSeriesGroup、isColorVaried 值和图表样式返回数据点的自动颜色。如果 fillType 等于 NotDefined，则默认使用此颜色。
#### **向 com.aspose.slides.ITiffOptions 添加了方法 getPixelFormat() 和 setPixelFormat(int)**
向 com.aspose.slides.ITiffOptions 和 com.aspose.slides.TiffOptions 添加了方法 getPixelFormat() 和 setPixelFormat(/ImagePixelFormat/int)，用于指定生成的 TIFF 图像的像素格式。

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```