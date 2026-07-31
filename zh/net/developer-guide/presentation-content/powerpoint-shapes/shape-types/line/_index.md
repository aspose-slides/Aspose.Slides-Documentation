---
title: 在 .NET 中向演示文稿添加线形状
linktitle: 线
type: docs
weight: 50
url: /zh/net/line/
keywords:
- 线
- 创建线
- 添加线
- 普通线
- 配置线
- 自定义线
- 虚线样式
- 箭头
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中操作线条格式。探索属性、方法和示例。"
---
## **概述**

Aspose.Slides 允许您以编程方式向 PowerPoint 幻灯片添加线形状。本文展示了如何创建一条简单的直线以及如何自定义直线使其呈现为箭头。

您将学习如何向幻灯片添加线形状、调整其外观，并保存更新后的演示文稿。示例侧重于实用的线条格式设置，如样式、宽度、虚线模式、箭头选项和填充颜色。

## **创建普通直线**
要向演示文稿的选定幻灯片添加一条简单的普通直线，请按以下步骤操作：

- 创建一个 [Presentation ](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation) 类的实例。
- 使用其索引获取幻灯片的引用。
- 使用 Shapes 对象提供的 [AddAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishapecollection/methods/addautoshape/index) 方法添加 Line 类型的 AutoShape。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条直线。

```c#
// 实例化表示 PPTX 文件的 PresentationEx 类
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加类型为 line 的自动形状
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //将 PPTX 写入磁盘
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **创建带箭头的直线**
Aspose.Slides for .NET 还允许开发人员配置线条的某些属性，使其更具吸引力。让我们尝试配置几项属性，使线条看起来像箭头。请按以下步骤操作：

- 创建一个 [Presentation ](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/zh/aspose.slides/)[](http://www.aspose.com/api/net/slides/zh/aspose.slides/) 的实例。
- 使用其索引获取幻灯片的引用。
- 使用 Shapes 对象提供的 AddAutoShape 方法添加 Line 类型的 AutoShape。
- 将线条样式设置为 Aspose.Slides for .NET 提供的样式之一。
- 设置线条的宽度。
- 将线条的 [Dash Style](https://reference.aspose.com/slides/zh/net/aspose.slides/linedashstyle) 设置为 Aspose.Slides for .NET 提供的样式之一。
- 设置线条起点的 [Arrow Head Style](https://reference.aspose.com/slides/zh/net/aspose.slides/linearrowheadstyle) 和长度。
- 设置线条终点的 Arrow Head Style 和长度。
- 将修改后的演示文稿写入为 PPTX 文件。

```c#
// 实例化表示 PPTX 文件的 PresentationEx 类
using (Presentation pres = new Presentation())
{

    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加类型为 line 的自动形状
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 对线条应用一些格式设置
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //将 PPTX 写入磁盘
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **常见问题**

**我可以将普通直线转换为连接线，以便它“捕捉”到形状吗？**

不可以。普通直线（类型为 [Line](https://reference.aspose.com/slides/zh/net/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/autoshape/)）不会自动变为连接线。若要使其捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/zh/net/aspose.slides/connector/) 类型以及用于连接的 [corresponding APIs](/slides/zh/net/connector/)。

**如果线条的属性是从主题继承的，且难以确定最终值，我该怎么办？**

通过 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh/net/aspose.slides/ilinefillformateffectivedata/) 接口读取[有效属性](/slides/zh/net/shape-effective-properties/)，这些已经考虑了继承和主题样式。

**我可以锁定线条，使其不可编辑（移动、调整大小）吗？**

可以。Shapes 提供 [lock objects](https://reference.aspose.com/slides/zh/net/aspose.slides/autoshape/autoshapelock/)，可用于 [disallow editing operations](/slides/zh/net/applying-protection-to-presentation/)。