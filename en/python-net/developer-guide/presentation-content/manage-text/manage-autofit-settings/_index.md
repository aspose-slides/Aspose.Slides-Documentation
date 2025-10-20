---
title: Enhance Your Presentations with AutoFit in Python
linktitle: Autofit Settings
type: docs
weight: 30
url: /python-net/manage-autofit-settings/
keywords:
- textbox
- autofit
- do not autofit
- fit text
- shrink text
- wrap text
- resize shape
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn how to manage AutoFit settings in Aspose.Slides for Python via .NET to optimize text display in your PowerPoint and OpenDocument presentations and improve content readability."
---

By default, when you add a textbox, Microsoft PowerPoint uses the **Resize shape to fix text** setting for the textbox—it automatically resizes the textbox to ensure its text always fits into it. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* When the text in the textbox becomes longer or bigger, PowerPoint automatically enlarges the textbox—increases its height—to allow it to hold more text. 
* When the text in the textbox becomes shorter or smaller, PowerPoint automatically reduces the textbox—decreases its height—to clear redundant space. 

In PowerPoint, these are the 4 important parameters or options that control the autofit behavior for a textbox: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via .NET provides similar options—some properties under the [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) class—that allow you to control the autofit behavior for textboxes in presentations. 

## **Resize Shapes to Fit Text**

If you want the text in a box to always fit into that box after changes are made to the text, you have to use the **Resize shape to fix text** option. To specify this setting, set the [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) property from the [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) class to `SHAPE`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

This Python code shows you how to specify that a text must always fit into its box in a PowerPoint presentation:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

If the text becomes longer or bigger, the textbox will be automatically resized (increase in height) to ensure all the text fits into it. If the text becomes shorter, the reverse occurs. 

## **Do Not Autofit**

If you want a textbox or shape to retain its dimensions no matter the changes made to the text it contains, you have to use the **Do not Autofit** option. To specify this setting, set the [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) property from the [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) class to `NONE`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

This Python code shows you how to specify that a textbox must always retain its dimensions in a PowerPoint presentation:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

When the text becomes too long for its box, it spills out. 

## **Shrink Text on Overflow**

If a text becomes too long for its box, through the **Shrink text on overflow** option, you can specify that the text's size and spacing must be reduced to make it fit into its box. To specify this setting, set the [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) property from the [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) class to `NORMAL`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

This Python code shows you how to specify that a text must be shrunk on overflow in a PowerPoint presentation:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NORMAL

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}

When the **Shrink text on overflow** option is used, the setting gets applied only when the text becomes too long for its box. 

{{% /alert %}}

## **Wrap Text**

If you want the text in a shape to get wrapped inside that shape when the text goes beyond the shape's border (width only), you have to use the **Wrap text in shape** parameter. To specify this setting, you have to set the [wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) property from the [TextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) class to `NullableBool.TRUE`. 

This Python code shows you how to use the Wrap Text setting in a PowerPoint presentation:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30, 350, 100)

    portion = slides.Portion("lorem ipsum...")
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    auto_shape.text_frame.paragraphs[0].portions.add(portion)

    text_frame_format = auto_shape.text_frame.text_frame_format
    text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame_format.wrap_text = slides.NullableBool.TRUE

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

If you set the `wrap_text` property to `NullableBool.FALSE` for a shape, when the text inside the shape becomes longer than the shape's width, the text gets extended beyond the shape's borders along a single line. 

{{% /alert %}}

## **FAQ**

**Do the text frame’s internal margins affect AutoFit?**

Yes. Padding (internal margins) reduces the usable area for text, so AutoFit will kick in earlier—shrinking the font or resizing the shape sooner. Check and adjust margins before tuning AutoFit.

**How does AutoFit interact with manual and soft line breaks?**

Forced breaks remain in place, and AutoFit adapts font size and spacing around them. Removing unnecessary breaks often reduces how aggressively AutoFit needs to shrink the text.

**Does changing the theme font or triggering font substitution affect AutoFit results?**

Yes. Substituting to a font with different glyph metrics changes text width/height, which can alter final font size and line wrapping. After any font change or substitution, re-check the slides.
