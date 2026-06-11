---
title: Dostosowywanie słupków błędów w wykresach prezentacji na Androidzie
linktitle: Słupki błędów
type: docs
url: /pl/androidjava/error-bar/
keywords:
- słupki błędów
- wartość niestandardowa
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodać i dostosować słupki błędów w wykresach za pomocą Aspose.Slides for Android via Java - optymalizuj wizualizacje danych w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z słupkami błędów w wykresach prezentacji przy użyciu Aspose.Slides. Pokazuje, jak dodać słupki błędów do serii wykresu, skonfigurować ustawienia słupków błędów X i Y oraz zastosować różne typy wartości, takie jak stałe, procentowe i niestandardowe.

Pokazuje także, jak przypisać niestandardowe wartości słupków błędów dla poszczególnych punktów danych w serii, używając odpowiedniej kolekcji punktów danych. Dodatkowo artykuł zawiera krótkie uwagi na temat zachowania słupków błędów podczas eksportu, ich kompatybilności z znacznikami i etykietami danych oraz gdzie znaleźć powiązane klasy i wyliczenia w dokumentacji API.

## **Dodaj słupki błędów**
Aspose.Slides for Android via Java udostępnia prosty interfejs API do zarządzania wartościami słupków błędów. Przykładowy kod ma zastosowanie przy użyciu typu wartości niestandardowej. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** określonego punktu danych w kolekcji [**DataPoints**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartSeriesCollection) serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu Y.
1. Ustaw wartości słupków i format.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Tworzenie wykresu bąbelkowego
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Dodawanie słupków błędów i ustawianie ich formatu
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Zapisywanie prezentacji
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodaj niestandardowe wartości słupków błędów**
Aspose.Slides for Android via Java udostępnia prosty interfejs API do zarządzania niestandardowymi wartościami słupków błędów. Przykładowy kod ma zastosowanie, gdy właściwość [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) jest równa **Custom**. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** określonego punktu danych w kolekcji [**DataPoints**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartSeriesCollection) serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format słupka błędu Y.
1. Uzyskaj dostęp do poszczególnych punktów danych serii wykresu i ustaw wartości słupka błędu dla każdego punktu danych.
1. Ustaw wartości słupków i format.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Tworzenie wykresu bąbelkowego
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Dodawanie niestandardowych słupków błędów i ustawianie ich formatu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Uzyskiwanie dostępu do punktu danych serii wykresu i ustawianie wartości słupków błędów dla
    // poszczególnego punktu
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Ustawianie słupków błędów dla punktów serii wykresu
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Zapisywanie prezentacji
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Co się dzieje ze słupkami błędów podczas eksportu prezentacji do PDF lub obrazów?**

Są renderowane jako część wykresu i zachowywane podczas konwersji wraz z resztą formatowania wykresu, o ile używana jest kompatybilna wersja lub silnik renderujący.

**Czy słupki błędów można łączyć ze znacznikami i etykietami danych?**

Tak. Słupki błędów są odrębnym elementem i są kompatybilne ze znacznikami oraz etykietami danych; jeśli elementy nakładają się na siebie, może być konieczne dostosowanie formatowania.

**Gdzie mogę znaleźć listę właściwości i klas do pracy ze słupkami błędów w API?**

W dokumentacji API: klasa [ErrorBarsFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/errorbarsformat/) oraz powiązane klasy [ErrorBarType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/errorbartype/) i [ErrorBarValueType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/errorbarvaluetype/).