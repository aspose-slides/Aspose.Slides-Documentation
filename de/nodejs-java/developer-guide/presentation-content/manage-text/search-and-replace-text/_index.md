---
title: Suchen und Ersetzen von Text in PowerPoint-Präsentationen in JavaScript
linktitle: Suchen und Ersetzen von Text
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
- Audit-Bericht
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Text in PowerPoint-Präsentationen suchen, hervorheben und ersetzen, während jede Übereinstimmung mit Aspose.Slides für Node.js via Java gesammelt wird."
---
## **Übersicht**

Aspose.Slides für Node.js über Java kann Text in einem einzelnen Textfeld oder in einer gesamten Präsentation suchen, hervorheben und ersetzen. Jeder Vorgang kann auch eine Anwendung über jede Übereinstimmung mittels eines Ergebnis‑Callbacks benachrichtigen. Dadurch ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, Textfeld und Foliennummer enthält.

Diese Funktionen sind nützlich für Überprüfungen, Schwärzungen, Terminologie‑Prüfungen, Vorlagenbereinigung und automatisierte Bericht‑Workflows.

In den ersten Beispielen unten verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich auswählen**

Verwenden Sie Methoden von [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) , um einen Vorgang auf ein Textfeld zu beschränken. Verwenden Sie Methoden von [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/) , um gesamten anwendbaren Text in der Präsentation zu verarbeiten.

| Vorgang | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| Literaltext hervorheben | [TextFrame.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguläre‑Ausdruck‑Übereinstimmungen hervorheben | [TextFrame.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Literaltext ersetzen | [TextFrame.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguläre‑Ausdruck‑Übereinstimmungen ersetzen | [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Textabgleich konfigurieren**

Für Literal‑Text‑Operationen verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/) , um den Abgleich zu steuern:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) beschränkt Übereinstimmungen auf ganze Wörter.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) steuert, ob die Groß‑/Kleinschreibung berücksichtigt werden muss.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) bezieht Folien‑Notizen in Präsentations‑Suchen, Ersetzungen und Hervorhebungen ein.

Reguläre‑Ausdruck‑Operationen verwenden ein Java‑`Pattern`, sodass Abgleichregeln wie Groß‑/Kleinschreibung und Wortgrenzen durch den Ausdruck und seine Flags definiert werden.

## **Eigentümer eines Textfeldes ermitteln**

Allgemeine Textverarbeitungs‑Workflows erhalten häufig ein [TextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/) beim Suchen, Ersetzen, Validieren oder Exportieren von Text. Verwenden Sie [TextFrame.getParentShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentShape--) und [TextFrame.getParentCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentCell--) , um festzustellen, welches Präsentationsobjekt das Textfeld besitzt.

Die erwarteten Werte hängen vom Eigentümer ab:

| Eigentümer des Textfeldes | `getParentShape` | `getParentCell` |
|---|---|---|
| Ein AutoShape oder eine andere texthaltige Form | Die zugehörige [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/) | `null` |
| Eine Tabellenzelle | `null` | Die zugehörige [Cell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/cell/) |

Beide Methoden bieten eine schreibgeschützte Navigation. Ein Aufruf ändert weder die Position des Textfeldes noch dessen Eigentümer. Generischer Code sollte beide Werte auf `null` prüfen und den Fall behandeln, dass kein Eigentümer verfügbar ist.

Das folgende Beispiel verwendet [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) , um durch die Textfelder einer Präsentation zu iterieren. Für Formen gibt es den Formnamen, den Java‑Laufzeit‑Typ und die zugehörige Folie aus. Für Tabellenzellen gibt es die nullbasierten Spalten‑ und Zeilenkoordinaten sowie die zugehörige Folie aus.

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

Für SmartArt‑Inhalte iterieren Sie über die Formen in [SmartArtNode.getShapes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartartnode/#getShapes--) und greifen auf jedes [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) zu. Das Textfeld kann über [TextFrame.getParentShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentShape--) zu seiner zugehörigen Form zurückverfolgt werden, während [TextFrame.getParentCell](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getParentCell--) `null` zurückgibt. Daher behandelt der Form‑Zweig im Beispiel auch Text aus SmartArt‑Knoten.

## **Übereinstimmungsinformationen mit einem Callback sammeln**

Erstellen Sie einen Java‑Proxy für das Ergebnis‑Callback, um für jede Übereinstimmung eine Benachrichtigung zu erhalten. Die Proxy‑Funktion erhält das zugehörige Textfeld, den Quelltext, den gefundenen Text und die Position der Übereinstimmung.

Das Callback erhält die Foliennummer nicht direkt. Die nachstehende Implementierung ermittelt sie über die zugehörige Form oder Tabellenzelle des Textfeldes, wobei [TextFrame.getSlide](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#getSlide--) als Ersatz verwendet wird. Zudem werden Texte aus Folien‑Notizen verarbeitet.

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

Bei Ersetzungs‑Operationen enthält `foundText` den ursprünglichen gefundenen Text, sodass das Callback exakt protokollieren kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [TextFrame.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) , um Literal‑Text‑Übereinstimmungen in einem Textfeld hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/) , um die Suche zu steuern.

Das Code‑Beispiel unten hebt alle Vorkommen der Zeichen **"try"** hervor und hebt anschließend nur das komplette Wort **"to"** hervor.

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

    // Hervorheben jedes Vorkommens von "try" im Textfeld.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Nur das vollständige Wort "to" hervorheben.
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

Die Methode [TextFrame.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) hebt Text‑Übereinstimmungen hervor, die durch einen regulären Ausdruck in einem Textfeld gefunden wurden.

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

![Der mit dem regulären Ausdruck hervorgehobene Text](highlighted_text_using_regex.png)

## **Text in einer gesamten Präsentation hervorheben**

Verwenden Sie [Presentation.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [Presentation.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) , um alle anwendbaren Textfelder in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen Literalbegriff und alle E‑Mail‑Adressen hervor:

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

Verwenden Sie [TextFrame.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) für Literaltext und [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) für ersatzbasierte Muster. Diese Methoden aktualisieren den gefundenen Text im bestehenden Textfeld und behalten die Formatierung des umgebenden Abschnitts bei, anstatt das Textfeld aus einem einfachen String neu zu erstellen.

Das folgende Beispiel vereinheitlicht eine Rechtschreibvariante und ersetzt anschließend Versionsbezeichnungen:

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

Wenn eine Übereinstimmung Bereiche mit unterschiedlicher Formatierung umfasst, prüfen Sie die Ausgabe, um zu bestätigen, welche Formatierung auf den Ersatztext angewendet werden soll.

## **Text in einer gesamten Präsentation ersetzen**

Verwenden Sie [Presentation.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [Presentation.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) , um dieselben Vorgänge in der gesamten Präsentation anzuwenden. Dies ist nützlich für Vorlagenbereinigung, Terminologie‑Aktualisierungen und Schwärzungen.

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

Weil jedes gesammelte Ergebnis die Foliennummer und das Textfeld speichert, können Anwendungen Übereinstimmungen für Prüfungen, Berichte oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die Ergebnisse zuerst nach Folie und dann nach Textfeld:

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

**Wie kann ich nur ein Textfeld und nicht die gesamte Präsentation durchsuchen?**

Holen Sie das Textfeld der Form und rufen Sie [TextFrame.highlightText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) oder [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) für dieses Textfeld auf. Methoden auf Präsentationsebene verarbeiten alle anwendbaren Textfelder.

**Wie kann ich komplette Wörter mit korrekter Groß‑/Kleinschreibung abgleichen?**

Setzen Sie [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) und [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) auf `true` und übergeben Sie die Optionen an eine Literal‑Text‑Hervorhebungs‑ oder Ersetzungs‑Methode. Für reguläre Ausdrücke definieren Sie Wortgrenzen und Groß‑/Kleinschreibung direkt im Java‑`Pattern`.

**Können Suche und Ersetzung Text in Folien‑Notizen einbeziehen?**

Ja. Setzen Sie [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) auf `true`, wenn Sie eine Literal‑Text‑Operation auf Präsentationsebene verwenden. Die oben gezeigte Callback‑Implementierung ordnet eine Übereinstimmung in einer Notizfolie ihrer übergeordneten Foliennummer zu.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu durchsuchen?**

Übergeben Sie einen Java‑Ergebnis‑Callback‑Proxy an die Hervorhebungs‑ oder Ersetzungsoperation. Das Callback erhält jede Übereinstimmung während der Ausführung, sodass die Anwendung Quelltext, gefundenen Text, Position, Textfeld und abgeleitete Foliennummer für spätere Gruppierung oder den Export speichern kann.

**Behält das Ersetzen von Text dessen Formatierung bei?**

[TextFrame.replaceText](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ändern den gefundenen Text im bestehenden Textfeld und behalten die Formatierung des umgebenden Bereichs bei. Wenn eine Übereinstimmung Bereiche mit unterschiedlicher Formatierung umfasst, prüfen Sie das Ergebnis, um sicherzustellen, dass der Ersatz die gewünschte Formatierung verwendet.