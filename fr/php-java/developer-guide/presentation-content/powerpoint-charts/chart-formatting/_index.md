---
title: Mise en forme des graphiques
type: docs
weight: 60
url: /fr/php-java/chart-formatting/
---

## **Format des entités de graphique**
Aspose.Slides pour PHP via Java permet aux développeurs d'ajouter des graphiques personnalisés à leurs diapositives depuis zéro. Cet article explique comment formater différentes entités de graphique, y compris les axes de catégorie et de valeur.

Aspose.Slides pour PHP via Java fournit une API simple pour gérer différentes entités de graphique et les formatter à l'aide de valeurs personnalisées :

1. Créer une instance de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir la référence d'une diapositive par son index.
1. Ajouter un graphique avec des données par défaut de n'importe quel type désiré (dans cet exemple, nous utiliserons ChartType::LineWithMarkers).
1. Accéder à l'axe de valeur du graphique et définir les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de grille majeures de l'axe de valeur
   1. Définir le **format de ligne** pour les lignes de grille mineures de l'axe de valeur
   1. Définir le **format numérique** pour l'axe de valeur
   1. Définir les **unités Min, Max, Majeur et Mineur** pour l'axe de valeur
   1. Définir les **propriétés de texte** pour les données de l'axe de valeur
   1. Définir le **titre** pour l'axe de valeur
   1. Définir le **format de ligne** pour l'axe de valeur
1. Accéder à l'axe de catégorie du graphique et définir les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de grille majeures de l'axe de catégorie
   1. Définir le **format de ligne** pour les lignes de grille mineures de l'axe de catégorie
   1. Définir les **propriétés de texte** pour les données de l'axe de catégorie
   1. Définir le **titre** pour l'axe de catégorie
   1. Définir le **positionnement des étiquettes** pour l'axe de catégorie
   1. Définir l'**angle de rotation** pour les étiquettes de l'axe de catégorie
1. Accéder à la légende du graphique et définir les **propriétés de texte** pour celles-ci
1. Afficher les légendes du graphique sans chevauchement
1. Accéder à l'**axe de valeur secondaire** du graphique et définir les propriétés suivantes :
   1. Activer l'**axe de valeur secondaire**
   1. Définir le **format de ligne** pour l'axe de valeur secondaire
   1. Définir le **format numérique** pour l'axe de valeur secondaire
   1. Définir les **unités Min, Max, Majeur et Mineur** pour l'axe de valeur secondaire
1. Maintenant, tracer la première série de graphique sur l'axe de valeur secondaire
1. Définir la couleur de remplissage du mur arrière du graphique
1. Définir la couleur de remplissage de la zone de tracé du graphique
1. Écrire la présentation modifiée dans un fichier PPTX

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter le graphique d'exemple
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Définir le titre du graphique
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Graphique d'exemple");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir le format des lignes de grille majeures pour l'axe de valeur
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Définir le format des lignes de grille mineures pour l'axe de valeur
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Définir le format numérique de l'axe de valeur
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Définir les valeurs maximales et minimales du graphique
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Définir les propriétés de texte de l'axe de valeur
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Définir le titre de l'axe de valeur
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Axe primaire");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir le format des lignes de grille majeures pour l'axe de catégorie
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Définir le format des lignes de grille mineures pour l'axe de catégorie
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Définir les propriétés de texte de l'axe de catégorie
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Définir le titre de la catégorie
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Catégorie d'exemple");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir la position des étiquettes de l'axe de catégorie
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Définir l'angle de rotation des étiquettes de l'axe de catégorie
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Définir les propriétés de texte des légendes
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Afficher les légendes du graphique sans chevauchement
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Définir l'axe de valeur secondaire
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Définir le format numérique de l'axe de valeur secondaire
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Définir les valeurs maximales et minimales du graphique
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Définir la couleur du mur arrière du graphique
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Définir la couleur de la zone de tracé
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Sauvegarder la présentation
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir les propriétés de la police pour le graphique**
Aspose.Slides pour PHP via Java fournit un support pour définir les propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci-dessous pour définir les propriétés de police pour le graphique.

- Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Ajouter un graphique sur la diapositive.
- Définir la hauteur de la police.
- Sauvegarder la présentation modifiée.

Un exemple de code est donné ci-dessous.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir le format des numériques**
Aspose.Slides pour PHP via Java fournit une API simple pour gérer le format des données du graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenir la référence d'une diapositive par son index.
1. Ajouter un graphique avec des données par défaut de n'importe quel type désiré (cet exemple utilise **ChartType::ClusteredColumn**).
1. Définir le format numérique prédéfini à partir des valeurs prédéfinies possibles.
1. Parcourir les cellules des données du graphique dans chaque série de graphiques et définir le format numérique des données du graphique.
1. Sauvegarder la présentation.
1. Définir le format numérique personnalisé.
1. Parcourir les cellules de données du graphique à l'intérieur de chaque série de graphiques et définir un format numérique différent pour les données du graphique.
1. Sauvegarder la présentation.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter un graphique en colonnes regroupées par défaut
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Accéder à la collection de séries de graphiques
    $series = $chart->getChartData()->getSeries();
    # Parcourir chaque série de graphiques
    foreach($series as $ser) {
      # Parcourir chaque cellule de données dans la série
      foreach($ser->getDataPoints() as $cell) {
        # Définir le format numérique
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # Sauvegarder la présentation
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Les valeurs possibles de format numérique prédéfini ainsi que leur index prédéfini qui peuvent être utilisées sont données ci-dessous :

|**0**|Général|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rouge$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rouge$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/j/aa|
|**15**|j-mmm-aa|
|**16**|j-mmm|
|**17**|mmm-aa|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/j/aa h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Rouge-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rouge-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Définir les bordures arrondies de la zone de graphique**
Aspose.Slides pour PHP via Java fournit un support pour définir la zone du graphique. Les méthodes [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#hasRoundedCorners--) et [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#setRoundedCorners-boolean-) ont été ajoutées à l'interface [IChart](https://reference.aspose.com/slides/php-java/aspose.slides/IChart) et à la classe [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart). 

1. Instancier un objet de classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du graphique
1. Définir la propriété coin arrondi sur Vrai.
1. Sauvegarder la présentation modifiée.

Un exemple de code est donné ci-dessous.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```