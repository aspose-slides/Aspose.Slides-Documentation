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
description: "Discover how Aspose.Slides for Python via .NET calculates and applies effective shape properties for precise PowerPoint and OpenDocument rendering."
---

## **Overview**

In this topic, you will learn the concepts of **effective** and **local** properties. When values are set directly at the following levels:

1. In the text portion properties on the slide.
2. In the prototype shape’s text style on the layout or master slide (if the text frame has one).
3. In the presentation’s global text settings.

those values are called **local** values. At any level, **local** values may be defined or omitted. When the application needs to determine how the text portion should appear, it uses the **effective** values. You can obtain the effective values by calling the `get_effective` method on the local format.

The following example shows how to get the effective values for a text frame format and a text portion format.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **Get Effective Camera Properties**

Aspose.Slides for Python via .NET allows you to retrieve the effective camera properties. The [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) class represents an immutable object that contains these properties. An instance of [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), which provides the effective values for the [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) class.

The following example shows how to get the effective camera properties:

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

## **Get Effective Light Rig Properties**

Aspose.Slides for Python via .NET allows you to retrieve the effective properties of a light rig. The [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) class represents an immutable object that contains these properties. An instance of [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), which provides the effective values for the [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) class.

The following example shows how to get the effective light rig properties:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **Get Effective Shape Bevel Properties**

Aspose.Slides for Python via .NET allows you to retrieve the effective properties of a shape bevel. The [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) class represents an immutable object that contains a shape’s face-relief (bevel) properties. An instance of [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) is exposed through [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), which provides the effective values for the [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) class.

The following example shows how to get the effective properties for a shape bevel:

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

## **Get Effective Text Frame Properties**

Using Aspose.Slides for Python via .NET, you can retrieve the effective properties of a text frame. The [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) class contains the effective text frame formatting properties.

The following example shows how to get the effective text frame formatting properties:

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

## **Get Effective Text Style Properties**

Using Aspose.Slides for Python via .NET, you can retrieve the effective properties of a text style. The [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) class contains the effective text style properties.

The following example shows how to get the effective text style properties:

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

## **Get Effective Font Height**

Using Aspose.Slides for Python via .NET, you can retrieve the effective font height. The example below demonstrates how a text portion’s effective font height changes as you set local font height values at different levels of the presentation structure.

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

## **Get Effective Table Fill Format**

Using Aspose.Slides for Python via .NET, you can retrieve the effective fill formatting for different logical parts of a table. The [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) class contains the effective fill formatting properties. Note that cell formatting always has higher priority than row formatting, a row has higher priority than a column, and a column has higher priority than the whole table.

Therefore, [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) properties are ultimately used to draw the table. The following example shows how to get the effective fill formatting for the different table levels:

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
