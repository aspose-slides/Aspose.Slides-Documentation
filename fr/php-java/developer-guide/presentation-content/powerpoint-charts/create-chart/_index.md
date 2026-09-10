---
title: Créer ou mettre à jour des graphiques de présentation PowerPoint en PHP
linktitle: Créer ou mettre à jour des graphiques
type: docs
weight: 10
url: /fr/php-java/create-chart/
keywords:
- ajouter graphique
- créer graphique
- modifier graphique
- changer graphique
- mettre à jour graphique
- graphique dispersé
- graphique circulaire
- graphique en courbes
- graphique en carte arborescente
- graphique boursier
- graphique à boîte et moustaches
- graphique en entonnoir
- graphique Sunburst
- graphique à histogramme
- graphique radar
- graphique multicatégorie
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Créer et personnaliser des graphiques dans les présentations PowerPoint à l'aide d'Aspose.Slides pour PHP via Java. Ajouter, formater et modifier des graphiques avec des exemples de code pratiques."
---
## **Aperçu**

Cet article fournit un guide complet sur la façon de créer et de personnaliser des graphiques à l'aide d'Aspose.Slides. Vous apprendrez à ajouter programmétiquement un graphique à une diapositive, à le remplir avec des données et à appliquer diverses options de formatage pour répondre à vos exigences de conception spécifiques. Tout au long de l'article, des exemples de code détaillés illustrent chaque étape, de l'initialisation de la présentation et de l'objet graphique à la configuration des séries, des axes et des légendes. En suivant ce guide, vous acquerrez une solide compréhension de la façon d'intégrer la génération dynamique de graphiques dans vos applications, simplifiant ainsi le processus de création de présentations basées sur les données.

## **Créer un graphique**

Les graphiques aident les personnes à visualiser rapidement les données et à obtenir des informations qui ne sont pas immédiatement évidentes à partir d'un tableau ou d'une feuille de calcul.

**Pourquoi créer des graphiques ?**

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d'une présentation
* exposer les motifs et les tendances dans les données
* déduire la direction et l'élan des données au fil du temps ou par rapport à une unité de mesure spécifique
* détecter les valeurs aberrantes, les anomalies, les écarts, les erreurs, les données incohérentes, etc.
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques via la fonction *Insérer*, qui propose des modèles pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer à la fois des graphiques standards (basés sur des types de graphiques populaires) et des graphiques personnalisés.

{{% alert color="info" title="Remarque" %}}
Pour créer des graphiques, utilisez la classe [ChartType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/). Les champs de cette classe correspondent à différents types de graphiques.
{{% /alert %}}

### **Créer des graphiques à colonnes groupées**

Cette section explique comment créer des graphiques à colonnes groupées à l'aide d'Aspose.Slides. Vous apprendrez à initialiser une présentation, ajouter un graphique et personnaliser ses éléments tels que le titre, les données, les séries, les catégories et le style. Suivez les étapes ci-dessous pour voir comment un graphique à colonnes groupées standard est généré :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec certaines données et spécifier le type `ChartType::ClusteredColumn`.
4. Ajouter un titre au graphique.
5. Accéder à la feuille de calcul des données du graphique.
6. Effacer toutes les séries et catégories par défaut.
7. Ajouter de nouvelles séries et catégories.
8. Ajouter de nouvelles données de graphique pour les séries du graphique.
9. Appliquer une couleur de remplissage aux séries du graphique.
10. Ajouter des étiquettes aux séries du graphique.
11. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code C# montre comment créer un graphique à colonnes groupées :
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
    # Définit l'index pour la feuille de données du graphique
    $defaultWorksheetIndex = 0;
    # Récupère la feuille de calcul des données du graphique
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
    # Remplit maintenant les données de la série
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
    # Crée des libellés personnalisés pour chaque catégorie de la nouvelle série
    # Définit le premier libellé pour afficher le nom de la catégorie
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # Affiche la valeur pour le troisième libellé
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

### **Créer des graphiques de dispersion**

Les graphiques de dispersion (également appelés nuages de points ou graphiques x‑y) sont souvent utilisés pour vérifier des motifs ou démontrer des corrélations entre deux variables.

Utilisez un graphique de dispersion lorsque :
* vous disposez de données numériques appariées
* vous avez deux variables qui s'accordent bien ensemble
* vous souhaitez déterminer si deux variables sont liées
* vous avez une variable indépendante qui possède plusieurs valeurs pour une variable dépendante

1. Suivez les étapes décrites dans [Créer des graphiques à colonnes groupées](#create-clustered-column-charts).
2. Pour la troisième étape, ajoutez un graphique avec certaines données et spécifiez votre type de graphique parmi les suivants :
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _Représente un graphique de dispersion._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Représente un graphique de dispersion relié par des courbes, avec des marqueurs de données._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Représente un graphique de dispersion relié par des courbes, sans marqueurs de données._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Représente un graphique de dispersion relié par des lignes droites, avec des marqueurs de données._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Représente un graphique de dispersion relié par des lignes droites, sans marqueurs de données._

Ce code PHP montre comment créer un graphique de dispersion avec des marqueurs différents pour chaque série :
```php
  # Instancie une classe de présentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Crée le graphique par défaut
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # Récupère l'index de la feuille de calcul des données du graphique par défaut
    $defaultWorksheetIndex = 0;
    # Récupère la feuille de calcul des données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Supprime les séries de démonstration
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
    # Modifie le type de série
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # Modifie le marqueur de la série du graphique
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # Prend la deuxième série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Ajoute un nouveau point (5:2) là
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

Les graphiques circulaires sont les mieux utilisés pour montrer la relation partie‑à‑tout dans les données, en particulier lorsque les données contiennent des libellés catégoriques avec des valeurs numériques. Cependant, si vos données contiennent de nombreuses parties ou libellés, vous pouvez envisager d'utiliser un graphique à barres à la place.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec des données par défaut et spécifier le type [ChartType::Pie](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#Pie).
4. Accéder au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries du graphique.
8. Ajouter de nouveaux points au graphique et appliquer des couleurs personnalisées aux secteurs du graphique circulaire.
9. Définir les libellés pour les séries.
10. Activer les lignes directrices pour les libellés des séries.
11. Définir l'angle de rotation des secteurs du graphique circulaire.
12. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment créer un graphique circulaire :
```php
  # Instancie une classe de présentation qui représente un fichier PPTX
  $pres = new Presentation();
  try {
    # Accède à la première diapositive
    $slides = $pres->getSlides()->get_Item(0);
    # Ajoute un graphique avec les données par défaut
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
    # Récupère la feuille de calcul des données du graphique
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
    # Crée des libellés personnalisés pour chaque catégorie de la nouvelle série
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
    # Affiche les lignes de guidage pour le graphique
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

### **Créer des graphiques en courbes**

Les graphiques en courbes (également appelés graphiques linéaires) sont les mieux utilisés dans les situations où vous souhaitez démontrer des variations de valeur au fil du temps. Avec un graphique en courbes, vous pouvez comparer une grande quantité de données à la fois, suivre les changements et les tendances dans le temps, mettre en évidence les anomalies dans les séries de données, etc.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec des données par défaut et spécifier le type [ChartType::Line](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#Line).
4. Accéder au classeur de données du graphique ([ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/)).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries du graphique.
Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment créer un graphique en courbes :
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

Par défaut, les points d'un graphique en courbes sont reliés par des lignes continues droites. Si vous souhaitez que les points soient reliés par des tirets, vous pouvez spécifier le type de tiret souhaité comme suit :
```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Créer des graphiques en cartes arborescentes**

Les graphiques en cartes arborescentes sont les mieux adaptés aux données de ventes lorsque vous souhaitez montrer la taille relative des catégories de données et attirer rapidement l'attention sur les éléments qui représentent d'importantes contributions au sein de chaque catégorie.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec des données par défaut et spécifier le type [ChartType::Treemap](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#Treemap).
4. Accéder au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries du graphique.
8. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment créer un graphique en carte arborescente :
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

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec des données par défaut et spécifier le type [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#OpenHighLowClose).
4. Accéder au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries du graphique.
8. Spécifier le format des lignes haut‑bas.
9. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment créer un graphique boursier :
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
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Créer des graphiques à boîte et moustaches**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec des données par défaut et spécifier le type [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#BoxAndWhisker).
4. Accéder au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries du graphique.
8. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment créer un graphique à boîte et moustaches :
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

### **Créer des graphiques en entonnoir**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec des données par défaut et spécifier le type [ChartType::Funnel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#Funnel).
4. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment créer un graphique en entonnoir :
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

### **Créer des graphiques Sunburst**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec des données par défaut et spécifier le type [ChartType::Sunburst](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#Sunburst).
4. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment créer un graphique Sunburst :
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

### **Créer des graphiques à histogramme**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec des données par défaut et spécifier le type [ChartType::Histogram](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#Histogram).
4. Accéder au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment créer un graphique à histogramme :
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

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec certaines données et spécifier votre type de graphique préféré ([ChartType::Radar](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#Radar) dans ce cas).
4. Enregistrer la présentation modifiée sous forme de fichier PPTX.

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

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Ajouter un graphique avec des données par défaut et spécifier le type [ChartType::ClusteredColumn](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/#ClusteredColumn).
4. Accéder au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/php-java/aspose.slides/chartdataworkbook/).
5. Effacer les séries et catégories par défaut.
6. Ajouter de nouvelles séries et catégories.
7. Ajouter de nouvelles données de graphique pour les séries du graphique.
8. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment créer un graphique multi‑catégories :
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

Les graphiques cartographiques visualisent des données géographiques et aident à comparer les valeurs entre les régions.

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

Un graphique combiné (ou graphique combo) combine deux types de graphiques ou plus dans un seul graphique. Ce type de graphique vous permet de mettre en évidence, comparer ou examiner les différences entre deux ensembles de données ou plus, facilitant l'identification des relations entre eux.

![Le graphique combiné](combination_chart.png)

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

    // Définit le titre du graphique.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // Définit la légende du graphique.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // Supprime les séries et catégories générées par défaut.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // Ajoute de nouvelles catégories.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // Ajoute la première série.
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
    // Définit l'axe horizontal.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // Définit l'axe vertical.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // Définit la couleur des lignes de grille majeures verticales.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // Définit l'axe horizontal secondaire.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // Définit l'axe vertical secondaire.
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

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) qui représente la présentation contenant le graphique à mettre à jour.
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Parcourir toutes les formes pour trouver le graphique souhaité.
4. Accéder à la feuille de calcul des données du graphique.
5. Modifier les séries de données du graphique en changeant les valeurs des séries.
6. Ajouter une nouvelle série et remplir ses données.
7. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment mettre à jour un graphique :
```php
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Obtenir le graphique avec les données par défaut
    $chart = $sld->getShapes()->get_Item(0);
    # Définir l'index de la feuille de données du graphique
    $defaultWorksheetIndex = 0;
    # Récupérer la feuille de calcul des données du graphique
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Modifier le nom de catégorie du graphique
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
    # Prendre la 3e série du graphique
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # Population des données de la série
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

## **Définir la plage de données d'un graphique**

Pour définir la plage de données d'un graphique, procédez comme suit :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/) qui représente la présentation contenant le graphique.
2. Obtenir une référence à une diapositive en utilisant son indice.
3. Parcourir toutes les formes pour trouver le graphique souhaité.
4. Accéder aux données du graphique et définir la plage.
5. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Ce code PHP montre comment définir la plage de données d'un graphique :
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is040null($pres)) {
      $pres->dispose();
    }
  }
```

## **Utiliser des marqueurs par défaut dans les graphiques**

Lorsque vous utilisez des marqueurs par défaut dans les graphiques, chaque série de graphique obtient automatiquement un symbole de marqueur différent.

Ce code PHP montre comment définir automatiquement un marqueur de série de graphique :
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
    # Maintenant remplissage des données de la série
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

Aspose.Slides prend en charge un large éventail de [types de graphiques](https://reference.aspose.com/slides/fr/php-java/aspose.slides/charttype/), notamment les graphiques à barres, en courbes, circulaires, en aires, de dispersion, à histogramme, radar et bien d’autres. Cette flexibilité vous permet de choisir le type de graphique le plus approprié à vos besoins de visualisation de données.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, vous créez d'abord une instance de la classe [Presentation], récupérez la diapositive souhaitée en utilisant son indice, puis appelez la méthode d'ajout d'un graphique en spécifiant le type de graphique et les données initiales. Ce processus intègre le graphique directement dans votre présentation.

**Comment puis‑je mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d'un graphique en accédant à son classeur de données ([ChartDataWorkbook]), en supprimant les séries et catégories par défaut, puis en ajoutant vos données personnalisées. Cela vous permet d'actualiser le graphique pour refléter les dernières données.

**Est‑il possible de personnaliser l'apparence du graphique ?**

Oui, Aspose.Slides offre de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les libellés, les légendes et d’autres [éléments de formatage](/slides/fr/php-java/chart-entities/) pour adapter l’apparence du graphique à vos exigences de conception spécifiques.