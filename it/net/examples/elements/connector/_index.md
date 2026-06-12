---
title: Connettore
type: docs
weight: 190
url: /it/net/examples/elements/connector/
keywords:
- connettore
- aggiungi connettore
- accedi al connettore
- rimuovi connettore
- ricollega forme
- esempio di codice
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri come aggiungere, instradare e formattare i connettori tra le forme usando Aspose.Slides per .NET, con esempi C# per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come collegare forme con connettori e modificare i loro target usando **Aspose.Slides for .NET**.

## **Aggiungi un connettore**

Inserisci una forma connettore tra due punti della diapositiva.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Accedi a un connettore**

Recupera la prima forma connettore aggiunta a una diapositiva.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Rimuovi un connettore**

Elimina un connettore dalla diapositiva.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Riconnetti le forme**

Collega un connettore a due forme assegnando i target di inizio e fine.

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