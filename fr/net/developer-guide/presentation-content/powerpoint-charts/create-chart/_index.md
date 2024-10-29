---
title: Créer ou Mettre à Jour des Graphiques de Présentation PowerPoint en C# ou .NET
linktitle: Créer ou Mettre à Jour un Graphique
type: docs
weight: 10
url: /fr/net/create-chart/
keywords: "Créer un graphique, graphique dispersé, graphique à secteurs, diagramme en arbre, graphique boursier, graphique de boîte et de moustache, graphique histogramme, graphique en entonnoir, graphique en soleil, graphique multicatégorie, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Créer un graphique dans une présentation PowerPoint en C# ou .NET"
---

## **Créer un Graphique**
Les graphiques aident les gens à visualiser rapidement les données et à obtenir des idées qui peuvent ne pas être immédiatement évidentes à partir d'un tableau ou d'une feuille de calcul.

**Pourquoi Créer des Graphiques ?**

En utilisant des graphiques, vous pouvez

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d'une présentation
* révéler des motifs et des tendances dans les données
* déduire la direction et l'élan des données au fil du temps ou par rapport à une unité de mesure spécifique
* repérer des valeurs aberrantes, des anomalies, des écarts, des erreurs, des données nonsensiques, etc.
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques grâce à la fonction d'insertion, qui fournit des modèles utilisés pour concevoir de nombreux types de graphiques. En utilisant Aspose.Slides, vous pouvez créer des graphiques réguliers (basés sur des types de graphiques populaires) et des graphiques personnalisés.

{{% alert color="primary" %}} 

Pour vous permettre de créer des graphiques, Aspose.Slides fournit l'énumération [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) dans l'espace de noms [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). Les valeurs de cette énumération correspondent à différents types de graphiques.

{{% /alert %}} 

### **Création de Graphiques Normaux**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence de la diapositive par son index.
1. Ajoutez un graphique avec des données et spécifiez votre type de graphique préféré.
1. Ajoutez un titre pour le graphique.
1. Accédez à la feuille de calcul des données du graphique.
1. Effacez toutes les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques.
1. Ajoutez une couleur de remplissage pour les séries de graphiques.
1. Ajoutez des étiquettes pour les séries de graphiques.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C# vous montre comment créer un graphique normal :

```c#
// Instancie la classe Presentation représentant un fichier PPTX
Presentation pres = new Presentation();

// Accède à la première diapositive
ISlide sld = pres.Slides[0];

// Ajoute un graphique avec ses données par défaut
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

// Définit le titre du graphique
chart.ChartTitle.AddTextFrameForOverriding("Titre d'exemple");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Définit la première série pour afficher les valeurs
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// Définit l'index pour la feuille de données du graphique
int defaultWorksheetIndex = 0;

// Obtient la feuille de calcul des données du graphique
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Supprime les séries et catégories générées par défaut
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

// Ajoutez de nouvelles séries
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Série 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Série 2"), chart.Type);

// Ajoutez de nouvelles catégories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Catégorie 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Catégorie 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Catégorie 3"));

// Prend la première série de graphique
IChartSeries series = chart.ChartData.Series[0];

// Remplit les données de la série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// Définit la couleur de remplissage pour la série
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Prend la deuxième série de graphique
series = chart.ChartData.Series[1];

// Remplit les données de la série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Définit la couleur de remplissage pour la série
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

// Définit la première étiquette pour afficher le nom de la catégorie
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

// Définit la série pour afficher la valeur pour la troisième étiquette
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

// Enregistre le fichier PPTX sur le disque
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **Création de Graphiques Dispersés**
Les graphiques dispersés (également connus sous le nom de graphiques dispersés ou graphiques xy) sont souvent utilisés pour vérifier des motifs ou démontrer des corrélations entre deux variables.

Vous pourriez vouloir utiliser un graphique dispersé lorsque

* vous avez des données numériques appariées
* vous avez 2 variables qui s'accordent bien ensemble
* vous souhaitez déterminer si 2 variables sont liées
* vous avez une variable indépendante qui a plusieurs valeurs pour une variable dépendante

Ce code C# vous montre comment créer des graphiques dispersés avec une série différente de marqueurs :

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

// Crée le graphique par défaut
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

// Obtient l'index de la feuille de données du graphique par défaut
int defaultWorksheetIndex = 0;

// Obtient la feuille de calcul des données du graphique
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Supprime les séries d'exemple
chart.ChartData.Series.Clear();

// Ajoute de nouvelles séries
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Série 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Série 2"), chart.Type);

// Prend la première série de graphique
IChartSeries series = chart.ChartData.Series[0];

// Ajoute un nouveau point (1:3) à la série
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

// Ajoute un nouveau point (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

// Change le type de série
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

// Change le marqueur de série du graphique
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

// Prend la deuxième série de graphique
series = chart.ChartData.Series[1];

// Ajoute un nouveau point (5:2) à la série de graphique
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

// Ajoute un nouveau point (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

// Ajoute un nouveau point (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

// Ajoute un nouveau point (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

// Change le marqueur de série du graphique
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

// Enregistre le fichier PPTX sur le disque
pres.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
```

### **Création de Graphiques à Secteurs**

Les graphiques à secteurs sont mieux utilisés pour montrer la relation partie-tout dans les données, surtout lorsque les données contiennent des étiquettes catégorielles avec des valeurs numériques. Cependant, si vos données contiennent de nombreuses parties ou étiquettes, vous pourriez envisager d'utiliser plutôt un graphique à barres.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence de la diapositive par son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.Pie`).
1. Accédez à la feuille de calcul des données du graphique IChartDataWorkbook.
1. Effacez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques.
1. Ajoutez de nouveaux points pour les graphiques et ajoutez des couleurs personnalisées pour les secteurs du graphique à secteurs.
1. Définissez des étiquettes pour les séries.
1. Définissez des lignes de leader pour les étiquettes des séries.
1. Définissez l'angle de rotation pour les diapositives de graphique à secteurs.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment créer un graphique à secteurs :

```c#
// Instancie une classe Presentation représentant un fichier PPTX
Presentation presentation = new Presentation();

// Accède à la première diapositive
ISlide slides = presentation.Slides[0];

// Ajoute un graphique avec ses données par défaut
IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Définit le titre du graphique
chart.ChartTitle.AddTextFrameForOverriding("Titre d'exemple");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Définit la première série pour montrer les valeurs
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

// Définit l'index pour la feuille de données du graphique
int defaultWorksheetIndex = 0;

// Obtient la feuille de calcul des données du graphique
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Supprime les séries et catégories générées par défaut
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

// Ajoute de nouvelles catégories
chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "Premier Trimestre"));
chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "Deuxième Trimestre"));
chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "Troisième Trimestre"));

// Ajoute de nouvelles séries
IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Série 1"), chart.Type);

// Remplit les données de la série
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

// Ne fonctionne pas dans la nouvelle version
// Ajout des nouveaux points et définition de la couleur des secteurs
// series.IsColorVaried = true;
chart.ChartData.SeriesGroups[0].IsColorVaried = true;

IChartDataPoint point = series.DataPoints[0];
point.Format.Fill.FillType = FillType.Solid;
point.Format.Fill.SolidFillColor.Color = Color.Cyan;
// Définit la bordure de secteur
point.Format.Line.FillFormat.FillType = FillType.Solid;
point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
point.Format.Line.Width = 3.0;
point.Format.Line.Style = LineStyle.ThinThick;
point.Format.Line.DashStyle = LineDashStyle.DashDot;

IChartDataPoint point1 = series.DataPoints[1];
point1.Format.Fill.FillType = FillType.Solid;
point1.Format.Fill.SolidFillColor.Color = Color.Brown;

// Définit la bordure de secteur
point1.Format.Line.FillFormat.FillType = FillType.Solid;
point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
point1.Format.Line.Width = 3.0;
point1.Format.Line.Style = LineStyle.Single;
point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

IChartDataPoint point2 = series.DataPoints[2];
point2.Format.Fill.FillType = FillType.Solid;
point2.Format.Fill.SolidFillColor.Color = Color.Coral;

// Définit la bordure de secteur
point2.Format.Line.FillFormat.FillType = FillType.Solid;
point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
point2.Format.Line.Width = 2.0;
point2.Format.Line.Style = LineStyle.ThinThin;
point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

// Crée des étiquettes personnalisées pour chacune des catégories pour la nouvelle série
IDataLabel lbl1 = series.DataPoints[0].Label;

// lbl.ShowCategoryName = true;
lbl1.DataLabelFormat.ShowValue = true;

IDataLabel lbl2 = series.DataPoints[1].Label;
lbl2.DataLabelFormat.ShowValue = true;
lbl2.DataLabelFormat.ShowLegendKey = true;
lbl2.DataLabelFormat.ShowPercentage = true;

IDataLabel lbl3 = series.DataPoints[2].Label;
lbl3.DataLabelFormat.ShowSeriesName = true;
lbl3.DataLabelFormat.ShowPercentage = true;

// Définit la série pour montrer des lignes de leader pour le graphique
series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

// Définit l'angle de rotation pour les secteurs du graphique à secteurs
chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

// Enregistre le fichier PPTX sur le disque
presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
```

### **Création de Graphiques Linéaires**

Les graphiques linéaires (également connus sous le nom de graphiques linéaires) sont mieux utilisés dans des situations où vous souhaitez démontrer des changements de valeur au fil du temps. En utilisant un graphique linéaire, vous pouvez comparer beaucoup de données à la fois, suivre les changements et les tendances au fil du temps, mettre en avant des anomalies dans les séries de données, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Obtenez une référence de la diapositive par son index. 
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.Line`). 
1. Accédez à la feuille de calcul des données IChartDataWorkbook. 
1. Effacez les séries et catégories par défaut. 
1. Ajoutez de nouvelles séries et catégories. 
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques. 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment créer un graphique linéaire :

```c#
using (Presentation pres = new Presentation())
{
    IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);
    
    pres.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Par défaut, les points sur un graphique linéaire sont reliés par des lignes continues droites. Si vous souhaitez que les points soient reliés par des tirets au lieu de cela, vous pouvez spécifier votre type de tiret préféré de cette manière : xxx

```c#
IChart lineChart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 10, 50, 600, 350);

foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

### **Création de Graphiques en Arbre**

Les graphiques en arbre sont mieux utilisés pour les données de ventes lorsque vous souhaitez montrer la taille relative des catégories de données et (en même temps) attirer rapidement l'attention sur les éléments qui contribuent de manière significative à chaque catégorie. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Obtenez une référence de la diapositive par son index. 
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.TreeMap`). 
1. Accédez à la feuille de calcul des données IChartDataWorkbook. 
1. Effacez les séries et catégories par défaut. 
1. Ajoutez de nouvelles séries et catégories. 
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques. 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment créer un graphique en arbre :

```c#
using (Presentation presentation = new Presentation())
{
	IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.Treemap, 50, 50, 500, 400);
	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	// Branche 1
	IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Feuille1"));
	leaf.GroupingLevels.SetGroupingItem(1, "Tige1");
	leaf.GroupingLevels.SetGroupingItem(2, "Branche1");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Feuille2"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Feuille3"));
	leaf.GroupingLevels.SetGroupingItem(1, "Tige2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Feuille4"));


	// Branche 2
	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Feuille5"));
	leaf.GroupingLevels.SetGroupingItem(1, "Tige3");
	leaf.GroupingLevels.SetGroupingItem(2, "Branche2");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Feuille6"));

	leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Feuille7"));
	leaf.GroupingLevels.SetGroupingItem(1, "Tige4");

	chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Feuille8"));

	IChartSeries series = chart.ChartData.Series.Add(Aspose.Slides.Charts.ChartType.Treemap);
	series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D1", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D2", 5));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D3", 3));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D4", 6));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D5", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D6", 9));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D7", 4));
	series.DataPoints.AddDataPointForTreemapSeries(wb.GetCell(0, "D8", 3));

	series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

	presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

### **Création de Graphiques Boursiers**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Obtenez une référence de la diapositive par son index. 
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.OpenHighLowClose). 
1. Accédez à la feuille de données IChartDataWorkbook. 
1. Effacez les séries et catégories par défaut. 
1. Ajoutez de nouvelles séries et catégories. 
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques. 
1. Spécifiez le format HiLowLines. 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Exemple de code C# utilisé pour créer un graphique boursier :

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);
    
	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "A"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "B"));
	chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "C"));

	chart.ChartData.Series.Add(wb.GetCell(0, 0, 1, "Ouvert"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 2, "Haut"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 3, "Bas"), chart.Type);
	chart.ChartData.Series.Add(wb.GetCell(0, 0, 4, "Fermé"), chart.Type);

	IChartSeries series = chart.ChartData.Series[0];

	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 1, 72));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 1, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 1, 38));

	series = chart.ChartData.Series[1];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 2, 172));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 2, 57));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 2, 57));

	series = chart.ChartData.Series[2];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 3, 12));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 3, 13));

	series = chart.ChartData.Series[3];
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 1, 4, 25));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 2, 4, 38));
	series.DataPoints.AddDataPointForStockSeries(wb.GetCell(0, 3, 4, 50));

	chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
	chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

	foreach (IChartSeries ser in chart.ChartData.Series)
	{
		ser.Format.Line.FillFormat.FillType = FillType.NoFill;
	}

	pres.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

### **Création de Graphiques de Boîte et de Moustache**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Obtenez une référence de la diapositive par son index. 
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.BoxAndWhisker). 
1. Accédez à la feuille de données IChartDataWorkbook. 
1. Effacez les séries et catégories par défaut. 
1. Ajoutez de nouvelles séries et catégories. 
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques. 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment créer un graphique de boîte et de moustache :

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Catégorie 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Catégorie 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Catégorie 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Catégorie 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Catégorie 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Catégorie 1"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

		series.QuartileMethod = QuartileMethodType.Exclusive;
		series.ShowMeanLine = true;
		series.ShowMeanMarkers = true;
		series.ShowInnerPoints = true;
		series.ShowOutlierPoints = true;

		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B1", 15));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B2", 41));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B3", 16));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B4", 10));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B5", 23));
		series.DataPoints.AddDataPointForBoxAndWhiskerSeries(wb.GetCell(0, "B6", 16));

		pres.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
	}
}
```

### **Création de Graphiques en Entonnoir**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Obtenez une référence de la diapositive par son index. 
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.Funnel). 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment créer un graphique en entonnoir :

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		chart.ChartData.Categories.Add(wb.GetCell(0, "A1", "Catégorie 1"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A2", "Catégorie 2"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A3", "Catégorie 3"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A4", "Catégorie 4"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A5", "Catégorie 5"));
		chart.ChartData.Categories.Add(wb.GetCell(0, "A6", "Catégorie 6"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B1", 50));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B2", 100));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B3", 200));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B4", 300));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B5", 400));
		series.DataPoints.AddDataPointForFunnelSeries(wb.GetCell(0, "B6", 500));

		pres.Save("Funnel.pptx", SaveFormat.Pptx);
	}
}
```

### **Création de Graphiques en Soleil**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Obtenez une référence de la diapositive par son index. 
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.sunburst`). 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment créer un graphique en soleil :

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		// Branche 1
		IChartCategory leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C1", "Feuille1"));
		leaf.GroupingLevels.SetGroupingItem(1, "Tige1");
		leaf.GroupingLevels.SetGroupingItem(2, "Branche1");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C2", "Feuille2"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C3", "Feuille3"));
		leaf.GroupingLevels.SetGroupingItem(1, "Tige2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C4", "Feuille4"));

		// Branche 2
		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C5", "Feuille5"));
		leaf.GroupingLevels.SetGroupingItem(1, "Tige3");
		leaf.GroupingLevels.SetGroupingItem(2, "Branche2");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C6", "Feuille6"));

		leaf = chart.ChartData.Categories.Add(wb.GetCell(0, "C7", "Feuille7"));
		leaf.GroupingLevels.SetGroupingItem(1, "Tige4");

		chart.ChartData.Categories.Add(wb.GetCell(0, "C8", "Feuille8"));

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
		series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D1", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D2", 5));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D3", 3));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D4", 6));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D5", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D6", 9));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D7", 4));
		series.DataPoints.AddDataPointForSunburstSeries(wb.GetCell(0, "D8", 3));

		pres.Save("Sunburst.pptx", SaveFormat.Pptx);
	}
}
```

### **Création de Graphiques Histogrammes**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Obtenez une référence de la diapositive par son index. 
1. Ajoutez des graphiques avec des données et spécifiez votre type de graphique préféré (`ChartType.Histogram` dans ce cas). 
1. Accédez aux données du graphique `IChartDataWorkbook`. 
1. Effacez les séries et catégories par défaut. 
1. Ajoutez de nouvelles séries et catégories. 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment créer un graphique histogramme :

```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Histogram, 50, 50, 500, 400);
		chart.ChartData.Categories.Clear();
		chart.ChartData.Series.Clear();

		IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

		wb.Clear(0);

		IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A1", 15));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A2", -41));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A3", 16));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A4", 10));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A5", -23));
		series.DataPoints.AddDataPointForHistogramSeries(wb.GetCell(0, "A6", 16));

		chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

		pres.Save("Histogram.pptx", SaveFormat.Pptx);
	}
}
```

### **Création de Graphiques Radar**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Obtenez une référence de la diapositive par son index. 
1. Ajoutez un graphique avec des données et spécifiez votre type de graphique préféré (`ChartType.Radar` dans ce cas). 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment créer un graphique radar :

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 400, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

### **Création de Graphiques Multicatégorie**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
1. Obtenez une référence de la diapositive par son index. 
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (ChartType.ClusteredColumn). 
1. Accédez aux données IChartDataWorkbook. 
1. Effacez les séries et catégories par défaut. 
1. Ajoutez de nouvelles séries et catégories. 
1. Ajoutez de nouvelles données de graphique pour les séries de graphiques. 
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code C# vous montre comment créer un graphique multicatégorie :

```c#
Presentation pres = new Presentation();
ISlide slide = pres.Slides[0];

IChart ch = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
ch.ChartData.Series.Clear();
ch.ChartData.Categories.Clear();


IChartDataWorkbook fact = ch.ChartData.ChartDataWorkbook;
fact.Clear(0);
int defaultWorksheetIndex = 0;

IChartCategory category = ch.ChartData.Categories.Add(fact.GetCell(0, "c2", "A"));
category.GroupingLevels.SetGroupingItem(1, "Groupe1");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c3", "B"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c4", "C"));
category.GroupingLevels.SetGroupingItem(1, "Groupe2");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c5", "D"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c6", "E"));
category.GroupingLevels.SetGroupingItem(1, "Groupe3");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c7", "F"));

category = ch.ChartData.Categories.Add(fact.GetCell(0, "c8", "G"));
category.GroupingLevels.SetGroupingItem(1, "Groupe4");
category = ch.ChartData.Categories.Add(fact.GetCell(0, "c9", "H"));

// Ajoute les séries
IChartSeries series = ch.ChartData.Series.Add(fact.GetCell(0, "D1", "Série 1"),
    ChartType.ClusteredColumn);

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D2", 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D3", 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D4", 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D5", 40));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D6", 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D7", 60));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D8", 70));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, "D9", 80));
// Enregistre la présentation avec le graphique
pres.Save("AsposeChart_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **Création de Graphiques de Carte**

Un graphique de carte est une visualisation d'une zone contenant des données. Les graphiques de carte sont mieux utilisés pour comparer des données ou des valeurs à travers des régions géographiques.

Ce code C# vous montre comment créer un graphique de carte :

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Map, 50, 50, 500, 400);
    pres.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

### **Création de Graphiques de Combinaison**

Un graphique de combinaison (ou combo chart) est un graphique qui combine deux ou plusieurs graphiques sur un seul graphique. Un tel graphique vous permet de mettre en évidence, de comparer ou de passer en revue les différences entre deux (ou plusieurs) ensembles de données. De cette façon, vous voyez la relation (s'il y en a) entre les ensembles de données.

![combination-chart-ppt](combination-chart-ppt.png)

Ce code C# vous montre comment créer un graphique de combinaison dans PowerPoint :

```c#
private static void CreateComboChart()
{
    using (Presentation pres = new Presentation())
    {
        IChart chart = CreateChart(pres.Slides[0]);
        AddFirstSeriesToChart(chart);
        AddSecondSeriesToChart(chart);
        pres.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChart(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Série 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Série 2"), chart.Type);
    
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Catégorie 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Catégorie 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Catégorie 3"));

    IChartSeries series = chart.ChartData.Series[0];

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));
    
    series = chart.ChartData.Series[1];
    
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    return chart;
}

private static void AddFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Série 3"), ChartType.ScatterWithSmoothLines);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 0, 1, 3),
        workbook.GetCell(worksheetIndex, 0, 2, 5));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 10),
        workbook.GetCell(worksheetIndex, 1, 4, 13));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 3, 20),
        workbook.GetCell(worksheetIndex, 2, 4, 15));

    series.PlotOnSecondAxis = true;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;
    
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 5, "Série 4"),
        ChartType.ScatterWithStraightLinesAndMarkers);

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 3, 5),
        workbook.GetCell(worksheetIndex, 1, 4, 2));
    
    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 1, 5, 10),
        workbook.GetCell(worksheetIndex, 1, 6, 7));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 2, 5, 15),
        workbook.GetCell(worksheetIndex, 2, 6, 12));

    series.DataPoints.AddDataPointForScatterSeries(
        workbook.GetCell(worksheetIndex, 3, 5, 12),
        workbook.GetCell(worksheetIndex, 3, 6, 9));
    
    series.PlotOnSecondAxis = true;
}
```

## **Mise à Jour des Graphiques**

1. Instanciez une classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui représente la présentation contenant le graphique. 
2. Obtenez une référence de la diapositive par son index. 
3. Parcourez toutes les formes pour trouver le graphique souhaité. 
4. Accédez à la feuille de calcul des données du graphique. 
5. Modifiez les données de la série de graphiques en changeant les valeurs des séries. 
6. Ajoutez une nouvelle série et remplissez les données dans celle-ci. 
7. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C# vous montre comment mettre à jour un graphique :

```c#
// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation("ExistingChart.pptx");

// Accède à la première diapositive
ISlide sld = pres.Slides[0];

// Ajoute un graphique avec des données par défaut
IChart chart = (IChart)sld.Shapes[0];

// Définit l'index pour la feuille de données du graphique
int defaultWorksheetIndex = 0;

// Obtient la feuille de calcul des données du graphique
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;


// Change le nom de catégorie du graphique
fact.GetCell(defaultWorksheetIndex, 1, 0, "Catégorie Modifiée 1");
fact.GetCell(defaultWorksheetIndex, 2, 0, "Catégorie Modifiée 2");


// Prend la première série de graphique
IChartSeries series = chart.ChartData.Series[0];

// Met à jour les données de la série
fact.GetCell(defaultWorksheetIndex, 0, 1, "Nouvelle_Série1"); // Modification du nom de la série
series.DataPoints[0].Value.Data = 90;
series.DataPoints[1].Value.Data = 123;
series.DataPoints[2].Value.Data = 44;

// Prend la deuxième série de graphique
series = chart.ChartData.Series[1];

// Met à jour maintenant les données de la série
fact.GetCell(defaultWorksheetIndex, 0, 2, "Nouvelle_Série2"); // Modification du nom de la série
series.DataPoints[0].Value.Data = 23;
series.DataPoints[1].Value.Data = 67;
series.DataPoints[2].Value.Data = 99;


// Maintenant, ajout d'une nouvelle série
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 3, "Série 3"), chart.Type);

// Prend la 3ème série de graphique
series = chart.ChartData.Series[2];

// Remplit maintenant les données de la série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 3, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 30));

chart.Type = ChartType.ClusteredCylinder;

// Enregistre la présentation avec le graphique
pres.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
```

## **Définir la Plage de Données des Graphiques**

1. Instanciez une classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) qui représente la présentation contenant le graphique. 
2. Obtenez une référence de la diapositive par son index. 
3. Parcourez toutes les formes pour trouver le graphique souhaité. 
4. Accédez aux données du graphique et définissez la plage. 
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment définir la plage de données pour un graphique :

```c#
// Instancie une classe Presentation qui représente un fichier PPTX
Presentation presentation = new Presentation("ExistingChart.pptx");

// Accède à la première diapositive et ajoute un graphique avec des données par défaut
ISlide slide = presentation.Slides[0];
IChart chart = (IChart)slide.Shapes[0];
chart.ChartData.SetRange("Sheet1!A1:B4");
presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
```


## **Utiliser des Marqueurs par Défaut dans les Graphiques**
Lorsque vous utilisez un marqueur par défaut dans les graphiques, chaque série de graphique obtient automatiquement des symboles de marqueurs par défaut différents.

Ce code C# vous montre comment configurer automatiquement un marqueur de série de graphique :

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;
    chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Série 1"), chart.Type);
    IChartSeries series = chart.ChartData.Series[0];

    chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 1, 24));
    chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 1, 23));
    chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 1, -10));
    chart.ChartData.Categories.Add(fact.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 1, null));

    chart.ChartData.Series.Add(fact.GetCell(0, 0, 2, "Série 2"), chart.Type);
    // Prend la deuxième série de graphique
    IChartSeries series2 = chart.ChartData.Series[1];

    // Remplit les données de la série
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(fact.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    pres.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
``` 