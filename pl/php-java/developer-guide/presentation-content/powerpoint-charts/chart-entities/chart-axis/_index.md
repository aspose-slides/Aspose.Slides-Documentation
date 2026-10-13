---
title: Dostosuj osie wykresów w prezentacjach przy użyciu PHP
linktitle: Oś wykresu
type: docs
url: /pl/php-java/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosuj oś
- manipuluj osią
- zarządzaj osią
- właściwości osi
- wartość maksymalna
- wartość minimalna
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak używać Aspose.Slides dla PHP via Java do dostosowywania osi wykresów w prezentacjach PowerPoint przeznaczonych do raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu w Aspose.Slides for PHP via Java. Omówiono wyliczane wartości osi, zamianę wierszy i kolumn wykresu, widoczność osi, interwały etykiet kategorii i znaczników podziałek, kategorie dat i formatowanie, obrót tytułu, pozycjonowanie osi, jednostki wyświetlania oraz skalowanie logarytmiczne.

## **Uzyskaj maksymalne wartości na pionowej osi wykresów**

Utwórz [Prezentację](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) i dodaj wykres powierzchniowy z domyślnymi danymi. Wywołaj [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) przed odczytaniem wyliczonych wartości osi, aby układ wykresu był aktualny.

Odczytaj [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) i [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) dla granic osi oraz [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) i [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) dla interwałów podziałek. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) i [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) dostarczają skale jednostek czasu, które są istotne dla osi dat. Przykład zapisuje te wartości w zmiennych lokalnych i zapisuje wykres.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zamień dane między osiami**

Użyj [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) aby wymienić role serii i kategorii w danych wykresu. Każda poprzednia kategoria staje się serią, a każda poprzednia seria staje się kategorią. Zmienia to sposób grupowania danych; nie wymienia to osi poziomej i pionowej. Przykład używa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) aby powiązać domyślne dane z `Sheet1!A1:D5`, włączając wiersz nagłówka i kolumnę kategorii, przed zamianą wierszy i kolumn. Zapisuje wykres z czterema seriami i trzema kategoriami.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ukryj pionową oś w wykresach liniowych**

Wywołaj [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) z wartością `false` na pionowej osi, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą pionową osią.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ukryj poziomą oś w wykresach liniowych**

Wywołaj [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) z wartością `false` na poziomej osi, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą poziomą osią.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Zmień oś kategorii**

Użyj [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) aby wybrać oś dat lub tekstową. Przykład wymaga pliku `ExistingChart.pptx`, w którym wykres jest pierwszym kształtem na pierwszym slajdzie, a komórki kategorii zawierają numeryczne wartości dat Excel. Zmienia poziomą oś na oś daty. Wywołanie [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) z wartością `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) z wartością `1` oraz [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) z `TimeUnitType::Months` ustawia główne podziały w odstępach jednego miesiąca.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontroluj interwały etykiet osi kategorii**

Gdy wykres ma wiele kategorii, zmniejsz liczbę widocznych etykiet osi bez usuwania kategorii lub punktów danych. Wywołaj [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) z wartością `false`, a następnie przekaż żądany interwał kategorii do [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Dla tekstowych kategorii w normalnym porządku licznik zaczyna się od pierwszej kategorii:

| Interwał | Etykiety wyświetlane w przykładzie |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Interwał `3` wyświetla co trzecią etykietę, pozostawiając dwie ukryte między wyświetlanymi. Nie usuwa to odpowiednich kolumn. Automatyczne rozmieszczenie wybiera interwał na podstawie dostępnej przestrzeni; niekoniecznie wyświetla każdą etykietę.

Znaczniki podziałek mają oddzielne ustawienia. Wywołaj [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) z wartością `false` i użyj [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) aby ustawić ich interwał. Na przykład `1` utrzymuje znacznik podziałki przy każdym interwale kategorii, podczas gdy etykiety pojawiają się co trzecią kategorię. Użyj [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) z widocznym stylem, aby zobaczyć wynik. Ponowne ustawienie dowolnego z automatycznych setterów na `true` pozwala wykresowi ponownie wybrać ten interwał.

Poniższy samodzielny przykład tworzy 24 kategorie i jedną serię, a następnie zapisuje trzy slajdy w `CategoryAxisIntervals.pptx`: automatyczne rozmieszczenie, ręczne rozmieszczenie etykiet z niezależnymi znacznikami podziałek oraz przywrócone automatyczne rozmieszczenie. Dwie kopie zachowują oryginalne dane wykresu. Żadna prezentacja wejściowa nie jest wymagana. Tekst poziomej etykiety ułatwia zauważenie różnicy w gęstości.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Slajd 2: pokaż co trzecią etykietę, ale zachowaj znacznik podziałki dla każdej kategorii.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Slajd 3: pozwól wykresowi ponownie wybrać oba interwały.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatyczne rozmieszczenie (slajd 1):** W tym renderowaniu co druga etykieta kategorii jest wyświetlana i rozkłada się na dwie linie. Automatyczny wynik może się różnić w zależności od rozmiaru wykresu, czcionek i renderera.

![Automatyczne rozmieszczenie etykiet kategorii przy wszystkich 24 widocznych kolumnach](category-axis-automatic.png)

**Ręczne rozmieszczenie (slajd 2):** Co trzecia etykieta jest wyświetlana w jednej linii, podczas gdy znaczniki podziałek pozostają przy każdym interwale kategorii. Wszystkie 24 kolumny, w tym te bez etykiet, pozostają widoczne z tymi samymi wartościami. Slajd 3 przywraca automatyczny wygląd pokazany powyżej.

![Ręczny interwał etykiet kategorii równy trzem przy wszystkich 24 widocznych kolumnach](category-axis-manual.png)

### **Wybierz właściwą oś i interwał**

Użyj tego interwału liczb kategorii dla tekstowej osi kategorii, takiej jak oś kategorii wykresu słupkowego, liniowego, powierzchniowego lub kolumnowego. W wykresie kolumnowym jest to oś pozioma. W wykresie poziomym słupków oś kategorii jest pionowa, więc zastosuj te ustawienia do osi zwróconej przez [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Rozstawienie znaczników podziałek ma też zastosowanie do osi serii w wykresach, które taką posiadają.

Nie używaj rozmieszczania etykiet kategorii do ustawiania numerycznej skali osi wartości. Na osi wartości [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) określa różnicę w wartościach: na przykład główna jednostka `10` powoduje podziały przy 0, 10, 20 itd., gdy oś zaczyna się od zera. Interwał etykiet kategorii `3` liczy pozycje kategorii, niezależnie od ich wartości danych. Wykresy rozrzutu i bąbelkowe używają osi wartości, a nie tekstowej osi kategorii. Dla osi dat użyj jednostek i skal czasowych opisanych w sekcji [Zmień oś kategorii](#zmień-osi-kategorii).

## **Ustaw format daty dla wartości osi kategorii**

Przykład zastępuje domyślne dane wykresu czterema rocznymi wartościami. Daty są przechowywane jako liczby seryjne OLE Automation w pierwszym arkuszu (indeks `0`), obliczane jako liczba dni od 30 grudnia 1899. Użyj [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) z `CategoryAxisType::Date`, wywołaj [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) z `false` i przekaż `yyyy` do [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/), aby etykiety kategorii wyświetlały czterocyfrowe lata niezależnie od formatowania komórek.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw kąt obrotu tytułu osi wykresu**

Wywołaj [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) z wartością `true` na pionowej osi, podaj tekst tytułu i użyj [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) aby obrócić tytuł. Kąt podawany jest w stopniach; przykład zapisuje wykres kolumnowy z tytułem osi wartości obróconym o 90 stopni.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw pozycję osi na osi kategorii lub wartości**

Użyj [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) aby kontrolować, czy oś wartości przecina oś kategorii pomiędzy kategoriami czy na znacznikach podziałek kategorii. To ustawienie dotyczy osi kategorii. Przykład ustawia je na `true` na poziomej osi kategorii wykresu kolumnowego i zapisuje wynik.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ustaw jednostkę wyświetlania na osi wartości wykresu**

Użyj [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) aby skalować etykiety na osi wartości bez zmiany danych źródłowych. Przy ustawieniu [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) na `Millions`, wartość 60 000 000 jest wyświetlana jako 60. Przykład tworzy wykres kolumnowy i stosuje jednostkę wyświetlania „miliony” do jego pionowej osi.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Skonfiguruj logarytmiczną oś wartości**

Logarytmiczna oś wartości jest przydatna, gdy dodatnie wartości rozciągają się na kilka rzędów wielkości. Na przykład usługa może otrzymywać 10, 100, 1 000, 10 000 i 100 000 żądań w pięciu okresach. Na skali liniowej mniejsze wartości są skupione blisko zera. Skala logarytmiczna ułatwia porównanie ich względnego wzrostu: równe odległości oznaczają równe stosunki, a nie równe różnice.

Wywołaj [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) z wartością `true` na osi wartości i użyj [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) aby wybrać podstawę. Zmienia to sposób wyświetlania istniejących wartości; nie zmienia danych ani nie dodaje logarytmicznej linii trendu. Linia trendu reprezentuje dopasowaną zależność w danych i jest odrębną funkcją.

### **Wybierz oś wartości i podstawę**

Dla wykresu liniowego lub kolumnowego oś wartości zwracana jest przez [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Dla wykresu poziomego słupka jest to [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Wykresy rozrzutu i bąbelkowe mają dwie osie wartości, więc wybierz oś poziomą dla wartości X, pionową dla Y lub obie. Nie stosuj skalowania logarytmicznego do osi kategorii.

Domyślna podstawa logarytmu to `10`. Dla wykresów PPTX można używać podstaw od `2` do `1000` włącznie; obsługiwane są także ułamkowe podstawy, takie jak `2.5`. Przy podstawie `10` kolejne potęgi (10, 100, 1 000, 10 000) są równomiernie rozmieszczone.

### **Porównaj skalowanie liniowe i logarytmiczne**

Poniższy samodzielny przykład tworzy wykres liniowy z pięcioma liczbami żądań na pierwszym slajdzie, a następnie klonuje ten slajd i włącza logarytmiczną oś wartości o podstawie 10 na drugim. Oba slajdy zachowują te same dane.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Utrzymaj pierwszy slajd jako liniowy i zmień tylko skalę osi wartości w kopii.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Skala liniowa (slajd 1):** Równe odległości pionowe reprezentują równe różnice w liczbie żądań. Największa wartość dominuje wykres, co utrudnia rozróżnienie mniejszych wartości.

![Wykres liniowy w PowerPoint pokazujący pięć liczby żądań na osi wartości liniowej](value-axis-linear.png)

**Skala logarytmiczna (slajd 2):** Równe odległości pionowe reprezentują równe stosunki. Każdy okres ma dziesięciokrotnie więcej żądań niż poprzedni, więc punkty tworzą prostą rosnącą linię na skali logarytmicznej o podstawie 10. Etykiety osi wciąż pokazują oryginalne liczby żądań.

![Te same pięć liczby żądań w PowerPoint na logarytmicznej osi wartości o podstawie 10](value-axis-logarithmic.png)

### **Obsługa zer i wartości ujemnych**

Skala logarytmiczna może wyświetlać wyłącznie wartości ściśle dodatnie. Sprawdź dane przed jej włączeniem. Jeśli zero lub wartości ujemne mają znaczenie, zachowaj skalę liniową lub pokaż je oddzielnie. Jeśli ich wykluczenie jest uzasadnione, wyjaśnij pominięcie. Nie zastępuj ich cicho małymi dodatnimi liczbami, ponieważ zmienia to znaczenie danych. Każde ręcznie ustawione minimum lub maksimum dla logarytmicznej osi musi być także dodatnie.

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Użyj [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) aby wybrać zachowanie przecięcia. Aby określić numeryczną wartość przecięcia, użyj [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Te ustawienia pozwalają przesunąć przecięcie osi do odpowiedniej linii bazowej.

**Jak mogę pozycjonować etykiety podziałek względem osi?**

Wywołaj [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) używając [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` lub `None`. Aby kontrolować same znaczniki podziałek, użyj [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) lub [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); są one oddzielne od pozycjonowania etykiet.