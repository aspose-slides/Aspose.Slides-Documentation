---
title: Forma di Gruppo
type: docs
weight: 170
url: /it/cpp/examples/elements/group-shape/
keywords:
- esempio di codice
- forma di gruppo
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Gestisci le forme raggruppate in Aspose.Slides per C++: crea, annida, allinea, riordina e applica stili alle forme di gruppo con esempi C++ in presentazioni PPT, PPTX e ODP."
---
Esempi per creare gruppi di forme, accedervi, separare e rimuovere utilizzando **Aspose.Slides for C++**.

## **Aggiungi una Forma di Gruppo**

Crea un gruppo contenente due forme di base.

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

## **Accedi a una Forma di Gruppo**

Recupera la prima forma di gruppo da una diapositiva.

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

## **Rimuovi una Forma di Gruppo**

Elimina una forma di gruppo dalla diapositiva.

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

## **Separa le Forme**

Sposta le forme fuori da un contenitore di gruppo.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Sposta la forma fuori dal gruppo.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```