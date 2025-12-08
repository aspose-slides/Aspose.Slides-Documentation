---
title: 线
type: docs
weight: 50
url: /zh/net/Line/
keywords: "线, PowerPoint 形状, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加线"
---

Aspose.Slides for .NET 支持向幻灯片添加不同类型的形状。在本主题中，我们将通过向幻灯片添加直线来开始使用形状。使用 Aspose.Slides for .NET，开发人员不仅可以创建简单的直线，还可以在幻灯片上绘制一些精美的直线。

## **创建普通直线**
要向演示文稿中选定的幻灯片添加一条简单的普通直线，请按以下步骤操作：

- 创建一个 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
- 使用索引获取幻灯片的引用。
- 使用 Shapes 对象公开的 [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) 方法添加 Line 类型的 AutoShape。
- 将修改后的演示文稿保存为 PPTX 文件。

在下面的示例中，我们在演示文稿的第一张幻灯片上添加了一条直线。
```c#
// 实例化表示 PPTX 文件的 PresentationEx 类
// 获取第一张幻灯片
// 添加类型为 line 的自动形状
//Write 将 PPTX 写入磁盘
```


## **创建箭头形状的直线**
Aspose.Slides for .NET 还允许开发人员配置直线的某些属性，使其外观更具吸引力。下面尝试配置几项属性，使直线看起来像箭头。请按以下步骤操作：

- 创建一个 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/)。
- 使用索引获取幻灯片的引用。
- 使用 Shapes 对象公开的 AddAutoShape 方法添加 Line 类型的 AutoShape。
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

    // 将 PPTX 写入磁盘
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**我可以将普通直线转换为连接线，使其能够“捕捉”到形状吗？**

不可以。普通直线（类型为 [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)）不会自动变为连接线。要使其捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) 类型以及用于连接的 [corresponding APIs](/slides/zh/net/connector/)。

**如果线条的属性是从主题继承的，且难以确定最终值，我该怎么办？**

通过 [Read the effective properties](/slides/zh/net/shape-effective-properties/) 使用 [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) 类来读取有效属性——这些类已经考虑了继承和主题样式。

**我能锁定直线以防止编辑（移动、调整大小）吗？**

可以。Shapes 提供了 [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/)，使您可以 [disallow editing operations](/slides/zh/net/applying-protection-to-presentation/)。