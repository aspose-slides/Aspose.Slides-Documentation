---
title: Get Text Portion Bounds from Presentations in .NET
linktitle: Portion Bounds
type: docs
weight: 47
url: /net/portion-bounds/
keywords:
- text portion bounds
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn how to retrieve text portion bounds in PowerPoint presentations using Aspose.Slides for .NET."
---

## **Overview**

A text portion represents a specific fragment of text inside a paragraph and allows you to work with that fragment independently from surrounding content. In Aspose.Slides, portions can be used when you need to retrieve the bounds of a text fragment, apply formatting to only part of a paragraph, or control text behavior at a more detailed level.

This article shows how to get the bounding rectangle of a portion by using [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/). It also shows how to get the coordinates of the beginning of a portion by using [IPortion.GetCoordinates](https://reference.aspose.com/slides/net/aspose.slides/iportion/getcoordinates/). In addition, it highlights common portion-related scenarios, such as applying a hyperlink to a single text fragment, understanding how formatting is resolved through portion, paragraph, text frame, and theme inheritance, and handling cases where a specified font is unavailable.

## **Get Bounds of a Text Portion**

Use [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) to retrieve the bounding rectangle of a text portion:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Get Coordinates of a Text Portion**

Use [IPortion.GetCoordinates](https://reference.aspose.com/slides/net/aspose.slides/iportion/getcoordinates/) to retrieve the coordinates of the beginning of a text portion:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/net/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a portion override, and what is taken from a paragraph or text frame?**

Portion-level properties have the highest precedence. If a property is not set on the [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/), Aspose.Slides takes it from the [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/). If it is not set there either, Aspose.Slides uses the [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) or [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/) style.

**What happens if the font specified for a portion is missing on the target machine or server?**

[Font substitution rules](/slides/net/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set portion-specific text fill transparency or a gradient independently of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) level can differ from neighboring fragments.
