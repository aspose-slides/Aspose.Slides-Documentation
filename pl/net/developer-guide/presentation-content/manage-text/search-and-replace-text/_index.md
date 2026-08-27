---
title: Wyszukiwanie i zamiana tekstu w prezentacjach PowerPoint w .NET
linktitle: Wyszukiwanie i zamiana tekstu
type: docs
weight: 55
url: /pl/net/search-and-replace-text/
keywords:
- wyszukiwanie tekstu
- podświetlanie tekstu
- zamiana tekstu
- wyrażenie regularne
- wywołanie zwrotne wyniku
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

Aspose.Slides for .NET może wyszukiwać, podświetlać i zamieniać tekst w pojedynczej ramce tekstowej lub w całej prezentacji. Każda operacja może również powiadomić aplikację o każdym dopasowaniu za pomocą wywołania zwrotnego wyniku. Umożliwia to aktualizację prezentacji i jednoczesne tworzenie śladu audytu zawierającego dopasowany tekst, jego kontekst, pozycję, ramkę tekstową oraz numer slajdu.

Te możliwości są przydatne przy przeglądzie, redagowaniu, weryfikacji terminologii, czyszczeniu szablonów oraz automatycznych przepływach raportowania.

W pierwszych przykładach poniżej używamy pliku o nazwie "sample.pptx", który zawiera jedną ramkę tekstową na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Wybierz zakres wyszukiwania**

Użyj metod na [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/), aby ograniczyć operację do jednej ramki tekstowej. Użyj metod na [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), aby przetwarzać cały odpowiedni tekst w prezentacji.

| Operacja | Jedna ramka tekstowa | Cała prezentacja |
|---|---|---|
| Podświetl tekst dosłowny | [ITextFrame.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/highlighttext/) |
| Podświetl dopasowania wyrażenia regularnego | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/highlightregex/) |
| Zamień tekst dosłowny | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/replacetext/) |
| Zamień dopasowania wyrażenia regularnego | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/replaceregex/) |

## **Skonfiguruj dopasowywanie tekstu**

Do operacji na tekście dosłownym użyj [TextSearchOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/) aby kontrolować dopasowywanie:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/wholewordsonly/) ogranicza dopasowania do pełnych słów.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/casesensitive/) określa, czy uwzględniać wielkość liter.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/includenotes/) uwzględnia notatki slajdów w operacjach wyszukiwania, zamiany i podświetlania na poziomie prezentacji.

Operacje wykorzystujące wyrażenia regularne używają .NET `Regex`, więc reguły dopasowywania, takie jak wrażliwość na wielkość liter i granice słów, są definiowane przez wyrażenie i jego opcje.

## **Zidentyfikuj właściciela ramki tekstowej**

Ogólne przepływy przetwarzania tekstu często otrzymują obiekt [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) podczas wyszukiwania, zamiany, walidacji lub eksportu tekstu. Użyj [ITextFrame.ParentShape](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentshape/) i [ITextFrame.ParentCell](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentcell/) aby określić, który obiekt prezentacji jest właścicielem ramki tekstowej.

Oczekiwane wartości zależą od właściciela:

| Właściciel ramki tekstowej | `ParentShape` | `ParentCell` |
|---|---|---|
| AutoShape lub inny kształt zawierający tekst | Właściciel [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) | `null` |
| Komórka tabeli | `null` | Właściciel [ICell](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/) |

Obie właściwości są tylko do odczytu i służą do nawigacji. Odczyt ich nie przenosi ramki tekstowej ani nie zmienia jej właściciela. Kod generyczny powinien sprawdzać oba wartości pod kątem `null` i obsługiwać możliwość, że żaden właściciel nie jest dostępny.

Poniższy przykład używa [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/getalltextframes/) aby przeiterować wszystkie ramki tekstowe w prezentacji. Dla kształtów raportuje nazwę kształtu, typ kształtu i slajd, na którym się znajduje. Dla komórek tabeli raportuje współrzędne kolumny i wiersza (liczone od zera) oraz slajd, w którym się znajduje.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Dla treści SmartArt iteruj po kształtach w [ISmartArtNode.Shapes](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/ismartartnode/shapes/) i uzyskaj dostęp do każdego [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/ismartartshape/textframe/). Ramka tekstowa może być powiązana z jej kształtem przy pomocy [ITextFrame.ParentShape](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentshape/), podczas gdy [ITextFrame.ParentCell](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentcell/) jest `null`. Dlatego gałąź dotycząca kształtów w przykładzie obsługuje również tekst z węzłów SmartArt.

## **Zbierz informacje o dopasowaniach za pomocą wywołania zwrotnego**

Zaimplementuj [IFindResultCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/ifindresultcallback/) aby otrzymywać powiadomienie o każdym dopasowaniu. Jego metoda [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/pl/net/aspose.slides/ifindresultcallback/foundresult/) dostarcza powiązaną ramkę tekstową, źródłowy tekst, dopasowany tekst oraz pozycję dopasowania.

Wywołanie zwrotne nie otrzymuje numeru slajdu bezpośrednio. Poniższa implementacja wylicza go z slajdu nadrzędnego i obsługuje również tekst znaleziony w notatkach slajdu. Opcjonalny numer slajdu pozwala temu samemu modelowi wyniku reprezentować tekst powiązany z innymi typami slajdów.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

W operacjach zamiany `FoundText` zawiera pierwotny dopasowany tekst, więc wywołanie zwrotne może dokładnie zapisać, które terminy zostały zamienione.

## **Podświetl tekst**

Użyj metody [ITextFrame.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlighttext/) aby podświetlić dopasowania tekstu dosłownego w ramce tekstowej. Przekaż [TextSearchOptions](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/) w celu kontrolowania wyszukiwania oraz wywołanie zwrotne do zbierania szczegółów dopasowań.

Poniższy przykład kodu podświetla wszystkie wystąpienia znaków **"try"** i następnie podświetla tylko całe słowo **"to"**. Oba wyszukiwania raportują swoje dopasowania do tego samego wywołania zwrotnego.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Pobierz pierwszy kształt z pierwszego slajdu.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Podświetl każde wystąpienie "try" w ramce tekstowej.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Podświetl tylko całe słowo "to".
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

Metoda [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlightregex/) podświetla dopasowania tekstu znalezione przez wyrażenie regularne w ramce tekstowej.

Poniższy kod podświetla wszystkie słowa zawierające siedem lub więcej znaków i zbiera każde dopasowanie:

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

Wynik:

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Podświetl tekst w całej prezentacji**

Użyj [Presentation.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/highlighttext/) i [Presentation.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/highlightregex/) aby przeszukać wszystkie odpowiednie ramki tekstowe w prezentacji. Poniższy przykład podświetla literalny termin i wszystkie adresy e‑mail, zachowując oddzielne kolekcje wyników dla obu wyszukiwań.

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

## **Zamień tekst w ramce tekstowej**

Użyj [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replacetext/) do tekstu dosłownego i [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replaceregex/) do zamiany opartej na wzorcu. Metody te aktualizują dopasowany tekst w istniejącej ramce tekstowej, zachowując formatowanie otaczających fragmentów zamiast przekształcać ramkę tekstową z zwykłego ciągu znaków.

Poniższy przykład standaryzuje wariant pisowni, a następnie zamienia etykiety wersji. To samo wywołanie zwrotne zapisuje oryginalne terminy dopasowane w obu operacjach.

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

Jeśli jedno dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby potwierdzić, które formatowanie powinno zostać zastosowane do tekstu zamiany.

## **Zamień tekst w całej prezentacji**

Użyj [Presentation.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/replacetext/) i [Presentation.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/replaceregex/) aby zastosować te same operacje w całej prezentacji. Jest to przydatne przy czyszczeniu szablonów, aktualizacji terminologii oraz redagowaniu.

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

## **Grupuj dopasowania do raportowania**

Ponieważ każdy wynik przechowuje numer slajdu i ramkę tekstową, aplikacje mogą grupować dopasowania do celów audytu, raportowania lub przeglądu. Poniższy przykład grupuje zebrane wyniki najpierw według slajdu, a następnie według ramki tekstowej:

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

## **Najczęściej zadawane pytania**

**Jak mogę przeszukiwać tylko jedną ramkę tekstową zamiast całej prezentacji?**

Pobierz ramkę tekstową kształtu i wywołaj [ITextFrame.HighlightText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replacetext/) lub [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replaceregex/) na tej ramce. Metody na poziomie prezentacji przetwarzają wszystkie odpowiednie ramki tekstowe zamiast tego.

**Jak mogę dopasować pełne słowa z zachowaniem prawidłowej wielkości liter?**

Ustaw [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/wholewordsonly/) i [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/casesensitive/) na `true` i przekaż opcje do metody podświetlania lub zamiany tekstu dosłownego. W przypadku wyrażeń regularnych określ granice słów i wrażliwość na wielkość liter bezpośrednio w .NET `Regex`.

**Czy wyszukiwanie i zamiana mogą obejmować tekst w notatkach slajdów?**

Tak. Ustaw [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/pl/net/aspose.slides/textsearchoptions/includenotes/) na `true` podczas używania operacji tekstu dosłownego na poziomie prezentacji. Implementacja wywołania zwrotnego przedstawiona powyżej mapuje dopasowanie w notatce slajdu na numer slajdu nadrzędnego.

**Jak stworzyć raport bez ponownego skanowania prezentacji?**

Przekaż implementację [IFindResultCallback](https://reference.aspose.com/slides/pl/net/aspose.slides/ifindresultcallback/) do operacji podświetlania lub zamiany. Wywołanie zwrotne otrzymuje każde dopasowanie w trakcie trwania operacji, dzięki czemu aplikacja może przechowywać tekst źródłowy, dopasowany tekst, pozycję, ramkę tekstową oraz wyliczony numer slajdu do późniejszego grupowania lub eksportu.

**Czy zamiana tekstu zachowuje jego formatowanie?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replacetext/) i [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/replaceregex/) modyfikują dopasowany tekst w istniejącej ramce tekstowej i zachowują formatowanie otaczających fragmentów. Jeśli dopasowanie obejmuje fragmenty o różnym formatowaniu, sprawdź wynik, aby upewnić się, że zamiana używa pożądanego stylu.