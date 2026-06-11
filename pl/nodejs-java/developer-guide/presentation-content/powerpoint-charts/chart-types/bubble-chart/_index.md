---
title: Dostosuj wykresy bąbelkowe w prezentacjach przy użyciu JavaScript
linktitle: Wykres bąbelkowy
type: docs
url: /pl/nodejs-java/bubble-chart/
keywords:
- wykres bąbelkowy
- rozmiar bąbla
- skalowanie rozmiaru
- reprezentacja rozmiaru
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz i dostosowuj potężne wykresy bąbelkowe w PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js via Java, aby łatwo ulepszyć wizualizację danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresami bąbelkowymi w Aspose.Slides. Omawia dwie konkretne opcje dostosowywania: skalowanie rozmiarów bąbelków za pomocą metody `setBubbleSizeScale` oraz kontrolowanie, jak wartości rozmiaru bąbelków są reprezentowane za pomocą metody `setBubbleSizeRepresentation`.

Przykłady demonstrują, jak utworzyć wykres bąbelkowy, dostosować skalowanie rozmiaru oraz przełączyć reprezentację rozmiaru bąbelków na szerokość. Artykuł zawiera także krótką sekcję FAQ, która wyjaśnia obsługę typu wykresu „Bubble with 3‑D”, zauważa, że praktyczne limity wykresu zależą od wydajności i docelowej wersji PowerPoint oraz wyjaśnia, że eksport zachowuje wygląd wykresu dzięki silnikowi renderującemu Aspose.Slides.

## **Skalowanie rozmiaru wykresu bąbelkowego**
Aspose.Slides for Node.js via Java zapewnia obsługę skalowania rozmiaru wykresu bąbelkowego. W Aspose.Slides for Node.js via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) i [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-) dodano nowe metody. Poniżej podano przykładowy kod.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Reprezentuj dane jako rozmiary wykresu bąbelkowego**
Do klas [ChartSeries](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartSeriesGroup) oraz powiązanych klas dodano metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) i [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--). **BubbleSizeRepresentation** określa, w jaki sposób wartości rozmiaru bąbelków są przedstawiane na wykresie bąbelkowym. Dostępne wartości to: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) oraz [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). W związku z tym do wyliczenia [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BubbleSizeRepresentationType) dodano możliwe sposoby reprezentacji danych jako rozmiarów wykresu bąbelkowego. Przykładowy kod znajduje się poniżej.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy „bubble chart with 3‑D effect” jest obsługiwany i czym różni się od zwykłego?**

Tak. Istnieje osobny typ wykresu, „Bubble with 3‑D”. Nakłada styl 3‑D na bąbelki, ale nie dodaje dodatkowej osi; dane pozostają X‑Y‑S (rozmiar). Typ jest dostępny w wyliczeniu [chart type](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/) .

**Czy istnieje limit liczby serii i punktów w wykresie bąbelkowym?**

Nie ma sztywnego limitu na poziomie API; ograniczenia zależą od wydajności i docelowej wersji PowerPoint. Zaleca się utrzymywanie liczby punktów na rozsądnym poziomie, aby zapewnić czytelność i szybkość renderowania.

**Jak eksport wpływa na wygląd wykresu bąbelkowego (PDF, obrazy)?**

Eksport do obsługiwanych formatów zachowuje wygląd wykresu; renderowanie odbywa się za pośrednictwem silnika Aspose.Slides. Dla formatów rastrowych i wektorowych obowiązują ogólne zasady renderowania grafiki wykresu (rozdzielczość, antyaliasing), więc należy wybrać wystarczającą liczbę DPI do druku.