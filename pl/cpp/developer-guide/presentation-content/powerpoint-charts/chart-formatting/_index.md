---
title: Formatowanie wykresów w prezentacji w C++
linktitle: Formatowanie wykresu
type: docs
weight: 60
url: /pl/cpp/chart-formatting/
keywords:
- format wykresu
- formatowanie wykresu
- element wykresu
- właściwości wykresu
- ustawienia wykresu
- opcje wykresu
- właściwości czcionki
- zaokrąglona krawędź
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla C++ i podnieś swoją prezentację PowerPoint dzięki profesjonalnemu, przyciągającemu uwagę stylowi."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu oraz wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Demonstruje również, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wstępnie zdefiniowane i niestandardowe formaty liczb do danych wykresu oraz włączyć zaokrąglone narożniki dla obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresu w prezentacji.

## **Formatowanie elementów wykresu**
Aspose.Slides for C++ umożliwia programistom dodawanie własnych wykresów do slajdów od podstaw. Ten artykuł wyjaśnia, jak formatować różne elementy wykresu, w tym oś kategorii i oś wartości.

Aspose.Slides for C++ udostępnia prosty interfejs API do zarządzania różnymi elementami wykresu i formatowania ich przy użyciu własnych wartości:

1. Utwórz instancję klasy **Presentation**.
1. Pobierz referencję do slajdu za pośrednictwem jego indeksu.
1. Dodaj wykres z domyślnymi danymi oraz wybranym typem (w tym przykładzie użyjemy ChartType.LineWithMarkers).
1. Uzyskaj dostęp do osi wartości wykresu i ustaw następujące właściwości:
   1. Ustawienie **Line format** dla głównych linii siatki osi wartości
   1. Ustawienie **Line format** dla pobocznych linii siatki osi wartości
   1. Ustawienie **Number Format** dla osi wartości
   1. Ustawienie **Min, Max, Major and Minor units** dla osi wartości
   1. Ustawienie **Text Properties** dla danych osi wartości
   1. Ustawienie **Title** dla osi wartości
   1. Ustawienie **Line Format** dla osi wartości
1. Uzyskaj dostęp do osi kategorii wykresu i ustaw następujące właściwości:
   1. Ustawienie **Line format** dla głównych linii siatki osi kategorii
   1. Ustawienie **Line format** dla pobocznych linii siatki osi kategorii
   1. Ustawienie **Text Properties** dla danych osi kategorii
   1. Ustawienie **Title** dla osi kategorii
   1. Ustawienie **Label Positioning** dla osi kategorii
   1. Ustawienie **Rotation Angle** dla etykiet osi kategorii
1. Uzyskaj dostęp do legendy wykresu i ustaw **Text Properties** dla niej
1. Ustaw wyświetlanie legend wykresu bez nakładania się na wykres
1. Uzyskaj dostęp do **Secondary Value Axis** wykresu i ustaw następujące właściwości:
   1. Włączenie drugorzędnej **Value Axis**
   1. Ustawienie **Line Format** dla drugorzędnej osi wartości
   1. Ustawienie **Number Format** dla drugorzędnej osi wartości
   1. Ustawienie **Min, Max, Major and Minor units** dla drugorzędnej osi wartości
1. Narysuj pierwszą serię wykresu na drugorzędnej osi wartości
1. Ustaw tło tylnej ściany wykresu na wybrany kolor wypełnienia
1. Ustaw kolor wypełnienia obszaru wykresu
1. Zapisz zmodyfikowaną prezentację do pliku PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Ustawienie właściwości czcionki dla wykresu**
Aspose.Slides for C++ zapewnia obsługę ustawiania właściwości czcionki dla wykresu. Postępuj zgodnie z poniższymi krokami, aby ustawić właściwości czcionki wykresu.

- Utwórz obiekt klasy Presentation.
- Dodaj wykres na slajdzie.
- Ustaw wysokość czcionki.
- Zapisz zmodyfikowaną prezentację.

Poniżej znajduje się przykładowy kod.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Ustawienie właściwości czcionki dla tabeli danych wykresu**
Aspose.Slides for C++ zapewnia obsługę zmiany koloru kategorii w serii.

1. Utwórz obiekt klasy Presentation.
1. Dodaj wykres na slajdzie.
1. Ustaw tabelę wykresu.
1. Ustaw wysokość czcionki.
1. Zapisz zmodyfikowaną prezentację.

Poniżej znajduje się przykładowy kod.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Ustawienie zaokrąglonych krawędzi obszaru wykresu**
Aspose.Slides for C++ zapewnia obsługę ustawiania obszaru wykresu. Dodano właściwości **IChart.HasRoundedCorners** i **Chart.HasRoundedCorners** w Aspose.Slides.

1. Utwórz obiekt klasy Presentation.
1. Dodaj wykres na slajdzie.
1. Ustaw typ wypełnienia i kolor wypełnienia wykresu
1. Ustaw właściwość zaokrąglonych narożników na wartość True.
1. Zapisz zmodyfikowaną prezentację.

Poniżej znajduje się przykładowy kod.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Ustawienie formatu liczbowego**
Aspose.Slides for C++ udostępnia prosty interfejs API do zarządzania formatem danych wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz referencję do slajdu za pośrednictwem jego indeksu.
1. Dodaj wykres z domyślnymi danymi oraz wybranym typem (w tym przykładzie użyto **ChartType.ClusteredColumn**).
1. Ustaw wstępny format liczbowy spośród dostępnych wartości wstępnych.
1. Przejdź przez każdą komórkę danych wykresu w każdej serii i ustaw format liczbowy danych wykresu.
1. Zapisz prezentację.
1. Ustaw niestandardowy format liczbowy.
1. Przejdź przez komórki danych wykresu w każdej serii i ustaw inny format liczbowy danych wykresu.
1. Zapisz prezentację.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Możliwe wstępnie zdefiniowane formaty liczb wraz z ich indeksami**|
| :- | :- |

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**Czy mogę ustawić półprzezroczyste wypełnienia kolumn/obszarów, zachowując nieprzezroczyste krawędzie?**

Tak. Przezroczystość wypełnienia i kontur są konfigurowane osobno. Jest to przydatne do zwiększenia czytelności siatki i danych w gęstych wizualizacjach.

**Jak radzić sobie z etykietami danych, gdy zachodzą na siebie?**

Zmniejsz rozmiar czcionki, wyłącz nieistotne elementy etykiet (np. kategorie), ustaw offset/pozycję etykiety, wyświetlaj etykiety tylko dla wybranych punktów w razie potrzeby lub przełącz format na „wartość + legenda”.

**Czy mogę zastosować gradientowe lub wzorcowe wypełnienia w seriach?**

Tak. Zarówno jednolite, jak i gradientowe/wzorcowe wypełnienia są zazwyczaj dostępne. W praktyce używaj gradientów oszczędnie i unikaj kombinacji, które zmniejszają kontrast względem siatki i tekstu.