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
description: "Twórz i dostosowuj wydajne wykresy bąbelkowe w PowerPoint za pomocą Aspose.Slides dla C++, aby łatwo poprawić wizualizację danych."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresami bąbelkowymi w Aspose.Slides. Obejmuje dwie konkretne opcje dostosowywania: skalowanie rozmiarów bąbelków za pomocą metody `set_BubbleSizeScale` oraz kontrolowanie sposobu reprezentacji wartości rozmiaru bąbelka za pomocą metody `set_BubbleSizeRepresentation`.

Przykłady pokazują, jak utworzyć wykres bąbelkowy, dostosować skalowanie jego rozmiaru oraz przełączyć reprezentację rozmiaru bąbelka na użycie szerokości. Artykuł zawiera również krótką sekcję FAQ, która wyjaśnia wsparcie dla typu wykresu „Bubble with 3-D”, zauważa, że praktyczne limity wykresu zależą od wydajności i docelowej wersji PowerPoint oraz wyjaśnia, że eksport zachowuje wygląd wykresu dzięki silnikowi renderującemu Aspose.Slides.

## **Skalowanie rozmiaru wykresu bąbelkowego**
Aspose.Slides dla C++ zapewnia obsługę skalowania rozmiaru wykresu bąbelkowego. W Aspose.Slides dla **C++ IChartSeries.BubbleSizeScale** i **IChartSeriesGroup.BubbleSizeScale** dodano właściwości. Poniższy przykładowy kod został podany. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Reprezentowanie danych jako rozmiary wykresu bąbelkowego**
Do klas **IChartSeries** i **ChartSeries** dodano nową metodę **get_BubbleSizeRepresentation()**. **BubbleSizeRepresentation** określa, w jaki sposób wartości rozmiaru bąbelka są przedstawiane na wykresie bąbelkowym. Dostępne wartości to: **BubbleSizeRepresentationType.Area** oraz **BubbleSizeRepresentationType.Width**. Odpowiednio, do określenia możliwych sposobów reprezentacji danych jako rozmiarów wykresu bąbelkowego dodano wyliczenie **BubbleSizeRepresentationType**. Poniżej znajduje się przykładowy kod.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Czy wykres bąbelkowy z efektem 3‑D jest obsługiwany i jak różni się od zwykłego?**

Tak. Istnieje oddzielny typ wykresu, „Bubble with 3‑D”. Nakłada on stylizację 3‑D na bąbelki, ale nie dodaje dodatkowej osi; dane pozostają X‑Y‑S (rozmiar). Typ jest dostępny w wyliczeniu [chart type](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/).

**Czy istnieje limit liczby serii i punktów w wykresie bąbelkowym?**

Nie ma sztywnego limitu na poziomie API; ograniczenia wynikają z wydajności i docelowej wersji PowerPoint. Zaleca się utrzymywanie liczby punktów na rozsądnym poziomie, aby zapewnić czytelność i szybkość renderowania.

**Jak eksport wpływa na wygląd wykresu bąbelkowego (PDF, obrazy)?**

Eksport do obsługiwanych formatów zachowuje wygląd wykresu; renderowanie jest wykonywane przez silnik Aspose.Slides. W przypadku formatów rastrowych lub wektorowych stosuje się ogólne zasady renderowania grafiki wykresów (rozdzielczość, antyaliasing), dlatego należy wybrać odpowiednie DPI do druku.