---
title: 在 .NET 中向演示文稿添加椭圆
linktitle: 椭圆
type: docs
weight: 30
url: /zh/net/ellipse/
keywords:
- 椭圆
- 形状
- 添加椭圆
- 创建椭圆
- 绘制椭圆
- 格式化椭圆
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中创建、格式化和操作椭圆形状，适用于 PPT 和 PPTX 演示文稿——包含 C# 代码示例。"
---

## **创建椭圆**
在本主题中，我们将向开发人员介绍如何使用 Aspose.Slides for .NET 向幻灯片添加椭圆形状。Aspose.Slides for .NET 提供了一组更简便的 API，只需几行代码即可绘制各种形状。要在演示文稿的选定幻灯片上添加一个简单的椭圆，请按照以下步骤操作：

1. 创建一个[Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例
1. 使用索引获取幻灯片的引用
1. 使用 IShapes 对象提供的 AddAutoShape 方法添加椭圆类型的 AutoShape
1. 将修改后的演示文稿写入为 PPTX 文件

在下面的示例中，我们已在第一页幻灯片上添加了一个椭圆。
```c#
 // 实例化表示 PPTX 的 Presentation 类
using (Presentation pres = new Presentation())
{
    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加椭圆类型的自动形状
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 将 PPTX 文件写入磁盘
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```




## **创建格式化椭圆**
要在幻灯片上添加格式更好的椭圆，请按照以下步骤操作：

1. 创建一个[Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 IShapes 对象提供的 AddAutoShape 方法添加椭圆类型的 AutoShape。
1. 将椭圆的填充类型设置为实心。
1. 使用与 IShape 对象关联的 FillFormat 对象公开的 SolidFillColor.Color 属性设置椭圆的颜色。
1. 设置椭圆线条的颜色。
1. 设置椭圆线条的宽度。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已在演示文稿的第一页幻灯片上添加了一个格式化的椭圆。
```c#
// 实例化表示 PPTX 的 Presentation 类
using (Presentation pres = new Presentation())
{

    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加椭圆类型的自动形状
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 对椭圆形状应用一些格式设置
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 对椭圆线条应用一些格式设置
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //将 PPTX 文件写入磁盘
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**如何相对于幻灯片的单位设置椭圆的精确位置和大小？**

坐标和尺寸通常以 **in points** 为单位指定。为获得可预期的结果，请基于幻灯片大小进行计算，并在赋值之前将所需的毫米或英寸转换为点。

**如何将椭圆放置在其他对象之上或之下（控制堆叠顺序）？**

通过将对象置于最前或发送到最背来调整其绘制顺序。这使得椭圆可以覆盖其他对象或显示其下方的对象。

**如何为椭圆添加出现或强调的动画？**

[应用](/slides/zh/net/shape-animation/) 进入、强调或退出效果到形状，并配置触发器和时间，以安排动画的播放时机和方式。