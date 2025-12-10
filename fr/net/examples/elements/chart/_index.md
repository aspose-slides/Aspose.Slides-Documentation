---
title: Graphique
type: docs
weight: 60
url: /fr/net/examples/elements/chart/
keywords:
- exemple de graphique
- ajouter un graphique
- accéder à un graphique
- supprimer un graphique
- mettre à jour un graphique
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser des graphiques en C# avec Aspose.Slides : ajouter des données, formater les séries, les axes et les libellés, changer les types et exporter — compatible avec PPT, PPTX et ODP."
---

Exemples d'ajout, d'accès, de suppression et de mise à jour de différents types de graphiques avec **Aspose.Slides for .NET**. Les extraits ci-dessous illustrent les opérations de base sur les graphiques.

## **Ajouter un graphique**

Cette méthode ajoute un graphique en aires simple à la première diapositive.
```csharp
static void Add_Chart()
{
    using var pres = new Presentation();

    // Ajouter un graphique à colonnes simple à la première diapositive
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```


## **Acceder à un graphique**

Après avoir créé un graphique, vous pouvez le récupérer via la collection de formes.
```csharp
static void Access_Chart()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Accéder au premier graphique de la diapositive
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```


## **Supprimer un graphique**

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


## **Mettre à jour les données du graphique**

Vous pouvez modifier les propriétés du graphique telles que le titre.
```csharp
static void Update_Chart_Data()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Modifier le titre du graphique
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```
