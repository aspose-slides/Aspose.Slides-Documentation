---
title: Axe de diagramme
type: docs
url: /fr/net/chart-axis/
keywords: "Axe de diagramme PowerPoint, Diagrammes de présentation, C#, .NET, Manipuler l'Axe de diagramme, Données de diagramme"
description: "Modifier l'axe du diagramme PowerPoint en C# ou .NET"
---


## **Obtenir les valeurs maximales sur l'axe vertical des diagrammes**
Aspose.Slides pour .NET vous permet d'obtenir les valeurs minimales et maximales sur un axe vertical. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accédez à la première diapositive.
1. Ajoutez un diagramme avec des données par défaut.
1. Obtenez la valeur maximale réelle sur l'axe.
1. Obtenez la valeur minimale réelle sur l'axe.
1. Obtenez l'unité majeure réelle de l'axe.
1. Obtenez l'unité mineure réelle de l'axe.
1. Obtenez l'échelle de l'unité majeure réelle de l'axe.
1. Obtenez l'échelle de l'unité mineure réelle de l'axe.

Ce code d'exemple—une implémentation des étapes ci-dessus—vous montre comment obtenir les valeurs requises en C# :

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Sauvegarde de la présentation
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```


## **Échanger les données entre les axes**
Aspose.Slides vous permet d'échanger rapidement les données entre les axes—les données représentées sur l'axe vertical (axe des y) se déplacent vers l'axe horizontal (axe des x) et vice versa. 

Ce code C# vous montre comment effectuer la tâche d'échange de données entre les axes d'un diagramme :

```c#
// Crée une présentation vide
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Échange les lignes et les colonnes
	chart.ChartData.SwitchRowColumn();
		   
	// Sauvegarde de la présentation
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Désactiver l'axe vertical pour les diagrammes linéaires**

Ce code C# vous montre comment masquer l'axe vertical pour un diagramme linéaire :

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Désactiver l'axe horizontal pour les diagrammes linéaires**

Ce code vous montre comment masquer l'axe horizontal pour un diagramme linéaire :

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Changer l'axe des catégories**

À l'aide de la propriété **CategoryAxisType**, vous pouvez spécifier votre type d'axe de catégorie préféré (**date** ou **texte**). Ce code en C# démontre l'opération : 

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

## **Définir le format de date pour la valeur de l'axe des catégories**
Aspose.Slides pour .NET vous permet de définir le format de date pour une valeur d'axe de catégorie. L'opération est démontrée dans ce code C# :

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

## **Définir l'angle de rotation pour le titre de l'axe du diagramme**
Aspose.Slides pour .NET vous permet de définir l'angle de rotation pour un titre d'axe de diagramme. Ce code C# démontre l'opération :

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Définir l'axe de position dans un axe de catégorie ou de valeur**
Aspose.Slides pour .NET vous permet de définir l'axe de position dans un axe de catégorie ou de valeur. Ce code C# montre comment effectuer la tâche :

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Activer l'étiquette d'unité d'affichage sur l'axe de valeur du diagramme**
Aspose.Slides pour .NET vous permet de configurer un diagramme pour afficher une étiquette d'unité sur son axe de valeur du diagramme. Ce code C# démontre l'opération :

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```