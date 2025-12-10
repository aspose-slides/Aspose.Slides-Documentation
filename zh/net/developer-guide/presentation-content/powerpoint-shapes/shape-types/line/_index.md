---
title: 在 .NET 中向演示文稿添加线条形状
linktitle: 线条
type: docs
weight: 50
url: /zh/net/Line/
keywords:
- 线条
- 创建线条
- 添加线条
- 普通线条
- 配置线条
- 自定义线条
- 虚线样式
- 箭头
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中操作线条格式。探索属性、方法和示例。"
---

Aspose.Slides for .NET 支持向幻灯片添加不同类型的形状。本文将从向幻灯片添加直线开始介绍形状的使用。使用 Aspose.Slides for .NET，开发者不仅可以创建普通直线，还可以在幻灯片上绘制一些花式直线。

## **创建普通直线**
要在演示文稿的选定幻灯片上添加一条简单的普通直线，请按以下步骤操作：

- 创建一个 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class 的实例。
- 使用幻灯片的 Index 获取幻灯片引用。
- 通过 Shapes 对象公开的 [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) 方法添加 Line 类型的 AutoShape。
- 将修改后的演示文稿保存为 PPTX 文件。

下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条直线。
```c#
// 实例化表示 PPTX 文件的 PresentationEx 类
using (Presentation pres = new Presentation())
{
    // 获取第一页幻灯片
    ISlide sld = pres.Slides[0];

    // 添加类型为 line 的自动形状
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //将 PPTX 写入磁盘
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **创建箭头形状的直线**
Aspose.Slides for .NET 还允许开发者配置直线的部分属性，使其更具美观性。下面尝试配置一些属性，使直线呈现为箭头形状。请按以下步骤操作：

- 创建一个 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/) 的实例。
- 使用幻灯片的 Index 获取幻灯片引用。
- 通过 Shapes 对象的 AddAutoShape 方法添加 Line 类型的 AutoShape。
- 将线条样式设置为 Aspose.Slides for .NET 提供的样式之一。
- 设置线条的宽度。
- 将线条的 [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) 设置为 Aspose.Slides for .NET 提供的样式之一。
- 设置线条起点的 [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) 和长度。
- 设置线条终点的 Arrow Head Style 和长度。
- 将修改后的演示文稿保存为 PPTX 文件。
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


## **FAQ**

**是否可以将普通直线转换为连接线，使其“捕捉”到形状上？**

不可以。普通直线（类型为 [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)）不会自动成为连接线。要实现捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) 类型以及用于连接的 [对应 API](/slides/zh/net/connector/)。

**如果直线的属性继承自主题且难以确定最终值，该怎么办？**

通过 [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) 接口读取 [有效属性](/slides/zh/net/shape-effective-properties/)，这些接口已考虑继承和主题样式。

**是否可以锁定直线，防止编辑（移动、调整大小）？**

可以。Shapes 提供的 [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) 允许您 [禁用编辑操作](/slides/zh/net/applying-protection-to-presentation/)。