---
title: Connector
type: docs
weight: 190
url: /nl/net/examples/elements/connector/
keywords:
- connector
- connector toevoegen
- connector benaderen
- connector verwijderen
- vormen opnieuw verbinden
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u connectoren tussen vormen kunt toevoegen, routeren en opmaken met Aspose.Slides voor .NET, met C#-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel toont hoe u vormen kunt verbinden met connectoren en hun doelstellingen kunt wijzigen met behulp van **Aspose.Slides for .NET**.

## **Connector toevoegen**

Voeg een connectorvorm in tussen twee punten op de dia.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Connector benaderen**

Haal de eerste toegevoegde connectorvorm op een dia op.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Connector verwijderen**

Verwijder een connector van de dia.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Vormen opnieuw verbinden**

Koppel een connector aan twee vormen door start‑ en einddoelen toe te wijzen.

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