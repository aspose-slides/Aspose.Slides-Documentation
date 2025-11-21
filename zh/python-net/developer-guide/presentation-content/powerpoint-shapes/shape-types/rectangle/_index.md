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
description: "使用 Aspose.Slides for Python via .NET 在 PowerPoint 与 OpenDocument 演示文稿中添加矩形——轻松以编程方式设计和修改形状。"
---

## **创建简单矩形**
与之前的主题类似，此主题也关于添加形状，这次我们讨论的形状是矩形。在本主题中，我们描述了开发者如何使用 Aspose.Slides for Python via .NET 向幻灯片添加简单或格式化的矩形。要向演示文稿的选定幻灯片添加一个简单矩形，请按照以下步骤操作：

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过使用索引获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加类型为 Rectangle 的 IAutoShape。
1. 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一个简单矩形。
```py
import aspose.slides as slides

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加矩形类型的自动形状
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #写入 PPTX 文件到磁盘
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **创建格式化矩形**
要向幻灯片添加格式化矩形，请按照以下步骤操作：

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 通过使用索引获取幻灯片的引用。
1. 使用 IShapes 对象公开的 AddAutoShape 方法添加类型为 Rectangle 的 IAutoShape。
1. 将矩形的填充类型设置为实色。
1. 使用与 IShape 对象关联的 FillFormat 对象公开的 SolidFillColor.Color 属性设置矩形的颜色。
1. 设置矩形线条的颜色。
1. 设置矩形线条的宽度。
1. 将修改后的演示文稿写入为 PPTX 文件。  
上述步骤在下面的示例中实现。
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加矩形类型的自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # 对矩形形状应用一些格式设置
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # 对矩形的线条应用一些格式设置
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # 写入 PPTX 文件到磁盘
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**如何添加带圆角的矩形？**  
使用圆角 [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) 并在形状属性中调整角半径；还可以通过几何调整对每个角单独进行圆角处理。

**如何使用图片（纹理）填充矩形？**  
选择图片 [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)，提供图像来源，并配置 [stretching/tiling modes](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/)。

**矩形可以有阴影和发光效果吗？**  
是的。可使用 [Outer/inner shadow, glow, and soft edges](/slides/zh/python-net/shape-effect/) 且可调节参数。

**我可以将矩形设置为带超链接的按钮吗？**  
是的。可在形状点击时 [Assign a hyperlink](/slides/zh/python-net/manage-hyperlinks/)（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何保护矩形不被移动或更改？**  
[Use shape locks](/slides/zh/python-net/applying-protection-to-presentation/)：您可以禁止移动、大小调整、选择或文本编辑，以保护布局。

**我可以将矩形转换为光栅图像或 SVG 吗？**  
是的。您可以将形状 [render the shape](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) 为指定尺寸/比例的图像，或将其 [export it as SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) 以供矢量使用。

**如何快速获取考虑主题和继承的矩形实际（有效）属性？**  
[Use the shape’s effective properties](/slides/zh/python-net/shape-effective-properties/)：API 返回考虑主题样式、布局和本地设置的计算值，简化格式分析。