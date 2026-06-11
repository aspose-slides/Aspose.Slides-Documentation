---
title: Dostosuj wykresy bąbelkowe w prezentacjach w Pythonie
linktitle: Wykres bąbelkowy
type: docs
url: /pl/python-net/bubble-chart/
keywords:
- wykres bąbelkowy
- rozmiar bąbelka
- skalowanie rozmiaru
- reprezentacja rozmiaru
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i dostosowuj potężne wykresy bąbelkowe w PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via .NET, aby łatwo ulepszyć wizualizację danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresami bąbelkowymi w Aspose.Slides. Obejmuje dwie konkretne opcje dostosowywania: skalowanie rozmiarów bąbelków za pomocą właściwości `bubble_size_scale` oraz kontrolowanie sposobu reprezentacji wartości rozmiaru bąbelka za pomocą właściwości `bubble_size_representation`.

Przykłady demonstrują, jak utworzyć wykres bąbelkowy, dostosować skalowanie jego rozmiaru oraz przełączyć reprezentację rozmiaru bąbelka na użycie szerokości. Artykuł zawiera także krótką sekcję FAQ, która wyjaśnia obsługę typu wykresu „Bubble with 3-D”, zauważa, że praktyczne limity wykresów zależą od wydajności i docelowej wersji PowerPoint oraz opisuje, że eksport zachowuje wygląd wykresu dzięki silnikowi renderującemu Aspose.Slides.

## **Skalowanie rozmiaru wykresu bąbelkowego**
Aspose.Slides for Python via .NET zapewnia obsługę skalowania rozmiaru wykresu bąbelkowego. W Aspose.Slides for Python via .NET dodano właściwości **ChartSeries.bubble_size_scale** oraz **ChartSeriesGroup.bubble_size_scale**. Poniżej podano przykładowy kod.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Reprezentowanie danych jako rozmiary wykresu bąbelkowego**
Do klas ChartSeries i ChartSeriesGroup dodano właściwość **bubble_size_representation**. **bubble_size_representation** określa, w jaki sposób wartości rozmiaru bąbelka są reprezentowane na wykresie bąbelkowym. Możliwe wartości to: **BubbleSizeRepresentationType.AREA** oraz **BubbleSizeRepresentationType.WIDTH**. Odpowiednio, do określenia możliwych sposobów reprezentacji danych jako rozmiarów wykresu bąbelkowego dodano wyliczenie **BubbleSizeRepresentationType**. Poniżej znajduje się przykładowy kod.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy „wykres bąbelkowy z efektem 3‑D” jest obsługiwany i czym różni się od zwykłego?**

Tak. Istnieje osobny typ wykresu „Bubble with 3-D”. Nakłada on styl 3‑D na bąbelki, ale nie dodaje dodatkowej osi; dane pozostają X‑Y‑S (rozmiar). Typ ten jest dostępny w wyliczeniu [chart type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/charttype/).

**Czy istnieje limit liczby serii i punktów w wykresie bąbelkowym?**

Na poziomie API nie ma sztywnego limitu; ograniczenia wynikają z wydajności i wersji docelowego PowerPointa. Zaleca się utrzymywać liczbę punktów na rozsądnym poziomie, aby zapewnić czytelność i szybkość renderowania.

**Jak eksport wpływa na wygląd wykresu bąbelkowego (PDF, obrazy)?**

Eksport do obsługiwanych formatów zachowuje wygląd wykresu; renderowanie jest wykonywane przez silnik Aspose.Slides. Dla formatów rastrowych/wektorowych obowiązują ogólne zasady renderowania grafiki wykresów (rozdzielczość, antyaliasing), dlatego należy wybrać wystarczającą liczbę DPI do druku.