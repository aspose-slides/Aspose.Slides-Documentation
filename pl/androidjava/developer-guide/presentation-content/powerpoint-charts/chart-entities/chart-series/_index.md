---
title: Zarządzanie seriami danych wykresu w prezentacjach na Androidzie
linktitle: Serie danych
type: docs
url: /pl/androidjava/chart-series/
keywords:
- seria wykresu
- zachodzenie serii
- kolor serii
- nazwa serii
- punkt danych
- komórka skoroszytu
- przerwa serii
- wartość ujemna
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, zachodzeniem, szerokością przerwy i wartościami ujemnymi w prezentacjach na Androidzie."
---
## **Przegląd**

Wykres przechowuje wyświetlane dane w skoroszycie danych wykresu. Obiekt [IChartSeries](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [IChartDataPoint](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/) w serii odnosi się do jednej lub kilku komórek skoroszytu. Obiekty [IChartCategory](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartcategory/) dostarczają etykiety lub wartości grupujące współdzielone przez serie. Nazwa serii, kategorie i wartości punktów są więc powiązane z obiektami [IChartDataCell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatacell/) zamiast przechowywane wyłącznie jako tekst wyświetlany.

Dla typowego wykresu kategorii domyślny skoroszyt używa wiersza 0 do nazw serii, kolumny 0 do nazw kategorii oraz pozostałych komórek do wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) są zerowo‑indeksowane. Ten układ jest przydatny przy tworzeniu wykresu z domyślnymi danymi, ale nie należy zakładać, że każdy istniejący wykres go używa. W przypadku wczytanej prezentacji należy sprawdzić komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [IChartSeries.getFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getFormat--), określają domyślny wygląd wszystkich punktów jednej serii.
- Ustawienia punktu danych, takie jak [IChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupowe mają zastosowanie do kompatybilnych serii, które należą do tej samej [IChartSeriesGroup](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/). Uzyskaj dostęp do grupy przez [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) , gdy musisz ustawić opcje takie jak zachodzenie lub szerokość przerwy.

Gdy nie jest ustawione żadne wyraźne wypełnienie punktu lub serii, styl i motyw wykresu określają automatyczny wygląd. Gdy obecne są zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ustaw zachodzenie serii wykresu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getOverlap--) informuje, jak bardzo słupki lub kolumny zachodzą na siebie w wykresie 2D, w zakresie od -100 do 100 procent. Jest to tylko do odczytu projekcja ustawienia na grupie nadrzędnej serii. Użyj [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) , aby zaktualizować wszystkie kompatybilne serie w tej grupie. Ta opcja ma zastosowanie do typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia zachodzenie dla grupy zawierającej pierwszą serię:

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

![The series overlap](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Użyj [IChartSeries.getFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getFormat--) , aby ustawić domyślne wypełnienie dla całej serii. Jeśli punkt już ma wyraźne wypełnienie, jego ustawienie [IChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) nadpisuje wypełnienie serii dla tego punktu.

Poniższy przykład stosuje jednolite niebieskie wypełnienie do pierwszej serii:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![The color of the series](series_color.png)

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zwykle wyświetlana jest w legendzie. W domyślnym skoroszycie utworzonym dla wykresu słupkowego grupowanego, komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Nazwane stałe w poniższym przykładzie wyraźnie określają tę strukturę:

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

Możesz także zaktualizować komórkę już odwoływaną przez [IChartSeries.getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getName--) . To podejście unika zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

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

![The series name](series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu jako całkowitą wartość koloru Android ARGB. Jest to kolor używany, gdy wypełnienie serii nie zostało wyraźnie określone. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

Poniższy przykład wypisuje automatyczną liczbę całkowitą koloru dla każdej domyślnej serii:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Dokładne wartości całkowite zależą od stylu wykresu i motywu.

## **Ustaw odwrócony kolor wypełnienia dla serii wykresu**

Dla serii słupkowych, kolumnowych i bąbelkowych, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii jako jednolite, włącz odwracanie i przypisz kolor wartości ujemnych za pomocą [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) . Ujemne liczby pozostają niezmienione w skoroszycie; zmienia się tylko ich kolor wyświetlania.

Poniższy przykład zastępuje domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 zawiera nazwy kategorii, a kolumna 1 zawiera wartości:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

![The inverted solid fill color](inverted_solid_fill_color.png)

Możesz włączyć odwracanie dla jednego punktu za pomocą [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). W poniższym przykładzie odwracanie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punktowi przypisana jest również wartość ujemna, aby efekt był widoczny:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
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

## **Wyczyść określoną wartość punktu danych**

Aby uczynić jeden punkt pustym bez usuwania innych punktów, ustaw jego powiązaną komórkę skoroszytu na `null`. W przypadku wykresu kolumnowego wyświetlana wartość jest dostępna przez [IChartDataPoint.getValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) . Punkt danych pozostaje w tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

Poniższy przykład usuwa tylko drugi punkt w pierwszej serii:

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

Wykresy rozrzutu używają oddzielnych komórek X i Y, a wykresy bąbelkowe także używają komórki rozmiaru. Wyczyść tylko komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj [IChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) , gdy chcesz zachować pozostałe punkty, ponieważ ta metoda usuwa każdy punkt danych z kolekcji.

## **Kontroluj wyświetlanie pustych komórek**

Pusta komórka skoroszytu oznacza brakujące dane; komórka zawierająca `0` oznacza znaną wartość numeryczną. Wywołaj [IChartDataCell.setValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) z wartością `null`, aby uczynić komórkę pustą. Zero numeryczne pozostaje zerem niezależnie od ustawienia pustej komórki.

Użyj [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) , aby wybrać, jak wykres wyświetla puste komórki. To ustawienie ma zastosowanie do całego wykresu. Zmienia sposób rysowania pustych miejsc, nie wypełniając pustej komórki skoroszytu zerem ani wartością interpolowaną.

Poniższy samodzielny przykład tworzy wykres liniowy z jedną serią, usuwa wartość dla Dnia 3 i zapisuje ten sam wykres w każdym trybie. Nie jest wymagany żaden plik wejściowy. [IChartDataWorkbook](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdataworkbook/) używa arkusza 0, kolumny 0 dla etykiet kategorii i kolumny 1 dla wartości; wiersz 0 zawiera nazwę serii. Końcowe dane to `10, 20, empty, 30, 40`.

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

    // Pozostaw dzień 3 naprawdę pusty, jednocześnie zachowując jego kategorię i punkt danych.
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

Każdy plik wyjściowy przechowuje tryb przypisany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, przypisz żądany tryb i zapisz prezentację raz zamiast iterować po trybach.

Poniższe porównanie pokazuje te same dane we wszystkich trzech plikach. Dzień 3 jest pusty w skoroszycie w każdym przypadku:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy ułatwia porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii łączącej brakującą kategorię, więc `Span` nie może wygenerować pokazanego powyżej odcinka łączącego; brakujący słupek i słupek o zerowej wysokości mogą wyglądać podobnie. Podobnie, wykres rozrzutu z samymi znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wynik dla używanego typu.

## **Ustaw szerokość przerwy serii**

Szerokość przerwy to odstęp między sąsiadującymi grupami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak zachodzenie, należy do grupy nadrzędnej serii, a nie do jednej serii. Wywołaj [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) raz dla grupy. Większa wartość tworzy więcej odstępu między grupami; mniejsza wartość sprawia, że są gęstsze.

Poniższy przykład zmienia szerokość przerwy i zapisuje tylko końcową prezentację:

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

![The gap width](gap_width.png)

## **FAQ**

**Jakie typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/charttype/) używają danych wykresu, ale ich serie nie mają wszystkich takiej samej struktury wartości ani ustawień. Na przykład wykresy kategorialne używają kategorii i wartości, wykresy rozrzutu używają wartości X i Y, a wykresy bąbelkowe dodatkowo rozmiarów bąbelków. Użyj metody tworzenia punktu danych odpowiadającej typowi serii. Opcje takie jak zachodzenie i szerokość przerwy mają zastosowanie tylko do kompatybilnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/) zawiera kompatybilne serie, które współdzielą ustawienia wykresu poziomu grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera domyślne dane?**

Tak. Domyślnie, [IShapeCollection.addChart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno kolekcje serii, jak i kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może również utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są powiązane z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [IChartDataWorkbook](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdataworkbook/). Zmiana odwoływanej komórki aktualizuje odpowiadający element wykresu. Tworząc własne dane, utrzymuj wyrównane wiersze kategorii i wiersze wartości serii, aby każdy punkt był wykreślony pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `null`, aby zachować pozycję kategorii punktu jako pusty punkt. Używaj [IChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli również usuwasz kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane do kolekcji kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i wartości skonfigurowanej przez [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zero lub przez połączenie sąsiadujących punktów. Wybierz ustawienie pasujące do znaczenia brakujących danych w Twojej prezentacji. Zobacz sekcję Kontroluj wyświetlanie pustych komórek, aby zobaczyć pełny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) i ustaw kolor zwracany przez [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Możesz nadpisać zachowanie dla pojedynczego punktu za pomocą [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Metody te wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie wygrywa, gdy zarówno seria, jak i punkt są sformatowane?**

Wyraźne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają wyraźnego formatu serii lub, gdy format serii nie jest zdefiniowany, automatycznego stylu i motywu wykresu. Ustawienia grupowe, takie jak zachodzenie i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania na poziomie punktu.

**Czy istnieje limit liczby serii, które może zawierać wykres?**

Aspose.Slides nie narzuca oddzielnego stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu określają użyteczny limit.

**Co powinienem zmienić, gdy kolumny są zbyt blisko siebie lub zbyt daleko od siebie?**

Wywołaj [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) na odpowiedniej grupie nadrzędnej serii. Zwiększ wartość, aby poszerzyć odstęp między grupami, lub zmniejsz ją, aby przybliżyć grupy do siebie.