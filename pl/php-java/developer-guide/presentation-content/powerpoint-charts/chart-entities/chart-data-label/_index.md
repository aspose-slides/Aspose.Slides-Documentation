---
title: Zarządzanie etykietami danych wykresów w prezentacjach przy użyciu PHP
linktitle: Etykieta danych
type: docs
url: /pl/php-java/chart-data-label/
keywords:
- wykres
- etykieta danych
- precyzja danych
- procent
- odległość etykiety
- położenie etykiety
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak dodawać i formatować etykiety danych wykresów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Java, aby uzyskać bardziej atrakcyjne slajdy."
---
## **Wprowadzenie**

Etykiety danych wyświetlają informacje o seriach wykresu i poszczególnych punktach danych, pomagając odbiorcom rozpoznawać wartości i rozumieć wykres. Ten artykuł wyjaśnia, jak formatować wartości, wyświetlać procenty, odczytywać tekst etykiety, kontrolować etykiety poza maksimum osi, regulować odstępy etykiet osi kategorii oraz pozycjonować etykiety wykresu kołowego.

## **Ustaw precyzję danych w etykietach wykresu**

Użyj [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setNumberFormatOfValues), aby sformatować wartości serii. Ten przykład tworzy wykres liniowy z domyślnymi danymi, wyświetla jego tabelę danych i włącza etykiety wartości dla pierwszej serii. Format `#,##0.00` wyświetla separator tysięcy i dwie miejsca po przecinku bez zmiany pierwotnych wartości.

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

## **Wyświetl procent jako etykiety**

W przypadku wykresu słupkowego skumulowanego oblicz każdą wartość jako procent sumy jej kategorii i przypisz tekst do ramki tekstowej zwróconej przez [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding). Ten przykład używa domyślnych danych wykresu i wyświetla procenty z dwoma miejscami po przecinku w czcionce 8‑punktowej. Kategorie o sumie równej zero są pomijane, aby uniknąć dzielenia przez zero. Przelicz ponownie niestandardowy tekst etykiety, jeśli dane wykresu ulegną zmianie.

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

## **Ustaw znak procenta w etykietach danych wykresu**

Gdy wartości są przechowywane jako ułamki, użyj [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormat), aby wyświetlać procenty. Przekaż `false` do [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), aby zastosować format etykiety niezależnie od komórek źródłowych.

Ten przykład tworzy wykres słupkowy skumulowany 100 % z czerwonymi i niebieskimi seriami w czterech kategoriach. Każda para wartości sumuje się do 1. Format etykiety `0.0%` wyświetla 0,30 jako 30,0 %, podczas gdy oś pionowa używa dwóch miejsc po przecinku. Obie serie używają białego tekstu etykiety o rozmiarze 10 punktów.

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

## **Odczytaj rzeczywisty tekst etykiet danych**

Użyj [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText), aby pobrać tekst wygenerowany na podstawie ustawień etykiety danych. Jest to przydatne przy wyodrębnianiu etykiet do raportów, przeszukiwaniu treści prezentacji lub walidacji wygenerowanych wykresów. W poniższym przykładzie domyślny [data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) łączy nazwę każdej kategorii, nazwę serii i wartość. Jeden punkt formatuje swoją wartość jako procent, a inny używa niestandardowego tekstu z [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Liczba przechowywana w punkcie danych pozostaje `0.75`, nawet gdy jego etykieta wyświetla `75 %` wraz z nazwą kategorii i serii. Niestandardowy tekst zastępuje wygenerowany tekst etykiety. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#getActualLabelText) zwraca wynikowy ciąg etykiety w obu przypadkach. Sprawdź [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#isVisible) osobno, jak pokazano powyżej, gdy chcesz wyodrębnić tylko widoczne etykiety.

## **Kontroluj etykiety danych poza maksimum osi**

Gdy ręcznie ograniczasz zakres osi, niektóre punkty danych mogą przekraczać jej maksimum. Użyj [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setShowDataLabelsOverMaximum), aby kontrolować, czy ich etykiety danych są wyświetlane. To ustawienie zmienia widoczność etykiet; nie zmienia zakresu osi ani podstawowych wartości danych.

Poniższy przykład tworzy dwuwymiarowy wykres słupkowy grupowany z wartościami 60 i 120. Przekazuje `false` do [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setAutomaticMaxValue) i ustawia maksimum na 100 za pomocą [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setMaxValue) na osi pionowej. Pierwszy slajd zezwala na etykiety poza maksimum; kopia tego slajdu wyłącza je. Oba slajdy są zapisywane w pliku `DataLabelsOverMaximum.pptx`.

Włącz etykiety wartości za pomocą [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue). Ustawienie na poziomie wykresu nie włącza wyświetlania wartości samo w sobie ani nie nadpisuje wyłączonego wyświetlania wartości poszczególnej etykiety. Ten przykład włącza wartości dla całej serii i używa [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setPosition), aby umieścić etykiety na zewnętrznym końcu każdego słupka.

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

Poniższe obrazy pokazują zapisane slajdy renderowane przez Microsoft PowerPoint. Przy `true` etykieta **120** jest widoczna przy górnym brzegu; przy `false` jest ukryta. Etykieta **60** pozostaje widoczna, maksymalna wartość osi pozostaje **100**, a drugi punkt danych pozostaje **120** w obu przypadkach.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![Wykres PowerPoint wyświetlający etykietę wartości 120 przy maksymalnym poziomie osi 100](data-labels-over-maximum-true.png) | ![Wykres PowerPoint ukrywający etykietę wartości 120 przy maksymalnym poziomie osi 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ten przykład używa dwuwymiarowego wykresu słupkowego z osią wartości. Wykresy bez osi wartości, takie jak wykresy kołowe i pierścieniowe, nie posiadają maksymalnego ograniczenia osi w ten sposób.
{{% /alert %}}

## **Ustaw odległość etykiety od osi**

Użyj [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setLabelOffset), aby kontrolować odległość między etykietami osi kategorii a samą osią. Wartość jest procentem maksymalnego rozmiaru czcionki etykiet osi. Ten przykład tworzy wykres słupkowy grupowany i ustawia offset etykiety osi poziomej na 500. To ustawienie wpływa na etykiety osi kategorii, a nie na etykiety przypięte do poszczególnych punktów danych.

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

## **Dostosuj położenie etykiety**

W wykresie kołowym dostosuj położenie etykiet danych, aby poprawić odstępy i zrobić miejsce na linie prowadzące.

Ten przykład wyświetla wartość pierwszego punktu danych, umieszcza jego etykietę poza fragmentem koła i reguluje jej poziomy oraz pionowy offset za pomocą [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) i [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY). Te offsety są względne względem szerokości i wysokości wykresu.

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

![Wykres kołowy z dostosowanym położeniem etykiety danych](pie-chart-adjusted-label.png)

## **Dodaj wiele wierszy etykiet danych nad wykresem słupkowym**

Ten przykład tworzy wykres słupkowy z dwoma wierszami etykiet danych nad obszarem wykresu. Seria A wyświetla widoczne słupki, natomiast Serie B i C dostarczają dodatkowe etykiety. Ich słupki są ukryte poprzez usunięcie wypełnienia i konturu. Metoda [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) wyrównuje wszystkie trzy serie wzdłuż tych samych środków kategorii.

Ustawienia [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) rezerwują miejsce na wiersze etykiet. Po obliczeniu domyślnych pozycji przez [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#validateChartLayout), [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setX) i [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/#setY) zachowują wyrównanie poziome i stosują pionowe offsety, aby rozmieszczać etykiety w dwóch wierszach. Liczby pozostają etykietami danych powiązanymi z wartościami serii; jedynie nagłówki wierszy są oddzielnymi kształtami tekstowymi.

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
            // Ukryj kolumny B i C, ale pozostaw ich etykiety danych.
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

    // Wyrównaj wszystkie trzy serie względem tych samych środków kategorii.
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setOverlap(100);

    // Użyj mniejszej liczby linii siatki w tym zwartym przykładzie.
    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(10);

    // Zarezerwuj miejsce nad obszarem wykresu na dwa wiersze etykiet danych.
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
            // Zachowaj domyślną pozycję poziomą. Y jest przesunięciem od
            // domyślnej pozycji etykiety, wyrażonym jako ułamek wysokości wykresu.
            $actualY = java_values($dataLabel->getActualY());
            $dataLabel->setX(0);
            $dataLabel->setY($rowTop - $actualY / $chartHeight);
        }

        // Tylko nagłówek wiersza jest oddzielnym kształtem tekstowym.
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

![Wykres słupkowy z dwoma wierszami etykiet danych nad obszarem wykresu](multiple-rows-of-labels.png)


## **FAQ**

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**

Połącz automatyczne rozmieszczanie etykiet, linie prowadzące i zmniejszoną wielkość czcionki; w razie potrzeby ukryj niektóre pola (np. kategorię) lub wyświetlaj etykiety tylko dla skrajnych wartości lub kluczowych punktów.

**Jak mogę wyłączyć etykiety tylko dla wartości zerowych, ujemnych lub pustych?**

Przefiltruj punkty danych przed włączeniem etykiet i wyłącz wyświetlanie dla wartości równych 0, wartości ujemnych lub brakujących zgodnie z określoną regułą.

**Jak zapewnić spójny styl etykiet przy eksportowaniu do PDF/obrazów?**

Jawnie ustaw rodzinę czcionki i rozmiar oraz zweryfikuj, czy czcionka jest dostępna w środowisku renderującym, aby uniknąć użycia zastępczej czcionki.