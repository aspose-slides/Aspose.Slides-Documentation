---
title: Dostosowywanie wykresów kołowych w prezentacjach przy użyciu C++
linktitle: Wykres kołowy
type: docs
url: /pl/cpp/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje wykresu
- kolor fragmentu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy kołowe w C++ przy użyciu Aspose.Slides, które można eksportować do PowerPoint, przyspieszając opowiadanie historii danych w kilka sekund."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugorzędnego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie segmentów w standardowym wykresie kołowym.

Przykłady koncentrują się na praktycznych krokach dostosowywania wykresu, takich jak dodawanie wykresu do slajdu, dostosowywanie ustawień serii i etykiet, zastępowanie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**

Aspose.Slides for C++ obsługuje teraz opcje drugiego wykresu dla wykresów Pie of Pie lub Bar of Pie. W tym temacie zobaczymy na przykładzie, jak określić te opcje przy użyciu Aspose.Slides. Aby określić właściwości, prosimy wykonać poniższe kroki:

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Dodaj wykres na slajdzie.
3. Określ opcje drugiego wykresu.
4. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy różne właściwości wykresu Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Ustaw automatyczne kolory fragmentów wykresu kołowego**

Aspose.Slides for C++ udostępnia proste API do ustawiania automatycznych kolorów segmentów wykresu kołowego. Przykładowy kod stosuje ustawienie wymienionych powyżej właściwości.

1. Utwórz instancję klasy Presentation.
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Ustaw tytuł wykresu.
5. Ustaw pierwszą serię na wyświetlanie wartości.
6. Ustaw indeks arkusza danych wykresu.
7. Pobranie arkusza danych wykresu.
8. Usuń domyślnie wygenerowane serie i kategorie.
9. Dodaj nowe kategorie.
10. Dodaj nową serię.

Zapisz zmodyfikowaną prezentację do pliku PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Czy warianty 'Pie of Pie' i 'Bar of Pie' są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/) drugorzędny wykres dla wykresów kołowych, w tym typy 'Pie of Pie' i 'Bar of Pie'.

**Czy mogę wyeksportować sam wykres jako obraz (np. PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/) (np. PNG) bez całej prezentacji.