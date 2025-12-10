---
title: Connecteur
type: docs
weight: 190
url: /fr/net/examples/elements/connector/
keywords:
- exemple de connecteur
- ajouter un connecteur
- accéder au connecteur
- supprimer le connecteur
- reconnecter les formes
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Dessinez et contrôlez les connecteurs en C# avec Aspose.Slides: ajoutez, routez, reroutez, définissez les points de connexion, les flèches et les styles pour lier des formes dans PPT, PPTX et ODP."
---

Montre comment connecter des formes avec des connecteurs et modifier leurs cibles en utilisant **Aspose.Slides for .NET**.

## **Ajouter un connecteur**

Insérez une forme de connecteur entre deux points sur la diapositive.
```csharp
static void Add_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
}
```


## **Accéder à un connecteur**

Récupérez la première forme de connecteur ajoutée à une diapositive.
```csharp
static void Access_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    var connector = slide.Shapes.OfType<IConnector>().First();
}
```


## **Supprimer un connecteur**

Supprimez un connecteur de la diapositive.
```csharp
static void Remove_Connector()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    slide.Shapes.Remove(conn);
}
```


## **Reconnecter des formes**

Attachez un connecteur à deux formes en attribuant des cibles de départ et d'arrivée.
```csharp
static void Reconnect_Shapes()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
    var conn = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

    conn.StartShapeConnectedTo = shape1;
    conn.EndShapeConnectedTo = shape2;
}
```
