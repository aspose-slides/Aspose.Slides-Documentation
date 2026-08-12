---
title: Zoeken en vervangen van tekst in PowerPoint-presentaties in JavaScript
linktitle: Zoeken en vervangen van tekst
type: docs
weight: 55
url: /nl/nodejs-java/search-and-replace-text/
keywords:
- tekst zoeken
- tekst markeren
- tekst vervangen
- reguliere expressie
- resultaat‑callback
- tekstframe
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Zoeken, markeren en vervangen van tekst in PowerPoint-presentaties terwijl elke overeenkomst wordt verzameld met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides voor Node.js via Java kan zoeken, markeren en tekst vervangen in een individueel tekstframe of in een volledige presentatie. Elke bewerking kan ook een toepassing op de hoogte stellen van elke overeenkomst via een result-callback. Hierdoor is het mogelijk om een presentatie bij te werken en tegelijkertijd een audittrail op te bouwen die de gevonden tekst, de context, positie, het tekstframe en het dia-nummer bevat.

Deze mogelijkheden zijn nuttig voor beoordeling, redactie, terminologiecontroles, sjabloon-opschoning en geautomatiseerde rapportage-workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand genaamd "sample.pptx", dat een enkele tekstvak op de eerste dia bevat met de volgende tekst:

![Sample text](sample_text.png)

## **Kies de zoekscope**

Gebruik de methoden op [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) om een bewerking te beperken tot één tekstframe. Gebruik de methoden op [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerking | Eén tekstframe | Gehele presentatie |
|---|---|---|
| Markeer letterlijke tekst | [TextFrame.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Markeer reguliere-expressie‑overeenkomsten | [TextFrame.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Vervang letterlijke tekst | [TextFrame.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Vervang reguliere-expressie‑overeenkomsten | [TextFrame.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configureer tekstmatching**

Voor bewerkingen met letterlijke tekst, gebruik [TextSearchOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/) om het matchen te regelen:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) beperkt overeenkomsten tot volledige woorden.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) bepaalt of hoofdlettergebruik moet overeenkomen.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) neemt dia-notities op in zoek-, vervang- en markeerbewerkingen op presentatieniveau.

Reguliere-expressie-bewerkingen gebruiken een Java `Pattern`, dus de regels voor overeenkomsten, zoals hoofdlettergevoeligheid en woordgrenzen, worden gedefinieerd door de expressie en de bijbehorende vlaggen.

## **Verzamel matchinformatie met een callback**

Maak een Java-proxy voor de result-callback om een melding te ontvangen voor elke overeenkomst. De proxy-functie ontvangt het bijbehorende tekstframe, de brontekst, de gevonden tekst en de positie van de overeenkomst.

De callback ontvangt niet direct een dia-nummer. De onderstaande implementatie haalt dit af via [TextFrame.getSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getSlideNumber--), en [NotesSlide.getParentSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/notesslide/#getParentSlide--). Het verwerkt ook tekst die in dia-notities is gevonden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

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

Voor vervangingsbewerkingen bevat `foundText` de oorspronkelijke gevonden tekst, zodat de callback exact kan registreren welke termen zijn vervangen.

## **Markeer tekst**

Gebruik de methode [TextFrame.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) om letterlijke-tekst-overeenkomsten in een tekstframe te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/) door om de zoekopdracht te regelen.

Het codevoorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en markeert vervolgens alleen het volledige woord **"to"**.

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

    // Markeer elk voorkomen van "try" in het tekstframe.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Markeer alleen het volledige woord "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![The highlighted text](highlighted_text.png)

## **Markeer tekst met reguliere expressies**

De methode [TextFrame.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) markeert tekstovereenkomsten die gevonden zijn met een reguliere expressie in een tekstframe.

De volgende code markeert alle woorden die zeven of meer tekens bevatten:

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

Het resultaat:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Markeer tekst in een volledige presentatie**

Gebruik [Presentation.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [Presentation.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) om alle toepasselijke tekstframes in een presentatie te doorzoeken. Het volgende voorbeeld markeert een letterlijke term en alle e-mailadressen:

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

## **Vervang tekst in een tekstframe**

Gebruik [TextFrame.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) voor letterlijke tekst en [TextFrame.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) voor patroon-gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstframe, waardoor de opmaak van de omringende delen behouden blijft in plaats van het tekstframe opnieuw op te bouwen uit een platte string.

Het volgende voorbeeld standaardiseert een spellingvariant en vervangt vervolgens versielabels:

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

Als één overeenkomst delen met verschillende opmaak omvat, bekijk dan de output om te bevestigen welke opmaak op de vervangende tekst moet worden toegepast.

## **Vervang tekst in een volledige presentatie**

Gebruik [Presentation.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [Presentation.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) om dezelfde bewerkingen over de hele presentatie toe te passen. Dit is nuttig voor sjabloon-opschoning, terminologie-updates en redactie.

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

## **Groeperen van matches voor rapportage**

Omdat elk verzameld resultaat het dia-nummer en tekstframe opslaat, kunnen toepassingen matches groeperen voor audit, rapportage of beoordelingsworkflows. Het volgende voorbeeld groepeert de resultaten eerst per dia en vervolgens per tekstframe:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentSlide = textFrame.getSlide();

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

**Hoe kan ik zoeken in slechts één tekstvak in plaats van de volledige presentatie?**

Haal het tekstframe van de vorm op en roep [TextFrame.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), of [TextFrame.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) aan op dat tekstframe. Methoden op presentatieniveau verwerken alle toepasselijke tekstframes.

**Hoe kan ik volledige woorden matchen met de juiste hoofdlettergebruik?**

Stel [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) en [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) in op `true` en geef de opties door aan een letterlijke-tekst-markeer- of vervangingsmethode. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de Java `Pattern` zelf.

**Kunnen zoeken en vervangen tekst in dia-notities omvatten?**

Ja. Stel [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) in op `true` wanneer je een letterlijke-tekst-bewerking op presentatieniveau gebruikt. De hierboven getoonde callback-implementatie mappt een overeenkomst in een notitieslide terug naar het bijbehorende dia-nummer.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een Java-result-callback-proxy door aan de markeer- of vervangingsbewerking. De callback ontvangt elke overeenkomst terwijl de bewerking loopt, zodat de toepassing de brontekst, gevonden tekst, positie, tekstframe en afgeleide dia-nummer kan opslaan voor latere groepering of export.

**Behoudt vervanging van tekst de opmaak?**

[TextFrame.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [TextFrame.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) wijzigen de gevonden tekst binnen het bestaande tekstframe en behouden de opmaak van de omringende delen. Als een overeenkomst delen met verschillende opmaak omvat, inspecteer dan het resultaat om er zeker van te zijn dat de vervanging de gewenste stijl gebruikt.