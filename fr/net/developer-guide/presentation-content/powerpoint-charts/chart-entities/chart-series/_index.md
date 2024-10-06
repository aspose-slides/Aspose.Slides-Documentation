---
title: Séries de Graphiques
type: docs
url: /net/chart-series/
keywords: "Séries de graphiques, couleur de série, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Séries de graphiques dans les présentations PowerPoint en C# ou .NET"
---

Une série est une ligne ou une colonne de chiffres tracés dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le Chevauchement des Séries de Graphiques**

Avec la propriété [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap), vous pouvez spécifier combien de barres et de colonnes doivent se chevaucher sur un graphique 2D (plage : -100 à 100). Cette propriété s'applique à toutes les séries du groupe de séries parent : c'est une projection de la propriété de groupe appropriée. Par conséquent, cette propriété est en lecture seule.

Utilisez la propriété en lecture/écriture `ParentSeriesGroup.Overlap` pour définir votre valeur préférée pour `Overlap`.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajouter un graphique à colonnes groupées sur une diapositive.
1. Accéder à la première série de graphiques.
1. Accéder au `ParentSeriesGroup` de la série de graphiques et définir votre valeur de chevauchement préférée pour la série.
1. Écrire la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment définir le chevauchement pour une série de graphiques :

```c#
using (Presentation presentation = new Presentation())
{
    // Ajoute le graphique
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.ChartData.Series;
    if (series[0].Overlap == 0)
    {
        // Définit le chevauchement de la série
        series[0].ParentSeriesGroup.Overlap = -30;
    }

    // Écrit le fichier de présentation sur le disque
    presentation.Save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
}
```

## **Changer la Couleur de la Série**
Aspose.Slides pour .NET vous permet de changer la couleur d'une série de cette manière :

1. Créer une instance de la classe `Presentation`.
1. Ajouter un graphique sur la diapositive.
1. Accéder à la série dont vous souhaitez changer la couleur. 
1. Définir votre type de remplissage préféré et la couleur de remplissage.
1. Enregistrer la présentation modifiée.

Ce code C# vous montre comment changer la couleur d'une série :

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[1];
	
	point.Explosion = 30;
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Changer la Couleur de la Catégorie de Série**
Aspose.Slides pour .NET vous permet de changer la couleur d'une catégorie de série de cette manière :

1. Créer une instance de la classe `Presentation`.
1. Ajouter un graphique sur la diapositive.
1. Accéder à la catégorie de série dont vous souhaitez changer la couleur.
1. Définir votre type de remplissage préféré et la couleur de remplissage.
1. Enregistrer la présentation modifiée.

Ce code en C# vous montre comment changer la couleur d'une catégorie de série :

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];
	
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Changer le Nom de la Série** 

Par défaut, les noms des légendes pour un graphique sont le contenu des cellules au-dessus de chaque colonne ou ligne de données.

Dans notre exemple (image d'échantillon), 

* les colonnes sont *Série 1, Série 2,* et *Série 3*;
* les lignes sont *Catégorie 1, Catégorie 2, Catégorie 3,* et *Catégorie 4.* 

Aspose.Slides pour .NET vous permet de mettre à jour ou de changer le nom d'une série dans ses données de graphique et sa légende. 

Ce code C# vous montre comment changer le nom d'une série dans ses données de graphique `ChartDataWorkbook` :

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = "Nouveau nom";
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

Ce code C# vous montre comment changer le nom d'une série dans sa légende via `Series` :

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.ChartData.Series[0];
    
    IStringChartValue name = series.Name;
    name.AsCells[0].Value = "Nouveau nom";   
}
```

## **Définir la Couleur de Remplissage des Séries de Graphiques**

Aspose.Slides pour .NET vous permet de définir la couleur de remplissage automatique pour les séries de graphiques à l'intérieur d'une zone de tracé de cette façon :

1. Créer une instance de la classe `Presentation`.
1. Obtenir une référence de diapositive par son index.
1. Ajouter un graphique avec des données par défaut en fonction de votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType.ClusteredColumn`).
1. Accéder aux séries de graphiques et définir la couleur de remplissage sur Automatique.
1. Enregistrer la présentation dans un fichier PPTX.

Ce code C# vous montre comment définir la couleur de remplissage automatique pour une série de graphiques :

```c#
using (Presentation presentation = new Presentation())
{
    // Crée un graphique à colonnes groupées
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Définit le format de remplissage de la série sur automatique
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series[i].GetAutomaticSeriesColor();
    }

    // Écrit le fichier de présentation sur le disque
    presentation.Save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
}
```

## **Définir les Couleurs de Remplissage Inversées des Séries de Graphiques**
Aspose.Slides vous permet de définir la couleur de remplissage inversée pour les séries de graphiques à l'intérieur d'une zone de tracé de cette façon :

1. Créer une instance de la classe `Presentation`.
1. Obtenir une référence de diapositive par son index.
1. Ajouter un graphique avec des données par défaut en fonction de votre type préféré (dans l'exemple ci-dessous, nous avons utilisé `ChartType.ClusteredColumn`).
1. Accéder à la série de graphiques et définir la couleur de remplissage sur inverser.
1. Enregistrer la présentation dans un fichier PPTX.

Ce code C# démontre l'opération :

```c#
Color inverColor = Color.Red;
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Ajoute de nouvelles séries et catégories
    chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Série 1"), chart.Type);
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Catégorie 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Catégorie 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Catégorie 3"));

    // Prend la première série de graphiques et remplit ses données de série.
    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;
    pres.Save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);               
}
```

## **Définir les Séries pour Inverser Lorsqu'une Valeur est Négative**
Aspose.Slides vous permet de définir des inversions via les propriétés `IChartDataPoint.InvertIfNegative` et `ChartDataPoint.InvertIfNegative`. Lorsqu'une inversion est définie à l'aide des propriétés, le point de données inverse ses couleurs lorsqu'il obtient une valeur négative.

Ce code C# démontre l'opération :

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
	IChartSeriesCollection series = chart.ChartData.Series;
	chart.ChartData.Series.Clear();

	series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -2));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

	series[0].InvertIfNegative = false;

	series[0].DataPoints[2].InvertIfNegative = true;

	pres.Save("out.pptx", SaveFormat.Pptx);
}
```

## **Effacer les Données de Points de Données Spécifiques**
Aspose.Slides pour .NET vous permet d'effacer les données `DataPoints` pour une série de graphiques spécifique de cette façon :

1. Créer une instance de la classe `Presentation`.
2. Obtenir la référence d'une diapositive par son index.
3. Obtenir la référence d'un graphique par son index.
4. Itérer à travers tous les `DataPoints` du graphique et définir `XValue` et `YValue` sur null.
5. Effacer tous les `DataPoints` pour une série de graphiques spécifique.
6. Écrire la présentation modifiée dans un fichier PPTX.

Ce code C# démontre l'opération :

```c#
using (Presentation pres = new Presentation("TestChart.pptx"))
{
	ISlide sl = pres.Slides[0];

	IChart chart = (IChart)sl.Shapes[0];

	foreach (IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
	{
		dataPoint.XValue.AsCell.Value = null;
		dataPoint.YValue.AsCell.Value = null;
	}

	chart.ChartData.Series[0].DataPoints.Clear();

	pres.Save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
}
```

## **Définir la Largeur de Fente de la Série**
Aspose.Slides pour .NET vous permet de définir la largeur de fente d'une série grâce à la propriété **`GapWidth`** de cette façon :

1. Créer une instance de la classe `Presentation`.
1. Accéder à la première diapositive.
1. Ajouter un graphique avec des données par défaut.
1. Accéder à n'importe quelle série de graphiques.
1. Définir la propriété `GapWidth`.
1. Écrire la présentation modifiée dans un fichier PPTX.

Ce code en C# vous montre comment définir la largeur de fente d'une série :

```c#
// Crée une présentation vide 
Presentation presentation = new Presentation();

// Accède à la première diapositive de la présentation
ISlide slide = presentation.Slides[0];

// Ajoute un graphique avec des données par défaut
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 0, 0, 500, 500);

// Définit l'index de la feuille de données du graphique
int defaultWorksheetIndex = 0;

// Obtient la feuille de données du graphique
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Ajoute des séries
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Série 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Série 2"), chart.Type);

// Ajoute des Catégories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Catégorie 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Catégorie 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Catégorie 3"));

// Prend la deuxième série de graphiques
IChartSeries series = chart.ChartData.Series[1];

// Remplit les données de la série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Définit la valeur de GapWidth
series.ParentSeriesGroup.GapWidth = 50;

// Enregistre la présentation sur le disque
presentation.Save("GapWidth_out.pptx", SaveFormat.Pptx);
```