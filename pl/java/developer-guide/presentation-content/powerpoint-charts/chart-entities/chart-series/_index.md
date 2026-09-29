---
title: Zarządzanie seriami danych wykresu w prezentacjach w Javie
linktitle: Serie danych
type: docs
url: /pl/java/chart-series/
keywords:
- seria wykresu
- nakładanie się serii
- kolor serii
- nazwa serii
- punkt danych
- komórka skoroszytu
- przerwa serii
- wartość ujemna
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem się, szerokością przerwy i wartościami ujemnymi w prezentacjach przy użyciu Javy."
---
## **Przegląd**

Wykres przechowuje swoje wykreślone dane w skoroszycie danych wykresu. Interfejs [IChartSeries](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [IChartDataPoint](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapoint/) w serii odnosi się do jednej lub wielu komórek skoroszytu. Obiekty [IChartCategory](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartcategory/) dostarczają etykiety lub wartości grupowania wspólne dla serii. Dlatego nazwa serii, kategorie i wartości punktów są powiązane z obiektami [IChartDataCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/), a nie przechowywane jedynie jako tekst wyświetlany.

Dla typowego wykresu kategorii domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) są zerowe. Ten układ jest przydatny przy tworzeniu wykresu z danymi domyślnymi, ale nie należy zakładać, że każdy istniejący wykres go używa. W przypadku załadowanej prezentacji należy sprawdzić komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [IChartSeries.getFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#getFormat--), zapewniają domyślny wygląd wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [IChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapoint/#getFormat--), nadpisują wygląd serii dla pojedynczego punktu.
- Ustawienia grupy dotyczą kompatybilnych serii należących do tej samej [IChartSeriesGroup](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseriesgroup/). Dostęp do grupy uzyskuje się przez [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) gdy trzeba ustawić opcje takie jak nakładanie się (overlap) lub szerokość przerwy (gap width).

Gdy nie określono wyraźnego wypełnienia punktu lub serii, styl i motyw wykresu określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![serie wykresu PowerPoint](chart-series-powerpoint.png)

## **Ustaw nakładanie się serii wykresu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#getOverlap--) zwraca, jak bardzo słupki lub kolumny nakładają się w wykresie 2D, w zakresie od -100 do 100 procent. Jest to projekcja ustawienia w grupie serii nadrzędnej, dostępna tylko do odczytu. Użyj [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) , aby zaktualizować wszystkie kompatybilne serie w tej grupie. Opcja ta ma zastosowanie do typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

The following example sets the overlap for the group that contains the first series:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Nowy wykres zawiera przykładowe serie, kategorie i wartości.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Nakładanie się serii](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Użyj [IChartSeries.getFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#getFormat--) , aby ustawić domyślne wypełnienie całej serii. Jeśli punkt już ma wyraźne wypełnienie, jego ustawienie [IChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapoint/#getFormat--) nadpisuje wypełnienie serii dla tego punktu.

The following example applies a solid blue fill to the first series:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Kolor serii](series_color.png)

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zazwyczaj wyświetlana jest w legendzie. W domyślnym skoroszycie utworzonym dla wykresu kolumnowego grupowanego komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Nazwane stałe w poniższym przykładzie wyraźnie określają tę strukturę:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Możesz również zaktualizować komórkę już odwoływaną przez [IChartSeries.getName](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#getName--) . To podejście unika zakładania określonego wiersza i kolumny w istniejącym wykresie:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Nazwa serii](series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) zwraca kolor wyliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało wyraźnie określone. Wywołanie metody odczytuje wyliczony kolor; nie przypisuje nowego wypełnienia.

The following example prints the automatic color of each default series:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
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

Dla serii słupkowych, kolumnowych i bąbelkowych [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na stałe, włącz odwracanie i przypisz kolor wartości ujemnych poprzez [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) . Ujemne liczby pozostają niezmienione w skoroszycie; zmienia się tylko ich kolor wyświetlania.

The following example replaces the default chart data with one series. Worksheet row 0 contains the series name, column 0 contains category names, and column 1 contains the values:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Odwrócony stały kolor wypełnienia](inverted_solid_fill_color.png)

You can enable inversion for one point through [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). In the following example, inversion is disabled for the series and enabled only for the selected point. The point is also assigned a negative value so that the effect is visible:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wyczyść konkretne wartości punktu danych**

Aby uczynić jeden punkt pustym bez usuwania pozostałych punktów, ustaw jego komórkę w skoroszycie na `null`. Dla wykresu kolumnowego wyświetlana wartość jest dostępna przez [IChartDataPoint.getValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapoint/#getValue--) . Punkt danych pozostaje na tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

The following example clears only the second point in the first series:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wykresy punktowe używają osobnych komórek X i Y, a wykresy bąbelkowe dodatkowo używają komórki rozmiaru. Wyczyść tylko komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj [IChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatapointcollection/#clear--) gdy chcesz zachować pozostałe punkty, ponieważ ta metoda usuwa każdy punkt danych z kolekcji.

## **Sterowanie wyświetlaniem pustych komórek**

Ukryte komórki zawierające wartości to odrębny przypadek od pustych komórek. Aby włączyć lub wykluczyć dane z ukrytych wierszy i kolumn arkusza, zobacz [Include Data from Hidden Rows and Columns](/slides/pl/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Pusta komórka skoroszytu reprezentuje brakujące dane; komórka zawierająca `0` reprezentuje znaną wartość numeryczną. Wywołaj [IChartDataCell.setValue](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) z `null`, aby uczynić komórkę pustą. Zero numeryczne pozostaje zerem niezależnie od ustawienia pustej komórki.

Użyj [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) , aby wybrać, jak wykres wyświetla puste komórki. To ustawienie dotyczy całego wykresu. Zmienia sposób rysowania pustych wartości, nie wypełniając pustej komórki skoroszytu zerem ani wartością interpolowaną.

Poniższy samodzielny przykład tworzy wykres liniowy z jedną serią, czyści wartość dla Dnia 3 i zapisuje ten sam wykres w każdym trybie. Żaden plik wejściowy nie jest wymagany. [IChartDataWorkbook](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartdataworkbook/) używa arkusza 0, kolumny 0 dla etykiet kategorii i kolumny 1 dla wartości; wiersz 0 zawiera nazwę serii. Ostateczne dane to `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Pozostaw Dzień 3 rzeczywiście pusty, zachowując jego kategorię i punkt danych.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Każdy plik wyjściowy przechowuje tryb przypisany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, przypisz pożądany tryb i zapisz prezentację raz, zamiast iterować po trybach.

Poniższe porównanie pokazuje te same dane we wszystkich trzech plikach. Dzień 3 jest pusty w skoroszycie w każdym przypadku:

![Wykresy liniowe z identycznymi danymi: Gap przerywa linię w Dniu 3, Zero obniża linię do zera, a Span łączy Dzień 2 z Dniem 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy ułatwia porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii do połączenia brakującej kategorii, więc `Span` nie może wygenerować segmentu łączenia pokazanego powyżej; brakująca kolumna i kolumna o wysokości zero mogą wyglądać podobnie. Podobnie wykres punktowy z samymi znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wynik dla używanego typu.

## **Ustaw szerokość przerwy serii**

Szerokość przerwy to odstęp między sąsiadującymi grupami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie się, należy ona do grupy serii nadrzędnej, a nie do jednej serii. Wywołaj [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) raz dla grupy. Większa wartość zwiększa odstęp między grupami; mniejsza wartość powoduje ich zagęszczenie.

The following example changes the gap width and saves only the final presentation:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Szerokość przerwy](gap_width.png)

## **FAQ**

**Jakie typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType] używają danych wykresu, ale ich serie nie mają wszystkich takiej samej struktury wartości ani ustawień. Na przykład wykresy kategorii używają kategorii i wartości, wykresy punktowe używają wartości X i Y, a wykresy bąbelkowe dodają rozmiary bąbelków. Użyj metody tworzenia punktów danych odpowiadającej typowi serii. Opcje takie jak nakładanie się i szerokość przerwy mają zastosowanie tylko do kompatybilnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[IChartSeriesGroup] zawiera kompatybilne serie, które współdzielą ustawienia wykresu na poziomie grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera domyślne dane?**

Tak. Domyślnie [IShapeCollection.addChart] tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub usunąć zarówno kolekcje serii, jak i kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może również utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są powiązane z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [IChartDataWorkbook]. Zmiana odwoływanej komórki aktualizuje odpowiedni element wykresu. Tworząc własne dane, utrzymuj wyrównane wiersze kategorii i wiersze wartości serii, aby każdy punkt został wykreślony pod zamierzoną kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `null`, aby zachować pozycję kategorii punktu jako pusty punkt. Użyj [IChartDataPointCollection.clear] tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli także usuwasz kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i wartości skonfigurowanej przez [IChart.setDisplayBlanksAs]. Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zero lub poprzez połączenie sąsiednich punktów. Wybierz ustawienie pasujące do znaczenia brakujących danych w prezentacji. Zobacz [Control the Display of Empty Cells](#control-the-display-of-empty-cells) po pełny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [IChartSeries.setInvertIfNegative] i ustaw kolor zwracany przez [IChartSeries.getInvertedSolidFillColor]. Możesz nadpisać zachowanie dla pojedynczego punktu za pomocą [IChartDataPoint.setInvertIfNegative]. Te metody wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie ma pierwszeństwo, gdy zarówno seria, jak i punkt są sformatowane?**

Wyraźne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają wyraźnego formatu serii lub, gdy format serii nie jest zdefiniowany, automatycznego stylu i motywu wykresu. Ustawienia grupy, takie jak nakładanie się i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania na poziomie punktu.

**Czy istnieje limit liczby serii, które może zawierać wykres?**

Aspose.Slides nie narzuca osobnego stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu określają użyteczny limit.

**Co zmienić, gdy kolumny są zbyt blisko siebie lub zbyt daleko od siebie?**

Wywołaj [IChartSeriesGroup.setGapWidth] na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby poszerzyć odstęp między grupami, lub zmniejsz ją, aby przybliżyć grupy do siebie.