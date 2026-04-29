---
title: Manage Text Portions in Presentations in .NET
linktitle: Text Portion
type: docs
weight: 70
url: /net/portion/
keywords:
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to manage text portions in PowerPoint presentations using Aspose.Slides for .NET, boosting performance and customization."
---

## **Overview**

A text portion represents a specific fragment of text inside a paragraph and allows you to work with that fragment independently from surrounding content. In Aspose.Slides, portions can be used when you need to retrieve the position of a text fragment, apply formatting to only part of a paragraph, or control text behavior at a more detailed level.

This article shows how to get the coordinates of the beginning of a portion by using the `GetCoordinates()` method. It also highlights common portion-related scenarios, such as applying a hyperlink to a single text fragment, understanding how formatting is resolved through portion, paragraph, text frame, and theme inheritance, and handling cases where a specified font is unavailable. In addition, it notes that text fill, color, and transparency can be set differently for individual portions within the same paragraph.

## **Get Coordinates of a Text Portion**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/net/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a Portion override, and what is taken from Paragraph/TextFrame?**

Portion-level properties have the highest precedence. If a property is not set on the [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/), the engine takes it from the [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/); if it is not set there either, from the [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) or the [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/) style.

**What happens if the font specified for a Portion is missing on the target machine/server?**

[Font substitution rules](/slides/net/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set a Portion-specific text fill transparency or gradient independent of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) level can differ from neighboring fragments.
