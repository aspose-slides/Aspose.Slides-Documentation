---
title: Gruppenform
type: docs
weight: 170
url: /de/cpp/examples/elements/group-shape/
keywords:
- Codebeispiel
- Gruppenform
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie gruppierte Formen in Aspose.Slides für C++: Erstellen, verschachteln, ausrichten, neu anordnen und formatieren Sie Gruppenformen mit C++‑Beispielen in PPT-, PPTX- und ODP‑Präsentationen."
---
Beispiele für das Erstellen von Gruppen von Formen, den Zugriff darauf, das Aufheben von Gruppen und das Entfernen mit **Aspose.Slides for C++**.

## **Gruppenform hinzufügen**

Erstellen Sie eine Gruppe, die zwei Grundformen enthält.

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

## **Zugriff auf eine Gruppenform**

Rufen Sie die erste Gruppenform von einer Folie ab.

```cpp
static void AccessGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    auto firstGroup = SharedPtr<IGroupShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IGroupShape>(shape))
        {
            firstGroup = ExplicitCast<IGroupShape>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Gruppenform entfernen**

Löschen Sie eine Gruppenform von der Folie.

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

## **Formen entgruppieren**

Verschieben Sie Formen aus einem Gruppencontainer.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Form aus der Gruppe verschieben.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```