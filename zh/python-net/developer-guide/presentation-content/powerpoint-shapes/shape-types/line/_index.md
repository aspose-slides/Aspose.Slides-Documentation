---
title: 线
type: docs
weight: 50
url: /python-net/line/
keywords: "线, PowerPoint 形状, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中的 PowerPoint 演示文稿中添加线"
---

Aspose.Slides for Python via .NET 支持向幻灯片添加不同种类的形状。在本主题中，我们将通过向幻灯片添加线条开始处理形状。使用 Aspose.Slides for Python via .NET，开发者不仅可以创建简单的线条，还可以在幻灯片上绘制一些花哨的线条。
## **创建普通线条**
要向演示文稿的选定幻灯片添加简单的普通线条，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 使用 Shapes 对象提供的 [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 方法添加一种线条类型的自动形状。
- 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们在演示文稿的第一张幻灯片上添加了一条线。

```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 PresentationEx 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加一种类型为线的自动形状
    sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 将 PPTX 写入磁盘
    pres.save("LineShape1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **创建箭头形状线条**
Aspose.Slides for Python via .NET 还允许开发者配置线条的一些属性，以使其看起来更具吸引力。让我们尝试配置线条的几个属性，使其看起来像箭头。请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 使用 Shapes 对象提供的 AddAutoShape 方法添加一种线条类型的自动形状。
- 将线条样式设置为 Aspose.Slides for Python via .NET 提供的样式之一。
- 设置线条的宽度。
- 将线条的 [虚线样式](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) 设置为 Aspose.Slides for Python via .NET 提供的样式之一。
- 设置线条起始点的 [箭头头样式](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) 和长度。
- 设置线条的终点的箭头头样式和长度。
- 将修改后的演示文稿写入 PPTX 文件。

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 PresentationEx 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 添加一种类型为线的自动形状
    shp = sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # 对线条应用一些格式
    shp.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shp.line_format.width = 10

    shp.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shp.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shp.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shp.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shp.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # 将 PPTX 写入磁盘
    pres.save("LineShape2_out.pptx", slides.export.SaveFormat.PPTX)
```