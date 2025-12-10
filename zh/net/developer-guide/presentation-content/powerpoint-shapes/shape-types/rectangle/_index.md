---
title: 在 .NET 中向演示文稿添加矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh/net/rectangle/
keywords:
- 添加矩形
- 创建矩形
- 矩形形状
- 简单矩形
- 格式化矩形
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "通过使用 Aspose.Slides for .NET 添加矩形，提升您的 PowerPoint 演示文稿——轻松以编程方式设计和修改形状。"
---

## **创建简单矩形**
像前面的主题一样，本节也是关于添加形状，这次我们讨论的形状是矩形。在本主题中，我们描述了开发人员如何使用 Aspose.Slides for .NET 向幻灯片添加简单或格式化的矩形。要向演示文稿的选定幻灯片添加一个简单矩形，请按照以下步骤操作：

1. 创建一个 [演示文稿](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加 Rectangle 类型的 IAutoShape。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一个简单矩形。
```c#
 // 实例化表示 PPTX 的 Prseetation 类
using (Presentation pres = new Presentation())
{
    
    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];
    
    // 添加矩形类型的自动形状
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
    
    //写入 PPTX 文件到磁盘
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```



## **创建格式化矩形**
要向幻灯片添加格式化矩形，请按照以下步骤操作：

1. 创建一个 [演示文稿](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加 Rectangle 类型的 IAutoShape。
1. 将矩形的填充类型设置为实色。
1. 使用 FillFormat 对象关联的 IShape 对象公开的 SolidFillColor.Color 属性设置矩形的颜色。
1. 设置矩形线条的颜色。
1. 设置矩形线条的宽度。
1. 将修改后的演示文稿写入 PPTX 文件。  
   上述步骤已在下面的示例中实现。
```c#
 // 实例化表示 PPTX 的 Presentation 类
using (Presentation pres = new Presentation())
{

    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加矩形类型的自动形状
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 对矩形形状应用一些格式设置
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 对矩形的线条应用一些格式设置
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // 将 PPTX 文件写入磁盘
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **FAQ**

**如何添加带圆角的矩形？**

使用圆角 [形状类型](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) 并在形状属性中调整角半径；也可以通过几何调整对每个角单独进行圆角处理。

**如何用图像（纹理）填充矩形？**

选择图片 [填充类型](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，提供图像源，并配置 [拉伸/平铺模式](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)。

**矩形可以有阴影和发光效果吗？**

可以。[外部/内部阴影、发光和柔化边缘](/slides/zh/net/shape-effect/) 均可使用，并支持可调参数。

**能否将矩形设为带超链接的按钮？**

可以。为形状点击分配 [超链接](/slides/zh/net/manage-hyperlinks/)（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何保护矩形不被移动或更改？**

[使用形状锁定](/slides/zh/net/applying-protection-to-presentation/)：可以禁止移动、重新尺寸、选择或文本编辑，以保持布局。

**可以将矩形转换为光栅图像或 SVG 吗？**

可以。您可以 [渲染形状](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) 为指定大小/比例的图像，或 [导出为 SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) 用于矢量用途。

**如何快速获取考虑主题和继承后的矩形实际（有效）属性？**

[使用形状的有效属性](/slides/zh/net/shape-effective-properties/)：API 返回已计算的值，涵盖主题样式、布局和本地设置，从而简化格式分析。