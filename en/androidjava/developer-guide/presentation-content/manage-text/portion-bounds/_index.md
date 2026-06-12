---
title: Get Text Portion Bounds from Presentations on Android
linktitle: Portion Bounds
type: docs
weight: 47
url: /androidjava/portion-bounds/
keywords:
- text portion bounds
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn how to retrieve text portion bounds in PowerPoint presentations using Aspose.Slides for Android via Java."
---

## **Overview**

A text portion represents a specific fragment of text inside a paragraph and allows you to work with that fragment independently from surrounding content. In Aspose.Slides, portions can be used when you need to retrieve the bounds of a text fragment, apply formatting to only part of a paragraph, or control text behavior at a more detailed level.

This article shows how to get the bounding rectangle of a portion by using [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getRect--). It also shows how to get the coordinates of the beginning of a portion by using [IPortion.getCoordinates](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--). In addition, it highlights common portion-related scenarios, such as applying a hyperlink to a single text fragment, understanding how formatting is resolved through portion, paragraph, text frame, and theme inheritance, and handling cases where a specified font is unavailable.

## **Get Bounds of a Text Portion**

Use [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getRect--) to retrieve the bounding rectangle of a text portion:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Get Coordinates of a Text Portion**

Use [IPortion.getCoordinates](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) to retrieve the coordinates of the beginning of a text portion:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/androidjava/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a portion override, and what is taken from a paragraph or text frame?**

Portion-level properties have the highest precedence. If a property is not set on the [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/), Aspose.Slides takes it from the [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/). If it is not set there either, Aspose.Slides uses the [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) or [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/) style.

**What happens if the font specified for a portion is missing on the target machine or server?**

[Font substitution rules](/slides/androidjava/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set portion-specific text fill transparency or a gradient independently of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) level can differ from neighboring fragments.
