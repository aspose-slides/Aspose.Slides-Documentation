---
title: Aspose.Slides for Java 15.7.0 的公共 API 和不兼容的更改
type: docs
weight: 150
url: /androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
---

{{% alert color="primary" %}} 

此页面列出了在 Aspose.Slides for Java 15.7.0 API 中添加的或移除的所有[class](/slides/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/)、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **添加了枚举 com.aspose.slides.ImagePixelFormat**
添加了枚举 com.aspose.slides.ImagePixelFormat 用于指定生成图像的像素格式。
#### **添加了 com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() 方法**
该方法根据系列索引、数据点索引、parentSeriesGroup、isColorVaried 值和图表样式返回数据点的自动颜色。 如果 fillType 等于 NotDefined，则默认使用此颜色。
#### **在 com.aspose.slides.ITiffOptions 中添加了方法 getPixelFormat() 和 setPixelFormat(int)**
在 com.aspose.slides.ITiffOptions 和 com.aspose.slides.TiffOptions 中添加了用于指定生成 TIFF 图像的像素格式的方法 getPixelFormat() 和 setPixelFormat(/ImagePixelFormat/int)。

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```