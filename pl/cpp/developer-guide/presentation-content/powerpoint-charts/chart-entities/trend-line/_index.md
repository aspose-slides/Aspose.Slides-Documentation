---
title: Dodaj linie trendu do wykresów w prezentacjach w C++
linktitle: Linia trendu
type: docs
url: /pl/cpp/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- linia trendu średniej kroczącej
- wielomianowa linia trendu
- potęgowa linia trendu
- niestandardowa linia trendu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Szybko dodawaj i dostosowuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides dla C++ — praktyczny przewodnik, który przyciągnie uwagę odbiorców."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dodać linie trendu do wykresów w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz pracować z różnymi typami linii trendu, w tym wykładniczą, liniową, logarytmiczną, średnią kroczącą, wielomianową i potęgową.

Opisuje także, jak dodać własną linię do wykresu przez wstawienie kształtu linii, oraz zawiera krótkie FAQ dotyczące wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**
Aspose.Slides for C++ udostępnia prosty interfejs API do zarządzania różnymi liniami trendu wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj wykres z domyślnymi danymi oraz wybranym typem (w tym przykładzie użyto ChartType.ClusteredColumn).
4. Dodaj wykładniczą linię trendu dla serii wykresu 1.
5. Dodaj liniową linię trendu dla serii wykresu 1.
6. Dodaj logarytmiczną linię trendu dla serii wykresu 2.
7. Dodaj linię trendu średniej kroczącej dla serii wykresu 2.
8. Dodaj wielomianową linię trendu dla serii wykresu 3.
9. Dodaj potęgową linię trendu dla serii wykresu 3.
10. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Poniższy kod służy do utworzenia wykresu z liniami trendu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Dodaj własną linię**
Aspose.Slides for C++ udostępnia prosty interfejs API do dodawania własnych linii w wykresie. Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy Presentation
- Uzyskaj odniesienie do slajdu, używając jego indeksu
- Utwórz nowy wykres, używając metody AddChart udostępnionej przez obiekt Shapes
- Dodaj AutoShape typu Linia, używając metody AddAutoShape udostępnionej przez obiekt Shapes
- Ustaw kolor linii kształtu.
- Zapisz zmodyfikowaną prezentację jako plik PPTX

Poniższy kod służy do utworzenia wykresu z własnymi liniami.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Co oznaczają terminy „forward” i „backward” w kontekście linii trendu?**

Są to długości linii trendu rzutowane w przód lub w tył: dla wykresów punktowych (XY) — w jednostkach osi; dla wykresów innych niż punktowe — w liczbie kategorii. Dozwolone są tylko wartości nieujemne.

**Czy linia trendu zostanie zachowana przy eksportowaniu prezentacji do formatu PDF lub SVG, albo przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje do [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/) oraz renderuje wykresy jako obrazy; linie trendu, będące częścią wykresu, są zachowywane podczas tych operacji. Dostępna jest także metoda pozwalająca [wyeksportować obraz wykresu](/slides/pl/cpp/create-shape-thumbnails/).