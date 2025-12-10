---
title: Créer ou mettre à jour des graphiques de présentation PowerPoint en Java
linktitle: Créer ou mettre à jour des graphiques
type: docs
weight: 10
url: /fr/java/create-chart/
keywords:
- ajouter un graphique
- créer un graphique
- modifier un graphique
- changer un graphique
- mettre à jour le graphique
- graphique dispersé
- graphique en secteurs
- graphique en lignes
- graphique arborescent
- graphique de cours
- graphique boîte à moustaches
- graphique entonnoir
- graphique rayonnant
- histogramme
- graphique radar
- graphique multicatégorie
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Créer et personnaliser des graphiques dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Java. Ajouter, formater et modifier des graphiques avec des exemples de code pratiques en Java."
---

## Vue d'ensemble

Cet article décrit comment **créer des graphiques de présentation PowerPoint en Java**. Vous pouvez également **mettre à jour les graphiques en Java**. Il couvre les sujets suivants.

_Chart_: **Normal**
- [Créer un graphique PowerPoint en Java](#java-create-powerpoint-chart)
- [Créer un graphique de présentation en Java](#java-create-presentation-chart)
- [Créer un graphique de présentation PowerPoint en Java](#java-create-powerpoint-presentation-chart)

_Chart_: **Scattered**
- [Créer un graphique dispersé en Java](#java-create-scattered-chart)
- [Créer un graphique dispersé PowerPoint en Java](#java-create-powerpoint-scattered-chart)
- [Créer un graphique dispersé de présentation PowerPoint en Java](#java-create-powerpoint-presentation-scattered-chart)

_Chart_: **Pie**
- [Créer un graphique en secteurs en Java](#java-create-pie-chart)
- [Créer un graphique en secteurs PowerPoint en Java](#java-create-powerpoint-pie-chart)
- [Créer un graphique en secteurs de présentation PowerPoint en Java](#java-create-powerpoint-presentation-pie-chart)

_Chart_: **Tree Map**
- [Créer un graphique arborescent en Java](#java-create-tree-map-chart)
- [Créer un graphique arborescent PowerPoint en Java](#java-create-powerpoint-tree-map-chart)
- [Créer un graphique arborescent de présentation PowerPoint en Java](#java-create-powerpoint-presentation-tree-map-chart)

_Chart_: **Stock**
- [Créer un graphique de cours en Java](#java-create-stock-chart)
- [Créer un graphique de cours PowerPoint en Java](#java-create-powerpoint-stock-chart)
- [Créer un graphique de cours de présentation PowerPoint en Java](#java-create-powerpoint-presentation-stock-chart)

_Chart_: **Box and Whisker**
- [Créer un graphique boîte à moustaches en Java](#java-create-box-and-whisker-chart)
- [Créer un graphique boîte à moustaches PowerPoint en Java](#java-create-powerpoint-box-and-whisker-chart)
- [Créer un graphique boîte à moustaches de présentation PowerPoint en Java](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Chart_: **Funnel**
- [Créer un graphique entonnoir en Java](#java-create-funnel-chart)
- [Créer un graphique entonnoir PowerPoint en Java](#java-create-powerpoint-funnel-chart)
- [Créer un graphique entonnoir de présentation PowerPoint en Java](#java-create-powerpoint-presentation-funnel-chart)

_Chart_: **Sunburst**
- [Créer un graphique rayonnant en Java](#java-create-sunburst-chart)
- [Créer un graphique rayonnant PowerPoint en Java](#java-create-powerpoint-sunburst-chart)
- [Créer un graphique rayonnant de présentation PowerPoint en Java](#java-create-powerpoint-presentation-sunburst-chart)

_Chart_: **Histogram**
- [Créer un histogramme en Java](#java-create-histogram-chart)
- [Créer un histogramme PowerPoint en Java](#java-create-powerpoint-histogram-chart)
- [Créer un histogramme de présentation PowerPoint en Java](#java-create-powerpoint-presentation-histogram-chart)

_Chart_: **Radar**
- [Créer un graphique radar en Java](#java-create-radar-chart)
- [Créer un graphique radar PowerPoint en Java](#java-create-powerpoint-radar-chart)
- [Créer un graphique radar de présentation PowerPoint en Java](#java-create-powerpoint-presentation-radar-chart)

_Chart_: **Multi Category**
- [Créer un graphique multi-catégorie en Java](#java-create-multi-category-chart)
- [Créer un graphique multi-catégorie PowerPoint en Java](#java-create-powerpoint-multi-category-chart)
- [Créer un graphique multi-catégorie de présentation PowerPoint en Java](#java-create-powerpoint-presentation-multi-category-chart)

_Chart_: **Map**
- [Créer un graphique cartographique en Java](#java-create-map-chart)
- [Créer un graphique cartographique PowerPoint en Java](#java-create-powerpoint-map-chart)
- [Créer un graphique cartographique de présentation PowerPoint en Java](#java-create-powerpoint-presentation-map-chart)

_Action_: **Update Chart**
- [Mettre à jour un graphique PowerPoint en Java](#java-update-powerpoint-chart)
- [Mettre à jour un graphique de présentation en Java](#java-update-presentation-chart)
- [Mettre à jour un graphique de présentation PowerPoint en Java](#java-update-powerpoint-presentation-chart)


## **Créer des graphiques**
Les graphiques aident les utilisateurs à visualiser rapidement les données et à en tirer des informations, ce qui peut ne pas être immédiatement évident à partir d’un tableau ou d’une feuille de calcul. 


**Pourquoi créer des graphiques ?**

Avec les graphiques, vous pouvez :

* regrouper, condenser ou résumer de grandes quantités de données sur une seule diapositive d’une présentation
* révéler des motifs et des tendances dans les données
* déduire la direction et l’élan des données dans le temps ou par rapport à une unité de mesure spécifique 
* repérer des valeurs aberrantes, des anomalies, des écarts, des erreurs, des données non sensées, etc. 
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques via la fonction d’insertion, qui fournit des modèles utilisés pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer des graphiques standards (basés sur des types de graphiques populaires) et des graphiques personnalisés. 

{{% alert color="primary" %}} 

Pour vous permettre de créer des graphiques, Aspose.Slides fournit la classe [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType). Les champs de cette classe correspondent aux différents types de graphiques. 

{{% /alert %}} 

### **Créer des graphiques normaux**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint en Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Étapes :</em> Créer un graphique de présentation en Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint en Java</strong></a>

_Code Steps:_

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un graphique avec des données et indiquez le type de graphique souhaité. 
4. Ajoutez un titre au graphique. 
5. Accédez à la feuille de données du graphique. 
6. Supprimez toutes les séries et catégories par défaut. 
7. Ajoutez de nouvelles séries et catégories. 
8. Ajoutez de nouvelles données au graphique pour les séries. 
9. Ajoutez une couleur de remplissage pour les séries. 
10. Ajoutez des libellés pour les séries. 
11. Enregistrez la présentation modifiée sous forme de fichier PPTX. 

Ce code Java montre comment créer un graphique normal :
```java
// Instancie une classe de présentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajoute un graphique avec ses données par défaut
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // Définit le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // Définit la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Définit l'index pour la feuille de données du graphique
    int defaultWorksheetIndex = 0;
    
    // Obtient la feuille de calcul des données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // Ajoute de nouvelles séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // Ajoute de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Récupère la première série du graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Remplit maintenant les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // Récupère la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Remplit les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //Crée des libellés personnalisés pour chaque catégorie de la nouvelle série
    // Définit le premier libellé pour afficher le nom de catégorie
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // Affiche la valeur pour le troisième libellé
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // Enregistre la présentation avec le graphique
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Créer des graphiques dispersés**
Les graphiques dispersés (également appelés nuages de points ou graphiques x‑y) sont souvent utilisés pour vérifier des motifs ou démontrer des corrélations entre deux variables. 

Vous pouvez choisir un graphique dispersé lorsque 

* vous avez des données numériques appariées
* vous avez deux variables qui se combinent bien
* vous voulez déterminer si deux variables sont liées
* vous avez une variable indépendante comportant plusieurs valeurs pour une variable dépendante

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Étapes :</em> Créer un graphique dispersé en Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Étapes :</em> Créer un graphique dispersé PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Étapes :</em> Créer un graphique dispersé de présentation PowerPoint en Java</strong></a>

1. Veuillez suivre les étapes indiquées ci‑dessus dans [Créer des graphiques normaux](#creating-normal-charts)
2. Pour la troisième étape, ajoutez un graphique avec des données et indiquez le type de graphique parmi les suivants :
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _Représente un graphique dispersé avec marqueurs._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Représente un graphique dispersé relié par des courbes, avec des marqueurs._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Représente un graphique dispersé relié par des courbes, sans marqueurs._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Représente un graphique dispersé relié par des lignes droites, avec des marqueurs._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Représente un graphique dispersé relié par des lignes droites, sans marqueurs._

Ce code Java montre comment créer des graphiques dispersés avec différentes séries de marqueurs : 
```java
// Instancie une classe de présentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Crée le graphique par défaut
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // Obtient l'indice de la feuille de données du graphique par défaut
    int defaultWorksheetIndex = 0;
    
    // Obtient la feuille de données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Supprime les séries de démonstration
    chart.getChartData().getSeries().clear();
    
    // Ajoute de nouvelles séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // Prend la première série du graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Ajoute un nouveau point (1:3) à la série
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // Ajoute un nouveau point (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // Change le type de la série
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // Change le marqueur de la série du graphique
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // Prend la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1);
    
    // Ajoute un nouveau point (5:2) là
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // Ajoute un nouveau point (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // Ajoute un nouveau point (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // Ajoute un nouveau point (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // Change le marqueur de la série du graphique
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Créer des graphiques en secteurs**

Les graphiques en secteurs sont idéaux pour montrer la relation partie‑toute dans les données, surtout lorsque les données contiennent des libellés catégoriques avec des valeurs numériques. Toutefois, si vos données comportent de nombreuses parties ou libellés, envisagez d’utiliser un graphique à barres à la place.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Étapes :</em> Créer un graphique en secteurs en Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Étapes :</em> Créer un graphique en secteurs PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Étapes :</em> Créer un graphique en secteurs de présentation PowerPoint en Java</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Pie).
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données au graphique pour les séries.
8. Ajoutez de nouveaux points au graphique et définissez des couleurs personnalisées pour les secteurs du graphique en secteurs.
9. Définissez les libellés pour les séries.
10. Définissez les traits de leader pour les libellés de séries.
11. Définissez l’angle de rotation des diapositives du graphique en secteurs.
12. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un graphique en secteurs :
```java
// Instancie une classe de présentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slides = pres.getSlides().get_Item(0);
    
    // Ajoute un graphique avec les données par défaut
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // Définit le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // Définit la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // Définit l'index pour la feuille de données du graphique
    int defaultWorksheetIndex = 0;
    
    // Obtient la feuille de calcul des données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // Ajoute de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // Ajoute de nouvelles séries
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //Remplit les données de la série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // Ne fonctionne pas dans la nouvelle version
    // Ajout de nouveaux points et définition de la couleur du secteur
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // Définit la bordure du secteur
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // Définit la bordure du secteur
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // Définit la bordure du secteur
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // Crée des libellés personnalisés pour chaque catégorie de la nouvelle série
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
    
    // Affiche les lignes meneuses pour le graphique
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // Définit l'angle de rotation pour les secteurs du graphique circulaire
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // Enregistre la présentation avec un graphique
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Créer des graphiques en lignes**

Les graphiques en lignes (également appelés graphiques linéaires) sont idéaux lorsqu’il s’agit de montrer des variations de valeur au fil du temps. Avec un graphique en lignes, vous pouvez comparer de nombreuses données simultanément, suivre les changements et les tendances dans le temps, mettre en évidence des anomalies dans les séries de données, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive via son index.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.Line`).
1. Accédez aux données du graphique via IChartDataWorkbook.
1. Supprimez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données au graphique pour les séries.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un graphique en lignes :
```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Par défaut, les points d’un graphique en lignes sont reliés par des lignes continues droites. Si vous voulez que les points soient reliés par des tirets, indiquez le type de tiret souhaité ainsi :
```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```


### **Créer des graphiques arborescents**

Les graphiques arborescents sont idéaux pour les données de ventes lorsque vous souhaitez montrer la taille relative des catégories de données et, en même temps, attirer rapidement l’attention sur les éléments qui contribuent fortement à chaque catégorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Étapes :</em> Créer un graphique arborescent en Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Étapes :</em> Créer un graphique arborescent PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Étapes :</em> Créer un graphique arborescent de présentation PowerPoint en Java</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).TreeMap).
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données au graphique pour les séries.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un graphique arborescent :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //branche 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //branche 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

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


### **Créer des graphiques de cours**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Étapes :</em> Créer un graphique de cours en Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Étapes :</em> Créer un graphique de cours PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Étapes :</em> Créer un graphique de cours de présentation PowerPoint en Java</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).OpenHighLowClose).
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données au graphique pour les séries.
8. Spécifiez le format HiLowLines.
9. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Exemple de code Java utilisé pour créer un graphique de cours :
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

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

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


### **Créer des graphiques boîte à moustaches**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Étapes :</em> Créer un graphique boîte à moustaches en Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Étapes :</em> Créer un graphique boîte à moustaches PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Étapes :</em> Créer un graphique boîte à moustaches de présentation PowerPoint en Java</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).BoxAndWhisker).
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données au graphique pour les séries.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un graphique boîte à moustaches :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

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


### **Créer des graphiques en entonnoir**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Étapes :</em> Créer un graphique en entonnoir en Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Étapes :</em> Créer un graphique en entonnoir PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Étapes :</em> Créer un graphique en entonnoir de présentation PowerPoint en Java</strong></a>


1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Funnel).
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Le code Java montre comment créer un graphique en entonnoir :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

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


### **Créer des graphiques rayonnants**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Étapes :</em> Créer un graphique rayonnant en Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Étapes :</em> Créer un graphique rayonnant PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Étapes :</em> Créer un graphique rayonnant de présentation PowerPoint en Java</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).sunburst).
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un graphique rayonnant :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //branche 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //branche 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

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


### **Créer des histogrammes**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Étapes :</em> Créer un histogramme en Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Étapes :</em> Créer un histogramme PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Étapes :</em> Créer un histogramme de présentation PowerPoint en Java</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).Histogram).
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un histogramme :
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


### **Créer des graphiques radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Étapes :</em> Créer un graphique radar en Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Étapes :</em> Créer un graphique radar PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Étapes :</em> Créer un graphique radar de présentation PowerPoint en Java</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son index. 
3. Ajoutez un graphique avec des données et indiquez le type de graphique souhaité (`ChartType.Radar` dans ce cas).
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un graphique radar :
```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Créer des graphiques multi‑catégorie**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Étapes :</em> Créer un graphique multi‑catégorie en Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Étapes :</em> Créer un graphique multi‑catégorie PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Étapes :</em> Créer un graphique multi‑catégorie de présentation PowerPoint en Java</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son index. 
3. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/ChartType).ClusteredColumn).
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données au graphique pour les séries.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment créer un graphique multi‑catégorie :
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
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // Ajout de séries
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // Enregistrer la présentation avec le graphique
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Créer des graphiques cartographiques**

Un graphique cartographique visualise une zone contenant des données. Les graphiques cartographiques sont idéaux pour comparer des données ou des valeurs selon des régions géographiques.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Étapes :</em> Créer un graphique cartographique en Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Étapes :</em> Créer un graphique cartographique PowerPoint en Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Étapes :</em> Créer un graphique cartographique de présentation PowerPoint en Java</strong></a>

Ce code Java montre comment créer un graphique cartographique :
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Créer des graphiques combinés**

Un graphique combiné (ou graphique combo) combine deux types de graphiques ou plus dans un même diagramme. Ce type de graphique vous permet de mettre en évidence, de comparer ou d’examiner les différences entre deux ensembles de données ou plus, aidant à identifier les relations entre eux.

![The combination chart](combination_chart.png)

Le code Java suivant montre comment créer le graphique combiné illustré ci‑dessus dans une présentation PowerPoint :
```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Définir le titre du graphique.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // Définir la légende du graphique.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // Supprimer les séries et catégories générées par défaut.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // Ajouter de nouvelles catégories.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Ajouter la première série.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // Définir l'axe horizontal.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // Définir l'axe vertical.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Définir la couleur des lignes de grille majeures verticales.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // Définir l'axe horizontal secondaire.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // Définir l'axe vertical secondaire.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```


## **Mettre à jour les graphiques**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Étapes :</em> Mettre à jour un graphique PowerPoint en Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Étapes :</em> Mettre à jour un graphique de présentation en Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Étapes :</em> Mettre à jour un graphique de présentation PowerPoint en Java</strong></a>

1. Instanciez une classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui représente la présentation contenant le graphique à mettre à jour. 
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez à la feuille de données du graphique.
5. Modifiez les données des séries du graphique en changeant les valeurs des séries.
6. Ajoutez une nouvelle série et remplissez‑la de données.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment mettre à jour un graphique :
```java
Presentation pres = new Presentation();
try {
    // Accéder au premier slideMarker
    ISlide sld = pres.getSlides().get_Item(0);

    // Obtenir le graphique avec les données par défaut
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // Définir l'index de la feuille de données du graphique
    int defaultWorksheetIndex = 0;

    // Obtenir la feuille de calcul des données du graphique
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Modifier le nom de la catégorie du graphique
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // Obtenir la première série du graphique
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Mise à jour des données de la série
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modification du nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // Obtenir la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1);

    // Mise à jour des données de la série
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modification du nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // Ajout d'une nouvelle série
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // Obtenir la troisième série du graphique
    series = chart.getChartData().getSeries().get_Item(2);

    // Population des données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // Enregistrer la présentation avec le graphique
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la plage de données d’un graphique**

Pour définir la plage de données d’un graphique, procédez comme suit :

1. Instanciez une classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) qui représente la présentation contenant le graphique.
2. Obtenez la référence d’une diapositive via son index.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez aux données du graphique et définissez la plage.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Java montre comment définir la plage de données d’un graphique :
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Utiliser des marqueurs par défaut dans les graphiques**
Lorsque vous utilisez un marqueur par défaut dans les graphiques, chaque série du graphique obtient automatiquement un symbole de marqueur différent.

Ce code Java montre comment définir automatiquement un marqueur de série de graphique :
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Obtenir la deuxième série du graphique
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // Maintenant, remplissage des données de la série
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Quels types de graphiques sont pris en charge par Aspose.Slides ?**

Aspose.Slides prend en charge un large éventail de [types de graphiques](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/), notamment les graphiques à barres, lignes, secteurs, aires, dispersés, histogrammes, radar, et bien d’autres. Cette souplesse vous permet de choisir le type de graphique le plus adapté à vos besoins de visualisation de données.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, créez d’abord une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) , récupérez la diapositive souhaitée à l’aide de son index, puis appelez la méthode d’ajout d’un graphique en indiquant le type de graphique et les données initiales. Cette procédure intègre le graphique directement dans votre présentation.

**Comment mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d’un graphique en accédant à son classeur de données ([IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)), en supprimant les séries et catégories par défaut, puis en ajoutant vos propres données personnalisées. Cela vous permet de rafraîchir le graphique avec les dernières valeurs.

**Est‑il possible de personnaliser l’apparence du graphique ?**

Oui, Aspose.Slides offre de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les libellés, les légendes et d’autres [éléments de formatage](/slides/fr/java/chart-entities/) pour adapter l’apparence du graphique à vos exigences de conception.