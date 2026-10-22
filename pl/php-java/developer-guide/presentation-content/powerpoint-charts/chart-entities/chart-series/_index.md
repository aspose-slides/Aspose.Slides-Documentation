---
title: Zarządzanie seriami danych wykresu w prezentacjach w PHP
linktitle: Serie danych
type: docs
url: /pl/php-java/chart-series/
keywords:
- serie wykresu
- nakładanie serii
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
description: "Dowiedz się, jak zarządzać seriami wykresów, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem, szerokością przerwy oraz wartościami ujemnymi w prezentacjach przy użyciu PHP."
---
## **Przegląd**

Wykres może przechowywać swoje wartości wykreślone w komórkach skoroszytu lub bezpośrednio jako literały numeryczne. [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) reprezentuje punkt w tej serii. Obiekty [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) zapewniają etykiety lub wartości grupujące współdzielone przez serie. W wykresach utworzonych z danymi domyślnymi nazwy serii, kategorie i wartości punktów używają obiektów [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) z skoroszytu wykresu.

Dla typowego wykresu kategorialnego domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) są zero‑indeksowane. Ten układ jest przydatny, gdy tworzysz wykres z danymi domyślnymi, ale nie zakładaj, że każdy istniejący wykres go używa. Dla wczytanej prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), zapewniają domyślny wygląd dla wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupowe dotyczą zgodnych serii, które należą do tej samej [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/). Uzyskaj dostęp do grupy przez [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/), gdy musisz ustawić opcje takie jak nakładanie lub szerokość przerwy.

Gdy nie zostanie ustawione wyraźne wypełnienie punktu lub serii, styl wykresu i motyw określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw wartości serii przy użyciu literałów numerycznych**

Używaj literałów numerycznych, gdy wartości serii pochodzą z danych aplikacji lub obliczeń i nie wymagają odwołań do komórek arkusza. Wywołaj [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) z [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) przed przypisaniem wyniku [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) każdego punktu poprzez [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Ustawienie kolekcji kontroluje typ źródła wszystkich wartości punktów w tej serii. Metoda [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) każdego punktu zwraca wybrany typ; zmień go poprzez ustawienie kolekcji. W przypadku `Worksheet` użyj [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) do uzyskania dostępu do odwoływanej komórki. W przypadku `DoubleLiterals` użyj [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) lub `setAsLiteralDouble`, aby odczytać lub zapisać liczbę bezpośrednio.

Poniższy przykład tworzy wykres słupkowy z domyślnymi seriami i kategoriami, a następnie przypisuje wyliczone wartości 10, 20 i tak dalej do istniejących punktów pierwszej serii. Zapisuje prezentację, otwiera ją ponownie i wypisuje zapisane wartości.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Typ źródła wartości punktu jest osobny od [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), który identyfikuje wewnętrzną lub zewnętrzną konfigurację skoroszytu wykresu. Użycie literałów numerycznych nie usuwa samego wbudowanego skoroszytu. W tym przykładzie skoroszyt pozostaje dostępny dla etykiet kategorii, nazw serii i pozostałych serii. Zobacz [Chart Workbook](/slides/pl/php-java/chart-workbook/) po informacje o zarządzaniu skoroszytem.

Dla wykresów punktowych i bąbelkowych użyj [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) oraz [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) w celu wybrania źródeł dla [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) i [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). Wykresy bąbelkowe dodatkowo używają [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) dla [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Ustaw każdy odpowiedni źródłowy typ na `DoubleLiterals` przed przypisaniem liczb poprzez metodę `setAsLiteralDouble` tego wartości.

## **Ustaw nakładanie serii wykresu**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) podaje, o ile słupki lub kolumny nakładają się w wykresie 2D, od ‑100 do 100 procent. Jest to jedynie odczytowa projekcja ustawienia w nadrzędnej grupie serii. Użyj [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/), aby zaktualizować wszystkie zgodne serie w tej grupie. Opcja ta dotyczy typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niezależne grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia nakładanie dla grupy zawierającej pierwszą serię:

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

## **Zmień kolor wypełnienia serii**

Użyj [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) aby ustawić domyślne wypełnienie dla całej serii. Jeśli punkt ma już wyraźnie określone wypełnienie, jego ustawienie [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) nadpisuje wypełnienie serii dla tego punktu.

Poniższy przykład zastosowuje jednolite niebieskie wypełnienie do pierwszej serii:

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

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zazwyczaj wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla wykresu kolumnowego skumulowanego komórka B1 znajduje się w wierszu 0, kolumna 1 i zawiera nazwę pierwszej serii. Zmienna w poniższym przykładzie wyraźnie opisuje tę strukturę:

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

Możesz także zaktualizować komórkę już odwoływaną przez [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Takie podejście unika zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

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

### **Utwórz serię z nazwą z wielu komórek**

Złożona nazwa serii jest przydatna, gdy nazwa produktu i okres sprawozdawczy są przechowywane w oddzielnych komórkach skoroszytu. Na przykład możesz połączyć `Product A` w B1 i `2026` w C1 w jedną nazwę serii, zachowując jednocześnie powiązanie obu części z ich komórkami źródłowymi.

Użyj [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/), aby pobrać zakres nazw, a następnie przekaż tę kolekcję do [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Argument `skipHiddenCells` kontroluje, czy ukryte komórki są uwzględniane: `true` je pomija, `false` uwzględnia. Ten przykład używa `false`, aby włączyć wszystkie komórki w zakresie nazw.

Poniższy przykład tworzy prezentację z jedną serią i dwoma punktami danych. Komórki B1:C1 dostarczają wyłącznie nazwę serii; A2:A3 dostarczają etykiety kategorii, a B2:B3 – wartości liczbowe.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Te dwie komórki dostarczają nazwę serii.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Oddzielne komórki dostarczają kategorie i numeryczne punkty danych.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Wynikowa nazwa serii to `Product A 2026`, z odstępem pomiędzy dwoma wartościami komórek. Legenda wyświetla to jako jedną pozycję dla obu kolumn. Obraz poniżej ilustruje wynik:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało wyraźnie określone. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

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

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Dla serii słupkowych, kolumnowych i bąbelkowych [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) może wyświetlać wartości ujemne innym kolorem wypełnienia. Ustaw regularne wypełnienie serii na jednolite, włącz odwracanie i przypisz kolor wartości ujemnych poprzez [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Ujemne liczby pozostają niezmienione w skoroszycie; zmienia się jedynie ich kolor wyświetlania.

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

Możesz włączyć odwracanie dla jednego punktu poprzez [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). W poniższym przykładzie odwracanie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punktowi przypisano również wartość ujemną, aby efekt był widoczny:

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

## **Wyczyść określoną wartość punktu danych**

Aby uczynić jeden punkt pustym bez usuwania pozostałych, ustaw jego powiązaną komórkę skoroszytu na `null`. Dla wykresu słupkowego dostępna jest wartość poprzez [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Punkt pozostaje w tym samym miejscu kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami wykresu dla pustych wartości.

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

Wykresy punktowe używają oddzielnych komórek X i Y, a wykresy bąbelkowe dodatkowo używają komórki rozmiaru. Usuń tylko tę komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/), gdy chcesz zachować pozostałe punkty, ponieważ ta metoda usuwa wszystkie punkty danych z kolekcji.

## **Kontroluj wyświetlanie pustych komórek**

Ukryte komórki zawierające wartości to odrębny przypadek od pustych komórek. Aby włączać lub wyłączać dane z ukrytych wierszy i kolumn arkusza, zobacz [Include Data from Hidden Rows and Columns](/slides/pl/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Pusta komórka skoroszytu oznacza brak danych; komórka zawierająca `0` oznacza znaną wartość liczbową. Wywołaj [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) z `null`, aby uczynić komórkę pustą. Liczba zero pozostaje zerem bez względu na ustawienie pustej komórki.

Użyj [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/), aby wybrać, jak wykres wyświetla puste komórki. To ustawienie dotyczy całego wykresu. Zmienia sposób rysowania pustych wartości, nie wypełniając pustej komórki zerem ani interpolowaną wartością.

Poniższy samodzielny przykład tworzy wykres liniowy z jedną serią, usuwa wartość dla Dnia 3 i zapisuje ten sam wykres w każdym trybie. Nie wymaga pliku wejściowego. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) używa arkusza 0, kolumny 0 dla etykiet kategorii i kolumny 1 dla wartości; wiersz 0 zawiera nazwę serii. Finalne dane to `10, 20, empty, 30, 40`.

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

    // Zostaw Dzień 3 naprawdę pusty, zachowując jego kategorię i punkt danych.
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

Każdy plik wyjściowy przechowuje tryb przypisany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, ustaw żądany tryb i zapisz prezentację raz zamiast iterować po trybach.

Poniższe porównanie pokazuje te same dane we wszystkich trzech plikach. Dzień 3 jest pusty w skoroszycie w każdym przypadku:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy ułatwia porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii łączącej brakującą kategorię, więc `Span` nie może wygenerować połączenia pokazanego powyżej; brakująca kolumna i kolumna o zerowej wysokości mogą wyglądać podobnie. Podobnie wykres punktowy z samymi znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wyjście dla używanego typu.

## **Ustaw szerokość przerwy serii**

Szerokość przerwy to odstęp między sąsiadującymi klastrami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie, należy ona do grupy nadrzędnej serii, a nie do jednej serii. Wywołaj [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) raz dla grupy. Większa wartość tworzy więcej miejsca między klastrami; mniejsza – zagęszcza je.

Poniższy przykład zmienia szerokość przerwy i zapisuje jedynie końcową prezentację:

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

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) używają danych wykresu, lecz ich serie nie zawsze mają tę samą strukturę wartości lub ustawienia. Na przykład wykresy kategorialne używają kategorii i wartości, wykresy punktowe X i Y, a wykresy bąbelkowe dodatkowo rozmiary bąbelków. Używaj metody tworzenia punktów danych odpowiedniej dla typu serii. Opcje takie jak nakładanie i szerokość przerwy dotyczą tylko zgodnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) zawiera zgodne serie, które współdzielą ustawienia grupowe wykreślania. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera dane domyślne?**

Tak. Domyślnie [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno serie, jak i kolekcje kategorii przed dodaniem w pełni własnego zestawu danych. Istnieje również przeciążenie, które może utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są połączone z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Zmiana odwoływanej komórki aktualizuje odpowiadający element wykresu. Tworząc własne dane, utrzymuj wyrównane wiersze kategorii i wiersze wartości serii, aby każdy punkt był wykreślony pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `null`, aby zachować pozycję kategorii punktu jako pusty punkt. Używaj [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) tylko wtedy, gdy chcesz usunąć wszystkie punkty z tej serii. Jeśli usuwasz także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i ustawienia skonfigurowanego w [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zero lub poprzez połączenie sąsiednich punktów. Wybierz ustawienie odpowiadające znaczeniu brakujących danych w Twojej prezentacji. Zobacz [Control the Display of Empty Cells](#control-the-display-of-empty-cells) po pełny przykład i porównanie wizualne.

**Jak sformatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) i ustaw kolor zwracany przez [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Możesz nadpisać zachowanie dla pojedynczego punktu za pomocą [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Te metody wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie ma pierwszeństwo, gdy zarówno seria, jak i punkt są sformatowane?**

Wyraźne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają wyraźnego formatu serii lub, gdy format serii nie jest zdefiniowany, automatycznego stylu i motywu wykresu. Ustawienia grup, takie jak nakładanie i szerokość przerwy, kontrolują układ i nie są nadpisywane na poziomie punktu.

**Czy istnieje limit liczby serii, które wykres może zawierać?**

Aspose.Slides nie narzuca osobnego stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu określają praktyczny limit.

**Co zmienić, gdy kolumny są za blisko siebie lub za daleko od siebie?**

Wywołaj [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) w odpowiedniej grupie nadrzędnej serii. Zwiększ wartość, aby poszerzyć przestrzeń między klastrami, lub zmniejsz ją, aby przybliżyć klastry.