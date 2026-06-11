---
title: Dostosuj wykresy kołowe w prezentacjach przy użyciu C++
linktitle: Wykres kołowy
type: docs
url: /pl/cpp/pie-chart/
keywords:
- wykres kołowy
- zarządzanie wykresem
- dostosowywanie wykresu
- opcje wykresu
- ustawienia wykresu
- opcje wykreślania
- kolor fragmentu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy kołowe w C++ za pomocą Aspose.Slides, które można eksportować do PowerPoint, zwiększając efektywność opowiadania historii danych w ciągu kilku sekund."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wykresami kołowymi w Aspose.Slides. Pokazuje, jak skonfigurować opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie oraz jak włączyć automatyczne kolorowanie fragmentów standardowego wykresu kołowego.

Przykłady koncentrują się na praktycznych krokach dostosowywania wykresu, takich jak dodawanie wykresu do slajdu, dopasowywanie ustawień serii i etykiet, zastępowanie domyślnych danych wykresu własnymi kategoriami i wartościami oraz zapisywanie zaktualizowanej prezentacji.

## **Opcje drugiego wykresu dla wykresów Pie of Pie i Bar of Pie**
Aspose.Slides for C++ obsługuje teraz opcje drugiego wykresu dla wykresów Pie of Pie lub Bar of Pie. W tym temacie zobaczymy na przykładzie, jak określić te opcje przy użyciu Aspose.Slides. Aby określić właściwości, postępuj zgodnie z poniższymi krokami:

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Dodaj wykres na slajdzie.
1. Określ drugie opcje wykresu.
1. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy różne właściwości wykresu Pie of Pie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Ustaw automatyczne kolory fragmentów wykresu kołowego**
Aspose.Slides for C++ udostępnia prosty interfejs API do ustawiania automatycznych kolorów fragmentów wykresu kołowego. Przykładowy kod zastosowuje opisane powyżej właściwości.

1. Utwórz instancję klasy Presentation.
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Ustaw tytuł wykresu.
1. Ustaw pierwszą serię na Wyświetl wartości.
1. Ustaw indeks arkusza danych wykresu.
1. Pobierz arkusz danych wykresu.
1. Usuń domyślnie wygenerowane serie i kategorie.
1. Dodaj nowe kategorie.
1. Dodaj nową serię.

Zapisz zmodyfikowaną prezentację do pliku PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Czy warianty 'Pie of Pie' i 'Bar of Pie' są obsługiwane?**

Tak, biblioteka [obsługuje](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/) dodatkowy wykres dla wykresów kołowych, w tym typy 'Pie of Pie' i 'Bar of Pie'.

**Czy mogę wyeksportować sam wykres jako obraz (np. PNG)?**

Tak, możesz [wyeksportować sam wykres jako obraz](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/) (np. PNG) bez całej prezentacji.