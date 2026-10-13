---
title: Dostosowywanie osi wykresu w prezentacjach przy użyciu JavaScript
linktitle: Oś wykresu
type: docs
url: /pl/nodejs-java/chart-axis/
keywords:
- oś wykresu
- oś pionowa
- oś pozioma
- dostosować oś
- manipulować osią
- zarządzać osią
- właściwości osi
- maksymalna wartość
- minimalna wartość
- linia osi
- format daty
- tytuł osi
- pozycja osi
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak używać JavaScript wraz z Aspose.Slides for Node.js via Java do dostosowywania osi wykresów w prezentacjach PowerPoint dla raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresów przy użyciu Aspose.Slides for Node.js via Java. Omówiono wyliczane wartości osi, zamianę wierszy i kolumn wykresu, widoczność osi, interwały etykiet kategorii i znaczników podziałki, kategorie dat i formatowanie, obrót tytułu, pozycjonowanie osi, jednostki wyświetlania oraz skalowanie logarytmiczne.

## **Uzyskaj maksymalne wartości na pionowej osi wykresów**

Utwórz [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) i dodaj wykres powierzchniowy z domyślnymi danymi. Wywołaj [validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) przed odczytaniem wyliczonych wartości osi, aby układ wykresu był aktualny.

Odczytaj [getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmaxvalue/) i [getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminvalue/) w celu uzyskania limitów osi oraz [getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunit/) i [getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunit/) dla interwałów znaczników. [getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualmajorunitscale/) i [getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/getactualminorunitscale/) dostarczają skal czasu, które mają znaczenie dla osi dat. Przykład zapisuje te wartości w zmiennych lokalnych i zapisuje wykres.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    var majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    var majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    var minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zamień dane między osiami**

Użyj [switchRowColumn](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/switchrowcolumn/) aby wymienić role serii i kategorii w danych wykresu. Każda poprzednia kategoria staje się serią, a każda poprzednia seria staje się kategorią. Zmienia to sposób grupowania danych; nie zamienia to osi poziomej i pionowej. Przykład używa [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) aby powiązać domyślne dane z `Sheet1!A1:D5`, w tym wiersz nagłówka i kolumnę kategorii, przed zamianą wierszy i kolumn. Zapisuje wykres z czterema seriami i trzema kategoriami.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wyłącz pionową oś dla wykresów liniowych**

Wywołaj [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) z wartością `false` na pionowej osi, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą pionową osią.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wyłącz poziomą oś dla wykresów liniowych**

Wywołaj [setVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setvisible/) z wartością `false` na poziomej osi, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukrytą poziomą osią.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zmień oś kategorii**

Użyj [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) aby wybrać oś kategorii daty lub tekstu. Ten przykład wymaga `ExistingChart.pptx`, z wykresem jako pierwszym kształtem na pierwszym slajdzie oraz komórkami kategorii zawierającymi numeryczne wartości dat Excel. Zmienia poziomą oś na oś daty. Wywołanie [setAutomaticMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmajorunit/) z wartością `false`, [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) z `1` oraz [setMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunitscale/) z `TimeUnitType.Months` ustawia główne znaczniki co miesiąc.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(aspose.slides.TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontroluj interwały etykiet osi kategorii**

Jeśli wykres ma wiele kategorii, zmniejsz liczbę widocznych etykiet osi bez usuwania kategorii ani punktów danych. Wywołaj [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticticklabelspacing/) z wartością `false`, a następnie przekaż żądany interwał kategorii do [setTickLabelSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelspacing/). Dla tekstowych kategorii w ich normalnym porządku liczenie zaczyna się od pierwszej kategorii:

| Interwał | Etykiety wyświetlane w przykładzie |
| --- | --- |
| `1` | Kategoria 1, Kategoria 2, Kategoria 3, ... Kategoria 24 |
| `2` | Kategoria 1, Kategoria 3, Kategoria 5, ... Kategoria 23 |
| `3` | Kategoria 1, Kategoria 4, Kategoria 7, ... Kategoria 22 |

Interwał `3` wyświetla co trzecią etykietę, ukrywając dwie etykiety pomiędzy wyświetlanymi. Nie usuwa to odpowiadających kolumn. Automatyczne rozmieszczanie wybiera interwał w zależności od dostępnej przestrzeni; nie musi wyświetlać każdej etykiety.

Znaczniki podziałki mają osobne ustawienia. Wywołaj [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomatictickmarksspacing/) z wartością `false` i użyj [setTickMarksSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settickmarksspacing/) , aby ustawić ich interwał. Na przykład `1` zachowuje znacznik przy każdym interwale kategorii, podczas gdy etykiety pojawiają się tylko co trzecią kategorię. Użyj [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) z widocznym stylem, aby zobaczyć rezultat. Ponowne wywołanie któregoś z automatycznych ustawień z `true` pozwala wykresowi ponownie wybrać ten interwał.

Następujący samodzielny przykład tworzy 24 kategorie i jedną serię, a następnie zapisuje trzy slajdy w pliku `CategoryAxisIntervals.pptx`: automatyczne rozmieszczanie, ręczne rozmieszczanie etykiet z niezależnymi znacznikami oraz przywrócone automatyczne rozmieszczanie. Obie kopie zachowują oryginalne dane wykresu. Nie wymaga żadnej prezentacji wejściowej. Poziomy tekst etykiet ułatwia dostrzeżenie różnicy w gęstości.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.ClusteredColumn);
    for (var i = 0; i < 24; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        var valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    var axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(aspose.slides.CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(aspose.slides.TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slajd 2: pokazuj co trzecią etykietę, ale zachowaj znacznik podziałki dla każdej kategorii.
    var manualSlide = presentation.getSlides().addClone(slide);
    var manualChart = manualSlide.getShapes().get_Item(0);
    var manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slajd 3: pozwól wykresowi ponownie wybrać oba interwały.
    var restoredSlide = presentation.getSlides().addClone(manualSlide);
    var restoredChart = restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatyczne rozmieszczanie (slajd 1):** W tym renderowaniu co druga etykieta kategorii jest wyświetlana i łamie się na dwa wiersze. Wynik automatyczny może się różnić w zależności od rozmiaru wykresu, czcionek i renderera.

![Automatyczne rozmieszczanie etykiet kategorii przy wszystkich 24 widocznych kolumnach](category-axis-automatic.png)

**Ręczne rozmieszczanie (slajd 2):** Co trzecia etykieta jest wyświetlana w jednym wierszu, podczas gdy znaczniki podziałki pozostają przy każdym interwale kategorii. Wszystkie 24 kolumny, w tym te bez etykiet, pozostają widoczne z tymi samymi wartościami. Slajd 3 przywraca automatyczny wygląd pokazany powyżej.

![Ręczny interwał etykiet kategorii wynoszący trzy przy wszystkich 24 widocznych kolumnach](category-axis-manual.png)

### **Wybierz prawidłową oś i interwał**

Użyj tego interwału liczb kategorii dla tekstowej osi kategorii, takiej jak oś kategorii wykresu kolumnowego, liniowego, powierzchniowego lub słupkowego. W wykresie kolumnowym jest to oś pozioma. W wykresie słupkowym poziomym oś kategorii jest pionowa, więc zastosuj te ustawienia do osi zwróconej przez [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Rozstawienie znaczników podziałki ma również zastosowanie do osi serii w wykresach, które ją posiadają.

Nie używaj rozmieszczania etykiet kategorii do ustawiania numerycznej skali osi wartości. Na osi wartości [setMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajorunit/) określa różnicę w wartościach: na przykład jednostka główna `10` tworzy znaczniki przy 0, 10, 20 itd., gdy oś zaczyna się od zera. Interwał etykiet kategorii `3` liczy pozycje kategorii, niezależnie od ich wartości danych. Wykresy punktowe i bąbelkowe używają osi wartości zamiast tekstowej osi kategorii. Dla osi dat użyj jednostek głównych i skal opartych na czasie, jak opisano w [Change a Category Axis](#change-a-category-axis).

## **Ustaw format daty dla wartości osi kategorii**

Przykład zastępuje domyślne dane wykresu czterema rocznymi wartościami. Daty są przechowywane jako numery seryjne OLE Automation w pierwszym arkuszu (indeks `0`), obliczane jako liczba dni od 30 grudnia 1899 dla tych dat. Obliczenia JavaScript używają znaczników czasu UTC i dzielą różnicę przez 86 400 000 milisekund na dzień. Użyj [setCategoryAxisType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcategoryaxistype/) z `CategoryAxisType.Date`, wywołaj [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) z `false` i przekaż `yyyy` do [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/), aby etykiety kategorii wyświetlały czterocyfrowe lata niezależnie od formatowania komórek.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var baseDate = Date.UTC(1899, 11, 30);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    for (var i = 0; i < 4; i++) {
        var date = Date.UTC(2015 + i, 0, 1);
        var categoryCell = workbook.getCell(0, i + 1, 0, (date - baseDate) / 86400000);
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(aspose.slides.CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw kąt obrotu tytułu osi wykresu**

Wywołaj [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/settitle/) z wartością `true` na pionowej osi, podaj tekst tytułu i użyj [setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setrotationangle/) , aby obrócić tytuł. Kąt jest mierzony w stopniach; ten przykład zapisuje wykres kolumnowy z tytułem osi wartości obróconym o 90 stopni.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw pozycję osi na osi kategorii lub wartości**

Użyj [setAxisBetweenCategories](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaxisbetweencategories/) , aby kontrolować, czy oś wartości przecina oś kategorii pomiędzy kategoriami czy na znacznikach kategorii. To ustawienie ma zastosowanie do osi kategorii. Przykład ustawia je na `true` na poziomej osi kategorii wykresu kolumnowego i zapisuje wynik.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw jednostkę wyświetlania na osi wartości wykresu**

Użyj [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setdisplayunit/) , aby skalować etykiety na osi wartości bez zmiany danych podstawowych. Przy ustawieniu [DisplayUnitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/displayunittype/) na `Millions`, wartość 60 000 000 jest wyświetlana jako 60. Przykład tworzy wykres kolumnowy i stosuje jednostkę wyświetlania miliony do jego pionowej osi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Millions);

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Skonfiguruj logarytmiczną oś wartości**

Logarytmiczna oś wartości jest przydatna, gdy dodatnie wartości obejmują kilka rzędów wielkości. Na przykład usługa może otrzymywać 10, 100, 1 000, 10 000 i 100 000 żądań w pięciu okresach. Na skali liniowej mniejsze wartości znajdują się blisko siebie w pobliżu zera. Skala logarytmiczna ułatwia porównanie ich względnego wzrostu: równe odległości reprezentują równe stosunki, a nie równe różnice.

Wywołaj [setLogarithmic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogarithmic/) z wartością `true` na osi wartości i użyj [setLogBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlogbase/) , aby wybrać podstawę. Zmienia to sposób wyświetlania istniejących wartości; nie zmienia danych ani nie dodaje logarytmicznej linii trendu. Linia trendu reprezentuje dopasowaną zależność w danych i jest odrębną funkcją.

### **Wybierz oś wartości i podstawę**

Dla wykresu liniowego lub kolumnowego oś wartości jest zwracana przez [getVerticalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/getverticalaxis/). Dla wykresu słupkowego poziomego jest zwracana przez [getHorizontalAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axesmanager/gethorizontalaxis/). Wykresy punktowe i bąbelkowe mają dwie osie wartości, więc wybierz oś poziomą dla wartości X, oś pionową dla wartości Y lub obie. Nie stosuj skalowania logarytmicznego do osi kategorii.

Domyślna podstawa logarytmu to `10`. Dla wykresów PPTX użyj podstawy od `2` do `1000`, włącznie; obsługiwane są także ułamkowe podstawy, takie jak `2.5`. Przy podstawie `10` kolejne potęgi, takie jak 10, 100, 1 000 i 10 000, są równomiernie rozmieszczone.

### **Porównaj skalowanie liniowe i logarytmiczne**

Następujący samodzielny przykład tworzy wykres liniowy z pięcioma liczbami żądań na pierwszym slajdzie, a następnie klonuje ten slajd i włącza logarytmiczną oś wartości o podstawie 10 na drugim. Oba slajdy zachowują te same dane.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    var workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Line);
    var values = [10, 100, 1000, 10000, 100000];

    for (var i = 0; i < values.length; i++) {
        var categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        var valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Zachowaj pierwszy slajd liniowy i zmień tylko skalę osi wartości w kopii.
    var logarithmicSlide = presentation.getSlides().addClone(slide);
    var logarithmicChart = logarithmicSlide.getShapes().get_Item(0);
    var valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Skala liniowa (slajd 1):** Równe odległości pionowe reprezentują równe różnice w liczbie żądań. Największa wartość dominuje wykres, utrudniając rozróżnienie mniejszych wartości.

![Wykres liniowy w PowerPoint pokazujący pięć liczby żądań na liniowej osi wartości](value-axis-linear.png)

**Skala logarytmiczna (slajd 2):** Równe odległości pionowe reprezentują równe stosunki. Każdy okres ma dziesięć razy więcej żądań niż poprzedni, więc punkty tworzą prostą rosnącą linię na skali o podstawie 10. Etykiety osi nadal pokazują oryginalne liczby żądań.

![Te same pięć liczby żądań w PowerPoint na logarytmicznej osi wartości o podstawie 10](value-axis-logarithmic.png)

### **Obsługa zer i wartości ujemnych**

Skala logarytmiczna może wyświetlać wyłącznie wartości ściśle dodatnie. Sprawdź dane przed jej włączeniem. Jeśli wartości zero lub ujemne mają znaczenie, zachowaj skalę liniową lub pokaż je osobno. Jeśli wykluczenie tych wartości jest uzasadnione w analizie, wyjaśnij to pominięcie. Nie zastępuj ich cicho małymi liczbami dodatnimi, gdyż zmienia to znaczenie danych. Każde ręcznie skonfigurowane minimum lub maksimum dla osi logarytmicznej musi również być dodatnie.

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Użyj [setCrossType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrosstype/) , aby wybrać zachowanie przecięcia. Aby określić numeryczną wartość przecięcia, użyj [setCrossAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setcrossat/). Te ustawienia pozwalają przenieść przecięcie osi na odpowiednią linię bazową.

**Jak mogę pozycjonować etykiety znaczników względem osi?**

Wywołaj [setTickLabelPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setticklabelposition/) używając [TickLabelPositionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` lub `None`. Aby kontrolować same znaczniki podziałki, użyj [setMajorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmajortickmark/) lub [setMinorTickMark](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setminortickmark/) ; są one oddzielne od pozycjonowania etykiet.