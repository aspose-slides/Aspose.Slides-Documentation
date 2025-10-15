---
title: Connector
type: docs
weight: 190
url: /cpp/examples/elements/connector/
keywords:
- code example
- Connector
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Learn how to add, route, and style connectors between shapes using Aspose.Slides for C++, with examples for PPT, PPTX, and ODP presentations."
---

This article demonstrates how to connect shapes with connectors and change their targets using **Aspose.Slides for C++**.

## **Add a Connector**

Insert a connector shape between two points on the slide.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Access a Connector**

Retrieve the first connector shape added to a slide.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Access the first connector on the slide.
    auto connector = SharedPtr<IConnector>();
    for (auto i = 0; i < slide->get_Shapes()->get_Count(); ++i) {
        auto shape = slide->get_Shape(i);
        if (ObjectExt::Is<IConnector>(shape)) {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Remove a Connector**

Delete a connector from the slide.

```cpp
static void RemoveConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    slide->get_Shapes()->Remove(connector);

    presentation->Dispose();
}
```

## **Reconnect Shapes**

Attach a connector to two shapes by assigning start and end targets.

```cpp
static void ReconnectShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    connector->set_StartShapeConnectedTo(shape1);
    connector->set_EndShapeConnectedTo(shape2);

    presentation->Dispose();
}
```
