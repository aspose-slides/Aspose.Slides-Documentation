---
title: Automatyzacja lokalizacji prezentacji w JavaScript
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/nodejs-java/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- identyfikator języka
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatyzuj lokalizację slajdów PowerPoint i OpenDocument w JavaScript przy użyciu Aspose.Slides, korzystając z praktycznych przykładów kodu i wskazówek dla szybszego wdrożenia globalnego."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak ustawić `LanguageId` dla tekstu w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak otworzyć prezentację, dodać kształt z tekstem, przypisać identyfikator języka do fragmentu tekstu oraz zapisać wynik jako plik PPTX.

## **Zmień język prezentacji i tekstu kształtu**

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
- Uzyskaj odwołanie do slajdu, używając jego indeksu.
- Dodaj do slajdu [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) typu [Rectangle](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeType#Rectangle).
- Dodaj tekst do TextFrame.
- [Ustawianie Language Id](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-) dla tekstu.
- Zapisz prezentację jako plik PPTX.

Implementację powyższych kroków przedstawiono poniżej w przykładzie.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy identyfikator języka wywołuje automatyczne tłumaczenie tekstu?**

Nie. [setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) w Aspose.Slides przechowuje informacje o języku dla sprawdzania pisowni i poprawności gramatycznej, ale nie tłumaczy ani nie zmienia treści tekstu. Są to metadane, które PowerPoint rozumie w kontekście korekty.

**Czy identyfikator języka wpływa na dzielenie wyrazów i podziały wierszy podczas renderowania?**

W Aspose.Slides [setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) służy do korekty. Jakość dzielenia wyrazów i zawijania linii zależy głównie od dostępności [odpowiednich czcionek](/slides/pl/nodejs-java/powerpoint-fonts/) oraz ustawień układu/podziału wierszy dla systemu pisma. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [reguły podstawiania czcionek](/slides/pl/nodejs-java/font-substitution/) i/lub [osadź czcionki](/slides/pl/nodejs-java/embedded-font/) w prezentacji.

**Czy mogę ustawić różne języki w jednym akapicie?**

Tak. [setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) jest stosowany na poziomie fragmentu tekstu, więc pojedynczy akapit może zawierać wiele języków z odrębnymi ustawieniami korekty.