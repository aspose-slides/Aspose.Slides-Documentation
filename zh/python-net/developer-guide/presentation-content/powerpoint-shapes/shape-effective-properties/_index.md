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
- 斜角形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 如何计算并应用有效的形状属性，以实现精准的 PowerPoint 渲染。"
---
## **概述**

本主题解释 **本地** 与 **有效** 属性之间的区别。本地值是直接在特定格式层级设置的值，例如：

1. 幻灯片上文本段属性。
1. 布局或母版幻灯片上的原型形状文本样式（当段的文本框形状拥有该样式时）。
1. 演示文稿中的全局文本设置。

本地值可以在任意层级定义或省略。当 Aspose.Slides 需要最终的“渲染后”格式时，它会解析继承链并返回 **有效** 值。可以通过在本地格式对象上调用 `get_effective` 方法获取这些值。

下面示例演示如何获取有效值。假设第一张幻灯片的第一个形状是带有文本框且至少包含一个段的 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
有效格式数据表示在应用继承后当前计算得到的格式。当前实现中，某些有效数据对象（例如 [IPortionFormatEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/iportionformateffectivedata/)）可能会在内部缓存。更改父级或继承的格式后再次调用 `get_effective` 可以刷新缓存的数据，先前获取的对象可能不再代表之前的状态。如果需要保留有效值以供后续使用，请将所需属性（如字体高度、填充颜色、字体样式或对齐方式）复制到自己的数据对象中。
{{% /alert %}}

## **获取相机的有效属性**

Aspose.Slides 允许获取相机的有效属性。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/icameraeffectivedata/) 类型表示包含有效相机属性的不可变对象。[ICameraEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/icameraeffectivedata/) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ithreedformateffectivedata/) 暴露，该对象为 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/) 提供有效值。

下面的代码示例展示如何获取相机的有效属性。假设第一张幻灯片的第一个形状具有 3D 格式。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **获取灯光装置的有效属性**

Aspose.Slides 允许获取灯光装置的有效属性。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ilightrigeffectivedata/) 类型表示包含有效灯光装置属性的不可变对象。[ILightRigEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ilightrigeffectivedata/) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ithreedformateffectivedata/) 暴露，该对象为 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/) 提供有效值。

下面的代码示例展示如何获取灯光装置的有效属性。假设第一张幻灯片的第一个形状具有 3D 格式。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **获取形状斜角的有效属性**

Aspose.Slides 允许获取形状斜角的有效属性。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ishapebeveleffectivedata/) 类型表示包含形状面部凹凸有效属性的不可变对象。[IShapeBevelEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ishapebeveleffectivedata/) 实例通过 [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ithreedformateffectivedata/) 暴露，该对象为 [ThreeDFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides/threedformat/) 提供有效值。

下面的代码示例展示如何获取形状顶部斜角的有效属性。假设第一张幻灯片的第一个形状具有 3D 格式。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **获取文本框的有效属性**

使用 Aspose.Slides，您可以获取文本框的有效属性。[ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/itextframeformateffectivedata/) 类型包含有效的文本框格式属性。

下面的代码示例展示如何获取有效的文本框格式属性。假设第一张幻灯片的第一个形状是带有文本框的 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **获取文本样式的有效属性**

使用 Aspose.Slides，您可以获取文本样式的有效属性。[ITextStyleEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/itextstyleeffectivedata/) 类型包含有效的文本样式属性。

下面的代码示例展示如何获取有效的文本样式属性。假设第一张幻灯片的第一个形状是带有文本框的 [AutoShape](https://reference.aspose.com/slides/zh/python-net/aspose.slides/autoshape/)。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **获取有效的字体高度值**

使用 Aspose.Slides，您可以获取有效的字体高度。下面的代码演示在不同演示结构层级设置本地字体高度后，段的有效字体高度如何变化。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **获取表格的有效填充格式**

使用 Aspose.Slides，您可以获取不同表格部件的有效填充格式。[IFillFormatEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ifillformateffectivedata/) 类型包含有效的填充格式属性。单元格格式的优先级高于行格式，行格式高于列格式，列格式高于整体表格格式。

因此，绘制表格单元格时使用 [ICellFormatEffectiveData](https://reference.aspose.com/slides/zh/python-net/aspose.slides/icellformateffectivedata/) 属性。下面的代码示例展示如何获取不同表格部件的有效填充格式。假设第一张幻灯片的第一个形状是 [Table](https://reference.aspose.com/slides/zh/python-net/aspose.slides/table/)。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**`get_effective` 会返回快照吗？**

不一定。有效数据表示在应用继承后计算得到的格式，但某些有效数据对象可能在内部缓存。后续的 `get_effective` 调用可能重新计算格式并刷新缓存数据，所以先前获取的对象不应视为持久快照。

**何时需要重新读取有效属性？**

在更改本地格式、父样式、布局格式、母版格式或演示级默认设置后再次调用 `get_effective`。下一次调用会重新评估格式层级并返回当前的有效结果。

**更改或删除布局/母版幻灯片会影响已获取的有效属性吗？**

会，但更改会在下次 `get_effective` 调用时体现。如果父级格式来源被更改或删除，之前获取的有效数据可能已失效。再次调用 `get_effective` 后，Aspose.Slides 会重新评估格式树，字体、颜色、大小等值可能会改变。

**可以通过有效数据对象修改值吗？**

不能。有效数据对象仅暴露计算后的值。应在本地格式对象上进行修改，然后再次获取有效值。

**如果在形状层、布局/母版或全局设置中都未设置属性，会如何？**

有效值由默认机制决定，包含 PowerPoint 和 Aspose.Slides 的默认值。解析后的值会成为当前有效数据的一部分。

**从有效字体值能否判断是哪一级提供的尺寸或字形？**

不能直接判断。有效数据返回最终值。若需寻找来源，请检查段、段落、文本框以及布局、母版和演示级别的本地值，查看首次出现的显式定义。

**为什么有效值有时看起来与本地值相同？**

因为本地值最终未被更高层级覆盖，成为最终值。在这种情况下，有效值与本地值一致。

**何时使用有效属性，何时仅使用本地属性？**

在需要“渲染后”结果（即所有继承都已应用）时使用有效数据，例如对齐颜色、缩进或尺寸。如果需要在后续格式更改后仍保留这些值，请将所需属性复制到自己的对象中。若需在特定层级修改格式，先修改本地属性，然后如有必要再次读取有效数据以验证结果。