---
title: Automatyzacja lokalizacji prezentacji w C++
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/cpp/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- identyfikator języka
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Automatyzuj lokalizację slajdów PowerPoint i OpenDocument w C++ przy użyciu Aspose.Slides, korzystając z praktycznych przykładów kodu i wskazówek przyspieszających globalne wdrożenie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak ustawić `LanguageId` dla tekstu w prezentacji przy użyciu Aspose.Slides. Pokazuje, jak otworzyć prezentację, dodać kształt z tekstem, przypisać identyfikator języka do fragmentu tekstu oraz zapisać wynik jako plik PPTX.

## **Zmienianie języka dla prezentacji i tekstu w kształcie**
- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu prostokąt do slajdu.
- Dodaj trochę tekstu do TextFrame.
- Ustawienie Language Id dla tekstu.
- Zapisz prezentację jako plik PPTX.

Implementacja powyższych kroków jest przedstawiona poniżej w przykładzie.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**Czy identyfikator języka uruchamia automatyczne tłumaczenie tekstu?**

Nie. [Language ID](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_languageid/) w Aspose.Slides przechowuje język dla sprawdzania pisowni i korekty gramatycznej, ale nie tłumaczy ani nie zmienia treści tekstu. Jest to metadane, które PowerPoint rozumie w kontekście korekty.

**Czy identyfikator języka wpływa na dzielenie wyrazów i wstawianie łamania wierszy podczas renderowania?**

W Aspose.Slides [Language ID](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_languageid/) służy do korekty. Jakość dzielenia wyrazów i zawijania linii zależy głównie od dostępności [odpowiednich czcionek](/slides/pl/cpp/powerpoint-fonts/) oraz ustawień układu/łamania linii dla systemu pisma. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [zasady podstawiania czcionek](/slides/pl/cpp/font-substitution/) i/lub [osadź czcionki](/slides/pl/cpp/embedded-font/) w prezentacji.

**Czy mogę ustawić różne języki w jednym akapicie?**

Tak. [Language ID](https://reference.aspose.com/slides/pl/cpp/aspose.slides/baseportionformat/set_languageid/) jest stosowany na poziomie fragmentu tekstu, więc w jednym akapicie można mieszać wiele języków z odrębnymi ustawieniami korekty.