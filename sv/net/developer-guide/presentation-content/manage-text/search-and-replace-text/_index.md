---
title: Sök och ersätt text i PowerPoint-presentationer i .NET
linktitle: Sök och ersätt text
type: docs
weight: 55
url: /sv/net/search-and-replace-text/
keywords:
- söktext
- markera text
- ersätt text
- reguljärt uttryck
- resultatåteranrop
- textram
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som varje matchning samlas in med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides for .NET kan söka, markera och ersätta text i en enskild textram eller i hela presentationen. Varje operation kan också meddela en applikation om varje matchning via ett resultat‑återanrop. Detta gör det möjligt att uppdatera en presentation och samtidigt skapa en revisionsspårning som innehåller den matchade texten, dess sammanhang, position, textram och bildnummer.

Dessa funktioner är användbara för granskning, maskering, terminologikontroller, rensning av mallar och automatiserade rapportsarbetsflöden.

I de första exemplen nedan använder vi en fil med namnet "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Välj sökområde**

Använd metoder på [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) för att begränsa en operation till en textram. Använd metoder på [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) för att bearbeta all tillämplig text i presentationen.

| Operation | En textram | Hela presentationen |
|---|---|---|
| Markera bokstavlig text | [ITextFrame.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/highlighttext/) |
| Markera reguljära uttrycksmatcher | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/highlightregex/) |
| Ersätt bokstavlig text | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/replacetext/) |
| Ersätt reguljära uttrycksmatcher | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/replaceregex/) |

## **Konfigurera textmatchning**

För bokstavliga textoperationer, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/) för att styra matchning:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/wholewordsonly/) begränsar matchningar till kompletta ord.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/casesensitive/) styr om teckenens skiftläge måste matcha.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/includenotes/) inkluderar bildanteckningar i sök-, ersättnings- och markeringsoperationer på presentationsnivå.

Reguljära uttrycksoperationer använder en .NET `Regex`, så matchningsregler såsom skiftlägeskänslighet och ordgränser definieras av uttrycket och dess alternativ.

## **Samla matchningsinformation med ett återanrop**

Implementera [IFindResultCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/ifindresultcallback/) för att få en notifikation för varje match. Dess [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/sv/net/aspose.slides/ifindresultcallback/foundresult/)‑metod tillhandahåller den relaterade textramen, källtexten, den matchade texten och matchningspositionen.

Återanropet får inte ett bildnummer direkt. Implementeringen nedan härleder det från den överordnade bilden och hanterar också text som hittas i bildanteckningar. Ett nullbart bildnummer tillåter samma resultatmodell att representera text kopplad till andra bildtyper.

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

För ersättningsoperationer innehåller `FoundText` den ursprungliga matchade texten, så återanropet kan registrera exakt vilka termer som ersattes.

## **Markera text**

Använd metoden [ITextFrame.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlighttext/) för att markera bokstavliga textmatchningar i en textram. Skicka in [TextSearchOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/) för att styra sökningen och ett återanrop för att samla matchningsdetaljer.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast det kompletta ordet **"to"**. Båda sökningarna rapporterar sina matchningar till samma återanrop.

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

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlightregex/) markerar textmatchningar som hittats med ett reguljärt uttryck i en textram.

Följande kod markerar alla ord som innehåller sju eller fler tecken och samlar varje matchning:

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

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Markera text i en hel presentation**

Använd [Presentation.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/highlighttext/) och [Presentation.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/highlightregex/) för att söka i alla tillämpliga textramar i en presentation. Följande exempel markerar ett bokstavligt uttryck och alla e‑postadresser samtidigt som separata resultatkollektioner hålls för de två sökningarna.

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

## **Ersätt text i en textram**

Använd [ITextFrame.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replacetext/) för bokstavlig text och [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replaceregex/) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten inom den befintliga textramen, vilket bevarar formateringen på den omgivande delen istället för att bygga om textramen från en ren sträng.

Följande exempel standardiserar en stavningsvariant och ersätter sedan versionsetiketter. Samma återanrop registrerar de ursprungliga termerna som matchades av båda operationerna.

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

Om en matchning sträcker sig över segment med olika formatering, granska utdata för att bekräfta vilken formatering som ska tillämpas på den ersatta texten.

## **Ersätt text i en hel presentation**

Använd [Presentation.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/replacetext/) och [Presentation.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/replaceregex/) för att tillämpa samma operationer i hela presentationen. Detta är användbart för rensning av mallar, uppdatering av terminologi och maskering.

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

## **Gruppera matchningar för rapportering**

Eftersom varje resultat lagrar sitt bildnummer och textram kan applikationer gruppera matchningar för revision, rapportering eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först efter bild och sedan efter textram:

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

**Hur kan jag söka bara i en textruta istället för i hela presentationen?**

Hämta figurens textram och anropa [ITextFrame.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replacetext/) eller [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replaceregex/) på den textramen. Metoder på presentationsnivå bearbetar alla tillämpliga textramar istället.

**Hur kan jag matcha hela ord med korrekt kapitalisering?**

Ställ in [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/wholewordsonly/) och [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/casesensitive/) till `true`, och skicka alternativen till en metod för bokstavlig textmarkering eller -ersättning. För reguljära uttryck definera ordgränser och skiftlägeskänslighet i .NET `Regex` själva.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Ställ in [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/includenotes/) till `true` när du använder en bokstavlig textoperation på presentationsnivå. Återanropsimplementationen ovan mappar en matchning i en anteckningsbild tillbaka till dess överordnade bildnummer.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en [IFindResultCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/ifindresultcallback/)‑implementation till markerings‑ eller ersättningsoperationen. Återanropet får varje matchning medan operationen körs, så applikationen kan lagra källtext, matchad text, position, textram och härlett bildnummer för senare gruppering eller export.

**Bevarar ersättning av text dess formatering?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replacetext/) och [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replaceregex/) modifierar den matchade texten inom den befintliga textramen och behåller formateringen på den omgivande delen. Om en matchning sträcker sig över segment med olika formatering, granska resultatet för att säkerställa att ersättningen använder önskad stil.