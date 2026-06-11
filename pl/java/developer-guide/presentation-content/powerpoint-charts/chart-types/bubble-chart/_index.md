---
title: Dostosuj wykresy bąbelkowe w prezentacjach przy użyciu Javy
linktitle: Wykres bąbelkowy
type: docs
url: /pl/java/bubble-chart/
keywords:
- wykres bąbelkowy
- rozmiar bąbelka
- skalowanie rozmiaru
- reprezentacja rozmiaru
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Twórz i dostosowuj zaawansowane wykresy bąbelkowe w PowerPoint przy użyciu Aspose.Slides for Java, aby łatwo wzbogacić wizualizację danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresami bąbelkowymi w Aspose.Slides. Obejmuje dwie konkretne opcje dostosowywania: skalowanie rozmiarów bąbelków przy użyciu metody `setBubbleSizeScale` oraz kontrolowanie sposobu reprezentacji wartości rozmiaru bąbelka przy użyciu metody `setBubbleSizeRepresentation`.

Przykłady pokazują, jak utworzyć wykres bąbelkowy, dostosować skalowanie jego rozmiaru oraz przełączyć reprezentację rozmiaru bąbelka na szerokość. Artykuł zawiera również krótką sekcję FAQ, która wyjaśnia obsługę typu wykresu „Bubble with 3-D”, zauważa, że praktyczne limity wykresu zależą od wydajności i docelowej wersji PowerPoint oraz tłumaczy, że eksport zachowuje wygląd wykresu dzięki silnikowi renderującemu Aspose.Slides.

## **Skalowanie rozmiaru wykresu bąbelkowego**

Aspose.Slides for Java zapewnia obsługę skalowania rozmiaru wykresu bąbelkowego. W Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) oraz [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) dodano metody. Poniżej podano przykładowy kod.

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

## **Reprezentowanie danych jako rozmiary wykresu bąbelkowego**

Do interfejsów [IChartSeries](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartSeriesGroup) oraz powiązanych klas dodano metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) i [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--). **BubbleSizeRepresentation** określa, jak wartości rozmiaru bąbelka są reprezentowane w wykresie bąbelkowym. Możliwe wartości to: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/BubbleSizeRepresentationType#Area) oraz [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Odpowiednio, enum [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/BubbleSizeRepresentationType) został dodany, aby określić możliwe sposoby reprezentacji danych jako rozmiarów wykresu bąbelkowego. Poniżej podano przykładowy kod.

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

**Czy wykres bąbelkowy z efektem 3‑D jest obsługiwany i czym różni się od zwykłego?**

Tak. Istnieje osobny typ wykresu, „Bubble with 3-D”. Nakłada stylizację 3‑D na bąbelki, ale nie dodaje dodatkowej osi; dane pozostają X‑Y‑S (rozmiar). Typ jest dostępny w klasie [chart type](https://reference.aspose.com/slides/pl/java/com.aspose.slides/charttype/).

**Czy istnieje limit liczby serii i punktów w wykresie bąbelkowym?**

Na poziomie API nie ma sztywnego limitu; ograniczenia zależą od wydajności i docelowej wersji PowerPoint. Zaleca się utrzymywanie liczby punktów na rozsądnym poziomie, aby zapewnić czytelność i szybkość renderowania.

**Jak eksport wpływa na wygląd wykresu bąbelkowego (PDF, obrazy)?**

Eksport do obsługiwanych formatów zachowuje wygląd wykresu; renderowanie odbywa się przy użyciu silnika Aspose.Slides. W przypadku formatów rastrowych/wektorowych stosuje się ogólne zasady renderowania grafiki wykresów (rozdzielczość, antyaliasing), dlatego należy wybrać wystarczające DPI do druku.