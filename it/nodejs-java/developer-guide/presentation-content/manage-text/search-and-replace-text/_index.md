---
title: Cerca e sostituisci testo nelle presentazioni PowerPoint in JavaScript
linktitle: Cerca e sostituisci testo
type: docs
weight: 55
url: /it/nodejs-java/search-and-replace-text/
keywords:
- ricerca testo
- evidenzia testo
- sostituzione testo
- espressione regolare
- callback risultato
- riquadro di testo
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

Aspose.Slides per Node.js tramite Java può cercare, evidenziare e sostituire testo in un singolo riquadro di testo o in tutta la presentazione. Ogni operazione può anche notificare un'applicazione su ogni corrispondenza tramite una callback di risultato. Questo consente di aggiornare una presentazione e simultaneamente creare un registro di audit contenente il testo corrispondente, il suo contesto, posizione, riquadro di testo e numero della diapositiva.

Queste funzionalità sono utili per revisioni, redazioni, controlli terminologici, pulizia di modelli e flussi di lavoro di reporting automatizzato.

Nei primi esempi seguenti, utilizziamo un file chiamato "sample.pptx", che contiene un unico riquadro di testo nella prima diapositiva con il seguente testo:

![Sample text](sample_text.png)

## **Scegliere l'ambito di ricerca**

Usa i metodi su [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) per limitare un'operazione a un singolo riquadro di testo. Usa i metodi su [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un riquadro di testo | Intera presentazione |
|---|---|---|
| Highlight literal text | [TextFrame.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [TextFrame.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [TextFrame.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [TextFrame.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurare la corrispondenza del testo**

Per le operazioni di testo letterale, usa [TextSearchOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/) per controllare la corrispondenza:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limita le corrispondenze a parole intere.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) controlla se il caso dei caratteri deve corrispondere.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) include le note della diapositiva nelle operazioni di ricerca, sostituzione e evidenziazione a livello di presentazione.

Le operazioni con espressioni regolari utilizzano un `Pattern` Java, quindi regole come la sensibilità al caso e i confini di parola sono definite dall'espressione e dalle sue flag.

## **Identificare il proprietario di un riquadro di testo**

I flussi di lavoro generici di elaborazione del testo spesso ricevono un [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/) mentre cercano, sostituiscono, convalidano o esportano testo. Usa [TextFrame.getParentShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentShape--) e [TextFrame.getParentCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentCell--) per determinare quale oggetto della presentazione possiede il riquadro di testo.

I valori attesi dipendono dal proprietario:

| Proprietario del riquadro di testo | `getParentShape` | `getParentCell` |
|---|---|---|
| Un AutoShape o un'altra forma contenente testo | The owning [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) | `null` |
| Una cella di tabella | `null` | The owning [Cell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/cell/) |

Entrambi i metodi forniscono navigazione in sola lettura. Chiamarli non sposta il riquadro di testo né ne cambia il proprietario. Il codice generico dovrebbe verificare entrambi i valori per `null` e gestire la possibilità che nessuno dei due proprietari sia disponibile.

L'esempio seguente utilizza [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) per iterare sui riquadri di testo in una presentazione. Per le forme, segnala il nome della forma, il tipo runtime Java e la diapositiva contenente. Per le celle della tabella, segnala le coordinate colonna e riga a base zero e la diapositiva contenente.

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

Per il contenuto SmartArt, itera sulle forme in [SmartArtNode.getShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartnode/#getShapes--) e accedi a ciascuna [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). Il riquadro di testo può essere tracciato alla forma associata tramite [TextFrame.getParentShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentShape--), mentre [TextFrame.getParentCell](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getParentCell--) restituisce `null`. Pertanto, il ramo della forma nell'esempio gestisce anche il testo proveniente da nodi SmartArt.

## **Raccogliere le informazioni delle corrispondenze con una callback**

Crea un proxy Java per la callback di risultato per ricevere una notifica per ogni corrispondenza. La funzione proxy riceve il riquadro di testo correlato, il testo sorgente, il testo corrispondente e la posizione della corrispondenza.

La callback non riceve direttamente il numero della diapositiva. L'implementazione sotto lo ricava attraverso la forma o la cella di tabella proprietaria del riquadro di testo, con [TextFrame.getSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#getSlide--) come fallback. Gestisce inoltre il testo trovato nelle note della diapositiva.

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

Per le operazioni di sostituzione, `foundText` contiene il testo originale corrispondente, quindi la callback può registrare esattamente quali termini sono stati sostituiti.

## **Evidenziare il testo**

Usa il metodo [TextFrame.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) per evidenziare le corrispondenze di testo letterale in un riquadro di testo. Passa [TextSearchOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/) per controllare la ricerca.

Il codice di esempio sotto evidenzia tutte le occorrenze dei caratteri **"try"** e poi evidenzia solo la parola intera **"to"**.

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

    // Evidenzia ogni occorrenza di "try" nel riquadro di testo.
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

## **Evidenziare il testo usando espressioni regolari**

Il metodo [TextFrame.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) evidenzia le corrispondenze di testo trovate da un'espressione regolare in un riquadro di testo.

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

Usa [Presentation.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) per cercare tutti i riquadri di testo applicabili in una presentazione. L'esempio seguente evidenzia un termine letterale e tutti gli indirizzi email:

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

## **Sostituire il testo in un riquadro di testo**

Usa [TextFrame.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) per testo letterale e [TextFrame.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) per sostituzione basata su pattern. Questi metodi aggiornano il testo corrispondente all'interno del riquadro esistente, mantenendo la formattazione delle parti circostanti invece di ricostruire il riquadro da una stringa semplice.

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

Se una corrispondenza attraversa porzioni con formattazioni diverse, controlla il risultato per confermare quale formattazione dovrebbe essere applicata al testo sostituito.

## **Sostituire il testo in tutta la presentazione**

Usa [Presentation.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [Presentation.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) per applicare le stesse operazioni a livello di presentazione. Questo è utile per la pulizia dei modelli, aggiornamenti terminologici e redazioni.

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

Poiché ogni risultato raccolto memorizza il numero della diapositiva e il riquadro di testo, le applicazioni possono raggruppare le corrispondenze per audit, reporting o flussi di revisione. L'esempio seguente raggruppa i risultati prima per diapositiva e poi per riquadro di testo:

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

**Come posso cercare solo in una casella di testo invece che in tutta la presentazione?**

Ottieni il riquadro di testo della forma e chiama [TextFrame.highlightText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), o [TextFrame.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) su quel riquadro di testo. I metodi a livello di presentazione elaborano tutti i riquadri di testo applicabili.

**Come posso far corrispondere parole intere con la corretta capitalizzazione?**

Imposta [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) e [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) su `true`, e passa le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al caso direttamente nel `Pattern` Java.

**La ricerca e la sostituzione possono includere il testo nelle note delle diapositive?**

Sì. Imposta [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) su `true` quando utilizzi un'operazione di testo letterale a livello di presentazione. L'implementazione della callback mostrata sopra mappa una corrispondenza in una diapositiva di note al numero della diapositiva padre.

**Come posso creare un report senza scansionare la presentazione una seconda volta?**

Passa un proxy Java per la callback di risultato all'operazione di evidenziazione o sostituzione. La callback riceve ogni corrispondenza durante l'esecuzione, così l'applicazione può memorizzare il testo sorgente, il testo corrispondente, la posizione, il riquadro di testo e il numero della diapositiva derivato per successivi raggruppamenti o esportazioni.

**La sostituzione del testo preserva la formattazione?**

[TextFrame.replaceText](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) e [TextFrame.replaceRegex](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modificano il testo corrispondente all'interno del riquadro esistente e mantengono la formattazione delle parti circostanti. Se una corrispondenza attraversa porzioni con formattazioni diverse, esamina il risultato per assicurarti che la sostituzione utilizzi lo stile desiderato.