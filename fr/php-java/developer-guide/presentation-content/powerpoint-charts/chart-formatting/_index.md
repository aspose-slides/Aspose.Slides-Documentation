---
title: Formater les graphiques de présentation en PHP
linktitle: Mise en forme des graphiques
type: docs
weight: 60
url: /fr/php-java/chart-formatting/
keywords:
- format de graphique
- mise en forme de graphique
- entité de graphique
- propriétés de graphique
- paramètres de graphique
- options de graphique
- propriétés de police
- bordure arrondie
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à mettre en forme les graphiques avec Aspose.Slides pour PHP via Java et améliorez votre présentation PowerPoint avec un style professionnel et attrayant."
---

## **Format des entités de graphique**
Aspose.Slides for PHP via Java permet aux développeurs d'ajouter des graphiques personnalisés à leurs diapositives à partir de zéro. Cet article explique comment formater différentes entités de graphique, y compris les axes de catégorie et de valeur.

Aspose.Slides for PHP via Java fournit une API simple pour gérer différentes entités de graphique et les formater à l'aide de valeurs personnalisées :

1. Créez une instance de la classe [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à la diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple nous utiliserons ChartType::LineWithMarkers).
1. Accédez à l'axe des valeurs du graphique et définissez les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de la grille principale de l'axe des valeurs
   1. Définir le **Line format** pour les lignes de la grille secondaire de l'axe des valeurs
   1. Définir le **Number Format** pour l'axe des valeurs
   1. Définir les **Min, Max, Major and Minor units** pour l'axe des valeurs
   1. Définir les **Text Properties** pour les données de l'axe des valeurs
   1. Définir le **Title** pour l'axe des valeurs
   1. Définir le **Line Format** pour l'axe des valeurs
1. Accédez à l'axe des catégories du graphique et définissez les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de la grille principale de l'axe des catégories
   1. Définir le **Line format** pour les lignes de la grille secondaire de l'axe des catégories
   1. Définir les **Text Properties** pour les données de l'axe des catégories
   1. Définir le **Title** pour l'axe des catégories
   1. Définir le **Label Positioning** pour l'axe des catégories
   1. Définir l'**Rotation Angle** pour les étiquettes de l'axe des catégories
1. Accédez à la légende du graphique et définissez les **Text Properties** pour celle‑ci
1. Configurez l'affichage des légendes du graphique sans chevauchement
1. Accédez à l'**Secondary Value Axis** du graphique et définissez les propriétés suivantes :
   1. Activez l'**Value Axis** secondaire
   1. Définir le **Line Format** pour l'axe des valeurs secondaire
   1. Définir le **Number Format** pour l'axe des valeurs secondaire
   1. Définir les **Min, Max, Major and Minor units** pour l'axe des valeurs secondaire
1. Tracez maintenant la première série du graphique sur l'axe des valeurs secondaire
1. Définissez la couleur de remplissage du mur arrière du graphique
1. Définissez la couleur de remplissage de la zone de tracé du graphique
1. Enregistrez la présentation modifiée dans un fichier PPTX
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
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir le format des lignes de grille principales pour l'axe des valeurs
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Définir le format des lignes de grille secondaires pour l'axe des valeurs
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Définir le format numérique de l'axe des valeurs
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
    # Définir les propriétés de texte de l'axe des valeurs
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Définir le titre de l'axe des valeurs
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir le format des lignes de grille principales pour l'axe des catégories
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Définir le format des lignes de grille secondaires pour l'axe des catégories
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Définir les propriétés de texte de l'axe des catégories
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
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Définir la position des étiquettes de l'axe des catégories
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Définir l'angle de rotation des étiquettes de l'axe des catégories
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Définir les propriétés de texte des légendes
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Définir l'affichage des légendes du graphique sans chevauchement
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Définir l'axe des valeurs secondaire
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Définir le format numérique de l'axe des valeurs secondaire
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
    # Enregistrer la présentation
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Définir les propriétés de police pour un graphique**
Aspose.Slides for PHP via Java prend en charge la définition des propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci‑dessous pour définir les propriétés de police du graphique.

- Instanciez l'objet de classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Ajoutez un graphique sur la diapositive.
- Définissez la hauteur de la police.
- Enregistrez la présentation modifiée.

L'exemple d'échantillon ci‑dessous est fourni.
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


## **Définir le format numérique**
Aspose.Slides for PHP via Java fournit une API simple pour gérer le format des données de graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez une référence à la diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise **ChartType::ClusteredColumn**).
1. Définissez le format numérique prédéfini parmi les valeurs prédéfinies possibles.
1. Parcourez chaque cellule de données du graphique dans chaque série et définissez le format numérique des données du graphique.
1. Enregistrez la présentation.
1. Définissez le format numérique personnalisé.
1. Parcourez chaque cellule de données du graphique dans chaque série et définissez un format numérique différent.
1. Enregistrez la présentation.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Accéder à la première diapositive de la présentation
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter un graphique à colonnes groupées par défaut
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Accéder à la collection des séries du graphique
    $series = $chart->getChartData()->getSeries();
    # Parcourir chaque série du graphique
    foreach($series as $ser) {
      # Parcourir chaque cellule de données dans la série
      foreach($ser->getDataPoints() as $cell) {
        # Définir le format numérique
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # Enregistrer la présentation
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Les valeurs possibles de format numérique prédéfini, ainsi que leurs index, qui peuvent être utilisées, sont indiquées ci‑dessous :

|**0**|Général|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Définir les bordures arrondies de la zone du graphique**
Aspose.Slides for PHP via Java prend en charge la définition de la zone du graphique. Les méthodes [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasroundedcorners/) et [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setroundedcorners/) ont été ajoutées à la classe [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart).

1. Instanciez l'objet de classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajoutez un graphique sur la diapositive.
1. Définissez le type de remplissage et la couleur de remplissage du graphique
1. Définissez la propriété de coins arrondis sur True.
1. Enregistrez la présentation modifiée.

L'exemple d'échantillon ci‑dessous est fourni.
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


## **FAQ**

**Puis‑je définir des remplissages semi‑transparents pour les colonnes/zones tout en gardant la bordure opaque ?**  
Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les étiquettes de données lorsqu'elles se chevauchent ?**  
Réduisez la taille de la police, désactivez les composants d'étiquette non essentiels (par exemple, les catégories), définissez le décalage/la position de l'étiquette, n'affichez les étiquettes que pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages dégradés ou à motifs aux séries ?**  
Oui. Les remplissages plein et dégradé/motif sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.