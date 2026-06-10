---
title: Csoport alakzat
type: docs
weight: 170
url: /hu/net/examples/elements/group-shape/
keywords:
- csoport
- csoport alakzat hozzáadása
- csoport alakzat elérése
- csoport alakzat eltávolítása
- csoport alakzatok feloldása
- kódpélda
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Csoportosított alakzatok kezelése az Aspose.Slides for .NET-ben: csoport alakzatok létrehozása, egymásba ágyazása, igazítása, átrendezése és formázása C# példákkal PPT, PPTX és ODP prezentációkban."
---
Példák alakzatcsoportok létrehozására, elérésére, csoportból való szétválasztásra és eltávolításra a **Aspose.Slides for .NET** használatával.

## **Csoport alakzat hozzáadása**

Hozzon létre egy csoportot, amely két alap alakzatot tartalmaz.

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

## **Csoport alakzat elérése**

Szerezze meg az első csoport alakzatot a diáról.

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

## **Csoport alakzat eltávolítása**

Törölje a csoport alakzatot a diáról.

```csharp
static void RemoveGroupShape()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();

    slide.Shapes.Remove(group);
}
```

## **Alakzatok csoportjának feloldása**

Mozgassa az alakzatokat a csoportkonténerből kívülre.

```csharp
static void UngroupShapes()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var group = slide.Shapes.AddGroupShape();
    var rect = group.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

    // Alakzat áthelyezése a csoportból.
    slide.Shapes.AddClone(rect);
    group.Shapes.Remove(rect);
}
```