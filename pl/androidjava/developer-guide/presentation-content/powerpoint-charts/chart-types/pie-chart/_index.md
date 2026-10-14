---
title: Dostosuj wykresy kołowe w prezentacjach na Androidzie
linktitle: Wykres kołowy
type: docs
url: /pl/androidjava/pie-chart/
keywords:
- wykres kołowy
- zarządzaj wykresem
- dostosuj wykres
- opcje wykresu
- ustawienia wykresu
- opcje wykresu
- kolor wycinka
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz i dostosowuj wykresy kołowe na Androidzie przy użyciu Aspose.Slides for Android via Java. Konfiguruj wykresy dodatkowe, wyświetlaj etykiety danych i stosuj automatyczne kolory wycinków w programie PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie wycinków w standardowym wykresie kołowym.

Przykłady koncentrują się na zadaniach dostosowywania wykresu, takich jak dodawanie wykresu do slajdu, dostosowywanie ustawień serii i etykiet, zamiana domyślnych danych wykresu na własne kategorie i wartości oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides for Android via Java obsługuje opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie. Opcje te kontrolują rozmiar drugorzędnego wykresu oraz sposób podziału punktów danych pomiędzy dwa wykresy.

Poniższy przykład tworzy wykres Pie of Pie w nowej prezentacji i wyświetla wartości punktów danych jako etykiety. Metoda [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) ustawia rozmiar drugorzędnego wykresu na 149% głównego wykresu. [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) wybiera podział oparty na procentach, a [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) ustawia próg na 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Wyświetl wartości i skonfiguruj wykres dodatkowy.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Wybierz kategorie dla drugorzędnego wykresu**

Użyj niestandardowego podziału, gdy chcesz grupować określone kategorie w drugorzędnym wykresie niezależnie od ich wartości procentowych. Na przykład raport sprzedaży może pokazywać Online i Events razem, aby czytelnicy mogli porównać te dwa kanały, mimo że stanowią 35% i 10% całkowitej sprzedaży.

Wywołaj [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) z [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) i wybierz punkty za pomocą [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Metoda [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) kolekcji przyjmuje indeks zero‑bazowy w serii; użyj [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) , aby dodać obiekt punktu danych. W tym przykładzie indeks 1 wybiera Online, a punkt o indeksie 3 wybiera Events. Partners jest również dodany tymczasowo, a następnie wykluczony przy użyciu [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Zastąp domyślne dane sprzedażą według kanału.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Wybierz Online według indeksu zero-bazowego i Events według obiektu punktu danych.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Wyklucz Partners z wyboru bez usuwania jego danych źródłowych.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) i Events (10) pojawiają się jako oddzielne wycinki w drugorzędnym wykresie. W wykresie głównym są one reprezentowane jedną połączoną częścią o wartości 45, obok Retail (40) i Partners (15). Usunięcie Partners z niestandardowego wyboru pozostawia go w wykresie głównym; nie usuwa kategorii ani jej wartości z danych źródłowych wykresu.

The following image shows the saved presentation in PowerPoint:

![Wykres Pie of Pie z Online i Events w drugorzędnym wykresie oraz ich łączną wartością 45 w wykresie głównym](pie_of_pie_custom.png)

## **Ustaw automatyczne kolory wycinków wykresu kołowego**

Aspose.Slides for Android via Java może automatycznie przydzielać różne kolory wycinkom wykresu kołowego. Poniższy przykład tworzy wykres kołowy z wyśrodkowanym tytułem i zastępuje domyślne dane trzema kategoriami kwartalnymi oraz ich wartościami. Metoda [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) wyświetla wartości 20, 50 i 30 jako etykiety, natomiast [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) włącza odrębny kolor dla każdego wycinka.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Dodaj wyśrodkowany tytuł wykresu.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Zastąp domyślne dane przy użyciu pierwszego arkusza.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Pokaż wartości i przydziel różne kolory wycinkom.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy warianty Pie of Pie i Bar of Pie są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) drugorzędny wykres dla wykresów kołowych, w tym typy Pie of Pie i Bar of Pie.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wyk wykres jako obraz](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (np. PNG) bez eksportowania całej prezentacji.