---
title: Créer ou mettre à jour des graphiques de présentation PowerPoint en PHP
linktitle: Créer ou mettre à jour des graphiques
type: docs
weight: 10
url: /fr/php-java/create-chart/
keywords:
- ajouter un graphique
- créer un graphique
- modifier un graphique
- changer un graphique
- mettre à jour un graphique
- graphique en dispersion
- graphique circulaire
- graphique en ligne
- graphique en carte arborescente
- graphique boursier
- graphique boîte à moustaches
- graphique entonnoir
- graphique Sunburst
- histogramme
- graphique radar
- graphique à plusieurs catégories
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer et personnaliser des graphiques dans les présentations PowerPoint en utilisant Aspose.Slides pour PHP via Java. Ajouter, mettre en forme et modifier des graphiques avec des exemples de code pratiques."
---

## **Vue d'ensemble**

Cet article décrit comment **créer des graphiques de présentation PowerPoint en Java**. Vous pouvez également **mettre à jour les graphiques**. Il couvre les sujets suivants.

_Chart_: **Normal**
- [Java Create PowerPoint Chart](#java-create-powerpoint-chart)
- [Java Create Presentation Chart](#java-create-presentation-chart)
- [Java Create PowerPoint Presentation Chart](#java-create-powerpoint-presentation-chart)

_Chart_: **Scattered**
- [Java Create Scattered Chart](#java-create-scattered-chart)
- [Java Create PowerPoint Scattered Chart](#java-create-powerpoint-scattered-chart)
- [Java Create PowerPoint Presentation Scattered Chart](#java-create-powerpoint-presentation-scattered-chart)

_Chart_: **Pie**
- [Java Create Pie Chart](#java-create-pie-chart)
- [Java Create PowerPoint Pie Chart](#java-create-powerpoint-pie-chart)
- [Java Create PowerPoint Presentation Pie Chart](#java-create-powerpoint-presentation-pie-chart)

_Chart_: **Tree Map**
- [Java Create Tree Map Chart](#java-create-tree-map-chart)
- [Java Create PowerPoint Tree Map Chart](#java-create-powerpoint-tree-map-chart)
- [Java Create PowerPoint Presentation Tree Map Chart](#java-create-powerpoint-presentation-tree-map-chart)

_Chart_: **Stock**
- [Java Create Stock Chart](#java-create-stock-chart)
- [Java Create PowerPoint Stock Chart](#java-create-powerpoint-stock-chart)
- [Java Create PowerPoint Presentation Stock Chart](#java-create-powerpoint-presentation-stock-chart)

_Chart_: **Box and Whisker**
- [Java Create Box and Whisker Chart](#java-create-box-and-whisker-chart)
- [Java Create PowerPoint Box and Whisker Chart](#java-create-powerpoint-box-and-whisker-chart)
- [Java Create PowerPoint Presentation Box and Whisker Chart](#java-create-powerpoint-presentation-box-and-whisker-chart)

_Chart_: **Funnel**
- [Java Create Funnel Chart](#java-create-funnel-chart)
- [Java Create PowerPoint Funnel Chart](#java-create-powerpoint-funnel-chart)
- [Java Create PowerPoint Presentation Funnel Chart](#java-create-powerpoint-presentation-funnel-chart)

_Chart_: **Sunburst**
- [Java Create Sunburst Chart](#java-create-sunburst-chart)
- [Java Create PowerPoint Sunburst Chart](#java-create-powerpoint-sunburst-chart)
- [Java Create PowerPoint Presentation Sunburst Chart](#java-create-powerpoint-presentation-sunburst-chart)

_Chart_: **Histogram**
- [Java Create Histogram Chart](#java-create-histogram-chart)
- [Java Create PowerPoint Histogram Chart](#java-create-powerpoint-histogram-chart)
- [Java Create PowerPoint Presentation Histogram Chart](#java-create-powerpoint-presentation-histogram-chart)

_Chart_: **Radar**
- [Java Create Radar Chart](#java-create-radar-chart)
- [Java Create PowerPoint Radar Chart](#java-create-powerpoint-radar-chart)
- [Java Create PowerPoint Presentation Radar Chart](#java-create-powerpoint-presentation-radar-chart)

_Chart_: **Multi Category**
- [Java Create Multi Category Chart](#java-create-multi-category-chart)
- [Java Create PowerPoint Multi Category Chart](#java-create-powerpoint-multi-category-chart)
- [Java Create PowerPoint Presentation Multi Category Chart](#java-create-powerpoint-presentation-multi-category-chart)

_Chart_: **Map**
- [Java Create Map Chart](#java-create-map-chart)
- [Java Create PowerPoint Map Chart](#java-create-powerpoint-map-chart)
- [Java Create PowerPoint Presentation Map Chart](#java-create-powerpoint-presentation-map-chart)

_Action_: **Update Chart**
- [Java Update PowerPoint Chart](#java-update-powerpoint-chart)
- [Java Update Presentation Chart](#java-update-presentation-chart)
- [Java Update PowerPoint Presentation Chart](#java-update-powerpoint-presentation-chart)


## **Créer un graphique**
Les graphiques aident les utilisateurs à visualiser rapidement les données et à en tirer des enseignements, ce qui peut ne pas être immédiatement évident à partir d’un tableau ou d’une feuille de calcul. 


**Pourquoi créer des graphiques ?**

Grâce aux graphiques, vous pouvez :

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d’une présentation
* révéler des motifs et des tendances dans les données
* déduire la direction et l’élan des données dans le temps ou par rapport à une unité de mesure spécifique 
* repérer les valeurs aberrantes, les anomalies, les écarts, les erreurs, les données incohérentes, etc. 
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques via la fonction d’insertion, qui fournit des modèles utilisés pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer des graphiques standards (basés sur les types de graphiques courants) et des graphiques personnalisés. 

{{% alert color="primary" %}} 

Pour vous permettre de créer des graphiques, Aspose.Slides fournit la classe [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType). Les champs de cette classe correspondent aux différents types de graphiques.

{{% /alert %}} 

### **Créer des graphiques normaux**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Steps:</em> Create PowerPoint Chart </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Steps:</em> Create Presentation Chart </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Chart </strong></a>

_Code Steps:_

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez un graphique avec certaines données et spécifiez le type de graphique souhaité. 
4. Ajoutez un titre au graphique. 
5. Accédez à la feuille de données du graphique. 
6. Supprimez toutes les séries et catégories par défaut. 
7. Ajoutez de nouvelles séries et catégories. 
8. Ajoutez de nouvelles données de graphique pour les séries. 
9. Ajoutez une couleur de remplissage pour les séries. 
10. Ajoutez des étiquettes pour les séries. 
11. Enregistrez la présentation modifiée au format PPTX. 

Ce code PHP montre comment créer un graphique normal :
```php
  # Instancie une classe de présentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute un graphique avec ses données par défaut
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # Définit le titre du graphique
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # Définit la première série pour afficher les valeurs
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Définit l'index de la feuille de données du graphique
    $defaultWorksheetIndex = 0;
    # Obtient la feuille de données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Supprime les séries et catégories générées par défaut
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # Ajoute de nouvelles séries
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Ajoute de nouvelles catégories
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Prend la première série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Maintenant remplit les données de la série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Définit la couleur de remplissage pour la série
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Prend la deuxième série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Remplit les données de la série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Définit la couleur de remplissage pour la série
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Crée des étiquettes personnalisées pour chaque catégorie de la nouvelle série
    # Définit la première étiquette pour afficher le nom de la catégorie
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Affiche la valeur pour la troisième étiquette
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # Enregistre la présentation avec le graphique
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques dispersés**
Les graphiques dispersés (également appelés nuages de points ou graphiques x‑y) sont souvent utilisés pour vérifier des motifs ou démontrer des corrélations entre deux variables. 

Vous pouvez choisir un graphique dispersé lorsque :

* vous avez des données numériques appariées
* vous avez 2 variables qui se combinent bien
* vous voulez déterminer si 2 variables sont liées
* vous avez une variable indépendante qui possède plusieurs valeurs pour une variable dépendante

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Steps:</em> Create Scattered Chart </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Steps:</em> Create PowerPoint Scattered Chart </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Scattered Chart </strong></a>

1. Veuillez suivre les étapes décrites ci‑dessus dans [Creating Normal Charts](#creating-normal-charts)  
2. Pour la troisième étape, ajoutez un graphique avec des données et spécifiez le type de graphique parmi les suivants :  
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) – _Représente un graphique de dispersion avec marqueurs._  
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) – _Représente un graphique de dispersion avec lignes lisses et marqueurs._  
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) – _Représente un graphique de dispersion avec lignes lisses, sans marqueurs._  
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) – _Représente un graphique de dispersion avec lignes droites et marqueurs._  
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) – _Représente un graphique de dispersion avec lignes droites, sans marqueurs._

Ce code PHP montre comment créer des graphiques dispersés avec différentes séries de marqueurs :
```php
  # Instancie une classe de présentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Crée le graphique par défaut
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Obtient l'index de la feuille de données du graphique par défaut
    $defaultWorksheetIndex = 0;
    # Obtient la feuille de données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Supprime la série de démonstration
    $chart->getChartData()->getSeries()->clear();
    # Ajoute de nouvelles séries
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # Prend la première série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Ajoute un nouveau point (1:3) à la série
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # Ajoute un nouveau point (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # Modifie le type de la série
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Modifie le marqueur de la série du graphique
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Prend la deuxième série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Ajoute un nouveau point (5:2) ici
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # Ajoute un nouveau point (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # Ajoute un nouveau point (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # Ajoute un nouveau point (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # Modifie le marqueur de la série du graphique
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques circulaires**

Les graphiques circulaires sont idéaux pour illustrer la relation partie‑à‑tout dans les données, surtout lorsque les données contiennent des libellés catégoriels avec des valeurs numériques. Cependant, si vos données comportent de nombreuses parties ou libellés, il peut être préférable d’utiliser un diagramme à barres.

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Steps:</em> Create Pie Chart </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Steps:</em> Create PowerPoint Pie Chart </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Pie Chart </strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Pie).  
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).  
5. Supprimez les séries et catégories par défaut.  
6. Ajoutez de nouvelles séries et catégories.  
7. Ajoutez de nouvelles données de graphique pour les séries.  
8. Ajoutez de nouveaux points et définissez des couleurs personnalisées pour les secteurs du graphique circulaire.  
9. Définissez des étiquettes pour les séries.  
10. Définissez des lignes de repère pour les étiquettes des séries.  
11. Définissez l’angle de rotation pour les diapositives du graphique circulaire.  
12. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un graphique circulaire :
```php
  # Instancie une classe de présentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $slides = $pres->getSlides()->get_Item(0);
    # Ajoute un graphique avec des données par défaut
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Définit le titre du graphique
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Définit la première série pour afficher les valeurs
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Définit l'index de la feuille de données du graphique
    $defaultWorksheetIndex = 0;
    # Obtient la feuille de données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Supprime les séries et catégories générées par défaut
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Ajoute de nouvelles catégories
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Ajoute de nouvelles séries
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Remplit les données de la série
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # Ne fonctionne pas dans la nouvelle version
    # Ajout de nouveaux points et définition de la couleur du secteur
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # Définit la bordure du secteur
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # Définit la bordure du secteur
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Définit la bordure du secteur
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # Crée des étiquettes personnalisées pour chaque catégorie de la nouvelle série
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # Affiche les lignes directrices pour le graphique
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # Définit l'angle de rotation des secteurs du graphique circulaire
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # Enregistre la présentation avec un graphique
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques en lignes**

Les graphiques en lignes (ou graphiques linéaires) sont les mieux adaptés lorsqu’on veut montrer l’évolution d’une valeur dans le temps. Avec un graphique en lignes, vous pouvez comparer de nombreux jeux de données simultanément, suivre les évolutions et les tendances, mettre en évidence des anomalies, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (dans ce cas, `ChartType::Line`).  
4. Accédez aux données du graphique via IChartDataWorkbook.  
5. Supprimez les séries et catégories par défaut.  
6. Ajoutez de nouvelles séries et catégories.  
7. Ajoutez de nouvelles données de graphique pour les séries.  
8. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un graphique en lignes :
```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Par défaut, les points d’un graphique en lignes sont reliés par des segments droits continus. Si vous souhaitez que les points soient reliés par des tirets, vous pouvez spécifier le type de tiret souhaité ainsi :
```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```


### **Créer des graphiques arborescents**

Les graphiques arborescents sont idéaux pour les données de ventes lorsque vous voulez montrer la taille relative des catégories tout en attirant rapidement l’attention sur les éléments qui contribuent le plus à chaque catégorie. 

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Steps:</em> Create Tree Map Chart </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Steps:</em> Create PowerPoint Tree Map Chart </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Tree Map Chart </strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).TreeMap).  
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).  
5. Supprimez les séries et catégories par défaut.  
6. Ajoutez de nouvelles séries et catégories.  
7. Ajoutez de nouvelles données de graphique pour les séries.  
8. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un graphique arborescent :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # branche 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # branche 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques boursiers**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Steps:</em> Create Stock Chart </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Steps:</em> Create PowerPoint Stock Chart </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Stock Chart </strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).OpenHighLowClose).  
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).  
5. Supprimez les séries et catégories par défaut.  
6. Ajoutez de nouvelles séries et catégories.  
7. Ajoutez de nouvelles données de graphique pour les séries.  
8. Spécifiez le format HiLowLines.  
9. Enregistrez la présentation modifiée au format PPTX.  

Exemple de code PHP utilisé pour créer un graphique boursier :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    foreach($chart->getChartData()->getSeries() as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques boîte à moustaches**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Steps:</em> Create Box and Whisker Chart </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Steps:</em> Create PowerPoint Box and Whisker Chart </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Box and Whisker Chart </strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).BoxAndWhisker).  
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).  
5. Supprimez les séries et catégories par défaut.  
6. Ajoutez de nouvelles séries et catégories.  
7. Ajoutez de nouvelles données de graphique pour les séries.  
8. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un graphique boîte à moustaches :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques entonnoir**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Steps:</em> Create Funnel Chart </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Steps:</em> Create PowerPoint Funnel Chart </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Funnel Chart </strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Funnel).  
4. Enregistrez la présentation modifiée au format PPTX.  

Le code PHP montre comment créer un graphique entonnoir :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques rayonnants**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Steps:</em> Create Sunburst Chart </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Steps:</em> Create PowerPoint Sunburst Chart </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Sunburst Chart </strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (dans ce cas, [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).sunburst).  
4. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un graphique rayonnant :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # branche 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # branche 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques histogrammes**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Steps:</em> Create Histogram Chart </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Steps:</em> Create PowerPoint Histogram Chart </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Histogram Chart </strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).Histogram).  
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).  
5. Supprimez les séries et catégories par défaut.  
6. Ajoutez de nouvelles séries et catégories.  
7. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un histogramme :
```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```


### **Créer des graphiques radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Steps:</em> Create Radar Chart </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Steps:</em> Create PowerPoint Radar Chart </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Radar Chart </strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec certaines données et spécifiez le type souhaité (`ChartType::Radar` dans ce cas).  
4. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un graphique radar :
```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques multi‑catégories**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Steps:</em> Create Multi Category Chart </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Steps:</em> Create PowerPoint Multi Category Chart </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Multi Category Chart </strong></a>

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).  
2. Obtenez la référence d’une diapositive via son index.  
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité ([ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/ChartType).ClusteredColumn).  
4. Accédez aux données du graphique via [IChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook).  
5. Supprimez les séries et catégories par défaut.  
6. Ajoutez de nouvelles séries et catégories.  
7. Ajoutez de nouvelles données de graphique pour les séries.  
8. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment créer un graphique multi‑catégorie :
```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # Ajout de séries
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # Enregistrer la présentation avec le graphique
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques cartographiques**

Un graphique cartographique visualise une zone contenant des données. Les graphiques cartographiques sont idéaux pour comparer des valeurs à travers des régions géographiques.

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Steps:</em> Create Map Chart </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Steps:</em> Create PowerPoint Map Chart </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Map Chart </strong></a>

Ce code PHP montre comment créer un graphique cartographique :
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **Créer des graphiques combinés**

Un graphique combiné (ou graphique combo) réunit deux types de graphiques ou plus dans un même diagramme. Ce type de graphique vous permet de mettre en évidence, de comparer ou d’examiner les différences entre plusieurs ensembles de données, aidant ainsi à identifier les relations entre eux.

![The combination chart](combination_chart.png)

Le code PHP suivant montre comment créer le graphique combiné présenté ci‑dessus dans une présentation PowerPoint :
```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Définir le titre du graphique.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Définir la légende du graphique.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Supprimer les séries et catégories générées par défaut.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Ajouter de nouvelles catégories.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Ajouter la première série.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // Définir l'axe horizontal.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Définir l'axe vertical.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Définir la couleur des lignes de grille majeures verticales.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Définir l'axe horizontal secondaire.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Définir l'axe vertical secondaire.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```


## **Mettre à jour les graphiques**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Steps:</em> Update PowerPoint Chart </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Steps:</em> Update Presentation Chart </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Steps:</em> Update PowerPoint Presentation Chart </strong></a>

1. Instanciez une classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) qui représente la présentation contenant le graphique à mettre à jour.  
2. Obtenez la référence d’une diapositive en utilisant son index.  
3. Parcourez toutes les formes pour trouver le graphique souhaité.  
4. Accédez à la feuille de données du graphique.  
5. Modifiez les données des séries en changeant les valeurs des séries.  
6. Ajoutez une nouvelle série et remplissez‑la avec des données.  
7. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment mettre à jour un graphique :
```php
  # Accéder à la première diapositive
  $pres = new Presentation();
  try {
    # Obtenir le graphique avec les données par défaut
    $sld = $pres->getSlides()->get_Item(0);
    # Définir l'index de la feuille de données du graphique
    $defaultWorksheetIndex = 0;
    # Obtenir la feuille de données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Modifier le nom de la catégorie du graphique
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # Prendre la première série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Mise à jour des données de la série
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// Modification du nom de la série

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # Prendre la deuxième série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Mise à jour des données de la série
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// Modification du nom de la série

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # Ajout d'une nouvelle série
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # Prendre la troisième série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Remplissage des données de la série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # Enregistrer la présentation avec le graphique
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir la plage de données d’un graphique**

Pour définir la plage de données d’un graphique, procédez ainsi :

1. Instanciez une classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) qui représente la présentation contenant le graphique.  
2. Obtenez la référence d’une diapositive via son index.  
3. Parcourez toutes les formes pour trouver le graphique souhaité.  
4. Accédez aux données du graphique et définissez la plage.  
5. Enregistrez la présentation modifiée au format PPTX.  

Ce code PHP montre comment définir la plage de données d’un graphique :
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Utiliser des marqueurs par défaut dans les graphiques**
Lorsque vous utilisez un marqueur par défaut dans les graphiques, chaque série reçoit automatiquement un symbole de marqueur différent.

Ce code PHP montre comment définir automatiquement un marqueur de série :
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # Prendre la deuxième série du graphique
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # Maintenant, remplissage des données de la série
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Quels types de graphiques sont pris en charge par Aspose.Slides ?**

Aspose.Slides prend en charge un large éventail de [types de graphiques](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/), notamment les graphiques à barres, en lignes, circulaires, en aires, dispersés, histogrammes, radar et bien d’autres. Cette flexibilité vous permet de choisir le type de graphique le plus adapté à vos besoins de visualisation.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, créez d’abord une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) , récupérez la diapositive souhaitée via son index, puis appelez la méthode d’ajout de graphique en précisant le type de graphique et les données initiales. Cette procédure intègre directement le graphique dans votre présentation.

**Comment mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d’un graphique en accédant à son classeur de données ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)), en supprimant les séries et catégories par défaut, puis en ajoutant vos propres données. Cela vous permet de rafraîchir le graphique avec les dernières informations.

**Est‑il possible de personnaliser l’apparence du graphique ?**

Oui, Aspose.Slides offre de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les étiquettes, les légendes et d’autres [éléments de mise en forme](/slides/fr/php-java/chart-entities/) pour adapter l’aspect du graphique à vos exigences de conception.