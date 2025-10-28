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
- 倒角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何计算并应用形状有效属性，以实现精准的 PowerPoint 和 OpenDocument 渲染。"
---

## **概述**

在本主题中，您将了解 **有效** 与 **局部** 属性的概念。当值直接在以下层级设置时：

1. 幻灯片上的文本部分属性。
2. 布局或母版幻灯片中原型形状的文本样式（如果文本框具有样式）。
3. 演示文稿的全局文本设置。

这些值称为 **局部** 值。每个层级都可以定义或省略 **局部** 值。当应用程序需要确定文本部分的显示方式时，会使用 **有效** 值。您可以通过在局部格式上调用 `get_effective` 方法来获取有效值。

下面的示例演示如何获取文本框格式和文本部分格式的有效值。

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **获取有效的相机属性**

Aspose.Slides for Python via .NET 允许您检索有效的相机属性。`[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/)` 类表示一个不可变对象，其中包含这些属性。`[ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/)` 的实例通过 `[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)` 暴露，后者提供 `[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)` 类的有效值。

下面的示例演示如何获取有效的相机属性：

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

## **获取有效的灯光装置属性**

Aspose.Slides for Python via .NET 允许您检索灯光装置的有效属性。`[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/)` 类表示一个不可变对象，其中包含这些属性。`[ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/)` 的实例通过 `[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)` 暴露，后者提供 `[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)` 类的有效值。

下面的示例演示如何获取有效的灯光装置属性：

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **获取有效的形状倒角属性**

Aspose.Slides for Python via .NET 允许您检索形状倒角的有效属性。`[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/)` 类表示一个不可变对象，其中包含形状面部倒角（倒角）属性。`[IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/)` 的实例通过 `[IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/)` 暴露，后者提供 `[ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/)` 类的有效值。

下面的示例演示如何获取形状倒角的有效属性：

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

## **获取有效的文本框属性**

使用 Aspose.Slides for Python via .NET，您可以检索文本框的有效属性。`[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/)` 类包含文本框的有效格式属性。

下面的示例演示如何获取文本框的有效格式属性：

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

## **获取有效的文本样式属性**

使用 Aspose.Slides for Python via .NET，您可以检索文本样式的有效属性。`[ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/)` 类包含文本样式的有效属性。

下面的示例演示如何获取文本样式的有效属性：

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

## **获取有效的字体高度**

使用 Aspose.Slides for Python via .NET，您可以检索有效的字体高度。下面的示例演示当在演示文稿结构的不同层级设置局部字体高度时，文本部分的有效字体高度是如何变化的。

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

## **获取有效的表格填充格式**

使用 Aspose.Slides for Python via .NET，您可以检索表格不同逻辑部分的有效填充格式。`[IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/)` 类包含有效的填充格式属性。请注意，单元格格式的优先级始终高于行格式，行格式高于列格式，列格式高于整个表格。

因此，最终用于绘制表格的是 `[ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/)` 的属性。下面的示例演示如何获取不同表格层级的有效填充格式：

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

## **常见问题**

**如何判断得到的是 “快照” 而非 “实时对象”，以及何时需要重新读取有效属性？**  
EffectiveData 对象是调用时计算值的不可变快照。如果您修改了形状的局部或继承设置，需要再次获取有效数据以获得更新后的值。

**更改布局/母版幻灯片会影响已经获取的有效属性吗？**  
会，但只有在再次读取后才会体现。已经获取的 EffectiveData 对象不会自动更新；更改布局或母版后请重新请求。

**我可以通过 EffectiveData 修改值吗？**  
不能。EffectiveData 是只读的。请在局部格式对象（形状/文本/3D 等）中进行修改，然后再次获取有效值。

**如果在形状层级、布局/母版以及全局设置中都未设置某属性，会怎样？**  
有效值将由默认机制（PowerPoint/Aspose.Slides 的默认值）决定。该解析后的值会成为 EffectiveData 快照的一部分。

**从有效的字体值能否判断是哪一级提供了尺寸或字体？**  
不能直接判断。EffectiveData 只返回最终值。若需追溯来源，请检查段落/文本框/部分的局部值以及布局/母版/演示文稿的文本样式，以找出首次出现的显式定义。

**为什么 EffectiveData 的值有时看起来与局部值相同？**  
因为局部值最终成为了最终值（未需要更高层级的继承），所以有效值与局部值相匹配。

**何时使用有效属性，何时仅使用局部属性？**  
当需要在所有继承应用后得到“渲染后”结果时使用 EffectiveData（例如对齐颜色、缩进或尺寸）。如果只需在特定层级修改格式，请修改局部属性，并在需要时重新读取 EffectiveData 以验证结果。