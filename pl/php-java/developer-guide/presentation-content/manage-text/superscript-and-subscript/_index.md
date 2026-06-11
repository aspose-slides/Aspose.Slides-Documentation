---
title: Zarządzanie superskryptem i subskryptem w prezentacjach przy użyciu PHP
linktitle: Superskrypt i subskrypt
type: docs
weight: 80
url: /pl/php-java/superscript-and-subscript/
keywords:
- superskrypt
- subskrypt
- dodaj superskrypt
- dodaj subskrypt
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Opanuj superskrypt i subskrypt w Aspose.Slides dla PHP poprzez Java i podnieś swoje prezentacje dzięki profesjonalnemu formatowaniu tekstu dla maksymalnego efektu."
---
## **Przegląd**

Aspose.Slides udostępnia funkcje integracji tekstu w superskrypcie i subskrypcie w prezentacjach PowerPoint (PPT, PPTX) oraz OpenDocument (ODP). Niezależnie od tego, czy musisz wyróżnić wzory chemiczne, równania matematyczne, czy dodać przypisy, te specjalistyczne opcje formatowania pomagają zachować przejrzystość i precyzję. W tym artykule dowiesz się, jak płynnie stosować style superskryptu i subskryptu oraz zapewnić profesjonalny efekt na każdym slajdzie.

## **Zarządzanie tekstem w superskrypcie i subskrypcie**
Możesz dodać tekst w superskrypcie i subskrypcie w dowolnej części akapitu. Aby dodać tekst w superskrypcie lub subskrypcie w ramce tekstowej Aspose.Slides, należy użyć metody [**setEscapement**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setEscapement) klasy [PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/PortionFormat).

Właściwość ta zwraca lub ustawia tekst w superskrypcie lub subskrypcie (wartość od -100 % (subskrypt) do 100 % (superskrypt)). Na przykład:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Pobierz referencję slajdu, używając jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) typu [Rectangle](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ShapeType#Rectangle) do slajdu.
- Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) powiązanego z [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/).
- Wyczyść istniejące akapity.
- Utwórz nowy obiekt akapitu przechowujący tekst w superskrypcie i dodaj go do kolekcji [IParagraphs](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/#getParagraphs) [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/).
- Utwórz nowy obiekt portion.
- Ustaw właściwość Escapement dla portion na wartość od 0 do 100, aby dodać superskrypt. (0 oznacza brak superskryptu)
- Ustaw tekst dla [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Portion) i dodaj go do kolekcji portionów akapitu.
- Utwórz nowy obiekt akapitu przechowujący tekst w subskrypcie i dodaj go do kolekcji IParagraphs ramki tekstowej.
- Utwórz nowy obiekt portion.
- Ustaw właściwość Escapement dla portion na wartość od 0 do -100, aby dodać subskrypt. (0 oznacza brak subskryptu)
- Ustaw tekst dla [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Portion) i dodaj go do kolekcji portionów akapitu.
- Zapisz prezentację jako plik PPTX.

Implementacja powyższych kroków jest przedstawiona poniżej.

```php
  # Utwórz instancję klasy Presentation reprezentującej plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz slajd
    $slide = $pres->getSlides()->get_Item(0);
    # Utwórz pole tekstowe
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # Utwórz akapit dla tekstu w superskrypcie
    $superPar = new Paragraph();
    # Utwórz część z zwykłym tekstem
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # Utwórz część z tekstem w superskrypcie
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # Utwórz akapit dla tekstu w subskrypcie
    $paragraph2 = new Paragraph();
    # Utwórz część z zwykłym tekstem
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # Utwórz część z tekstem w subskrypcie
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # Dodaj akapity do pola tekstowego
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy superskrypt i subskrypt są zachowywane przy eksporcie do PDF lub innych formatów?**

Tak, Aspose.Slides prawidłowo zachowuje formatowanie superskryptu i subskryptu podczas eksportu prezentacji do PDF, PPT/PPTX, obrazów oraz innych obsługiwanych formatów. Specjalistyczne formatowanie pozostaje nienaruszone we wszystkich plikach wyjściowych.

**Czy superskrypt i subskrypt można łączyć z innymi stylami formatowania, takimi jak pogrubienie czy kursywa?**

Tak, Aspose.Slides umożliwia mieszanie różnych stylów tekstu w jednej części tekstu. Możesz włączyć pogrubienie, kursywę, podkreślenie oraz jednocześnie zastosować superskrypt lub subskrypt, konfigurując odpowiednie właściwości w [PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/).

**Czy formatowanie superskryptu i subskryptu działa dla tekstu wewnątrz tabel, wykresów lub SmartArt?**

Tak, Aspose.Slides obsługuje formatowanie w większości obiektów, w tym w elementach tabel i wykresów. Pracując ze SmartArt, należy uzyskać dostęp do odpowiednich elementów (np. [SmartArtNode](https://reference.aspose.com/slides/pl/php-java/aspose.slides/smartartnode/)) i ich kontenerów tekstowych, a następnie skonfigurować właściwości [PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/) w podobny sposób.