---
title: Dostosowywanie wykresów kołowych w prezentacjach na Androidzie
linktitle: Wykres kołowy
type: docs
url: /pl/androidjava/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje wykreślania
- kolor wycinka
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy kołowe w Javie przy użyciu Aspose.Slides dla Androida, które można eksportować do PowerPointa, zwiększając opowiadanie historii danych w kilka sekund."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie wycinków w standardowym wykresie kołowym.

Przykłady koncentrują się na praktycznych krokach dostosowywania wykresu, takich jak dodawanie wykresu do slajdu, dostosowywanie ustawień serii i etykiet, zamiana domyślnych danych wykresu na niestandardowe kategorie i wartości oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides dla Androida za pośrednictwem Javy obsługuje teraz opcje drugiego wykresu dla wykresów Pie of Pie lub Bar of Pie. W tym temacie pokażemy, jak określić te opcje przy użyciu Aspose.Slides. Aby określić właściwości, wykonaj następujące kroki:

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
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

## **Ustaw automatyczne kolory wycinków wykresu kołowego**

Aspose.Slides dla Androida za pośrednictwem Javy udostępnia prosty interfejs API do ustawiania automatycznych kolorów wycinków wykresu kołowego. Przykładowy kod stosuje ustawienie wymienionych wyżej właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Ustaw tytuł wykresu.
1. Ustaw pierwszą serię na wyświetlanie wartości.
1. Ustaw indeks arkusza danych wykresu.
1. Pobieranie arkusza danych wykresu.
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

    // Ustaw pierwszą serię na wyświetlanie wartości
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

    // Dodawanie nowej serii
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

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/charttype/) drugorzędny wykres dla wykresów kołowych, w tym typy 'Pie of Pie' i 'Bar of Pie'.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (np. PNG) bez całej prezentacji.