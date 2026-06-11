---
title: Łącznik
type: docs
weight: 190
url: /pl/net/examples/elements/connector/
keywords:
- łącznik
- dodaj łącznik
- uzyskaj dostęp do łącznika
- usuń łącznik
- ponownie połącz kształty
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak dodawać, łączyć i formatować łączniki między kształtami przy użyciu Aspose.Slides for .NET, z przykładami w C# dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak łączyć kształty za pomocą łączników i zmieniać ich cele przy użyciu **Aspose.Slides for .NET**.

## **Dodaj łącznik**

Wstaw kształt łącznika pomiędzy dwa punkty na slajdzie.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Uzyskaj dostęp do łącznika**

Pobierz pierwszy kształt łącznika dodany do slajdu.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Usuń łącznik**

Usuń łącznik ze slajdu.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Ponowne połączenie kształtów**

Podłącz łącznik do dwóch kształtów, przypisując cele początkowy i końcowy.

```csharp
static void ReconnectShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    connector.StartShapeConnectedTo = shape1;
    connector.EndShapeConnectedTo = shape2;
}
```