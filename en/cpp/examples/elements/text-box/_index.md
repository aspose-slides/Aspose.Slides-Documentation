---
title: Text Box
type: docs
weight: 40
url: /cpp/examples/elements/textbox/
keywords:
- code example
- textbox
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Work with text boxes in Aspose.Slides for C++: add, format, align, wrap, autofit, and style text using C++ for PPT, PPTX, and ODP presentations."
---

In Aspose.Slides, a **text box** is represented by an `AutoShape`. Nearly any shape can contain text, but a typical text box has no fill or border and displays only text.

This guide explains how to add, access, and remove text boxes programmatically.

## **Add a Text Box**

A text box is simply an `AutoShape` with no fill or border and some formatted text. Here's how to create one:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Create a rectangle shape (defaults to filled with border and no text).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Remove fill and border to make it look like a typical text box.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Set text formatting.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Assign the actual text content.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Note:** Any `AutoShape` that contains a non-empty `TextFrame` can function as a text box.

## **Access Text Boxes by Content**

To find all text boxes containing a specific keyword (e.g. "Slide"), iterate through the shapes and check their text:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Only AutoShapes can contain editable text.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Do something with the matching text box.
            }
        }
    }

    presentation->Dispose();
}
```

## **Remove Text Boxes by Content**

This example finds and deletes all text boxes on the first slide that contain a specific keyword:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Tip:** Always create a copy of the shape collection before modifying it during iteration to avoid collection modification errors.
