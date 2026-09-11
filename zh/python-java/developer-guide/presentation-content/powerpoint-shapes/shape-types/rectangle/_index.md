---
title: 在 Python 中通过 Java 向演示文稿添加矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh/python-java/rectangle/
keywords:
- 添加矩形
- 创建矩形
- 矩形形状
- 简单矩形
- 格式化矩形
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 添加矩形，轻松以编程方式设计和修改形状，提升 PowerPoint 演示文稿效果。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 向 PowerPoint 幻灯片添加矩形形状。它涵盖了创建一个简单矩形、创建格式化矩形以及将更新后的演示文稿保存为 PPTX 文件。您还将了解如何应用基本的矩形格式设置，例如实心填充颜色、线条颜色和线宽。此外，本文的 FAQ 还指向相关的矩形任务，包括圆角、图片填充、视觉效果、超链接、形状锁定、导出选项以及有效属性。

## **向幻灯片添加矩形**

要向演示文稿的选定幻灯片添加一个简单矩形，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
- 通过索引获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addAutoShape) 方法，添加一种矩形类型的 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已向演示文稿的第一张幻灯片添加了一个简单矩形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 实例化表示 PPTX 文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加矩形形状。
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # 将 PPTX 文件写入磁盘。
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **向幻灯片添加格式化矩形**

要向幻灯片添加格式化矩形，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。
- 通过索引获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/#addAutoShape) 方法，添加一种矩形类型的 [AutoShape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/autoshape/)。
- 将矩形的 [fill type](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/) 设置为实心。
- 使用关联的 [Shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/) 对象的 [FillFormat](https://reference.aspose.com/slides/zh/python-java/aspose.slides/fillformat/) 对象的实心填充颜色上的 [setColor](https://reference.aspose.com/slides/zh/python-java/aspose.slides/colorformat/#setColor) 方法设置矩形的颜色。
- 设置矩形轮廓的颜色。
- 设置矩形轮廓的宽度。
- 将修改后的演示文稿写入为 PPTX 文件。

上述步骤已在下面的示例中实现。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# 实例化表示 PPTX 文件的 Presentation 类。
presentation = Presentation()
try:
    # 获取第一张幻灯片。
    slide = presentation.getSlides().get_Item(0)

    # 添加矩形形状。
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # 格式化矩形的填充。
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # 格式化矩形的轮廓。
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # 将 PPTX 文件写入磁盘。
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**如何添加带圆角的矩形？**

使用圆角 [shape type](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapetype/) 并在形状属性中调整角半径；也可以通过几何调整对每个角单独进行圆角处理。

**如何使用图像（纹理）填充矩形？**

选择图片 [fill type](https://reference.aspose.com/slides/zh/python-java/aspose.slides/filltype/)，提供图像来源，并配置 [stretching/tiling modes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/picturefillmode/)。

**矩形可以拥有阴影和辉光吗？**

可以。[Outer/inner shadow, glow, and soft edges](/slides/zh/python-java/shape-effect/) 均可使用，并提供可调参数。

**我可以将矩形转换为带超链接的按钮吗？**

可以。为形状点击[Assign a hyperlink](/slides/zh/python-java/manage-hyperlinks/)（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何保护矩形不被移动或更改？**

[Use shape locks](/slides/zh/python-java/applying-protection-to-presentation/)：您可以禁止移动、调整大小、选择或文本编辑，以保留布局。

**我可以将矩形转换为光栅图像或 SVG 吗？**

可以。您可以[render the shape](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shape/#getImage) 为具有指定尺寸/比例的图像，或[export it as SVG](/slides/zh/python-java/create-shape-thumbnails/) 导出为 SVG 以供矢量使用。

**如何快速获取考虑主题和继承的矩形实际（有效）属性？**

[Use the shape’s effective properties](/slides/zh/python-java/shape-effective-properties/)：API 返回考虑主题样式、布局和本地设置的计算值，从而简化格式分析。