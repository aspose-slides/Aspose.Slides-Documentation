---
title: Suche und ersetze Text in PowerPoint-Präsentationen in Java
linktitle: Suche und ersetze Text
type: docs
weight: 55
url: /de/java/search-and-replace-text/
keywords:
- Text suchen
- Text hervorheben
- Text ersetzen
- Regulärer Ausdruck
- Ergebnis-Callback
- Textfeld
- Prüfbericht
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Text in PowerPoint-Präsentationen suchen, hervorheben und ersetzen und dabei jede Übereinstimmung mit Aspose.Slides für Java sammeln."
---
## **Übersicht**

Aspose.Slides for Java kann Text in einem einzelnen Textfeld oder in einer gesamten Präsentation suchen, hervorheben und ersetzen. Jede Operation kann zudem eine Anwendung über jede Übereinstimmung mittels eines Ergebnis‑Callbacks benachrichtigen. Dadurch ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, Textfeld und Foliennummer enthält.

Diese Funktionen sind nützlich für Reviews, Redaktionen, Terminologie‑Prüfungen, Vorlagen‑Bereinigungen und automatisierte Reporting‑Workflows.

In den ersten Beispielen unten verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich auswählen**

Verwenden Sie Methoden auf [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) um eine Operation auf ein Textfeld zu beschränken. Verwenden Sie Methoden auf [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/) um allen anwendbaren Text in der Präsentation zu verarbeiten.

| Operation | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Textabgleich konfigurieren**

Für Literaltext‑Operationen verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/), um das Matching zu steuern:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) Beschränkt die Übereinstimmungen auf komplette Wörter.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) Steuert, ob die Groß-/Kleinschreibung übereinstimmen muss.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) Bezieht Foliennotizen in nachricht‑, ersetzungs‑ und hervorhebungsoperationen auf Präsentationsebene ein.

Reguläre‑Ausdruck‑Operationen verwenden ein Java‑`Pattern`, sodass Matching‑Regeln wie Groß-/Kleinschreibung und Wortgrenzen durch den Ausdruck und seine Flags definiert werden.

## **Match‑Informationen mit einem Callback sammeln**

Implementieren Sie [IFindResultCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifindresultcallback/), um für jede Übereinstimmung eine Benachrichtigung zu erhalten. Seine Methode [IFindResultCallback.foundResult](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) liefert das zugehörige Textfeld, den Quelltext, den gefundenen Text und die Position der Übereinstimmung.

Der Callback erhält die Foliennummer nicht direkt. Die nachstehende Implementierung ermittelt sie aus der übergeordneten Folie und verarbeitet zudem Text, der in Foliennotizen gefunden wird. Ein nullable `Integer` ermöglicht es, dass dasselbe Ergebnis‑Modell Text zu anderen Folientypen zuzuordnen.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

Bei Ersetzungs‑Operationen enthält `foundText` den original gefundenen Text, sodass der Callback exakt aufzeichnen kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [ITextFrame.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), um Literaltext‑Übereinstimmungen in einem Textfeld hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/) , um die Suche zu steuern, und einen Callback, um Details zu sammeln.

Das nachstehende Code‑Beispiel hebt alle Vorkommen der Zeichen **"try"** hervor und anschließend nur das komplette Wort **"to"**. Beide Suchen melden ihre Treffer an denselben Callback.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // Hervorheben jedes Auftretens von "try" im Textfeld.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Nur das komplette Wort "to" hervorheben.
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der hervorgehobene Text](highlighted_text.png)

## **Text mit regulären Ausdrücken hervorheben**

Die Methode [ITextFrame.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) hebt Text‑Übereinstimmungen, die durch einen regulären Ausdruck gefunden wurden, in einem Textfeld hervor.

Der folgende Code hebt alle Wörter mit sieben oder mehr Zeichen hervor und sammelt jede Übereinstimmung:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Der hervorgehobene Text mit dem regulären Ausdruck](highlighted_text_using_regex.png)

## **Text in einer Präsentation hervorheben**

Verwenden Sie [Presentation.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [Presentation.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), um alle anwendbaren Textfelder in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen Literalbegriff und alle E‑Mail‑Adressen hervor, wobei für die beiden Suchen separate Ergebnissammlungen beibehalten werden.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Text in einem Textfeld ersetzen**

Verwenden Sie [ITextFrame.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) für Literaltext und [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) für Musteraustausch. Diese Methoden aktualisieren den gefundenen Text im bestehenden Textfeld und erhalten die Formatierung des umgebenden Teils, anstatt das Textfeld aus einem Rohstring neu aufzubauen.

Das folgende Beispiel standardisiert eine Schreibvariante und ersetzt anschließend Versionsbezeichnungen. Derselbe Callback zeichnet die ursprünglichen Begriffe auf, die von beiden Operationen gefunden wurden.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Falls eine Übereinstimmung Bereiche mit unterschiedlicher Formatierung überspannt, prüfen Sie die Ausgabe, um zu bestätigen, welche Formatierung auf den ersetzten Text angewendet werden soll.

## **Text in einer Präsentation ersetzen**

Verwenden Sie [Presentation.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [Presentation.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-), um dieselben Operationen in der gesamten Präsentation anzuwenden. Dies ist nützlich für Vorlagen‑Bereinigungen, Terminologie‑Updates und Redaktionen.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Übereinstimmungen für Berichte gruppieren**

Da jedes Ergebnis die Foliennummer und das Textfeld speichert, können Anwendungen Übereinstimmungen für Prüfungen, Berichte oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die gesammelten Ergebnisse zuerst nach Folie und anschließend nach Textfeld:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **FAQ**

**Wie kann ich nur ein Textfeld statt der gesamten Präsentation durchsuchen?**

Rufen Sie das Textfeld der Form ab und verwenden Sie [ITextFrame.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), oder [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) für dieses Textfeld. Methoden auf Präsentationsebene verarbeiten stattdessen alle anwendbaren Textfelder.

**Wie kann ich komplette Wörter mit korrekter Groß-/Kleinschreibung abgleichen?**

Setzen Sie [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) und [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) auf `true` und übergeben Sie die Optionen an eine Literaltext‑Hervorhebungs‑ oder Ersetzungs‑Methode. Bei regulären Ausdrücken definieren Sie Wortgrenzen und Groß-/Kleinschreibung im Java‑`Pattern` selbst.

**Können Suche und Ersetzung Text in Foliennotizen einschließen?**

Ja. Setzen Sie [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) auf `true`, wenn Sie eine Literaltext‑Operation auf Präsentationsebene verwenden. Die oben gezeigte Callback‑Implementierung ordnet eine Übereinstimmung in einer Notizfolie ihrer übergeordneten Foliennummer zu.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu scannen?**

Übergeben Sie eine Implementierung von [IFindResultCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifindresultcallback/) an die Hervorhebungs‑ oder Ersetzungs‑Operation. Der Callback erhält jede Übereinstimmung während der Ausführung, sodass die Anwendung den Quelltext, den gefundenen Text, die Position, das Textfeld und die abgeleitete Foliennummer für spätere Gruppierung oder den Export speichern kann.

**Erhält das Ersetzen von Text dessen Formatierung?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ändern den gefundenen Text im bestehenden Textfeld und behalten die Formatierung des umgebenden Abschnitts bei. Wenn eine Übereinstimmung Abschnitte mit unterschiedlicher Formatierung überspannt, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung den gewünschten Stil verwendet.