---
title: 在 .NET 中向演示文稿添加线形状
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
- 定制线条
- 虚线样式
- 箭头
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 操作 PowerPoint 演示文稿中的线条格式。探索属性、方法和示例。"
---

Aspose.Slides for .NET 支持向幻灯片添加各种形状。在本主题中，我们将通过向幻灯片添加直线来开始使用形状。使用 Aspose.Slides for .NET，开发人员不仅可以创建简单的直线，还可以在幻灯片上绘制一些花式直线。

## **创建普通直线**
要向演示文稿的选定幻灯片添加一条简单的普通直线，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 通过 Shapes 对象提供的 [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) 方法，添加类型为 Line 的 AutoShape。
- 将修改后的演示文稿保存为 PPTX 文件。

下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条直线。
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


## **创建箭头形状的直线**
Aspose.Slides for .NET 还允许开发人员配置直线的某些属性，使其更具吸引力。让我们尝试配置直线的几个属性，使其看起来像箭头。请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 通过 Shapes 对象提供的 AddAutoShape 方法，添加类型为 Line 的 AutoShape。
- 将线条样式设置为 Aspose.Slides for .NET 提供的样式之一。
- 设置直线的宽度。
- 将直线的 [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) 设置为 Aspose.Slides for .NET 提供的样式之一。
- 设置直线起点的 [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) 和长度。
- 设置直线终点的箭头样式和长度。
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


## **常见问题**

**我可以将普通直线转换为连接器，使其“捕捉”到形状吗？**

不行。普通直线（类型为 [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)）不会自动变为连接器。若要使其捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) 类型以及用于连接的 [corresponding APIs](/slides/zh/net/connector/)。

**如果直线的属性继承自主题，且难以确定最终值，我该怎么办？**

通过 [读取有效属性](/slides/zh/net/shape-effective-properties/) 使用 [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) 接口读取有效属性 —— 这些接口已经考虑了继承和主题样式。

**我可以锁定直线以防止编辑（移动、调整大小）吗？**

可以。Shapes 提供的 [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) 让您 [禁止编辑操作](/slides/zh/net/applying-protection-to-presentation/)。