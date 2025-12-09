---
title: Manage Text Portions in Presentations Using C++
linktitle: Text Portion
type: docs
weight: 70
url: /cpp/portion/
keywords:
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn how to manage text portions in PowerPoint presentations using Aspose.Slides for C++, boosting performance and customization."
---

## **Get Coordinates of a Text Portion**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/cpp/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a Portion override, and what is taken from Paragraph/TextFrame?**

Portion-level properties have the highest precedence. If a property is not set on the [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/), the engine takes it from the [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/); if it is not set there either, from the [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) or the [theme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/theme/) style.

**What happens if the font specified for a Portion is missing on the target machine/server?**

[Font substitution rules](/slides/cpp/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set a Portion-specific text fill transparency or gradient independent of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [Portion](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) level can differ from neighboring fragments.
