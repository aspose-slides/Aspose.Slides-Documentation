---
title: Zarządzaj indeksem górnym i dolnym w prezentacjach przy użyciu JavaScript
linktitle: Indeks górny i dolny
type: docs
weight: 80
url: /pl/nodejs-java/superscript-and-subscript/
keywords:
- indeks górny
- indeks dolny
- dodaj indeks górny
- dodaj indeks dolny
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Opanuj indeksy górny i dolny w Aspose.Slides dla Node.js poprzez Java i podnieś swoje prezentacje dzięki profesjonalnemu formatowaniu tekstu dla maksymalnego efektu."
---
## **Przegląd**

Aspose.Slides zapewnia funkcje integracji tekstu w indeksie górnym i dolnym w prezentacjach PowerPoint (PPT, PPTX) oraz OpenDocument (ODP). Niezależnie od tego, czy musisz podkreślić wzory chemiczne, równania matematyczne, czy dodać przypisy, te specjalistyczne opcje formatowania pomagają zachować czytelność i precyzję. W tym artykule dowiesz się, jak płynnie stosować style indeksu górnego i dolnego oraz zapewnić profesjonalny wygląd na każdym slajdzie.

## **Zarządzanie tekstem w indeksie górnym i dolnym**

Można dodać tekst w indeksie górnym i dolnym w dowolnej części akapitu. Aby dodać tekst w indeksie górnym lub dolnym w ramce tekstowej Aspose.Slides, należy użyć metody [**setEscapement**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) klasy [PortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PortionFormat).

Ta właściwość zwraca lub ustawia tekst w indeksie górnym lub dolnym (wartość od -100 % (indeks dolny) do 100 % (indeks górny)). Na przykład:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
- Uzyskaj odniesienie do slajdu, używając jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) typu [Rectangle](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeType#Rectangle) do slajdu.
- Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame) powiązanego z [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape).
- Wyczyść istniejące akapity.
- Utwórz nowy obiekt akapitu przechowujący tekst w indeksie górnym i dodaj go do [Paragraphs collection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame#getParagraphs--) obiektu [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame).
- Utwórz nowy obiekt części tekstu.
- Ustaw właściwość Escapement dla części w zakresie od 0 do 100, aby dodać indeks górny (0 oznacza brak indeksu górnego).
- Ustaw tekst dla [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Portion) i dodaj go do kolekcji części w akapicie.
- Utwórz nowy obiekt akapitu przechowujący tekst w indeksie dolnym i dodaj go do kolekcji IParagraphs obiektu ITextFrame.
- Utwórz nowy obiekt części tekstu.
- Ustaw właściwość Escapement dla części w zakresie od 0 do -100, aby dodać indeks dolny (0 oznacza brak indeksu dolnego).
- Ustaw tekst dla [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Portion) i dodaj go do kolekcji części w akapicie.
- Zapisz prezentację jako plik PPTX.

Implementacja powyższych kroków przedstawiona jest poniżej.

```javascript
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz slajd
    var slide = pres.getSlides().get_Item(0);
    // Utwórz pole tekstowe
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // Utwórz akapit dla tekstu w indeksie górnym
    var superPar = new aspose.slides.Paragraph();
    // Utwórz część tekstu z normalnym tekstem
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // Utwórz część tekstu w indeksie górnym
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // Utwórz akapit dla tekstu w indeksie dolnym
    var paragraph2 = new aspose.slides.Paragraph();
    // Utwórz część tekstu z normalnym tekstem
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // Utwórz część tekstu w indeksie dolnym
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // Dodaj akapity do pola tekstowego
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy indeks górny i dolny zostaną zachowane podczas eksportu do PDF lub innych formatów?**

Tak, Aspose.Slides poprawnie zachowuje formatowanie indeksu górnego i dolnego podczas eksportu prezentacji do PDF, PPT/PPTX, obrazów i innych obsługiwanych formatów. Specjalistyczne formatowanie pozostaje nienaruszone we wszystkich plikach wyjściowych.

**Czy indeks górny i dolny można łączyć z innymi stylami formatowania, takimi jak pogrubienie lub kursywa?**

Tak, Aspose.Slides pozwala łączyć różne style tekstu w jednej części tekstu. Możesz włączyć pogrubienie, kursywę, podkreślenie oraz jednocześnie zastosować indeks górny lub dolny, konfigurując odpowiednie właściwości w [PortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/).

**Czy formatowanie indeksu górnego i dolnego działa dla tekstu wewnątrz tabel, wykresów lub SmartArt?**

Tak, Aspose.Slides obsługuje formatowanie w większości obiektów, w tym w tabelach i elementach wykresów. Przy pracy ze SmartArt należy uzyskać dostęp do odpowiednich elementów (takich jak [SmartArtNode](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartartnode/)) oraz ich kontenerów tekstowych, a następnie skonfigurować właściwości [PortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/) w podobny sposób.