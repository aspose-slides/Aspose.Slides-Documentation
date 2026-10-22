---
title: Zarządzanie seriami danych wykresu w prezentacjach w języku Java
linktitle: Serie danych
type: docs
url: /pl/java/chart-series/
keywords:
- serie wykresu
- nakładanie się serii
- kolor serii
- nazwa serii
- punkt danych
- komórka skoroszytu
- przerwa między seriami
- wartość ujemna
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać seriami wykresu, punktami danych, komórkami skoroszytu, formatowaniem, nakładaniem się, szerokością przerwy i wartościami ujemnymi w prezentacjach przy użyciu języka Java."
---
## **Przegląd**

Wykres może przechowywać swoje wyświetlane wartości w komórkach skoroszytu lub bezpośrednio jako liczby literałowe. An [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) reprezentuje jeden zestaw powiązanych wartości, a każdy [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) reprezentuje punkt w tej serii. [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) objects provide the labels or grouping values shared by the series. W wykresach tworzonych z danymi domyślnymi nazwy serii, kategorie i wartości punktów używają obiektów [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) z skoroszytu wykresu.

Dla typowego wykresu kategorii domyślny skoroszyt używa wiersza 0 dla nazw serii, kolumny 0 dla nazw kategorii oraz pozostałych komórek dla wartości serii. Indeksy arkusza, wiersza i kolumny przekazywane do [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) są zerowo‑indeksowane. Ten układ jest przydatny, gdy tworzysz wykres z danymi domyślnymi, ale nie zakładaj, że każdy istniejący wykres go używa. Dla wczytanego prezentacji sprawdź komórki odwoływane przez serie, kategorie i punkty danych przed zmianą wartości w skoroszycie.

Ustawienia wykresu mają trzy różne zakresy:

- Ustawienia na poziomie serii, takie jak [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), zapewniają domyślny wygląd dla wszystkich punktów w jednej serii.
- Ustawienia punktu danych, takie jak [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), nadpisują wygląd serii dla jednego punktu.
- Ustawienia grupowe mają zastosowanie do zgodnych serii, które należą do tego samego [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/). Dostęp do grupy uzyskuje się poprzez [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) kiedy trzeba ustawić opcje takie jak nakładanie się lub szerokość przerwy.

Gdy nie zostanie określone wypełnienie punktu ani serii, styl i motyw wykresu określają automatyczny wygląd. Gdy zarówno formatowanie serii, jak i punktu jest obecne, formatowanie punktu ma pierwszeństwo dla tego punktu.

![seria wykresu PowerPoint](chart-series-powerpoint.png)

## **Ustaw wartości serii przy użyciu literałów liczbowych**

Używaj literałów liczbowych, gdy wartości serii pochodzą z danych aplikacji lub obliczeń i nie wymagają odwołań do komórek arkusza. Wywołaj [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) z [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) przed przypisaniem wyniku [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) każdego punktu poprzez [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

Ustawienie kolekcji kontroluje typ źródła wszystkich wartości punktów w tej serii. Metoda [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) każdego punktu zgłasza wybrany typ; zmień go poprzez ustawienie kolekcji. Z `Worksheet` użyj [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) aby uzyskać dostęp do odwołanej komórki. Z `DoubleLiterals` użyj [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) lub `setAsLiteralDouble`, aby odczytać lub zapisać liczbę bezpośrednio.

Poniższy przykład tworzy wykres kolumnowy z domyślnymi seriami i kategoriami, a następnie przypisuje obliczone wartości 10, 20 itd. do istniejących punktów pierwszej serii. Zapisuje prezentację, ponownie ją otwiera i wypisuje zapisane wartości.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Typ źródła wartości punktu jest oddzielony od [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--), który identyfikuje wewnętrzną lub zewnętrzną konfigurację skoroszytu wykresu. Użycie literałów liczbowych nie usuwa wbudowanego skoroszytu. W tym przykładzie skoroszyt pozostaje dostępny dla etykiet kategorii, nazw serii i pozostałych serii. Zobacz [Chart Workbook](/slides/pl/java/chart-workbook/) po zarządzanie skoroszytem.

Dla wykresów rozproszonych i bąbelkowych użyj [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) oraz [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-), aby wybrać źródła dla [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) i [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--). Wykresy bąbelkowe dodatkowo używają [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) dla [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Ustaw każdy odpowiedni źródło na `DoubleLiterals` przed przypisaniem liczb poprzez metodę `setAsLiteralDouble` tego wartości.

## **Ustaw nakładanie się serii wykresu**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) zwraca, jak bardzo słupki lub kolumny nakładają się w wykresie 2D, w zakresie od -100 do 100 procent. Jest to odczytowa projekcja ustawienia w grupie serii nadrzędnej. Użyj [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-), aby zaktualizować każdą zgodną serię w tej grupie. Ta opcja ma zastosowanie do typów wykresów wyświetlających grupowane słupki lub kolumny; nie wpływa na niepowiązane grupy serii w wykresie kombinowanym.

Poniższy przykład ustawia nakładanie się dla grupy, która zawiera pierwszą serię:

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

![nakładanie serii](series_overlap.png)

## **Zmień kolor wypełnienia serii**

Użyj [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) aby ustawić domyślne wypełnienie dla całej serii. Jeśli punkt już ma jawne wypełnienie, jego ustawienie [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) nadpisuje wypełnienie serii dla tego punktu.

Poniższy przykład zastosowuje jednolite niebieskie wypełnienie do pierwszej serii:

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

![kolor serii](series_color.png)

## **Zmień nazwę serii**

Nazwa serii jest przechowywana w skoroszycie danych wykresu i zazwyczaj wyświetlana w legendzie. W domyślnym skoroszycie utworzonym dla wykresu skumulowanych kolumn, komórka B1 znajduje się w wierszu 0, kolumnie 1 i zawiera nazwę pierwszej serii. Stałe nazwane w poniższym przykładzie czynią tę strukturę explicite:

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

Można także zaktualizować komórkę już odwoływaną przez [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--). Takie podejście unika zakładania konkretnego wiersza i kolumny w istniejącym wykresie:

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

![nazwa serii](series_name.png)

### **Utwórz serię z nazwą pochodzącą z wielu komórek**

Złożona nazwa serii jest przydatna, gdy nazwa produktu i okres raportowania są przechowywane w osobnych komórkach skoroszytu. Na przykład możesz połączyć `Product A` w B1 i `2026` w C1 w jedną nazwę serii, zachowując oba elementy powiązane ze swoimi komórkami źródłowymi.

Użyj [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-), aby pobrać zakres nazw, a następnie przekaż tę kolekcję do [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Argument `skipHiddenCells` określa, czy ukryte komórki mają być pomijane: `true` je wyklucza, `false` włącza. Ten przykład używa `false`, aby włączyć każdą komórkę w zakresie nazw.

Poniższy przykład tworzy prezentację z jedną serią i dwoma punktami danych. Komórki B1:C1 dostarczają jedynie nazwę serii; A2:A3 dostarczają etykiety kategorii, a B2:B3 dostarczają wartości liczbowe.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Te dwie komórki dostarczają nazwę serii.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Oddzielne komórki dostarczają kategorie oraz numeryczne punkty danych.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynikowa nazwa serii to `Product A 2026`, ze spacją pomiędzy dwoma wartościami komórek. Legenda wyświetla to jako jedną pozycję dla obu kolumn. Poniżej ilustracja wyniku:

![Wykres kolumnowy z wartościami Północ i Południe oraz złożoną nazwą serii Product A 2026 w legendzie](composite_series_name.png)

## **Pobierz automatyczny kolor wypełnienia serii**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) zwraca kolor obliczony na podstawie indeksu serii i stylu wykresu. Jest to kolor używany, gdy wypełnienie serii nie zostało jawnie określone. Wywołanie metody odczytuje obliczony kolor; nie przypisuje nowego wypełnienia.

Poniższy przykład wypisuje automatyczny kolor każdej domyślnej serii:

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

Dla serii słupkowych, kolumnowych i bąbelkowych, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) może wyświetlać wartości ujemne innym wypełnieniem. Ustaw regularne wypełnienie serii na jednolite, włącz odwrócenie i określ kolor dla wartości ujemnych przez [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Liczby ujemne pozostają niezmienione w skoroszycie; zmienia się tylko ich kolor wyświetlania.

Poniższy przykład zastępuje domyślne dane wykresu jedną serią. Wiersz 0 arkusza zawiera nazwę serii, kolumna 0 zawiera nazwy kategorii, a kolumna 1 zawiera wartości:

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

![odwrócony jednolity kolor wypełnienia](inverted_solid_fill_color.png)

Możesz włączyć odwrócenie dla jednego punktu przez [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). W poniższym przykładzie odwrócenie jest wyłączone dla serii i włączone tylko dla wybranego punktu. Punktowi przypisano także wartość ujemną, aby efekt był widoczny:

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

## **Wyczyść konkretną wartość punktu danych**

Aby uczynić jeden punkt pustym bez usuwania pozostałych, ustaw jego komórkę w skoroszycie na `null`. Dla wykresu kolumnowego wyświetlana wartość jest dostępna przez [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--). Punkt danych pozostaje w tym samym miejscu kategorii, ale wykres traktuje jego wartość jako pustą zgodnie z ustawieniami pustych wartości wykresu.

Poniższy przykład wymazuje tylko drugi punkt w pierwszej serii:

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

Wykresy rozproszone używają oddzielnych komórek X i Y, a wykresy bąbelkowe także komórki rozmiaru. Wymaż tylko komórkę, która reprezentuje wartość, którą zamierzasz usunąć. Nie wywołuj [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) gdy chcesz zachować pozostałe punkty, ponieważ metoda usuwa wszystkie punkty danych z kolekcji.

## **Kontroluj wyświetlanie pustych komórek**

Ukryte komórki zawierające wartości to odrębny przypadek od pustych komórek. Aby włączyć lub wyłączyć dane z ukrytych wierszy i kolumn arkusza, zobacz [Include Data from Hidden Rows and Columns](/slides/pl/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Pusta komórka skoroszytu reprezentuje brakujące dane; komórka zawierająca `0` reprezentuje znaną wartość liczbową. Wywołaj [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) z `null`, aby uczynić komórkę pustą. Liczba zero pozostaje zerem bez względu na ustawienie pustej komórki.

Użyj [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) aby wybrać, jak wykres wyświetla puste komórki. To ustawienie ma zastosowanie do całego wykresu. Zmienia sposób rysowania pustek, nie wypełniając pustej komórki zerem ani interpolowaną wartością.

Poniższy samodzielny przykład tworzy wykres liniowy z jedną serią, wymazuje wartość dla Dnia 3 i zapisuje ten sam wykres w każdym trybie. Nie wymaga pliku wejściowego. [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) używa arkusza 0, kolumny 0 dla etykiet kategorii oraz kolumny 1 dla wartości; wiersz 0 zawiera nazwę serii. Końcowe dane to `10, 20, empty, 30, 40`.

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

    // Pozostaw Dzień 3 naprawdę pusty, zachowując jego kategorię i punkt danych.
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

Każdy plik wyjściowy przechowuje tryb przypisany przed zapisem: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` i `empty_cells_Span.pptx`. Aby zapisać tylko jedną wersję, ustaw żądany tryb i zapisz prezentację raz zamiast iterować po trybach.

Poniższe porównanie pokazuje te same dane w trzech plikach. Dzień 3 jest pusty w skoroszycie w każdym przypadku:

![Wykresy liniowe z identycznymi danymi: Gap przerywa linię w Dniu 3, Zero obniża linię do zera, a Span łączy Dzień 2 z Dniem 4.](display_blanks_as.png)

Widoczny efekt zależy od typu wykresu. Wykres liniowy ułatwia porównanie wszystkich trzech trybów. Wykresy słupkowe i kolumnowe nie mają linii do połączenia przez brakującą kategorię, więc `Span` nie może wygenerować pokazanego odcinka; brakująca kolumna i kolumna o wysokości zero mogą wyglądać podobnie. Podobnie wykres rozproszony z samymi znacznikami nie ma linii łączącej. Nie oczekuj trzech odrębnych wyników dla każdego typu wykresu; sprawdź wynik dla używanego typu.

## **Ustaw szerokość przerwy serii**

Szerokość przerwy to odstęp między sąsiadującymi grupami słupków lub kolumn, wyrażony jako procent szerokości słupka lub kolumny. Podobnie jak nakładanie się, należy do grupy serii nadrzędnej, a nie do jednej serii. Wywołaj [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) raz dla grupy. Większa wartość tworzy więcej przestrzeni między grupami; mniejsza wartość zagęszcza je.

Poniższy przykład zmienia szerokość przerwy i zapisuje tylko ostateczną prezentację:

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

![szerokość przerwy](gap_width.png)

## **FAQ**

**Które typy wykresów obsługują serie danych?**

Wszystkie typy wykresów reprezentowane przez wyliczenie [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) używają danych wykresu, ale ich serie nie mają takiej samej struktury wartości ani ustawień. Na przykład wykresy kategorii używają kategorii i wartości, wykresy rozproszone X i Y, a wykresy bąbelkowe dodają rozmiary bąbelków. Użyj metody tworzenia punktu danych, która odpowiada typowi serii. Opcje takie jak nakładanie się i szerokość przerwy mają zastosowanie tylko do zgodnych grup słupków lub kolumn.

**Czym jest grupa serii wykresu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) zawiera zgodne serie, które współdzielą ustawienia grupowe wykreślania. Wykres kombinowany może zawierać więcej niż jedną grupę, więc zmiana grupy osiągnięta przez jedną serię niekoniecznie zmieni wszystkie serie w wykresie.

**Czy nowo utworzony wykres zawiera dane domyślne?**

Tak. Domyślnie [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) tworzy przykładowe serie, kategorie i wartości. Możesz edytować te komórki lub wyczyścić zarówno serie, jak i kolekcje kategorii przed dodaniem w pełni własnego zestawu danych. Przeciążenie może także utworzyć wykres bez danych domyślnych.

**Jak obiekty wykresu są połączone z komórkami skoroszytu?**

Nazwy serii, etykiety kategorii i wartości punktów danych odwołują się do komórek w [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). Zmiana odwołanej komórki aktualizuje odpowiadający element wykresu. Budując własne dane, utrzymuj wiersze kategorii i wiersze wartości serii wyrównane, aby każdy punkt był wykreślony pod właściwą kategorią.

**Jak wyczyścić jeden punkt zamiast całej serii?**

Ustaw odpowiednią komórkę wartości na `null`, aby zachować pozycję kategorii punktu jako pusty punkt. Używaj [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) tylko wtedy, gdy zamierzasz usunąć wszystkie punkty z tej serii. Jeśli usuwasz także kategorie, zaktualizuj wszystkie serie, aby ich wartości pozostały wyrównane z kolekcją kategorii.

**Jak wyświetlane są puste punkty?**

Wynik zależy od typu wykresu i wartości skonfigurowanej przez [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Obsługiwane wykresy mogą wyświetlać puste miejsca jako przerwy, jako wartości zero lub poprzez łączenie sąsiednich punktów. Wybierz ustawienie odpowiadające znaczeniu brakujących danych w Twojej prezentacji. Zobacz [Control the Display of Empty Cells](#control-the-display-of-empty-cells) po kompletny przykład i porównanie wizualne.

**Jak formatowane są wartości ujemne?**

Dla obsługiwanych serii słupkowych, kolumnowych i bąbelkowych, wywołaj [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) i ustaw kolor zwracany przez [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Możesz nadpisać zachowanie dla pojedynczego punktu za pomocą [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Te metody wpływają na formatowanie, a nie na przechowywane wartości liczbowe.

**Które formatowanie wygrywa, gdy zarówno seria, jak i punkt są sformatowane?**

Jawne formatowanie punktu danych ma pierwszeństwo dla tego punktu. Inne punkty nadal używają jawnego formatu serii lub, gdy format serii nie jest określony, automatycznego stylu i motywu wykresu. Ustawienia grupowe, takie jak nakładanie się i szerokość przerwy, kontrolują układ i nie są nadpisaniami formatowania na poziomie punktu.

**Czy istnieje limit liczby serii, które wykres może zawierać?**

Aspose.Slides nie nakłada oddzielnego stałego limitu liczby serii. W praktyce ograniczenia pliku prezentacji, dostępna pamięć, czas renderowania i czytelność wykresu określają praktyczny limit.

**Co zmienić, gdy kolumny są zbyt blisko siebie lub zbyt daleko od siebie?**

Wywołaj [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) na odpowiedniej grupie serii nadrzędnej. Zwiększ wartość, aby poszerzyć odstęp między grupami, lub zmniejsz ją, aby przybliżyć grupy.