---
title: Grupa kształtów
type: docs
weight: 170
url: /pl/net/examples/elements/group-shape/
keywords:
- grupa
- dodaj grupowy kształt
- uzyskaj dostęp do grupowego kształtu
- usuń grupowy kształt
- rozgrupuj kształty
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj grupowanymi kształtami w Aspose.Slides for .NET: twórz, zagnieżdżaj, wyrównuj, zmieniaj kolejność i stylizuj grupy kształtów przy użyciu przykładów C# w prezentacjach PPT, PPTX i ODP."
---
Przykłady tworzenia grup kształtów, uzyskiwania do nich dostępu, rozgrupowywania oraz usuwania przy użyciu **Aspose.Slides for .NET**.

## **Dodaj grupę kształtów**

Utwórz grupę zawierającą dwa podstawowe kształty.

```csharp
static void AddGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    group.Shapes.AddAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
}
```

## **Uzyskaj dostęp do grupy kształtów**

Pobierz pierwszy grupowy kształt ze slajdu.

```csharp
static void AccessGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    var firstGroup = slide.Shapes.OfType<IGroupShape>().First();
}
```

## **Usuń grupowy kształt**

Usuń grupowy kształt ze slajdu.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Rozgrupuj kształty**

Przenieś kształty poza kontener grupowy.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Przenieś kształt poza grupę.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```