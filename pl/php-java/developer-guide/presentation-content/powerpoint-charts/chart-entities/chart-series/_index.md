---
title: Zarządzanie seriami danych wykresu w prezentacjach w PHP
linktitle: Serie danych
type: docs
url: /pl/php-java/chart-series/
keywords:
- serie wykresu
- nakładanie się serii
- kolor serii
- nazwa serii
- punkt danych
- komórka skoroszytu
- przerwa serii
- wartość ujemna
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem się, szerokością przerwy i wartościami ujemnymi w prezentacjach przy użyciu PHP."
---
## **Przegląd**

Wykres przechowuje swoje dane w skoroszycie danych wykresu. [ChartSeries](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [ChartDataPoint](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/) w serii odnosi się do jednej lub wielu komórek skoroszytu. Obiekty [ChartCategory](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartcategory/) dostarczają etykiet lub wartości grupujących współdzielonych przez serie. Nazwa serii, kategorie i wartości punktów są więc połączone z obiektami [ChartDataCell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/), a nie przechowywane wyłącznie jako tekst wyświetlany.

Dla typowego wykresu kategoriowego domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [ChartDataWorkbook.getCell](httpshttps://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/#getCell) są zerowo‑indeksowane. Układ ten jest przydatny, gdy tworzysz wykres z domyślnymi danymi, ale nie zakładaj, że każdy istniejący wykres go używa. Dla wczytanej prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [ChartSeries.getFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#getFormat), określają domyślny wygląd wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/#getFormat), nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupowe mają zastosowanie do kompatybilnych serii należących do tej samej [ChartSeriesGroup](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/). Uzyskaj dostęp do grupy przez [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#getParentSeriesGroup), gdy musisz ustawić opcje takie jak nakładanie się lub szerokość przerwy.

Gdy nie jest ustawione wyraźne wypełnienie punktu lub serii, styl i motyw wykresu określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustawienie nakładania się serii wykresu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#getOverlap) informuje, jak bardzo słupki lub kolumny nakładają się w wykresie 2D, od -100 do 100 procent. Jest to odczytywana projekcja ustawienia w grupie serii nadrzędnej. Użyj [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/#setOverlap), aby zaktualizować wszystkie kompatybilne serie w tej grupie. Ta opcja ma zastosowanie do typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia nakładanie się dla grupy zawierającej pierwszą serię:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Nowy wykres zawiera przykładowe serie, kategorie i wartości.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wynik:

![The series overlap](series_overlap.png)

## **Zmiana koloru wypełnienia serii**

Użyj [ChartSeries.getFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#getFormat), aby ustawić domyślne wypełnienie całej serii. Jeśli punkt ma już wyraźne wypełnienie, jego ustawienie [ChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/#getFormat) nadpisuje wypełnienie serii dla tego punktu.

Poniższy przykład stosuje jednolite niebieskie wypełnienie do pierwszej serii:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wynik:

![The color of the series](series_color.png)

## **Zmiana nazwy serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zazwyczaj wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla wykresu kolumnowego grupowanego komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Zmienna w poniższym przykładzie czyni tę strukturę explicite:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Możesz także zaktualizować komórkę już odwoływaną przez [ChartSeries.getName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#getName). Takie podejście unika zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wynik:

![The series name](series_name.png)

## **Pobranie automatycznego koloru wypełnienia serii**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) zwraca kolor wyliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało jawnie określone. Wywołanie metody odczytuje wyliczony kolor; nie przypisuje nowego wypełnienia.

Poniższy przykład wypisuje automatyczny kolor każdej domyślnej serii:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Przykładowe wyjście dla domyślnego stylu wykresu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Dokładne kolory zależą od stylu i motywu wykresu.

## **Ustawienie odwróconego koloru wypełnienia dla serii wykresu**

Dla serii słupkowych, kolumnowych i bąbelkowych [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#setInvertIfNegative) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na jednolite, włącz odwracanie i przypisz kolor wartości ujemnej przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Ujemne liczby pozostają niezmienione w skoroszycie; zmienia się jedynie ich kolor wyświetlania.

Poniższy przykład zastępuje domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 – nazwy kategorii, a kolumna 1 – wartości:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wynik:

![The inverted solid fill color](inverted_solid_fill_color.png)

Możesz włączyć odwrócenie dla jednego punktu przez [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). W poniższym przykładzie odwrócenie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punktowi przypisana jest również wartość ujemna, aby efekt był widoczny:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Czyszczenie konkretnej wartości punktu danych**

Aby uczynić jeden punkt pustym bez usuwania pozostałych, ustaw jego komórkę w skoroszycie na `null`. Dla wykresu kolumnowego wartość wykreślona jest dostępna przez [ChartDataPoint.getValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/#getValue). Punkt danych pozostaje na tej samej pozycji kategori, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

Poniższy przykład usuwa tylko drugi punkt w pierwszej serii:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wykresy punktowe używają oddzielnych komórek X i Y, a wykresy bąbelkowe dodatkowo komórki rozmiaru. Czyść tylko komórkę reprezentującą wartość, którą chcesz usunąć. Nie wywołuj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointcollection/#clear), gdy chcesz zachować pozostałe punkty, ponieważ metoda ta usuwa wszystkie punkty danych z kolekcji.

## **Kontrola wyświetlania pustych komórek**

Pusta komórka skoroszytu oznacza brak danych; komórka zawierająca `0` oznacza znaną wartość liczbową. Wywołaj [ChartDataCell::setValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatacell/#setValue) z `null`, aby uczynić komórkę pustą. Zero liczbowe pozostaje zerem, niezależnie od ustawienia pustej komórki.

Użyj [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/#setDisplayBlanksAs), aby wybrać sposób wyświetlania pustych komórek. To ustawienie dotyczy całego wykresu. Zmienia sposób wykreślania pustek, nie wypełniając pustej komórki zerem ani interpolowaną wartością.

Poniższy, samodzielny przykład tworzy wykres liniowy z jedną serią, czyści wartość dla Dnia 3 i zapisuje ten sam wykres w każdym trybie. Plik wejściowy nie jest wymagany. [ChartDataWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/) używa arkusza 0, kolumny 0 dla etykiet kategorii i kolumny 1 dla wartości; wiersz 0 zawiera nazwę serii. Końcowe dane to `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Zostaw dzień 3 naprawdę pusty, zachowując jego kategorię i punkt danych.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Każdy plik wyjściowy przechowuje tryb przypisany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, przypisz żądany tryb i zapisz prezentację raz, zamiast iterować po trybach.

Porównanie poniżej pokazuje te same dane we wszystkich trzech plikach. Dzień 3 jest pusty w skoroszycie w każdym przypadku:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy ułatwia porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii łączącej brakującą kategorię, więc `Span` nie może wygenerować segmentu połączenia pokazanego powyżej; pusty słupek i słupek o wysokości zero mogą również wyglądać podobnie. Podobnie wykres punktowy tylko ze znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wynik dla używanego typu.

## **Ustawienie szerokości przerwy serii**

Szerokość przerwy to odstęp między sąsiadującymi grupami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie się, należy do grupy serii nadrzędnej, a nie do jednej serii. Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/#setGapWidth) raz dla grupy. Większa wartość tworzy więcej przestrzeni między grupami; mniejsza wartość sprawia, że są one bardziej zwarte.

Poniższy przykład zmienia szerokość przerwy i zapisuje tylko finalną prezentację:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Wynik:

![The gap width](gap_width.png)

## **FAQ**

**Jakie typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/charttype/) używają danych wykresu, ale ich serie nie mają takiej samej struktury wartości ani ustawień. Na przykład wykresy kategoriowe używają kategorii i wartości, wykresy punktowe używają wartości X i Y, a wykresy bąbelkowe dodają rozmiary bąbelków. Użyj metody tworzenia punktu danych, która odpowiada typowi serii. Opcje takie jak nakładanie się i szerokość przerwy mają zastosowanie tylko do kompatybilnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/) zawiera kompatybilne serie, które współdzielą ustawienia wykreślania na poziomie grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy osiągniętej przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera domyślne dane?**

Tak. Domyślnie [ShapeCollection.addChart](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addChart) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno kolekcje serii, jak i kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może także utworzyć wykres bez domyślnych danych.

**Jak obiekty wykresu są połączone z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [ChartDataWorkbook](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdataworkbook/). Zmiana odwołanej komórki aktualizuje odpowiadający element wykresu. Gdy budujesz własne dane, utrzymuj wiersze kategorii i wiersze wartości serii wyrównane, aby każdy punkt został wykreślony pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `null`, aby zachować pozycję kategorii punktu jako pusty punkt. Użyj [ChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapointcollection/#clear) tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli usuwasz także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i wartości skonfigurowanej w [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chart/#setDisplayBlanksAs). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zero lub przez łączenie sąsiednich punktów. Wybierz ustawienie pasujące do znaczenia brakujących danych w twojej prezentacji. Zobacz [Kontrola wyświetlania pustych komórek](#control-the-display-of-empty-cells) po pełny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#setInvertIfNegative) i ustaw kolor zwrócony przez [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Możesz nadpisać zachowanie dla poszczególnego punktu za pomocą [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Metody te wpływają na formatowanie, nie na przechowywane wartości liczbowe.

**Które formatowanie ma pierwszeństwo, gdy zarówno seria, jak i punkt są sformatowane?**

Jawne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają wyraźnego formatu serii lub, gdy format serii nie jest określony, automatycznego stylu i motywu wykresu. Ustawienia grupowe, takie jak nakładanie się i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania na poziomie punktu.

**Czy istnieje limit liczby serii w wykresie?**

Aspose.Slides nie narzuca oddzielnego stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu determinują praktyczny limit.

**Co zmienić, gdy kolumny są za blisko siebie lub za daleko od siebie?**

Wywołaj [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/chartseriesgroup/#setGapWidth) na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby poszerzyć odstęp między grupami, lub zmniejsz ją, aby przybliżyć grupy do siebie.