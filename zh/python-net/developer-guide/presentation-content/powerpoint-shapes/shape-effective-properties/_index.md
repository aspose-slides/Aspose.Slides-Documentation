---
title: 从演示文稿中使用 Python 获取形状有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/python-net/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
- 灯光装置
- 斜角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何计算并应用有效的形状属性，以实现精确的 PowerPoint 和 OpenDocument 渲染。"
---

## **概述**

在本主题中，您将学习 **有效** 和 **本地** 属性的概念。当在以下级别直接设置值时：

1. 幻灯片上的文本段落属性。
2. 布局或母版幻灯片上原型形状的文本样式（如果文本框有的话）。
3. 演示文稿的全局文本设置。

这些值称为 **本地** 值。任何级别都可以定义或省略 **本地** 值。当应用程序需要确定文本段落应如何显示时，它使用 **有效** 值。您可以通过调用本地格式的 `get_effective` 方法来获取 **有效** 值。

以下示例展示了如何获取文本框格式和文本段落格式的 **有效** 值。
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```


## **获取有效相机属性**

Aspose.Slides for Python via .NET 允许您检索 **有效** 相机属性。 [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) 类表示包含这些属性的不可变对象。通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) 暴露的 [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) 实例提供了 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 类的 **有效** 值。

以下示例展示了如何获取 **有效** 相机属性：
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective camera properties =")
	print("Type:", str(three_d_effective_data.camera.camera_type))
	print("Field of view:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```


## **获取有效灯光装置属性**

Aspose.Slides for Python via .NET 允许您检索灯光装置的 **有效** 属性。 [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) 类表示包含这些属性的不可变对象。通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) 暴露的 [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) 实例提供了 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 类的 **有效** 值。

以下示例展示了如何获取 **有效** 灯光装置属性：
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```


## **获取有效形状斜角属性**

Aspose.Slides for Python via .NET 允许您检索形状斜角的 **有效** 属性。 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) 类表示包含形状面部凹凸（斜角）属性的不可变对象。通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) 暴露的 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) 实例提供了 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 类的 **有效** 值。

以下示例展示了如何获取形状斜角的 **有效** 属性：
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective shape's top face relief properties =")
	print("Type:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Width:", str(three_d_effective_data.bevel_top.width))
	print("Height:", str(three_d_effective_data.bevel_top.height))
```


## **获取有效文本框属性**

使用 Aspose.Slides for Python via .NET，您可以检索文本框的 **有效** 属性。 [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) 类包含 **有效** 文本框格式属性。

以下示例展示了如何获取 **有效** 文本框格式属性：
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Anchoring type:", str(text_frame_format_effective_data.anchoring_type))
	print("Autofit type:", str(text_frame_format_effective_data.autofit_type))
	print("Text vertical type:", str(text_frame_format_effective_data.text_vertical_type))
	print("Margins")
	print("   Left:", str(text_frame_format_effective_data.margin_left))
	print("   Top:", str(text_frame_format_effective_data.margin_top))
	print("   Right:", str(text_frame_format_effective_data.margin_right))
	print("   Bottom:", str(text_frame_format_effective_data.margin_bottom))
```


## **获取有效文本样式属性**

使用 Aspose.Slides for Python via .NET，您可以检索文本样式的 **有效** 属性。 [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) 类包含 **有效** 文本样式属性。

以下示例展示了如何获取 **有效** 文本样式属性：
```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Effective paragraph formatting for style level #{str(i)} =")

        print("Depth:", str(effectiveStyleLevel.depth))
        print("Indent:", str(effectiveStyleLevel.indent))
        print("Alignment:", str(effectiveStyleLevel.alignment))
        print("Font alignment:", str(effectiveStyleLevel.font_alignment))
```


## **获取有效字体高度**

使用 Aspose.Slides for Python via .NET，您可以检索 **有效** 字体高度。下面的示例演示了当您在演示文稿结构的不同级别设置本地字体高度值时，文本段落的 **有效** 字体高度是如何变化的。
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)

    shape.add_text_frame("")
    paragraph = shape.text_frame.paragraphs[0]

    portion0 = slides.Portion("Sample text with first portion")
    portion1 = slides.Portion(" and second portion.")

    paragraph.portions.add(portion0)
    paragraph.portions.add(portion1)

    print("Effective font height just after creation:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Effective font height after setting entire presentation default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **获取有效表格填充格式**

使用 Aspose.Slides for Python via .NET，您可以检索表格不同逻辑部分的 **有效** 填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) 类包含 **有效** 填充格式属性。请注意，单元格格式始终优先于行格式，行格式优先于列格式，列格式优先于整个表格。

因此，最终使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) 的属性来绘制表格。以下示例展示了如何获取不同表格层级的 **有效** 填充格式：
```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	table = presentation.slides[0].shapes[0]

	table_format_effective = table.table_format.get_effective()
	row_format_effective = table.rows[0].row_format.get_effective()
	column_format_effective = table.columns[0].column_format.get_effective()
	cell_format_effective = table[0, 0].cell_format.get_effective()

	table_fill_format_effective = table_format_effective.fill_format
	row_fill_format_effective = row_format_effective.fill_format
	column_fill_format_effective = column_format_effective.fill_format
	cell_fill_format_effective = cell_format_effective.fill_format
```


## **常见问题解答**

**如何判断获得的是“快照”而不是“实时对象”，以及何时需要重新读取 **有效** 属性？**

EffectiveData 对象是调用时计算值的不可变快照。如果您更改了形状的本地或继承设置，请再次检索 **有效** 数据以获取更新后的值。

**更改布局/母版幻灯片会影响已检索的 **有效** 属性吗？**

会，但只有在您再次读取后才会生效。已经获取的 EffectiveData 对象不会自行更新——在更改布局或母版后请重新请求。

**我可以通过 EffectiveData 修改值吗？**

不能。EffectiveData 只读。请在本地格式对象（形状/文本/3D 等）中进行更改，然后再次获取 **有效** 值。

**如果在形状级别、布局/母版以及全局设置中都未设置某属性，会怎样？**

**有效** 值将由默认机制（PowerPoint/Aspose.Slides 默认值）决定。解析后的默认值将成为 EffectiveData 快照的一部分。

**从 **有效** 字体值能否判断出是哪一级提供的大小或字体？**

不能直接判断。EffectiveData 返回最终值。若要追溯来源，请检查段落/文本框/段落文本的本地值以及布局/母版/演示文稿的文本样式，以确定首次出现显式定义的级别。

**为什么 **有效** 数据值有时看起来与本地值相同？**

因为本地值最终成为了最终值（没有更高层级的继承）。在此情况下，**有效** 值与本地值相匹配。

**什么时候应使用 **有效** 属性，什么时候仅使用本地属性？**

当您需要在所有继承应用后得到“实际渲染”结果时（例如对齐颜色、缩进或尺寸），使用 EffectiveData。如果您只需在特定层级修改格式，请修改本地属性，然后在需要时重新读取 EffectiveData 以验证结果。