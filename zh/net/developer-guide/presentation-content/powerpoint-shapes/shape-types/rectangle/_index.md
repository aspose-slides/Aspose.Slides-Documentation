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
如同前面的章节，这一章节同样是关于添加形状，这次我们讨论的形状是矩形。在本章节中，我们描述了开发人员如何使用 Aspose.Slides for .NET 向幻灯片添加简单或格式化的矩形。要向演示文稿中选定的幻灯片添加一个简单矩形，请按照以下步骤操作：

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 使用其 Index 获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加 Rectangle 类型的 IAutoShape。
1. 将修改后的演示文稿写入为 PPTX 文件。

以下示例中，我们已向演示文稿的第一张幻灯片添加了一个简单矩形。
```c#
 // 实例化表示 PPTX 的 Presentation 类
using (Presentation pres = new Presentation())
{

    // 获取第一张幻灯片
    ISlide sld = pres.Slides[0];

    // 添加矩形类型的自动形状
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //将 PPTX 文件写入磁盘
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **创建格式化矩形**
要向幻灯片添加格式化矩形，请按照以下步骤操作：

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
1. 使用其 Index 获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加 Rectangle 类型的 IAutoShape。
1. 将矩形的填充类型设置为 Solid。
1. 使用与 IShape 对象关联的 FillFormat 对象公开的 SolidFillColor.Color 属性设置矩形的颜色。
1. 设置矩形线条的颜色。
1. 设置矩形线条的宽度。
1. 将修改后的演示文稿写入为 PPTX 文件。

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


## **常见问题**

**如何添加带圆角的矩形？**

使用圆角 [shape type](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) 并在形状属性中调整角半径；也可以通过几何调整对每个角单独应用圆角。

**如何使用图像（纹理）填充矩形？**

选择图片 [fill type](https://reference.aspose.com/slides/net/aspose.slides/filltype/)，提供图像来源，并配置 [stretching/tiling modes](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/)。

**矩形可以有阴影和发光效果吗？**

可以。支持可调参数的 [Outer/inner shadow, glow, and soft edges](/slides/zh/net/shape-effect/) 可用于矩形。

**我可以将矩形转换为带超链接的按钮吗？**

可以。通过 [Assign a hyperlink](/slides/zh/net/manage-hyperlinks/) 为形状的点击分配超链接（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何防止矩形被移动或更改？**

[Use shape locks](/slides/zh/net/applying-protection-to-presentation/)：您可以禁止移动、调整大小、选择或编辑文本，以保持布局。

**我可以将矩形转换为光栅图像或 SVG 吗？**

可以。您可以将形状 [渲染为图像](http://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) 为指定尺寸/比例的图像，或将其 [导出为 SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) 以供矢量使用。

**如何快速获取考虑主题和继承的矩形实际（有效）属性？**

[使用形状的有效属性](/slides/zh/net/shape-effective-properties/)：API 返回考虑主题样式、布局和本地设置的计算值，简化格式分析。