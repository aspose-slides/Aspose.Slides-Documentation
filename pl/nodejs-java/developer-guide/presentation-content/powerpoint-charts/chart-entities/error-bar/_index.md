---
title: Dostosowanie słupków błędów w wykresach prezentacji przy użyciu JavaScript
linktitle: Słupek błędu
type: docs
url: /pl/nodejs-java/error-bar/
keywords:
- słupek błędu
- wartość niestandardowa
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak dodawać i dostosowywać słupki błędów w wykresach za pomocą JavaScript i Aspose.Slides for Node.js via Java — optymalizuj wizualizacje danych w prezentacjach PowerPoint."
---
## **Overview**

Ten artykuł wyjaśnia, jak pracować z słupkami błędów w wykresach prezentacji przy użyciu Aspose.Slides. Pokazuje, jak dodać słupki błędów do serii wykresu, skonfigurować ustawienia słupków błędów X i Y oraz zastosować różne typy wartości, takie jak stałe, procentowe i niestandardowe.

Pokazuje również, jak przypisać niestandardowe wartości słupków błędów do poszczególnych punktów danych w serii, używając odpowiedniej kolekcji punktów danych. Dodatkowo artykuł zawiera krótkie uwagi na temat zachowania słupków błędów podczas eksportu, ich kompatybilności z markerami i etykietami danych oraz gdzie znaleźć powiązane klasy i wyliczenia w dokumentacji API.

## **Add Error Bar**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API do zarządzania wartościami słupków błędów. Przykładowy kod ma zastosowanie przy użyciu typu wartości niestandardowej. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji [**DataPoints**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartSeriesCollection) serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu Y.
1. Ustaw wartości słupków i format.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Tworzenie wykresu bąbelkowego
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Dodawanie słupków błędów i ustawianie ich formatu
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Zapisywanie prezentacji
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add Custom Error Bar Value**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API do zarządzania niestandardowymi wartościami słupków błędów. Przykładowy kod ma zastosowanie, gdy właściwość [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) ma wartość **Custom**. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** konkretnego punktu danych w kolekcji [**DataPoints**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartSeriesCollection) serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu Y.
1. Uzyskaj dostęp do pojedynczych punktów danych serii wykresu i ustaw wartości słupka błędu dla każdego punktu danych.
1. Ustaw wartości słupków i format.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Tworzenie wykresu bąbelkowego
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Dodawanie niestandardowych słupków błędów i ustawianie ich formatu
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Uzyskiwanie dostępu do punktu danych serii wykresu i ustawianie wartości słupków błędów dla
    // poszczególnego punktu
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Ustawianie słupków błędów dla punktów serii wykresu
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Zapisywanie prezentacji
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**What happens to error bars when exporting a presentation to PDF or images?**

Są renderowane jako część wykresu i zachowywane podczas konwersji wraz z resztą formatowania wykresu, pod warunkiem użycia kompatybilnej wersji lub renderera.

**Can error bars be combined with markers and data labels?**

Tak. Słupki błędów są osobnym elementem i są kompatybilne z markerami oraz etykietami danych; jeśli elementy się pokrywają, może być konieczne dostosowanie formatowania.

**Where can I find the list of properties and enums for working with error bars in the API?**

W dokumentacji API: klasa [ErrorBarsFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/errorbarsformat/) oraz powiązane wyliczenia [ErrorBarType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/errorbartype/) i [ErrorBarValueType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/errorbarvaluetype/).