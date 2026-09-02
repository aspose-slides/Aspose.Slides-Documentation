---
title: Zarządzanie seriami danych wykresu w prezentacjach na Androidzie
linktitle: Serie danych
type: docs
url: /pl/androidjava/chart-series/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem, szerokością przerwy i wartościami ujemnymi w prezentacjach na Androidzie."
---
## **Przegląd**

Wykres przechowuje swoje wyświetlane dane w skoroszycie danych wykresu. [IChartSeries](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [IChartDataPoint](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/) w serii odnosi się do jednej lub wielu komórek skoroszytu. Obiekty [IChartCategory](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartcategory/) dostarczają etykiet lub wartości grupowania współdzielonych przez serie. Nazwa serii, kategorie i wartości punktów są więc połączone z obiektami [IChartDataCell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatacell/) zamiast być przechowywane wyłącznie jako tekst wyświetlany.

Dla typowego wykresu kategorii domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) są zerowe. Ten układ jest przydatny, gdy tworzysz wykres z domyślnymi danymi, ale nie zakładaj, że każdy istniejący wykres używa go. Dla wczytanej prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [IChartSeries.getFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getFormat--), zapewniają domyślny wygląd wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [IChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupy mają zastosowanie do kompatybilnych serii, które należą do tego samego [IChartSeriesGroup](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/). Uzyskaj dostęp do grupy przez [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) gdy musisz ustawić opcje takie jak nakładanie lub szerokość przerwy.

Gdy nie jest ustawione wyraźne wypełnienie punktu lub serii, styl i motyw wykresu określają automatyczny wygląd. Gdy istnieje zarówno formatowanie serii, jak i punktu, formatowanie punktu ma pierwszeństwo dla tego punktu.

![seria-wykresu-powerpoint](chart-series-powerpoint.png)

## **Ustaw Nakładanie Serii Wykresu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getOverlap--) podaje, o ile słupki lub kolumny nakładają się w wykresie 2D, od ‑100 do 100 procent. Jest to tylko do odczytu projekcja ustawienia w grupie serii nadrzędnej. Użyj [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-), aby zaktualizować wszystkie kompatybilne serie w tej grupie. Opcja ta ma zastosowanie do typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia nakładanie dla grupy, która zawiera pierwszą serię:

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

![nakładanie-serii](series_overlap.png)

## **Zmień Kolor Wypełnienia Serii**

Użyj [IChartSeries.getFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getFormat--) aby ustawić domyślne wypełnienie całej serii. Jeśli punkt już ma wyraźne wypełnienie, jego ustawienie [IChartDataPoint.getFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) nadpisuje wypełnienie serii dla tego punktu.

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

![kolor-serii](series_color.png)

## **Zmień Nazwę Serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zwykle wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla wykresu skumulowanych kolumn komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Stałe nazwane w poniższym przykładzie wyraźnie określają tę strukturę:

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

Możesz także zaktualizować komórkę już odwoływaną przez [IChartSeries.getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getName--). To podejście unika zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

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

![nazwa-serii](series_name.png)

## **Pobierz Automatyczny Kolor Wypełnienia Serii**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu jako liczbową wartość ARGB Androida. Jest to kolor używany, gdy wypełnienie serii nie zostało wyraźnie określone. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

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

Dokładne wartości liczbowe zależą od stylu i motywu wykresu.

## **Ustaw Odwrócony Kolor Wypełnienia dla Serii Wykresu**

Dla serii słupkowych, kolumnowych i bąbelkowych [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw standardowe wypełnienie serii na jednolite, włącz odwracanie i przypisz kolor wartości ujemnej przez [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Ujemne liczby pozostają niezmienione w skoroszycie; zmienia się tylko ich kolor wyświetlania.

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

![odwrócony-jednolity-kolor-wypełnienia](inverted_solid_fill_color.png)

Możesz włączyć odwracanie dla jednego punktu przez [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). W poniższym przykładzie odwracanie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punktowi przypisywana jest także wartość ujemna, aby efekt był widoczny:

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

## **Wyczyść Konkretnej Wartość Punktu Danych**

Aby uczynić jeden punkt pustym bez usuwania pozostałych, ustaw jego komórkę w skoroszycie na `null`. Dla wykresu kolumnowego wyświetlana wartość jest dostępna przez [IChartDataPoint.getValue](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#getValue--). Punkt danych pozostaje na tej samej pozycji kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

Poniższy przykład czyści tylko drugi punkt w pierwszej serii:

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

Wykresy rozrzutu używają oddzielnych komórek X i Y, a wykresy bąbelkowe dodatkowo używają komórki rozmiaru. Czyść tylko komórkę, która reprezentuje wartość, którą chcesz usunąć. Nie wywołuj [IChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) gdy chcesz zachować pozostałe punkty, ponieważ ta metoda usuwa wszystkie punkty danych z kolekcji.

## **Ustaw Szerokość Przerwy Serii**

Szerokość przerwy to odstęp pomiędzy sąsiadującymi klastrami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie, należy ona do grupy serii nadrzędnej, a nie do jednej serii. Wywołaj [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) raz dla grupy. Większa wartość tworzy więcej przestrzeni między klastrami; mniejsza wartość powoduje, że są one gęstsze.

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

![szerokość-przerwy](gap_width.png)

## **FAQ**

**Jakie typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/charttype/) używają danych wykresu, ale ich serie nie zawsze mają tę samą strukturę wartości ani ustawienia. Na przykład wykresy kategorii używają kategorii i wartości, wykresy rozrzutu używają wartości X i Y, a wykresy bąbelkowe dodają rozmiary bąbelków. Użyj metody tworzenia punktu danych, która odpowiada typowi serii. Opcje takie jak nakładanie i szerokość przerwy mają zastosowanie tylko do kompatybilnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/) zawiera kompatybilne serie, które współdzielą ustawienia rysowania na poziomie grupy. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy uzyskanej przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera domyślne dane?**

Tak. Domyślnie [IShapeCollection.addChart](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno kolekcje serii, jak i kategorii przed dodaniem całkowicie własnego zestawu danych. Przeciążenie może również utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są powiązane z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [IChartDataWorkbook](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdataworkbook/). Zmiana odwoływanej komórki aktualizuje odpowiedni element wykresu. Tworząc własne dane, utrzymuj wiersze kategorii i wiersze wartości serii wyrównane, aby każdy punkt był rysowany pod zamierzoną kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `null`, aby zachować pozycję kategorii punktu jako pusty punkt. Użyj [IChartDataPointCollection.clear](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli usuwasz także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i wartości skonfigurowanej przez [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zerowe lub łącząc sąsiednie punkty. Wybierz ustawienie, które odpowiada znaczeniu brakujących danych w twojej prezentacji.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych wywołaj [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) i ustaw kolor zwracany przez [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Możesz nadpisać zachowanie dla pojedynczego punktu za pomocą [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Metody te wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie wygrywa, gdy zarówno seria, jak i punkt są sformatowane?**

Wyraźne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają wyraźnego formatu serii lub, gdy format serii nie jest określony, automatycznego stylu i motywu wykresu. Ustawienia grup, takie jak nakładanie i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania na poziomie punktu.

**Czy istnieje limit liczby serii, które wykres może zawierać?**

Aspose.Slides nie narzuca oddzielnego stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu określają praktyczny limit.

**Co zmienić, gdy kolumny są zbyt blisko siebie lub zbyt od siebie oddalone?**

Wywołaj [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby poszerzyć przestrzeń między klastrami, lub zmniejsz ją, aby przybliżyć klastry do siebie.