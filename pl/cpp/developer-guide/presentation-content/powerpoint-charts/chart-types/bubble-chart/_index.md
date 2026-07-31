---
title: Dostosuj wykresy bąbelkowe w prezentacjach przy użyciu C++
linktitle: Wykres bąbelkowy
type: docs
url: /pl/cpp/bubble-chart/
keywords:
- wykres bąbelkowy
- rozmiar bąbelka
- skalowanie rozmiaru
- reprezentacja rozmiaru
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Twórz i dostosowuj potężne wykresy bąbelkowe w programie PowerPoint za pomocą Aspose.Slides dla C++, aby łatwo ulepszyć wizualizację danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresami bąbelkowymi w Aspose.Slides. Omówiono dwie konkretne opcje dostosowywania: skalowanie rozmiarów bąbelków za pomocą metody `set_BubbleSizeScale` oraz kontrolowanie sposobu reprezentacji wartości rozmiaru bąbelka za pomocą metody `set_BubbleSizeRepresentation`.

Przykłady demonstrują, jak utworzyć wykres bąbelkowy, dostosować skalowanie rozmiaru oraz przełączyć reprezentację rozmiaru bąbelka na użycie szerokości. Artykuł zawiera także krótką sekcję FAQ, w której wyjaśniono obsługę typu wykresu „Bubble with 3‑D”, zaznaczono, że praktyczne ograniczenia wykresu zależą od wydajności i wersji docelowego programu PowerPoint oraz opisano, że eksport zachowuje wygląd wykresu dzięki silnikowi renderującemu Aspose.Slides.

## **Skalowanie rozmiaru wykresu bąbelkowego**
Aspose.Slides for C++ zapewnia obsługę skalowania rozmiaru wykresu bąbelkowego. W Aspose.Slides for **C++** zostały dodane właściwości **IChartSeries.BubbleSizeScale** oraz **IChartSeriesGroup.BubbleSizeScale**. Poniżej podano przykładowy kod.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Reprezentowanie danych jako rozmiary wykresu bąbelkowego**
Do klas **IChartSeries** i **ChartSeries** dodano nową metodę **get_BubbleSizeRepresentation()**. **BubbleSizeRepresentation** określa, w jaki sposób wartości rozmiaru bąbelka są przedstawiane w wykresie bąbelkowym. Dostępne wartości to: **BubbleSizeRepresentationType.Area** i **BubbleSizeRepresentationType.Width**. Odpowiednio, do określenia możliwych sposobów reprezentacji danych jako rozmiarów wykresu bąbelkowego dodano wyliczenie **BubbleSizeRepresentationType**. Poniżej przykład kodu.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Czy „wykres bąbelkowy z efektem 3‑D” jest obsługiwany i czym różni się od zwykłego?**

Tak. Istnieje osobny typ wykresu „Bubble with 3‑D”. Nakłada on stylizację 3‑D na bąbelki, ale nie dodaje dodatkowej osi; dane pozostają X‑Y‑S (rozmiar). Typ jest dostępny w wyliczeniu [chart type](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/).

**Czy istnieje limit liczby serii i punktów w wykresie bąbelkowym?**

Na poziomie API nie ma sztywnego limitu; ograniczenia zależą od wydajności i wersji docelowego programu PowerPoint. Zaleca się utrzymywanie liczby punktów na rozsądnym poziomie, aby zapewnić czytelność i szybkość renderowania.

**Jak eksport wpłynie na wygląd wykresu bąbelkowego (PDF, obrazy)?**

Eksport do obsługiwanych formatów zachowuje wygląd wykresu; renderowanie odbywa się przez silnik Aspose.Slides. W przypadku formatów rastrowych lub wektorowych stosuje się ogólne zasady renderowania grafiki wykresu (rozdzielczość, antyaliasing), dlatego należy wybrać odpowiednie DPI dla druku.