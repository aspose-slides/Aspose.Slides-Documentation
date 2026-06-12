---
title: Get Text Portion Bounds from Presentations in Python
linktitle: Portion Bounds
type: docs
weight: 47
url: /python-net/portion-bounds/
keywords:
- text portion bounds
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to retrieve text portion bounds in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET."
---

## **Overview**

A text portion represents a specific fragment of text inside a paragraph and allows you to work with that fragment independently from surrounding content. In Aspose.Slides, portions can be used when you need to retrieve the bounds of a text fragment, apply formatting to only part of a paragraph, or control text behavior at a more detailed level.

This article shows how to get the bounding rectangle of a portion by using [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/). It also shows how to get the coordinates of the beginning of a portion by using [Portion.get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/). In addition, it highlights common portion-related scenarios, such as applying a hyperlink to a single text fragment, understanding how formatting is resolved through portion, paragraph, text frame, and theme inheritance, and handling cases where a specified font is unavailable.

## **Get Bounds of a Text Portion**

Use [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) to retrieve the bounding rectangle of a text portion:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Get Coordinates of a Text Portion**

Use [Portion.get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) to retrieve the coordinates of the beginning of a text portion:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/python-net/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a portion override, and what is taken from a paragraph or text frame?**

Portion-level properties have the highest precedence. If a property is not set on the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/), Aspose.Slides takes it from the [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/). If it is not set there either, Aspose.Slides uses the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) or [theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/) style.

**What happens if the font specified for a portion is missing on the target machine or server?**

[Font substitution rules](/slides/python-net/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set portion-specific text fill transparency or a gradient independently of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) level can differ from neighboring fragments.
