---
title: Automatyzacja lokalizacji prezentacji w Javie
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/java/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- identyfikator języka
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Automatyzuj lokalizację slajdów PowerPoint i OpenDocument w Javie przy użyciu Aspose.Slides, wykorzystując praktyczne przykłady kodu i wskazówki dla szybszego wdrożenia na rynku globalnym."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak ustawić `LanguageId` dla tekstu w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak otworzyć prezentację, dodać kształt z tekstem, przypisać identyfikator języka do fragmentu tekstu oraz zapisać wynik jako plik PPTX.

## **Zmienianie języka tekstu w prezentacji i kształcie**
- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj do slajdu obiekt [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) typu [Rectangle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ShapeType#Rectangle).
- Dodaj tekst do TextFrame.
- [Ustawianie Language Id](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) dla tekstu.
- Zapisz prezentację jako plik PPTX.

Implementacja powyższych kroków jest pokazana poniżej w przykładzie.

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy identyfikator języka wywołuje automatyczne tłumaczenie tekstu?**

Nie. [Language ID](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) w Aspose.Slides przechowuje informacje o języku dla sprawdzania pisowni i korekty gramatycznej, ale nie tłumaczy ani nie zmienia treści tekstu. Jest to metadane, które PowerPoint rozumie w kontekście korekty.

**Czy identyfikator języka wpływa na dzielenie wyrazów i łamanie linii podczas renderowania?**

W Aspose.Slides, [language ID](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) służy do korekty. Jakość dzielenia wyrazów i zawijania linii zależy głównie od dostępności [odpowiednie czcionki](/slides/pl/java/powerpoint-fonts/) oraz ustawień układu/łamania linii dla danego systemu pisma. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [zasady podstawiania czcionek](/slides/pl/java/font-substitution/) i/lub [osadzenie czcionek](/slides/pl/java/embedded-font/) w prezentacji.

**Czy mogę ustawić różne języki w jednym akapicie?**

Tak. [Language ID](https://reference.aspose.com/slides/pl/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) jest stosowany na poziomie fragmentu tekstu, więc w jednym akapicie można mieszać wiele języków z odrębnymi ustawieniami korekty.