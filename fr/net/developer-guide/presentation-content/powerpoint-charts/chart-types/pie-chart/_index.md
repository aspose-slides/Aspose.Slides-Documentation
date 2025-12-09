---
title: Personnaliser les graphiques circulaires dans les présentations en .NET
linktitle: Graphique circulaire
type: docs
url: /fr/net/pie-chart/
keywords:
- graphique circulaire
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur de part
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques circulaires en .NET avec Aspose.Slides, exportables vers PowerPoint, pour renforcer votre storytelling de données en quelques secondes."
---

## **Options de deuxième tracé pour les graphiques Pie of Pie et Bar of Pie**
Aspose.Slides for .NET prend désormais en charge les options de deuxième tracé pour les graphiques Pie of Pie ou Bar of Pie. Dans ce sujet, nous verrons avec un exemple comment spécifier ces options à l'aide d'Aspose.Slides. Pour spécifier les propriétés, veuillez suivre les étapes ci-dessous :

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajouter un graphique sur la diapositive.
1. Spécifier les options de deuxième tracé du graphique.
1. Enregistrer la présentation sur le disque.

Dans l'exemple ci-dessous, nous avons défini différentes propriétés du graphique Pie of Pie.
```c#
 // Créez une instance de la classe Presentation
 Presentation presentation = new Presentation();

 // Ajoutez le graphique sur la diapositive
 IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
      
 // Définissez différentes propriétés
 chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
 chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
 chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
 chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

 // Enregistrez la présentation sur le disque
 presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```


## **Définir les couleurs automatiques des parts du graphique circulaire**
Aspose.Slides for .NET fournit une API simple pour définir les couleurs automatiques des parts d'un graphique circulaire. Le code d'exemple applique la configuration des propriétés mentionnées ci-dessus.

1. Créer une instance de la classe Presentation.
1. Accéder à la première diapositive.
1. Ajouter un graphique avec des données par défaut.
1. Définir le titre du graphique.
1. Configurer la première série pour afficher les valeurs.
1. Définir l'index de la feuille de données du graphique.
1. Obtenir la feuille de calcul des données du graphique.
1. Supprimer les séries et catégories générées par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter une nouvelle série.

Enregistrer la présentation modifiée dans un fichier PPTX.
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
	 chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	 chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	 chart.ChartTitle.Height = 20;
	 chart.HasTitle = true;

	 // Configurer la première série pour afficher les valeurs
	 chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	 // Définir l'index de la feuille de données du graphique
	 int defaultWorksheetIndex = 0;

	 // Obtenir la feuille de calcul des données du graphique
	 IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	 // Supprimer les séries et catégories générées par défaut
	 chart.ChartData.Series.Clear();
	 chart.ChartData.Categories.Clear();

	 // Ajouter de nouvelles catégories
	 chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	 chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	 chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	 // Ajouter une nouvelle série
	 IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	 // Remplir maintenant les données de la série
	 series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	 series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	 series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	 series.ParentSeriesGroup.IsColorVaried = true;
	 presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **FAQ**

**Les variantes 'Pie of Pie' et 'Bar of Pie' sont-elles prises en charge?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types 'Pie of Pie' et 'Bar of Pie'.

**Puis-je exporter uniquement le graphique en tant qu'image (par exemple, PNG)?**

Oui, vous pouvez [exporter le graphique lui-même en image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (comme PNG) sans toute la présentation.