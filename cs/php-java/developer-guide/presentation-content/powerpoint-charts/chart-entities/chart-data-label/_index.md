---
title: Správa popisků dat grafu v prezentacích pomocí PHP
linktitle: Popisek dat
type: docs
url: /cs/php-java/chart-data-label/
keywords:
- graf
- popisek dat
- přesnost dat
- procento
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se přidávat a formátovat popisky dat grafu v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java pro poutavější snímky."
---
## **Úvod**

Popisky dat zobrazují informace o sériích grafu a jednotlivých datových bodech, pomáhají čtenářům identifikovat hodnoty a pochopit graf. Tento článek vysvětluje, jak formátovat hodnoty, zobrazovat procenta, číst text popisku, řídit popisky mimo maximum osy, upravit rozestupy popisků osy kategorií a umístit popisky koláčových grafů.

## **Nastavení přesnosti dat v popiscích grafu**

Použijte [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setNumberFormatOfValues) k formátování hodnot sérií. Tento příklad vytváří spojnicový graf s výchozími daty, zobrazuje jeho datovou tabulku a povoluje popisky hodnot pro první sérii. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by měnil základní hodnoty.

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

## **Zobrazení procent jako popisků**

Pro seskupený sloupcový graf vypočítejte každou hodnotu jako procento celkového součtu kategorie a přiřaďte text do textového rámce vráceného metodou [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy v písmu o velikosti 8 bodů. Kategorie s celkovým součtem nula jsou přeskočeny, aby se zabránilo dělení nulou. Přepočítejte vlastní text popisku, pokud se data grafu změní.

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

## **Nastavení procentního znaku v popiscích grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormat) k zobrazení procent. Při volání [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) předávejte `false`, aby formát popisku byl aplikován nezávisle na zdrojových buňkách.

Tento příklad vytváří 100 % seskupený sloupcový graf s červenou a modrou sérií ve čtyřech kategoriích. Každý pár hodnot sečte na 1. Formát popisku `0.0%` zobrazí 0.30 jako 30.0 %, zatímco svislá osa používá dvě desetinná místa. Obě série používají bílé popisky o velikosti 10 bodů.

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

## **Čtení skutečného textu popisků dat**

Použijte [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText) k získání textu vytvořeného nastavením popisku dat. To je užitečné při extrahování popisků pro zprávy, vyhledávání obsahu prezentace nebo ověřování vygenerovaných grafů. V níže uvedeném příkladu výchozí [data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) kombinuje název kategorie, název série a hodnotu. Jeden bod formátuje svou hodnotu jako procento a další používá vlastní text z [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Číslo uložené v datovém bodě zůstává `0.75`, i když jeho popisek zobrazuje `75%` spolu s názvy kategorie a série. Vlastní text nahrazuje vygenerovaný text popisku. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText) vrací výsledný řetězec popisku v obou případech. Zkontrolujte [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#isVisible), jak je ukázáno výše, pokud chcete extrahovat pouze viditelné popisky.

## **Řízení popisků dat mimo maximum osy**

Když omezíte rozsah osy ručně, některé datové body mohou překročit její maximum. Použijte [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) k ovládnutí, zda jsou jejich popisky zobrazeny. Toto nastavení mění viditelnost popisku; nemění rozsah osy ani základní hodnoty dat.

Níže uvedený příklad vytváří 2D seskupený sloupcový graf s hodnotami 60 a 120. Předá `false` metodě [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setAutomaticMaxValue) a nastaví maximum na 100 pomocí [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setMaxValue) na svislé ose. První snímek povoluje popisky nad maximem; kopie tohoto snímku je zakáže. Oba snímky jsou uloženy v `DataLabelsOverMaximum.pptx`.

Povolit popisky hodnot pomocí [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue). Nastavení na úrovni grafu samo o sobě nepovolí zobrazení hodnot ani nepřebije zakázané zobrazení hodnot u jednotlivých popisků. Tento příklad povoluje hodnoty pro celou sérii a používá [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setPosition), aby umístil popisky na vnější konec každého sloupce.

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

Následující obrázky ukazují uložené snímky vykreslené v Microsoft PowerPoint. S `true` je popisek **120** viditelný na horní hranici; s `false` je skrytý. Popisek **60** zůstává viditelný, maximum osy zůstává na **100** a druhý datový bod zůstává **120** v obou případech.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Graf PowerPoint zobrazující popisek hodnoty 120 s maximem osy 100](data-labels-over-maximum-true.png) | ![Graf PowerPoint skrývající popisek hodnoty 120 s maximem osy 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Tento příklad používá 2D sloupcový graf s hodnotovou osou. Grafy bez hodnotové osy, jako jsou koláčové a prstencové grafy, nemají maximum osy, které by šlo tímto způsobem omezit.
{{% /alert %}}

## **Nastavení vzdálenosti popisku od osy**

Použijte [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setLabelOffset) k řízení vzdálenosti mezi popisky osy kategorií a samotnou osou. Hodnota je procento maximální velikosti písma popisků osy. Tento příklad vytváří seskupený sloupcový graf a nastavuje odsazení popisků vodorovné osy na 500. Toto nastavení ovlivňuje popisky osy kategorií, nikoli popisky připojené k jednotlivým datovým bodům.

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

## **Úprava umístění popisku**

U koláčového grafu upravte pozice datových popisků, aby se zlepšilo rozložení a vytvořilo místo pro vodící čáry.

Tento příklad zobrazuje hodnotu prvního datového bodu, umisťuje jeho popisek mimo výseč a upravuje jeho vodorovné a svislé odsazení pomocí [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) a [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY). Tato odsazení jsou relativní k šířce a výšce grafu, respektive.

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

![Koláčový graf s upravenou pozicí datového popisku](pie-chart-adjusted-label.png)

## **Přidání více řádků popisků nad sloupcovým grafem**

Tento příklad vytváří sloupcový graf se dvěma řádky popisků nad oblastí vykreslování. Série A zobrazuje viditelné sloupce, zatímco série B a C poskytují další popisky. Jejich sloupce jsou skryté odstraněním výplně a obrysu. Metoda [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) zarovnává všechny tři série ke stejným středům kategorií.

Nastavení [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) rezervují prostor pro řádky popisků. Po výpočtu výchozích pozic metodou [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#validateChartLayout), [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) a [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY) zachovávají vodorovné zarovnání a aplikují svislá odsazení pro uspořádání popisků do dvou řádků. Čísla zůstávají popisky dat propojenými s hodnotami sérií; pouze nadpisy řádků jsou samostatné textové tvary.

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
            // Skrýt sloupce B a C, ale zachovat jejich datové popisky.
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

    // Zarovnat všechny tři série ke stejným středům kategorií.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Použít méně mřížkových čar pro tento kompaktní příklad.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Rezervovat prostor nad vykreslením pro dva řádky datových popisků.
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
            // Zachovat výchozí vodorovnou pozici. Y je posunutí od
            // výchozí pozice popisku, vyjádřené jako podíl výšky grafu.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // Pouze nadpis řádku je samostatný textový tvar.
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

![Sloupcový graf se dvěma řádky popisků nad oblastí vykreslování](multiple-rows-of-labels.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání popisků dat v hustých grafech?**

Použijte automatické umístění popisků, vodicí čáry a zmenšení velikosti písma; případně skryjte některá pole (například kategorii) nebo zobrazujte popisky jen pro extrémní hodnoty či klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**

Filtrujte datové body před povolením popisků a vypněte zobrazení pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak mohu zajistit konzistentní styl popisků při exportu do PDF/obrázků?**

Explicitně nastavte rodinu a velikost písma a ověřte, že je font dostupný v renderovacím prostředí, aby se předešlo náhradě.