---
title: Dostosowywanie osi wykresu w prezentacjach przy użyciu PHP
linktitle: Oś wykresu
type: docs
url: /pl/php-java/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosowywanie osi
- manipulowanie osią
- zarządzanie osią
- właściwości osi
- maksymalna wartość
- minimalna wartość
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Odkryj, jak używać Aspose.Slides dla PHP poprzez Java, aby dostosować osie wykresów w prezentacjach PowerPoint dla raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu przy użyciu Aspose.Slides dla PHP przy użyciu Java. Obejmuje on obliczone wartości osi, zamianę wierszy i kolumn wykresu, widoczność osi, interwały etykiet kategorii i znaczników podziałek, kategorie dat i formatowanie, obrót tytułu, pozycjonowanie osi, jednostki wyświetlania oraz skalowanie logarytmiczne.

## **Pobierz maksymalne wartości na osi pionowej na wykresach**

Utwórz [Prezentacja](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) i dodaj wykres powierzchniowy z domyślnymi danymi. Wywołaj [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) przed odczytaniem obliczonych wartości osi, aby układ wykresu był aktualny.

Odczytaj [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) i [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) dla limitów osi oraz [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) i [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) dla interwałów podziałek. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) i [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) dostarczają skale jednostek czasu, które są istotne dla osi dat. Przykład przechowuje te wartości w zmiennych lokalnych i zapisuje wykres.

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

Użyj [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/), aby wymienić role serii i kategorii w danych wykresu. Każda poprzednia kategoria staje się serią, a każda poprzednia seria staje się kategorią. Zmienia to sposób grupowania danych; nie zamienia to osi poziomej i pionowej. Przykład używa [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) aby powiązać domyślne dane z `Sheet1!A1:D5`, włączając wiersz nagłówka i kolumnę kategorii, przed zamianą wierszy i kolumn. Zapisuje wykres z czterema seriami i trzema kategoriami.

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

## **Odwróć kolejność rysowania osi**

Użyj [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) aby odwrócić oś kategorii lub wartości. Na przykład, wykres słupkowy poziomy może wyświetlać etapy projektu od góry do dołu w tej samej kolejności co arkusz: Planowanie, Rozwój, Testowanie. Odwrócenie osi zmienia kierunek rysowania; nie sortuje ani nie zmienia układu danych w skoroszycie. Dla porównania, [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) wymienia role serii i kategorii.

Poniższy przykład tworzy wykres słupkowy poziomy z trzema etapami i jedną serią. Zapisuje prezentację z trzema slajdami: zwykła kolejność, odwrócone kategorie i odwrócone wartości. Każda kopia używa tego samego zestawu danych, a na każdej kopii odwrócona jest tylko jedna oś.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // Slajd 2: wyświetl pierwszą kategorię na górze.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Utrzymaj poziomą oś wartości na dole.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // Slajd 3: odwróć tylko poziomą skalę liczbową.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Odwrócenie osi może również przenieść prostopadłą oś na przeciwległą stronę wykresu. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) kontroluje, gdzie druga oś przecina konfigurowaną oś. Na slajdzie 2, wywołanie jej z `CrossesType::Maximum` na odwróconej osi kategorii utrzymuje poziomą oś wartości u dołu. Dla konkretnego punktu przecięcia użyj [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Sprawdź ustawienia przecięcia przy zmianie kierunku, szczególnie jeśli wykres już posiada niestandardowy punkt przecięcia. Wywołaj `setPlotOrderReversed` z `false`, aby przywrócić normalny kierunek rysowania; ustawienia przecięcia są oddzielne.

| Zwykła kolejność (slajd 1) | Odwrócone kategorie (slajd 2) | Odwrócone wartości (slajd 3) |
| --- | --- | --- |
| ![Wykres słupkowy poziomy ze zwykłą kolejnością osi kategorii i wartości](axis-order-normal.png) | ![Wykres słupkowy poziomy z kategoriami wyświetlanymi od góry do dołu](axis-order-categories-reversed.png) | ![Wykres słupkowy poziomy z odwróconą osią wartości i zerem po prawej](axis-order-values-reversed.png) |
| Kategorie biegną od dołu do góry; wartości rosną od lewej do prawej. | Planowanie, Rozwój i Testowanie biegną od góry do dołu. Wartości i kolejność wierszy w skoroszycie pozostają niezmienione. | Kategorie zachowują swoją normalną kolejność; wartości rosną od prawej do lewej. Oś kategorii przecina zero po prawej stronie. |

## **Wyłącz oś pionową dla wykresów liniowych**

Wywołaj [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) z `false` na osi pionowej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą osią pionową.

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

## **Wyłącz oś poziomą dla wykresów liniowych**

Wywołaj [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) z `false` na osi poziomej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą osią poziomą.

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

Użyj [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) aby wybrać oś kategorii daty lub tekstu. Ten przykład wymaga pliku `ExistingChart.pptx`, z wykresem jako pierwszym kształtem na pierwszym slajdzie i komórkami kategorii zawierającymi numeryczne wartości dat w Excelu. Zmienia on oś poziomą na oś daty. Wywołanie [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) z `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) z `1` oraz [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) z `TimeUnitType::Months` ustawia główne podziały co jeden miesiąc.

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

Gdy wykres ma wiele kategorii, zmniejsz liczbę widocznych etykiet osi bez usuwania kategorii lub punktów danych. Wywołaj [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) z `false`, a następnie przekaż żądany interwał kategorii do [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Dla tekstowych kategorii w ich normalnym porządku, liczenie zaczyna się od pierwszej kategorii:

| Interwał | Etykiety wyświetlane w przykładzie |
| --- | --- |
| `1` | Kategoria 1, Kategoria 2, Kategoria 3, ... Kategoria 24 |
| `2` | Kategoria 1, Kategoria 3, Kategoria 5, ... Kategoria 23 |
| `3` | Kategoria 1, Kategoria 4, Kategoria 7, ... Kategoria 22 |

Interwał `3` wyświetla co trzecią etykietę, pozostawiając dwie ukryte etykiety pomiędzy wyświetlonymi. Nie usuwa to odpowiadających kolumn. Automatyczne rozmieszczanie wybiera interwał w zależności od dostępnej przestrzeni; nie musi wyświetlać każdej etykiety.

Znaczniki podziałek mają osobne ustawienia. Wywołaj [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) z `false` i użyj [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) aby ustawić ich interwał. Na przykład, `1` utrzymuje znak podziałki przy każdym interwale kategorii, podczas gdy etykiety pojawiają się tylko co trzecią kategorię. Użyj [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) z widocznym stylem, aby zobaczyć rezultat. Ponowne wywołanie któregoś z automatycznych ustawień z `true` pozwala wykresowi ponownie wybrać ten interwał.

Poniższy samodzielny przykład tworzy 24 kategorie i jedną serię, a następnie zapisuje trzy slajdy w pliku `CategoryAxisIntervals.pptx`: automatyczne rozmieszczanie, ręczne rozmieszczanie etykiet z niezależnymi znacznikami podziałek oraz przywrócone automatyczne rozmieszczanie. Dwie kopie zachowują oryginalne dane wykresu. Nie wymaga wejściowej prezentacji. Poziomy tekst etykiet ułatwia zobaczyć różnicę w gęstości.

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

**Automatyczne rozmieszczanie (slajd 1):** W tym renderowaniu każda druga etykieta kategorii jest wyświetlana i łamie się na dwie linie. Wynik automatyczny może się różnić w zależności od rozmiaru wykresu, czcionek i renderera.

![Automatyczne rozmieszczanie etykiet kategorii przy widocznych wszystkich 24 kolumnach](category-axis-automatic.png)

**Ręczne rozmieszczanie (slajd 2):** Co trzecia etykieta jest wyświetlana w jednej linii, podczas gdy znaczniki podziałek pozostają przy każdym interwale kategorii. Wszystkie 24 kolumny, w tym te bez etykiet, pozostają widoczne z takimi samymi wartościami. Slajd 3 przywraca automatyczny wygląd przedstawiony powyżej.

![Ręczny interwał etykiet kategorii wynoszący trzy przy widocznych wszystkich 24 kolumnach](category-axis-manual.png)

### **Wybierz właściwą oś i interwał**

Użyj tego interwału liczby kategorii dla tekstowej osi kategorii, takiej jak oś kategorii wykresu kolumnowego, liniowego, powierzchniowego lub słupkowego. W wykresie kolumnowym jest to oś pozioma. W wykresie słupkowym poziomym oś kategorii jest pionowa, więc zastosuj te ustawienia do osi zwróconej przez [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Rozstawienie znaczników podziałek ma również zastosowanie do osi serii w wykresach, które ją posiadają.

Nie używaj rozmieszczania etykiet kategorii do ustawiania skali numerycznej osi wartości. Na osi wartości [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) określa różnicę w wartościach: na przykład jednostka główna `10` tworzy podziały przy 0, 10, 20 itd., gdy oś zaczyna się od zera. Interwał etykiet kategorii `3` liczy natomiast pozycje kategorii, niezależnie od ich wartości danych. Wykresy punktowe i bąbelkowe używają osi wartości zamiast tekstowej osi kategorii. Dla osi dat użyj jednostek i skal czasowych opisanych w [Change a Category Axis](#change-a-category-axis).

## **Ustaw format daty dla wartości osi kategorii**

Przykład zastępuje domyślne dane wykresu czterema rocznymi wartościami. Daty są przechowywane jako liczby seryjne OLE Automation w pierwszym arkuszu (indeks `0`), obliczane jako liczba dni od 30 grudnia 1899 dla tych dat. Użyj [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) z `CategoryAxisType::Date`, wywołaj [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) z `false` oraz przekaż `yyyy` do [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/), aby etykiety kategorii wyświetlały czterocyfrowe lata niezależnie od formatowania komórek.

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

Wywołaj [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) z `true` na osi pionowej, podaj tekst tytułu i użyj [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) aby obrócić tytuł. Kąt jest mierzony w stopniach; ten przykład zapisuje wykres kolumnowy z tytułem osi wartości obróconym o 90 stopni.

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

Użyj [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) aby kontrolować, czy oś wartości przecina oś kategorii pomiędzy kategoriami czy na znacznikach kategorii. To ustawienie dotyczy osi kategorii. Przykład ustawia je na `true` na poziomej osi kategorii wykresu kolumnowego i zapisuje wynik.

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

Użyj [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) aby skalować etykiety na osi wartości bez zmiany danych podstawowych. Z [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) ustawionym na `Millions`, wartość 60 000 000 jest wyświetlana jako 60. Przykład tworzy wykres kolumnowy i stosuje jednostkę wyświetlania miliony do jego osi pionowej.

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

Logarytmiczna oś wartości jest przydatna, gdy dodatnie wartości rozciągają się na kilka rzędów wielkości. Na przykład, usługa może otrzymywać 10, 100, 1 000, 10 000 i 100 000 żądań w ciągu pięciu okresów. Na skali liniowej mniejsze wartości są blisko siebie w pobliżu zera. Skala logarytmiczna ułatwia porównanie ich względnego wzrostu: równe odległości odpowiadają równym stosunkom, a nie równym różnicom.

Wywołaj [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) z `true` na osi wartości i użyj [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) aby wybrać podstawę. Zmienia to sposób wyświetlania istniejących wartości; nie zmienia danych ani nie dodaje logarytmicznej linii trendu. Linia trendu reprezentuje dopasowaną zależność w danych i jest osobną funkcją.

### **Wybierz oś wartości i podstawę**

Dla wykresu liniowego lub kolumnowego, oś wartości jest zwracana przez [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Dla wykresu słupkowego poziomego, jest zwracana przez [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Wykresy punktowe i bąbelkowe mają dwie osie wartości, więc wybierz oś poziomą dla wartości X, oś pionową dla wartości Y, lub obie. Nie stosuj skalowania logarytmicznego do osi kategorii.

Domyślna podstawa logarytmu to `10`. Dla wykresów PPTX użyj podstawy od `2` do `1000`, włącznie; obsługiwane są także ułamkowe podstawy, takie jak `2.5`. Przy podstawie `10` kolejne potęgi, takie jak 10, 100, 1 000 i 10 000, są równomiernie rozmieszczone.

### **Porównaj skalowanie liniowe i logarytmiczne**

Poniższy samodzielny przykład tworzy wykres liniowy z pięcioma liczbami żądań na pierwszym slajdzie, następnie klonuje ten slajd i włącza logarytmiczną oś wartości o podstawie 10 na drugim. Oba slajdy zachowują te same dane.

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

    // Zachowaj pierwszy slajd liniowy i zmień tylko skalę osi wartości w kopii.
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

![Wykres liniowy w PowerPoint pokazujący pięć liczb żądań na osi wartości liniowej](value-axis-linear.png)

**Skala logarytmiczna (slajd 2):** Równe odległości pionowe reprezentują równe stosunki. Każdy okres ma dziesięć razy więcej żądań niż poprzedni, więc punkty tworzą prostą rosnącą linię na skali o podstawie 10. Etykiety osi nadal pokazują oryginalne liczby żądań.

![Te same pięć liczb żądań w PowerPoint na logarytmicznej osi wartości o podstawie 10](value-axis-logarithmic.png)

### **Obsługa zer i wartości ujemnych**

Skala logarytmiczna może wyświetlać tylko wyłącznie dodatnie wartości. Sprawdź dane przed jej włączeniem. Jeśli zero lub wartości ujemne są istotne, zachowaj skalę liniową lub pokaż je osobno. Jeśli wykluczenie tych wartości jest odpowiednie dla analizy, wyjaśnij pominięcie. Nie zamieniaj ich cicho na małe liczby dodatnie, ponieważ zmienia to znaczenie danych. Każde ręcznie skonfigurowane minimum lub maksimum dla osi logarytmicznej musi również być dodatnie.

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Użyj [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) aby wybrać zachowanie przecięcia. Aby określić numeryczną wartość przecięcia, użyj [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Te ustawienia pozwalają przenieść przecięcie osi na odpowiednią linię bazową.

**Jak mogę pozycjonować etykiety podziałek względem osi?**

Wywołaj [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) używając [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` lub `None`. Aby kontrolować same znaczniki podziałek, użyj [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) lub [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); są one oddzielne od pozycjonowania etykiet.