---
title: Dostosowywanie wykresów kołowych w prezentacjach przy użyciu JavaScript
linktitle: Wykres kołowy
type: docs
url: /pl/nodejs-java/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje rysowania
- kolor wycinków
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy kołowe w JavaScript przy użyciu Aspose.Slides dla Node.js, eksportowalne do PowerPoint, zwiększając opowieść o danych w kilka sekund."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie wycinków w standardowym wykresie kołowym.

Przykłady koncentrują się na praktycznych krokach dostosowywania wykresu, takich jak dodawanie wykresu do slajdu, dostosowywanie ustawień serii i etykiet, zastępowanie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides for Node.js via Java obsługuje teraz opcje drugiego wykresu dla wykresów Pie of Pie lub Bar of Pie. W tym temacie pokażemy, jak określić te opcje przy użyciu Aspose.Slides. Aby określić właściwości, wykonaj następujące kroki:

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Określ opcje drugiego wykresu dla wykresu.
1. Zapisz prezentację na dysku.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Dodaj wykres na slajdzie
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Ustaw różne własności
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Zapisz prezentację na dysku
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw automatyczne kolory wycinków wykresu kołowego**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API do ustawiania automatycznych kolorów wycinków wykresu kołowego. Przykładowy kod stosuje ustawienie wyżej wymienionych właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Ustaw tytuł wykresu.
1. Ustaw pierwszą serię na wyświetlanie wartości.
1. Ustaw indeks arkusza danych wykresu.
1. Pobierz arkusz danych wykresu.
1. Usuń domyślnie wygenerowane serie i kategorie.
1. Dodaj nowe kategorie.
1. Dodaj nowe serie.

Zapisz zmodyfikowaną prezentację do pliku PPTX.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Dodaj wykres z domyślnymi danymi
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Ustawianie tytułu wykresu
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Ustaw pierwszą serię na wyświetlanie wartości
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Ustawianie indeksu arkusza danych wykresu
    var defaultWorksheetIndex = 0;
    // Pobieranie arkusza danych wykresu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Usuń domyślnie wygenerowane serie i kategorie
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Dodawanie nowych kategorii
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Dodawanie nowych serii
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Teraz wypełnianie danych serii
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy warianty 'Pie of Pie' i 'Bar of Pie' są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/) drugorzędny wykres dla wykresów kołowych, w tym typy 'Pie of Pie' i 'Bar of Pie'.

**Czy mogę wyeksportować sam wykres jako obraz (na przykład PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage) (np. PNG) bez całej prezentacji.