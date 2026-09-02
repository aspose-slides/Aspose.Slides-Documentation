---
title: Zoeken en vervangen van tekst in PowerPoint-presentaties in .NET
linktitle: Zoeken en vervangen van tekst
type: docs
weight: 55
url: /nl/net/search-and-replace-text/
keywords:
- tekst zoeken
- tekst markeren
- tekst vervangen
- reguliere expressie
- resultaat-callback
- tekstframe
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Zoek, markeer en vervang tekst in PowerPoint-presentaties terwijl elke overeenkomst wordt verzameld met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides for .NET kan zoeken, markeren en tekst vervangen in een individueel tekstframe of in een volledige presentatie. Elke bewerking kan ook een applicatie op de hoogte stellen van elke overeenkomst via een resultaat‑callback. Hiermee is het mogelijk om een presentatie bij te werken en tegelijkertijd een audit‑logboek op te bouwen met de gevonden tekst, de context, positie, het tekstframe en het slidennummer.

Deze mogelijkheden zijn nuttig voor beoordeling, redactie, terminologiecontroles, het opschonen van sjablonen en geautomatiseerde rapportage‑werkstromen.

In de eerste voorbeelden hieronder gebruiken we een bestand genaamd "sample.pptx", dat een enkele tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies de zoekscope**

Gebruik methoden van [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) om een bewerking te beperken tot één tekstframe. Gebruik methoden van [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerking | Één tekstframe | Volledige presentatie |
|---|---|---|
| Markeer letterlijke tekst | [ITextFrame.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/highlighttext/) |
| Markeer reguliere‑expressie‑overeenkomsten | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/highlightregex/) |
| Vervang letterlijke tekst | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/replacetext/) |
| Vervang reguliere‑expressie‑overeenkomsten | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/replaceregex/) |

## **Configureer tekstmatching**

Voor bewerkingen met letterlijke tekst, gebruik [TextSearchOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/) om het zoeken te regelen:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/wholewordsonly/) beperkt overeenkomsten tot volledige woorden.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/casesensitive/) bepaalt of hoofd‑/kleine letters moeten overeenkomen.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/includenotes/) omvat notities van dia's bij zoek‑, vervang‑ en markeerbewerkingen op presentatieniveau.

Reguliere‑expressie‑bewerkingen gebruiken een .NET `Regex`, waardoor regels voor zoeken, zoals hoofdlettergevoeligheid en woordgrenzen, worden gedefinieerd door de expressie en de bijbehorende opties.

## **Verzamel overeenstemmingsinformatie met een callback**

Implementeer [IFindResultCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/ifindresultcallback/) om een melding te ontvangen voor elke overeenkomst. De methode [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/nl/net/aspose.slides/ifindresultcallback/foundresult/) levert het bijbehorende tekstframe, de brontekst, de gevonden tekst en de positie van de overeenkomst.

De callback ontvangt niet rechtstreeks een slidennummer. De onderstaande implementatie haalt dit af van de bovenliggende dia en behandelt ook tekst die in notities van dia's wordt gevonden. Een nullable slidennummer maakt het mogelijk dat hetzelfde resultaatsmodel tekst kan vertegenwoordigen die bij andere dia‑typen hoort.

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

Voor vervangbewerkingen bevat `FoundText` de oorspronkelijk gevonden tekst, zodat de callback exact kan registreren welke termen zijn vervangen.

## **Markeer tekst**

Gebruik de methode [ITextFrame.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlighttext/) om overeenkomsten van letterlijke tekst in een tekstframe te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/) door om het zoeken te regelen en een callback om de details van de overeenkomst te verzamelen.

Het code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en daarna alleen het volledige woord **"to"**. Beide zoekopdrachten rapporteren hun overeenkomsten aan dezelfde callback.

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

Het resultaat:

![De gemarkeerde tekst](highlighted_text.png)

## **Markeer tekst met reguliere expressies**

De methode [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlightregex/) markeert tekstovereenkomsten die door een reguliere expressie in een tekstframe worden gevonden.

De onderstaande code markeert alle woorden die zeven of meer tekens bevatten en verzamelt elke overeenkomst:

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

Het resultaat:

![De gemarkeerde tekst met de reguliere expressie](highlighted_text_using_regex.png)

## **Markeer tekst in een hele presentatie**

Gebruik [Presentation.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/highlighttext/) en [Presentation.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/highlightregex/) om alle toepasselijke tekstframes in een presentatie te doorzoeken. Het onderstaande voorbeeld markeert een letterlijke term en alle e‑mailadressen, terwijl voor de twee zoekopdrachten aparte resultaatscollecties worden aangehouden.

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

## **Vervang tekst in een tekstframe**

Gebruik [ITextFrame.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replacetext/) voor letterlijke tekst en [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replaceregex/) voor op patronen gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstframe, waardoor de opmaak van de omringende delen behouden blijft in plaats van het tekstframe opnieuw op te bouwen vanuit een gewone string.

Het onderstaande voorbeeld standaardiseert een spellingvariant en vervangt vervolgens versielabels. Dezelfde callback registreert de oorspronkelijke termen die door beide bewerkingen zijn gevonden.

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

Als één overeenkomst delen met verschillende opmaak bestrijkt, controleer dan de uitvoer om te bevestigen welke opmaak op de vervangende tekst moet worden toegepast.

## **Vervang tekst in een hele presentatie**

Gebruik [Presentation.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/replacetext/) en [Presentation.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/replaceregex/) om dezelfde bewerkingen overal in de presentatie toe te passen. Dit is nuttig voor het opschonen van sjablonen, het bijwerken van terminologie en redactie.

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

## **Groepeer matches voor rapportage**

Aangezien elk resultaat het slidennummer en het tekstframe opslaat, kunnen applicaties matches groeperen voor audit‑, rapportage‑ of beoordelingswerkstromen. Het onderstaande voorbeeld groepeert de verzamelde resultaten eerst per dia en vervolgens per tekstframe:

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

**Hoe kan ik slechts één tekstvak doorzoeken in plaats van de hele presentatie?**

Haal het tekstframe van de shape op en roep [ITextFrame.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replacetext/) of [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replaceregex/) aan op dat tekstframe. Methoden op presentatieniveau verwerken alle toepasselijke tekstframes.

**Hoe kan ik volledige woorden matchen met de juiste hoofdlettergebruik?**

Stel [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/wholewordsonly/) en [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/casesensitive/) in op `true` en geef de opties door aan een markeer‑ of vervangmethode voor letterlijke tekst. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de .NET `Regex` zelf.

**Kunnen zoeken en vervangen tekst in dia‑notities omvatten?**

Ja. Stel [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/includenotes/) in op `true` bij gebruik van een bewerking voor letterlijke tekst op presentatieniveau. De bovenstaande callback‑implementatie koppelt een overeenkomst in een notitieslide terug naar het slidennummer van de bovenliggende dia.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een implementatie van [IFindResultCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/ifindresultcallback/) door aan de markeer‑ of vervangbewerking. De callback ontvangt elke overeenkomst terwijl de bewerking loopt, zodat de applicatie de brontekst, gevonden tekst, positie, tekstframe en afgeleid slidennummer kan opslaan voor latere groepering of export.

**Behoudt het vervangen van tekst de opmaak?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replacetext/) en [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replaceregex/) wijzigen de gevonden tekst binnen het bestaande tekstframe en behouden de opmaak van de omringende delen. Als een overeenkomst delen met verschillende opmaak beslaat, inspecteer dan het resultaat om te verzekeren dat de vervanging de gewenste stijl gebruikt.