---
title: Ajouter des lignes de tendance aux graphiques de présentation en .NET
linktitle: Ligne de tendance
type: docs
url: /fr/net/trend-line/
keywords:
- graphique
- ligne de tendance
- ligne de tendance exponentielle
- ligne de tendance linéaire
- ligne de tendance logarithmique
- ligne de tendance moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance de puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Ajoutez et personnalisez rapidement des lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour .NET — un guide pratique pour captiver votre audience."
---

## **Ajouter une ligne de tendance**
Aspose.Slides pour .NET fournit une API simple pour gérer différentes lignes de tendance de graphiques :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d’une diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise ChartType.ClusteredColumn).
1. Ajoutez une ligne de tendance exponentielle pour la série 1 du graphique.
1. Ajoutez une ligne de tendance linéaire pour la série 1 du graphique.
1. Ajoutez une ligne de tendance logarithmique pour la série 2 du graphique.
1. Ajoutez une ligne de tendance moyenne mobile pour la série 2 du graphique.
1. Ajoutez une ligne de tendance polynomiale pour la série 3 du graphique.
1. Ajoutez une ligne de tendance de puissance pour la série 3 du graphique.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des lignes de tendance.
```c#
// Création d'une présentation vide
// Création d'un graphique en colonnes groupées
// Ajout d'une ligne de tendance exponentielle pour la série 1 du graphique
// Ajout d'une ligne de tendance linéaire pour la série 1 du graphique
// Ajout d'une ligne de tendance logarithmique pour la série 2 du graphique
// Ajout d'une ligne de tendance moyenne mobile pour la série 2 du graphique
// Ajout d'une ligne de tendance polynomiale pour la série 3 du graphique
// Ajout d'une ligne de tendance de puissance pour la série 3 du graphique
// Enregistrement de la présentation
Presentation pres = new Presentation();

// Creating a clustered column chart
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Adding ponential trend line for chart series 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Adding Linear trend line for chart series 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Adding Logarithmic trend line for chart series 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Adding MovingAverage trend line for chart series 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Adding Polynomial trend line for chart series 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Adding Power trend line for chart series 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Saving presentation
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```




## **Ajouter une ligne personnalisée**
Aspose.Slides pour .NET fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

- Créez une instance de la classe Presentation
- Obtenez la référence d’une diapositive en utilisant son Index
- Créez un nouveau graphique à l’aide de la méthode AddChart exposée par l’objet Shapes
- Ajoutez une AutoShape de type Line à l’aide de la méthode AddAutoShape exposée par l’objet Shapes
- Définissez la couleur des lignes de la forme.
- Enregistrez la présentation modifiée en tant que fichier PPTX

Le code suivant est utilisé pour créer un graphique avec des lignes personnalisées.
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Que signifient « forward » et « backward » pour une ligne de tendance ?**

Il s’agit des longueurs de la ligne de tendance projetées en avant ou en arrière : pour les graphiques de dispersion (XY) – en unités d’axe ; pour les graphiques non‑dispersion – en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance est‑elle conservée lors de l’exportation de la présentation au format PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/net/convert-powerpoint-to-pdf/)/[SVG](/slides/fr/net/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont conservées pendant ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/net/create-shape-thumbnails/) lui‑même.