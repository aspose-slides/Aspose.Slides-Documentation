---
title: 矩形
type: docs
weight: 80
url: /net/rectangle/
keywords: "创建矩形, PowerPoint形状, PowerPoint演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在C# 或 .NET中创建PowerPoint演示文稿中的矩形"
---


## **创建简单矩形**
与前面的主题一样，本主题也是关于添加形状，这次我们讨论的形状是矩形。在本主题中，我们描述了开发人员如何使用Aspose.Slides for .NET将简单或格式化的矩形添加到其幻灯片中。要将简单矩形添加到演示文稿的选定幻灯片中，请按照以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 使用IShapes对象暴露的AddAutoShape方法添加矩形类型的IAutoShape。
1. 将修改后的演示文稿写入PPTX文件。

在下面给出的示例中，我们已将简单的矩形添加到演示文稿的第一张幻灯片中。

```c#
// 实例化表示PPTX的Presentation类
using (Presentation pres = new Presentation())
{

    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加矩形类型的自定义形状
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //将PPTX文件写入磁盘
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **创建格式化矩形**
要将格式化矩形添加到幻灯片，请按照以下步骤操作：

1. 创建[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 使用IShapes对象暴露的AddAutoShape方法添加矩形类型的IAutoShape。
1. 将矩形的填充类型设置为实心。
1. 使用与IShape对象相关联的FillFormat对象暴露的SolidFillColor.Color属性设置矩形的颜色。
1. 设置矩形线条的颜色。
1. 设置矩形线条的宽度。
1. 将修改后的演示文稿写入PPTX文件。
   上述步骤在下面给出的示例中实现。

```c#
// 实例化表示PPTX的Presentation类
using (Presentation pres = new Presentation())
{

    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加矩形类型的自定义形状
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 对矩形形状应用一些格式设置
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 对矩形的线条应用一些格式设置
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //将PPTX文件写入磁盘
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```