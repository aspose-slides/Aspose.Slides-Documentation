---
title: Sök och ersätt text i PowerPoint-presentationer i JavaScript
linktitle: Sök och ersätt text
type: docs
weight: 55
url: /sv/nodejs-java/search-and-replace-text/
keywords:
- sök text
- markera text
- ersätt text
- reguljärt uttryck
- resultat callback
- textruta
- revisionsrapport
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Sök, markera och ersätt text i PowerPoint-presentationer samtidigt som du samlar varje matchning med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides för Node.js via Java kan söka, markera och ersätta text i en enskild textruta eller i hela en presentation. Varje operation kan även meddela en applikation om varje matchning via ett result callback. Detta gör det möjligt att uppdatera en presentation och samtidigt bygga ett revisionsspår som innehåller den matchade texten, dess sammanhang, position, textruta och bildnummer.

Dessa funktioner är användbara för granskning, redigering, terminologikontroller, mallrengöring och automatiserade rapporteringsarbetsflöden.

I de första exemplen nedan använder vi en fil med namnet "sample.pptx" som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Välj söksområde**

Använd metoder på [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) för att begränsa en operation till en textruta. Använd metoder på [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) för att bearbeta all tillämplig text i presentationen.

| Operation | En textruta | Hela presentationen |
|---|---|---|
| Highlight literal text | [TextFrame.highlightText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [TextFrame.highlightRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [TextFrame.replaceText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [TextFrame.replaceRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurera textmatchning**

För operationer med exakt text, använd [TextSearchOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textsearchoptions/) för att styra matchning:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) begränsar matchningar till hela ord.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) kontrollerar om teckenkänslighet måste matcha.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inkluderar bildanteckningar i sök-, ersättnings- och markeringsoperationer på presentationsnivå.

Operationer med reguljära uttryck använder en Java `Pattern`, så matchningsregler såsom skiftlägeskänslighet och ordgränser definieras av själva uttrycket och dess flaggor.

## **Identifiera ägaren till en textruta**

Generiska textbehandlingsarbetsflöden får ofta en [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) när de söker, ersätter, validerar eller exporterar text. Använd [TextFrame.getParentShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentShape--) och [TextFrame.getParentCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentCell--) för att avgöra vilket presentationsobjekt som äger textrutan.

De förväntade värdena beror på ägaren:

| Ägare av textruta | `getParentShape` | `getParentCell` |
|---|---|---|
| En AutoShape eller en annan textinnehållande form | Den ägande [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/) | `null` |
| En tabellcell | `null` | Den ägande [Cell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cell/) |

Båda metoderna ger skrivskyddad navigering. Att anropa dem flyttar inte textrutan eller ändrar dess ägare. Generisk kod bör kontrollera båda värdena för `null` och hantera möjligheten att ingen ägare är tillgänglig.

Följande exempel använder [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) för att iterera genom textrutorna i en presentation. För former rapporterar den formens namn, Java‑körtidstyp och innehållande bild. För tabellceller rapporterar den kolumn‑ och radräkning med nollbas och den innehållande bilden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

För SmartArt‑innehåll, iterera genom formerna i [SmartArtNode.getShapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartnode/#getShapes--) och åtkomst varje [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). Textrutan kan spåras till sin tillhörande form via [TextFrame.getParentShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentShape--), medan [TextFrame.getParentCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getParentCell--) returnerar `null`. Därför hanterar även grenformen i exemplet text från SmartArt‑noder.

## **Samla matchningsinformation med en callback**

Skapa en Java‑proxy för result callback för att ta emot en avisering för varje matchning. Proxy‑funktionen får den relaterade textrutan, källtexten, den matchade texten och matchningspositionen.

Callback‑en får inte ett bildnummer direkt. Implementeringen nedan härleder det via textrutans ägande form eller tabellcell, med [TextFrame.getSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getSlide--) som reserv. Den hanterar även text som hittas i bildanteckningar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

För ersättningsoperationer innehåller `foundText` den ursprungliga matchade texten, så callback‑en kan registrera exakt vilka termer som ersattes.

## **Markera text**

Använd metoden [TextFrame.highlightText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för att markera exakta textmatchningar i en textruta. Skicka [TextSearchOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textsearchoptions/) för att styra sökningen.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Markera varje förekomst av "try" i textrutan.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Markera endast hela ordet "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [TextFrame.highlightRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) markerar textramsmatchningar som hittas med ett reguljärt uttryck i en textruta.

Följande kod markerar alla ord som innehåller sju eller fler tecken:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Markera text i hela en presentation**

Använd [Presentation.highlightText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [Presentation.highlightRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) för att söka i alla tillämpliga textrutor i en presentation. Följande exempel markerar ett exakt uttryck och alla e‑postadresser:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ersätt text i en textruta**

Använd [TextFrame.replaceText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) för exakt text och [TextFrame.replaceRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för mönsterbaserad ersättning. Dessa metoder uppdaterar den matchade texten inom den befintliga textrutan, vilket behåller formateringen av omgivande delar istället för att bygga om textrutan från en ren sträng.

Följande exempel standardiserar en stavningsvariant och ersätter sedan versionsetiketter:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om en matchning spänner över delar med olika formatering, granska resultatet för att bekräfta vilken formatering som ska tillämpas på den ersatta texten.

## **Ersätt text i hela en presentation**

Använd [Presentation.replaceText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [Presentation.replaceRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) för att tillämpa samma operationer i hela presentationen. Detta är användbart för mallrengöring, terminologiuppdateringar och redigering.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gruppera matchningar för rapportering**

Eftersom varje insamlad result lagrar sitt bildnummer och sin textruta kan applikationer gruppera matchningar för revision, rapportering eller granskningsarbetsflöden. Följande exempel grupperar resultaten först efter bild och sedan efter textruta:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Hur kan jag söka i endast en textruta istället för hela presentationen?**

Hämta formens textruta och anropa [TextFrame.highlightText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), eller [TextFrame.replaceRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) på den textrutan. Metoder på presentationsnivå bearbetar alla tillämpliga textrutor istället.

**Hur kan jag matcha hela ord med korrekt versalisering?**

Ställ in [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) och [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) till `true` och skicka alternativen till en metod för exakta textmarkering eller -ersättning. För reguljära uttryck, definiera ordgränser och skiftlägeskänslighet i själva Java `Pattern`‑en.

**Kan sökning och ersättning inkludera text i bildanteckningar?**

Ja. Ställ in [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) till `true` när du använder en exaktsökning på presentationsnivå. Callback‑implementeringen ovan mappar en matchning i en anteckningsbild tillbaka till dess föräldrabildsnummer.

**Hur kan jag skapa en rapport utan att skanna presentationen en andra gång?**

Skicka en Java‑result‑callback‑proxy till markerings‑ eller ersättningsoperationen. Callback‑en får varje matchning medan operationen körs, så applikationen kan lagra källtexten, den matchade texten, positionen, textrutan och härledda bildnumret för senare gruppering eller export.

**Behåller ersättning av text dess formatering?**

[TextFrame.replaceText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) och [TextFrame.replaceRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ändrar den matchade texten inom den befintliga textrutan och behåller formateringen av omgivande delar. Om en matchning spänner över delar med olika formatering, inspektera resultatet för att säkerställa att ersättningen använder önskad stil.