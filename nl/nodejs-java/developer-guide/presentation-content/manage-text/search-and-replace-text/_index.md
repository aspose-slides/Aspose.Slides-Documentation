---
title: Zoeken en vervangen van tekst in PowerPoint‑presentaties in JavaScript
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
- tekstkader
- auditrapport
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Zoek, markeer en vervang tekst in PowerPoint‑presentaties terwijl u elke overeenkomst verzamelt met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides for Node.js via Java kan tekst zoeken, markeren en vervangen in een individueel tekstkader of in de volledige presentatie. Elke bewerking kan een applicatie ook op de hoogte stellen van elke overeenkomst via een resultaat‑callback. Dit maakt het mogelijk om een presentatie bij te werken en tegelijkertijd een audittrail op te bouwen met de gevonden tekst, de context, positie, het tekstkader en het slide‑nummer.

Deze mogelijkheden zijn nuttig voor herziening, redactie, terminologiecontroles, sjabloonsopschoning en geautomatiseerde rapportage‑workflows.

In de eerste voorbeelden hieronder gebruiken we een bestand met de naam "sample.pptx", dat een enkele tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

## **Kies de zoekscope**

Gebruik methoden op [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) om een bewerking te beperken tot één tekstkader. Gebruik methoden op [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) om alle toepasselijke tekst in de presentatie te verwerken.

| Bewerking | Één tekstkader | Volledige presentatie |
|---|---|---|
| Markeer letterlijke tekst | [TextFrame.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Markeer reguliere‑expressie‑overeenkomsten | [TextFrame.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Vervang letterlijke tekst | [TextFrame.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Vervang reguliere‑expressie‑overeenkomsten | [TextFrame.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configureer tekstmatching**

Voor bewerkingen met letterlijke tekst, gebruik [TextSearchOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/) om de overeenkomsten te sturen:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) beperkt overeenkomsten tot volledige woorden.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) regelt of hoofdlettergebruik moet overeenkomen.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) voegt dia‑notities toe aan zoek-, vervang‑ en markeerbewerkingen op presentatieniveau.

Reguliere‑expressie‑bewerkingen gebruiken een Java `Pattern`, waardoor regels voor overeenkomsten zoals hoofdlettergevoeligheid en woordgrenzen worden gedefinieerd door de expressie en de bijbehorende vlaggen.

## **Identificeer de eigenaar van een tekstkader**

Generieke tekstverwerkingsworkflows ontvangen vaak een [TextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/) tijdens het zoeken, vervangen, valideren of exporteren van tekst. Gebruik [TextFrame.getParentShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentShape--) en [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentCell--) om te bepalen welk presentatie‑object eigenaar is van het tekstkader.

De verwachte waarden hangen af van de eigenaar:

| Eigenaar van tekstkader | `getParentShape` | `getParentCell` |
|---|---|---|
| Een AutoShape of een andere vorm die tekst bevat | De eigenaar‑[Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/) | `null` |
| Een tabelcel | `null` | De eigenaar‑[Cell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cell/) |

Beide methoden bieden alleen‑lezen navigatie. Het aanroepen ervan verplaatst het tekstkader niet en wijzigt de eigenaar niet. Generieke code moet beide waarden op `null` controleren en rekening houden met de mogelijkheid dat geen enkele eigenaar beschikbaar is.

Het onderstaande voorbeeld gebruikt [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) om door de tekstkaders in een presentatie te itereren. Voor vormen geeft het de vormnaam, het Java‑runtime‑type en de bijbehorende dia weer. Voor tabelcellen geeft het de nul‑gebaseerde kolom‑ en rij‑coördinaten en de bijbehorende dia weer.

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

Voor SmartArt‑inhoud, doorloop de vormen in [SmartArtNode.getShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartnode/#getShapes--) en krijg toegang tot elke [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). Het tekstkader kan worden getraceerd naar de bijbehorende vorm via [TextFrame.getParentShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentShape--), terwijl [TextFrame.getParentCell](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getParentCell--) `null` retourneert. Daarom behandelt de vorm‑tak in het voorbeeld ook tekst van SmartArt‑knopen.

## **Verzamel overeenkomstinformatie met een callback**

Maak een Java‑proxy voor de resultaat‑callback om een melding te ontvangen voor elke overeenkomst. De proxy‑functie ontvangt het betreffende tekstkader, de brontekst, de gevonden tekst en de positie van de overeenkomst.

De callback ontvangt niet direct een slidennummer. De onderstaande implementatie haalt dit af via de eigenaar‑vorm of -cel van het tekstkader, met [TextFrame.getSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getSlide--) als fallback. Het verwerkt ook tekst die wordt gevonden in dia‑notities.

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

Voor vervangingsbewerkingen bevat `foundText` de oorspronkelijk gevonden tekst, zodat de callback exact kan vastleggen welke termen zijn vervangen.

## **Markeer tekst**

Gebruik de methode [TextFrame.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) om letterlijke‑tekstovereenkomsten in een tekstkader te markeren. Geef [TextSearchOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/) door om de zoekopdracht te sturen.

Het onderstaande codevoorbeeld markeert alle voorkomen van de tekens **"try"** en markeert daarna alleen het volledige woord **"to"**.

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

    // Markeer elke keer dat "try" voorkomt in het tekstkader.
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

![De gemarkeerde tekst](highlighted_text.png)

## **Markeer tekst met reguliere expressies**

De methode [TextFrame.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) markeert tekstovereenkomsten die door een reguliere expressie in een tekstkader worden gevonden.

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

![De gemarkeerde tekst met de reguliere expressie](highlighted_text_using_regex.png)

## **Markeer tekst in een hele presentatie**

Gebruik [Presentation.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [Presentation.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) om alle toepasselijke tekstkaders in een presentatie te doorzoeken. Het onderstaande voorbeeld markeert een letterlijke term en alle e‑mailadressen:

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

## **Vervang tekst in een tekstkader**

Gebruik [TextFrame.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) voor letterlijke tekst en [TextFrame.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) voor patroon‑gebaseerde vervanging. Deze methoden werken de gevonden tekst bij binnen het bestaande tekstkader, waarbij de opmaak van de omliggende delen behouden blijft in plaats van het tekstkader opnieuw op te bouwen vanuit een platte tekenreeks.

Het onderstaande voorbeeld normaliseert een spellingvariant en vervangt vervolgens versielabels:

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

Als één overeenkomst delen met verschillende opmaak overspant, controleer dan de output om te bevestigen welke opmaak op de vervangende tekst moet worden toegepast.

## **Vervang tekst in een hele presentatie**

Gebruik [Presentation.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [Presentation.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) om dezelfde bewerkingen over de hele presentatie toe te passen. Dit is nuttig voor sjabloonsopschoning, terminologie‑updates en redacties.

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

## **Groepeer overeenkomsten voor rapportage**

Aangezien elk verzameld resultaat zijn slidennummer en tekstkader opslaat, kunnen applicaties overeenkomsten groeperen voor audit‑, rapportage‑ of beoordelingsworkflows. Het onderstaande voorbeeld groepeert de resultaten eerst per dia en daarna per tekstkader:

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

**Hoe kan ik slechts één tekstvak doorzoeken in plaats van de volledige presentatie?**

Haal het tekstkader van de vorm op en roep daarop [TextFrame.highlightText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) of [TextFrame.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) aan. Methoden op presentatieniveau verwerken alle toepasselijke tekstkaders.

**Hoe kan ik volledige woorden met de juiste hoofdlettervorm vinden?**

Stel [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) en [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) in op `true`, en geef de opties door aan een letterlijke‑tekst markeer‑ of vervangingsmethode. Voor reguliere expressies definieer je woordgrenzen en hoofdlettergevoeligheid in de Java `Pattern` zelf.

**Kunnen zoeken en vervangen tekst uit dia‑notities omvatten?**

Ja. Stel [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) in op `true` bij het gebruik van een letterlijke‑tekst bewerking op presentatieniveau. De hierboven getoonde callback‑implementatie brengt een overeenkomst in een notitiesdia terug naar het bijbehorende slidennummer.

**Hoe kan ik een rapport maken zonder de presentatie een tweede keer te scannen?**

Geef een Java‑resultaat‑callback‑proxy door aan de markeer‑ of vervangingsbewerking. De callback ontvangt elke overeenkomst terwijl de bewerking loopt, zodat de applicatie de brontekst, gevonden tekst, positie, tekstkader en afgeleid slidennummer kan opslaan voor later groeperen of exporteren.

**Behoudt het vervangen van tekst de opmaak?**

[TextFrame.replaceText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) en [TextFrame.replaceRegex](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) wijzigen de gevonden tekst binnen het bestaande tekstkader en behouden de opmaak van de omliggende delen. Als een overeenkomst delen met verschillende opmaak overspant, inspecteer dan het resultaat om er zeker van te zijn dat de vervanging de gewenste stijl gebruikt.