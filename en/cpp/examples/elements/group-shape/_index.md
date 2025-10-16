---
title: Group Shape
type: docs
weight: 170
url: /cpp/examples/elements/groupshape/
keywords:
- code example
- group shape
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Manage grouped shapes in Aspose.Slides for C++: create, nest, align, reorder, and style group shapes with C++ examples in PPT, PPTX, and ODP presentations."
---

Examples for creating groups of shapes, accessing them, ungrouping, and removal using **Aspose.Slides for C++**.

## **Add a Group Shape**

Create a group containing two basic shapes.

```cpp
static void AddGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    group->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

    presentation->Dispose();
}
```

## **Access a Group Shape**

Retrieve the first group shape from a slide.

```cpp
static void AccessGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    auto firstGroup = SharedPtr<IGroupShape>();
    for (auto&& shape : slide->get_Shapes()) {
        if (ObjectExt::Is<IGroupShape>(shape)) {
            firstGroup = ExplicitCast<IGroupShape>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Remove a Group Shape**

Delete a group shape from the slide.

```cpp
static void RemoveGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();

    slide->get_Shapes()->Remove(group);

    presentation->Dispose();
}
```

## **Ungroup Shapes**

Move shapes out of a group container.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Move shape out of the group.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```
