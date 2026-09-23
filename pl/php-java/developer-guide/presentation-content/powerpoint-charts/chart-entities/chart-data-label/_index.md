---
title: Zarządzanie etykietami danych wykresu w prezentacjach przy użyciu PHP
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
description: "Dowiedz się, jak dodawać i formatować etykiety danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Javę, aby stworzyć bardziej angażujące slajdy."
---
## **Wprowadzenie**

Etykiety danych wyświetlają informacje o seriach wykresu i pojedynczych punktach danych, pomagając czytelnikom zidentyfikować wartości i zrozumieć wykres. W tym artykule wyjaśniono, jak formatować wartości, wyświetlać procenty, odczytywać tekst etykiety, regulować odstępy etykiet osi kategorii oraz pozycjonować etykiety wykresu kołowego.

## **Ustawianie precyzji danych w etykietach wykresu**

Użyj [setNumberFormatOfValues](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#setNumberFormatOfValues), aby sformatować wartości serii. Ten przykład tworzy wykres liniowy z domyślnymi danymi, wyświetla jego tabelę danych i włącza etykiety wartości dla pierwszej serii. Format `#,##0.00` wyświetla separator tysięcy i dwie miejsca po przecinku bez zmiany wartości źródłowych.

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

## **Wyświetlanie procentów jako etykiet**

Dla wykresu słupkowego ze skumulowanymi wartościami oblicz każdą wartość jako procent całkowitej sumy w danej kategorii i przypisz tekst do ramki tekstowej zwróconej przez [getTextFrameForOverriding](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabel/#getTextFrameForOverriding). Ten przykład wykorzystuje domyślne dane wykresu i wyświetla procenty z dwoma miejscami po przecinku w czcionce 8‑puntowej. Kategorie o sumie zerowej są pomijane, aby uniknąć dzielenia przez zero. Przelicz niestandardowy tekst etykiety, jeśli dane wykresu ulegną zmianie.

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

## **Ustawianie znaku procenta w etykietach wykresu**

Gdy wartości są przechowywane jako ułamki, użyj [setNumberFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabelformat/#setNumberFormat), aby wyświetlić procenty. Przekaż `false` do [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), aby zastosować format etykiety niezależnie od komórek źródłowych.

Ten przykład tworzy wykres kolumnowy 100 % ze skumulowanymi seriami czerwonymi i niebieskimi w czterech kategoriach. Każda para wartości sumuje się do 1. Format etykiety `0.0%` wyświetla 0.30 jako 30.0 %, podczas gdy oś pionowa używa dwóch miejsc po przecinku. Obie serie używają białego tekstu etykiety 10‑puntowego.

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

## **Odczytywanie rzeczywistego tekstu etykiet danych**

Użyj [getActualLabelText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabel/#getActualLabelText), aby pobrać tekst wygenerowany przez ustawienia etykiety danych. Jest to przydatne przy wyodrębnianiu etykiet do raportów, przeszukiwaniu zawartości prezentacji lub weryfikacji wygenerowanych wykresów. W poniższym przykładzie domyślny [format etykiet danych](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabelformat/) łączy nazwę kategorii, nazwę serii i wartość. Jeden punkt formatuje swoją wartość jako procent, a inny używa niestandardowego tekstu z [getTextFrameForOverriding](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Liczba przechowywana w punkcie danych pozostaje `0.75`, nawet gdy jego etykieta pokazuje `75 %` wraz z nazwą kategorii i serii. Niestandardowy tekst zastępuje wygenerowany tekst etykiety. [getActualLabelText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabel/#getActualLabelText) zwraca wynikowy ciąg etykiety w obu przypadkach. Sprawdzaj [isVisible](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabel/#isVisible) osobno, tak jak pokazano powyżej, gdy chcesz wyodrębnić tylko widoczne etykiety.

## **Ustawianie odstępu etykiety od osi**

Użyj [setLabelOffset](https://reference.aspose.com/slides/pl/php-java/aspose.slides/axis/#setLabelOffset), aby kontrolować odległość między etykietami osi kategorii a samą osią. Wartość jest podawana jako procent maksymalnego rozmiaru czcionki etykiet osi. Ten przykład tworzy wykres kolumnowy grupowany i ustawia odstęp etykiet osi poziomej na 500. Ustawienie to wpływa na etykiety osi kategorii, a nie na etykiety dołączone do poszczególnych punktów danych.

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

## **Regulacja położenia etykiet**

W wykresie kołowym dopasuj pozycje etykiet danych, aby poprawić odstępy i zrobić miejsce na linie pomocnicze.

Ten przykład wyświetla wartość pierwszego punktu danych, umieszcza jego etykietę poza wycinkiem i reguluje jej przesunięcia poziome i pionowe przy użyciu [setX](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabel/#setX) i [setY](https://reference.aspose.com/slides/pl/php-java/aspose.slides/datalabel/#setY). Przesunięcia te są względem szerokości i wysokości wykresu.

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

![Wykres kołowy z dopasowaną pozycją etykiety danych](pie-chart-adjusted-label.png)

## **FAQ**

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**

Połącz automatyczne rozmieszczanie etykiet, linie pomocnicze i zmniejszoną wielkość czcionki; w razie potrzeby ukryj niektóre pola (np. kategorię) lub wyświetlaj etykiety tylko dla wartości skrajnych lub kluczowych punktów.

**Jak mogę wyłączyć etykiety tylko dla zerowych, ujemnych lub pustych wartości?**

Filtruj punkty danych przed włączeniem etykiet i wyłącz ich wyświetlanie dla wartości 0, ujemnych lub brakujących zgodnie z określoną regułą.

**Jak zapewnić spójny styl etykiet przy eksportowaniu do PDF/obrazów?**

Jawnie ustaw rodzinę i rozmiar czcionki oraz zweryfikuj, czy czcionka jest dostępna w środowisku renderującym, aby uniknąć użycia zastępczych czcionek.