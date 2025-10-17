---
title: SmartArt
type: docs
weight: 140
url: /cpp/examples/elements/smartart/
keywords:
- code example
- SmartArt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Work with SmartArt in Aspose.Slides for C++: create, edit, convert, and style diagrams with C++ for PowerPoint and OpenDocument presentations."
---

This article demonstrates how to add SmartArt graphics, access them, remove them, and change layouts using **Aspose.Slides for C++**.

## **Add SmartArt**

Insert a SmartArt graphic using one of the built-in layouts.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Access SmartArt**

Retrieve the first SmartArt object on a slide.

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Remove SmartArt**

Delete a SmartArt shape from the slide.

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **Change SmartArt Layout**

Update the layout type of an existing SmartArt graphic.

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```
