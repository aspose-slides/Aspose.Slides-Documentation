---
title: Connector
type: docs
weight: 190
url: /de/cpp/examples/elements/connector/
keywords:
- Codebeispiel
- Connector
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie mithilfe von Aspose.Slides für C++ Verbinder zwischen Formen hinzufügen, routen und formatieren, mit Beispielen für PPT, PPTX und ODP Präsentationen."
---
Dieser Artikel demonstriert, wie man Formen mit Connectors verbindet und deren Ziele mithilfe von **Aspose.Slides for C++** ändert.

## **Connector hinzufügen**

Fügen Sie eine Connector-Form zwischen zwei Punkten auf der Folie ein.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Zugriff auf einen Connector**

Rufen Sie die erste zur Folie hinzugefügte Connector-Form ab.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Zugriff auf den ersten Connector auf der Folie.
    auto connector = SharedPtr<IConnector>();
    for (auto&& shape :  slide->get_Shapes())
    {
        if (ObjectExt::Is<IConnector>(shape))
        {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Connector entfernen**

Löschen Sie einen Connector von der Folie.

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

## **Formen erneut verbinden**

Verbinden Sie einen Connector mit zwei Formen, indem Sie Start- und Endziele zuweisen.

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