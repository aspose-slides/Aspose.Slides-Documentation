---
title: Gérer les étiquettes de données de graphique dans les présentations avec PHP
linktitle: Étiquette de données
type: docs
url: /fr/php-java/chart-data-label/
keywords:
- graphique
- "étiquette de données"
- "précision des données"
- pourcentage
- "distance de l'étiquette"
- "position de l'étiquette"
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à ajouter et à formater les étiquettes de données de graphique dans les présentations PowerPoint à l'aide d'Aspose.Slides pour PHP via Java pour des diapositives plus attrayantes."
---
## **Introduction**

Les étiquettes de données affichent des informations sur les séries de graphiques et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des étiquettes, contrôler les étiquettes au‑delà du maximum de l’axe, ajuster l’espacement des étiquettes de l’axe des catégories et positionner les étiquettes des graphiques circulaires.

## **Set Data Precision in Chart Data Labels**

Utilisez [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/) pour formater les valeurs des séries. Cet exemple crée un graphique en courbes avec des données par défaut, affiche son tableau de données et active les étiquettes de valeurs pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous‑jacentes.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->setNumberFormatOfValues("#,##0.00");
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("PrecisionOfDatalabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Display Percentage as Labels**

Pour un graphique à colonnes empilées, calculez chaque valeur en pourcentage du total de sa catégorie et affectez le texte au cadre de texte renvoyé par [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/). Cet exemple utilise les données de graphique par défaut et affiche les pourcentages avec deux décimales dans une police de 8 points. Les catégories dont le total est zéro sont ignorées pour éviter une division par zéro. Recalculez le texte personnalisé des étiquettes si les données du graphique changent.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\Portion;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);

    $categoryCount = java_values($chart->getChartData()->getCategories()->size());
    $categoryTotals = array_fill(0, $categoryCount, 0.0);
    for ($k = 0; $k < $categoryCount; $k++) {
        for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
            $series = $chart->getChartData()->getSeries()->get_Item($i);
            $pointValue = java_values($series->getDataPoints()->get_Item($k)->getValue()->getData());
            $categoryTotals[$k] += $pointValue;
        }
    }

    for ($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()); $x++) {
        $series = $chart->getChartData()->getSeries()->get_Item($x);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);

        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $label = $series->getDataPoints()->get_Item($j)->getLabel();
            if ($categoryTotals[$j] == 0) {
                continue;
            }

            $pointValue = java_values($series->getDataPoints()->get_Item($j)->getValue()->getData());
            $dataPointPercent = ($pointValue / $categoryTotals[$j]) * 100;

            $portion = new Portion();
            $portion->setText(sprintf("%.2F %%", $dataPointPercent));
            $portion->getPortionFormat()->setFontHeight(8);

            $label->getTextFrameForOverriding()->setText("");
            $paragraph = $label->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
            $paragraph->getPortions()->add($portion);

            $label->getDataLabelFormat()->setShowValue(true);
            $label->getDataLabelFormat()->setShowSeriesName(false);
            $label->getDataLabelFormat()->setShowPercentage(false);
            $label->getDataLabelFormat()->setShowLegendKey(false);
            $label->getDataLabelFormat()->setShowCategoryName(false);
            $label->getDataLabelFormat()->setShowBubbleSize(false);
        }
    }

    $presentation->save("DisplayPercentageAsLabels_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Set Percentage Sign with Chart Data Labels**

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/) pour afficher les pourcentages. Passez `false` à [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) pour appliquer le format de l’étiquette indépendamment des cellules source.

Cet exemple crée un graphique à colonnes empilées à 100 % avec des séries rouge et bleue sur quatre catégories. Chaque paire de valeurs s’additionne à 1. Le format d’étiquette `0.0%` affiche 0,30 comme 30,0 %, tandis que l’axe vertical utilise deux décimales. Les deux séries utilisent un texte d’étiquette blanc de 10 points.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    for ($i = 0; $i < 4; $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    $colors = java("java.awt.Color");
    $seriesNames = [ "Reds", "Blues" ];
    $seriesColors = [ $colors->RED, $colors->BLUE ];
    $values = [ [ 0.30, 0.50, 0.80, 0.65 ], [ 0.70, 0.50, 0.20, 0.35 ] ];

    for ($i = 0; $i < count($seriesNames); $i++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $i + 1, $seriesNames[$i]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());
        for ($j = 0; $j < 4; $j++) {
            $valueCell = $workbook->getCell($worksheetIndex, $j + 1, $i + 1, $values[$i][$j]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        $series->getFormat()->getFill()->setFillType(FillType::Solid);
        $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColors[$i]);

        $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(false);
        $labelFormat->setNumberFormat("0.0%");
        $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(10);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($colors->WHITE);
    }

    $presentation->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Read the Actual Text of Data Labels**

Utilisez [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) pour récupérer le texte généré par les paramètres d’une étiquette de données. Cela est utile lors de l’extraction d’étiquettes pour des rapports, la recherche de contenu dans une présentation ou la validation de graphiques générés. Dans l’exemple ci‑dessous, le [format d’étiquette de données](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) par défaut combine le nom de chaque catégorie, le nom de la série et la valeur. Un point formate sa valeur en pourcentage, et un autre utilise un texte personnalisé provenant de [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $firstCategoryCell = $workbook->getCell(0, 1, 0, "Q1");
    $chart->getChartData()->getCategories()->add($firstCategoryCell);
    $secondCategoryCell = $workbook->getCell(0, 2, 0, "Q2");
    $chart->getChartData()->getCategories()->add($secondCategoryCell);

    $northSeriesCell = $workbook->getCell(0, 0, 1, "North");
    $north = $chart->getChartData()->getSeries()->add($northSeriesCell, $chart->getType());
    $northFirstValueCell = $workbook->getCell(0, 1, 1, 0.25);
    $north->getDataPoints()->addDataPointForBarSeries($northFirstValueCell);
    $northSecondValueCell = $workbook->getCell(0, 2, 1, 0.75);
    $north->getDataPoints()->addDataPointForBarSeries($northSecondValueCell);

    $southSeriesCell = $workbook->getCell(0, 0, 2, "South");
    $south = $chart->getChartData()->getSeries()->add($southSeriesCell, $chart->getType());
    $southFirstValueCell = $workbook->getCell(0, 1, 2, 0.40);
    $south->getDataPoints()->addDataPointForBarSeries($southFirstValueCell);
    $southSecondValueCell = $workbook->getCell(0, 2, 2, 0.60);
    $south->getDataPoints()->addDataPointForBarSeries($southSecondValueCell);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        $format = $series->getLabels()->getDefaultDataLabelFormat();
        $format->setShowCategoryName(true);
        $format->setShowSeriesName(true);
        $format->setShowValue(true);
    }

    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $north->getLabels()->get_Item(1)->getDataLabelFormat()->setNumberFormat("0%");
    $south->getLabels()->get_Item(0)->getTextFrameForOverriding()->setText("Reviewed");

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++) {
        $series = $chart->getChartData()->getSeries()->get_Item($i);
        for ($j = 0; $j < java_values($series->getDataPoints()->size()); $j++) {
            $point = $series->getDataPoints()->get_Item($j);
            $label = $point->getLabel();
            if (!java_values($label->isVisible())) {
                continue;
            }

            echo "Value: " . java_values($point->getValue()->getData()) . "; label: " . java_values($label->getActualLabelText()) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Le nombre stocké dans un point de données reste `0.75`, même si son étiquette affiche `75 %` avec les noms de catégorie et de série. Le texte personnalisé remplace le texte d’étiquette généré. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) renvoie la chaîne d’étiquette résultante dans les deux cas. Vérifiez séparément [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/), comme indiqué ci‑dessus, lorsque vous ne souhaitez extraire que les étiquettes visibles.

## **Control Data Labels Beyond the Axis Maximum**

Lorsque vous limitez manuellement la plage d’un axe, certains points de données peuvent dépasser son maximum. Utilisez [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/) pour contrôler si leurs étiquettes de données sont affichées. Ce paramètre modifie la visibilité des étiquettes ; il ne modifie pas la plage de l’axe ni les valeurs sous‑jacentes des données.

L’exemple ci‑dessus crée un graphique à colonnes groupées 2D avec des valeurs de 60 et 120. Il transmet `false` à [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) et fixe le maximum à 100 avec [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) sur l’axe vertical. La première diapositive autorise les étiquettes au‑delà du maximum ; une copie de cette diapositive les désactive. Les deux diapositives sont enregistrées dans `DataLabelsOverMaximum.pptx`.

Activez les étiquettes de valeurs avec [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/). Le paramètre au niveau du graphique n’active pas l’affichage des valeurs par lui‑même et ne remplace pas la désactivation de l’affichage des valeurs d’une étiquette individuelle. Cet exemple active les valeurs pour l’ensemble de la série et utilise [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/) pour placer les étiquettes à l’extrémité extérieure de chaque colonne.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $firstCategory = $workbook->getCell(0, 1, 0, "Within range");
    $secondCategory = $workbook->getCell(0, 2, 0, "Above maximum");

    $chart->getChartData()->getCategories()->add($firstCategory);
    $chart->getChartData()->getCategories()->add($secondCategory);

    $seriesName = $workbook->getCell(0, 0, 1, "Values");
    $series = $chart->getChartData()->getSeries()->add($seriesName, $chart->getType());

    $firstValue = $workbook->getCell(0, 1, 1, 60);
    $secondValue = $workbook->getCell(0, 2, 1, 120);

    $series->getDataPoints()->addDataPointForBarSeries($firstValue);
    $series->getDataPoints()->addDataPointForBarSeries($secondValue);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);

    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(100);
    $chart->setShowDataLabelsOverMaximum(true);

    $secondSlide = $presentation->getSlides()->addClone($slide);
    $secondChart = $secondSlide->getShapes()->get_Item(0);
    $secondChart->setShowDataLabelsOverMaximum(false);

    $presentation->save("DataLabelsOverMaximum.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Les images suivantes montrent les diapositives enregistrées rendues par Microsoft PowerPoint. Avec `true`, l’étiquette **120** est visible à la limite supérieure ; avec `false`, elle est cachée. L’étiquette **60** reste visible, le maximum de l’axe reste à **100**, et le second point de données reste **120** dans les deux cas.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Graphique PowerPoint affichant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-true.png) | ![Graphique PowerPoint masquant l’étiquette de valeur 120 avec un maximum d’axe de 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Cet exemple utilise un graphique à colonnes 2D avec un axe des valeurs. Les graphiques sans axe des valeurs, tels que les graphiques circulaires et en anneau, n’ont pas de maximum d’axe à limiter de cette manière.
{{% /alert %}}

## **Set Label Distance from an Axis**

Utilisez [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/) pour contrôler la distance entre les étiquettes de l’axe des catégories et l’axe. La valeur est un pourcentage de la taille maximale de police des étiquettes de l’axe. Cet exemple crée un graphique à colonnes groupées et définit le décalage des étiquettes de l’axe horizontal à 500. Ce paramètre affecte les étiquettes de l’axe des catégories plutôt que les étiquettes attachées aux points de données individuels.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $chart->getAxes()->getHorizontalAxis()->setLabelOffset(500);

    $presentation->save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Adjust Label Location**

Sur un graphique circulaire, ajustez les positions des étiquettes de données pour améliorer l’espacement et laisser de la place aux lignes directrices.

Cet exemple affiche la valeur du premier point de données, place son étiquette à l’extérieur de la tranche et ajuste ses décalages horizontal et vertical à l’aide de [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) et [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/). Ces décalages sont relatifs à la largeur et à la hauteur du graphique, respectivement.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();

    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition::OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Graphique circulaire avec une position d’étiquette de données ajustée](pie-chart-adjusted-label.png)

## **Format Leader Lines**

Lorsque les étiquettes d’un graphique circulaire se trouvent à l’extérieur de leurs tranches, les lignes directrices aident les lecteurs à associer chaque valeur à la tranche correcte. Une couleur contrastée et une ligne légèrement plus épaisse peuvent faciliter le suivi de ces connexions, tandis que la transparence et un style pointillé maintiennent les lignes visuellement discrètes.

Utilisez [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/) pour formater les lignes directrices au niveau de la collection d’étiquettes de données de la série. Les paramètres dans `$series->getLabels()->getLeaderLinesFormat()->getLine()` s’appliquent à la collection, plutôt qu’à une étiquette individuelle.

Cet exemple crée un graphique circulaire avec des données par défaut, affiche les valeurs à l’extérieur des tranches et active [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/). Il déplace deux étiquettes plus loin de leurs tranches à l’aide des décalages [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) et [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/), exprimés en fractions de la largeur et de la hauteur du graphique. Aucune présentation d’entrée n’est requise.

Le [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) de la ligne définit une couleur bleue unie avec une valeur alpha de 191 sur 255, ce qui donne environ 25 % de transparence. [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) définit l’épaisseur à 2 points, et [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) rend la ligne pointillée.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 80, 50, 560, 400);
    $chart->setLegend(false);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
    $labelFormat->setShowValue(true);
    $labelFormat->setPosition(LegendDataLabelPosition::OutsideEnd);
    $labelFormat->setShowLeaderLines(true);

    // Déplacer deux étiquettes plus loin de leurs tranches.
    $series->getLabels()->get_Item(0)->setX(0.10);
    $series->getLabels()->get_Item(0)->setY(-0.05);
    $series->getLabels()->get_Item(1)->setX(-0.10);
    $series->getLabels()->get_Item(1)->setY(0.05);

    $line = $series->getLabels()->getLeaderLinesFormat()->getLine();
    $line->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 30, 90, 160, 191);
    $line->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $line->setWidth(2);
    $line->setDashStyle(LineDashStyle::Dash);

    $presentation->save("FormattedLeaderLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L’activation des lignes directrices ne garantit pas qu’une ligne apparaisse pour chaque étiquette. La visibilité dépend du placement des étiquettes et du comportement de mise en page du graphique. Dans cet exemple, les deux étiquettes déplacées ont des lignes directrices visibles ; les étiquettes qui restent proches de leurs tranches n’en ont pas besoin.

L’image suivante montre le fichier `FormattedLeaderLines.pptx` enregistré, rendu avec Aspose.Slides :

![Graphique circulaire avec des lignes directrices bleues, semi‑transparentes et pointillées reliant deux étiquettes extérieures à leurs tranches](formatted-leader-lines.png)

## **Add Multiple Rows of Data Labels Above a Column Chart**

Cet exemple crée un graphique à colonnes avec deux rangées d’étiquettes de données au‑dessus de la zone de tracé. La série A affiche les colonnes visibles, tandis que les séries B et C fournissent les étiquettes supplémentaires. Leurs colonnes sont cachées en supprimant le remplissage et le contour. La méthode [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) aligne les trois séries sur les mêmes centres de catégorie.

Les paramètres du [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) réservent de l’espace pour les rangées d’étiquettes. Après que [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) calcule les positions par défaut, [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) et [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) conservent l’alignement horizontal et appliquent des décalages verticaux pour organiser les étiquettes en deux rangées. Les nombres restent des étiquettes de données liées aux valeurs des séries ; seuls les en‑têtes de rangée sont des formes de texte distinctes.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LegendDataLabelPosition;
use aspose\slides\LayoutTargetType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$colors = java("java.awt.Color");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 40, 40, 640, 200);
    $chart->setTitle(false);
    $chart->setLegend(false);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categories = [ "North", "South", "East", "West" ];
    $seriesNames = [ "Series A", "Series B", "Series C" ];
    $seriesValues = [
        [ 35, 42, 28, 47 ],
        [ 22, 31, 19, 26 ],
        [ 12, 16, 14, 18 ]
    ];
    
    for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
        $categoryCell = $workbook->getCell(0, $categoryIndex + 1, 0, $categories[$categoryIndex]);
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $seriesCell = $workbook->getCell(0, 0, $seriesIndex + 1, $seriesNames[$seriesIndex]);
        $series = $chart->getChartData()->getSeries()->add($seriesCell, ChartType::ClusteredColumn);

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $valueCell = $workbook->getCell(0, $categoryIndex + 1, $seriesIndex + 1, $seriesValues[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }

        if ($seriesIndex > 0) {
            // Masquer les colonnes de B et C, mais conserver leurs étiquettes de données.
            $series->getFormat()->getFill()->setFillType(FillType::NoFill);
            $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
            $labelFormat = $series->getLabels()->getDefaultDataLabelFormat();
            $labelFormat->setShowValue(true);
            $labelFormat->getTextFormat()->getPortionFormat()->setFontHeight(12);
            $labelFill = $labelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
            $labelFill->setFillType(FillType::Solid);
            $labelFill->getSolidFillColor()->setColor($colors->BLACK);
            $labelFormat->setPosition(LegendDataLabelPosition::InsideBase);
        }
    }

    // Align all three series with the same category centers.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Use fewer gridlines for this compact example.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Reserve space above the plot for two rows of data labels.
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $chart->getPlotArea()->setX(0.15);
    $chart->getPlotArea()->setY(0.32);
    $chart->getPlotArea()->setWidth(0.80);
    $chart->getPlotArea()->setHeight(0.48);
    $chart->validateChartLayout();

    $chartX = java_values($chart->getX());
    $chartY = java_values($chart->getY());
    $chartHeight = java_values($chart->getHeight());
    for ($seriesIndex = 1; $seriesIndex < count($seriesNames); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $rowTop = $seriesIndex == 1 ? 0.15 : 0.03;

        for ($categoryIndex = 0; $categoryIndex < count($categories); $categoryIndex++) {
            $dataLabel = $series->getDataPoints()->get_Item($categoryIndex)->getLabel();
            // Conserver la position horizontale par défaut. Y est un décalage depuis
            // la position d'étiquette par défaut, exprimé comme une fraction de la hauteur du graphique.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // Only the row heading is a separate text shape.
        $rowHeading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $chartX, $chartY + $rowTop * $chartHeight, 85, 18);
        $rowHeading->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $rowHeading->addTextFrame($seriesNames[$seriesIndex]);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginTop(0);
        $rowHeading->getTextFrame()->getTextFrameFormat()->setMarginBottom(0);
        $headingFormat = $rowHeading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $headingFormat->setFontHeight(12);
        $headingFormat->getFillFormat()->setFillType(FillType::Solid);
        $headingFormat->getFillFormat()->getSolidFillColor()->setColor($colors->BLACK);
    }

    $presentation->save("multiple-rows-of-labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Graphique à colonnes avec deux rangées d’étiquettes de données au‑dessus de la zone de tracé](multiple-rows-of-labels.png)

## **FAQ**

**Comment puis‑je empêcher les étiquettes de données de se chevaucher sur des graphiques denses ?**

Combinez le placement automatique des étiquettes, les lignes directrices et la réduction de la taille de police ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les valeurs extrêmes ou les points clés.

**Comment puis‑je désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**

Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment puis‑je garantir un style d’étiquette cohérent lors de l’exportation vers PDF/images ?**

Définissez explicitement la famille et la taille de la police et vérifiez que la police est disponible dans l’environnement de rendu pour éviter le recours à une police de secours.