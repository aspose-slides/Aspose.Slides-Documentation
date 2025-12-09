---
title: Aspose.Slides for .NET 15.5.0 的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for .NET 15.5.0
type: docs
weight: 160
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 旧版方法
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

此页面列出了所有 [added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) 或 [removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) 类、方法、属性等，以及 Aspose.Slides for .NET 15.5.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已添加 CommonSlideViewProperties 类和 ICommonSlideViewProperties 接口**
Aspose.Slides.CommonSlideViewProperties 类和 Aspose.Slides.ICommonSlideViewProperties 接口表示通用幻灯片视图属性（目前是视图缩放选项）。
#### **已添加 IAxis.LabelOffset 属性**
IAxis.LabelOffset 属性指定标签距坐标轴的距离，适用于类别坐标轴或日期坐标轴。
#### **已添加 IChartTextBlockFormat.AutofitType 属性**
更改此属性仅会对以下图表部件产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中对渲染没有影响）。
#### **已添加 IChartTextBlockFormat.WrapText 属性**
更改此属性仅会对以下图表部件产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2007/2013 中完全支持）。
#### **已向 IChartTextBlockFormat 添加 Margin 属性**
更改这些属性仅会对以下图表部件产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中对渲染没有影响）。
#### **已添加 ViewProperties.NotesViewProperties 属性**
已添加 Aspose.Slides.ViewProperties.NotesViewProperties 属性。它指定与备注视图模式相关的通用视图属性。
#### **已添加 ViewProperties.SlideViewProperties 属性**
已添加 Aspose.Slides.ViewProperties.SlideViewProperties 属性。它指定与幻灯片视图模式相关的通用视图属性。