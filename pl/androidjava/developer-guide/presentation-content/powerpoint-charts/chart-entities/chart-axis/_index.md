---
title: Dostosuj osie wykresu w prezentacjach na Androidzie
linktitle: Oś wykresu
type: docs
url: /pl/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak używać Aspose.Slides dla Androida w Javie, aby dostosować osie wykresu w prezentacjach PowerPoint do raportów i wizualizacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować osie wykresu w Aspose.Slides dla Android przy użyciu Javy. Obejmuje obliczone wartości osi, zamianę wierszy i kolumn wykresu, widoczność osi, interwały etykiet kategorii i znaczników podziałek, kategorie dat i formatowanie, obrót tytułu, pozycjonowanie osi, jednostki wyświetlania oraz skalowanie logarytmiczne.

## **Uzyskaj maksymalne wartości na osi pionowej wykresów**

Utwórz [Prezentację](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) i dodaj wykres obszarowy z domyślnymi danymi. Wywołaj [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) przed odczytem obliczonych wartości osi, aby układ wykresu był aktualny.

Odczytaj [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) i [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) dla limitów osi oraz [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) i [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) dla interwałów podziałek. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) i [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) dostarczają skal jednostek czasu, które są istotne dla osi dat. Przykład zapisuje te wartości w zmiennych lokalnych i zapisuje wykres.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zamień dane między osiami**

Użyj [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) aby wymienić role serii i kategorii w danych wykresu. Każda poprzednia kategoria staje się serią, a każda poprzednia seria staje się kategorią. Zmienia to sposób grupowania danych; nie zamienia to osi poziomej i pionowej. Przykład używa [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) aby powiązać domyślne dane z `Sheet1!A1:D5`, włączając wiersz nagłówka i kolumnę kategorii, przed zamianą wierszy i kolumn. Zapisuje wykres z czterema seriami i trzema kategoriami.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukryj oś pionową dla wykresów liniowych**

Wywołaj [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) z wartością `false` na osi pionowej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukryta osią pionową.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukryj oś poziomą dla wykresów liniowych**

Wywołaj [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) z wartością `false` na osi poziomej, aby ją ukryć. Przykład tworzy wykres liniowy z domyślnymi danymi i zapisuje go z ukryta osią poziomą.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zmień oś kategorii**

Użyj [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) , aby wybrać oś kategorii daty lub tekstu. Ten przykład wymaga pliku `ExistingChart.pptx`, z wykresem będącym pierwszą figurą na pierwszym slajdzie oraz komórkami kategorii zawierającymi numeryczne wartości dat Excel. Zmienia oś poziomą na oś datową. Wywołanie [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) z `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) z `1` oraz [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) z `TimeUnitType.Months` ustawia główne podziały co miesiąc.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontroluj interwały etykiet osi kategorii**

Gdy wykres ma wiele kategorii, zmniejsz liczbę widocznych etykiet osi bez usuwania kategorii lub punktów danych. Wywołaj [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) z `false`, a następnie przekaż żądany interwał kategorii do [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). Dla tekstowych kategorii w ich normalnym porządku liczenie zaczyna się od pierwszej kategorii:

| Interwał | Etykiety wyświetlane w przykładzie |
| --- | --- |
| `1` | Kategoria 1, Kategoria 2, Kategoria 3, ... Kategoria 24 |
| `2` | Kategoria 1, Kategoria 3, Kategoria 5, ... Kategoria 23 |
| `3` | Kategoria 1, Kategoria 4, Kategoria 7, ... Kategoria 22 |

Interwał `3` wyświetla co trzecią etykietę, ukrywając dwie etykiety pomiędzy wyświetlanymi. Nie usuwa to odpowiadających kolumn. Automatyczne rozmieszczenie wybiera interwał w oparciu o dostępne miejsce; niekoniecznie wyświetla wszystkie etykiety.

Znaczniki podziałek mają odrębne ustawienia. Wywołaj [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) z `false` i użyj [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) , aby ustawić ich interwał. Na przykład `1` pozostawia znacznik podziałki przy każdym interwale kategorii, podczas gdy etykiety pojawiają się tylko co trzecią kategorię. Użyj [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) z widocznym stylem, aby zobaczyć rezultat. Ponowne wywołanie któregokolwiek z automatycznych setterów z `true` pozwala wykresowi ponownie wybrać ten interwał.

Poniższy samodzielny przykład tworzy 24 kategorie i jedną serię, a następnie zapisuje trzy slajdy w pliku `CategoryAxisIntervals.pptx`: automatyczne rozmieszczenie, ręczne rozmieszczenie etykiet z niezależnymi znacznikami podziałek oraz przywrócone automatyczne rozmieszczenie. Dwie kopie zachowują pierwotne dane wykresu. Nie jest wymagana żadna prezentacja wejściowa. Poziomy tekst etykiet ułatwia zauważenie różnicy w gęstości.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Slajd 2: pokaż każdą trzecią etykietę, ale zachowaj znacznik podziałki dla każdej kategorii.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slajd 3: pozwól wykresowi ponownie wybrać oba interwały.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatyczne rozmieszczenie (slajd 1):**  
W tym renderowaniu co druga etykieta kategorii jest wyświetlana i łamie się na dwa wiersze. Wynik automatyczny może się różnić w zależności od rozmiaru wykresu, czcionek i renderera.

![Automatyczne rozmieszczenie etykiet kategorii przy widocznych wszystkich 24 kolumnach](category-axis-automatic.png)

**Ręczne rozmieszczenie (slajd 2):**  
Co trzecia etykieta jest wyświetlana w jednym wierszu, podczas gdy znaczniki podziałek pozostają przy każdym interwale kategorii. Wszystkie 24 kolumny, w tym te bez etykiet, pozostają widoczne z tymi samymi wartościami. Slajd 3 przywraca automatyczny wygląd pokazany powyżej.

![Ręczny interwał etykiet kategorii co trzy przy widocznych wszystkich 24 kolumnach](category-axis-manual.png)

### **Wybierz prawidłową oś i interwał**

Użyj tego interwału liczby kategorii dla tekstowej osi kategorii, takiej jak oś kategorii wykresu kolumnowego, liniowego, obszarowego lub słupkowego. W wykresie kolumnowym jest to oś pozioma. W poziomym wykresie słupkowym oś kategorii jest pionowa, więc zastosuj te ustawienia do osi zwróconej przez [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Rozstawienie znaczników podziałek ma również zastosowanie do osi serii w wykresach, które ją posiadają.

Nie używaj rozmieszczania etykiet kategorii do ustawiania numerycznej skali osi wartości. Na osi wartości [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) określa różnicę w wartościach: na przykład jednostka główna `10` powoduje podziały w punktach 0, 10, 20 itd., gdy oś zaczyna się od zera. Interwał etykiet kategorii `3` liczy natomiast pozycje kategorii, niezależnie od ich wartości danych. Wykresy punktowe i bąbelkowe używają osi wartości, a nie tekstowej osi kategorii. Dla osi dat użyj jednostek i skal opartych na czasie, jak opisano w [Change a Category Axis](#change-a-category-axis).

## **Ustaw format daty dla wartości osi kategorii**

Przykład zastępuje domyślne dane wykresu czterema rocznymi wartościami. Daty są przechowywane jako numery seryjne OLE Automation w pierwszym arkuszu (indeks `0`), obliczane jako liczba dni od 30 grudnia 1899 dla tych dat. Oba kalendarze używają UTC i są czyszczone przed ustawieniem dat, aby zmiana czasu letniego i aktualna godzina nie wpływały na obliczenia. Użyj [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) z `CategoryAxisType.Date`, wywołaj [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) z `false` i przekaż `yyyy` do [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) , aby etykiety kategorii wyświetlały czterocyfrowe lata niezależnie od formatowania komórek.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw kąt obrotu tytułu osi wykresu**

Wywołaj [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) z `true` na osi pionowej, podaj tekst tytułu i użyj [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) , aby obrócić tytuł. Kąt jest mierzony w stopniach; ten przykład zapisuje wykres kolumnowy z tytułem osi wartości obróconym o 90 stopni.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw pozycję osi na osi kategorii lub wartości**

Użyj [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) , aby kontrolować, czy oś wartości przecina oś kategorii pomiędzy kategoriami czy na znacznikach podziałek kategorii. To ustawienie dotyczy osi kategorii. Przykład ustawia ją na `true` na poziomej osi kategorii wykresu kolumnowego i zapisuje wynik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw jednostkę wyświetlania na osi wartości wykresu**

Użyj [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) , aby skalować etykiety na osi wartości bez zmiany podstawowych danych. Przy ustawieniu [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) na `Millions`, wartość 60 000 000 jest wyświetlana jako 60. Przykład tworzy wykres kolumnowy i stosuje jednostkę wyświetlania miliony do jego osi pionowej.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Skonfiguruj logarytmiczną oś wartości**

Logarytmiczna oś wartości jest przydatna, gdy dodatnie wartości rozciągają się na kilka rzędów wielkości. Na przykład usługa może otrzymać 10, 100, 1 000, 10 000 i 100 000 żądań w ciągu pięciu okresów. Na skali liniowej mniejsze wartości wyglądają blisko siebie w pobliżu zera. Skala logarytmiczna ułatwia porównanie ich względnego wzrostu: równe odległości reprezentują równe stosunki, a nie równe różnice.

Wywołaj [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) z `true` na osi wartości i użyj [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) , aby wybrać podstawę. Zmienia to sposób wyświetlania istniejących wartości; nie zmienia danych ani nie dodaje logarytmicznej linii trendu. Linia trendu reprezentuje dopasowaną zależność w danych i jest oddzielną funkcją.

### **Wybierz oś wartości i podstawę**

Dla wykresu liniowego lub kolumnowego oś wartości jest zwracana przez [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). Dla poziomego wykresu słupkowego jest zwracana przez [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). Wykresy punktowe i bąbelkowe mają dwie osie wartości, więc wybierz oś poziomą dla wartości X, oś pionową dla wartości Y lub obie. Nie stosuj skalowania logarytmicznego do osi kategorii.

Domyślna podstawa logarytmu to `10`. Dla wykresów PPTX użyj podstawy od `2` do `1000`, włącznie; obsługiwane są także podstawy ułamkowe, takie jak `2.5`. Przy podstawie `10` kolejne potęgi, takie jak 10, 100, 1 000 i 10 000, są równomiernie rozmieszczone.

### **Porównaj skalowanie liniowe i logarytmiczne**

Poniższy samodzielny przykład tworzy wykres liniowy z pięcioma liczbami żądań na pierwszym slajdzie, następnie klonuje ten slajd i włącza logarytmiczną oś wartości o podstawie 10 na drugim. Oba slajdy zachowują te same dane.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Zachowaj pierwszy slajd w skali liniowej i zmień tylko skalę osi wartości w kopii.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Skala liniowa (slajd 1):**  
Równe odległości pionowe reprezentują równe różnice w liczbie żądań. Największa wartość dominuje wykres, utrudniając rozróżnienie mniejszych wartości.

![Wykres liniowy w PowerPoint pokazujący pięć liczby żądań na liniowej osi wartości](value-axis-linear.png)

**Skala logarytmiczna (slajd 2):**  
Równe odległości pionowe reprezentują równe współczynniki. Każdy okres ma dziesięciokrotnie więcej żądań niż poprzedni, więc punkty tworzą prostą rosnącą linię na skali o podstawie 10. Etykiety osi nadal pokazują pierwotne liczby żądań.

![Te same pięć liczby żądań w PowerPoint na logarytmicznej osi wartości o podstawie 10](value-axis-logarithmic.png)

### **Obsługa wartości zerowych i ujemnych**

Skala logarytmiczna może wyświetlać wyłącznie wartości ściśle dodatnie. Sprawdź dane przed jej włączeniem. Jeśli wartości zero lub ujemne mają znaczenie, zachowaj skalę liniową lub pokaż je osobno. Jeśli wykluczenie tych wartości jest uzasadnione w analizie, wyjaśnij pominięcie. Nie zastępuj ich cicho małymi liczbami dodatnimi, ponieważ zmienia to znaczenie danych. Każde ręcznie skonfigurowane minimum lub maksimum dla osi logarytmicznej musi być również dodatnie.

## **FAQ**

**Jak ustawić wartość, w której jedna oś przecina drugą (przecięcie osi)?**

Użyj [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) , aby wybrać zachowanie przecięcia. Aby określić numeryczną wartość przecięcia, użyj [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). Te ustawienia pozwalają przesunąć przecięcie osi do odpowiedniej linii bazowej.

**Jak mogę pozycjonować etykiety podziałek względem osi?**

Wywołaj [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) używając [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) : `Low`, `High`, `NextTo` lub `None`. Aby kontrolować same znaczniki podziałek, użyj [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) lub [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) ; są one oddzielne od pozycjonowania etykiet.