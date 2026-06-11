---
title: Gruppform
type: docs
weight: 170
url: /sv/cpp/examples/elements/group-shape/
keywords:
- kodexempel
- gruppform
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Hantera grupperade former i Aspose.Slides för C++: skapa, nästla, justera, omordna och formge gruppformer med C++-exempel i PPT-, PPTX- och ODP-presentationer."
---
Exempel på hur man skapar grupper av former, får åtkomst till dem, avgrupperar och tar bort dem med **Aspose.Slides for C++**.

## **Lägg till en gruppform**

Skapa en grupp som innehåller två grundläggande former.

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

## **Få åtkomst till en gruppform**

Hämta den första gruppformen från en bild.

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

## **Ta bort en gruppform**

Ta bort en gruppform från bilden.

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

## **Avgruppera former**

Flytta former ur en gruppbehållare.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Flytta formen ur gruppen.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```