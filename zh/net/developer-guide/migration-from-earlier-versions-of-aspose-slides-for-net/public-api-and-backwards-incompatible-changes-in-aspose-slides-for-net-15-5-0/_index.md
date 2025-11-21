---
title: Aspose.Slides for .NET 15.5.0 的公共 API 及向后不兼容更改
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
description: "审查 Aspose.Slides for .NET 中的公共 API 更新和重大更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有已添加或已删除的类、方法、属性等，以及随 Aspose.Slides for .NET 15.5.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已添加 CommonSlideViewProperties 类和 ICommonSlideViewProperties 接口**
Aspose.Slides.CommonSlideViewProperties 类和 Aspose.Slides.ICommonSlideViewProperties 接口表示通用幻灯片视图属性（目前是视图缩放选项）。
#### **已添加 IAxis.LabelOffset 属性**
IAxis.LabelOffset 属性指定标签距坐标轴的距离。适用于类别轴或日期轴。
#### **已添加 IChartTextBlockFormat.AutofitType 属性**
更改此属性仅会对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中对渲染无效果）。
#### **已添加 IChartTextBlockFormat.WrapText 属性**
更改此属性仅会对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2007/2013 中完全支持）。
#### **已在 IChartTextBlockFormat 中添加 Margin 属性**
更改这些属性仅会对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中对渲染无效果）。
#### **已添加 ViewProperties.NotesViewProperties 属性**
Aspose.Slides.ViewProperties.NotesViewProperties 属性已添加。它指定与备注视图模式相关的通用视图属性。
#### **已添加 ViewProperties.SlideViewProperties 属性**
Aspose.Slides.ViewProperties.SlideViewProperties 属性已添加。它指定与幻灯片视图模式相关的通用视图属性。