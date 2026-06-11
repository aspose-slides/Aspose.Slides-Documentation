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
- zaokrąglone obramowanie
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla C++ i podnieś swoją prezentację PowerPoint dzięki profesjonalnemu, przyciągającemu uwagę stylowi."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu i wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Artykuł demonstruje także, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wstępnie zdefiniowane i niestandardowe formaty liczbowe dla danych wykresu oraz włączyć zaokrąglone rogi dla obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresów w prezentacji.

## **Formatuj elementy wykresu**
Aspose.Slides for C++ umożliwia programistom dodawanie własnych wykresów do slajdów od podstaw. Ten artykuł wyjaśnia, jak formatować różne elementy wykresu, w tym oś kategorii i oś wartości.

Aspose.Slides for C++ zapewnia prosty interfejs API do zarządzania różnymi elementami wykresu i formatowania ich przy użyciu własnych wartości:

1. Utwórz instancję klasy **Presentation**.
1. Uzyskaj referencję do slajdu po jego indeksie.
1. Dodaj wykres z danymi domyślnymi oraz wybranym typem (w tym przykładzie użyjemy ChartType.LineWithMarkers).
1. Uzyskaj dostęp do osi wartości wykresu i ustaw następujące właściwości:
   1. Ustaw **Line format** dla głównych linii siatki osi wartości.
   1. Ustaw **Line format** dla pobocznych linii siatki osi wartości.
   1. Ustaw **Number Format** dla osi wartości.
   1. Ustaw **Min, Max, Major and Minor units** dla osi wartości.
   1. Ustaw **Text Properties** dla danych osi wartości.
   1. Ustaw **Title** dla osi wartości.
   1. Ustaw **Line Format** dla osi wartości.
1. Uzyskaj dostęp do osi kategorii wykresu i ustaw następujące właściwości:
   1. Ustaw **Line format** dla głównych linii siatki osi kategorii.
   1. Ustaw **Line format** dla pobocznych linii siatki osi kategorii.
   1. Ustaw **Text Properties** dla danych osi kategorii.
   1. Ustaw **Title** dla osi kategorii.
   1. Ustaw **Label Positioning** dla osi kategorii.
   1. Ustaw **Rotation Angle** dla etykiet osi kategorii.
1. Uzyskaj dostęp do legendy wykresu i ustaw **Text Properties** dla niej.
1. Ustaw wyświetlanie legend wykresu bez nakładania się na wykres.
1. Uzyskaj dostęp do **Secondary Value Axis** wykresu i ustaw następujące właściwości:
   1. Włącz drugorzędną **Value Axis**.
   1. Ustaw **Line Format** dla drugorzędnej osi wartości.
   1. Ustaw **Number Format** dla drugorzędnej osi wartości.
   1. Ustaw **Min, Max, Major and Minor units** dla drugorzędnej osi wartości.
1. Teraz umieść pierwszą serię wykresu na drugorzędnej osi wartości.
1. Ustaw wypełnienie tylnej ściany wykresu.
1. Ustaw wypełnienie obszaru wykresu.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Ustaw właściwości czcionki dla wykresu**
Aspose.Slides for C++ zapewnia wsparcie w ustawianiu właściwości czcionki dla wykresu. Postępuj zgodnie z poniższymi krokami, aby ustawić właściwości czcionki dla wykresu.

- Utwórz obiekt klasy Presentation.
- Dodaj wykres do slajdu.
- Ustaw wysokość czcionki.
- Zapisz zmodyfikowaną prezentację.

Poniżej podano przykładowy kod.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Ustaw właściwości czcionki dla tabeli danych wykresu**
Aspose.Slides for C++ zapewnia wsparcie w zmianie koloru kategorii w serii.

1. Utwórz obiekt klasy Presentation.
1. Dodaj wykres do slajdu.
1. Ustaw tabelę wykresu.
1. Ustaw wysokość czcionki.
1. Zapisz zmodyfikowaną prezentację.

Poniżej podano przykładowy kod.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Ustaw zaokrąglone krawędzie obszaru wykresu**
Aspose.Slides for C++ zapewnia wsparcie w ustawianiu obszaru wykresu. Dodano właściwości **IChart.HasRoundedCorners** i **Chart.HasRoundedCorners** w Aspose.Slides.

1. Utwórz obiekt klasy Presentation.
1. Dodaj wykres do slajdu.
1. Ustaw typ wypełnienia i kolor wypełnienia wykresu.
1. Ustaw właściwość zaokrąglonych rogów na True.
1. Zapisz zmodyfikowaną prezentację.

Poniżej podano przykładowy kod.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Ustaw format liczbowy**
Aspose.Slides for C++ zapewnia prosty interfejs API do zarządzania formatem danych wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Uzyskaj referencję do slajdu po jego indeksie.
1. Dodaj wykres z danymi domyślnymi oraz wybranym typem (w tym przykładzie używamy **ChartType.ClusteredColumn**).
1. Ustaw wstępny format liczbowy z dostępnych wartości wstępnych.
1. Przejdź przez komórki danych wykresu w każdej serii i ustaw format liczbowy danych wykresu.
1. Zapisz prezentację.
1. Ustaw niestandardowy format liczbowy.
1. Przejdź przez komórki danych wykresu w każdej serii i ustaw inny format liczbowy danych wykresu.
1. Zapisz prezentację.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Możliwe wstępnie ustawione wartości formatu liczbowego wraz z ich indeksem i które można używać, podane są poniżej:**|
| :- | :- |
|**0**|General|
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

**Czy mogę ustawić półprzezroczyste wypełnienia dla kolumn/obszarów, zachowując nieprzezroczyste obramowanie?**

Tak. Przezroczystość wypełnienia i obrys są konfigurowane osobno. Jest to przydatne przy poprawianiu czytelności siatki i danych w gęstych wizualizacjach.

**Jak mogę sobie poradzić z etykietami danych, gdy nakładają się na siebie?**

Zmniejsz rozmiar czcionki, wyłącz nieistotne elementy etykiet (na przykład kategorie), ustaw offset/pozycję etykiety, wyświetlaj etykiety tylko dla wybranych punktów w razie potrzeby lub przełącz format na „wartość + legenda”.

**Czy mogę zastosować wypełnienia gradientowe lub wzorcowe do serii?**

Tak. Zazwyczaj dostępne są zarówno wypełnienia jednorodne, jak i gradientowe/wzorcowe. W praktyce używaj gradientów oszczędnie i unikaj kombinacji, które zmniejszają kontrast względem siatki i tekstu.