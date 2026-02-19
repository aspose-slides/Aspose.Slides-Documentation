---
title: Graphique
type: docs
weight: 60
url: /fr/net/examples/elements/chart/
keywords:
- graphique
- ajouter un graphique
- accéder à un graphique
- supprimer un graphique
- mettre à jour un graphique
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les graphiques avec Aspose.Slides for .NET : créez, formatez, liez des données et exportez des graphiques en PPT, PPTX et ODP avec des exemples C#."
---
Exemples d'ajout, d'accès, de suppression et de mise à jour de différents types de graphiques avec **Aspose.Slides for .NET**. Les extraits ci-dessous démontrent les opérations de base sur les graphiques.

## **Ajouter un graphique**

Cette méthode ajoute un graphique en aires simple à la première diapositive.

```csharp
static void AddChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Ajoutez un graphique en aires simple à la première diapositive.
    var chart = slide.Shapes.AddChart(ChartType.Area, 50, 50, 400, 300);
}
```

## **Accéder à un graphique**

Après avoir créé un graphique, vous pouvez le récupérer via la collection de formes.

```csharp
static void AccessChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 400, 300);

    // Accédez au premier graphique sur la diapositive.
    var firstChart = slide.Shapes.OfType<IChart>().First();
}
```

## **Supprimer un graphique**

Le code suivant supprime un graphique d'une diapositive.

```csharp
static void RemoveChart()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 300);

    // Supprime le graphique.
    slide.Shapes.Remove(chart);
}
```

## **Mettre à jour les données du graphique**

Vous pouvez modifier les propriétés du graphique comme le titre.

```csharp
static void UpdateChartData()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 400, 300);

    // Modifiez le titre du graphique.
    chart.ChartTitle.AddTextFrameForOverriding("Sales Report");
}
```