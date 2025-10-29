---
title: Manage Text Portions in Presentations with Python
linktitle: Text Portion
type: docs
weight: 70
url: /python-net/portion/
keywords:
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to manage text portions in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET, boosting performance and customization."
---

## **Get Coordinates of Text Portions**

The [get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) method has been added to the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) class which allows retrieving the coordinates of text portions:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/python-net/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a Portion override, and what is taken from Paragraph/TextFrame?**

Portion-level properties have the highest precedence. If a property is not set on the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/), the engine takes it from the [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/); if it is not set there either, from the [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) or the [theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/) style.

**What happens if the font specified for a Portion is missing on the target machine/server?**

[Font substitution rules](/slides/python-net/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set a Portion-specific text fill transparency or gradient independent of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) level can differ from neighboring fragments.
