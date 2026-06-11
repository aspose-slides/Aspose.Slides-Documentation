---
title: Automatyzacja lokalizacji prezentacji przy użyciu Pythona
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/python-net/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- identyfikator języka
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Automatyzuj lokalizację slajdów PowerPoint i OpenDocument w Pythonie przy użyciu Aspose.Slides, korzystając z praktycznych przykładów kodu i wskazówek przyspieszających globalne wdrożenie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak ustawić `language_id` dla tekstu w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak otworzyć prezentację, dodać kształt z tekstem, przypisać identyfikator języka do fragmentu tekstu oraz zapisać wynik jako plik PPTX.

## **Zmienianie języka dla prezentacji i tekstu kształtu**
- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Prostokąt do slajdu.
- Dodaj tekst do TextFrame.
- Ustawienie Language Id dla tekstu.
- Zapisz prezentację jako plik PPTX.

Implementacja powyższych kroków jest przedstawiona poniżej w przykładzie.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy identyfikator języka wywołuje automatyczne tłumaczenie tekstu?**

Nie. [language_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/language_id/) w Aspose.Slides przechowuje język używany do sprawdzania pisowni i gramatyki, ale nie tłumaczy ani nie zmienia treści tekstu. Są to metadane, które PowerPoint rozumie w kontekście sprawdzania.

**Czy identyfikator języka wpływa na dzielenie wyrazów i podziały linii podczas renderowania?**

W Aspose.Slides, [language_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/language_id/) służy do sprawdzania. Jakość dzielenia wyrazów i zawijania linii zależy głównie od dostępności [odpowiednich czcionek](/slides/pl/python-net/powerpoint-fonts/) oraz ustawień układu/podziału linii dla systemu pisma. Aby zapewnić poprawne renderowanie, udostępnij wymagane czcionki, skonfiguruj [reguły podstawiania czcionek](/slides/pl/python-net/font-substitution/) i/lub [osadź czcionki](/slides/pl/python-net/embedded-font/) w prezentacji.

**Czy mogę ustawić różne języki w jednym akapicie?**

Tak. [language_id](https://reference.aspose.com/slides/pl/python-net/aspose.slides/portionformat/language_id/) jest stosowany na poziomie fragmentu tekstu, więc w jednym akapicie można mieszać wiele języków z różnymi ustawieniami sprawdzania.