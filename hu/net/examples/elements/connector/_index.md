---
title: Csatlakozó
type: docs
weight: 190
url: /hu/net/examples/elements/connector/
keywords:
- csatlakozó
- csatlakozó hozzáadása
- csatlakozó elérése
- csatlakozó eltávolítása
- alakzatok újracsatlakoztatása
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet csatlakozókat hozzáadni, irányítani és formázni az alakzatok között az Aspose.Slides for .NET segítségével, C# példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet alakzatokat összekapcsolni csatlakozókkal, és módosítani a célpontjaikat a **Aspose.Slides for .NET** használatával.

## **Csatlakozó hozzáadása**

Helyezzen el egy csatlakozó alakzatot a dián két pont között.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Csatlakozó elérése**

Hívja le az első csatlakozó alakzatot, amely a diára lett hozzáadva.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Csatlakozó eltávolítása**

Törölje a csatlakozót a diáról.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Alakzatok újracsatlakoztatása**

Rögzítsen egy csatlakozót két alakzathoz a kezdő és végpont célpontjainak megadásával.

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