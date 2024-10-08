---
title: Graphique à secteurs
type: docs
url: /fr/net/pie-chart/
keywords: "Graphique à secteurs, options de tracé, couleurs des segments, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Options de tracé des graphiques à secteurs et couleurs des segments dans une présentation PowerPoint en C# ou .NET"
---

## **Options de tracé secondaire pour graphique à secteurs de secteurs et graphique à secteurs de barres**
Aspose.Slides pour .NET prend désormais en charge les options de tracé secondaire pour les graphiques à secteurs de secteurs ou les graphiques à secteurs de barres. Dans ce sujet, nous allons voir avec un exemple comment spécifier ces options en utilisant Aspose.Slides. Pour spécifier les propriétés, veuillez suivre les étapes ci-dessous :

1. Instancier un objet de classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajouter un graphique sur la diapositive.
1. Spécifier les options de tracé secondaire du graphique.
1. Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini différentes propriétés du graphique à secteurs de secteurs.

```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();

// Ajouter un graphique sur la diapositive
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Définir différentes propriétés
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Écrire la présentation sur le disque
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **Définir les couleurs des segments de graphique à secteurs automatiques**
Aspose.Slides pour .NET fournit une API simple pour définir les couleurs des segments de graphique à secteurs automatiques. Le code d'exemple applique les propriétés mentionnées ci-dessus.

1. Créer une instance de la classe Presentation.
1. Accéder à la première diapositive.
1. Ajouter un graphique avec des données par défaut.
1. Définir le titre du graphique.
1. Définir la première série pour afficher les valeurs.
1. Définir l'index de la feuille de données du graphique.
1. Obtenir la feuille de calcul des données du graphique.
1. Supprimer les séries et catégories générées par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter de nouvelles séries.

Écrire la présentation modifiée dans un fichier PPTX.

```c#
// Instancier la classe Presentation qui représente le fichier PPTX
using (Presentation presentation = new Presentation())
{
	// Instancier la classe Presentation qui représente le fichier PPTX
	Presentation presentation = new Presentation();

	// Accéder à la première diapositive
	ISlide slides = presentation.Slides[0];

	// Ajouter un graphique avec des données par défaut
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Définir le titre du graphique
	chart.ChartTitle.AddTextFrameForOverriding("Titre d'exemple");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Définir la première série pour afficher les valeurs
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Définir l'index de la feuille de données du graphique
	int defaultWorksheetIndex = 0;

	// Obtenir la feuille de calcul des données du graphique
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Supprimer les séries et catégories générées par défaut
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Ajouter de nouvelles catégories
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "Premier trimestre"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2ème trimestre"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3ème trimestre"));

	// Ajouter de nouvelles séries
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Série 1"), chart.Type);

	// Maintenant, peupler les données de la série
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```