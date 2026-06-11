---
title: Dostosuj wykresy bąbelkowe w prezentacjach w .NET
linktitle: Wykres bąbelkowy
type: docs
url: /pl/net/bubble-chart/
keywords:
- wykres bąbelkowy
- rozmiar bąbelka
- skalowanie rozmiaru
- reprezentacja rozmiaru
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz i dostosowuj potężne wykresy bąbelkowe w programie PowerPoint za pomocą Aspose.Slides dla .NET, aby łatwo ulepszyć wizualizację danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresami bąbelkowymi w Aspose.Slides. Obejmuje dwie konkretne opcje dostosowywania: skalowanie rozmiarów bąbelków za pomocą właściwości `BubbleSizeScale` oraz kontrolowanie sposobu reprezentacji wartości rozmiaru bąbelka za pomocą właściwości `BubbleSizeRepresentation`.

Przykłady demonstrują, jak utworzyć wykres bąbelkowy, dostosować skalowanie jego rozmiaru oraz przełączyć reprezentację rozmiaru bąbelka na użycie szerokości. Artykuł zawiera także krótką sekcję FAQ, która wyjaśnia wsparcie dla typu wykresu „Bubble with 3-D”, zauważa, że praktyczne limity wykresu zależą od wydajności i docelowej wersji PowerPoint oraz wyjaśnia, że eksport zachowuje wygląd wykresu dzięki silnikowi renderującemu Aspose.Slides.

## **Skalowanie rozmiaru wykresu bąbelkowego**
Aspose.Slides for .NET zapewnia wsparcie dla skalowania rozmiaru wykresu bąbelkowego. W Aspose.Slides for .NET zostały dodane właściwości **IChartSeries.BubbleSizeScale** oraz **IChartSeriesGroup.BubbleSizeScale**. Poniżej podano przykładowy kod.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Reprezentowanie danych jako rozmiary wykresu bąbelkowego**
Do interfejsów IChartSeries, IChartSeriesGroup oraz powiązanych klas została dodana właściwość **BubbleSizeRepresentation**. **BubbleSizeRepresentation** określa, w jaki sposób wartości rozmiaru bąbelka są reprezentowane na wykresie bąbelkowym. Dostępne wartości to: **BubbleSizeRepresentationType.Area** oraz **BubbleSizeRepresentationType.Width**. Odpowiednio, do określenia możliwych sposobów reprezentacji danych jako rozmiarów wykresu bąbelkowego został dodany enum **BubbleSizeRepresentationType**. Przykładowy kod znajduje się poniżej.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy „wykres bąbelkowy z efektem 3‑D” jest obsługiwany i czym różni się od zwykłego?**

Tak. Istnieje oddzielny typ wykresu „Bubble with 3-D”. Nakłada on stylizację 3‑D na bąbelki, ale nie dodaje dodatkowej osi; dane pozostają X‑Y‑S (rozmiar). Typ jest dostępny w wyliczeniu [chart type](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/charttype/).

**Czy istnieje limit liczby serii i punktów w wykresie bąbelkowym?**

Nie ma sztywnego limitu na poziomie API; ograniczenia zależą od wydajności i docelowej wersji PowerPoint. Zaleca się utrzymywanie liczby punktów na poziomie rozsądnym, aby zapewnić czytelność i szybkość renderowania.

**Jak eksport wpływa na wygląd wykresu bąbelkowego (PDF, obrazy)?**

Eksport do obsługiwanych formatów zachowuje wygląd wykresu; renderowanie odbywa się przy użyciu silnika Aspose.Slides. Dla formatów rastrowych lub wektorowych obowiązują ogólne zasady renderowania grafiki wykresu (rozdzielczość, antyaliasing), więc należy wybrać odpowiednią DPI dla druku.