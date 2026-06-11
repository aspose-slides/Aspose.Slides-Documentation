---
title: Zarządzanie indeksem górnym i dolnym w prezentacjach przy użyciu C++
linktitle: Indeks górny i dolny
type: docs
weight: 80
url: /pl/cpp/superscript-and-subscript/
keywords:
- indeks górny
- indeks dolny
- dodaj indeks górny
- dodaj indeks dolny
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Opanuj indeksy górny i dolny w Aspose.Slides dla C++ i podnieś jakość swoich prezentacji dzięki profesjonalnemu formatowaniu tekstu dla maksymalnego efektu."
---
## **Przegląd**

Aspose.Slides oferuje funkcje umożliwiające wstawianie tekstu w indeksie górnym i dolnym do prezentacji PowerPoint (PPT, PPTX) oraz OpenDocument (ODP). Niezależnie od tego, czy musisz wyróżnić wzory chemiczne, równania matematyczne, czy dodać przypisy, te specjalistyczne opcje formatowania pomagają zachować czytelność i precyzję. W tym artykule dowiesz się, jak płynnie stosować style indeksu górnego i dolnego oraz zapewnić profesjonalny wygląd na każdym slajdzie.

## **Zarządzanie tekstem w indeksie górnym i dolnym**

Możesz dodać tekst w indeksie górnym i dolnym w dowolnym fragmencie akapitu. Aby dodać tekst w indeksie górnym lub dolnym w ramce tekstowej Aspose.Slides, należy użyć właściwości **Escapement** klasy PortionFormat.

Ta właściwość zwraca lub ustawia tekst w indeksie górnym lub dolnym (wartość od -100 % (indeks dolny) do 100 % (indeks górny)). Na przykład:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
- Pobierz referencję do slajdu używając jego indeksu.
- Dodaj IAutoShape typu Rectangle do slajdu.
- Uzyskaj dostęp do ITextFrame powiązanego z IAutoShape.
- Wyczyść istniejące akapity.
- Utwórz nowy obiekt paragraph służący do przechowywania tekstu w indeksie górnym i dodaj go do kolekcji IParagraphs ITextFrame.
- Utwórz nowy obiekt portion.
- Ustaw właściwość Escapement dla portion na wartość od 0 do 100, aby dodać indeks górny. (0 oznacza brak indeksu górnego)
- Ustaw tekst dla Portion i dodaj go do kolekcji portionów akapitu.
- Utwórz nowy obiekt paragraph służący do przechowywania tekstu w indeksie dolnym i dodaj go do kolekcji IParagraphs ITextFrame.
- Utwórz nowy obiekt portion.
- Ustaw właściwość Escapement dla portion na wartość od 0 do -100, aby dodać indeks dolny. (0 oznacza brak indeksu dolnego)
- Ustaw tekst dla Portion i dodaj go do kolekcji portionów akapitu.
- Zapisz prezentację jako plik PPTX.

Implementacja powyższych kroków jest przedstawiona poniżej.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **FAQ**

**Czy indeksy górny i dolny zostaną zachowane przy eksporcie do PDF lub innych formatów?**

Tak, Aspose.Slides prawidłowo zachowuje formatowanie indeksu górnego i dolnego podczas eksportu prezentacji do PDF, PPT/PPTX, obrazów i innych obsługiwanych formatów. Specjalistyczne formatowanie pozostaje nienaruszone we wszystkich plikach wyjściowych.

**Czy indeksy górny i dolny można łączyć z innymi stylami formatowania, takimi jak pogrubienie lub kursywa?**

Tak, Aspose.Slides pozwala na mieszanie różnych stylów tekstu w ramach jednego portion. Możesz włączyć pogrubienie, kursywę, podkreślenie oraz jednocześnie zastosować indeks górny lub dolny, konfigurując odpowiednie właściwości w [PortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/portionformat/).

**Czy formatowanie indeksu górnego i dolnego działa dla tekstu w tabelach, wykresach lub SmartArt?**

Tak, Aspose.Slides obsługuje formatowanie w większości obiektów, w tym w elementach tabel i wykresów. Pracując z SmartArt, musisz uzyskać dostęp do odpowiednich elementów (takich jak [SmartArtNode](https://reference.aspose.com/slides/pl/cpp/aspose.slides.smartart/smartartnode/)) i ich kontenerów tekstowych, a następnie skonfigurować właściwości [PortionFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/portionformat/) w podobny sposób.