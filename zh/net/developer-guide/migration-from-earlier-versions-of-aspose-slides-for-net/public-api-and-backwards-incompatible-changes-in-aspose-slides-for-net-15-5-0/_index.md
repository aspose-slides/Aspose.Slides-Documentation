---
title: Aspose.Slides for .NET 15.5.0 中的公共 API 和不兼容更改
type: docs
weight: 160
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/
---

{{% alert color="primary" %}} 

此页面列出了在 Aspose.Slides for .NET 15.5.0 API 中添加的或移除的所有 [类](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) 、 [方法](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-5-0/) 、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **添加了 CommonSlideViewProperties 类和 ICommonSlideViewProperties 接口**
Aspose.Slides.CommonSlideViewProperties 类和 Aspose.Slides.ICommonSlideViewProperties 接口表示公共幻灯片视图属性（当前视图缩放选项）。
#### **添加了 IAxis.LabelOffset 属性**
IAxis.LabelOffset 属性指定标签与轴之间的距离。适用于类别或日期轴。
#### **添加了 IChartTextBlockFormat.AutofitType 属性**
更改此属性仅对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中没有渲染效果）。
#### **添加了 IChartTextBlockFormat.WrapText 属性**
更改此属性仅对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2007/2013 中完全支持）。
#### **在 IChartTextBlockFormat 中添加了 Margin 属性**
更改这些属性仅对以下图表部分产生一定影响：DataLabel 和 DataLabelFormat（在 PowerPoint 2013 中完全支持；在 PowerPoint 2007 中没有渲染效果）。
#### **添加了 ViewProperties.NotesViewProperties 属性**
添加了 Aspose.Slides.ViewProperties.NotesViewProperties 属性。它指定与笔记视图模式相关的公共视图属性。
#### **添加了 ViewProperties.SlideViewProperties 属性**
添加了 Aspose.Slides.ViewProperties.SlideViewProperties 属性。它指定与幻灯片视图模式相关的公共视图属性。