---
title: 椭圆
type: docs
weight: 30
url: /zh/net/ellipse/
keywords: "椭圆, PowerPoint形状, PowerPoint演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在C#或.NET中创建PowerPoint演示文稿中的椭圆"
---


## **创建椭圆**
在本主题中，我们将向开发人员介绍如何使用Aspose.Slides for .NET将椭圆形状添加到其幻灯片中。Aspose.Slides for .NET提供了一套更简单的API，只需几行代码即可绘制各种形状。要将简单的椭圆添加到演示文稿的选定幻灯片中，请按照以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例
1. 通过使用索引获取幻灯片的引用
1. 使用IShapes对象暴露的AddAutoShape方法添加椭圆类型的AutoShape
1. 将修改后的演示文稿写入PPTX文件

在下面给出的示例中，我们已将椭圆添加到第一张幻灯片中。

```c#
// 实例化代表PPTX的Presentation类
using (Presentation pres = new Presentation())
{

    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加椭圆类型的自动形状
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //将PPTX文件写入磁盘
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **创建格式化的椭圆**
要将格式更好的椭圆添加到幻灯片中，请按照以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 通过使用索引获取幻灯片的引用。
1. 使用IShapes对象暴露的AddAutoShape方法添加椭圆类型的AutoShape。
1. 将椭圆的填充类型设置为实心。
1. 使用与IShape对象关联的FillFormat对象暴露的SolidFillColor.Color属性设置椭圆的颜色。
1. 设置椭圆线条的颜色。
1. 设置椭圆线条的宽度。
1. 将修改后的演示文稿写入PPTX文件。

在下面给出的示例中，我们已将格式化的椭圆添加到演示文稿的第一张幻灯片中。

```c#
// 实例化代表PPTX的Presentation类
using (Presentation pres = new Presentation())
{

    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加椭圆类型的自动形状
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 对椭圆形状应用一些格式
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 对椭圆的线条应用一些格式
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //将PPTX文件写入磁盘
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```