---
title: Groepvorm
type: docs
weight: 170
url: /nl/cpp/examples/elements/group-shape/
keywords:
- codevoorbeeld
- groepsvorm
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer gegroepeerde vormen in Aspose.Slides voor C++: maak, nestel, rangschik, herschik en style groepsvormen met C++-voorbeelden in PPT-, PPTX- en ODP-presentaties."
---
Voorbeelden voor het maken van groepen van vormen, er toegang toe krijgen, ontgroeperen en verwijderen met **Aspose.Slides for C++**.

## **Voeg een groepsvorm toe**

Maak een groep aan met twee basale vormen.

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

## **Toegang tot een groepsvorm**

Haal de eerste groepsvorm op van een dia.

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

## **Verwijder een groepsvorm**

Verwijder een groepsvorm van de dia.

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

## **Ontgroepeer vormen**

Verplaats vormen uit een groepscontainer.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Verplaats vorm uit de groep.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```