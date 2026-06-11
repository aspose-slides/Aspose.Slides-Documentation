---
title: Zarządzanie indeksem górnym i dolnym w prezentacjach przy użyciu Java
linktitle: Indeks górny i dolny
type: docs
weight: 80
url: /pl/java/superscript-and-subscript/
keywords:
- indeks górny
- indeks dolny
- dodaj indeks górny
- dodaj indeks dolny
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Opanuj indeks górny i dolny w Aspose.Slides dla Java i podnieś swoje prezentacje dzięki profesjonalnemu formatowaniu tekstu dla maksymalnego efektu."
---
## **Przegląd**

Aspose.Slides udostępnia funkcje umożliwiające wstawianie tekstu w indeksie górnym i dolnym do prezentacji PowerPoint (PPT, PPTX) oraz OpenDocument (ODP). Niezależnie od tego, czy musisz wyróżnić wzory chemiczne, równania matematyczne, czy dodać przypisy, te specjalistyczne opcje formatowania pomagają zachować czytelność i precyzję. W tym artykule dowiesz się, jak płynnie stosować style indeksu górnego i dolnego oraz zapewnić profesjonalny wygląd na każdym slajdzie.

## **Zarządzanie tekstem w indeksie górnym i dolnym**
Możesz dodać tekst w indeksie górnym i dolnym wewnątrz dowolnej części akapitu. Aby dodać tekst w indeksie górnym lub dolnym w ramce tekstowej Aspose.Slides, należy użyć metody [**setEscapement**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IBasePortionFormat#setEscapement-float-) klasy [PortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PortionFormat).

Ta właściwość zwraca lub ustawia tekst w indeksie górnym lub dolnym (wartość od -100% (indeks dolny) do 100% (indeks górny)). Na przykład:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
- Uzyskaj odwołanie do slajdu, używając jego indeksu.
- Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) typu [Rectangle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ShapeType#Rectangle) do slajdu.
- Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrame) powiązanego z [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape).
- Wyczyść istniejące akapity
- Utwórz nowy obiekt akapitu przechowujący tekst w indeksie górnym i dodaj go do kolekcji [IParagraphs collection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrame#getParagraphs--) [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrame).
- Utwórz nowy obiekt Portion
- Ustaw właściwość Escapement dla Portion na wartość od 0 do 100, aby dodać indeks górny. (0 oznacza brak indeksu górnego)
- Ustaw tekst dla [Portion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Portion) i dodaj go do kolekcji portion w akapicie.
- Utwórz nowy obiekt akapitu przechowujący tekst w indeksie dolnym i dodaj go do kolekcji IParagraphs w ITextFrame.
- Utwórz nowy obiekt Portion
- Ustaw właściwość Escapement dla Portion na wartość od 0 do -100, aby dodać indeks dolny. (0 oznacza brak indeksu dolnego)
- Ustaw tekst dla [Portion](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Portion) i dodaj go do kolekcji portion w akapicie.
- Zapisz prezentację jako plik PPTX.

Implementację powyższych kroków podano poniżej.

```java
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz slajd
    ISlide slide = pres.getSlides().get_Item(0);

    // Utwórz pole tekstowe
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // Utwórz akapit dla tekstu w indeksie górnym
    IParagraph superPar = new Paragraph();

    // Utwórz fragment z zwykłym tekstem
    IPortion portion1 = new Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);

    // Utwórz fragment z tekstem w indeksie górnym
    IPortion superPortion = new Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);

    // Utwórz akapit dla tekstu w indeksie dolnym
    IParagraph paragraph2 = new Paragraph();

    // Utwórz fragment z zwykłym tekstem
    IPortion portion2 = new Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);

    // Utwórz fragment z tekstem w indeksie dolnym
    IPortion subPortion = new Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);

    // Dodaj akapity do pola tekstowego
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);

    pres.save("formatText.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy indeks górny i dolny zostaną zachowane przy eksporcie do PDF lub innych formatów?**

Tak, Aspose.Slides prawidłowo zachowuje formatowanie indeksu górnego i dolnego podczas eksportu prezentacji do PDF, PPT/PPTX, obrazów oraz innych obsługiwanych formatów. Specjalistyczne formatowanie pozostaje niezmienione we wszystkich plikach wyjściowych.

**Czy indeks górny i dolny można łączyć z innymi stylami formatowania, takimi jak pogrubienie lub kursywa?**

Tak, Aspose.Slides pozwala mieszać różne style tekstu w ramach jednej części tekstu. Możesz włączyć pogrubienie, kursywę, podkreślenie i jednocześnie zastosować indeks górny lub dolny, konfigurując odpowiednie właściwości w [PortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/portionformat/).

**Czy formatowanie indeksu górnego i dolnego działa dla tekstu wewnątrz tabel, wykresów lub SmartArt?**

Tak, Aspose.Slides obsługuje formatowanie w większości obiektów, w tym w tabelach i elementach wykresów. Pracując z SmartArt, należy uzyskać dostęp do odpowiednich elementów (takich jak [SmartArtNode](https://reference.aspose.com/slides/pl/java/com.aspose.slides/smartartnode/)) oraz ich kontenerów tekstu, a następnie skonfigurować właściwości [PortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/portionformat/) w podobny sposób.