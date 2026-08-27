---
title: "Suche und Ersetzen von Text in PowerPoint-Präsentationen auf Android"
linktitle: "Suche und Ersetzen von Text"
type: docs
weight: 55
url: /de/androidjava/search-and-replace-text/
keywords:
- "Text suchen"
- "Text hervorheben"
- "Text ersetzen"
- "regulärer Ausdruck"
- "Ergebnis-Callback"
- "Textrahmen"
- "Audit-Bericht"
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Suchen, Hervorheben und Ersetzen von Text in PowerPoint-Präsentationen, wobei jede Übereinstimmung mit Aspose.Slides für Android via Java gesammelt wird."
---
## **Übersicht**

Aspose.Slides für Android via Java kann Text in einem einzelnen Textrahmen oder in einer gesamten Präsentation suchen, hervorheben und ersetzen. Jede Operation kann zudem eine Anwendung über jede Übereinstimmung mittels eines Ergebnis‑Callbacks benachrichtigen. Dies ermöglicht es, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, Textrahmen und Foliennummer enthält.

Diese Funktionen sind nützlich für Überprüfung, Schwärzung, Terminologie‑Prüfungen, Vorlagen‑Bereinigung und automatisierte Reporting‑Workflows.

In den ersten Beispielen unten verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich auswählen**

Verwenden Sie Methoden von [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/)..., um eine Operation auf einen Textrahmen zu beschränken. Verwenden Sie Methoden von [IPresentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/)..., um allen anwendbaren Text in der Präsentation zu verarbeiten.

| Operation | Ein Textrahmen | Gesamte Präsentation |
|---|---|---|
| Highlight literal text | [ITextFrame.highlightText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Highlight regular-expression matches | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Replace literal text | [ITextFrame.replaceText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Replace regular-expression matches | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Textabgleich konfigurieren**

Für Literal‑Text‑Operationen verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textsearchoptions/), um das Matching zu steuern:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) beschränkt Übereinstimmungen auf ganze Wörter.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) steuert, ob die Groß‑ und Kleinschreibung übereinstimmen muss.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) schließt Foliennotizen in Präsentations‑Level‑Suche, -Ersetzung und -Hervorhebung ein.

Reguläre‑Ausdruck‑Operationen verwenden ein Java‑`Pattern`, sodass Matching‑Regeln wie Groß‑/Kleinschreibung und Wortgrenzen durch den Ausdruck und dessen Flags definiert werden.

## **Besitzer eines Textrahmens ermitteln**

Allgemeine Textverarbeitungs‑Workflows erhalten häufig ein [ITextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/) beim Suchen, Ersetzen, Validieren oder Exportieren von Text. Verwenden Sie [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentShape--) und [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentCell--) , um zu bestimmen, welches Präsentationsobjekt den Textrahmen besitzt.

Die erwarteten Werte hängen vom Besitzer ab:

| Besitzer des Textrahmens | `getParentShape` | `getParentCell` |
|---|---|---|
| Eine AutoShape oder ein anderes text‑enthaltendes Shape | Das zugehörige [IShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/) | `null` |
| Eine Tabellenzelle | `null` | Das zugehörige [ICell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/icell/) |

Beide Methoden bieten nur Lese‑Navigation. Ein Aufruf verschiebt den Textrahmen nicht und ändert seinen Besitzer nicht. Generischer Code sollte beide Werte auf `null` prüfen und die Möglichkeit berücksichtigen, dass kein Besitzer verfügbar ist.

Das folgende Beispiel verwendet [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-), um durch die Textrahmen einer Präsentation zu iterieren. Für Shapes gibt es den Shape‑Namen, den Java‑Laufzeit‑Typ und die zugehörige Folie aus. Für Tabellenzellen werden die null‑basierten Spalten‑ und Zeilenkoordinaten sowie die zugehörige Folie ausgegeben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Für SmartArt‑Inhalte iterieren Sie über die Shapes in [ISmartArtNode.getShapes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ismartartnode/#getShapes--) und greifen auf jedes [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) zu. Der Textrahmen lässt sich über [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentShape--) zu seinem zugehörigen Shape zurückverfolgen, während [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null` zurückgibt. Daher behandelt der Shape‑Zweig im Beispiel ebenfalls Text aus SmartArt‑Knoten.

## **Match‑Informationen mit einem Callback sammeln**

Implementieren Sie [IFindResultCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifindresultcallback/), um für jede Übereinstimmung eine Benachrichtigung zu erhalten. Seine Methode [IFindResultCallback.foundResult](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) liefert den zugehörigen Textrahmen, den Quelltext, den gefundenen Text und die Position der Übereinstimmung.

Der Callback erhält keine Foliennummer direkt. Die nachstehende Implementierung ermittelt sie aus der übergeordneten Folie und verarbeitet zudem Text, der in Folien‑Notizen gefunden wird. Ein nullable `Integer` ermöglicht es, dass dasselbe Ergebnis‑Modell Text zu anderen Folientypen zuzuordnen.

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

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

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

Bei Ersetzungs‑Operationen enthält `foundText` den ursprünglich gefundenen Text, sodass der Callback exakt festhalten kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [ITextFrame.highlightText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), um Literal‑Text‑Übereinstimmungen in einem Textrahmen hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textsearchoptions/), um die Suche zu steuern, und einen Callback, um Details der Übereinstimmungen zu sammeln.

Das untenstehende Code‑Beispiel hebt alle Vorkommen der Zeichen **"try"** hervor und anschließend nur das vollständige Wort **"to"**. Beide Suchen melden ihre Treffer an denselben Callback.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // Hervorheben jedes Vorkommens von "try" im Textrahmen.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Hervorheben nur des vollständigen Wortes "to".
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

## **Text hervorheben mithilfe regulärer Ausdrücke**

Die Methode [ITextFrame.highlightRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) hebt Textübereinstimmungen hervor, die durch einen regulären Ausdruck in einem Textrahmen gefunden wurden.

Der folgende Code hebt alle Wörter hervor, die sieben oder mehr Zeichen enthalten, und sammelt jede Übereinstimmung:

```java
import com.aspose.slides.*;
import android.graphics.Color;
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

![Der hervorgehobene Text mittels regulärem Ausdruck](highlighted_text_using_regex.png)

## **Text in einer gesamten Präsentation hervorheben**

Verwenden Sie [IPresentation.highlightText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [IPresentation.highlightRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), um alle anwendbaren Textrahmen in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen Literal‑Begriff und alle E‑Mail‑Adressen hervor, wobei für die beiden Suchen separate Ergebnis‑Sammlungen beibehalten werden.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

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

## **Text in einem Textrahmen ersetzen**

Verwenden Sie [ITextFrame.replaceText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) für Literal‑Text und [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) für ersatzbasierte Ersetzung. Diese Methoden aktualisieren den gefundenen Text im bestehenden Textrahmen, wobei die Formatierung des umgebenden Textteils erhalten bleibt, anstatt den Textrahmen aus einem Klartext‑String neu aufzubauen.

Das folgende Beispiel standardisiert eine Schreibvarianten und ersetzt anschließend Versionsbezeichnungen. Derselbe Callback zeichnet die ursprünglich gefundenen Begriffe beider Operationen auf.

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

Falls eine Übereinstimmung Teile mit unterschiedlicher Formatierung umfasst, prüfen Sie die Ausgabe, um zu bestätigen, welche Formatierung auf den Ersetzungstext angewendet werden soll.

## **Text in einer gesamten Präsentation ersetzen**

Verwenden Sie [IPresentation.replaceText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [IPresentation.replaceRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-), um dieselben Operationen über die gesamte Präsentation anzuwenden. Dies ist nützlich für die Bereinigung von Vorlagen, Terminologie‑Aktualisierungen und Schwärzungen.

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

## **Übereinstimmungen für Reporting gruppieren**

Da jedes Ergebnis seine Foliennummer und den Textrahmen speichert, können Anwendungen Treffer für Prüfungen, Reporting oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die gesammelten Ergebnisse zuerst nach Folie und dann nach Textrahmen:

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

Rufen Sie das Textfeld der Form ab und rufen Sie [ITextFrame.highlightText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) oder [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) für dieses Textfeld auf. Methoden auf Präsentations‑Ebene verarbeiten stattdessen alle anwendbaren Textrahmen.

**Wie kann ich komplette Wörter mit korrekter Groß‑ und Kleinschreibung matchen?**

Setzen Sie [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) und [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) auf `true` und übergeben Sie die Optionen an eine Literal‑Text‑Hervorhebungs‑ oder Ersetzungs‑Methode. Für reguläre Ausdrücke definieren Sie Wortgrenzen und Groß‑/Kleinschreibung im Java‑`Pattern` selbst.

**Können Suche und Ersetzung Text in Folien‑Notizen einschließen?**

Ja. Setzen Sie [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) auf `true`, wenn Sie eine Literal‑Text‑Operation auf Präsentations‑Ebene verwenden. Die oben gezeigte Callback‑Implementierung ordnet ein Ergebnis in einer Notizfolie wieder ihrer übergeordneten Foliennummer zu.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu durchsuchen?**

Übergeben Sie eine [IFindResultCallback](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ifindresultcallback/)‑Implementierung an die Hervorhebungs‑ oder Ersetzungs‑Operation. Der Callback erhält während der Ausführung jede Übereinstimmung, sodass die Anwendung den Quelltext, den gefundenen Text, die Position, den Textrahmen und die abgeleitete Foliennummer für spätere Gruppierung oder den Export speichern kann.

**Behält das Ersetzen von Text dessen Formatierung bei?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ändern den gefundenen Text innerhalb des bestehenden Textrahmens und behalten die Formatierung der umgebenden Textteile bei. Falls eine Übereinstimmung Teile mit unterschiedlicher Formatierung umfasst, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung die gewünschte Formatierung verwendet.