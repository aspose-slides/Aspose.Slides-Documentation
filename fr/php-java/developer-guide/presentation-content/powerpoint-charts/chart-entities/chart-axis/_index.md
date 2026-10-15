---
title: Personnaliser les axes de graphique dans les présentations avec PHP
linktitle: Axe de graphique
type: docs
url: /fr/php-java/chart-axis/
keywords:
- axe de graphique
- axe vertical
- axe horizontal
- personnaliser l'axe
- manipuler l'axe
- gérer l'axe
- propriétés de l'axe
- valeur maximale
- valeur minimale
- ligne d'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides pour PHP via Java afin de personnaliser les axes de graphique dans les présentations PowerPoint pour les rapports et les visualisations."
---
## **Aperçu**

Cet article explique comment personnaliser les axes de graphiques avec Aspose.Slides pour PHP via Java. Il couvre les valeurs d’axe calculées, l’échange des lignes et colonnes du graphique, la visibilité des axes, les intervalles d’étiquettes de catégorie et de marques de graduation, les catégories de dates et leur formatage, la rotation du titre, le positionnement des axes, les unités d’affichage et le redimensionnement logarithmique.

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**

Créez une [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et ajoutez un diagramme en aires avec les données par défaut. Appelez [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) avant de lire les valeurs d’axe calculées afin que la disposition du diagramme soit à jour.

Lisez [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) et [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) pour les limites de l’axe, et [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) et [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) pour les intervalles de graduation. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) et [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) fournissent les échelles d’unités de temps, pertinentes pour les axes de dates. L’exemple stocke ces valeurs dans des variables locales et enregistre le diagramme.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Échanger les données entre les axes**

Utilisez [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) pour échanger les rôles des séries et des catégories dans les données du graphique. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie la façon dont les données sont regroupées ; cela n’échange pas les axes horizontal et vertical. L’exemple utilise [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) pour lier les données par défaut à `Sheet1!A1:D5`, incluant la ligne d’en-tête et la colonne de catégorie, avant d’échanger les lignes et colonnes. Il enregistre un diagramme avec quatre séries et trois catégories.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Inverser l'ordre de tracé d'un axe**

Utilisez [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) pour inverser un axe de catégorie ou de valeur. Par exemple, un diagramme à barres horizontales peut afficher les étapes du projet de haut en bas dans le même ordre que la feuille : Planification, Développement, Test. L’inversion d’un axe change la direction du tracé ; cela ne trie pas et ne réarrange pas les données du classeur. En comparaison, [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) échange les rôles des séries et des catégories.

L’exemple suivant crée un diagramme à barres horizontales avec trois étapes et une série. Il enregistre une présentation avec trois diapositives : ordre normal, catégories inversées et valeurs inversées. Chaque copie utilise le même jeu de données, et un seul axe est inversé dans chaque copie.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // Diapositive 2 : afficher la première catégorie en haut.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Conserver l'axe de valeurs horizontal en bas.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // Diapositive 3 : inverser uniquement l'échelle numérique horizontale.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Inverser un axe peut aussi déplacer l’axe perpendiculaire du côté opposé du tracé. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) contrôle où l’autre axe croise l’axe en cours de configuration. Dans la diapositive 2, en l’appelant avec `CrossesType::Maximum` sur l’axe de catégorie inversé, l’axe de valeur horizontal reste en bas. Pour un point de croisement spécifique, utilisez [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Vérifiez les paramètres de croisement lors du changement de direction, surtout si le diagramme possède déjà un point de croisement personnalisé. Appelez `setPlotOrderReversed` avec `false` pour rétablir la direction de tracé normale ; les paramètres de croisement sont séparés.

| Ordre normal (diapositive 1) | Catégories inversées (diapositive 2) | Valeurs inversées (diapositive 3) |
| --- | --- | --- |
| ![Diagramme à barres horizontales avec ordre normal des axes de catégorie et de valeur](axis-order-normal.png) | ![Diagramme à barres horizontales avec catégories affichées de haut en bas](axis-order-categories-reversed.png) | ![Diagramme à barres horizontales avec un axe de valeur inversé et zéro à droite](axis-order-values-reversed.png) |
| Les catégories s'étendent du bas vers le haut ; les valeurs augmentent de gauche à droite. | Planification, Développement et Test s'étendent du haut vers le bas. Les valeurs et l'ordre des lignes du classeur restent inchangés. | Les catégories conservent leur ordre normal ; les valeurs augmentent de droite à gauche. L'axe de catégorie croise à zéro à droite. |

## **Désactiver l'axe vertical pour les graphiques en courbes**

Appelez [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) avec `false` sur l’axe vertical pour le masquer. L’exemple crée un diagramme en courbes avec les données par défaut et l’enregistre avec l’axe vertical masqué.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Désactiver l'axe horizontal pour les graphiques en courbes**

Appelez [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) avec `false` sur l’axe horizontal pour le masquer. L’exemple crée un diagramme en courbes avec les données par défaut et l’enregistre avec l’axe horizontal masqué.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Modifier un axe de catégorie**

Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) pour choisir un axe de catégorie date ou texte. Cet exemple nécessite `ExistingChart.pptx`, avec un diagramme comme première forme de la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il change l’axe horizontal en axe de date. En appelant [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) avec `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) avec `1`, et [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) avec `TimeUnitType::Months`, les graduations majeures sont placées à des intervalles d’un mois.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Contrôler les intervalles d'étiquettes d'axe de catégorie**

Lorsque le diagramme possède de nombreuses catégories, réduisez le nombre d’étiquettes d’axe visibles sans supprimer les catégories ni les points de données. Appelez [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) avec `false`, puis transmettez l’intervalle de catégorie souhaité à [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Pour des catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Étiquettes affichées dans l'exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, … Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, … Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, … Catégorie 22 |

Un intervalle de `3` affiche chaque troisième étiquette, laissant deux étiquettes masquées entre les étiquettes affichées. Cela ne supprime pas les colonnes correspondantes. L’espacement automatique choisit un intervalle en fonction de l’espace disponible ; il n’affiche pas nécessairement chaque étiquette.

Les marques de graduation ont des contrôles séparés. Appelez [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) avec `false` et utilisez [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) pour définir leur intervalle. Par exemple, `1` maintient une marque de graduation à chaque intervalle de catégorie tandis que les étiquettes n’apparaissent que toutes les trois catégories. Utilisez [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) avec un style visible afin de pouvoir voir le résultat. Le fait d’appeler à nouveau le réglage d’espacement automatique avec `true` laisse le diagramme choisir cet intervalle de nouveau.

L’exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement manuel des étiquettes avec marques de graduation indépendantes, et restauration de l’espacement automatique. Les deux copies conservent les données du diagramme d’origine. Aucune présentation d’entrée n’est requise. Le texte des étiquettes horizontales rend la différence de densité facile à voir.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Diapositive 2 : afficher chaque troisième étiquette, mais conserver une marque de graduation pour chaque catégorie.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Diapositive 3 : laisser le diagramme choisir à nouveau les deux intervalles.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Espacement automatique (diapositive 1)** : dans ce rendu, chaque deuxième étiquette de catégorie est affichée et se renvoie sur deux lignes. Le résultat automatique peut varier selon la taille du diagramme, les polices et le moteur de rendu.

![Espacement automatique des étiquettes de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2)** : chaque troisième étiquette est affichée sur une ligne, tandis que les marques de graduation restent à chaque intervalle de catégorie. Toutes les 24 colonnes, y compris celles sans étiquettes, restent visibles avec les mêmes valeurs. La diapositive 3 restaure l’apparence automatique présentée ci‑dessus.

![Intervalle d'étiquette de catégorie manuel de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir l'axe et l'intervalle corrects**

Utilisez cet intervalle de comptage de catégories pour un axe de catégorie texte, tel que l’axe de catégorie d’un diagramme en colonnes, en lignes, en aires ou à barres. Dans un diagramme en colonnes, il s’agit de l’axe horizontal. Dans un diagramme à barres horizontales, l’axe de catégorie est vertical, donc appliquez ces paramètres à l’axe renvoyé par [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). L’espacement des marques de graduation s’applique également à un axe de séries dans les diagrammes qui en possèdent un.

N’utilisez pas l’espacement des étiquettes de catégorie pour définir l’échelle numérique d’un axe de valeur. Sur un axe de valeur, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) spécifie une différence de valeurs : par exemple, une unité majeure de `10` produit des graduations à 0, 10, 20, etc. lorsque l’axe démarre à zéro. Un intervalle d’étiquette de catégorie de `3` compte simplement les positions de catégorie, indépendamment de leurs valeurs de données. Les diagrammes de dispersion et à bulles utilisent des axes de valeur plutôt qu’un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures basées sur le temps et des échelles comme décrit dans [Modifier un axe de catégorie](#modifier-un-axe-de-catégorie).

## **Définir le format de date pour les valeurs d'axe de catégorie**

L’exemple remplace les données du diagramme par défaut par quatre valeurs annuelles. Les dates sont stockées comme nombres de série OLE Automation dans la première feuille de calcul (indice `0`), calculées comme le nombre de jours depuis le 30 décembre 1899 pour ces dates. Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) avec `CategoryAxisType::Date`, appelez [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) avec `false`, et transmettez `yyyy` à [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) afin que les étiquettes de catégorie affichent les années sur quatre chiffres indépendamment du format de cellule.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir un angle de rotation pour le titre d'un axe de graphique**

Appelez [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) avec `true` sur l’axe vertical, fournissez le texte du titre, et utilisez [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) pour faire pivoter le titre. L’angle est mesuré en degrés ; cet exemple enregistre un diagramme en colonnes avec le titre de l’axe de valeur tourné de 90 degrés.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la position de l'axe sur un axe de catégorie ou de valeur**

Utilisez [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) pour contrôler si l’axe de valeur croise l’axe de catégorie entre les catégories ou aux marques de graduation des catégories. Ce réglage s’applique aux axes de catégorie. L’exemple le définit sur `true` pour l’axe de catégorie horizontal d’un diagramme en colonnes et enregistre le résultat.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir l'unité d'affichage sur un axe de valeur de graphique**

Utilisez [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) pour mettre à l’échelle les libellés d’un axe de valeur sans modifier les données sous‑jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) défini sur `Millions`, une valeur de 60 000 000 s’affiche comme 60. L’exemple crée un diagramme en colonnes et applique l’unité d’affichage millions à son axe vertical.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Configurer un axe de valeur logarithmique**

Un axe de valeur logarithmique est utile lorsque les valeurs positives couvrent plusieurs ordres de grandeur. Par exemple, un service peut recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent très proches les unes des autres près de zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Appelez [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) avec `true` sur l’axe de valeur et utilisez [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) pour choisir la base. Cela modifie la façon dont les valeurs existantes sont affichées ; cela ne change pas les données ni n’ajoute une ligne de tendance logarithmique. Une ligne de tendance représente une relation ajustée aux données et constitue une fonctionnalité distincte.

### **Choisir l'axe de valeur et la base**

Pour un diagramme en lignes ou en colonnes, l’axe de valeur est renvoyé par [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Pour un diagramme à barres horizontales, il est renvoyé par [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Les diagrammes de dispersion et à bulles possèdent deux axes de valeur, choisissez donc l’axe horizontal pour les valeurs X, l’axe vertical pour les valeurs Y, ou les deux. N’appliquez pas le redimensionnement logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les diagrammes PPTX, utilisez une base comprise entre `2` et `1000` inclusivement ; les bases fractionnaires comme `2.5` sont également prises en charge. Avec la base `10`, les puissances successives telles que 10, 100, 1 000 et 10 000 sont espacées de manière égale.

### **Comparer les échelles linéaire et logarithmique**

L’exemple autonome suivant crée un diagramme en lignes avec les cinq décomptes de requêtes sur la première diapositive, puis duplique cette diapositive et active un axe de valeur logarithmique base‑10 sur la seconde. Les deux diapositives conservent les mêmes données.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Conserver la première diapositive lineaire et ne modifier que l'echelle de l'axe de valeurs de la copie.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Échelle linéaire (diapositive 1)** : des distances verticales égales représentent des différences égales dans les décomptes de requêtes. La valeur la plus élevée domine le diagramme, rendant les petites valeurs difficiles à distinguer.

![Diagramme linéaire dans PowerPoint montrant cinq décomptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2)** : des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, de sorte que les points forment une droite ascendante sur l’échelle base‑10. Les libellés d’axe affichent toujours les décomptes de requêtes d’origine.

![Les mêmes cinq décomptes de requêtes dans PowerPoint sur un axe de valeur logarithmique base‑10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l’activer. Si les valeurs zéro ou négatives sont significatives, conservez une échelle linéaire ou affichez‑les séparément. Si leur exclusion est appropriée pour l’analyse, expliquez‑lui l’omission. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela changerait le sens des données. Toute valeur minimale ou maximale configurée manuellement pour un axe logarithmique doit également être positive.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axe) ?**

Utilisez [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) pour sélectionner le comportement du croisement. Pour spécifier une valeur numérique de croisement, utilisez [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Ces réglages vous permettent de déplacer le croisement de l’axe vers une ligne de base appropriée.

**Comment positionner les étiquettes de graduation par rapport à l'axe ?**

Appelez [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) en utilisant [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/) : `Low`, `High`, `NextTo` ou `None`. Pour contrôler les marques de graduation elles‑mêmes, utilisez [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) ou [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/) ; ceux‑ci sont distincts du positionnement des étiquettes.