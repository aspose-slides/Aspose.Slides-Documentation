---
title: 线
type: docs
weight: 50
url: /zh/net/Line/
keywords: "线，PowerPoint形状，PowerPoint演示文稿，C#，Csharp，Aspose.Slides for .NET"
description: "在C#或.NET中向PowerPoint演示文稿添加线条"
---

Aspose.Slides for .NET支持向幻灯片添加不同种类的形状。在本主题中，我们将通过向幻灯片添加线条来开始处理形状。使用Aspose.Slides for .NET，开发人员不仅可以创建简单的线条，还可以在幻灯片上绘制一些花哨的线条。
## **创建简单线条**
要在演示文稿的选定幻灯片上添加简单的线条，请按照以下步骤操作：

- 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
- 通过使用其索引获得幻灯片的引用。
- 使用Shapes对象提供的[AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index)方法添加一个线条类型的AutoShape。
- 将修改后的演示文稿写入PPTX文件。

在下面的示例中，我们已向演示文稿的第一张幻灯片添加了一条线。

```c#
// Instantiate PresentationEx class that represents the PPTX file
using (Presentation pres = new Presentation())
{
    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add an autoshape of type line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Write the PPTX to Disk
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **创建箭头形状的线条**
Aspose.Slides for .NET还允许开发人员配置线条的一些属性，以使其看起来更具吸引力。让我们尝试配置线条的几个属性，使其看起来像一个箭头。请按照以下步骤进行操作：

- 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
- 通过使用其索引获得幻灯片的引用。
- 使用Shapes对象提供的AddAutoShape方法添加一个线条类型的AutoShape。
- 将线条样式设置为Aspose.Slides for .NET提供的样式之一。
- 设置线条的宽度。
- 将线条的[虚线样式](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle)设置为Aspose.Slides for .NET提供的样式之一。
- 设置线条起点的[箭头头部样式](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle)和长度。
- 设置线条终点的箭头头部样式和长度。
- 将修改后的演示文稿写入PPTX文件。

```c#
// Instantiate PresentationEx class that represents the PPTX file
using (Presentation pres = new Presentation())
{

    // Get the first slide
    ISlide sld = pres.Slides[0];

    // Add an autoshape of type line
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Apply some formatting on the line
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //Write the PPTX to Disk
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```