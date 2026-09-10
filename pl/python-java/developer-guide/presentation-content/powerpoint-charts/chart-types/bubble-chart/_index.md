---
title: Dostosowywanie wykresów bąbelkowych w prezentacjach przy użyciu Pythona
linktitle: Wykres bąbelkowy
type: docs
url: /pl/python-java/bubble-chart/
keywords:
- wykres bąbelkowy
- rozmiar bąbelka
- skalowanie rozmiaru
- reprezentacja rozmiaru
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Twórz i dostosowuj potężne wykresy bąbelkowe w PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java, aby łatwo ulepszyć wizualizację danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresami bąbelkowymi w Aspose.Slides. Omówiono w nim dwie konkretne opcje dostosowywania: skalowanie rozmiarów bąbelków przy użyciu metody [setBubbleSizeScale](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) oraz kontrolowanie sposobu reprezentacji wartości rozmiaru bąbelka przy użyciu metody [setBubbleSizeRepresentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Przykłady demonstrują, jak utworzyć wykres bąbelkowy, dostosować skalowanie rozmiaru oraz przełączyć reprezentację rozmiaru bąbelka na szerokość. Artykuł zawiera także krótką sekcję FAQ, w której wyjaśniono obsługę typu wykresu „Bubble with 3‑D”, zaznaczono, że praktyczne limity wykresów zależą od wydajności i docelowej wersji PowerPoint oraz opisano, że eksport zachowuje wygląd wykresu dzięki silnikowi renderującemu Aspose.Slides.

## **Skalowanie rozmiaru wykresu bąbelkowego**
Aspose.Slides for Python via Java obsługuje skalowanie rozmiaru wykresu bąbelkowego przy użyciu metod [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) oraz [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). Poniższy przykład pokazuje, jak skalować rozmiary bąbelków.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Reprezentowanie danych jako rozmiary wykresu bąbelkowego**
Metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) i [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) są dostępne w klasie [ChartSeriesGroup](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/). Reprezentacja rozmiaru bąbelka określa, w jaki sposób wartości rozmiaru są przedstawiane na wykresie bąbelkowym. Możliwe wartości to [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/pl/python-java/aspose.slides/bubblesizerepresentationtype/#Area) oraz [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/pl/python-java/aspose.slides/bubblesizerepresentationtype/#Width). Wyliczenie [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/pl/python-java/aspose.slides/bubblesizerepresentationtype/) określa możliwe sposoby reprezentacji danych jako rozmiarów wykresu bąbelkowego. Poniższy przykład pokazuje, jak reprezentować rozmiary bąbelków przy użyciu szerokości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy wykres bąbelkowy z efektem 3‑D jest obsługiwany i czym różni się od zwykłego?**

Tak. Istnieje osobny typ wykresu „Bubble with 3‑D”. Nakłada on stylizację 3‑D na bąbelki, ale nie dodaje dodatkowej osi; dane pozostają X‑Y‑S (rozmiar). Typ ten jest dostępny w klasie [chart type](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/).

**Czy istnieje limit liczby serii i punktów w wykresie bąbelkowym?**

Na poziomie API nie ma sztywnego limitu; ograniczenia zależą od wydajności i docelowej wersji PowerPoint. Zaleca się utrzymywać liczbę punktów na rozsądnym poziomie, aby zapewnić czytelność i szybkość renderowania.

**Jak eksport wpłynie na wygląd wykresu bąbelkowego (PDF, obrazy)?**

Eksport do obsługiwanych formatów zachowuje wygląd wykresu; renderowanie jest wykonywane przez silnik Aspose.Slides. W przypadku formatów rastrowych lub wektorowych obowiązują ogólne zasady renderowania grafiki wykresów (rozdzielczość, antyaliasing), dlatego należy wybrać wystarczające DPI dla druku.