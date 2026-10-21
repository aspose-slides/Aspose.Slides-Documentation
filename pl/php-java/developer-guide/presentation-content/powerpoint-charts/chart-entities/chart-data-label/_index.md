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
description: "Dowiedz się, jak dodawać i formatować etykiety danych wykresu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Java, aby uzyskać bardziej angażujące slajdy."
---
## **Wprowadzenie**

Etykiety danych wyświetlają informacje o seriach wykresu i pojedynczych punktach danych, pomagając czytelnikom zidentyfikować wartości i zrozumieć wykres. Ten artykuł wyjaśnia, jak formatować wartości, wyświetlać procenty, odczytywać tekst etykiet, kontrolować etykiety poza maksymalną wartością osi, regulować odstępy etykiet osi kategorialnej oraz pozycjonować etykiety wykresu kołowego.

## **Ustaw precyzję danych w etykietach danych wykresu**

Użyj [setNumberFormatOfValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setnumberformatofvalues/), aby sformatować wartości serii. Ten przykład tworzy wykres liniowy z domyślnymi danymi, wyświetla jego tabelę danych i włącza etykiety wartości dla pierwszej serii. Format `#,##0.00` wyświetla separator tysięcy i dwa miejsca po przecinku, nie zmieniając wartości podstawowych.

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

Aby sformatować komórki liczbowe w osadzonym skoroszycie wykresu, zobacz [Set Custom Number Formats for Workbook Cells](/slides/pl/php-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). Ten przykład także pokazuje etykiety wartości, które zachowują formaty komórek źródłowych przy jednoczesnym zachowaniu przechowywanych wartości liczbowych.

## **Wyświetl procent jako etykietę**

Dla wykresu słupkowego skumulowanego oblicz każdą wartość jako procent sumy swojej kategorii i przypisz tekst do ramki tekstowej zwróconej przez [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/). Ten przykład używa domyślnych danych wykresu i wyświetla procenty z dwoma miejscami po przecinku w czcionce o rozmiarze 8 punktów. Kategorie o sumie zerowej są pomijane, aby uniknąć dzielenia przez zero. Przelicz ponownie niestandardowy tekst etykiety, jeśli dane wykresu ulegną zmianie.

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

Gdy wartości są przechowywane jako ułamki, użyj [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/), aby wyświetlać procenty. Przekaż `false` do [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/), aby zastosować format etykiety niezależnie od komórek źródłowych.

Ten przykład tworzy wykres słupkowy skumulowany 100 % z czerwonymi i niebieskimi seriami w czterech kategoriach. Każda para wartości sumuje się do 1. Format etykiety `0.0%` wyświetla 0,30 jako 30,0 %, podczas gdy oś pionowa używa dwóch miejsc po przecinku. Obie serie używają białego tekstu etykiet o rozmiarze 10 punktów.

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

Użyj [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/), aby pobrać tekst wygenerowany przez ustawienia etykiety danych. Jest to przydatne przy wyodrębnianiu etykiet do raportów, przeszukiwaniu zawartości prezentacji lub walidacji wygenerowanych wykresów. W poniższym przykładzie domyślny [data label format](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/) łączy nazwę każdej kategorii, nazwę serii oraz wartość. Jeden punkt formatuje swoją wartość jako procent, a inny używa niestandardowego tekstu z [getTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/gettextframeforoverriding/).

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

Liczba przechowywana w punkcie danych pozostaje `0.75`, nawet gdy jego etykieta wyświetla `75%` wraz z nazwami kategorii i serii. Niestandardowy tekst zastępuje wygenerowany tekst etykiety. [getActualLabelText](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/getactuallabeltext/) zwraca powstały ciąg etykiety w obu przypadkach. Sprawdź [isVisible](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/isvisible/) osobno, jak pokazano powyżej, gdy chcesz wyodrębnić tylko widoczne etykiety.

## **Kontroluj etykiety danych poza maksymalnym zakresem osi**

Kiedy ręcznie ograniczasz zakres osi, niektóre punkty danych mogą przekraczać jej maksymalną wartość. Użyj [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setshowdatalabelsovermaximum/), aby kontrolować, czy ich etykiety danych są wyświetlane. To ustawienie zmienia widoczność etykiet; nie zmienia zakresu osi ani podstawowych wartości danych.

Poniższy przykład tworzy dwuwymiarowy wykres słupkowy grupowany z wartościami 60 i 120. Przekazuje `false` do [setAutomaticMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmaxvalue/) i ustawia maksimum na 100 przy pomocy [setMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmaxvalue/) na osi pionowej. Pierwszy slajd pozwala na etykiety poza maksimum; kopia tego slajdu wyłącza je. Oba slajdy są zapisane w pliku `DataLabelsOverMaximum.pptx`.

Włącz etykiety wartości za pomocą [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/). Ustawienie na poziomie wykresu nie włącza samodzielnie wyświetlania wartości ani nie nadpisuje wyłączonego wyświetlania wartości w poszczególnej etykiecie. Ten przykład włącza wartości dla całej serii i używa [setPosition](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setposition/), aby umieścić etykiety na zewnętrznym końcu każdego słupka.

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

Poniższe obrazy przedstawiają zapisane slajdy wyrenderowane w programie Microsoft PowerPoint. Etykieta **120** jest widoczna na górnej granicy; przy `false` jest ukryta. Etykieta **60** pozostaje widoczna, maksimum osi pozostaje **100**, a drugi punkt danych pozostaje **120** w obu przypadkach.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ten przykład używa dwuwymiarowego wykresu słupkowego z osią wartości. Wykresy bez osi wartości, takie jak wykresy kołowe i pierścieniowe, nie mają maksymalnej wartości osi, którą można by w ten sposób ograniczyć.
{{% /alert %}}

## **Ustaw odległość etykiety od osi**

Użyj [setLabelOffset](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlabeloffset/), aby kontrolować odległość między etykietami osi kategorialnej a osią. Wartość jest procentem maksymalnego rozmiaru czcionki etykiet osi. Ten przykład tworzy wykres słupkowy grupowany i ustawia offset etykiet osi poziomej na 500. To ustawienie wpływa na etykiety osi kategorialnej, a nie na etykiety przypisane do pojedynczych punktów danych.

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

## **Dostosuj położenie etykiet**

Na wykresie kołowym dostosuj pozycje etykiet danych, aby poprawić odstępy i zrobić miejsce dla linii pomocniczych.

Ten przykład wyświetla wartość pierwszego punktu danych, umieszcza jego etykietę poza wycinką i reguluje jej przesunięcia poziome i pionowe przy użyciu [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) i [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/). Te przesunięcia są odpowiednio względem szerokości i wysokości wykresu.

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

## **Formatuj linie pomocnicze**

Na wykresie kołowym, gdy etykiety znajdują się poza wycinkami, linie pomocnicze pomagają czytelnikowi dopasować każdą wartość do właściwej wycinki. Kontrastowy kolor i nieco grubsza linia mogą ułatwić śledzenie połączeń, a przezroczystość oraz styl przerywany utrzymują linie w tle.

Użyj [getLeaderLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelcollection/getleaderlinesformat/), aby formatować linie pomocnicze na poziomie kolekcji etykiet danych serii. Ustawienia w `$series->getLabels()->getLeaderLinesFormat()->getLine()` mają zastosowanie do całej kolekcji, a nie do pojedynczej etykiety.

Ten przykład tworzy wykres kołowy z domyślnymi danymi, wyświetla wartości poza wycinkami i włącza [setShowLeaderLines](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowleaderlines/). Przesuwa dwie etykiety dalej od ich wycinków, używając przesunięć [setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) i [setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/), wyrażonych jako ułamki szerokości i wysokości wykresu. Nie jest wymagana żadna prezentacja wejściowa.

Metoda linii [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) ustawia jednolity niebieski kolor z wartością alfa 191 na 255, co daje około 25 % przezroczystości. [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) ustawia grubość na 2 punkty, a [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) sprawia, że linia jest przerywana.

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

    // Przesuń dwie etykiety dalej od ich wycinków.
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

Włączenie linii pomocniczych nie gwarantuje, że linia pojawi się przy każdej etykiecie. Widoczność zależy od rozmieszczenia etykiet i zachowania układu wykresu. W tym przykładzie dwie przemieszczone etykiety mają widoczne linie pomocnicze; etykiety pozostające blisko wycinków nie potrzebują ich.

Poniższy obraz przedstawia zapisany plik `FormattedLeaderLines.pptx` wyrenderowany przy użyciu Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Dodaj wiele wierszy etykiet danych nad wykresem słupkowym**

Ten przykład tworzy wykres słupkowy z dwoma rzędami etykiet danych nad obszarem wykresu. Seria A wyświetla widoczne słupki, podczas gdy Seria B i Seria C dostarczają dodatkowe etykiety. Ich słupki są ukryte poprzez usunięcie wypełnienia i konturu. Metoda [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) wyrównuje wszystkie trzy serie względem tych samych środków kategorii.

Ustawienia [ChartPlotArea](https://reference.aspose.com/slides/php-java/aspose.slides/chartplotarea/) rezerwują miejsce na rzędy etykiet. Po obliczeniu domyślnych pozycji przez [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/), [DataLabel::setX](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/setx/) i [DataLabel::setY](https://reference.aspose.com/slides/php-java/aspose.slides/datalabel/sety/) zachowują wyrównanie poziome i stosują przesunięcia pionowe, aby ułożyć etykiety w dwóch rzędach. Liczby pozostają etykietami danych powiązanymi z wartościami serii; jedynie nagłówki wierszy są oddzielnymi kształtami tekstowymi.

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
            // Ukryj słupki B i C, ale zachowaj ich etykiety danych.
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

    // Zarezerwuj miejsce nad obszarem wykresu dla dwóch rzędów etykiet danych.
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
            // domyślnej pozycji etykiety, wyrażonego jako ułamek wysokości wykresu.
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**Jak mogę zapobiec nakładaniu się etykiet danych na gęstych wykresach?**

Połącz automatyczne rozmieszczanie etykiet, linie pomocnicze i zmniejszony rozmiar czcionki; w razie potrzeby ukryj niektóre pola (na przykład kategorię) lub pokaż etykiety tylko dla wartości skrajnych lub kluczowych punktów.

**Jak mogę wyłączyć etykiety tylko dla wartości zerowych, ujemnych lub pustych?**

Przefiltruj punkty danych przed włączeniem etykiet i wyłącz wyświetlanie dla wartości 0, ujemnych lub brakujących zgodnie z określoną regułą.

**Jak mogę zapewnić spójny styl etykiet przy eksporcie do PDF/obrazów?**

Wyraźnie ustaw rodzinę i rozmiar czcionki oraz zweryfikuj, że czcionka jest dostępna w środowisku renderowania, aby uniknąć zastąpienia.