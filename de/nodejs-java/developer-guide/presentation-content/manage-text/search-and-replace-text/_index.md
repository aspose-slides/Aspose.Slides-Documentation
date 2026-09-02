---
title: "Suchen und Ersetzen von Text in PowerPoint-Präsentationen in JavaScript"
linktitle: "Suchen und Ersetzen von Text"
type: docs
weight: 55
url: /de/nodejs-java/search-and-replace-text/
keywords:
- Text suchen
- Text hervorheben
- Text ersetzen
- regulärer Ausdruck
- Ergebnis-Callback
- Textfeld
- Prüfbericht
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Text in PowerPoint-Präsentationen suchen, hervorheben und ersetzen und dabei jede Übereinstimmung mit Aspose.Slides for Node.js via Java sammeln."
---
## **Übersicht**

Aspose.Slides for Node.js via Java kann Text in einem einzelnen Textfeld oder in der gesamten Präsentation suchen, hervorheben und ersetzen. Jeder Vorgang kann außerdem eine Anwendung über jedes gefundene Ergebnis über einen Ergebnis‑Callback benachrichtigen. Dadurch ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, Textfeld und Foliennummer enthält.

Diese Funktionen sind nützlich für Überprüfung, Schwärzung, Terminologie‑Prüfungen, Vorlagen‑Bereinigung und automatisierte Reporting‑Workflows.

In den nachfolgenden ersten Beispielen verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich auswählen**

Verwenden Sie Methoden auf [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) um einen Vorgang auf ein Textfeld zu beschränken. Verwenden Sie Methoden auf [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) um allen anwendbaren Text in der Präsentation zu verarbeiten.

| Operation | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| Wörtlichen Text hervorheben | [TextFrame.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Regex‑Übereinstimmungen hervorheben | [TextFrame.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Wörtlichen Text ersetzen | [TextFrame.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Regex‑Übereinstimmungen ersetzen | [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Textabgleich konfigurieren**

Für Vorgänge mit wörtlichem Text verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/), um die Übereinstimmung zu steuern:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) begrenzt Übereinstimmungen auf ganze Wörter.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) steuert, ob die Groß‑ und Kleinschreibung der Zeichen übereinstimmen muss.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) schließt Foliennotizen in suchbezugsspezifischen Such-, Ersetz‑ und Hervorhebungs‑Vorgängen ein.

Vorgänge mit regulären Ausdrücken verwenden ein Java‑`Pattern`, sodass Übereinstimmungsregeln wie Groß‑/Kleinschreibung und Wortgrenzen durch den Ausdruck und seine Flags definiert werden.

## **Match‑Informationen mittels Callback sammeln**

Erstellen Sie einen Java‑Proxy für den Ergebnis‑Callback, um für jede Übereinstimmung eine Benachrichtigung zu erhalten. Die Proxy‑Funktion erhält das zugehörige Textfeld, den Quelltext, den gefundenen Text und die Position der Übereinstimmung.

Der Callback erhält die Foliennummer nicht direkt. Die nachstehende Implementierung leitet sie über [TextFrame.getSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getSlide--), [Slide.getSlideNumber](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slide/#getSlideNumber--), und [NotesSlide.getParentSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/notesslide/#getParentSlide--) ab. Sie verarbeitet außerdem Text, der in Foliennotizen gefunden wird.

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

Bei Ersetz‑Vorgängen enthält `foundText` den original gefundenen Text, sodass der Callback exakt festhalten kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [TextFrame.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), um wörtliche Text‑Übereinstimmungen in einem Textfeld hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/) , um die Suche zu steuern.

Das nachstehende Code‑Beispiel hebt alle Vorkommen der Zeichen **"try"** hervor und markiert anschließend nur das vollständige Wort **"to"**.

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

    // Hebe jedes Vorkommen von "try" im Textfeld hervor.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Hebe nur das vollständige Wort "to" hervor.
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der hervorgehobene Text](highlighted_text.png)

## **Text mit regulären Ausdrücken hervorheben**

Die Methode [TextFrame.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) hebt Text‑Übereinstimmungen, die durch einen regulären Ausdruck gefunden wurden, in einem Textfeld hervor.

Der folgende Code hebt alle Wörter hervor, die sieben oder mehr Zeichen enthalten:

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

Das Ergebnis:

![Der hervorgehobene Text mit regulärem Ausdruck](highlighted_text_using_regex.png)

## **Text in einer Präsentation hervorheben**

Verwenden Sie [Presentation.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [Presentation.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), um alle anwendbaren Textfelder in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen wörtlichen Begriff und alle E‑Mail‑Adressen hervor:

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

## **Text in einem Textfeld ersetzen**

Verwenden Sie [TextFrame.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) für wörtlichen Text und [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) für ersetzungsbasierte Muster. Diese Methoden aktualisieren den gefundenen Text innerhalb des bestehenden Textfelds, wobei die umgebende Formatierung beibehalten wird, anstatt das Textfeld aus einem Klartext‑String neu zu erstellen.

Das folgende Beispiel standardisiert eine Schreibvarianten und ersetzt anschließend Versionsbezeichnungen:

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

Falls eine Übereinstimmung Abschnitte mit unterschiedlicher Formatierung umfasst, prüfen Sie die Ausgabe, um zu bestätigen, welche Formatierung auf den ersetzten Text angewendet werden soll.

## **Text in einer Präsentation ersetzen**

Verwenden Sie [Presentation.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [Presentation.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-), um dieselben Vorgänge in der gesamten Präsentation anzuwenden. Dies ist nützlich für die Vorlagen‑Bereinigung, Terminologie‑Aktualisierungen und Schwärzungen.

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

## **Übereinstimmungen für Berichte gruppieren**

Da jedes gesammelte Ergebnis seine Foliennummer und das Textfeld speichert, können Anwendungen Übereinstimmungen für Prüf‑, Bericht‑ oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die Ergebnisse zunächst nach Folie und anschließend nach Textfeld:

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

**Wie kann ich nur ein Textfeld anstatt der gesamten Präsentation durchsuchen?**

Rufen Sie das Textfeld der Form ab und rufen Sie [TextFrame.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), oder [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) für dieses Textfeld auf. Methoden auf Präsentationsebene verarbeiten alle anwendbaren Textfelder.

**Wie kann ich vollständige Wörter mit korrekter Groß‑ und Kleinschreibung abgleichen?**

Setzen Sie [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) und [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) auf `true` und übergeben Sie die Optionen an eine Methode zum Hervorheben oder Ersetzen von wörtlichem Text. Bei regulären Ausdrücken definieren Sie Wortgrenzen und Groß‑/Kleinschreibung im Java‑`Pattern` selbst.

**Können Suche und Ersetzung Text in Foliennotizen einschließen?**

Ja. Setzen Sie [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) auf `true`, wenn Sie eine wörtliche Text‑Operation auf Präsentationsebene verwenden. Die oben gezeigte Callback‑Implementierung ordnet eine Übereinstimmung in einer Notiz‑Folien zurück zur übergeordneten Foliennummer zu.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu durchsuchen?**

Übergeben Sie einen Java‑Ergebnis‑Callback‑Proxy an die Hervorhebungs‑ oder Ersetzungs‑Operation. Der Callback erhält jede Übereinstimmung während der Ausführung, sodass die Anwendung den Quelltext, den gefundenen Text, die Position, das Textfeld und die ermittelte Foliennummer für eine spätere Gruppierung oder den Export speichern kann.

**Wird bei der Textersetzung die Formatierung beibehalten?**

[TextFrame.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ändern den gefundenen Text innerhalb des bestehenden Textfelds und behalten die Formatierung der umgebenden Abschnitte bei. Falls eine Übereinstimmung Abschnitte mit unterschiedlicher Formatierung umfasst, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung den gewünschten Stil verwendet.