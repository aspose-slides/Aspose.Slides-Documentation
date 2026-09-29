---
title: Beheer diagramgegevenslabels in presentaties met PHP
linktitle: Gegevenslabel
type: docs
url: /nl/php-java/chart-data-label/
keywords:
- diagram
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labellocatie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u diagramgegevenslabels kunt toevoegen en opmaken in PowerPoint-presentaties met Aspose.Slides voor PHP via Java voor meer boeiende dia's."
---
## **Inleiding**

Gegevenslabels tonen informatie over diagramreeksen en individuele gegevenspunten, waardoor lezers waarden kunnen identificeren en het diagram beter begrijpen. Dit artikel beschrijft hoe je waarden kunt formatteren, percentages kunt weergeven, labeltekst kunt lezen, labels kunt beheersen die buiten de asmaximum vallen, de afstand tussen labels op de categorische as kunt aanpassen en labels op cirkeldiagrammen kunt positioneren.

## **Precisie van gegevens instellen in diagram‑gegevenslabels**

Gebruik [setNumberFormatOfValues](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) om reekswerte te formatteren. Deze voorbeeldcode maakt een lijndiagram met standaardgegevens, toont de gegevenstabel en schakelt waardelabels in voor de eerste reeks. Het formaat `#,##0.00` toont een duizendtallen‑scheidingsteken en twee decimalen zonder de onderliggende waarden te wijzigen.

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

## **Percentage weergeven als labels**

Voor een gestapeld kolomdiagram bereken je elke waarde als een percentage van het totale bedrag van de categorie en ken je de tekst toe aan het tekstramwerk dat wordt geretourneerd door [getTextFrameForOverriding](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabel/#getTextFrameForOverriding). Dit voorbeeld gebruikt de standaarddiagramgegevens en toont percentages met twee decimalen in een lettertype van 8 pt. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst wanneer de diagramgegevens wijzigen.

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

## **Percentage‑teken instellen met diagram‑gegevenslabels**

Wanneer waarden als breuken worden opgeslagen, gebruik je [setNumberFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat/#setNumberFormat) om percentages weer te geven. Geef `false` door aan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) om het label‑formaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapeld kolomdiagram met rode en blauwe reeksen over vier categorieën. Elk paar waarden telt op tot 1. Het labelformaat `0.0%` toont 0.30 als 30.0 %, terwijl de verticale as twee decimalen gebruikt. Beide reeksen gebruiken witte labeltekst van 10 pt.

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

## **De feitelijke tekst van gegevenslabels lezen**

Gebruik [getActualLabelText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabel/#getActualLabelText) om de tekst op te halen die door de instellingen van een gegevenslabel wordt gegenereerd. Dit is nuttig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie‑inhoud of het valideren van gegenereerde diagrammen. In het voorbeeld hieronder combineert het standaard [data label format](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat/) de categorienaam, reeksennaam en waarde. Eén punt formatteert de waarde als percentage, een ander punt gebruikt aangepaste tekst van [getTextFrameForOverriding](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Het getal dat in een gegevenspunt is opgeslagen blijft `0.75`, ook al toont het label `75%` samen met de categorienaam en reeksennaam. Aangepaste tekst vervangt de gegenereerde labeltekst. [getActualLabelText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabel/#getActualLabelText) retourneert in beide gevallen de resulterende label‑string. Controleer [isVisible](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabel/#isVisible) apart, zoals hierboven getoond, wanneer je alleen zichtbare labels wilt extraheren.

## **Gegevenslabels beheren buiten het asmaximum**

Wanneer je handmatig een asbereik beperkt, kunnen sommige gegevenspunten boven het maximum uitkomen. Gebruik [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) om te bepalen of hun gegevenslabels worden weergegeven. Deze instelling wijzigt de zichtbaarheid van labels; ze verandert niet het as‑bereik of de onderliggende waarden.

Het onderstaande voorbeeld maakt een 2D gegroepeerd kolomdiagram met waarden van 60 en 120. Het geeft `false` door aan [setAutomaticMaxValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/#setAutomaticMaxValue) en stelt het maximum in op 100 met [setMaxValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/#setMaxValue) op de verticale as. De eerste dia staat labels toe die boven het maximum liggen; een kopie van die dia schakelt ze uit. Beide dia's worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waardelabels in met [setShowValue](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat/#setShowValue). De diagram‑niveau‑instelling activeert geen weergave van waarden op zichzelf en overschrijft niet een individueel label dat al uitgeschakeld is. Dit voorbeeld activeert waarden voor de volledige reeks en gebruikt [setPosition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat/#setPosition) om labels aan het buiten­einde van elke kolom te plaatsen.

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

De volgende afbeeldingen tonen de opgeslagen dia’s zoals gerenderd door Microsoft PowerPoint. Met `true` is het label **120** zichtbaar aan de bovenkant van de as; met `false` is het verborgen. Het label **60** blijft zichtbaar, het asmaximum blijft **100**, en het tweede gegevenspunt blijft **120** in beide gevallen.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dit voorbeeld maakt gebruik van een 2D kolomdiagram met een waardenas. Diagrammen zonder waardenas, zoals taart‑ en ringdiagrammen, hebben geen asmaximum dat op deze manier kan worden beperkt.
{{% /alert %}}

## **Afstand van label tot een as instellen**

Gebruik [setLabelOffset](https://reference.aspose.com/slides/nl/php-java/aspose.slides/axis/#setLabelOffset) om de afstand tussen labels op de categorische as en de as zelf te regelen. De waarde is een percentage van de maximale lettergrootte van de as‑labels. Dit voorbeeld maakt een gegroepeerd kolomdiagram en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt de labels van de categorische as, niet de labels die aan individuele gegevenspunten zijn gekoppeld.

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

## **Labelpositie aanpassen**

Op een taartdiagram pas je de positie van gegevenslabels aan om de onderlinge afstand te verbeteren en ruimte te creëren voor leidende lijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten het segment en past de horizontale en verticale offset aan met [setX](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabel/#setX) en [setY](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabel/#setY). Deze offsets zijn respectievelijk relatief ten opzichte van de diagram‑breedte en -hoogte.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevenslabels overlappen in dichte diagrammen?**

Combineer automatische labelplaatsing, leidende lijnen en een kleinere lettergrootte; verberg indien nodig bepaalde velden (bijvoorbeeld de categorie) of toon alleen labels voor extreme of belangrijke waarden.

**Hoe kan ik labels uitschakelen alleen voor nul‑, negatieve‑ of lege waarden?**

Filter gegevenspunten voordat je labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe zorg ik voor een consistente labelstijl bij export naar PDF/afbeeldingen?**

Stel expliciet het lettertype en de grootte in en controleer dat het lettertype beschikbaar is in de renderomgeving om terugval te voorkomen.