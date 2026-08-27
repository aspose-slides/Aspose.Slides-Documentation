---
title: Suche und Ersetze Text in PowerPoint-Präsentationen in Java
linktitle: Suche und Ersetze Text
type: docs
weight: 55
url: /de/java/search-and-replace-text/
keywords:
- Text suchen
- Text hervorheben
- Text ersetzen
- regulärer Ausdruck
- Ergebnis‑Callback
- Textfeld
- Audit‑Bericht
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Suchen, Hervorheben und Ersetzen von Text in PowerPoint-Präsentationen, wobei jeder Treffer mit Aspose.Slides for Java erfasst wird."
---
## **Übersicht**

Aspose.Slides for Java kann Text in einem einzelnen Textfeld oder in der gesamten Präsentation suchen, hervorheben und ersetzen. Jeder Vorgang kann außerdem eine Anwendung über jeden Treffer durch einen Ergebnis‑Callback informieren. Dadurch ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, Textfeld und Foliennummer enthält.

Diese Möglichkeiten sind nützlich für Überprüfungen, Redaktionen, Terminologie‑Checks, Vorlagen‑Bereinigungen und automatisierte Reporting‑Workflows.

In den ersten Beispielen unten verwenden wir die Datei **„sample.pptx“**, die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich wählen**

Verwenden Sie Methoden auf [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/), um einen Vorgang auf ein Textfeld zu beschränken. Verwenden Sie Methoden auf [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/), um allen anwendbaren Text in der Präsentation zu verarbeiten.

| Vorgang | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| Literal‑Text hervorheben | [ITextFrame.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Treffer von regulären Ausdrücken hervorheben | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Literal‑Text ersetzen | [ITextFrame.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Treffer von regulären Ausdrücken ersetzen | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Textabgleich konfigurieren**

Für Literal‑Text‑Operationen verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/), um den Abgleich zu steuern:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) beschränkt Treffer auf ganze Wörter.  
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) legt fest, ob die Groß‑/Kleinschreibung stimmen muss.  
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) schließt Folien‑Notizen in Such‑, Ersetz‑ und Hervorhebungs‑Operationen auf Präsentationsebene ein.

Bei Operationen mit regulären Ausdrücken wird ein Java `Pattern` verwendet; Regeln wie Groß‑/Kleinschreibung und Wortgrenzen werden im Ausdruck und dessen Flags definiert.

## **Den Eigentümer eines Textfeldes ermitteln**

Allgemeine Text‑Verarbeitungs‑Workflows erhalten häufig ein [ITextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/) beim Suchen, Ersetzen, Validieren oder Exportieren von Text. Verwenden Sie [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentShape--) und [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentCell--), um festzustellen, welches Präsentations‑Objekt das Textfeld besitzt.

Die erwarteten Werte hängen vom Eigentümer ab:

| Eigentümer des Textfeldes | `getParentShape` | `getParentCell` |
|---|---|---|
| Ein AutoShape oder ein anderes text‑enthältendes Shape | Das zugehörige [IShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/) | `null` |
| Eine Tabellenzelle | `null` | Das zugehörige [ICell](https://reference.aspose.com/slides/de/java/com.aspose.slides/icell/) |

Beide Methoden bieten nur lesende Navigation. Der Aufruf verändert weder die Position des Textfeldes noch dessen Eigentümer. Generischer Code sollte beide Werte auf `null` prüfen und den Fall behandeln, dass kein Eigentümer verfügbar ist.

Das folgende Beispiel verwendet [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/de/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-), um alle Textfelder einer Präsentation zu durchlaufen. Für Shapes gibt es den Shape‑Namen, den Java‑Laufzeit‑Typ und die zugehörige Folie aus. Für Tabellenzellen werden die null‑basierten Spalten‑ und Zeilen‑Koordinaten sowie die zugehörige Folie angegeben.

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

Für SmartArt‑Inhalte iterieren Sie über die Shapes in [ISmartArtNode.getShapes](https://reference.aspose.com/slides/de/java/com.aspose.slides/ismartartnode/#getShapes--) und greifen auf jedes [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ismartartshape/#getTextFrame--) zu. Das Textfeld lässt sich über [ITextFrame.getParentShape](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentShape--) zum zugehörigen Shape zurückverfolgen, während [ITextFrame.getParentCell](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#getParentCell--) `null` zurückliefert. Daher behandelt der Shape‑Zweig im Beispiel auch Text aus SmartArt‑Knoten.

## **Trefferinformationen mit einem Callback sammeln**

Implementieren Sie [IFindResultCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifindresultcallback/), um für jeden Treffer eine Benachrichtigung zu erhalten. Seine Methode [IFindResultCallback.foundResult](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) liefert das zugehörige Textfeld, den Quelltext, den gefundenen Text und die Position des Treffers.

Der Callback erhält nicht direkt die Foliennummer. Die Implementierung unten leitet sie aus der übergeordneten Folie ab und berücksichtigt zudem Text, der in Folien‑Notizen gefunden wurde. Ein nullable `Integer` erlaubt es, dasselbe Resultat‑Modell auch für andere Folientypen zu verwenden.

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

Bei Ersetz‑Operationen enthält `foundText` den ursprünglich gefundenen Text, sodass der Callback exakt festhalten kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [ITextFrame.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), um Literal‑Text‑Treffer in einem Textfeld hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/), um die Suche zu steuern, und einen Callback, um Treffer‑Details zu sammeln.

Im folgenden Code‑Beispiel werden alle Vorkommen der Zeichenfolge **„try“** hervorgehoben und anschließend nur das vollständige Wort **„to“**. Beide Suchen melden ihre Treffer an denselben Callback.

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

    // Hervorheben jedes Vorkommens von "try" im Textfeld.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Nur das vollständige Wort "to" hervorheben.
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

Die Methode [ITextFrame.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) hebt Text‑Treffer hervor, die durch einen regulären Ausdruck in einem Textfeld gefunden wurden.

Der nachfolgende Code hebt alle Wörter mit sieben oder mehr Zeichen hervor und sammelt jeden Treffer:

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

![Der hervorgehobene Text mit regulärem Ausdruck](highlighted_text_using_regex.png)

## **Text in einer gesamten Präsentation hervorheben**

Verwenden Sie [Presentation.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [Presentation.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), um alle anwendbaren Textfelder einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen Literal‑Begriff und alle E‑Mail‑Adressen hervor, wobei separate Ergebnis‑Sammlungen für die beiden Suchen geführt werden.

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

Verwenden Sie [ITextFrame.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) für Literal‑Text und [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) für ersetzungen basierend auf Mustern. Diese Methoden aktualisieren den gefundenen Text innerhalb des bestehenden Textfeldes, wodurch die Formatierung des umgebenden Textes erhalten bleibt, anstatt das Textfeld aus einem reinen String neu zu erzeugen.

Das nachfolgende Beispiel vereinheitlicht eine Rechtschreibvariante und ersetzt anschließend Versions‑Labels. Derselbe Callback zeichnet die ursprünglichen Begriffe auf, die von beiden Vorgängen gefunden wurden.

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

Falls ein Treffer Teile mit unterschiedlicher Formatierung umfasst, prüfen Sie die Ausgabe, um sicherzustellen, welche Formatierung für den Ersetzungstext übernommen werden soll.

## **Text in einer gesamten Präsentation ersetzen**

Verwenden Sie [Presentation.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [Presentation.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-), um dieselben Vorgänge über die gesamte Präsentation anzuwenden. Das ist nützlich für Vorlagen‑Bereinigung, Terminologie‑Updates und Redaktionen.

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

## **Treffer für Reporting gruppieren**

Da jedes Ergebnis seine Folien‑Nummer und sein Textfeld speichert, können Anwendungen Treffer für Prüf‑, Reporting‑ oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die gesammelten Ergebnisse zuerst nach Folie und dann nach Textfeld:

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

Holen Sie das Textfeld des Shapes und rufen Sie [ITextFrame.highlightText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), oder [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) auf diesem Textfeld auf. Methoden auf Präsentationsebene verarbeiten alle anwendbaren Textfelder.

**Wie kann ich ganze Wörter mit korrekter Groß‑/Kleinschreibung finden?**

Setzen Sie [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) und [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) auf `true` und übergeben Sie die Optionen einer Literal‑Text‑Hervorhebungs‑ oder Ersetzungs‑Methode. Für reguläre Ausdrücke definieren Sie Wortgrenzen und Groß‑/Kleinschreibung im Java `Pattern` selbst.

**Kann die Suche und das Ersetzen Text in Folien‑Notizen einschließen?**

Ja. Setzen Sie [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) auf `true`, wenn Sie eine Literal‑Text‑Operation auf Präsentationsebene ausführen. Die oben gezeigte Callback‑Implementierung ordnet einen Treffer in einer Notizfolie ihrer übergeordneten Folien‑Nummer zu.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu durchsuchen?**

Übergeben Sie eine [IFindResultCallback](https://reference.aspose.com/slides/de/java/com.aspose.slides/ifindresultcallback/)-Implementierung an die Hervorhebungs‑ oder Ersetzungs‑Operation. Der Callback erhält jeden Treffer während des Vorgangs, sodass die Anwendung Quelltext, gefundenen Text, Position, Textfeld und abgeleitete Folien‑Nummer für ein späteres Gruppieren oder Exportieren speichern kann.

**Behält das Ersetzen die Formatierung des Textes bei?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) und [ITextFrame.replaceRegex](https://reference.aspose.com/slides/de/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) ändern den gefundenen Text innerhalb des bestehenden Textfeldes und erhalten die Formatierung der umliegenden Abschnitte. Wenn ein Treffer Teile mit unterschiedlicher Formatierung umfasst, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung die gewünschte Formatierung verwendet.