---
title: Dodawanie elips do prezentacji w C++
linktitle: Elipsa
type: docs
weight: 30
url: /pl/cpp/ellipse/
keywords:
- elipsa
- kształt
- dodaj elipsę
- utwórz elipsę
- rysuj elipsę
- sformatowana elipsa
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, formatować i manipulować kształtami elips w Aspose.Slides dla C++ w prezentacjach PPT i PPTX — włączone przykłady kodu C++."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty elips do slajdów PowerPoint przy użyciu Aspose.Slides. Omówiono tworzenie prostej elipsy, tworzenie elipsy sformatowanej oraz zapisywanie zaktualizowanej prezentacji jako plik PPTX. Poruszono także powiązane kwestie, takie jak pozycjonowanie i rozmiar elipsy, kontrolowanie kolejności warstw oraz stosowanie efektów animacji.

## **Utworzenie elipsy**
W tym temacie przedstawimy programistom, jak dodawać kształty elips do ich slajdów przy użyciu Aspose.Slides for C++. Aspose.Slides for C++ udostępnia prostszy zestaw interfejsów API do rysowania różnych rodzajów kształtów w kilku linijkach kodu. Aby dodać prostą elipsę do wybranego slajdu prezentacji, wykonaj poniższe kroki:

1. Utwórz instancję [Presentation class](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/)
1. Pobierz referencję do slajdu, używając jego indeksu
1. Dodaj AutoShape typu Ellipse przy użyciu metody AddAutoShape udostępnionej przez obiekt IShapes
1. Zapisz zmodyfikowaną prezentację jako plik PPTX

W poniższym przykładzie dodaliśmy elipsę do pierwszego slajdu.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Utworzenie sformatowanej elipsy**
Aby dodać lepiej sformatowaną elipsę do slajdu, wykonaj następujące kroki:

1. Utwórz instancję [Presentation class](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
1. Pobierz referencję do slajdu, używając jego indeksu.
1. Dodaj AutoShape typu Ellipse przy użyciu metody AddAutoShape udostępnionej przez obiekt IShapes.
1. Ustaw typ wypełnienia elipsy na Solid.
1. Ustaw kolor elipsy, korzystając z właściwości SolidFillColor.Color udostępnionej przez obiekt FillFormat skojarzony z obiektem IShape.
1. Ustaw kolor linii elipsy.
1. Ustaw szerokość linii elipsy.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy sformatowaną elipsę do pierwszego slajdu prezentacji.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**Jak ustawić dokładną pozycję i rozmiar elipsy względem jednostek slajdu?**

Współrzędne i rozmiary są zazwyczaj podawane **w punktach**. Aby uzyskać przewidywalne wyniki, opieraj obliczenia na rozmiarze slajdu i przed przypisaniem wartości przelicz wymagane milimetry lub cale na punkty.

**Jak umieścić elipsę nad lub pod innymi obiektami (kontrola kolejności warstw)?**

Dostosuj kolejność rysowania obiektu, przenosząc go na wierzch lub wysyłając na spód. Dzięki temu elipsa może nakładać się na inne obiekty lub odsłaniać te znajdujące się pod nią.

**Jak animować pojawienie się lub podkreślenie elipsy?**

[Apply](/slides/pl/cpp/shape-animation/) efekty wejścia, podkreślenia lub wyjścia do kształtu oraz skonfiguruj wyzwalacze i czas, aby określić, kiedy i jak animacja ma się odtwarzać.