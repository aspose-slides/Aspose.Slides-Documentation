---
title: Créer ou Mettre à Jour des Graphiques de Présentation PowerPoint en Java
linktitle: Créer un Graphique
type: docs
weight: 10
url: /fr/java/create-chart/
keywords: "Créer un graphique, graphique dispersé, graphique circulaire, graphique en carte arborescente, graphique boursier, graphique en boîte à moustaches, graphique histogramme, graphique en entonnoir, graphique en soleil, graphique multicatégorie, présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Créer un graphique dans une présentation PowerPoint en Java"
---

## Vue d'ensemble

Cet article décrit comment **créer des Graphiques de Présentation PowerPoint en Java**. Vous pouvez également **mettre à jour les graphiques en Java**. Il couvre ces sujets.

_Graphique_: **Normal**
- [Java Créer un Graphique PowerPoint](#java-create-powerpoint-chart)
- [Java Créer un Graphique de Présentation](#java-create-presentation-chart)
- [Java Créer un Graphique de Présentation PowerPoint](#java-create-powerpoint-presentation-chart)

_Graphique_: **Dispersé**
- [Java Créer un Graphique Dispersé](#java-create-scattered-chart)
- [Java Créer un Graphique Dispersé PowerPoint](#java-create-powerpoint-scattered-chart)
- [Java Créer un Graphique Dispersé de Présentation PowerPoint](#java-create-powerpoint-presentation-scattered-chart)

_Graphique_: **Circulaire**
- [Java Créer un Graphique Circulaire](#java-create-pie-chart)
- [Java Créer un Graphique Circulaire PowerPoint](#java-create-powerpoint-pie-chart)
- [Java Créer un Graphique Circulaire de Présentation PowerPoint](#java-create-powerpoint-presentation-pie-chart)

_Graphique_: **Carte Arborescente**
- [Java Créer un Graphique en Carte Arborescente](#java-create-tree-map-chart)
- [Java Créer un Graphique en Carte Arborescente PowerPoint](#java-create-powerpoint-tree-map-chart)
- [Java Créer un Graphique en Carte Arborescente de Présentation PowerPoint](#java-create-powerpoint-presentation-tree-map-chart)

_Graphique_: **Boursier**
- [Java Créer un Graphique Boursier](#java-create-stock-chart)
- [Java Créer un Graphique Boursier PowerPoint](#java-create-powerpoint-stock-chart)
- [Java Créer un Graphique Boursier de Présentation PowerPoint](#java-create-powerpoint-presentation-stock-chart)

_Graphique_: **Boîte à Moustaches**
- [Java Créer un Graphique en Boîte à Moustaches](#java-create-box-and-whisker-chart)
- [Java Créer un Graphique en Boîte à Moustaches PowerPoint](#java-create-powerpoint-box-and-whisker-chart)
- [Java Créer un Graphique en Boîte à Moustaches de Présentation PowerPoint](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Graphique_: **Entonnoir**
- [Java Créer un Graphique en Entonnoir](#java-create-funnel-chart)
- [Java Créer un Graphique en Entonnoir PowerPoint](#java-create-powerpoint-funnel-chart)
- [Java Créer un Graphique en Entonnoir de Présentation PowerPoint](#java-create-powerpoint-presentation-funnel-chart)

_Graphique_: **Soleil**
- [Java Créer un Graphique en Soleil](#java-create-sunburst-chart)
- [Java Créer un Graphique en Soleil PowerPoint](#java-create-powerpoint-sunburst-chart)
- [Java Créer un Graphique en Soleil de Présentation PowerPoint](#java-create-powerpoint-presentation-sunburst-chart)

_Graphique_: **Histogramme**
- [Java Créer un Graphique Histogramme](#java-create-histogram-chart)
- [Java Créer un Graphique Histogramme PowerPoint](#java-create-powerpoint-histogram-chart)
- [Java Créer un Graphique Histogramme de Présentation PowerPoint](#java-create-powerpoint-presentation-histogram-chart)

_Graphique_: **Radar**
- [Java Créer un Graphique Radar](#java-create-radar-chart)
- [Java Créer un Graphique Radar PowerPoint](#java-create-powerpoint-radar-chart)
- [Java Créer un Graphique Radar de Présentation PowerPoint](#java-create-powerpoint-presentation-radar-chart)

_Graphique_: **Multi Catégorie**
- [Java Créer un Graphique Multi Catégorie](#java-create-multi-category-chart)
- [Java Créer un Graphique Multi Catégorie PowerPoint](#java-create-powerpoint-multi-category-chart)
- [Java Créer un Graphique Multi Catégorie de Présentation PowerPoint](#java-create-powerpoint-presentation-multi-category-chart)

_Graphique_: **Carte**
- [Java Créer un Graphique Carte](#java-create-map-chart)
- [Java Créer un Graphique Carte PowerPoint](#java-create-powerpoint-map-chart)
- [Java Créer un Graphique Carte de Présentation PowerPoint](#java-create-powerpoint-presentation-map-chart)

_Action_: **Mettre à jour le Graphique**
- [Java Mettre à Jour le Graphique PowerPoint](#java-update-powerpoint-chart)
- [Java Mettre à Jour le Graphique de Présentation](#java-update-presentation-chart)
- [Java Mettre à Jour le Graphique de Présentation PowerPoint](#java-update-powerpoint-presentation-chart)


## **Créer un Graphique**
Les graphiques aident les gens à visualiser rapidement les données et à obtenir des informations qui peuvent ne pas être immédiatement évidentes à partir d'un tableau ou d'une feuille de calcul. 

**Pourquoi Créer des Graphiques?**

En utilisant des graphiques, vous pouvez

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d'une présentation
* exposer des motifs et des tendances dans les données
* déduire la direction et l'élan des données au fil du temps ou par rapport à une unité de mesure spécifique 
* repérer des valeurs aberrantes, des anomalies, des écarts, des erreurs, des données absurdes, etc. 
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques via la fonction d'insertion, qui fournit des modèles utilisés pour concevoir de nombreux types de graphiques. En utilisant Aspose.Slides, vous pouvez créer des graphiques réguliers (basés sur des types de graphiques populaires) et des graphiques personnalisés. 

{{% alert color="primary" %}} 

Pour vous permettre de créer des graphiques, Aspose.Slides fournit la classe [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType). Les champs de cette classe correspondent à différents types de graphiques.

{{% /alert %}} 

### **Créer des Graphiques Normaux**

_Étapes : Créer un Graphique_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Étapes :</em> Créer un Graphique PowerPoint en Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Étapes :</em> Créer un Graphique de Présentation en Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Étapes :</em> Créer un Graphique de Présentation PowerPoint en Java</strong></a>

_Étapes du Code :_

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive via son index.
3. Ajouter un graphique avec certaines données et spécifier votre type de graphique préféré. 
4. Ajouter un titre pour le graphique. 
5. Accéder à la feuille de données du graphique.
6. Effacer toutes les séries et catégories par défaut.
7. Ajouter de nouvelles séries et catégories.
8. Ajouter de nouvelles données de graphique pour les séries de graphique.
9. Ajouter une couleur de remplissage pour les séries de graphique.
10. Ajouter des étiquettes pour les séries de graphique. 
11. Écrire la présentation modifiée sous forme de fichier PPTX.

Ce code Java vous montre comment créer un graphique normal :

```java
// Instancie une classe de présentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajoute un graphique avec ses données par défaut
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Définit le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Titre d'exemple");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Définit la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Définit l'index pour la feuille de données du graphique
    int defaultWorksheetIndex = 0;
    
    // Obtient la feuille de travail des données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Ajoute de nouvelles séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Série 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Série 2"), chart.getType());
    
    // Ajoute de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Catégorie 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Catégorie 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Catégorie 3"));
    
    // Prend la première série de graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Maintenant, peupler les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Prend la deuxième série de graphique
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Populer les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // Crée des étiquettes personnalisées pour chaque catégorie pour la nouvelle série
    // Définit la première étiquette pour montrer le nom de la Catégorie
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Montre la valeur pour la troisième étiquette
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Sauvegarde la présentation avec le graphique
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques Dispersés**
Les graphiques dispersés (également appelés graphiques dispersifs ou graphiques x-y) sont souvent utilisés pour vérifier des motifs ou démontrer des corrélations entre deux variables. 

Vous pouvez vouloir utiliser un graphique dispersé lorsque 

* vous avez des données numériques appariées
* vous avez 2 variables qui s'appairent bien ensemble
* vous voulez déterminer si 2 variables sont liées
* vous avez une variable indépendante qui a plusieurs valeurs pour une variable dépendante

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Étapes :</em> Créer un Graphique Dispersé en Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Étapes :</em> Créer un Graphique Dispersé PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Étapes :</em> Créer un Graphique Dispersé de Présentation PowerPoint en Java</strong></a>

1. Veuillez suivre les étapes mentionnées ci-dessus dans [Créer des Graphiques Normaux](#creating-normal-charts)
2. Pour la troisième étape, ajoutez un graphique avec quelques données et spécifiez votre type de graphique comme l'un des suivants
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Représente un Graphique Dispersé._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Représente un Graphique Dispersé relié par des courbes, avec des marqueurs de données._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Représente un Graphique Dispersé relié par des courbes, sans marqueurs de données._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Représente un Graphique Dispersé relié par des lignes, avec des marqueurs de données._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Représente un Graphique Dispersé relié par des lignes, sans marqueurs de données._

Ce code Java vous montre comment créer un graphique dispersé avec une série de marqueurs différente : 

```java
// Instancie une classe de présentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Crée le graphique par défaut
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Obtient l'index de la feuille de données du graphique par défaut
    int defaultWorksheetIndex = 0;
    
    // Obtient la feuille de données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Supprime les séries de démo
    chart.getChartData().getSeries().clear();
    
    // Ajoute de nouvelles séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Série 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Série 2"), chart.getType());
    
    // Prend la première série de graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Ajoute un nouveau point (1:3) à la série
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Ajoute un nouveau point (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Change le type de la série
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Change le marqueur de la série de graphique
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Prend la deuxième série de graphique
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Ajoute un nouveau point (5:2) là
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Ajoute un nouveau point (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Ajoute un nouveau point (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Ajoute un nouveau point (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Change le marqueur de la série de graphique
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques Circulaires**

Les graphiques circulaires sont mieux utilisés pour montrer la relation partie-tout dans les données, surtout lorsque les données contiennent des étiquettes catégorielles avec des valeurs numériques. Cependant, si vos données contiennent de nombreuses parties ou étiquettes, vous pouvez envisager d'utiliser un graphique à barres à la place.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Étapes :</em> Créer un Graphique Circulaire en Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Étapes :</em> Créer un Graphique Circulaire PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Étapes :</em> Créer un Graphique Circulaire de Présentation PowerPoint en Java</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive par son index.
3. Ajouter un graphique avec des données par défaut avec le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Pie).
4. Accéder à la feuille de données du graphique [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries de graphique.
8. Ajouter de nouveaux points pour les graphiques et ajouter des couleurs personnalisées pour les secteurs du graphique circulaire.
9. Définir des étiquettes pour les séries.
10. Définir des lignes de liaison pour les étiquettes des séries.
11. Définir l'angle de rotation pour les secteurs du graphique circulaire.
12. Écrire la présentation modifiée dans un fichier PPTX

Ce code Java vous montre comment créer un graphique circulaire :

```java
// Instancie une classe de présentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Ajoute un graphique avec des données par défaut
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Définit le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Titre d'exemple");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Définit la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Définit l'index pour la feuille de données du graphique
    int defaultWorksheetIndex = 0;
    
    // Obtient la feuille de travail des données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Ajoute de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "Premier Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "Deuxième Trimestre"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "Troisième Trimestre"));
    
    // Ajoute de nouvelles séries
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Série 1"), chart.getType());
    
    // Popule les données de la série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Ne fonctionne pas dans la nouvelle version
    // Ajouter de nouveaux points et définir la couleur du secteur
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Définit la bordure du Secteur
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Définit la bordure du Secteur
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Définit la bordure du Secteur
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Crée des étiquettes personnalisées pour chaque catégorie pour la nouvelle série
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // Montre les Lignes de Liaison pour le Graphique
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Définit l'Angle de Rotation pour les Secteurs du Graphique Circulaire
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Sauvegarde la présentation avec un graphique
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques en Ligne**

Les graphiques en ligne (également connus sous le nom de graphiques linéaires) sont mieux utilisés dans des situations où vous souhaitez démontrer des changements de valeur au fil du temps. En utilisant un graphique en ligne, vous pouvez comparer beaucoup de données à la fois, suivre les changements et les tendances au fil du temps, mettre en évidence les anomalies dans les séries de données, etc.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenir la référence d'une diapositive via son index.
1. Ajouter un graphique avec des données par défaut avec le type désiré (dans ce cas, `ChartType.Line`).
1. Accéder aux données du graphique IChartDataWorkbook.
1. Effacer les séries et catégories par défaut.
1. Ajouter de nouvelles séries et catégories.
1. Ajouter de nouvelles données de graphique pour les séries de graphique.
1. Écrire la présentation modifiée dans un fichier PPTX

Ce code Java vous montre comment créer un graphique en ligne :

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Par défaut, les points sur un graphique en ligne sont reliés par des lignes continues droites. Si vous voulez que les points soient reliés par des tirets à la place, vous pouvez spécifier votre type de tiret préféré de cette manière :

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **Créer des Graphiques en Carte Arborescente**

Les graphiques en carte arborescente sont mieux utilisés pour les données de vente lorsque vous souhaitez montrer la taille relative des catégories de données et (en même temps) attirer rapidement l'attention sur les éléments qui contribuent beaucoup à chaque catégorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Étapes :</em> Créer un Graphique en Carte Arborescente en Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Étapes :</em> Créer un Graphique en Carte Arborescente PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Étapes :</em> Créer un Graphique en Carte Arborescente de Présentation PowerPoint en Java</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtenir la référence d'une diapositive via son index.
3. Ajouter un graphique avec des données par défaut avec le type désiré (dans ce cas, [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).TreeMap).
4. Accéder à la feuille de données du graphique [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries de graphique.
8. Écrire la présentation modifiée dans un fichier PPTX

Ce code Java vous montre comment créer un graphique en carte arborescente :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //branche 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Feuille1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tige1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branche1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Feuille2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Feuille3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tige2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Feuille4"));

    //branche 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Feuille5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tige3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branche2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Feuille6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Feuille7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tige4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Feuille8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques Boursiers**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Étapes :</em> Créer un Graphique Boursier en Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Étapes :</em> Créer un Graphique Boursier PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Étapes :</em> Créer un Graphique Boursier de Présentation PowerPoint en Java</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtenir la référence d'une diapositive par son index.
3. Ajouter un graphique avec des données par défaut avec le type désigné ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. Accéder à la feuille de données du graphique [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries de graphique.
8. Spécifier le format des lignes hautes/basses.
9. Écrire la présentation modifiée dans un fichier PPTX

Un code Java exemple utilisé pour créer un graphique boursier :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Ouvert"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "Haut"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Bas"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Fermé"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));

    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));

    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));

    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques en Boîte à Moustaches**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Étapes :</em> Créer un Graphique en Boîte à Moustaches en Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Étapes :</em> Créer un Graphique en Boîte à Moustaches PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Étapes :</em> Créer un Graphique en Boîte à Moustaches de Présentation PowerPoint en Java</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtenir la référence d'une diapositive via son index.
3. Ajouter un graphique avec des données par défaut avec le type désiré ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. Accéder à la feuille de données du graphique [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries de graphique.
8. Écrire la présentation modifiée dans un fichier PPTX

Ce code Java vous montre comment créer un graphique en boîte à moustaches :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", 15));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", 41));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", 16));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", 10));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", 23));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", 16));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques en Entonnoir**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Étapes :</em> Créer un Graphique en Entonnoir en Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Étapes :</em> Créer un Graphique en Entonnoir PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Étapes :</em> Créer un Graphique en Entonnoir de Présentation PowerPoint en Java</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtenir la référence d'une diapositive via son index.
3. Ajouter un graphique avec des données par défaut avec le type désiré ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Funnel).
4. Écrire la présentation modifiée dans un fichier PPTX

Le code Java vous montre comment créer un graphique en entonnoir :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Catégorie 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Catégorie 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Catégorie 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Catégorie 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Catégorie 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Catégorie 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques en Soleil**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Étapes :</em> Créer un Graphique en Soleil en Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Étapes :</em> Créer un Graphique en Soleil PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Étapes :</em> Créer un Graphique en Soleil de Présentation PowerPoint en Java</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtenir la référence d'une diapositive via son index.
3. Ajouter un graphique avec des données par défaut avec le type désiré (dans ce cas,[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).sunburst).
4. Écrire la présentation modifiée dans un fichier PPTX

Ce code Java vous montre comment créer un graphique en soleil :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //branche 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Feuille1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tige1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branche1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Feuille2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Feuille3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tige2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Feuille4"));

    //branche 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Feuille5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tige3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branche2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Feuille6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Feuille7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Tige4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Feuille8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques Histogrammes**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Étapes :</em> Créer un Graphique Histogramme en Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Étapes :</em> Créer un Graphique Histogramme PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Étapes :</em> Créer un Graphique Histogramme de Présentation PowerPoint en Java</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtenir la référence d'une diapositive via son index.
3. Ajouter un graphique avec des données par défaut avec le type désiré ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Histogram).
4. Accéder à la feuille de données [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Écrire la présentation modifiée dans un fichier PPTX

Ce code Java vous montre comment créer un graphique histogramme :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques Radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Étapes :</em> Créer un Graphique Radar en Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Étapes :</em> Créer un Graphique Radar PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Étapes :</em> Créer un Graphique Radar de Présentation PowerPoint en Java</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtenir la référence d'une diapositive via son index. 
3. Ajouter un graphique avec des données et spécifier votre type de graphique préféré (`ChartType.Radar` dans ce cas).
4. Écrire la présentation modifiée dans un fichier PPTX

Ce code Java vous montre comment créer un graphique radar :

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques Multi Catégorie**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Étapes :</em> Créer un Graphique Multi Catégorie en Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Étapes :</em> Créer un Graphique Multi Catégorie PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Étapes :</em> Créer un Graphique Multi Catégorie de Présentation PowerPoint en Java</strong></a>

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Obtenir la référence d'une diapositive via son index. 
3. Ajouter un graphique avec des données par défaut avec le type désiré ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).ClusteredColumn).
4. Accéder à la feuille de données [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries de graphique.
8. Écrire la présentation modifiée dans un fichier PPTX.

Ce code Java vous montre comment créer un graphique multicatégorie :

```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Groupe1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Groupe2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Groupe3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Groupe4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // Ajout de Séries
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Série 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Sauvegarde la présentation avec le graphique
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques Carte**

Un graphique carte est une visualisation d'une zone contenant des données. Les graphiques carte sont mieux utilisés pour comparer des données ou des valeurs à travers des régions géographiques.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Étapes :</em> Créer un Graphique Carte en Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Étapes :</em> Créer un Graphique Carte PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Étapes :</em> Créer un Graphique Carte de Présentation PowerPoint en Java</strong></a>

Ce code Java vous montre comment créer un graphique carte :

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Créer des Graphiques en Combinaison**

Un graphique combiné (ou combiné) est un graphique qui combine deux ou plusieurs graphiques sur un seul graphique. Un tel graphique vous permet de mettre en évidence, de comparer ou d'examiner les différences entre deux (ou plusieurs) ensembles de données. Cette façon, vous voyez la relation (s'il y en a) entre les ensembles de données. 

![combination-chart-ppt](combination-chart-ppt.png)

Ce code Java vous montre comment créer un graphique combiné dans PowerPoint :

```java
private static void createComboChart()
{
    Presentation pres = new Presentation();
    {
        IChart chart = createChart(pres.getSlides().get_Item(0));
        addFirstSeriesToChart(chart);
        addSecondSeriesToChart(chart);
        pres.save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart createChart(ISlide slide)
{
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 1, "Série 1"), chart.getType());
    chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 2, "Série 2"), chart.getType());

    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Catégorie 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Catégorie 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Catégorie 3"));

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 30));

    series = chart.getChartData().getSeries().get_Item(1);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 60));

    return chart;
}

private static void addFirstSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 3, "Série 3"), ChartType.ScatterWithSmoothLines);

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 0, 1, 3),
            workbook.getCell(worksheetIndex, 0, 2, 5));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 3, 10),
            workbook.getCell(worksheetIndex, 1, 4, 13));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 2, 3, 20),
            workbook.getCell(worksheetIndex, 2, 4, 15));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 3, 3, 12),
            workbook.getCell(worksheetIndex, 3, 4, 9));

    series.setPlotOnSecondAxis(true);
}

private static void addSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartSeries series = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, 0, 5, "Série 4"),
            ChartType.ScatterWithStraightLinesAndMarkers);

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 3, 5),
            workbook.getCell(worksheetIndex, 1, 4, 2));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 1, 5, 10),
            workbook.getCell(worksheetIndex, 1, 6, 7));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 2, 5, 15),
            workbook.getCell(worksheetIndex, 2, 6, 12));

    series.getDataPoints().addDataPointForScatterSeries(
            workbook.getCell(worksheetIndex, 3, 5, 12),
            workbook.getCell(worksheetIndex, 3, 6, 9));

    series.setPlotOnSecondAxis(true);
}
```

## **Mettre à Jour les Graphiques**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Étapes :</em> Mettre à Jour le Graphique PowerPoint en Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Étapes :</em> Mettre à Jour le Graphique de Présentation</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Étapes :</em> Mettre à Jour le Graphique de Présentation PowerPoint en Java</strong></a>

1. Instancier une classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui représente la présentation contenant le graphique que vous souhaitez mettre à jour. 
2. Obtenir la référence d'une diapositive en utilisant son index.
3. Parcourir toutes les formes pour trouver le graphique désiré.
4. Accéder à la feuille de données du graphique.
5. Modifier les données des séries de graphiques en changeant les valeurs des séries.
6. Ajouter une nouvelle série et remplir les données dans celle-ci.
7. Écrire la présentation modifiée sous forme de fichier PPTX.

Ce code Java vous montre comment mettre à jour un graphique :

```java
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Obtient le graphique avec des données par défaut
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Définit l'index de la feuille de données du graphique
    int defaultWorksheetIndex = 0;

    // Obtient la feuille de travail des données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Changer le nom de la Catégorie du graphique
    fact.getCell(defaultWorksheetIndex, 1, 0, "Catégorie Modifiée 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Catégorie Modifiée 2");

    // Prend la première série de graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Maintenant mise à jour des données de la série
    fact.getCell(defaultWorksheetIndex, 0, 1, "Nouvelle_Série1");// Modifier le nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Prend la deuxième série de graphique
    series = chart.getChartData().getSeries().get_Item(1);

    // Maintenant mise à jour des données de la série
    fact.getCell(defaultWorksheetIndex, 0, 2, "Nouvelle_Série2");// Modifier le nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Maintenant, ajout d'une nouvelle série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Série 3"), chart.getType());

    // Prend la 3ème série de graphique
    series = chart.getChartData().getSeries().get_Item(2);

    // Maintenant peupler les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Sauvegarder la présentation avec le graphique
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la Plage de Données pour les Graphiques**

Pour définir la plage de données pour un graphique, procédez comme suit :

1. Instancier une classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui représente la présentation contenant le graphique.
2. Obtenir la référence d'une diapositive via son index.
3. Parcourir toutes les formes pour trouver le graphique désiré.
4. Accéder aux données du graphique et définir la plage.
5. Sauvegarder la présentation modifiée sous forme de fichier PPTX.

Ce code Java vous montre comment définir la plage de données pour un graphique :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Feuille1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Utiliser des Marqueurs Par Défaut dans les Graphiques**
Lorsque vous utilisez un marqueur par défaut dans les graphiques, chaque série de graphiques obtient automatiquement des symboles de marqueurs par défaut différents.

Ce code Java vous montre comment définir un marqueur de série de graphique automatiquement :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Série 1"), chart.get