---
title: Sök och ersätt text i PowerPoint-presentationer i .NET
linktitle: Sök och ersätt text
type: docs
weight: 55
url: /sv/net/search-and-replace-text/
keywords:
- sök text
- markera text
- ersätt text
- reguljärt uttryck
- resultat-callback
- textruta
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som du samlar alla matchningar med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides for .NET kan söka, markera och ersätta text i en enskild textruta eller i hela en presentation. Varje operation kan också meddela en applikation om varje matchning via ett callback. Detta gör det möjligt att uppdatera en presentation och samtidigt bygga ett revisionsspår som innehåller den matchade texten, dess sammanhang, position, textruta och bildnummer.

Dessa funktioner är användbara för granskning, redigering, terminologikontroller, mallrengöring och automatiserade rapporteringsarbetsflöden.

I de första exemplen nedan använder vi en fil med namnet "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Välj sökområde**

Använd metoder på [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) för att begränsa en operation till en textruta. Använd metoder på [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) för att bearbeta all tillämplig text i presentationen.

| Operation | En textruta | Hela presentationen |
|---|---|---|
| Markera bokstavlig text | [ITextFrame.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/highlighttext/) |
| Markera matchningar för reguljära uttryck | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/highlightregex/) |
| Ersätt bokstavlig text | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/replacetext/) |
| Ersätt matchningar för reguljära uttryck | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/replaceregex/) |

## **Konfigurera textmatchning**

För operationer med bokstavlig text, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/) för att styra matchning:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/wholewordsonly/) begränsar matchningar till hela ord.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/casesensitive/) styr huruvida tecknens skiftläge måste matcha.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/includenotes/) inkluderar bildanteckningar i sök-, ersättnings- och markeringsoperationer på presentationsnivå.

Operationer med reguljära uttryck använder en .NET `Regex`, så matchningsregler såsom skiftlägeskänslighet och ordgränser definieras av själva uttrycket och dess alternativ.

## **Identifiera ägaren till en textruta**

Generiska textbehandlingsarbetsflöden får ofta en [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) medan de söker, ersätter, validerar eller exporterar text. Använd [ITextFrame.ParentShape](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/parentshape/) och [ITextFrame.ParentCell](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/parentcell/) för att avgöra vilket presentationsobjekt som äger textrutan.

De förväntade värdena beror på ägaren:

| Ägare av textrutan | `ParentShape` | `ParentCell` |
|---|---|---|
| En AutoShape eller en annan textinnehållande form | Den ägande [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/) | `null` |
| En tabellcell | `null` | Den ägande [ICell](https://reference.aspose.com/slides/sv/net/aspose.slides/icell/) |

Båda egenskaperna är skrivskyddade navigerings‑egenskaper. Att läsa dem flyttar inte textrutan eller ändrar dess ägare. Generisk kod bör kontrollera båda värdena för `null` och hantera möjligheten att ingen ägare är tillgänglig.

Följande exempel använder [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/getalltextframes/) för att iterera genom textrutorna i en presentation. För former rapporterar det formens namn, formtyp och innehållande bild. För tabellceller rapporterar det nollbaserade kolumn‑ och radkoordinater samt den innehållande bilden.

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

För SmartArt‑innehåll, iterera genom formerna i [ISmartArtNode.Shapes](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/ismartartnode/shapes/) och få åtkomst till varje [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides.smartart/ismartartshape/textframe/). Textrutan kan spåras till sin associerade form via [ITextFrame.ParentShape](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/parentshape/), medan [ITextFrame.ParentCell](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/parentcell/) är `null`. Därför hanterar formgrenen i exemplet även text från SmartArt‑noder.

## **Samla in matchningsinformation med ett callback**

Implementera [IFindResultCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/ifindresultcallback/) för att få en avisering för varje matchning. Dess [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/sv/net/aspose.slides/ifindresultcallback/foundresult/)‑metod tillhandahåller den relaterade textrutan, källtexten, den matchade texten och matchningspositionen.

Callback‑funktionen får inte ett bildnummer direkt. Implementeringen nedan härleder det från den överordnade bilden och hanterar även text som hittas i bildanteckningar. Ett nullable bildnummer gör att samma resultatsmodell kan representera text som är associerad med andra bildtyper.

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

För ersättningsoperationer innehåller `FoundText` den ursprungliga matchade texten, så callback‑funktionen kan exakt registrera vilka termer som ersattes.

## **Markera text**

Använd metoden [ITextFrame.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlighttext/) för att markera matchningar av bokstavlig text i en textruta. Skicka in [TextSearchOptions] för att styra sökningen och ett callback för att samla in matchningsdetaljer.

Koden nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast det hela ordet **"to"**. Båda sökningarna rapporterar sina matchningar till samma callback.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Hämta den första formen från den första bilden.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Markera varje förekomst av "try" i textrutan.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Markera endast det hela ordet "to".
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

Metoden [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlightregex/) markerar textmatchningar som hittas av ett reguljärt uttryck i en textruta.

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

Använd [Presentation.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/highlighttext/) och [Presentation.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/highlightregex/) för att söka alla tillämpliga textrutor i en presentation. Följande exempel markerar ett bokstavligt uttryck och alla e‑postadresser samtidigt som separata resultatsamlingar hålls för de två sökningarna.

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

## **Ersätt text i en textruta**

Använd [ITextFrame.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replacetext/) för bokstavlig text och [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replaceregex/) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten i den befintliga textrutan, vilket behåller formateringen för den omgivande delen istället för att bygga om textrutan från en ren sträng.

Följande exempel standardiserar en stavningsvariant och ersätter sedan versionsetiketter. Samma callback registrerar de ursprungliga termerna som matchades av båda operationerna.

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

Om en matchning sträcker sig över delar med olika formatering, granska utdata för att bekräfta vilken formatering som ska gälla för den ersatta texten.

## **Ersätt text i en hel presentation**

Använd [Presentation.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/replacetext/) och [Presentation.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/replaceregex/) för att tillämpa samma operationer över hela presentationen. Detta är användbart för mallrengöring, terminologisk uppdatering och redigering.

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

Eftersom varje resultat lagrar sitt bildnummer och sin textruta kan applikationer gruppera matchningar för revisions‑, rapporterings‑ eller granskningsarbetsflöden. Följande exempel grupperar de insamlade resultaten först efter bild och sedan efter textruta:

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

**Hur kan jag söka endast i en textruta istället för hela presentationen?**

Hämta formens textruta och anropa [ITextFrame.HighlightText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replacetext/) eller [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replaceregex/) på den textrutan. Metoder på presentationsnivå bearbetar alla tillämpliga textrutor istället.

**Hur kan jag matcha hela ord med korrekt versal-/gemen‑skrift?**

Ställ in [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/wholewordsonly/) och [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/casesensitive/) till `true` och skicka alternativen till en bokstavlig markerings‑ eller ersättningsmetod. För reguljära uttryck definierar du ordgränser och skiftlägeskänslighet i själva .NET `Regex`.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Ställ in [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/sv/net/aspose.slides/textsearchoptions/includenotes/) till `true` när du använder en presentationsnivå‑operation för bokstavlig text. Callback‑implementeringen ovan kartlägger en matchning i en notbild tillbaka till dess överordnade bildnummer.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Passa in en [IFindResultCallback](https://reference.aspose.com/slides/sv/net/aspose.slides/ifindresultcallback/)‑implementation till markerings‑ eller ersättningsoperationen. Callback‑funktionen får varje matchning medan operationen körs, så applikationen kan lagra källtexten, den matchade texten, positionen, textrutan och det härledda bildnumret för senare gruppering eller export.

**Behåller ersättning av text dess formatering?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replacetext/) och [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/replaceregex/) ändrar den matchade texten i den befintliga textrutan och behåller formateringen för den omgivande delen. Om en matchning sträcker sig över delar med olika formatering, inspektera resultatet för att säkerställa att ersättningen använder den önskade stilen.