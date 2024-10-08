---
title: Aspose.Slides for .NET 15.7.0 的公共 API 和不向后兼容的更改
type: docs
weight: 180
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
---

{{% alert color="primary" %}} 

本页面列出了所有 [新增的](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) 或 [删除的](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) 类、方法、属性等，以及 Aspose.Slides for .NET 15.7.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **添加了枚举 ImagePixelFormat**
添加了枚举 Aspose.Slides.Export.ImagePixelFormat 用于指定生成图像的像素格式。
#### **添加了 IChartDataPoint.GetAutomaticDataPointColor() 方法**
根据系列索引、数据点索引、ParentSeriesGroup、IsColorVaried 属性和图表样式返回数据点的自动颜色。
如果 FillType 等于 NotDefined，则默认使用此颜色。
#### **Slide 中添加了 RenderToGraphics 方法**
将 RenderToGraphics（及其重载）方法添加到 Aspose.Slides.Slide 以将幻灯片渲染到 Graphics 对象。
#### **ITiffOptions 和 TiffOptions 中添加了 PixelFormat 属性**
在 Aspose.Slides.Export.ITiffOptions 和 Aspose.Slides.Export.TiffOptions 中添加了 PixelFormat 属性，用于指定生成的 TIFF 图像的像素格式。