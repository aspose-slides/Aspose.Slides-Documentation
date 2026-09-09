---
title: Manage Superscript and Subscript in Presentations Using Python via Java
linktitle: Superscript and Subscript
type: docs
weight: 80
url: /python-java/superscript-and-subscript/
keywords:
- superscript
- subscript
- add superscript
- add subscript
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Master superscript and subscript in Aspose.Slides for Python via Java and elevate your presentations with professional text formatting for maximum impact."
---

## **Overview**

Aspose.Slides provides features for integrating superscript and subscript text into your PowerPoint (PPT, PPTX) and OpenDocument (ODP) presentations. Whether you need to highlight chemical formulas, mathematical equations, or annotate content with footnotes, these specialized formatting options help maintain clarity and precision. In this article, you'll learn how to seamlessly apply superscript and subscript styles and ensure professional results in every slide.

## **Manage Superscript and Subscript Text**

You can add superscript and subscript text to any portion of a paragraph. To apply this formatting in an Aspose.Slides text frame, use the [setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setEscapement) method of the [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) class.

The escapement value ranges from -100% (subscript) to 100% (superscript). For example:

- Create an instance of the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class.
- Get a slide by its index.
- Add an [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) of type [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle) to the slide.
- Access the [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) associated with the [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Clear the existing paragraphs.
- Create a paragraph to hold superscript text and add it to the text frame's [paragraph collection](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs).
- Create a portion.
- Use [setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setEscapement) to set a value from 0 to 100 for superscript (0 means no superscript).
- Set the text of the [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) and add it to the paragraph's portion collection.
- Create a paragraph to hold subscript text and add it to the text frame's [paragraph collection](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs).
- Create a portion.
- Use [setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setEscapement) to set a value from -100 to 0 for subscript (0 means no subscript).
- Set the text of the [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) and add it to the paragraph's portion collection.
- Save the presentation as a PPTX file.

The following example implements these steps:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Create a presentation.
presentation = Presentation()
try:
    # Get the slide.
    slide = presentation.getSlides().get_Item(0)

    # Create a text box.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Create a paragraph for superscript text.
    superscript_paragraph = Paragraph()

    # Create a portion with normal text.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Create a portion with superscript text.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Create a paragraph for subscript text.
    subscript_paragraph = Paragraph()

    # Create a portion with normal text.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Create a portion with subscript text.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Add the paragraphs to the text box.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Will superscript and subscript be preserved when exporting to PDF or other formats?**

Yes, Aspose.Slides properly retains superscript and subscript formatting when exporting presentations to PDF, PPT/PPTX, images, and other supported formats. The specialized formatting remains intact in all output files.

**Can superscript and subscript be combined with other formatting styles such as bold or italics?**

Yes, Aspose.Slides allows you to mix various text styles within a single portion of text. You can enable bold, italics, underline, and simultaneously apply superscript or subscript by configuring the corresponding properties in [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

**Do superscript and subscript formatting work for text inside tables, charts, or SmartArt?**

Yes, Aspose.Slides supports formatting within most objects, including tables and chart elements. When working with SmartArt, you need to access the appropriate elements (such as [SmartArtNode](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/)) and their text containers, and then configure the [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) properties in a similar manner.
