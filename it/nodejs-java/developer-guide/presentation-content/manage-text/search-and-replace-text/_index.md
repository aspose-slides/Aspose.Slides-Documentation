---
title: Cerca e sostituisci testo nelle presentazioni PowerPoint in JavaScript
linktitle: Cerca e sostituisci testo
type: docs
weight: 55
url: /it/nodejs-java/search-and-replace-text/
keywords:
- ricerca testo
- evidenzia testo
- sostituisci testo
- espressione regolare
- callback risultato
- frame di testo
- rapporto di audit
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Cerca, evidenzia e sostituisci testo nelle presentazioni PowerPoint raccogliendo ogni corrispondenza con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Aspose.Slides for Node.js via Java può cercare, evidenziare e sostituire testo in un singolo frame di testo oppure in un'intera presentazione. Ogni operazione può anche notificare un'applicazione per ogni corrispondenza tramite una callback di risultato. Questo consente di aggiornare una presentazione e al contempo costruire un registro di audit contenente il testo corrispondente, il suo contesto, la posizione, il frame di testo e il numero della diapositiva.

Queste funzionalità sono utili per revisioni, redazioni, controlli di terminologia, pulizia di modelli e flussi di lavoro di reporting automatizzati.

Nei primi esempi seguenti, utilizziamo un file chiamato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente testo:

![Testo di esempio](sample_text.png)

## **Scegli l'ambito della ricerca**

Usa i metodi su [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) per limitare un'operazione a un singolo frame di testo. Usa i metodi su [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un frame di testo | Intera presentazione |
|---|---|---|
| Evidenziare testo letterale | [TextFrame.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Evidenziare corrispondenze di espressioni regolari | [TextFrame.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Sostituire testo letterale | [TextFrame.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Sostituire corrispondenze di espressioni regolari | [TextFrame.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurare la corrispondenza del testo**

Per le operazioni su testo letterale, usa [TextSearchOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/) per controllare la corrispondenza:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita le corrispondenze a parole intere.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controlla se il caso dei caratteri deve corrispondere.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) include le note delle diapositive nelle operazioni di ricerca, sostituzione e evidenziazione a livello di presentazione.

Le operazioni con espressioni regolari utilizzano un `Pattern` Java, pertanto le regole di corrispondenza come sensibilità al caso e confini di parola sono definite dall'espressione e dai suoi flag.

## **Raccogliere le informazioni sui risultati con una callback**

Crea un proxy Java per la callback di risultato per ricevere una notifica per ogni corrispondenza. La funzione proxy riceve il frame di testo correlato, il testo sorgente, il testo trovato e la posizione della corrispondenza.

La callback non riceve direttamente un numero di diapositiva. L'implementazione seguente lo ricava tramite [TextFrame.getSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getSlideNumber--), e [NotesSlide.getParentSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/notesslide/#getParentSlide--). Gestisce inoltre il testo trovato nelle note delle diapositive.

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

Per le operazioni di sostituzione, `foundText` contiene il testo originale corrispondente, così la callback può registrare esattamente quali termini sono stati sostituiti.

## **Evidenziare il testo**

Usa il metodo [TextFrame.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) per evidenziare le corrispondenze di testo letterale in un frame di testo. Passa [TextSearchOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/) per controllare la ricerca.

L'esempio di codice sotto evidenzia tutte le occorrenze della stringa **"try"** e poi evidenzia solo la parola intera **"to"**.

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

    // Evidenzia ogni occorrenza di "try" nel frame di testo.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Evidenzia solo la parola completa "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenziare il testo usando le espressioni regolari**

Il metodo [TextFrame.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) evidenzia le corrispondenze di testo trovate da un'espressione regolare in un frame di testo.

Il codice seguente evidenzia tutte le parole contenenti sette o più caratteri:

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

Il risultato:

![Il testo evidenziato usando l'espressione regolare](highlighted_text_using_regex.png)

## **Evidenziare il testo in tutta la presentazione**

Usa [Presentation.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) per cercare tutti i frame di testo applicabili in una presentazione. L'esempio seguente evidenzia un termine letterale e tutti gli indirizzi email:

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

## **Sostituire il testo in un frame di testo**

Usa [TextFrame.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) per testo letterale e [TextFrame.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) per sostituzioni basate su pattern. Questi metodi aggiornano il testo corrispondente all'interno del frame di testo esistente, mantenendo la formattazione della porzione circostante invece di ricostruire il frame di testo da una stringa semplice.

L'esempio seguente standardizza una variante ortografica e poi sostituisce le etichette di versione:

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

Se una corrispondenza copre porzioni con formattazioni diverse, controlla l'output per confermare quale formattazione applicare al testo sostituito.

## **Sostituire il testo in tutta la presentazione**

Usa [Presentation.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) per applicare le stesse operazioni a tutta la presentazione. Questo è utile per pulizia di modelli, aggiornamenti di terminologia e redazione.

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

## **Raggruppare le corrispondenze per la reportistica**

Poiché ogni risultato raccolto memorizza il numero della diapositiva e il frame di testo, le applicazioni possono raggruppare le corrispondenze per audit, reporting o flussi di lavoro di revisione. L'esempio seguente raggruppa i risultati prima per diapositiva e poi per frame di testo:

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

**Come posso cercare solo una casella di testo anziché l'intera presentazione?**

Ottieni il frame di testo della forma e chiama [TextFrame.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), o [TextFrame.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) su quel frame di testo. I metodi a livello di presentazione elaborano tutti i frame di testo applicabili.

**Come posso far corrispondere parole intere con la corretta capitalizzazione?**

Imposta [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) e [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) su `true`, e passa le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al caso direttamente nel `Pattern` Java.

**La ricerca e la sostituzione possono includere il testo nelle note delle diapositive?**

Sì. Imposta [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) su `true` quando usi un'operazione di testo letterale a livello di presentazione. L'implementazione della callback mostrata sopra associa una corrispondenza in una nota alla diapositiva madre.

**Come posso creare un report senza scansionare nuovamente la presentazione?**

Passa un proxy Java per la callback di risultato all'operazione di evidenziazione o sostituzione. La callback riceve ogni corrispondenza mentre l'operazione è in corso, così l'applicazione può memorizzare il testo sorgente, il testo trovato, la posizione, il frame di testo e il numero di diapositiva derivato per successivi raggruppamenti o esportazioni.

**La sostituzione del testo preserva la sua formattazione?**

[TextFrame.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [TextFrame.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modificano il testo corrispondente all'interno del frame di testo esistente e mantengono la formattazione della porzione circostante. Se una corrispondenza copre parti con formattazioni diverse, verifica il risultato per assicurarti che la sostituzione utilizzi lo stile desiderato.