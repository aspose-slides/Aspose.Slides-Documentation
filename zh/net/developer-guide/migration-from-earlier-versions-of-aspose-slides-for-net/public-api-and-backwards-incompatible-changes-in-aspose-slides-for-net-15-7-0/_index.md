---
title: Aspose.Slides for .NET 15.7.0 的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for .NET 15.7.0
type: docs
weight: 180
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审查 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出了所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/)或[已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/)的类、方法、属性等，以及在 Aspose.Slides for .NET 15.7.0 API 中引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已添加 Enum ImagePixelFormat**
Enum Aspose.Slides.Export.ImagePixelFormat 已被添加，用于指定生成图像的像素格式。
#### **已添加 IChartDataPoint.GetAutomaticDataPointColor() 方法**
根据系列索引、数据点索引、ParentSeriesGroup、IsColorVaried 属性和图表样式返回数据点的自动颜色。
如果 FillType 等于 NotDefined，则默认使用此颜色。
#### **已向 Slide 添加 RenderToGraphics 方法**
Method RenderToGraphics（及其重载）已被添加到 Aspose.Slides.Slide，用于将幻灯片渲染到 Graphics 对象。
#### **已向 ITiffOptions 和 TiffOptions 添加 PixelFormat 属性**
Property PixelFormat 已被添加到 Aspose.Slides.Export.ITiffOptions 和 Aspose.Slides.Export.TiffOptions，用于指定生成的 TIFF 图像的像素格式。