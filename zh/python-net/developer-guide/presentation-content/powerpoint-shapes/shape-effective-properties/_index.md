---
title: 使用 Python 从演示文稿获取形状有效属性
linktitle: 有效属性
type: docs
weight: 50
url: /zh/python-net/shape-effective-properties/
keywords:
- 形状属性
- 相机属性
- 灯光装置
- 倾斜形状
- 文本框架
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何计算并应用有效形状属性，以实现精确的 PowerPoint 和 OpenDocument 渲染。"
---

## **概述**

在本主题中，您将学习 **有效** 与 **本地** 属性的概念。当在以下层级直接设置值时：

1. 幻灯片中文本部分的属性。  
2. 布局或母版幻灯片上原型形状的文本样式（如果文本框架存在）。  
3. 演示文稿的全局文本设置。

这些值称为 **本地** 值。每个层级都可以定义或省略 **本地** 值。当应用程序需要确定文本部分的显示方式时，它会使用 **有效** 值。您可以通过在本地格式上调用 `get_effective` 方法来获取有效值。

下面的示例演示如何获取文本框架格式和文本部分格式的有效值。

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

Aspose.Slides for Python via .NET 允许您检索有效相机属性。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) 类表示包含这些属性的不可变对象。[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) 的实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) 暴露，该接口提供 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 类的有效值。

以下示例展示如何获取有效相机属性：

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

Aspose.Slides for Python via .NET 允许您检索灯光装置的有效属性。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) 类表示包含这些属性的不可变对象。[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) 的实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) 暴露，该接口提供 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 类的有效值。

以下示例展示如何获取有效灯光装置属性：

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **获取有效形状斜面属性**

Aspose.Slides for Python via .NET 允许您检索形状斜面的有效属性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) 类表示包含形状面部斜面（bevel）属性的不可变对象。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) 的实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/) 暴露，该接口提供 [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 类的有效值。

以下示例展示如何获取形状斜面的有效属性：

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

## **获取有效文本框架属性**

使用 Aspose.Slides for Python via .NET，您可以检索文本框架的有效属性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) 类包含有效的文本框架格式属性。

以下示例展示如何获取有效的文本框架格式属性：

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

使用 Aspose.Slides for Python via .NET，您可以检索文本样式的有效属性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) 类包含有效的文本样式属性。

以下示例展示如何获取有效的文本样式属性：

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

使用 Aspose.Slides for Python via .NET，您可以检索有效的字体高度。下面的示例演示当在演示文稿结构的不同层级设置本地字体高度时，文本部分的有效字体高度如何变化。

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

使用 Aspose.Slides for Python via .NET，您可以检索表格不同逻辑部分的有效填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) 类包含有效的填充格式属性。注意，单元格格式始终优先于行格式，行格式优先于列格式，列格式优先于整个表格。

因此，最终用于绘制表格的是 [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) 的属性。以下示例展示如何获取不同表格层级的有效填充格式：

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

**我如何判断得到的是 “快照” 而不是 “实时对象”，以及何时需要重新读取有效属性？**  
EffectiveData 对象是调用时计算值的不可变快照。如果您更改了形状的本地或继承设置，请再次检索 EffectiveData 以获取更新后的值。

**更改布局/母版幻灯片会影响已获取的有效属性吗？**  
会，但只有在您再次读取它们之后。已获取的 EffectiveData 对象不会自行更新——在更改布局或母版后再次请求即可。

**我可以通过 EffectiveData 修改值吗？**  
不能。EffectiveData 只读。请在本地格式对象（形状/文本/3D 等）中进行更改，然后再次获取有效值。

**如果某属性在形状层、布局/母版层以及全局设置中都未设置，会怎样？**  
有效值将由默认机制（PowerPoint/Aspose.Slides 的默认值）决定。该解析后的值成为 EffectiveData 快照的一部分。

**从有效字体值中，我能否判断是哪一级提供了大小或字体？**  
不能直接判断。EffectiveData 返回最终值。若想追溯来源，需要检查文本部分/段落/文本框的本地值以及布局/母版/演示文稿的文本样式，找出首次出现的显式定义。

**为什么 EffectiveData 值有时看起来与本地值完全相同？**  
因为本地值已经是最终值（不需要更高层级的继承），所以有效值与本地值相同。

**何时应使用有效属性，何时仅使用本地属性？**  
在需要“渲染后”结果（例如对齐颜色、缩进或尺寸）时使用 EffectiveData。如果只需在特定层级修改格式，直接操作本地属性，然后在需要时重新读取 EffectiveData 以验证结果。