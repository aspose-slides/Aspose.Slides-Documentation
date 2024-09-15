---
title: Shape Effective Properties
type: docs
weight: 50
url: /python-net/shape-effective-properties/
keywords: "Shape properties, Camera properties, light rig, bevel shape, text frame, text style, font height value, fill format for table, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Get effective shape properties in PowerPoint presentations in Python"
---

In this topic, we will discuss **effective** and **local** properties. When we set values directly at these levels

1. In portion properties on portion's slide.
1. In prototype shape text style on layout or master slide (if portion's text frame shape has one).
1. In presentation global text settings.

then those values are called **local** values. At any level, **local** values could be defined or omitted. But finally when it comes to the moment when the application needs to know what the portion should look like it uses **effective** values. You can get effective values by using **getEffective()** method from the local format.

The following example shows how to get effective values.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    localTextFrameFormat = shape.text_frame.text_frame_format
    effectiveTextFrameFormat = localTextFrameFormat.get_effective()

    localPortionFormat = shape.text_frame.paragraphs[0].portions[0].portion_format
    effectivePortionFormat = localPortionFormat.get_effective()
```



## **Get Effective Properties of Camera**
Aspose.Slides for Python via .NET allows developers to get effective properties of the camera. For this purpose, the **CameraEffectiveData** class has been added in Aspose.Slides. CameraEffectiveData class represents an immutable object which contains effective camera properties. An instance of **CameraEffectiveData** class is used as part of **ThreeDFormatEffectiveData** class which is an effective values pair for ThreeDFormat class.

The following code sample shows how to get effective properties for the camera.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Effective camera properties =")
	print("Type: " + str(threeDEffectiveData.camera.camera_type))
	print("Field of view: " + str(threeDEffectiveData.camera.field_of_view_angle))
	print("Zoom: " + str(threeDEffectiveData.camera.zoom))
```


## **Get Effective Properties of Light Rig**
Aspose.Slides for Python via .NET allows developers to get effective properties of Light Rig. For this purpose, the **LightRigEffectiveData** class has been added in Aspose.Slides. LightRigEffectiveData class represents an immutable object which contains effective light rig properties. An instance of **LightRigEffectiveData** class is used as part of **ThreeDFormatEffectiveData** class which is an effective values pair for ThreeDFormat class.

The following code sample shows how to get effective properties for the Light Rig.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type: " + str(threeDEffectiveData.light_rig.light_type))
	print("Direction: " + str(threeDEffectiveData.light_rig.direction))
```


## **Get Effective Properties of Bevel Shape**
Aspose.Slides for Python via .NET allows developers to get effective properties of Bevel Shape. For this purpose, the **ShapeBevelEffectiveData** class has been added in Aspose.Slides. ShapeBevelEffectiveData class represents an immutable object which contains effective shape's face relief properties. An instance of **ShapeBevelEffectiveData** class is used as part of **ThreeDFormatEffectiveData** class which is an effective values pair for ThreeDFormat class.

The following code sample shows how to get effective properties for the Bevel Shape.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Effective shape's top face relief properties =")
	print("Type: " + str(threeDEffectiveData.bevel_top.bevel_type))
	print("Width: " + str(threeDEffectiveData.bevel_top.width))
	print("Height: " + str(threeDEffectiveData.bevel_top.height))
```



## **Get Effective Properties of Text Frame**
Using Aspose.Slides for Python via .NET, you can get effective properties of Text Frame. For this purpose, the **TextFrameFormatEffectiveData** class has been added in Aspose.Slides which contains effective text frame formatting properties. 

The following code sample shows how to get effective text frame formatting properties.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	shape = pres.slides[0].shapes[0]

	textFrameFormat = shape.text_frame.text_frame_format
	effectiveTextFrameFormat = textFrameFormat.get_effective()


	print("Anchoring type: " + str(effectiveTextFrameFormat.anchoring_type))
	print("Autofit type: " + str(effectiveTextFrameFormat.autofit_type))
	print("Text vertical type: " + str(effectiveTextFrameFormat.text_vertical_type))
	print("Margins")
	print("   Left: " + str(effectiveTextFrameFormat.margin_left))
	print("   Top: " + str(effectiveTextFrameFormat.margin_top))
	print("   Right: " + str(effectiveTextFrameFormat.margin_right))
	print("   Bottom: " + str(effectiveTextFrameFormat.margin_bottom))
```



## **Get Effective Properties of Text Style**
Using Aspose.Slides for Python via .NET, you can get effective properties of Text Style. For this purpose, the **TextStyleEffectiveData** class has been added in Aspose.Slides which contains effective text style properties. 

The following code sample shows how to get effective text style properties.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    effectiveTextStyle = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effectiveTextStyle.get_level(i)
        print("= Effective paragraph formatting for style level #" + str(i) + " =")

        print("Depth: " + str(effectiveStyleLevel.depth))
        print("Indent: " + str(effectiveStyleLevel.indent))
        print("Alignment: " + str(effectiveStyleLevel.alignment))
        print("Font alignment: " + str(effectiveStyleLevel.font_alignment))

```


## **Get Effective Font Height Value**
Using Aspose.Slides for Python via .NET, you can get effective properties of Font Height . Here is the code demonstrating the portion's effective font height value changing after setting local font height values on different presentation structure levels. 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    newShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    newShape.add_text_frame("")
    newShape.text_frame.paragraphs[0].portions.clear()

    portion0 = slides.Portion("Sample text with first portion")
    portion1 = slides.Portion(" and second portion.")

    newShape.text_frame.paragraphs[0].portions.add(portion0)
    newShape.text_frame.paragraphs[0].portions.add(portion1)

    print("Effective font height just after creation:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Effective font height after setting entire presentation default font height:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[1].portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    print("Portion #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Portion #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **Get Effective Fill Format for Table**
Using Aspose.Slides for Python via .NET, you can get effective fill formatting for different table logic parts. For this purpose, the **IFillFormatEffectiveData** interface has been added in Aspose.Slides which contains effective fill formatting properties. Please note that cell formatting always has higher priority than row formatting, a row has higher priority than column and column higher that whole table. 

So finally **CellFormatEffectiveData** properties always used to draw the table. The following code sample shows how to get effective fill formatting for different table logic parts.

```py
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
	tbl = pres.slides[0].shapes[0]
	tableFormatEffective = tbl.table_format.get_effective()
	rowFormatEffective = tbl.rows[0].row_format.get_effective()
	columnFormatEffective = tbl.columns[0].column_format.get_effective()
	cellFormatEffective = tbl[0, 0].cell_format.get_effective()

	tableFillFormatEffective = tableFormatEffective.fill_format
	rowFillFormatEffective = rowFormatEffective.fill_format
	columnFillFormatEffective = columnFormatEffective.fill_format
	cellFillFormatEffective = cellFormatEffective.fill_format
```



