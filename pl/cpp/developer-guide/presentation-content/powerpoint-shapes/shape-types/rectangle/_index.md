---
title: Dodawanie prostokątów do prezentacji w C++
linktitle: Prostokąt
type: docs
weight: 80
url: /pl/cpp/rectangle/
keywords:
- dodaj prostokąt
- utwórz prostokąt
- kształt prostokąta
- prosty prostokąt
- sformatowany prostokąt
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Ulepsz swoje prezentacje PowerPoint, dodając prostokąty przy użyciu Aspose.Slides dla C++ — łatwo projektuj i modyfikuj kształty programowo."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty prostokątów do slajdów PowerPoint za pomocą Aspose.Slides. Obejmuje tworzenie prostego prostokąta, tworzenie sformatowanego prostokąta oraz zapis zaktualizowanej prezentacji jako plik PPTX.

## **Utworzenie prostego prostokąta**
Podobnie jak w poprzednich tematach, ten również dotyczy dodawania kształtu, a tym razem omawiamy prostokąt. W tym temacie opisaliśmy, jak programiści mogą dodawać proste lub sformatowane prostokąty do swoich slajdów przy użyciu Aspose.Slides dla C++. Aby dodać prosty prostokąt do wybranego slajdu prezentacji, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję [klasy Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj obiekt IAutoShape typu Rectangle, używając metody AddAutoShape udostępnionej przez obiekt IShapes.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy prosty prostokąt do pierwszego slajdu prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Utworzenie sformatowanego prostokąta**
Aby dodać sformatowany prostokąt do slajdu, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję [klasy Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu, używając jego indeksu.
1. Dodaj obiekt IAutoShape typu Rectangle, używając metody AddAutoShape udostępnionej przez obiekt IShapes.
1. Ustaw typ wypełnienia prostokąta na Solid.
1. Ustaw kolor prostokąta, używając właściwości SolidFillColor.Color udostępnionej przez obiekt FillFormat powiązany z obiektem IShape.
1. Ustaw kolor linii prostokąta.
1. Ustaw szerokość linii prostokąta.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Powyższe kroki zostały zaimplementowane w poniższym przykładzie.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**Jak dodać prostokąt z zaokrąglonymi rogami?**

Użyj [typ kształtu]([shape type](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shapetype/)) rounded‑corner i dostosuj promień rogu w właściwościach kształtu; zaokrąglenie można również zastosować osobno dla każdego rogu za pomocą modyfikacji geometrii.

**Jak wypełnić prostokąt obrazem (teksturą)?**

Wybierz [typ wypełnienia](https://reference.aspose.com/slides/pl/cpp/aspose.slides/filltype/) obrazu, podaj źródło obrazu i skonfiguruj [tryby rozciągania/układania](https://reference.aspose.com/slides/pl/cpp/aspose.slides/picturefillmode/).

**Czy prostokąt może mieć cień i poświatę?**

Tak. [Cienie zewnętrzne/wewnętrzne, poświata i miękkie krawędzie](/slides/pl/cpp/shape-effect/) są dostępne z regulowanymi parametrami.

**Czy mogę zamienić prostokąt w przycisk z hiperłączem?**

Tak. [Przypisz hiperłącze](/slides/pl/cpp/manage-hyperlinks/) do kliknięcia kształtu (przejście do slajdu, pliku, adresu internetowego lub e‑maila).

**Jak mogę zabezpieczyć prostokąt przed przemieszczaniem i zmianami?**

[Użyj blokad kształtu](/slides/pl/cpp/applying-protection-to-presentation/): możesz zabronić przemieszczania, zmiany rozmiaru, zaznaczania lub edycji tekstu, aby zachować układ.

**Czy mogę konwertować prostokąt na obraz rastrowy lub SVG?**

Tak. Możesz [renderować kształt](http://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/) do obrazu o określonym rozmiarze/skali lub [wyeksportować go jako SVG](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/writeassvg/) do użytku wektorowego.

**Jak szybko uzyskać rzeczywiste (efektywne) właściwości prostokąta uwzględniając motyw i dziedziczenie?**

[Użyj efektywnych właściwości kształtu](/slides/pl/cpp/shape-effective-properties/): API zwraca obliczone wartości uwzględniające style motywu, układ i ustawienia lokalne, upraszczając analizę formatowania.