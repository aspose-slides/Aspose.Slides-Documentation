---
title: Personnaliser les axes de graphique dans les présentations en .NET
linktitle: Axe de graphique
type: docs
url: /fr/net/chart-axis/
keywords:
- axe du graphique
- axe vertical
- axe horizontal
- personnaliser l'axe
- manipuler l'axe
- gérer l'axe
- propriétés de l'axe
- valeur maximale
- valeur minimale
- ligne d'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides pour .NET afin de personnaliser les axes des graphiques dans les présentations PowerPoint pour les rapports et les visualisations."
---

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**
Aspose.Slides for .NET vous permet d’obtenir les valeurs minimale et maximale sur un axe vertical. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec les données par défaut.
1. Récupérez la valeur maximale réelle de l’axe.
1. Récupérez la valeur minimale réelle de l’axe.
1. Récupérez l’unité principale réelle de l’axe.
1. Récupérez l’unité secondaire réelle de l’axe.
1. Récupérez l’échelle de l’unité principale réelle de l’axe.
1. Récupérez l’échelle de l’unité secondaire réelle de l’axe.

Ce code d’exemple—une implémentation des étapes ci‑dessus—vous montre comment obtenir les valeurs requises en C# :
```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Enregistre la présentation
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **Échanger les données entre les axes**
Aspose.Slides vous permet d’échanger rapidement les données entre les axes : les données représentées sur l’axe vertical (axe y) sont déplacées vers l’axe horizontal (axe x) et inversement.

Ce code C# vous montre comment réaliser l’échange de données entre les axes d’un graphique :
```c#
	// Crée une présentation vide
	using (Presentation pres = new Presentation())
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

		//Échange les lignes et les colonnes
		chart.ChartData.SwitchRowColumn();
			   
		// Enregistre la présentation
		 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
	 }
```


## **Désactiver l’axe vertical pour les graphiques en courbes**

Ce code C# vous montre comment masquer l’axe vertical d’un graphique en courbes :
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Désactiver l’axe horizontal pour les graphiques en courbes**

Ce code vous montre comment masquer l’axe horizontal d’un graphique en courbes :
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```


## **Modifier un axe de catégorie**

À l’aide de la propriété **CategoryAxisType**, vous pouvez spécifier le type d’axe de catégorie souhaité (**date** ou **text**). Ce code C# démontre cette opération :
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```


## **Définir le format de date pour les valeurs d’un axe de catégorie**
Aspose.Slides for .NET vous permet de définir le format de date pour une valeur d’axe de catégorie. L’opération est illustrée dans ce code C# :
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Définir un angle de rotation pour le titre d’un axe de graphique**
Aspose.Slides for .NET vous permet de définir l’angle de rotation pour le titre d’un axe de graphique. Ce code C# montre comment faire :
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```


## **Définir la position de l’axe sur un axe de catégorie ou de valeur**
Aspose.Slides for .NET vous permet de définir la position de l’axe dans un axe de catégorie ou de valeur. Ce code C# montre comment réaliser la tâche :
```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```


## **Activer l’étiquette d’unité d’affichage sur l’axe de valeur d’un graphique**
Aspose.Slides for .NET vous permet de configurer un graphique pour afficher une étiquette d’unité sur son axe de valeur. Ce code C# démontre l’opération :
```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Comment définir la valeur à laquelle un axe croise l’autre (croisement d’axes) ?**

Les axes offrent un [paramètre de croisement](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) : vous pouvez choisir de croiser à zéro, au maximum de la catégorie/valeur, ou à une valeur numérique spécifique. Cela est utile pour déplacer l’axe X vers le haut ou le bas ou pour mettre en évidence une ligne de base.

**Comment positionner les étiquettes de graduation par rapport à l’axe (à côté, à l’extérieur, à l’intérieur) ?**

Définissez la [position de l’étiquette](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) sur « cross », « outside » ou « inside ». Cela influence la lisibilité et aide à économiser de l’espace, notamment sur les petits graphiques.