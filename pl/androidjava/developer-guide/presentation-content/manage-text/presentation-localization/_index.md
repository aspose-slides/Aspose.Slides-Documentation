---
title: Automatyzacja lokalizacji prezentacji na Androidzie
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/androidjava/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- identyfikator języka
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Automatyzuj lokalizację slajdów PowerPoint i OpenDocument w Javie przy użyciu Aspose.Slides dla Androida, korzystając z praktycznych przykładów kodu i wskazówek przyspieszających globalne wdrożenie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak ustawić `LanguageId` dla tekstu w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak otworzyć prezentację, dodać kształt z tekstem, przypisać identyfikator języka do fragmentu tekstu oraz zapisać wynik jako plik PPTX.

## **Zmienianie języka w prezentacji i tekście kształtu**
- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Uzyskaj odniesienie do slajdu, korzystając z jego indeksu.
- Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IAutoShape) typu [Rectangle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ShapeType#Rectangle) do slajdu.
- Dodaj trochę tekstu do TextFrame.
- [Ustawianie Language Id](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) dla tekstu.
- Zapisz prezentację jako plik PPTX.

Implementacja powyższych kroków została przedstawiona poniżej w przykładzie.

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

Nie. [Language ID](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) w Aspose.Slides przechowuje język dla sprawdzania pisowni i korekty gramatycznej, ale nie tłumaczy ani nie zmienia treści tekstu. Jest to metadane, które PowerPoint rozumie w kontekście korekty.

**Czy identyfikator języka wpływa na dzielenie wyrazów i podziały wierszy podczas renderowania?**

W Aspose.Slides, [language ID](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) służy do korekty. Jakość dzielenia wyrazów i zawijania linii zależy głównie od dostępności [odpowiednich czcionek](/slides/pl/androidjava/powerpoint-fonts/) oraz ustawień układu/podziału linii dla systemu pisania. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [zasady podstawiania czcionek](/slides/pl/androidjava/font-substitution/) i/lub [osadź czcionki](/slides/pl/androidjava/embedded-font/) w prezentacji.

**Czy mogę ustawić różne języki w jednym paragrafie?**

Tak. [Language ID](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) jest stosowany na poziomie fragmentu tekstu, więc pojedynczy akapit może zawierać wiele języków z odrębnymi ustawieniami korekty.