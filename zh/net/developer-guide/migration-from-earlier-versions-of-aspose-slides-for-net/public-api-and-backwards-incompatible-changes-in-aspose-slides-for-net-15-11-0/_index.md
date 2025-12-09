---
title: Aspose.Slides for .NET 15.11.0 中的公共 API 及向后不兼容更改
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)或[已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)的类、方法、属性等，以及在 Aspose.Slides for .NET 15.11.0 API 中引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**

#### **已删除 DataLabelCollection 类中的已弃用属性**
已删除 DataLabelCollection 类中的已弃用属性：

Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **已在 Presentation 类中添加新属性 FirstSlideNumber**
在 Presentation 中添加的属性 FirstSlideNumber 允许获取或设置演示文稿中第一张幻灯片的编号。

当指定新的 FirstSlideNumber 值时，所有幻灯片编号将重新计算。

``` csharp
using(var pres = new Presenation(path))
{
  int firstSlideNumber = pres.FirstSlideNumber;
  pres.FirstSlideNumber = 10;
  pres.Save(newPath, SaveFormat.Pptx);
}
```