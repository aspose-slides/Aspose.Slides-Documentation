---
title: Anslutning
type: docs
weight: 190
url: /sv/net/examples/elements/connector/
keywords:
- anslutning
- lägg till anslutning
- åtkomst till anslutning
- ta bort anslutning
- koppla om former
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du lägger till, styr och formaterar anslutningar mellan former med Aspose.Slides för .NET, med C#-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man kopplar ihop former med anslutningar och ändrar deras mål med **Aspose.Slides for .NET**.

## **Lägg till en anslutning**

Infoga en anslutningsform mellan två punkter på bilden.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Åtkomst till en anslutning**

Hämta den första anslutningsformen som lagts till på en bild.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Ta bort en anslutning**

Ta bort en anslutning från bilden.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Koppla om former**

Fäst en anslutning till två former genom att tilldela start- och slutmål.

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