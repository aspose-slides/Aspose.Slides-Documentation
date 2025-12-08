---
title: Créer ou mettre à jour des graphiques de présentation PowerPoint en JavaScript
linktitle: Créer un graphique
type: docs
weight: 10
url: /fr/nodejs-java/create-chart/
keywords: "Créer un graphique, graphique dispersé, graphique circulaire, graphique en carte arborescente, graphique boursier, graphique boîte à moustaches, graphique histogramme, graphique en entonnoir, graphique rayonnant, graphique multi‑catégorie, présentation PowerPoint, Java, Aspose.Slides pour Node.js via Java"
description: "Créer un graphique dans une présentation PowerPoint en JavaScript"
---

## **Vue d'ensemble**

Cet article décrit comment **créer des graphiques de présentation PowerPoint en Java**. Vous pouvez également **mettre à jour les graphiques en JavaScript**. Il couvre les sujets suivants.

_Chart_: **Normal**
- [Java Créer un graphique PowerPoint](#java-create-powerpoint-chart)
- [Java Créer un graphique de présentation](#java-create-presentation-chart)
- [Java Créer un graphique de présentation PowerPoint](#java-create-powerpoint-presentation-chart)

_Chart_: **Scattered**
- [Java Créer un graphique dispersé](#java-create-scattered-chart)
- [Java Créer un graphique PowerPoint dispersé](#java-create-powerpoint-scattered-chart)
- [Java Créer un graphique de présentation PowerPoint dispersé](#java-create-powerpoint-presentation-scattered-chart)

_Chart_: **Pie**
- [Java Créer un graphique circulaire](#java-create-pie-chart)
- [Java Créer un graphique PowerPoint circulaire](#java-create-powerpoint-pie-chart)
- [Java Créer un graphique de présentation PowerPoint circulaire](#java-create-powerpoint-presentation-pie-chart)

_Chart_: **Tree Map**
- [Java Créer un graphique en arbre](#java-create-tree-map-chart)
- [Java Créer un graphique PowerPoint en arbre](#java-create-powerpoint-tree-map-chart)
- [Java Créer un graphique de présentation PowerPoint en arbre](#java-create-powerpoint-presentation-tree-map-chart)

_Chart_: **Stock**
- [Java Créer un graphique boursier](#java-create-stock-chart)
- [Java Créer un graphique PowerPoint boursier](#java-create-powerpoint-stock-chart)
- [Java Créer un graphique de présentation PowerPoint boursier](#java-create-powerpoint-presentation-stock-chart)

_Chart_: **Box and Whisker**
- [Java Créer un graphique boîte à moustaches](#java-create-box-and-whisker-chart)
- [Java Créer un graphique PowerPoint boîte à moustaches](#java-create-powerpoint-box-and-whisker-chart)
- [Java Créer un graphique de présentation PowerPoint boîte à moustaches](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Chart_: **Funnel**
- [Java Créer un graphique en entonnoir](#java-create-funnel-chart)
- [Java Créer un graphique PowerPoint en entonnoir](#java-create-powerpoint-funnel-chart)
- [Java Créer un graphique de présentation PowerPoint en entonnoir](#java-create-powerpoint-presentation-funnel-chart)

_Chart_: **Sunburst**
- [Java Créer un graphique rayonnant](#java-create-sunburst-chart)
- [Java Créer un graphique PowerPoint rayonnant](#java-create-powerpoint-sunburst-chart)
- [Java Créer un graphique de présentation PowerPoint rayonnant](#java-create-powerpoint-presentation-sunburst-chart)

_Chart_: **Histogram**
- [Java Créer un histogramme](#java-create-histogram-chart)
- [Java Créer un histogramme PowerPoint](#java-create-powerpoint-histogram-chart)
- [Java Créer un histogramme de présentation PowerPoint](#java-create-powerpoint-presentation-histogram-chart)

_Chart_: **Radar**
- [Java Créer un graphique radar](#java-create-radar-chart)
- [Java Créer un graphique PowerPoint radar](#java-create-powerpoint-radar-chart)
- [Java Créer un graphique de présentation PowerPoint radar](#java-create-powerpoint-presentation-radar-chart)

_Chart_: **Multi Category**
- [Java Créer un graphique multi-catégorie](#java-create-multi-category-chart)
- [Java Créer un graphique PowerPoint multi-catégorie](#java-create-powerpoint-multi-category-chart)
- [Java Créer un graphique de présentation PowerPoint multi-catégorie](#java-create-powerpoint-presentation-multi-category-chart)

_Chart_: **Map**
- [Java Créer un graphique cartographique](#java-create-map-chart)
- [Java Créer un graphique PowerPoint cartographique](#java-create-powerpoint-map-chart)
- [Java Créer un graphique de présentation PowerPoint cartographique](#java-create-powerpoint-presentation-map-chart)

_Action_: **Update Chart**
- [Java Mettre à jour le graphique PowerPoint](#java-update-powerpoint-chart)
- [Java Mettre à jour le graphique de présentation](#java-update-presentation-chart)
- [Java Mettre à jour le graphique de présentation PowerPoint](#java-update-powerpoint-presentation-chart)


## **Créer un graphique**
Les graphiques aident les gens à visualiser rapidement les données et à en tirer des enseignements, ce qui n’est pas toujours évident à partir d’un tableau ou d’une feuille de calcul. 


**Pourquoi créer des graphiques ?**

Avec les graphiques, vous pouvez :

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d’une présentation
* mettre en évidence des modèles et des tendances dans les données
* déduire la direction et l’élan des données au fil du temps ou par rapport à une unité de mesure spécifique 
* repérer les valeurs aberrantes, les anomalies, les écarts, les erreurs, les données incohérentes, etc. 
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques via la fonction Insérer, qui propose des modèles pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer des graphiques classiques (basés sur les types de graphiques courants) ainsi que des graphiques personnalisés. 

{{% alert color="primary" %}} 

Pour vous permettre de créer des graphiques, Aspose.Slides propose la classe [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType). Les champs de cette classe correspondent aux différents types de graphiques.

{{% /alert %}} 

### **Création de graphiques normaux**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint en JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Étapes :</em> Créer un graphique de présentation en JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint en JavaScript</strong></a>

_Code Steps:_

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un graphique avec des données et indiquez le type de graphique souhaité. 
4. Ajoutez un titre au graphique. 
5. Accédez à la feuille de calcul des données du graphique.
6. Supprimez toutes les séries et catégories par défaut.
7. Ajoutez de nouvelles séries et catégories.
8. Ajoutez de nouvelles données de séries au graphique.
9. Ajoutez une couleur de remplissage pour les séries du graphique.
10. Ajoutez des étiquettes aux séries du graphique. 
11. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment créer un graphique normal :
```javascript
// Instancie une classe de présentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajoute un graphique avec ses données par défaut
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // Définit le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // Définit la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Définit l'index pour la feuille de données du graphique
    var defaultWorksheetIndex = 0;
    // Obtient la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // Ajoute de nouvelles séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Ajoute de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Prend la première série du graphique
    var series = chart.getChartData().getSeries().get_Item(0);
    // Remplit maintenant les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Prend la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1);
    // Remplit les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Crée des étiquettes personnalisées pour chaque catégorie de la nouvelle série
    // Définit la première étiquette pour afficher le nom de la catégorie
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // Affiche la valeur pour la troisième étiquette
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // Enregistre la présentation avec le graphique
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques dispersés**
Les graphiques dispersés (également appelés nuages de points ou graphes x‑y) sont souvent utilisés pour vérifier des modèles ou démontrer des corrélations entre deux variables. 

Vous pouvez choisir un graphique dispersé lorsque :

* vous avez des données numériques appariées
* vous avez 2 variables qui se combinent bien
* vous voulez déterminer si 2 variables sont liées
* vous avez une variable indépendante possédant plusieurs valeurs pour une variable dépendante

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Étapes :</em> Créer un graphique dispersé en JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint dispersé en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint dispersé en JavaScript</strong></a>

1. Veuillez suivre les étapes décrites ci‑dessus dans [Création de graphiques normaux](#creating-normal-charts)
2. Pour la troisième étape, ajoutez un graphique avec des données et choisissez le type de graphique parmi :
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Représente un graphique dispersé._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Représente un graphique dispersé relié par des courbes, avec des marqueurs de données._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Représente un graphique dispersé relié par des courbes, sans marqueurs de données._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Représente un graphique dispersé relié par des lignes, avec des marqueurs de données._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Représente un graphique dispersé relié par des lignes, sans marqueurs de données._

Ce code JavaScript montre comment créer des graphiques dispersés avec différentes séries de marqueurs :
```javascript
// Instancie une classe de présentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Crée le graphique par défaut
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // Obtient l'index de la feuille de données du graphique par défaut
    var defaultWorksheetIndex = 0;
    // Obtient la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Supprime les séries d'exemple
    chart.getChartData().getSeries().clear();
    // Ajoute de nouvelles séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // Prend la première série du graphique
    var series = chart.getChartData().getSeries().get_Item(0);
    // Ajoute un nouveau point (1:3) à la série
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // Ajoute un nouveau point (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // Modifie le type de série
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // Modifie le marqueur de la série du graphique
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // Prend la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1);
    // Ajoute un nouveau point (5:2) à cette série
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // Ajoute un nouveau point (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // Ajoute un nouveau point (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // Ajoute un nouveau point (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // Modifie le marqueur de la série du graphique
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques circulaires**

Les graphiques circulaires sont idéaux pour montrer la relation part‑à‑total dans les données, surtout lorsque les données contiennent des libellés catégoriques avec des valeurs numériques. Cependant, si vos données comportent de nombreuses parties ou libellés, envisagez d’utiliser un graphique à barres à la place.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Étapes :</em> Créer un graphique circulaire en JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint circulaire en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint circulaire en JavaScript</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Pie).
4. Accédez aux données du graphique via [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de séries au graphique.
8. Ajoutez de nouveaux points et définissez des couleurs personnalisées pour les secteurs du graphique circulaire.
9. Définissez les étiquettes des séries.
10. Ajoutez des lignes de liaison pour les étiquettes des séries.
11. Définissez l’angle de rotation des diapositives du graphique circulaire.
12. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment créer un graphique circulaire :
```javascript
// Instancie une classe de présentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var slides = pres.getSlides().get_Item(0);
    // Ajoute un graphique avec les données par défaut
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Définit le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Définit la première série pour afficher les valeurs
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Définit l'index de la feuille de données du graphique
    var defaultWorksheetIndex = 0;
    // Obtient la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Ajoute de nouvelles catégories
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Ajoute de nouvelles séries
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Remplit les données de la série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // Ne fonctionne pas dans la nouvelle version
    // Ajout de nouveaux points et définition de la couleur du secteur
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // Définit la bordure du secteur
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // Définit la bordure du secteur
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // Définit la bordure du secteur
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // Crée des étiquettes personnalisées pour chaque catégorie de la nouvelle série
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // Affiche les lignes d’accompagnement pour le graphique
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // Définit l’angle de rotation pour les secteurs du graphique circulaire
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // Enregistre la présentation avec un graphique
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques linéaires**

Les graphiques linéaires (ou graphiques en courbes) sont idéaux lorsque vous souhaitez illustrer des variations de valeur au fil du temps. Avec un graphique linéaire, vous pouvez comparer de nombreuses données simultanément, suivre les évolutions et les tendances dans le temps, mettre en évidence des anomalies dans les séries de données, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive via son indice.
1. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (dans ce cas, `ChartType.Line`).
1. Accédez aux données du graphique via IChartDataWorkbook.
1. Supprimez les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de séries au graphique.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment créer un graphique linéaire :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Par défaut, les points d’un graphique linéaire sont reliés par des lignes droites continues. Si vous souhaitez que les points soient reliés par des tirets, vous pouvez spécifier le type de tiret préféré ainsi :
```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```


### **Création de graphiques en arbre**

Les graphiques en arbre sont idéaux pour les données de ventes lorsque vous devez montrer la taille relative des catégories de données et, simultanément, attirer rapidement l’attention sur les éléments qui contribuent le plus à chaque catégorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Étapes :</em> Créer un graphique en arbre en JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint en arbre en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint en arbre en JavaScript</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).TreeMap).
4. Accédez aux données du graphique via [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de séries au graphique.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment créer un graphique en arbre :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // branche 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // branche 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques boursiers**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Étapes :</em> Créer un graphique boursier en JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint boursier en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint boursier en JavaScript</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).OpenHighLowClose).
4. Accédez aux données du graphique via [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de séries au graphique.
8. Spécifiez le format HiLowLines.
9. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Exemple de code JavaScript utilisé pour créer un graphique boursier :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques boîte à moustaches**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Étapes :</em> Créer un graphique boîte à moustaches en JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint boîte à moustaches en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint boîte à moustaches en JavaScript</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).BoxAndWhisker).
4. Accédez aux données du graphique via [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de séries au graphique.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment créer un graphique boîte à moustaches :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
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
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques en entonnoir**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Étapes :</em> Créer un graphique en entonnoir en JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint en entonnoir en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint en entonnoir en JavaScript</strong></a>


1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Funnel).
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Le code JavaScript montre comment créer un graphique en entonnoir :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques rayonnants**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Étapes :</em> Créer un graphique rayonnant en JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint rayonnant en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint rayonnant en JavaScript</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).sunburst).
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment créer un graphique rayonnant :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // branche 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // branche 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création d’histogrammes**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Étapes :</em> Créer un histogramme en JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Étapes :</em> Créer un histogramme PowerPoint en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Étapes :</em> Créer un histogramme de présentation PowerPoint en JavaScript</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son indice.
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).Histogram).
4. Accédez aux données du graphique via [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment créer un histogramme :
```javascript
var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```


### **Création de graphiques radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Étapes :</em> Créer un graphique radar en JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint radar en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint radar en JavaScript</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son indice. 
3. Ajoutez un graphique avec des données et indiquez le type de graphique souhaité (`ChartType.Radar` dans ce cas).
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment créer un graphique radar :
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques multi‑catégories**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Étapes :</em> Créer un graphique multi‑catégorie en JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint multi‑catégorie en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint multi‑catégorie en JavaScript</strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. Obtenez la référence d’une diapositive via son indice. 
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartType).ClusteredColumn).
4. Accédez aux données du graphique via [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook).
5. Supprimez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de séries au graphique.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment créer un graphique multi‑catégorie :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // Enregistrer la présentation avec le graphique
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques cartographiques**

Un graphique cartographique visualise une zone contenant des données. Les graphiques cartographiques sont idéaux pour comparer des données ou des valeurs entre différentes régions géographiques.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Étapes :</em> Créer un graphique cartographique en JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Étapes :</em> Créer un graphique PowerPoint cartographique en JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Étapes :</em> Créer un graphique de présentation PowerPoint cartographique en JavaScript</strong></a>

Ce code JavaScript montre comment créer un graphique cartographique :
```javascript
let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Création de graphiques combinés**

Un graphique combiné (ou combo) combine deux types de graphiques ou plus dans un même diagramme. Ce graphique vous permet de mettre en évidence, de comparer ou d’examiner les différences entre plusieurs jeux de données, aidant ainsi à identifier les relations entre eux.

![The combination chart](combination_chart.png)

Le code JavaScript suivant montre comment créer le graphique combiné illustré ci‑dessus dans une présentation PowerPoint :
```js
function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Définir le titre du graphique.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // Définir la légende du graphique.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // Supprimer les séries et catégories générées par défaut.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // Ajouter de nouvelles catégories.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // Ajouter la première série.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // Définir l'axe horizontal.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // Définir l'axe vertical.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // Définir la couleur des lignes de grille principales verticales.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // Définir l'axe horizontal secondaire.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Définir l'axe vertical secondaire.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```


## **Mise à jour des graphiques**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Étapes :</em> Mettre à jour le graphique PowerPoint en JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Étapes :</em> Mettre à jour le graphique de présentation en JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Étapes :</em> Mettre à jour le graphique de présentation PowerPoint en JavaScript</strong></a>

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) qui représente la présentation contenant le graphique à mettre à jour.
2. Obtenez la référence d’une diapositive en utilisant son index.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez à la feuille de calcul des données du graphique.
5. Modifiez les données des séries du graphique en changeant les valeurs des séries.
6. Ajoutez une nouvelle série et remplissez‑la de données.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment mettre à jour un graphique :
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accéder au premier slideMarker
    var sld = pres.getSlides().get_Item(0);
    // Obtenir le graphique avec les données par défaut
    var chart = sld.getShapes().get_Item(0);
    // Définir l'index de la feuille de données du graphique
    var defaultWorksheetIndex = 0;
    // Récupérer la feuille de calcul des données du graphique
    var fact = chart.getChartData().getChartDataWorkbook();
    // Modifier le nom de la catégorie du graphique
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // Prendre la première série du graphique
    var series = chart.getChartData().getSeries().get_Item(0);
    // Mettre à jour les données de la série
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// Modifier le nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // Prendre la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1);
    // Mettre à jour les données de la série
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// Modifier le nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // Ajouter une nouvelle série maintenant
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // Prendre la troisième série du graphique
    series = chart.getChartData().getSeries().get_Item(2);
    // Remplir désormais les données de la série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // Enregistrer la présentation avec le graphique
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définition de la plage de données pour les graphiques**

Pour définir la plage de données d’un graphique, procédez comme suit :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) qui représente la présentation contenant le graphique.
2. Obtenez la référence d’une diapositive via son indice.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez aux données du graphique et définissez la plage.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code JavaScript montre comment définir la plage de données d’un graphique :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Utilisation des marqueurs par défaut dans les graphiques**
Lorsque vous utilisez un marqueur par défaut dans les graphiques, chaque série de graphique reçoit automatiquement un symbole de marqueur différent.

Ce code JavaScript montre comment définir automatiquement un marqueur de série de graphique :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // Prendre la deuxième série du graphique
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // Remplissage des données de la série
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Quels types de graphiques sont pris en charge par Aspose.Slides ?**

Aspose.Slides prend en charge une large gamme de types de graphiques, notamment les graphiques à barres, en courbes, circulaires, en aires, dispersés, histogrammes, radars et bien d’autres. Cette flexibilité vous permet de choisir le type de graphique le plus adapté à vos besoins de visualisation de données.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, créez d’abord une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) , récupérez la diapositive souhaitée via son indice, puis appelez la méthode permettant d’ajouter un graphique en précisant le type de graphique et les données initiales. Cette opération intègre le graphique directement dans votre présentation.

**Comment mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d’un graphique en accédant à son classeur de données ([ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/)), en supprimant les séries et catégories par défaut, puis en ajoutant vos propres données. Cela vous permet de rafraîchir le graphique de façon programmatique avec les dernières données.

**Est‑il possible de personnaliser l’apparence du graphique ?**

Oui, Aspose.Slides offre de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les libellés, les légendes et d’autres éléments de formatage afin d’ajuster l’aspect du graphique à vos exigences de conception.
