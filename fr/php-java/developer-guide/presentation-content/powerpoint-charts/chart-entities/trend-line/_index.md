---
title: Ajouter des lignes de tendance aux graphiques de présentation en PHP
linktitle: Ligne de tendance
type: docs
url: /fr/php-java/trend-line/
keywords:
- graphique
- ligne de tendance
- ligne de tendance exponentielle
- ligne de tendance linéaire
- ligne de tendance logarithmique
- ligne de tendance moyenne mobile
- ligne de tendance polynomiale
- ligne de tendance puissance
- ligne de tendance personnalisée
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Ajoutez rapidement et personnalisez des lignes de tendance dans les graphiques PowerPoint avec Aspose.Slides pour PHP via Java — un guide pratique pour captiver votre audience."
---
## **Aperçu**

Cet article explique comment ajouter des lignes de tendance aux graphiques de présentation en utilisant Aspose.Slides. Il montre comment créer un graphique, ajouter des lignes de tendance aux séries du graphique, et travailler avec plusieurs types de lignes de tendance, notamment exponentielle, linéaire, logarithmique, moyenne mobile, polynomiale et puissance.

Il décrit également comment ajouter une ligne personnalisée à un graphique en insérant une forme de ligne, et comprend une courte FAQ sur les valeurs de projection avant et arrière des lignes de tendance et sur la préservation des lignes de tendance lors de l'exportation en PDF ou SVG et lors du rendu des graphiques en images.

## **Ajouter une ligne de tendance**

Utilisez [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) pour ajouter une ligne de tendance à une série de graphique, en sélectionnant son type avec [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). L'exemple crée un graphique à colonnes groupées avec des données par défaut et ajoute deux lignes de tendance à chacune de ses trois séries.

La ligne de tendance exponentielle masque son équation et sa valeur R² via [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) et [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), tandis que la ligne de tendance linéaire est rouge. La ligne de tendance logarithmique utilise [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) pour une étiquette personnalisée. La moyenne mobile utilise un [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) de trois points de données et un [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/) personnalisé.

La ligne de tendance polynomiale a un ordre de trois, défini via [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), et s'étend d'une catégorie vers l'avant grâce à [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). La ligne de tendance puissance s'étend d'une catégorie vers l'arrière via [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir l'interception d'une ligne de tendance**

Utilisez [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) pour fixer la valeur Y d'une ligne de tendance à X = 0. Ce paramètre est pris en charge pour les lignes de tendance linéaires, exponentielles et polynomiales.

Par exemple, un modèle de coût de production peut devoir commencer à des coûts fixes connus de 100, même lorsque des mesures à des volumes de production non nuls suggèrent une base différente. Pour une ligne de tendance linéaire, fixer l'interception contraint l'équation `y = ax + b` à `b = 100` ; la pente est ajustée aux données sous cette contrainte. Cela ne déplace pas simplement une ligne déjà ajustée. Les paramètres de croisement des axes contrôlent où les axes du graphique se rencontrent, pas les coefficients de la ligne de tendance ajustée.

L'exemple suivant crée un graphique de dispersion (XY) avec des volumes de production de 1 à 4 et des coûts de 170, 200, 230 et 260. Il enregistre le graphique avec l'interception automatique par défaut, définit l'interception à 100, et enregistre un second PPTX. Les deux fichiers ne diffèrent que par le paramètre d'interception. La ligne de tendance affiche son équation et s'étend jusqu'à X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Avec le calcul automatique, ces données produisent `y = 30x + 140`. Fixer l'interception à 100 produit plutôt environ `y = 43,33x + 100` : la valeur ajustée à zéro correspond à la base connue, tandis que la ligne ne passe plus par chaque point de données.

| Interception automatique | Interception fixe de 100 |
| --- | --- |
| ![Ligne de tendance linéaire avec une interception calculée automatiquement de 140](intercept-automatic.png) | ![Ligne de tendance linéaire avec une interception fixe de 100](intercept-fixed.png) |

Les deux images utilisent les mêmes données et les mêmes échelles d'axes. Les lignes de tendance sont étendues jusqu'à X = 0 pour montrer leurs interceptions.

Par défaut, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) renvoie `NaN`, qui représente une interception non spécifiée plutôt que zéro. L'interception est alors calculée automatiquement à partir des données.

## **Ajouter une ligne personnalisée**

Une ligne personnalisée est une forme dessinée au-dessus du graphique plutôt qu'une ligne de tendance calculée à partir des données de la série. Cet exemple utilise [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) pour ajouter une ligne horizontale à la diapositive au-dessus du graphique. La position de la ligne est spécifiée en coordonnées de diapositive, mesurées en points, de sorte qu'elle débute au bord gauche du graphique et se situe à mi‑hauteur du graphique. Sa largeur correspond à celle du graphique. Le [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) donne à la ligne une couleur rouge unie.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Que signifient « avant » et « arrière » pour une ligne de tendance ?**

Ce sont les longueurs de la ligne de tendance projetées en avant ou en arrière : pour les graphiques de dispersion (XY) — en unités d'axe ; pour les graphiques non‑dispersion — en nombre de catégories. Seules les valeurs non négatives sont autorisées.

**La ligne de tendance sera-t-elle préservée lors de l'exportation de la présentation en PDF ou SVG, ou lors du rendu d’une diapositive en image ?**

Oui. Aspose.Slides convertit les présentations en [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) ou [SVG](/slides/fr/php-java/render-a-slide-as-an-svg-image/) et rend les graphiques en images ; les lignes de tendance, en tant que partie du graphique, sont préservées pendant ces opérations. Une méthode est également disponible pour [exporter une image du graphique](/slides/fr/php-java/create-shape-thumbnails/) lui‑même.