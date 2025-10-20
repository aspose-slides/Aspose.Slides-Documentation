---
title: Manage Superscript and Subscript in Python
linktitle: Superscript and Subscript
type: docs
weight: 80
url: /python-net/superscript-and-subscript/
keywords:
- superscript
- subscript
- add superscript
- add subscript
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Master superscript and subscript in Aspose.Slides for Python via .NET and elevate your presentations with professional text formatting for maximum impact."
---

## **Add Superscript and Subscript Text**

You can add superscript and subscript text to any paragraph portion. In Aspose.Slides, use the `escapement` property of the [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) class to control this.

`escapement` is a percentage from **-100% to 100%**:

- **> 0** → superscript (e.g., 25% = slight raise; 100% = full superscript)
- **0** → baseline (no super/subscript)
- **< 0** → subscript (e.g., -25% = slight lower; -100% = full subscript)

Steps:

1. Create a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) and get a slide.
1. Add a rectangle [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) and access its [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Clear existing paragraphs.
1. For superscript: create a paragraph and a portion, set `portion.portion_format.escapement` to a value between **0 and 100**, set text, and add the portion.
1. For subscript: create another paragraph and portion, set `escapement` to a value between **-100 and 0**, set text, and add the portion.
1. Save the presentation as PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Get a slide.
    slide = presentation.slides[0]

    # Create a text box.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Create a paragraph for superscript text.
    superscript_paragraph = slides.Paragraph()

    # Create a text portion with regular text.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Create a text portion with superscript text.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Create a paragraph for the subscript text.
    subscript_paragraph = slides.Paragraph()

    # Create a text portion with regular text.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Create a text portion with subscript text.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Add the paragraphs to the text box.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I apply superscript/subscript in tables and other containers, not just regular text boxes?**

Yes. You can format text as superscript or subscript inside any object that exposes a [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) (including table cells). The formatting applies to text portions within that frame.

**Will superscripts/subscripts be preserved when exporting to PDF, HTML, or images?**

Yes. Aspose.Slides preserves superscript/subscript formatting during export to common formats like [PDF](/slides/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/python-net/convert-powerpoint-to-html/), and [raster images](/slides/python-net/convert-powerpoint-to-png/) because the rendering pipeline respects portion-level text formatting.

**Can I combine superscript/subscript with hyperlinks in the same text fragment?**

Yes. [Hyperlinks](/slides/python-net/manage-hyperlinks/) are assigned at the portion (fragment) level, so a portion can simultaneously have a hyperlink and be formatted as superscript or subscript.
