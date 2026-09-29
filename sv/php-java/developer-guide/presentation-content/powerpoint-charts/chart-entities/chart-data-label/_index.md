---
title: Hantera diagramdatatetiketter i presentationer med PHP
linktitle: Datatetikett
type: docs
url: /sv/php-java/chart-data-label/
keywords:
- diagram
- datatetikett
- dataprecision
- procent
- etikettavstånd
- etikettplacering
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdatatetiketter i PowerPoint-presentationer med Aspose.Slides för PHP via Java för mer engagerande bilder."
---
## **Introduktion**

Dataetiketter visar information om diagramserier och enskilda datapunkter, vilket hjälper läsarna att identifiera värden och förstå diagrammet. Den här artikeln förklarar hur man formaterar värden, visar procenttal, läser etiketttext, styr etiketter utanför axelns maximum, justerar mellanrum för kategoriaxelns etiketter och placerar sektordiagrametiketter.

## **Ställ in dataprecision i diagramdatatetiketter**

Använd [setNumberFormatOfValues](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) för att formatera serievärden. Det här exemplet skapar ett linjediagram med standarddata, visar dess datatabell och aktiverar värdetiketter för den första serien. Formatet `#,##0.00` visar ett tusentalsavgränsare och två decimaler utan att ändra de underliggande värdena.

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

## **Visa procent som etiketter**

För ett staplat stapeldiagram beräknas varje värde som en procentandel av kategori‑totalsumman och texten tilldelas textramen som returneras av [getTextFrameForOverriding](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabel/#getTextFrameForOverriding). Det här exemplet använder standarddiagramdata och visar procenttal med två decimaler i ett 8‑punkts teckensnitt. Kategorier med en total på noll hoppas över för att undvika division med noll. Beräkna om den anpassade etiketttexten om diagramdata ändras.

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

## **Ställ in procenttecken med diagramdatatetiketter**

När värden lagras som bråk använder du [setNumberFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabelformat/#setNumberFormat) för att visa procenttal. Skicka `false` till [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) för att tillämpa etikettformatet oberoende av källcellerna.

Det här exemplet skapar ett 100 % staplat stapeldiagram med röda och blå serier över fyra kategorier. Varje par värden summeras till 1. Etikettformatet `0.0%` visar 0,30 som 30,0 %, medan den vertikala axeln använder två decimaler. Båda serierna använder vit, 10‑punkts etiketttext.

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

## **Läs den faktiska texten för datatetiketter**

Använd [getActualLabelText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabel/#getActualLabelText) för att hämta texten som genereras av en datatetiketts inställningar. Detta är användbart när du extraherar etiketter för rapporter, söker i presentationsinnehåll eller validerar genererade diagram. I exemplet nedan kombinerar standard‑[datatetikettformat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabelformat/) varje kategorinamn, serienamn och värde. En punkt formaterar sitt värde som procenttal, och en annan använder anpassad text från [getTextFrameForOverriding](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Numret som lagras i en datapunkt förblir `0.75`, även när dess etikett visar `75%` tillsammans med kategori‑ och serienamnen. Anpassad text ersätter den genererade etiketttexten. [getActualLabelText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabel/#getActualLabelText) returnerar den resulterande etikettsträngen i båda fallen. Kontrollera [isVisible](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabel/#isVisible) separat, som visas ovan, när du bara vill extrahera synliga etiketter.

## **Styr datatetiketter utanför axelns maximum**

När du begränsar ett axelintervall manuellt kan vissa datapunkter överskrida dess maximum. Använd [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) för att styra om deras datatetiketter visas. Denna inställning ändrar etikettens synlighet; den ändrar inte axelintervallet eller de underliggande datavärdena.

Exemplet nedan skapar ett 2D-klustrat stapeldiagram med värdena 60 och 120. Det skickar `false` till [setAutomaticMaxValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/#setAutomaticMaxValue) och sätter maximum till 100 med [setMaxValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/#setMaxValue) på den vertikala axeln. Den första bilden tillåter etiketter utanför maximum; en kopia av den bilden inaktiverar dem. Båda bilderna sparas i `DataLabelsOverMaximum.pptx`.

Aktivera värdetiketter med [setShowValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabelformat/#setShowValue). Diagramnivå‑inställningen aktiverar inte värdevisning i sig själv eller åsidosätter en enskild etikett som har inaktiverad värdevisning. Detta exempel aktiverar värden för hela serien och använder [setPosition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabelformat/#setPosition) för att placera etiketter vid den yttre kanten av varje stapel.

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

Följande bilder visar de sparade bilderna som renderats av Microsoft PowerPoint. Med `true` är etiketten **120** synlig vid den övre gränsen; med `false` är den dold. Etiketten **60** förblir synlig, axelns maximum förblir **100**, och den andra datapunkten förblir **120** i båda fallen.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint-diagram som visar värdetiketten 120 med ett axelmaximum på 100](data-labels-over-maximum-true.png) | ![PowerPoint-diagram som döljer värdetiketten 120 med ett axelmaximum på 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Det här exemplet använder ett 2D-stapeldiagram med en värdeaxel. Diagram utan värdeaxel, såsom cirkel‑ och donutsdiagram, har inget axelmaximum att begränsa på detta sätt.
{{% /alert %}}

## **Ställ in etiketternas avstånd från en axel**

Använd [setLabelOffset](https://reference.aspose.com/slides/sv/php-java/aspose.slides/axis/#setLabelOffset) för att kontrollera avståndet mellan kategoriaxelns etiketter och axeln. Värdet är en procentsats av den maximala teckenstorleken för axelns etiketter. Detta exempel skapar ett klustrat stapeldiagram och sätter den horisontella axelns etikettoffset till 500. Denna inställning påverkar kategoriaxelns etiketter snarare än etiketter som är fästa vid enskilda datapunkter.

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

## **Justera etikettposition**

I ett cirkeldiagram justeras datapunktsetikettens positioner för att förbättra avståndet och skapa plats för förbindelselänkar.

Det här exemplet visar värdet för den första datapunkten, placerar dess etikett utanför sektorn och justerar dess horisontella och vertikala offset med [setX](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabel/#setX) och [setY](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabel/#setY). Dessa offset är relativa till diagrammets bredd respektive höjd.

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

![Cirkeldiagram med en justerad datapunktsetikettposition](pie-chart-adjusted-label.png)

## **FAQ**

**Hur kan jag förhindra att datatetiketter överlappar i täta diagram?**

Kombinera automatisk etikettplacering, förbindelselänkar och minskad teckenstorlek; vid behov dölja vissa fält (t.ex. kategori) eller visa etiketter endast för extrema värden eller nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll, negativa eller tomma värden?**

Filtrera datapunkter innan etiketter aktiveras och stäng av visning för värden som är 0, negativa eller saknade enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettstil vid export till PDF/bilder?**

Ange explicit teckensnittsfamilj och storlek och verifiera att teckensnittet finns i renderingsmiljön för att undvika fallback.