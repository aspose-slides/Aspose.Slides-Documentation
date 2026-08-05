---
title: Dodaj linie trendu do wykresów w prezentacji w C++
linktitle: Linia trendu
type: docs
url: /pl/cpp/trend-line/
keywords:
- wykres
- linia trendu
- wykładnicza linia trendu
- liniowa linia trendu
- logarytmiczna linia trendu
- średnia krocząca linia trendu
- wielomianowa linia trendu
- potęgowa linia trendu
- własna linia trendu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Szybko dodaj i dostosuj linie trendu w wykresach PowerPoint przy użyciu Aspose.Slides dla C++ — praktyczny przewodnik, który zaangażuje Twoją publiczność."
---
## **Przegląd**

W tym artykule wyjaśniono, jak dodać linie trendu do wykresów w prezentacji przy użyciu Aspose.Slides. Pokazano, jak utworzyć wykres, dodać linie trendu do serii wykresu oraz jak pracować z różnymi typami linii trendu, w tym wykładniczym, liniowym, logarytmicznym, średnią kroczącą, wielomianowym i potęgowym.

Opisano również, jak dodać własną linię do wykresu poprzez wstawienie kształtu linii, oraz zamieszczono krótkie FAQ dotyczące wartości projekcji linii trendu w przód i w tył oraz tego, czy linie trendu są zachowywane podczas eksportu do PDF lub SVG i przy renderowaniu wykresów jako obrazy.

## **Dodaj linię trendu**
Aspose.Slides dla C++ udostępnia prosty interfejs API do zarządzania różnymi liniami trendu wykresów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu po jego indeksie.
1. Dodaj wykres z domyślnymi danymi oraz wybranym typem (w przykładzie użyto ChartType.ClusteredColumn).
1. Dodaj wykładniczą linię trendu dla serii wykresu 1.
1. Dodaj liniową linię trendu dla serii wykresu 1.
1. Dodaj logarytmiczną linię trendu dla serii wykresu 2.
1. Dodaj średnią kroczącą jako linię trendu dla serii wykresu 2.
1. Dodaj wielomianową linię trendu dla serii wykresu 3.
1. Dodaj potęgową linię trendu dla serii wykresu 3.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Poniższy kod służy do utworzenia wykresu z liniami trendu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Dodaj własną linię**
Aspose.Slides dla C++ udostępnia prosty interfejs API do dodawania własnych linii w wykresie. Aby dodać prostą, jednolitą linię do wybranego slajdu prezentacji, wykonaj następujące kroki:

- Utwórz instancję klasy Presentation
- Uzyskaj odniesienie do slajdu przy użyciu jego indeksu
- Utwórz nowy wykres za pomocą metody AddChart udostępnionej przez obiekt Shapes
- Dodaj AutoShape typu Line za pomocą metody AddAutoShape udostępnionej przez obiekt Shapes
- Ustaw kolor linii kształtu.
- Zapisz zmodyfikowaną prezentację jako plik PPTX

Poniższy kod służy do utworzenia wykresu z własnymi liniami.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Co oznaczają terminy „forward” i „backward” w odniesieniu do linii trendu?**

Są to długości linii trendu projekowane w przód lub w tył: w wykresach rozrzutu (XY) – w jednostkach osi; w wykresach nie‑rozrzutu – w liczbie kategorii. Dozwolone są wyłącznie wartości nieujemne.

**Czy linia trendu zostanie zachowana podczas eksportu prezentacji do PDF lub SVG oraz przy renderowaniu slajdu jako obrazu?**

Tak. Aspose.Slides konwertuje prezentacje na [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/) oraz renderuje wykresy jako obrazy; linie trendu, jako część wykresu, są zachowywane w tych operacjach. Dostępna jest również metoda do [eksportu obrazu samego wykresu](/slides/pl/cpp/create-shape-thumbnails/).