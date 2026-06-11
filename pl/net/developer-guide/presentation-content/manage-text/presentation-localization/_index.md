---
title: Automatyzacja lokalizacji prezentacji w .NET
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/net/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- identyfikator języka
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Automatyzuj lokalizację slajdów PowerPoint i OpenDocument w .NET przy użyciu Aspose.Slides, korzystając z praktycznych przykładów kodu C# i wskazówek przyspieszających globalne wdrożenie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak ustawić `LanguageId` dla tekstu w prezentacji za pomocą Aspose.Slides. Pokazuje, jak otworzyć prezentację, dodać kształt z tekstem, przypisać identyfikator języka do fragmentu tekstu i zapisać wynik jako plik PPTX.

## **Zmienianie języka w prezentacji i tekście kształtu**
- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Rectangle do slajdu.
- Dodaj trochę tekstu do TextFrame.
- Ustawienie Language Id dla tekstu.
- Zapisz prezentację jako plik PPTX.

Implementacja powyższych kroków jest przedstawiona poniżej w przykładzie.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Czy Language ID wywołuje automatyczne tłumaczenie tekstu?**

Nie. [LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/languageid/) w Aspose.Slides przechowuje język do sprawdzania pisowni i korekty gramatycznej, ale nie tłumaczy ani nie zmienia treści tekstu. Jest to metadane, które PowerPoint rozumie w celu korekty.

**Czy Language ID wpływa na dzielenie wyrazów i podziały wierszy podczas renderowania?**

W Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/languageid/) służy do korekty. Jakość dzielenia wyrazów i zawijania wierszy zależy głównie od dostępności [odpowiednich czcionek](/slides/pl/net/powerpoint-fonts/) oraz ustawień układu/podziału wierszy dla konkretnego systemu pisma. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [zasady podstawiania czcionek](/slides/pl/net/font-substitution/) i/lub [osadź czcionki](/slides/pl/net/embedded-font/) w prezentacji.

**Czy mogę ustawić różne języki w jednym akapicie?**

Tak. [LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/languageid/) jest stosowany na poziomie fragmentu tekstu, więc jeden akapit może mieszać wiele języków z odrębnymi ustawieniami korekty.