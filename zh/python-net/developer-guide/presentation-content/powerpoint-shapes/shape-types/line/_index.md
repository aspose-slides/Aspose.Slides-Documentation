---
title: 在演示文稿中使用 Python 创建线形状
linktitle: 线
type: docs
weight: 50
url: /zh/python-net/line/
keywords:
- 线条
- 创建线条
- 添加线条
- 普通线
- 配置线条
- 自定义线条
- 虚线样式
- 箭头
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 在 PowerPoint 和 OpenDocument 演示文稿中操作线的格式。发现属性、方法和示例。"
---

## **概述**

Aspose.Slides for Python via .NET 支持向幻灯片添加各种形状。在本主题中，我们将通过向幻灯片添加线条开始使用形状。使用 Aspose.Slides，开发人员不仅可以创建简单的线条，还可以在幻灯片上绘制一些复杂的线条。

## **创建普通线条**

使用 Aspose.Slides 向幻灯片添加普通线条，可用作简单的分隔线或连接线。要向演示文稿中选定的幻灯片添加普通线条，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片的引用。  
3. 在 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象上使用 `add_auto_shape` 方法添加类型为 `LINE` 的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
4. 将演示文稿保存为 PPTX 文件。

下面的示例将一条线添加到演示文稿的第一张幻灯片。

```py
import aspose.slides as slides

# 实例化 Presentation 类。
with slides.Presentation() as presentation:

    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加类型为 LINE 的自动形状。
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **创建箭头形状的线条**

Aspose.Slides 允许您配置线条属性，使其在视觉上更具吸引力。下面，我们配置几项线条属性，使其看起来像一支箭头。请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 按索引获取幻灯片的引用。  
3. 在 [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) 对象上使用 `add_auto_shape` 方法添加类型为 `LINE` 的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)。  
4. 设置 [线条样式](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/)。  
5. 设置线宽。  
6. 设置线条的 [虚线样式](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)。  
7. 为线条的起点设置 [箭头样式](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) 和长度。  
8. 为线条的终点设置箭头样式和长度。  
9. 将演示文稿保存为 PPTX 文件。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类。
with slides.Presentation() as presentation:
    # 获取第一张幻灯片。
    slide = presentation.slides[0]

    # 添加类型为 LINE 的自动形状。
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 为线条应用格式设置。
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # 将演示文稿保存为 PPTX 文件。
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**我可以将普通线转换为连接线，使其“自动吸附”到形状吗？**

不可以。普通线（类型为 [LINE] 的 [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)）不会自动变为连接线。若要实现吸附到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) 类型以及相应的 API（/slides/python-net/connector/）进行连接。

**如果线的属性从主题继承，难以确定最终值，我该怎么办？**

请通过 [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) 类读取有效属性——这些类已考虑继承和主题样式。

**我可以锁定线条以防止编辑（移动、调整大小）吗？**

可以。形状提供了 [锁定对象](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/)，可用于 [禁止编辑操作](/slides/zh/python-net/applying-protection-to-presentation/)。