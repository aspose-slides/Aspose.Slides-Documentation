---
title: Tekst zoeken en vervangen in PowerPoint‑presentaties in .NET
linktitle: Tekst zoeken en vervangen
type: docs
weight: 55
url: /nl/net/search-and-replace-text/
keywords:
- zoektekst
- tekst markeren
- tekst vervangen
- reguliere expressie
- resultaat‑callback
- tekstframe
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Zoek, markeer en vervang tekst in PowerPoint‑presentaties terwijl u elke overeenkomst verzamelt met Aspose.Slides for .NET."
---
## **Overzicht**

Aspose.Slides for .NET kan tekst zoeken, markeren en vervangen in een individueel tekstframe of in een hele presentatie. Elke bewerking kan bovendien een applicatie op de hoogte stellen van elke overeenkomst via een result‑callback. Hierdoor kan een presentatie worden bijgewerkt en tegelijkertijd een audit‑trail worden opgebouwd met de gevonden tekst, de context, positie, tekstframe en dia‑nummer.

Deze mogelijkheden zijn nuttig voor controle, redactie, terminologie‑checks, sjabloon‑opschoning en geautomatiseerde rapportage‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand met de naam “sample.pptx”, dat op de eerste dia één tekstvak bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies het zoekbereik**

Gebruik methoden op [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) om een bewerking te beperken tot één tekstframe. Gebruik methoden op [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Operatie | Eén tekstframe | Hele presentatie |
|---|---|---|
| Markeer letterlijke tekst | [ITextFrame.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/highlighttext/) |
| Markeer reguliere‑expressie‑overeenkomsten | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/highlightregex/) |
| Vervang letterlijke tekst | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/replacetext/) |
| Vervang reguliere‑expressie‑overeenkomsten | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/replaceregex/) |

## **Configureer tekstmatching**

Voor bewerkingen met letterlijke tekst gebruik je [TextSearchOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/) om het zoeken te sturen:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/wholewordsonly/) beperkt overeenkomsten tot volledige woorden.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/casesensitive/) bepaalt of hoofdlettergevoeligheid vereist is.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/includenotes/) neemt aantekeningen op in zoek‑, vervang‑ en markeerbewerkingen op presentatieniveau.

Reguliere‑expressie‑bewerkingen gebruiken een .NET `Regex`, zodat regels zoals hoofdlettergevoeligheid en woordgrenzen worden gedefinieerd door de expressie en de opties ervan.

## **Identificeer de eigenaar van een tekstframe**

Generieke tekstverwerkings‑workflows ontvangen vaak een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) tijdens zoeken, vervangen, valideren of exporteren. Gebruik [ITextFrame.ParentShape](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentshape/) en [ITextFrame.ParentCell](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentcell/) om te bepalen welk presentatie‑object eigenaar is van het tekstframe.

De verwachte waarden hangen af van de eigenaar:

| Eigenaar tekstframe | `ParentShape` | `ParentCell` |
|---|---|---|
| Een AutoShape of een andere vorm die tekst bevat | De eigenaar‑[IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) | `null` |
| Een tabelcel | `null` | De eigenaar‑[ICell](https://reference.aspose.com/slides/nl/net/aspose.slides/icell/) |

Beide eigenschappen zijn alleen‑lezen navigatie‑eigenschappen. Het lezen ervan verplaatst het tekstframe niet en verandert de eigenaar niet. Generieke code moet beide waarden op `null` controleren en rekening houden met de mogelijkheid dat geen van beide beschikbaar is.

Het volgende voorbeeld gebruikt [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/getalltextframes/) om door de tekstframes in een presentatie te itereren. Voor vormen meldt het de vormnaam, vormtype en bijbehorende dia. Voor tabelcellen meldt het de nul‑gebaseerde kolom‑ en rijcoördinaten en de bijbehorende dia.

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

Voor SmartArt‑inhoud iterereer je door de vormen in [ISmartArtNode.Shapes](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/ismartartnode/shapes/) en krijg je toegang tot elke [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/ismartartshape/textframe/). Het tekstframe kan worden opgespoord via [ITextFrame.ParentShape](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentshape/), terwijl [ITextFrame.ParentCell](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentcell/) `null` is. Daarom behandelt de vorm‑tak in het voorbeeld ook tekst uit SmartArt‑knopen.

## **Verzamel overeenkomstinformatie met een callback**

Implementeer [IFindResultCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/ifindresultcallback/) om een melding te ontvangen voor elke overeenkomst. Zijn [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/nl/net/aspose.slides/ifindresultcallback/foundresult/)‑methode levert het bijbehorende tekstframe, de brontekst, de gevonden tekst en de positie van de overeenkomst.

De callback ontvangt geen dia‑nummer direct. De implementatie hieronder haalt dit af van de bovenliggende dia en behandelt ook tekst die in aantekeningen staat. Een nullable dia‑nummer maakt het mogelijk om hetzelfde resultaatsmodel te gebruiken voor tekst gekoppeld aan andere dia‑typen.

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

Voor vervangings‑bewerkingen bevat `FoundText` de oorspronkelijke gevonden tekst, zodat de callback exact kan vastleggen welke termen zijn vervangen.

## **Markeer tekst**

Gebruik de methode [ITextFrame.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlighttext/) om letterlijke tekstovereenkomsten in een tekstframe te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/) door om het zoeken te sturen en een callback om de details van de overeenkomsten te verzamelen.

De code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en vervolgens alleen het volledige woord **"to"**. Beide zoekacties rapporteren hun overeenkomsten aan dezelfde callback.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Haal de eerste vorm van de eerste dia op.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Markeer elk voorkomen van "try" in het tekstframe.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Markeer alleen het volledige woord "to".
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

De methode [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlightregex/) markeert tekstovereenkomsten die door een reguliere expressie worden gevonden in een tekstframe.

De volgende code markeert alle woorden die zeven of meer tekens bevatten en verzamelt elke overeenkomst:

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

## **Markeer tekst in een presentatie**

Gebruik [Presentation.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/highlighttext/) en [Presentation.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/highlightregex/) om alle toepasselijke tekstframes in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e‑mailadressen, waarbij de resultaten van de twee zoekacties gescheiden blijven.

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

Gebruik [ITextFrame.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replacetext/) voor letterlijke tekst en [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replaceregex/) voor patroon‑gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstframe, waardoor de opmaak van de omliggende delen behouden blijft in plaats van dat het tekstframe wordt herbouwd vanuit een platte string.

Het volgende voorbeeld standaardiseert een spellingsvariant en vervangt vervolgens versie‑labels. Dezelfde callback legt de oorspronkelijke termen vast die door beide bewerkingen zijn gevonden.

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

Als één overeenkomst delen met verschillende opmaak bevat, controleer dan de uitvoer om te bevestigen welke opmaak moet worden toegepast op de vervangende tekst.

## **Vervang tekst in een presentatie**

Gebruik [Presentation.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/replacetext/) en [Presentation.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/replaceregex/) om dezelfde bewerkingen over de hele presentatie toe te passen. Dit is nuttig voor sjabloon‑opschoning, terminologie‑updates en redactie.

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

## **Groeperen van overeenkomsten voor rapportage**

Omdat elk resultaat zijn dia‑nummer en tekstframe opslaat, kunnen applicaties overeenkomsten groeperen voor audit‑, rapportage‑ of review‑workflows. Het volgende voorbeeld groepeert de verzamelde resultaten eerst op dia en vervolgens op tekstframe:

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

## **Veelgestelde vragen**

**Hoe kan ik zoeken in slechts één tekstvak in plaats van de hele presentatie?**

Haal het tekstframe van de vorm op en roep [ITextFrame.HighlightText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replacetext/) of [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replaceregex/) aan op dat tekstframe. Methoden op presentatieniveau verwerken alle toepasselijke tekstframes.

**Hoe kan ik volledige woorden vinden met de juiste hoofdlettergebruik?**

Stel [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/wholewordsonly/) en [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/casesensitive/) in op `true` en geef de opties door aan een markeer‑ of vervangingsmethode voor letterlijke tekst. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid rechtstreeks in de .NET `Regex`.

**Kunnen zoeken en vervangen ook tekst in aantekeningen omvatten?**

Ja. Stel [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/nl/net/aspose.slides/textsearchoptions/includenotes/) in op `true` bij een bewerking op presentatieniveau voor letterlijke tekst. De callback‑implementatie hierboven koppelt een overeenkomst in een notitie‑dia terug aan het bijbehorende dia‑nummer.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een [IFindResultCallback](https://reference.aspose.com/slides/nl/net/aspose.slides/ifindresultcallback/)‑implementatie door aan de markeer‑ of vervangingsbewerking. De callback ontvangt elke overeenkomst tijdens het uitvoeren van de bewerking, zodat de applicatie de brontekst, gevonden tekst, positie, tekstframe en afgeleid dia‑nummer kan opslaan voor latere groepering of export.

**Behoudt het vervangen van tekst de opmaak?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replacetext/) en [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/replaceregex/) wijzigen de gevonden tekst binnen het bestaande tekstframe en behouden de opmaak van de omliggende delen. Als een overeenkomst delen met verschillende opmaak overspant, inspecteer dan het resultaat om te verzekeren dat de vervanging de gewenste stijl gebruikt.