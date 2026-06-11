---
title: Förbindelse
type: docs
weight: 190
url: /sv/cpp/examples/elements/connector/
keywords:
- kodexempel
- Förbindelse
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du lägger till, dirigerar och formaterar förbindelser mellan former med Aspose.Slides för C++, med exempel för PPT-, PPTX- och ODP-presentationer."
---
Denna artikel visar hur man ansluter former med förbindelser och ändrar deras mål med hjälp av **Aspose.Slides for C++**.

## **Lägg till en förbindelse**

Infoga en förbindelseform mellan två punkter på bilden.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Åtkomst till en förbindelse**

Hämta den första förbindelseformen som lagts till på en bild.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Åtkomst till den första förbindelsen på sliden.
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

## **Ta bort en förbindelse**

Ta bort en förbindelse från bilden.

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

## **Återanslut former**

Fäst en förbindelse till två former genom att tilldela start- och slutmål.

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