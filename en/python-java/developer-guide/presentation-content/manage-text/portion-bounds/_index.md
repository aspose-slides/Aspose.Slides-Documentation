---
title: Get Text Portion Bounds from Presentations in Python via Java
linktitle: Portion Bounds
type: docs
weight: 47
url: /python-java/portion-bounds/
keywords:
- text portion bounds
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Learn how to retrieve text portion bounds in PowerPoint presentations using Aspose.Slides for Python via Java."
---

## **Overview**

A text portion represents a specific fragment of text inside a paragraph and allows you to work with that fragment independently from surrounding content. In Aspose.Slides, portions can be used when you need to retrieve the bounds of a text fragment, apply formatting to only part of a paragraph, or control text behavior at a more detailed level.

This article shows how to get the bounding rectangle of a portion by using [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect). It also shows how to get the coordinates of the beginning of a portion by using [Portion.getCoordinates](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getCoordinates). In addition, it highlights common portion-related scenarios, such as applying a hyperlink to a single text fragment, understanding how formatting is resolved through portion, paragraph, text frame, and theme inheritance, and handling cases where a specified font is unavailable.

## **Get Bounds of a Text Portion**

Use [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) to retrieve the bounding rectangle of a text portion:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Get Coordinates of a Text Portion**

Use [Portion.getCoordinates](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getCoordinates) to retrieve the coordinates of the beginning of a text portion:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/python-java/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a portion override, and what is taken from a paragraph or text frame?**

Portion-level properties have the highest precedence. If a property is not set on the [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/), Aspose.Slides takes it from the [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/). If it is not set there either, Aspose.Slides uses the [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) or [theme](https://reference.aspose.com/slides/python-java/aspose.slides/theme/) style.

**What happens if the font specified for a portion is missing on the target machine or server?**

[Font substitution rules](/slides/python-java/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set portion-specific text fill transparency or a gradient independently of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) level can differ from neighboring fragments.
