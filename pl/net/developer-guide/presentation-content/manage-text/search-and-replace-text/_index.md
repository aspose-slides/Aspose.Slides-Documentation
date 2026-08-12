---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint w .NET
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/net/search-and-replace-text/
keywords:
- wyszukiwanie tekstu
- podświetlanie tekstu
- zastępowanie tekstu
- wyrażenie regularne
- zwrotne wywołanie wyniku
- ramka tekstowa
- raport audytu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Wyszukuj, podświetlaj i zamieniaj tekst w prezentacjach PowerPoint, jednocześnie zbierając każde dopasowanie przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides for .NET może przeszukiwać, podświetlać i zastępować tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może również powiadomić aplikację o każdym dopasowaniu za pomocą zwrotnego wywołania wyniku. Umożliwia to aktualizację prezentacji i jednoczesne tworzenie ścieżki audytu zawierającej dopasowany tekst, jego kontekst, pozycję, ramkę tekstową oraz numer slajdu.

Te możliwości są przydatne przy przeglądzie, redakcji, weryfikacji terminologii, czyszczeniu szablonów oraz zautomatyzowanych przepływach raportowania.

W pierwszych przykładach poniżej używamy pliku o nazwie "sample.pptx", który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod na [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) , aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) , aby przetworzyć cały odpowiedni tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl tekst literalny | [ITextFrame.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/highlighttext/) |
| Podświetl dopasowania wyrażenia regularnego | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/highlightregex/) |
| Zastąp tekst literalny | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/replacetext/) |
| Zastąp dopasowania wyrażenia regularnego | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/replaceregex/) |

## **Skonfiguruj dopasowywanie tekstu**

Dla operacji na tekście dosłownym użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/) do kontrolowania dopasowań:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/wholewordsonly/) ogranicza dopasowania do pełnych słów.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/casesensitive/) kontroluje, czy wielkość znaków musi się zgadzać.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/includenotes/) uwzględnia notatki slajdu w operacjach wyszukiwania, zastępowania i podświetlania na poziomie prezentacji.

Operacje wyrażenia regularnego używają .NET `Regex`, więc reguły dopasowywania, takie jak wrażliwość na wielkość liter i granice słów, są definiowane przez wyrażenie i jego opcje.

## **Zbierz informacje o dopasowaniach za pomocą zwrotnego wywołania**

Zaimplementuj [IFindResultCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/ifindresultcallback/) , aby otrzymywać powiadomienie o każdym dopasowaniu. Jego metoda [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/pl/net/aspose.slides/ifindresultcallback/foundresult/) dostarcza powiązaną ramkę tekstową, tekst źródłowy, dopasowany tekst oraz pozycję dopasowania.

Zwrotne wywołanie nie otrzymuje numeru slajdu bezpośrednio. Implementacja poniżej wyprowadza go z nadrzędnego slajdu i obsługuje również tekst znaleziony w notatkach slajdu. Numer slajdu może być nulowalny, co pozwala temu samemu modelowi wyniku reprezentować tekst powiązany z innymi typami slajdów.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Dla operacji zastępowania `FoundText` zawiera oryginalny dopasowany tekst, więc zwrotne wywołanie może dokładnie zanotować, które terminy zostały zastąpione.

## **Podświetl tekst**

Użyj metody [ITextFrame.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlighttext/) , aby podświetlić dopasowania tekstu dosłownego w ramce tekstowej. Przekaż [TextSearchOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/) , aby kontrolować wyszukiwanie oraz zwrotne wywołanie do zbierania szczegółów dopasowań.

Przykład kodu poniżej podświetla wszystkie wystąpienia znaków **"try"** i następnie podświetla tylko pełne słowo **"to"**. Oba wyszukiwania zgłaszają swoje dopasowania do tego samego zwrotnego wywołania.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Wynik:

![Podświetlony tekst](highlighted_text.png)

## **Podświetl tekst przy użyciu wyrażeń regularnych**

Metoda [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlightregex/) podświetla dopasowania tekstu znalezione przy użyciu wyrażenia regularnego w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające co najmniej siedem znaków i zbiera każde dopasowanie:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Podświetl tekst w całej prezentacji**

Użyj [Presentation.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/highlighttext/) i [Presentation.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/highlightregex/) , aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla termin literalny i wszystkie adresy e‑mail, zachowując osobne kolekcje wyników dla obu wyszukiwań.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Zastąp tekst w ramce tekstowej**

Użyj [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replacetext/) dla tekstu literalnego i [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replaceregex/) dla zastępowania opartego na wzorcu. Te metody aktualizują dopasowany tekst w istniejącej ramce tekstowej, zachowując formatowanie otaczających fragmentów zamiast przebudowywać ramkę z ciągu znaków.

Poniższy przykład standaryzuje wariant pisowni, a następnie zastępuje etykiety wersji. To samo zwrotne wywołanie rejestruje oryginalne terminy dopasowane w obu operacjach.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, przejrzyj wynik, aby potwierdzić, które formatowanie ma być zastosowane do tekstu zastępczego.

## **Zastąp tekst w całej prezentacji**

Użyj [Presentation.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/replacetext/) i [Presentation.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/replaceregex/) , aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacjach terminologii i redakcji.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Grupuj dopasowania w raportach**

Ponieważ każdy wynik przechowuje numer slajdu i ramkę tekstową, aplikacje mogą grupować dopasowania dla audytu, raportowania lub przepływów przeglądu. Poniższy przykład grupuje zebrane wyniki najpierw według slajdu, a potem według ramki tekstowej:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **FAQ**

**Jak mogę wyszukać tylko jedną ramkę tekstową zamiast całej prezentacji?**

Uzyskaj ramkę tekstową kształtu i wywołaj [ITextFrame.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replacetext/) lub [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replaceregex/) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe zamiast tego.

**Jak mogę dopasować pełne słowa z właściwą kapitalizacją?**

Ustaw [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/wholewordsonly/) i [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/casesensitive/) na `true` i przekaż opcje do metody podświetlania lub zastępowania tekstu literalnego. Dla wyrażeń regularnych określ granice słów i wrażliwość na wielkość liter w samym .NET `Regex`.

**Czy wyszukiwanie i zastępowanie może obejmować tekst w notatkach slajdu?**

Tak. Ustaw [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/includenotes/) na `true` przy używaniu operacji tekstu literalnego na poziomie prezentacji. Implementacja zwrotnego wywołania pokazanego wyżej mapuje dopasowanie w notatkach slajdu na jego nadrzędny numer slajdu.

**Jak mogę utworzyć raport bez ponownego skanowania prezentacji?**

Przekaż implementację [IFindResultCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/ifindresultcallback/) do operacji podświetlania lub zastępowania. Zwrotne wywołanie otrzymuje każde dopasowanie podczas wykonywania operacji, więc aplikacja może przechowywać tekst źródłowy, dopasowany tekst, pozycję, ramkę tekstową oraz wyprowadzony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zastępowanie tekstu zachowuje jego formatowanie?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replacetext/) i [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replaceregex/) modyfikują dopasowany tekst w istniejącej ramce tekstowej i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby upewnić się, że zastąpiony tekst używa pożądanego stylu.