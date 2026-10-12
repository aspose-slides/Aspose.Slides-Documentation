---
title: Beheer grafiekgegevenslabels in presentaties met PHP
linktitle: Gegevenslabel
type: docs
url: /nl/php-java/chart-data-label/
keywords:
- grafiek
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labelpositie
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u grafiekgegevenslabels kunt toevoegen en opmaken in PowerPoint‑presentaties met Aspose.Slides voor PHP via Java voor meer boeiende dia's."
---
## **Inleiding**

Gegevenslabels tonen informatie over grafiekreeksen en individuele gegevenspunten, waardoor lezers waarden kunnen identificeren en de grafiek kunnen begrijpen. Dit artikel legt uit hoe waarden te formatteren, percentages weer te geven, labeltekst te lezen, labels buiten de asmaximale te beheren, de afstand tussen categorielabels aan te passen en labels van cirkeldiagrammen te positioneren.

## **Gegevensprecisie instellen in grafiekgegevenslabels**

Gebruik [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) om reekswerte te formatteren. Dit voorbeeld maakt een lijndiagram met standaardgegevens, toont de gegevenstabel en schakelt waardelabels in voor de eerste reeks. Het formaat `#,##0.00` geeft een duizendtallen scheidingsteken en twee decimalen weer zonder de onderliggende waarden te wijzigen.

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

Voor een gestapeld kolomdiagram bereken je elke waarde als een percentage van het totale aantal van de categorie en wijs je de tekst toe aan het tekstraster dat wordt geretourneerd door [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding). Dit voorbeeld gebruikt de standaardgrafiekgegevens en toont percentages met twee decimalen in een lettertype van 8 punten. Categorieën met een totaal van nul worden overgeslagen om deling door nul te voorkomen. Herbereken de aangepaste labeltekst als de grafiekgegevens wijzigen.

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

## **Percentage-teken instellen met grafiekgegevenslabels**

Wanneer waarden als breuken zijn opgeslagen, gebruik je [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormat) om percentages weer te geven. Geef `false` door aan [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) om het labelformaat onafhankelijk van de broncellen toe te passen.

Dit voorbeeld maakt een 100 % gestapeld kolomdiagram met rode en blauwe reeksen over vier categorieën. Elk waardepaar telt op tot 1. Het labelformaat `0.0%` toont 0.30 als 30,0 %, terwijl de verticale as twee decimalen gebruikt. Beide reeksen gebruiken witte labeltekst van 10 punten.

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

## **Werkelijke tekst van gegevenslabels lezen**

Gebruik [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText) om de tekst op te halen die door de instellingen van een gegevenslabel wordt geproduceerd. Dit is nuttig bij het extraheren van labels voor rapporten, het doorzoeken van presentatie-inhoud of het valideren van gegenereerde diagrammen. In het onderstaande voorbeeld combineert het standaard‑[data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) elke categorienaam, reeksennaam en waarde. Eén punt formatteert zijn waarde als een percentage, en een ander gebruikt aangepaste tekst van [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Het getal dat in een gegevenspunt is opgeslagen blijft `0.75`, zelfs wanneer het label `75%` toont samen met de categorie‑ en reeksennamen. Aangepaste tekst vervangt de gegenereerde labeltekst. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText) retourneert de resulterende label‑string in beide gevallen. Controleer [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#isVisible) apart, zoals hierboven getoond, wanneer je alleen zichtbare labels wilt extraheren.

## **Gegevenslabels buiten de asmaximale beheren**

Wanneer je handmatig een asbereik beperkt, kunnen enkele gegevenspunten de maximumwaarde overschrijden. Gebruik [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) om te bepalen of hun gegevenslabels worden weergegeven. Deze instelling verandert alleen de zichtbaarheid van het label; het wijzigt niet het asbereik of de onderliggende gegevenswaarden.

Het onderstaande voorbeeld maakt een 2D gegroepeerd kolomdiagram met waarden 60 en 120. Het geeft `false` door aan [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setAutomaticMaxValue) en stelt het maximum in op 100 met [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setMaxValue) op de verticale as. De eerste dia staat labels toe buiten het maximum; een kopie van die dia schakelt ze uit. Beide dia's worden opgeslagen in `DataLabelsOverMaximum.pptx`.

Schakel waardelabels in met [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue). De instelling op diagramniveau activeert de weergave van waarden niet op zichzelf en overschrijft niet de individuele instelling van een label. Dit voorbeeld activeert waarden voor de volledige reeks en gebruikt [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setPosition) om labels aan het buitenste einde van elke kolom te plaatsen.

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

De volgende afbeeldingen tonen de opgeslagen dia's gerenderd door Microsoft PowerPoint. Met `true` is het label **120** zichtbaar aan de bovenkant; met `false` is het verborgen. Het label **60** blijft zichtbaar, het asmaximum blijft op **100** en het tweede gegevenspunt blijft **120** in beide gevallen.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Dit voorbeeld gebruikt een 2D kolomdiagram met een waardenas. Diagrammen zonder waardenas, zoals taart- en donutdiagrammen, hebben geen asmaximale die op deze manier beperkt kan worden.
{{% /alert %}}

## **Labelafstand ten opzichte van een as instellen**

Gebruik [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setLabelOffset) om de afstand tussen categorielabels en de as te regelen. De waarde is een percentage van de maximale lettergrootte van de aslabels. Dit voorbeeld maakt een gegroepeerd kolomdiagram en stelt de horizontale as‑labeloffset in op 500. Deze instelling beïnvloedt categorielabels in plaats van labels die aan individuele gegevenspunten zijn gekoppeld.

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

Op een taartdiagram pas je de posities van gegevenslabels aan om de spacing te verbeteren en ruimte te maken voor begeleidingslijnen.

Dit voorbeeld toont de waarde van het eerste gegevenspunt, plaatst het label buiten de partitie en past de horizontale en verticale offsets aan met behulp van [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) en [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY). Deze offsets zijn respectievelijk relatief ten opzichte van de diagramhoogte en -breedte.

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

![Taartdiagram met aangepaste data labelpositie](pie-chart-adjusted-label.png)

## **Meerdere rijen gegevenslabels boven een kolomdiagram toevoegen**

Dit voorbeeld maakt een kolomdiagram met twee rijen gegevenslabels boven het plotgebied. Reeks A toont de zichtbare kolommen, terwijl reeks B en reeks C de extra labels leveren. Hun kolommen worden verborgen door de vulling en rand te verwijderen. De [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap)‑methode brengt alle drie de reeksen op dezelfde categoriekernen uit.

De [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/)‑instellingen reserveren ruimte voor de labelrijen. Na het berekenen van de standaardposities door [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#validateChartLayout) behouden [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) en [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY) de horizontale uitlijning en passen verticale offsets toe om de labels in twee rijen te rangschikken. De cijfers blijven gegevenslabels gekoppeld aan de reekswerte; alleen de rij‑koppen zijn afzonderlijke tekstvormen.

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
            // Verberg de kolommen van B en C, maar behoud hun gegevenslabels.
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

    // Lijn alle drie reeksen uit op dezelfde categoriecentra.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Gebruik minder rasterlijnen voor dit compacte voorbeeld.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Reserveer ruimte boven de plot voor twee rijen gegevenslabels.
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
            // Bewaar de standaard horizontale positie. Y is een offset ten opzichte van
            // de standaard labelpositie, uitgedrukt als een fractie van de diagramhoogte.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // Alleen de rij‑kop is een afzonderlijke tekstvorm.
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

![Kolomdiagram met twee rijen gegevenslabels boven het plotgebied](multiple-rows-of-labels.png)

## **FAQ**

**Hoe kan ik voorkomen dat gegevenslabels overlappen in drukke diagrammen?**  
Combineer automatische labelplaatsing, begeleidingslijnen en een verkleinde lettergrootte; indien nodig, verberg enkele velden (bijvoorbeeld de categorie) of toon alleen labels voor extreme waarden of sleutelpunten.

**Hoe kan ik labels alleen uitschakelen voor nul-, negatieve of lege waarden?**  
Filter gegevenspunten vóór het inschakelen van labels en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl waarborgen bij export naar PDF/afbeeldingen?**  
Stel expliciet het lettertype en de grootte in en controleer dat het lettertype beschikbaar is in de renderingomgeving om terugval te voorkomen.