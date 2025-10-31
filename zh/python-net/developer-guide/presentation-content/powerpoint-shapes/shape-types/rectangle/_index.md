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
description: "通过 Aspose.Slides for Python via .NET，轻松以编程方式设计和修改形状，提升您的 PowerPoint 与 OpenDocument 演示文稿的矩形添加功能。"
---

## **创建简单矩形**
像前面的主题一样，本节也讨论添加形状，这次我们讨论的形状是 Rectangle。 在本主题中，我们描述了开发人员如何使用 Aspose.Slides for Python via .NET 向幻灯片添加简单或格式化的矩形。 要向演示文稿的选定幻灯片添加一个简单矩形，请按照以下步骤操作：

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加 Rectangle 类型的 IAutoShape。
1. 将修改后的演示文稿保存为 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一个简单矩形。

```py
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加矩形类型的自动形状
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 将 PPTX 文件写入磁盘
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **创建格式化矩形**
要向幻灯片添加格式化矩形，请按照以下步骤操作：

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加 Rectangle 类型的 IAutoShape。
1. 将矩形的填充类型设为 Solid。
1. 使用 FillFormat 对象关联的 SolidFillColor.Color 属性设置矩形的填充颜色。
1. 设置矩形线条的颜色。
1. 设置矩形线条的宽度。
1. 将修改后的演示文稿保存为 PPTX 文件。
   上述步骤已在下面的示例中实现。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加矩形类型的自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 对矩形形状应用一些格式
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 对矩形的线条应用一些格式
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # 将 PPTX 文件写入磁盘
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**如何添加带圆角的矩形？**

使用圆角的 [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) 并在形状属性中调整角半径；也可以通过几何调整对每个角单独应用圆角。

**如何使用图片（纹理）填充矩形？**

选择图片 [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，提供图像源，并配置 [stretching/tiling modes](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)。

**矩形可以有阴影和辉光吗？**

可以。支持 [外部/内部阴影、辉光和柔边](/slides/zh/python-net/shape-effect/) 并提供可调参数。

**我可以把矩形设为带超链接的按钮吗？**

可以。将超链接 [Assign a hyperlink](/slides/zh/python-net/manage-hyperlinks/) 赋给形状点击（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何保护矩形不被移动或修改？**

使用 [shape locks](/slides/zh/python-net/applying-protection-to-presentation/)：可以禁止移动、重新大小、选择或文本编辑，以保留布局。

**我可以将矩形转换为光栅图像或 SVG 吗？**

可以。您可以 [render the shape](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) 为指定大小/比例的图像，或 [export it as SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) 进行矢量使用。

**如何快速获取考虑主题和继承后的矩形实际（有效）属性？**

使用形状的 [effective properties](/slides/zh/python-net/shape-effective-properties/)：API 返回考虑主题样式、布局和本地设置的计算值，简化格式分析。