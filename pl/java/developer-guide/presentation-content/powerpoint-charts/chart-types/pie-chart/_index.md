---
title: Dostosowywanie wykresów kołowych w prezentacjach przy użyciu Java
linktitle: Wykres kołowy
type: docs
url: /pl/java/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje wykreślania
- kolor segmentu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy kołowe w Javie za pomocą Aspose.Slides, które można wyeksportować do PowerPoint, zwiększając siłę opowiadania danych w kilka sekund."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie segmentów dla standardowego wykresu kołowego.

Przykłady koncentrują się na praktycznych krokach dostosowywania wykresów, takich jak dodawanie wykresu do slajdu, dostosowywanie ustawień serii i etykiet, zastępowanie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**
Aspose.Slides for Java now supports second plot options for Pie of Pie or Bar of Pie chart. In this topic, we will show you how to specify those options using Aspose.Slides. To specify the properties, do this:

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Określ opcje drugiego wykresu wykresu.
1. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy różne właściwości wykresu Pie of Pie.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Dodaj wykres na slajdzie
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Ustaw różne właściwości
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Zapisz prezentację na dysku
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw automatyczne kolory segmentów wykresu kołowego**
Aspose.Slides for Java provides a simple API for setting automatic pie chart slide colors. The sample code applies setting the above said properties.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Ustaw tytuł wykresu.
1. Ustaw pierwszą serię, aby wyświetlała wartości.
1. Ustaw indeks arkusza danych wykresu.
1. Pobierz arkusz danych wykresu.
1. Usuń domyślnie wygenerowane serie i kategorie.
1. Dodaj nowe kategorie.
1. Dodaj nowe serie.

Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Dodaj wykres z domyślnymi danymi
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Ustawianie tytułu wykresu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Ustaw pierwszą serię, aby wyświetlała wartości
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Ustawianie indeksu arkusza danych wykresu
    int defaultWorksheetIndex = 0;

    // Pobieranie arkusza danych wykresu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Usuń domyślnie wygenerowane serie i kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Dodawanie nowych kategorii
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Dodawanie nowych serii
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Teraz wypełnianie danych serii
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy warianty 'Pie of Pie' i 'Bar of Pie' są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/pl/java/com.aspose.slides/charttype/) drugi wykres dla wykresów kołowych, w tym typy 'Pie of Pie' i 'Bar of Pie'.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getImage-int-float-float-) (na przykład PNG) bez całej prezentacji.