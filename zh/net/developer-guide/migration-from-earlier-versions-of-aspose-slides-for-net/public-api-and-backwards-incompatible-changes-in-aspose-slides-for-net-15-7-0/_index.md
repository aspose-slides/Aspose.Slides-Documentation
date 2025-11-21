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
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "查看 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有已添加或已删除的类、方法、属性等，以及随 Aspose.Slides for .NET 15.7.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已添加 Enum ImagePixelFormat**
已添加 Enum Aspose.Slides.Export.ImagePixelFormat，用于指定生成图像的像素格式。
#### **已添加 IChartDataPoint.GetAutomaticDataPointColor() 方法**
根据系列索引、数据点索引、ParentSeriesGroup、IsColorVaried 属性以及图表样式返回数据点的自动颜色。  
如果 FillType 等于 NotDefined，则默认使用此颜色。
#### **已在 Slide 上添加 RenderToGraphics 方法**
已在 Aspose.Slides.Slide 中添加 Method RenderToGraphics（及其重载），用于将幻灯片渲染为 Graphics 对象。
#### **已在 ITiffOptions 和 TiffOptions 中添加 Property PixelFormat**
已在 Aspose.Slides.Export.ITiffOptions 和 Aspose.Slides.Export.TiffOptions 中添加 Property PixelFormat，用于指定生成的 TIFF 图像的像素格式。