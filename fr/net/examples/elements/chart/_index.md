---
title: Graphique
type: docs
weight: 60
url: /fr/net/examples/elements/chart/
keywords:
- exemple de graphique
- ajouter un graphique
- accéder au graphique
- supprimer le graphique
- mettre à jour le graphique
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser des graphiques en C# avec Aspose.Slides : ajouter des données, formater les séries, les axes et les libellés, changer de type et exporter - compatible avec PPT, PPTX et ODP."
---

Exemples d'ajout, d'accès, de suppression et de mise à jour de différents types de graphiques avec **Aspose.Slides for .NET**. Les extraits ci-dessous illustrent les opérations de base sur les graphiques.

## Ajouter un graphique

Cette méthode ajoute un simple graphique en aires à la première diapositive.
```csharp
static void Add_Chart()
{
    using var pres = new Presentation();

    // Ajouter un graphique en colonnes simple à la première diapositive
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```


## Accéder à un graphique

Après avoir créé un graphique, vous pouvez le récupérer via la collection de formes.
```csharp
static void Access_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Accéder au premier graphique sur la diapositive
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```


## Supprimer un graphique

Le code suivant supprime un graphique d'une diapositive.
```csharp
static void Remove_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Supprimer le graphique
    slide.Shapes.Remove(chart);
}
```


## Mettre à jour les données du graphique

Vous pouvez modifier les propriétés du graphique, comme le titre.
```csharp
static void Update_Chart_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Changer le titre du graphique
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
