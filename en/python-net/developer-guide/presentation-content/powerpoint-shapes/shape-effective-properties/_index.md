---
title: Get Shape Effective Properties from Presentations with Python
linktitle: Effective Properties
type: docs
weight: 50
url: /python-net/shape-effective-properties/
keywords:
- shape properties
- camera properties
- light rig
- bevel shape
- text frame
- text style
- font height
- fill format
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Discover how Aspose.Slides for Python via .NET calculates and applies effective shape properties for precise PowerPoint rendering."
---

## **Overview**

This topic explains the difference between **local** and **effective** properties. Local values are values that are set directly at a specific formatting level, such as:

1. Portion properties on a slide.
1. Prototype shape text styles on a layout or master slide, when the portion's text frame shape has one.
1. Global text settings in a presentation.

Local values can be defined or omitted at any level. When Aspose.Slides needs the final "as rendered" formatting, it resolves the inheritance chain and returns **effective** values. You can get them by calling the `get_effective` method on the local format object.

The following example shows how to get effective values. It assumes that the first shape on the first slide is an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) with a text frame and at least one portion.

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

Effective formatting data represents the current calculated formatting after inheritance is applied. In the current implementation, some effective data objects, such as [IPortionFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/), may be cached internally. Calling `get_effective` again after changing parent or inherited formatting can refresh the cached data, and a previously obtained object may no longer represent the earlier state. If you need to preserve effective values for later reuse, copy the required properties, such as font height, fill color, font style, or alignment, into your own data object.

{{% /alert %}}

## **Get Effective Properties of a Camera**

Aspose.Slides allows you to get effective properties of a camera. The [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) type represents an immutable object that contains effective camera properties. An [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), which provides effective values for [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

The following code sample shows how to get effective properties for the camera. It assumes that the first shape on the first slide has 3D formatting.

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

## **Get Effective Properties of a Light Rig**

Aspose.Slides allows you to get effective properties of a light rig. The [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) type represents an immutable object that contains effective light rig properties. An [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), which provides effective values for [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

The following code sample shows how to get effective properties for the light rig. It assumes that the first shape on the first slide has 3D formatting.

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

## **Get Effective Properties of a Bevel Shape**

Aspose.Slides allows you to get effective properties of a shape bevel. The [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) type represents an immutable object that contains effective face-relief properties for a shape. An [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) instance is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), which provides effective values for [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

The following code sample shows how to get effective properties for the top bevel of a shape. It assumes that the first shape on the first slide has 3D formatting.

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

## **Get Effective Properties of a Text Frame**

Using Aspose.Slides, you can get effective properties of a text frame. The [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) type contains effective text frame formatting properties.

The following code sample shows how to get effective text frame formatting properties. It assumes that the first shape on the first slide is an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) with a text frame.

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

## **Get Effective Properties of a Text Style**

Using Aspose.Slides, you can get effective properties of a text style. The [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) type contains effective text style properties.

The following code sample shows how to get effective text style properties. It assumes that the first shape on the first slide is an [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) with a text frame.

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

## **Get the Effective Font Height Value**

Using Aspose.Slides, you can get the effective font height. The following code demonstrates how a portion's effective font height changes after local font height values are set at different presentation structure levels.

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

## **Get the Effective Fill Format for a Table**

Using Aspose.Slides, you can get effective fill formatting for different table parts. The [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) type contains effective fill formatting properties. Cell formatting has higher priority than row formatting, row formatting has higher priority than column formatting, and column formatting has higher priority than whole-table formatting.

As a result, [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) properties are used to draw the table cell. The following code sample shows how to get effective fill formatting for different table parts. It assumes that the first shape on the first slide is a [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/).

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

**Does `get_effective` return a snapshot?**

Not always. Effective data represents the calculated formatting after inheritance is applied, but some effective data objects can be cached internally. A subsequent `get_effective` call may recalculate formatting and refresh the cached data, so a previously obtained object should not be treated as a durable snapshot.

**When should I read effective properties again?**

Call `get_effective` again after changing local formatting, parent styles, layout formatting, master formatting, or presentation-level defaults. The next call re-evaluates the formatting hierarchy and returns the current effective result.

**Does changing or removing a layout/master slide affect effective properties that have already been retrieved?**

Yes, but the change is reflected on the next `get_effective` call. If a parent formatting source is changed or removed, previously obtained effective data may be stale. Once `get_effective` is called again, Aspose.Slides re-evaluates the formatting tree and the resulting fonts, colors, sizes, or other values may change.

**Can I modify values through effective data objects?**

No. Effective data objects expose calculated values. Make changes in the local formatting objects, and then obtain the effective values again.

**What happens if a property is not set at the shape level, nor in the layout/master, nor in global settings?**

The effective value is determined by the default mechanism, which includes PowerPoint and Aspose.Slides defaults. That resolved value becomes part of the current effective data.

**From an effective font value, can I tell which level provided the size or typeface?**

Not directly. Effective data returns the final value. To find the source, check local values at the portion, paragraph, text frame, and text styles at the layout, master, and presentation levels to see where the first explicit definition appears.

**Why do effective values sometimes look identical to the local ones?**

Because the local value ended up being final (no higher-level inheritance was needed). In such cases, the effective value matches the local one.

**When should I use effective properties, and when should I work only with local ones?**

Use effective data when you need the "as rendered" result after all inheritance is applied, such as to align colors, indents, or sizes. If you need to preserve those values regardless of later formatting changes, copy the required properties into your own object. If you need to change formatting at a specific level, modify local properties and then, if needed, read the effective data again to verify the outcome.
