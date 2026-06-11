---
title: Dostosowywanie wykresów bąbelkowych w prezentacjach na Androidzie
linktitle: Wykres bąbelkowy
type: docs
url: /pl/androidjava/bubble-chart/
keywords:
- wykres bąbelkowy
- rozmiar bąbelka
- skalowanie rozmiaru
- reprezentacja rozmiaru
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz i dostosowuj potężne wykresy bąbelkowe w PowerPoint przy użyciu Aspose.Slides for Android via Java, aby łatwo ulepszyć wizualizację danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresami bąbelkowymi w Aspose.Slides. Omawia dwie konkretne opcje dostosowywania: skalowanie rozmiarów bąbelków za pomocą metody `setBubbleSizeScale` oraz kontrolowanie sposobu reprezentacji wartości rozmiaru bąbelka za pomocą metody `setBubbleSizeRepresentation`.

Przykłady demonstrują, jak utworzyć wykres bąbelkowy, dostosować skalowanie rozmiaru oraz przełączyć reprezentację rozmiaru bąbelka na użycie szerokości. Artykuł zawiera również krótką sekcję FAQ, która wyjaśnia obsługę typu wykresu „Bubble with 3-D”, informuje, że praktyczne limity wykresów zależą od wydajności i docelowej wersji PowerPointa, oraz opisuje, że eksport zachowuje wygląd wykresu dzięki silnikowi renderowania Aspose.Slides.

## **Skalowanie rozmiaru wykresu bąbelkowego**
Aspose.Slides for Android via Java zapewnia obsługę skalowania rozmiaru wykresu bąbelkowego. W Aspose.Slides for Android via Java zostały dodane metody [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) oraz [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-). Poniżej podany jest przykładowy kod.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Przedstawianie danych jako rozmiary wykresu bąbelkowego**
Do interfejsów [IChartSeries](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartSeriesGroup) oraz powiązanych klas zostały dodane metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) i [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--). **BubbleSizeRepresentation** określa, w jaki sposób wartości rozmiaru bąbelka są reprezentowane na wykresie bąbelkowym. Możliwe wartości to: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) oraz [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). W związku z tym, do określenia możliwych sposobów przedstawiania danych jako rozmiary wykresu bąbelkowego został dodany wym enumeracja [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/BubbleSizeRepresentationType). Poniżej podany jest przykładowy kod.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy wykres bąbelkowy z efektem 3-D jest obsługiwany i jak różni się od zwykłego?**

Tak. Istnieje oddzielny typ wykresu, „Bubble with 3-D”. Nakłada on stylizację 3‑D na bąbelki, ale nie dodaje dodatkowej osi; dane pozostają X‑Y‑S (rozmiar). Typ jest dostępny w klasie [chart type](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/charttype/).

**Czy istnieje limit liczby serii i punktów w wykresie bąbelkowym?**

Nie ma sztywnego limitu na poziomie API; ograniczenia zależą od wydajności oraz docelowej wersji PowerPointa. Zaleca się, aby liczba punktów była rozsądna dla czytelności i szybkości renderowania.

**Jak eksport wpływa na wygląd wykresu bąbelkowego (PDF, obrazy)?**

Eksport do obsługiwanych formatów zachowuje wygląd wykresu; renderowanie jest wykonywane przez silnik Aspose.Slides. W przypadku formatów rastrowych/wektorowych obowiązują ogólne zasady renderowania grafiki wykresu (rozdzielczość, antyaliasing), dlatego należy wybrać odpowiednią liczbę DPI do druku.