---
title: Spojnice
type: docs
weight: 190
url: /cs/net/examples/elements/connector/
keywords:
- spojnice
- přidat spojnici
- získat spojnici
- odstranit spojnici
- znovupripojit tvary
- příklad kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak přidávat, směrovat a stylovat spojnice mezi tvary pomocí Aspose.Slides pro .NET, s příklady v C# pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak propojit tvary pomocí spojnic a změnit jejich cíle pomocí **Aspose.Slides for .NET**.

## **Přidat spojnici**

Vložte tvar spojnice mezi dva body na snímku.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Získat spojnici**

Získejte první tvar spojnice přidaný do snímku.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Odstranit spojnici**

Odstraňte spojnici ze snímku.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Znovupripojit tvary**

Připojte spojnici ke dvěma tvarům přiřazením počátečního a koncového cíle.

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