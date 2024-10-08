---
title: Ligne de Tendance
type: docs
url: /fr/net/trend-line/
keywords: "Ligne de tendance, ligne personnalisée présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter une ligne de tendance et une ligne personnalisée aux présentations PowerPoint en C# ou .NET"
---

## **Ajouter une Ligne de Tendance**
Aspose.Slides pour .NET fournit une API simple pour gérer différentes lignes de tendance de graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir une référence de la diapositive par son index.
1. Ajouter un graphique avec des données par défaut ainsi que tout type souhaité (cet exemple utilise ChartType.ClusteredColumn).
1. Ajouter une ligne de tendance exponentielle pour la série de graphique 1.
1. Ajouter une ligne de tendance linéaire pour la série de graphique 1.
1. Ajouter une ligne de tendance logarithmique pour la série de graphique 2.
1. Ajouter une ligne de tendance de moyenne mobile pour la série de graphique 2.
1. Ajouter une ligne de tendance polynomiale pour la série de graphique 3.
1. Ajouter une ligne de tendance puissance pour la série de graphique 3.
1. Écrire la présentation modifiée dans un fichier PPTX.

Le code suivant est utilisé pour créer un graphique avec des Lignes de Tendance.

```c#
// Création d'une présentation vide
Presentation pres = new Presentation();

// Création d'un graphique à colonnes groupées
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Ajout d'une ligne de tendance exponentielle pour la série de graphique 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Ajout d'une ligne de tendance linéaire pour la série de graphique 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Ajout d'une ligne de tendance logarithmique pour la série de graphique 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("Nouvelle ligne de tendance logarithmique");

// Ajout d'une ligne de tendance de moyenne mobile pour la série de graphique 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "Nouveau nom de ligne de tendance";

// Ajout d'une ligne de tendance polynomiale pour la série de graphique 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Ajout d'une ligne de tendance puissance pour la série de graphique 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Enregistrement de la présentation
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Ajouter une Ligne Personnalisée**
Aspose.Slides pour .NET fournit une API simple pour ajouter des lignes personnalisées dans un graphique. Pour ajouter une ligne simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe Presentation
- Obtenir la référence d'une diapositive en utilisant son index
- Créer un nouveau graphique en utilisant la méthode AddChart exposée par l'objet Shapes
- Ajouter une forme automatique de type Ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes
- Définir la couleur des lignes de la forme.
- Écrire la présentation modifiée en tant que fichier PPTX

Le code suivant est utilisé pour créer un graphique avec des Lignes Personnalisées.

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