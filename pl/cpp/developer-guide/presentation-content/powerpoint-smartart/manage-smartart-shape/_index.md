---
title: Zarządzanie grafikami SmartArt w prezentacjach przy użyciu C++
linktitle: Grafiki SmartArt
type: docs
weight: 20
url: /pl/cpp/manage-smartart-shape/
keywords:
- obiekt SmartArt
- grafika SmartArt
- styl SmartArt
- kolor SmartArt
- tworzenie SmartArt
- dodawanie SmartArt
- edytowanie SmartArt
- zmiana SmartArt
- dostęp do SmartArt
- typ układu SmartArt
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Automatyzuj tworzenie, edycję i stylizację SmartArt w PowerPoint przy użyciu C++ i Aspose.Slides, oferując zwięzłe przykłady kodu oraz wskazówki skoncentrowane na wydajności."
---
## **Przegląd**

Aspose.Slides umożliwia programowe tworzenie i zarządzanie grafikami SmartArt w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak dodać kształt SmartArt do slajdu, uzyskać dostęp do istniejących kształtów SmartArt, znaleźć SmartArt o określonym typie układu oraz zaktualizować jego wygląd poprzez zmianę stylu SmartArt lub stylu kolorów.

Przykłady pokazują, jak pracować z kształtami SmartArt poprzez kolekcję kształtów slajdu prezentacji, sprawdzić, czy kształt jest SmartArt, a następnie modyfikować lub przeglądać jego właściwości.

## **Utworzenie kształtu SmartArt**
Aspose.Slides for C++ umożliwia teraz dodawanie własnych kształtów SmartArt do slajdów od podstaw. Aspose.Slides for C++ udostępnia najprostsze API do tworzenia kształtów SmartArt w najłatwiejszy sposób. Aby utworzyć kształt SmartArt na slajdzie, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
- Pobierz referencję do slajdu, używając jego indeksu.
- Dodaj kształt SmartArt, ustawiając właściwość LayoutType.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **Uzyskanie dostępu do kształtu SmartArt na slajdzie**
Poniższy kod służy do uzyskania dostępu do kształtów SmartArt dodanych do slajdu prezentacji. W przykładowym kodzie przechodzimy przez każdy kształt znajdujący się na slajdzie i sprawdzamy, czy jest to kształt SmartArt. Jeśli kształt jest typu SmartArt, rzutujemy go na instancję SmartArt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **Uzyskanie dostępu do kształtu SmartArt o określonym typie układu**
Poniższy przykładowy kod pomoże uzyskać dostęp do kształtu SmartArt o określonym LayoutType. Należy pamiętać, że nie można zmienić LayoutType SmartArt, ponieważ jest on tylko do odczytu i ustawia się go jedynie w momencie dodania kształtu SmartArt.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację zawierającą kształt SmartArt.
- Pobierz referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź przez każdy kształt znajdujący się w pierwszym slajdzie.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.
- Znajdź kształt SmartArt o określonym LayoutType i wykonaj wymagane działania.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **Zmiana stylu kształtu SmartArt**
Poniższy przykładowy kod pomoże uzyskać dostęp do kształtu SmartArt o określonym LayoutType.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację zawierającą kształt SmartArt.
- Pobierz referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź przez każdy kształt znajdujący się w pierwszym slajdzie.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.
- Znajdź kształt SmartArt o określonym stylu.
- Ustaw nowy styl dla kształtu SmartArt.
- Zapisz prezentację.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **Zmiana stylu kolorów kształtu SmartArt**
W tym przykładzie nauczymy się zmieniać styl kolorów dowolnego kształtu SmartArt. W poniższym przykładowym kodzie uzyskamy dostęp do kształtu SmartArt o określonym stylu kolorów i zmienimy go.

- Utwórz instancję klasy `Presentation` i wczytaj prezentację zawierającą kształt SmartArt.
- Pobierz referencję do pierwszego slajdu, używając jego indeksu.
- Przejdź przez każdy kształt znajdujący się w pierwszym slajdzie.
- Sprawdź, czy kształt jest typu SmartArt i rzutuj wybrany kształt na SmartArt, jeśli tak jest.
- Znajdź kształt SmartArt o określonym stylu kolorów.
- Ustaw nowy styl kolorów dla kształtu SmartArt.
- Zapisz prezentację.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **FAQ**

**Czy mogę animować SmartArt jako pojedynczy obiekt?**

Tak. SmartArt jest kształtem, więc możesz zastosować [standardowe animacje](/slides/pl/cpp/powerpoint-animation/) za pomocą API animacji (wejście, wyjście, podkreślenie, ścieżki ruchu) tak jak w przypadku innych kształtów.

**Jak mogę znaleźć konkretny SmartArt na slajdzie, jeśli nie znam jego wewnętrznego identyfikatora?**

Ustaw i użyj tekstu alternatywnego (AltText) oraz wyszukaj kształt po tej wartości — jest to zalecany sposób lokalizacji docelowego kształtu.

**Czy mogę grupować SmartArt z innymi kształtami?**

Tak. Możesz grupować SmartArt z innymi kształtami (obrazami, tabelami itp.), a następnie [manipulować grupą](/slides/pl/cpp/group/).

**Jak uzyskać obraz konkretnego SmartArt (np. do podglądu lub raportu)?**

Wyeksportuj miniaturkę/obraz kształtu; biblioteka może [renderować poszczególne kształty](/slides/pl/cpp/create-shape-thumbnails/) do plików rastrowych (PNG/JPG/TIFF).

**Czy wygląd SmartArt zostanie zachowany przy konwertowaniu całej prezentacji do PDF?**

Tak. Silnik renderujący zapewnia wysoką wierność przy [eksport PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), z szerokim zakresem opcji jakości i kompatybilności.