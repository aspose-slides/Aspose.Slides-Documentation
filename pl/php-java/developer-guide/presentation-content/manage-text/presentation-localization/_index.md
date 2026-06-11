---
title: Automatyzacja lokalizacji prezentacji w PHP
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/php-java/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- identyfikator języka
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Automatyzuj lokalizację slajdów PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP poprzez Java, korzystając z praktycznych przykładów kodu i wskazówek przyspieszających globalne wdrożenie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak ustawić `LanguageId` dla tekstu w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak otworzyć prezentację, dodać kształt z tekstem, przypisać identyfikator języka do fragmentu tekstu i zapisać wynik jako plik PPTX.

## **Zmienianie języka w prezentacji i tekście kształtu**
- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
- Uzyskaj odniesienie do slajdu, używając jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) typu [Rectangle](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ShapeType#Rectangle) na slajdzie.
- Dodaj trochę tekstu do obiektu TextFrame.
- Ustaw identyfikator języka w tekście za pomocą [Set Language Id](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId).
- Zapisz prezentację jako plik PPTX.

Implementację powyższych kroków przedstawiono poniżej w przykładzie.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy identyfikator języka uruchamia automatyczne tłumaczenie tekstu?**

Nie. [Language ID](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId) w Aspose.Slides przechowuje język do sprawdzania pisowni i korekty gramatycznej, ale nie tłumaczy ani nie zmienia treści tekstu. Jest to metadane, które PowerPoint rozumie w kontekście korekty.

**Czy identyfikator języka wpływa na dzielenie wyrazów i złamania linii podczas renderowania?**

W Aspose.Slides, [language ID](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId) służy do korekty. Jakość dzielenia wyrazów i zawijania linii zależy przede wszystkim od dostępności [odpowiednich czcionek](/slides/pl/php-java/powerpoint-fonts/) oraz ustawień układu i podziału linii dla systemu pisma. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [reguły podstawiania czcionek](/slides/pl/php-java/font-substitution/) i/lub [osadź czcionki](/slides/pl/php-java/embedded-font/) w prezentacji.

**Czy mogę ustawić różne języki w jednym paragrafie?**

Tak. [Language ID](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId) jest stosowany na poziomie fragmentu tekstu, więc pojedynczy paragraf może zawierać wiele języków z odrębnymi ustawieniami korekty.