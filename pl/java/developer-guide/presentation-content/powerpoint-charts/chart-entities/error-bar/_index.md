---
title: Dostosuj paski błędów w wykresach prezentacji przy użyciu Java
linktitle: Pasek błędu
type: docs
url: /pl/java/error-bar/
keywords:
- pasek błędu
- wartość niestandardowa
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać i dostosowywać paski błędów w wykresach za pomocą Aspose.Slides dla Java — optymalizuj wizualizację danych w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z paskami błędów w wykresach prezentacji przy użyciu Aspose.Slides. Pokazuje, jak dodać paski błędów do serii wykresu, skonfigurować ustawienia pasków błędów X i Y oraz zastosować różne typy wartości, takie jak stałe, procentowe i własne wartości.

Prezentuje także, jak przypisać własne wartości pasków błędów do pojedynczych punktów danych w serii, korzystając z odpowiedniej kolekcji punktów danych. Dodatkowo artykuł zawiera krótkie uwagi na temat zachowania pasków błędów podczas eksportu, ich kompatybilności z znacznikami i etykietami danych oraz gdzie znaleźć powiązane klasy i wyliczenia w dokumentacji API.

## **Dodaj paski błędów**
Aspose.Slides for Java udostępnia prosty interfejs API do zarządzania wartościami pasków błędów. Przykładowy kod ma zastosowanie przy użyciu własnego typu wartości. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** danego punktu danych w kolekcji [**DataPoints**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartSeriesCollection) serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów Y.
1. Ustaw wartości i format pasków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Tworzenie wykresu bąbelkowego
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Dodawanie pasków błędów i ustawianie ich formatu
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

    // Zapisanie prezentacji
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodaj własne wartości pasków błędów**
Aspose.Slides for Java udostępnia prosty interfejs API do zarządzania własnymi wartościami pasków błędów. Przykładowy kod ma zastosowanie, gdy właściwość [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IErrorBarsFormat#getValue--) jest równa **Custom**. Aby określić wartość, użyj właściwości **ErrorBarCustomValues** danego punktu danych w kolekcji [**DataPoints**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartSeriesCollection) serii:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Dodaj wykres bąbelkowy na wybranym slajdzie.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów X.
1. Uzyskaj dostęp do pierwszej serii wykresu i ustaw format pasków błędów Y.
1. Uzyskaj dostęp do poszczególnych punktów danych serii wykresu i ustaw wartości pasków błędów dla każdego punktu danych.
1. Ustaw wartości i format pasków.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Tworzenie wykresu bąbelkowego
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Dodawanie własnych pasków błędów i ustawianie ich formatu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Uzyskiwanie dostępu do punktu danych serii wykresu i ustawianie wartości pasków błędów dla
    // poszczególnego punktu
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Ustawianie pasków błędów dla punktów serii wykresu
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

**Co się dzieje z paskami błędów podczas eksportu prezentacji do PDF lub obrazów?**

Są renderowane jako część wykresu i zachowywane podczas konwersji wraz z resztą formatowania wykresu, pod warunkiem użycia kompatybilnej wersji lub renderera.

**Czy paski błędów można łączyć ze znacznikami i etykietami danych?**

Tak. Paski błędów są odrębnym elementem i są kompatybilne ze znacznikami oraz etykietami danych; jeśli elementy nachodzą na siebie, może być konieczne dostosowanie formatowania.

**Gdzie mogę znaleźć listę właściwości i klas służących do pracy z paskami błędów w API?**

W dokumentacji API: klasa [ErrorBarsFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/errorbarsformat/) oraz powiązane klasy [ErrorBarType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/errorbartype/) i [ErrorBarValueType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/errorbarvaluetype/).