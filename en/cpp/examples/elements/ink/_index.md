---
title: Ink
type: docs
weight: 180
url: /cpp/examples/elements/ink/
keywords:
- code example
- ink
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Work with Ink in Aspose.Slides for C++: draw, import, and edit strokes, adjust color and width, and export to PPT, PPTX, and ODP using C++ examples."
---

This article provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for C++**.

> ❗ **Note:** Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.

## **Access Ink**

Read the tags from the first ink shape on a slide.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // Use tagName as needed.
        }
    }

    presentation->Dispose();
}
```

## **Remove Ink**

Delete an ink shape from the slide if one exists.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```
