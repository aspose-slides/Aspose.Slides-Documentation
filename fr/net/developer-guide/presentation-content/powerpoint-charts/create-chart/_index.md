---
title: Créer ou mettre à jour des graphiques de présentation PowerPoint dans .NET
linktitle: Créer ou mettre à jour des graphiques
type: docs
weight: 10
url: /fr/net/create-chart/
keywords:
- ajouter graphique
- créer graphique
- modifier graphique
- changer graphique
- mettre à jour graphique
- graphique en nuage de points
- graphique circulaire
- graphique en ligne
- graphique en carte d'arbres
- graphique boursier
- graphique à boîte et moustaches
- graphique en entonnoir
- graphique Sunburst
- histogramme
- graphique radar
- graphique multicatégorie
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer et personnaliser des graphiques dans les présentations PowerPoint à l'aide d'Aspose.Slides pour .NET. Ajouter, mettre en forme et modifier des graphiques avec des exemples de code pratiques en C#."
---

## **Vue d’ensemble**

Cet article fournit un guide complet sur la création et la personnalisation de graphiques avec Aspose.Slides pour .NET. Vous apprendrez à ajouter programmétiquement un graphique à une diapositive, à le peupler de données et à appliquer diverses options de mise en forme pour répondre à vos exigences de conception spécifiques. Tout au long de l’article, des exemples de code détaillés illustrent chaque étape, de l’initialisation de la présentation et de l’objet graphique à la configuration des séries, des axes et des légendes. En suivant ce guide, vous acquerrez une solide compréhension de l’intégration de la génération dynamique de graphiques dans vos applications .NET, simplifiant la création de présentations basées sur les données.

## **Créer un graphique**

Les graphiques aident les utilisateurs à visualiser rapidement les données et à en tirer des informations qui ne sont pas immédiatement évidentes dans un tableau ou une feuille de calcul.

**Pourquoi créer des graphiques ?**

Avec les graphiques, vous pouvez :

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive ;
* révéler des motifs et des tendances dans les données ;
* déduire la direction et l’élan des données dans le temps ou par rapport à une unité de mesure spécifique ;
* repérer les valeurs aberrantes, les écarts, les erreurs et les données incohérentes ;
* communiquer ou présenter des données complexes.

Dans PowerPoint, vous pouvez créer des graphiques via la fonction *Insertion*, qui propose des modèles pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer à la fois des graphiques classiques (basés sur des types de graphiques populaires) et des graphiques personnalisés.

{{% alert color="primary" %}} 
Utilisez l’énumération [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) du namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/). Les valeurs de cette énumération correspondent aux différents types de graphiques.
{{% /alert %}} 

### **Créer des graphiques à colonnes groupées**

Cette section explique comment créer des graphiques à colonnes groupées avec Aspose.Slides pour .NET. Vous apprendrez à initialiser une présentation, ajouter un graphique et personnaliser ses éléments tels que le titre, les données, les séries, les catégories et le style. Suivez les étapes ci‑dessous pour voir comment un graphique à colonnes groupées standard est généré :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données et spécifiez le type `ChartType.ClusteredColumn`.
1. Ajoutez un titre au graphique.
1. Accédez à la feuille de données du graphique.
1. Supprimez toutes les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries.
1. Appliquez une couleur de remplissage aux séries.
1. Ajoutez des libellés aux séries.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique à colonnes groupées :
```c#
// Instancier la classe Presentation.
using (Presentation presentation = new Presentation())
{
    // Accéder à la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter un graphique à colonnes groupées avec ses données par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Définir le titre du graphique.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Configurer la première série pour afficher les valeurs.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Définir l’indice de la feuille de données du graphique.
    int worksheetIndex = 0;

    // Obtenir le classeur de données du graphique.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Supprimer les séries et catégories générées par défaut.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Ajouter de nouvelles séries.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Ajouter de nouvelles catégories.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Obtenir la première série du graphique.
    IChartSeries series = chart.ChartData.Series[0];

    // Remplir les données de la série.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Définir la couleur de remplissage pour la série.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Obtenir la deuxième série du graphique.
    series = chart.ChartData.Series[1];

    // Remplir les données de la série.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Définir la couleur de remplissage pour la série.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Définir le premier libellé pour afficher le nom de la catégorie.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Configurer la série pour afficher la valeur du troisième libellé.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Enregistrer la présentation sur le disque sous forme de fichier PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique à colonnes groupées](clustered_column_chart.png)

### **Créer des graphiques en nuage de points**

Les graphiques en nuage de points (également appelés nuages de dispersion ou graphiques x‑y) sont souvent utilisés pour vérifier des motifs ou démontrer des corrélations entre deux variables.

Utilisez un graphique en nuage de points lorsque :

* Vous avez des données numériques appariées.
* Vous avez deux variables qui se combinent bien.
* Vous souhaitez déterminer si les deux variables sont liées.
* Vous avez une variable indépendante avec plusieurs valeurs pour une variable dépendante.

Ce code C# montre comment créer un graphique en nuage de points avec une série de marqueurs différente :
```c#
// Instancier la classe Presentation.
using (Presentation presentation = new Presentation())
{
    // Accéder à la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Créer le graphique de dispersion par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Définir l’indice de la feuille de données du graphique.
    int worksheetIndex = 0;

    // Obtenir le classeur de données du graphique.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Supprimer les séries par défaut.
    chart.ChartData.Series.Clear();

    // Ajouter de nouvelles séries.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Obtenir la première série du graphique.
    IChartSeries series = chart.ChartData.Series[0];

    // Ajouter un nouveau point (1:3) à la série.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Ajouter un nouveau point (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Modifier le type de la série.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Modifier le marqueur de la série du graphique.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Obtenir la deuxième série du graphique.
    series = chart.ChartData.Series[1];

    // Ajouter un nouveau point (5:2) à la série du graphique.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Ajouter un nouveau point (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Ajouter un nouveau point (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Ajouter un nouveau point (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Modifier le marqueur de la série du graphique.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Enregistrer la présentation sur le disque sous forme de fichier PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique en nuage de points](scatter_chart.png)

### **Créer des graphiques circulaires**

Les graphiques circulaires sont idéaux pour illustrer la relation partie‑à‑tout dans des données, notamment lorsque les données comportent des libellés catégoriques associés à des valeurs numériques. Cependant, si vos données contiennent de nombreuses parties ou libellés, vous pourriez préférer un graphique à barres.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données par défaut et spécifiez le type `ChartType.Pie`.
1. Accédez au classeur de données du graphique ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Supprimez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries.
1. Ajoutez de nouveaux points au graphique et appliquez des couleurs personnalisées aux secteurs du graphique circulaire.
1. Définissez les libellés des séries.
1. Activez les lignes de repère pour les libellés de séries.
1. Définissez l’angle de rotation du graphique circulaire.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique circulaire :
```c#
// Instancier la classe Presentation.
using (Presentation presentation = new Presentation())
{
    // Accéder à la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter un graphique avec ses données par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Définir le titre du graphique.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Définir la première série pour afficher les valeurs.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Définir l’indice de la feuille de données du graphique.
    int worksheetIndex = 0;

    // Obtenir le classeur de données du graphique.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Supprimer les séries et catégories générées par défaut.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Ajouter de nouvelles catégories.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Ajouter de nouvelles séries.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Remplir les données de la série.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Définir la couleur du secteur.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Définir la bordure du secteur.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Définir la bordure du secteur.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Définir la bordure du secteur.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Créer des libellés personnalisés pour chaque catégorie de la nouvelle série.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Définir la série pour afficher les lignes de repère du graphique.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Définir l’angle de rotation des secteurs du graphique circulaire.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Enregistrer la présentation sur le disque sous forme de fichier PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique circulaire](pie_chart.png)

### **Créer des graphiques en ligne**

Les graphiques en ligne (ou graphiques linéaires) sont idéaux pour illustrer les variations de valeur dans le temps. Avec un graphique en ligne, vous pouvez comparer un grand nombre de données simultanément, suivre les évolutions et les tendances dans le temps, mettre en évidence les anomalies d’une série, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données par défaut et spécifiez le type `ChartType.Line`.
1. Accédez au classeur de données du graphique ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Supprimez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique en ligne :
```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```


Par défaut, les points d’un graphique en ligne sont reliés par des lignes continues droites. Si vous souhaitez que les points soient reliés par des tirets, vous pouvez spécifier le type de tiret souhaité comme suit :
```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```


Le résultat :

![Le graphique en ligne](line_chart.png)

### **Créer des graphiques en carte d’arbres**

Les graphiques en carte d’arbres sont idéaux pour les données de vente lorsqu’il s’agit de montrer la taille relative des catégories et d’attirer rapidement l’attention sur les éléments qui contribuent fortement au sein de chaque catégorie.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données par défaut et spécifiez le type `ChartType.Treemap`.
1. Accédez au classeur de données du graphique ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Supprimez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique en carte d’arbres :
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Branche 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Branche 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique en carte d’arbres](treemap_chart.png)

### **Créer des graphiques boursiers**

Les graphiques boursiers affichent des données financières telles que les cours d’ouverture, haut, bas et clôture, aidant à analyser les tendances du marché et la volatilité. Ils offrent des informations essentielles sur la performance des actions, aidant investisseurs et analystes à prendre des décisions éclairées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données par défaut et spécifiez le type `ChartType.OpenHighLowClose`.
1. Accédez au classeur de données du graphique ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Supprimez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries.
1. Spécifiez le format des HiLowLines.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique boursier :
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique boursier](stock_chart.png)

### **Créer des graphiques à boîte et moustaches**

Les graphiques à boîte et moustaches affichent la distribution des données en résumant les mesures statistiques clés, telles que la médiane, les quartiles et les valeurs aberrantes potentielles. Ils sont particulièrement utiles en analyse exploratoire de données et en études statistiques pour comprendre rapidement la variabilité des données et identifier d’éventuelles anomalies.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données par défaut et spécifiez le type `ChartType.BoxAndWhisker`.
1. Accédez au classeur de données du graphique ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Supprimez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique à boîte et moustaches :
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```


### **Créer des graphiques en entonnoir**

Les graphiques en entonnoir visualisent des processus comportant plusieurs étapes séquentielles, où le volume de données diminue d’une étape à l’autre. Ils sont particulièrement utiles pour analyser les taux de conversion, identifier les goulots d’étranglement et suivre l’efficacité des processus de vente ou de marketing.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données par défaut et spécifiez le type `ChartType.Funnel`.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique en entonnoir :
```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique en entonnoir](funnel_chart.png)

### **Créer des graphiques en acrylique**

Les graphiques en acrylique visualisent des données hiérarchiques, affichant les niveaux sous forme d’anneaux concentriques. Ils aident à illustrer les relations partie‑à‑tout et sont idéaux pour représenter des catégories imbriquées de manière claire et compacte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données par défaut et spécifiez le type `ChartType.Sunburst`.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique en acrylique :
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Branche 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Branche 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique en acrylique](sunburst_chart.png)

### **Créer des histogrammes**

Les histogrammes représentent la distribution de données numériques en regroupant les valeurs en intervalles ou « bins ». Ils sont utiles pour identifier des motifs tels que la fréquence, l’asymétrie et la dispersion, ainsi que pour détecter les valeurs aberrantes dans un jeu de données.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données et spécifiez le type `ChartType.Histogram`.
1. Accédez au classeur de données du graphique ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Supprimez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un histogramme :
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![L’histogramme](histogram_chart.png)

### **Créer des graphiques radar**

Les graphiques radar affichent des données multivariées sur un plan bidimensionnel, permettant de comparer facilement plusieurs variables simultanément. Ils sont utiles pour identifier les points forts, les faiblesses et les motifs à travers plusieurs indicateurs de performance ou attributs.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données et spécifiez le type `ChartType.Radar`.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique radar :
```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique radar](radar_chart.png)

### **Créer des graphiques multi‑catégories**

Les graphiques multicatégories affichent des données comportant plusieurs regroupements catégoriels, vous permettant de comparer des valeurs sur plusieurs dimensions simultanément. Ils sont utiles pour analyser les tendances et les relations au sein de jeux de données complexes et à plusieurs niveaux.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données par défaut et spécifiez le type `ChartType.ClusteredColumn`.
1. Accédez au classeur de données du graphique ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)).
1. Supprimez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment créer un graphique multicatégorie :
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Ajouter une série.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Enregistrer la présentation avec le graphique.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique multi‑catégorie](multi_category_chart.png)

### **Créer des graphiques cartographiques**

Les graphiques cartographiques visualisent des données géographiques en associant des informations à des emplacements spécifiques tels que des pays, des régions ou des villes. Ils sont utiles pour analyser les tendances régionales, les données démographiques et les distributions spatiales de manière claire et attrayante.

Ce code C# montre comment créer un graphique cartographique :
```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique cartographique](map_chart.png)

### **Créer des graphiques combinés**

Un graphique combiné (ou combo) regroupe deux types de graphiques ou plus dans un même diagramme. Ce type de graphique permet de mettre en évidence, comparer ou examiner les différences entre plusieurs ensembles de données, facilitant l’identification de leurs relations.

![Le graphique combiné](combination_chart.png)

Le code C# suivant montre comment créer le graphique combiné illustré ci‑dessus dans une présentation PowerPoint :
```c#
private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Définit le titre du graphique
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Définit la légende du graphique
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Supprime les séries et catégories générées par défaut
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Ajoute de nouvelles catégories
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Ajoute la première série
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Définit l'axe horizontal
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Définit l'axe vertical
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Définit la couleur des lignes de quadrillage majeures verticales
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Définit l'axe horizontal secondaire
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Définit l'axe vertical secondaire
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```


## **Mettre à jour les graphiques**

Aspose.Slides pour .NET vous permet de mettre à jour les graphiques PowerPoint en modifiant les données, la mise en forme et le style. Cette fonctionnalité simplifie la mise à jour des présentations avec du contenu dynamique et garantit que les graphiques reflètent avec précision les données actuelles et les normes visuelles.

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) représentant la présentation contenant le graphique.
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Parcourez toutes les formes pour trouver le graphique.
1. Accédez à la feuille de données du graphique.
1. Modifiez les séries de données du graphique en changeant les valeurs des séries.
1. Ajoutez une nouvelle série et remplissez ses données.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment mettre à jour un graphique :
```c#
const string chartName = "My chart";

// Instancier la classe Presentation qui représente un fichier PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Accéder à la première diapositive.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Définir l'index de la feuille de données du graphique.
            int worksheetIndex = 0;

            // Obtenir le classeur de données du graphique.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Modifier les noms des catégories du graphique.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Obtenir la première série du graphique.
            IChartSeries series = chart.ChartData.Series[0];

            // Mettre à jour les données de la série.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Modification du nom de la série.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Obtenir la deuxième série du graphique.
            series = chart.ChartData.Series[1];

            // Mettre à jour les données de la série.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Modification du nom de la série.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Ajouter une nouvelle série.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Remplir les données de la série.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Enregistrer la présentation avec le graphique.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```


## **Définir la plage de données d’un graphique**

Aspose.Slides pour .NET offre la flexibilité de définir une plage de données spécifique d’une feuille de calcul comme source pour les données du graphique. Cela signifie que vous pouvez mapper directement une portion de votre feuille de calcul au graphique, en contrôlant quelles cellules contribuent aux séries et aux catégories du graphique. Ainsi, vous pouvez facilement mettre à jour et synchroniser vos graphiques avec les dernières modifications de vos données, garantissant que vos présentations PowerPoint reflètent des informations actuelles et précises.

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) représentant la présentation contenant le graphique.
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Parcourez toutes les formes pour trouver le graphique.
1. Accédez aux données du graphique et définissez la plage.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code C# montre comment définir la plage de données d’un graphique :
```c#
const string chartName = "My chart";

// Instancier la classe Presentation qui représente un fichier PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Accéder à la première diapositive.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```


## **Utiliser des marqueurs par défaut dans les graphiques**

Lorsque vous utilisez des marqueurs par défaut dans les graphiques, chaque série reçoit automatiquement un symbole de marqueur différent.

Ce code C# montre comment définir automatiquement un marqueur de série :
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Remplir les données de la série.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Quels types de graphiques sont pris en charge par Aspose.Slides pour .NET ?**

Aspose.Slides pour .NET prend en charge un large éventail de types de graphiques, notamment les graphiques à barres, en ligne, circulaires, en aires, en nuage de points, histogrammes, radar et bien d’autres. Cette flexibilité vous permet de choisir le type le plus adapté à vos besoins de visualisation.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, créez d’abord une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), récupérez la diapositive souhaitée à l’aide de son indice, puis appelez la méthode d’ajout de graphique en spécifiant le type de graphique et les données initiales. Cette opération intègre le graphique directement dans votre présentation.

**Comment mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d’un graphique en accédant à son classeur de données ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)), en supprimant les séries et catégories par défaut, puis en ajoutant vos propres données. Cela vous permet de rafraîchir le graphique de manière programmatique.

**Est‑il possible de personnaliser l’apparence du graphique ?**

Oui, Aspose.Slides pour .NET offre de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les libellés, les légendes et d’autres éléments de mise en forme pour adapter l’apparence du graphique à vos exigences de conception.