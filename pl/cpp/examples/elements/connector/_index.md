---
title: Łącznik
type: docs
weight: 190
url: /pl/cpp/examples/elements/connector/
keywords:
- przykład kodu
- Łącznik
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak dodawać, łączyć i stylizować łączniki między kształtami przy użyciu Aspose.Slides dla C++, z przykładami dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak łączyć kształty przy użyciu łączy i zmieniać ich cele przy użyciu **Aspose.Slides for C++**.

## **Dodaj łącze**

Wstaw kształt łącza pomiędzy dwoma punktami na slajdzie.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Uzyskaj dostęp do łącza**

Pobierz pierwszy kształt łącza dodany do slajdu.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Uzyskaj dostęp do pierwszego łącza na slajdzie.
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

## **Usuń łącze**

Usuń łącze ze slajdu.

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

## **Ponownie połącz kształty**

Dołącz łącze do dwóch kształtów, przypisując cele początkowy i końcowy.

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