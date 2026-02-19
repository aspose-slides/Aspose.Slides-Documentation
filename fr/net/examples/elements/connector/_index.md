---
title: Connecteur
type: docs
weight: 190
url: /fr/net/examples/elements/connector/
keywords:
- connecteur
- ajouter un connecteur
- accéder au connecteur
- supprimer le connecteur
- reconnecter les formes
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à ajouter, acheminer et styliser des connecteurs entre des formes à l'aide d'Aspose.Slides for .NET, avec des exemples C# pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment connecter des formes avec des connecteurs et modifier leurs cibles à l'aide de **Aspose.Slides for .NET**.

## **Ajouter un connecteur**

Insérez une forme de connecteur entre deux points de la diapositive.

```csharp
static void AddConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```

## **Accéder à un connecteur**

Récupérez la première forme de connecteur ajoutée à une diapositive.

```csharp
static void AccessConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```

## **Supprimer un connecteur**

Supprimez un connecteur de la diapositive.

```csharp
static void RemoveConnector()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(connector);
}
```

## **Reconnecter les formes**

Attachez un connecteur à deux formes en attribuant les cibles de début et de fin.

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