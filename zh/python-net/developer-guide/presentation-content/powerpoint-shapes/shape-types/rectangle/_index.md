---
title: 在 Python 中向演示文稿添加矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh/python-net/rectangle/
keywords:
- 添加矩形
- 创建矩形
- 矩形形状
- 简单矩形
- 格式化矩形
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "通过使用 Aspose.Slides for Python via .NET 向 PowerPoint 和 OpenDocument 演示文稿添加矩形，轻松以编程方式设计和修改形状。"
---

## **创建简单矩形**
与之前的主题类似，本章节同样是关于添加形状，这次我们讨论的形状是矩形。在本主题中，我们描述了开发者如何使用 Aspose.Slides for Python via .NET 向幻灯片添加简单或格式化的矩形。要向演示文稿的选定幻灯片添加一个简单矩形，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过使用索引获取幻灯片的引用。
3. 使用 IShapes 对象公开的 AddAutoShape 方法添加一个 Rectangle 类型的 IAutoShape。
4. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一个简单矩形。

```py
import aspose.slides as slides

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Write the PPTX file to disk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **创建格式化矩形**
要向幻灯片添加格式化矩形，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过使用索引获取幻灯片的引用。
3. 使用 IShapes 对象公开的 AddAutoShape 方法添加一个 Rectangle 类型的 IAutoShape。
4. 将矩形的填充类型设置为实心。
5. 使用与 IShape 对象关联的 FillFormat 对象公开的 SolidFillColor.Color 属性设置矩形的颜色。
6. 设置矩形线条的颜色。
7. 设置矩形线条的宽度。
8. 将修改后的演示文稿写入为 PPTX 文件。
   上述步骤在下面的示例中实现。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Apply some formatting to rectangle shape
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Apply some formatting to the line of rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write the PPTX file to disk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**如何添加圆角矩形？**

使用圆角 [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) 并在形状属性中调整角半径；也可以通过几何调整对每个角单独进行圆角处理。

**如何用图像（纹理）填充矩形？**

选择图片 [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，提供图像源，并配置 [stretching/tiling modes](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)。

**矩形可以有阴影和发光效果吗？**

可以。[外部/内部阴影、发光和柔化边缘](/slides/zh/python-net/shape-effect/) 均可使用，并提供可调参数。

**我可以将矩形变成带超链接的按钮吗？**

可以。为形状点击[分配超链接](/slides/zh/python-net/manage-hyperlinks/)（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何保护矩形不被移动或修改？**

[使用形状锁定](/slides/zh/python-net/applying-protection-to-presentation/)：可以禁止移动、缩放、选择或文本编辑，以保持布局。

**我可以将矩形转换为光栅图像或 SVG 吗？**

可以。您可以将形状[渲染为图像](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)（指定尺寸/比例），或将其[导出为 SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/)用于矢量使用。

**如何快速获取考虑主题和继承后的矩形实际（有效）属性？**

[使用形状的有效属性](/slides/zh/python-net/shape-effective-properties/)：API 返回考虑主题样式、布局和本地设置的计算值，简化格式分析。