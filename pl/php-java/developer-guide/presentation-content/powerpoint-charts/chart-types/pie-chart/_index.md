---
title: Dostosuj wykresy kołowe w prezentacjach przy użyciu PHP
linktitle: Wykres kołowy
type: docs
url: /pl/php-java/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje wykresu
- kolor wycinka
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz i dostosowuj wykresy kołowe w PHP przy użyciu Aspose.Slides. Konfiguruj dodatkowe wykresy, wyświetlaj etykiety danych i stosuj automatyczne kolory wycinków w programie PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie wycinków dla standardowego wykresu kołowego.

Przykłady koncentrują się na zadaniach związanych z dostosowywaniem wykresów, takich jak dodawanie wykresu do slajdu, dostosowywanie ustawień serii i etykiet, zastępowanie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides for PHP via Java obsługuje opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie. Opcje te kontrolują rozmiar drugiego wykresu oraz sposób podziału punktów danych pomiędzy dwa wykresy.

Poniższy przykład tworzy wykres Pie of Pie w nowej prezentacji i wyświetla wartości punktów danych jako etykiety. Metoda [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) ustawia rozmiar drugiego wykresu na 149% głównego wykresu. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) wybiera podział oparty na procentach, a [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) ustawia próg na 53%.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Wyświetl wartości i skonfiguruj drugi wykres.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Wybierz kategorie dla drugiego wykresu**

Użyj niestandardowego podziału, gdy chcesz grupować określone kategorie w drugim wykresie niezależnie od ich wartości procentowych. Na przykład raport sprzedaży może pokazywać Online i Events razem, aby czytelnicy mogli porównać te dwa kanały, mimo że stanowią 35% i 10% całkowitej sprzedaży.

Wywołaj [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) z [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) i wybierz punkty za pomocą [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Metoda [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) kolekcji przyjmuje indeks zerowy w serii; użyj [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) aby dodać obiekt punktu danych. W tym przykładzie indeks 1 wybiera Online, a punkt pod indeksem 3 wybiera Events. Partners jest również dodany tymczasowo, a następnie wykluczony przy użyciu [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Zastąp domyślne dane danymi sprzedaży według kanału.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Wybierz Online za pomocą jego indeksu zerowego oraz Events za pomocą obiektu punktu danych.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Wyklucz Partners z wyboru bez usuwania jego danych źródłowych.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) i Events (10) pojawiają się jako oddzielne wycinki w drugim wykresie. W wykresie głównym są reprezentowane jednym połączonym wycinkiem o wartości 45, obok Retail (40) i Partners (15). Usunięcie Partners z niestandardowego wyboru pozostawia go w wykresie głównym; nie usuwa to kategorii ani jej wartości z danych źródłowych wykresu.

Poniższy obrazek pokazuje zapisaną prezentację w programie PowerPoint:

![Wykres Pie of Pie z Online i Events w drugim wykresie oraz ich łączną wartością 45 w wykresie głównym](pie_of_pie_custom.png)

## **Ustaw automatyczne kolory wycinków wykresu kołowego**

Aspose.Slides for PHP via Java może automatycznie przypisywać różne kolory wycinkom wykresu kołowego. Poniższy przykład tworzy wykres kołowy z wyśrodkowanym tytułem i zastępuje domyślne dane trzema kwartalnymi kategoriami oraz ich wartościami. Metoda [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) wyświetla wartości 20, 50 i 30 jako etykiety, natomiast [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) umożliwia różny kolor dla każdego wycinka.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Dodaj wyśrodkowany tytuł wykresu.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Zastąp domyślne dane przy użyciu pierwszego arkusza.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Pokaż wartości i przypisz różne kolory wycinkom.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Najczęściej zadawane pytania**

**Czy warianty Pie of Pie i Bar of Pie są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) drugi wykres dla wykresów kołowych, w tym typy Pie of Pie i Bar of Pie.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (np. PNG) bez eksportowania całej prezentacji.