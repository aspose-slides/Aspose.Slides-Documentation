---
title: Get Text Portion Bounds from Presentations in C++
linktitle: Portion Bounds
type: docs
weight: 47
url: /cpp/portion-bounds/
keywords:
- text portion bounds
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn how to retrieve text portion bounds in PowerPoint presentations using Aspose.Slides for C++."
---

## **Overview**

A text portion represents a specific fragment of text inside a paragraph and allows you to work with that fragment independently from surrounding content. In Aspose.Slides, portions can be used when you need to retrieve the bounds of a text fragment, apply formatting to only part of a paragraph, or control text behavior at a more detailed level.

This article shows how to get the bounding rectangle of a portion by using [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/). It also shows how to get the coordinates of the beginning of a portion by using [IPortion::GetCoordinates](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getcoordinates/). In addition, it highlights common portion-related scenarios, such as applying a hyperlink to a single text fragment, understanding how formatting is resolved through portion, paragraph, text frame, and theme inheritance, and handling cases where a specified font is unavailable.

## **Get Bounds of a Text Portion**

Use [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/) to retrieve the bounding rectangle of a text portion:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Get Coordinates of a Text Portion**

Use [IPortion::GetCoordinates](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getcoordinates/) to retrieve the coordinates of the beginning of a text portion:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **FAQ**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

Yes, you can [assign a hyperlink](/slides/cpp/manage-hyperlinks/) to an individual portion; only that fragment will be clickable, not the entire paragraph.

**How does style inheritance work: what does a portion override, and what is taken from a paragraph or text frame?**

Portion-level properties have the highest precedence. If a property is not set on the [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/), Aspose.Slides takes it from the [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/). If it is not set there either, Aspose.Slides uses the [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) or [theme](https://reference.aspose.com/slides/cpp/aspose.slides.theme/theme/) style.

**What happens if the font specified for a portion is missing on the target machine or server?**

[Font substitution rules](/slides/cpp/font-selection-sequence/) apply. The text may reflow: metrics, hyphenation, and width can change, which matters for precise positioning.

**Can I set portion-specific text fill transparency or a gradient independently of the rest of the paragraph?**

Yes, text color, fill, and transparency at the [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) level can differ from neighboring fragments.
