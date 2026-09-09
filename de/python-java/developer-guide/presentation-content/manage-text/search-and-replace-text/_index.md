---
title: Suchen und Ersetzen von Text in PowerPoint-Präsentationen in Python via Java
linktitle: Suchen und Ersetzen von Text
type: docs
weight: 55
url: /de/python-java/search-and-replace-text/
keywords:
- Text suchen
- Text hervorheben
- Text ersetzen
- regulärer Ausdruck
- Ergebnis-Callback
- Textfeld
- Auditbericht
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Suchen, Hervorheben und Ersetzen von Text in PowerPoint-Präsentationen, wobei jede Übereinstimmung mit Aspose.Slides for Python via Java erfasst wird."
---
## **Übersicht**

Aspose.Slides for Python via Java kann Text in einem einzelnen Textfeld oder in der gesamten Präsentation suchen, hervorheben und ersetzen. Jeder Vorgang kann auch eine Anwendung über jede Übereinstimmung mittels eines Ergebnis‑Callbacks benachrichtigen. Dadurch ist es möglich, eine Präsentation zu aktualisieren und gleichzeitig ein Prüfprotokoll zu erstellen, das den gefundenen Text, dessen Kontext, Position, Textfeld und Foliennummer enthält.

Diese Funktionen sind nützlich für Überprüfungen, Redaktionen, Terminologie‑Prüfungen, Vorlagenbereinigung und automatisierte Berichtswerkabläufe.

In den nachfolgenden ersten Beispielen verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich auswählen**

Verwenden Sie Methoden von [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/), um einen Vorgang auf ein Textfeld zu beschränken. Verwenden Sie Methoden von [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/), um alle anwendbaren Texte in der Präsentation zu verarbeiten.

| Operation | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| Wörtlichen Text hervorheben | [TextFrame.highlightText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#highlightText) | [Presentation.highlightText](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#highlightText) |
| Übereinstimmungen von regulären Ausdrücken hervorheben | [TextFrame.highlightRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#highlightRegex) | [Presentation.highlightRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#highlightRegex) |
| Wörtlichen Text ersetzen | [TextFrame.replaceText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#replaceText) | [Presentation.replaceText](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#replaceText) |
| Übereinstimmungen von regulären Ausdrücken ersetzen | [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#replaceRegex) | [Presentation.replaceRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#replaceRegex) |

## **Textabgleich konfigurieren**

Für Vorgänge mit wörtlichem Text verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/textsearchoptions/) , um das Matching zu steuern:

- [setWholeWordsOnly](https://reference.aspose.com/slides/de/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) begrenzt Übereinstimmungen auf ganze Wörter.
- [setCaseSensitive](https://reference.aspose.com/slides/de/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) steuert, ob die Groß-/Kleinschreibung übereinstimmen muss.
- [setIncludeNotes](https://reference.aspose.com/slides/de/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) schließt Foliennotizen in Such‑, Ersetz‑ und Hervorhebungs‑Vorgängen auf Präsentationsebene ein.

Vorgänge mit regulären Ausdrücken verwenden ein Java-`Pattern`, sodass Matching‑Regeln wie Groß-/Kleinschreibung und Wortgrenzen durch den Ausdruck und seine Flags definiert werden.

## **Den Besitzer eines Textfelds ermitteln**

Allgemeine Textverarbeitungs‑Workflows erhalten häufig ein [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) beim Suchen, Ersetzen, Validieren oder Exportieren von Text. Verwenden Sie [TextFrame.getParentShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentShape) und [TextFrame.getParentCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentCell), um festzustellen, welches Präsentationsobjekt das Textfeld besitzt.

Die erwarteten Werte hängen vom Besitzer ab:

| Besitzer des Textfelds | `getParentShape` | `getParentCell` |
|---|---|---|
| Ein [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) oder eine andere textenthaltende Form | Die zugehörige [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/) | `None` |
| Eine Tabellenzelle | `None` | Die zugehörige [Cell](https://reference.aspose.com/slides/de/python-java/aspose.slides/cell/) |

Beide Methoden bieten eine schreibgeschützte Navigation. Das Aufrufen ändert das Textfeld nicht und ändert seinen Besitzer nicht. Generischer Code sollte beide Werte auf `None` prüfen und die Möglichkeit berücksichtigen, dass kein Besitzer verfügbar ist.

Das folgende Beispiel verwendet [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/de/python-java/aspose.slides/slideutil/#getAllTextFrames), um die Textfelder einer Präsentation zu durchlaufen. Für Formen gibt es den Formnamen, den Java-Laufzeittyp und die zugehörige Folie aus. Für Tabellenzellen gibt es die nullbasierten Spalten‑ und Zeilenkoordinaten sowie die zugehörige Folie aus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

presentation = Presentation("presentation.pptx")
try:
    text_frames = SlideUtil.getAllTextFrames(presentation, False)
    for text_frame in text_frames:
        owner_shape = text_frame.getParentShape()
        owner_cell = text_frame.getParentCell()
        if owner_shape is not None:
            shape_name = str(owner_shape.getName()) or "(unnamed)"
            shape_type = owner_shape.getClass().getSimpleName()
            base_slide = owner_shape.getSlide()
        elif owner_cell is not None:
            base_slide = owner_cell.getSlide()
        else:
            print("The text frame owner is not available as a shape or table cell.")
            continue

        if isinstance(base_slide, Slide):
            slide_label = f"slide {base_slide.getSlideNumber()}"
        elif isinstance(base_slide, NotesSlide):
            slide_label = f"notes for slide {base_slide.getParentSlide().getSlideNumber()}"
        else:
            slide_label = str(base_slide.getClass().getSimpleName())

        if owner_shape is not None:
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
        else:
            print(f"Table cell: column {owner_cell.getFirstColumnIndex()}, row {owner_cell.getFirstRowIndex()}; {slide_label}")
finally:
    presentation.dispose()
```

Für SmartArt-Inhalte iterieren Sie über die Formen in [SmartArtNode.getShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/#getShapes) und greifen auf jedes [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartshape/#getTextFrame) zu. Das Textfeld kann über [TextFrame.getParentShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentShape) zu seiner zugehörigen Form zurückverfolgt werden, während [TextFrame.getParentCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentCell) `None` zurückgibt. Daher behandelt der Form‑Zweig im Beispiel ebenfalls Text aus SmartArt‑Knoten.

## **Übereinstimmungsinformationen mit einem Callback sammeln**

Implementieren Sie `IFindResultCallback` über `jpype.JProxy`, um für jede Übereinstimmung eine Benachrichtigung zu erhalten. Seine `foundResult`‑Methode liefert das zugehörige Textfeld, den Quelltext, den gefundenen Text und die Position der Übereinstimmung.

Der Callback erhält die Foliennummer nicht direkt. Die nachstehende Implementierung leitet sie von der übergeordneten Folie ab und verarbeitet zudem Text, der in Foliennotizen gefunden wurde. Eine optionale Foliennummer ermöglicht es, dass dasselbe Ergebnis‑Modell Text zu anderen Folientypen zugeordnet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)
```

Bei Ersetz‑Operationen enthält `found_text` den ursprünglich gefundenen Text, sodass der Callback genau aufzeichnen kann, welche Begriffe ersetzt wurden.

## **Text hervorheben**

Verwenden Sie die Methode [TextFrame.highlightText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#highlightText), um wörtliche Text‑Übereinstimmungen in einem Textfeld hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/python-java/aspose.slides/textsearchoptions/), um die Suche zu steuern, und einen Callback, um Details zu den Übereinstimmungen zu sammeln.

Das nachstehende Code‑Beispiel hebt alle Vorkommen der Zeichen **"try"** hervor und hebt anschließend nur das vollständige Wort **"to"** hervor. Beide Suchen melden ihre Übereinstimmungen an denselben Callback.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)

    substring_search_options = TextSearchOptions()
    substring_search_options.setCaseSensitive(False)
    substring_highlight_color = Color(173, 216, 230)

    # Hervorheben jedes Vorkommens von "try" im Textfeld.
    shape.getTextFrame().highlightText("try", substring_highlight_color, substring_search_options, callback)

    whole_word_search_options = TextSearchOptions()
    whole_word_search_options.setWholeWordsOnly(True)
    whole_word_search_options.setCaseSensitive(False)
    whole_word_highlight_color = Color(238, 130, 238)

    # Nur das vollständige Wort "to" hervorheben.
    shape.getTextFrame().highlightText("to", whole_word_highlight_color, whole_word_search_options, callback)

    for result in callback_handler.results:
        print(f"Found '{result.found_text}' at position {result.text_position} on slide {result.slide_number}.")

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Der hervorgehobene Text](highlighted_text.png)

## **Text mit regulären Ausdrücken hervorheben**

Die Methode [TextFrame.highlightRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#highlightRegex) hebt Text‑Übereinstimmungen hervor, die durch einen regulären Ausdruck in einem Textfeld gefunden wurden.

Der folgende Code hebt alle Wörter hervor, die sieben oder mehr Zeichen enthalten, und sammelt jede Übereinstimmung:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    regex = Pattern.compile("\\b[^\\s]{7,}\\b")

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback)

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Der mit dem regulären Ausdruck hervorgehobene Text](highlighted_text_using_regex.png)

## **Text in einer gesamten Präsentation hervorheben**

Verwenden Sie [Presentation.highlightText](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#highlightText) und [Presentation.highlightRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#highlightRegex), um alle anwendbaren Textfelder in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen wörtlichen Begriff und alle E‑Mail‑Adressen hervor, wobei für die beiden Suchen separate Ergebnis‑Sammlungen verwendet werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    term_callback_handler = TextSearchCallback()
    term_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=term_callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    presentation.highlightText("confidential", Color.ORANGE, search_options, term_callback)

    email_callback_handler = TextSearchCallback()
    email_callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=email_callback_handler)
    email_regex = Pattern.compile("\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b", Pattern.CASE_INSENSITIVE)

    presentation.highlightRegex(email_regex, Color.YELLOW, email_callback)
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Text in einem Textfeld ersetzen**

Verwenden Sie [TextFrame.replaceText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#replaceText) für wörtlichen Text und [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#replaceRegex) für ersatzbasierte Ersetzungen. Diese Methoden aktualisieren den gefundenen Text innerhalb des bestehenden Textfelds, wobei die umgebende Formatierung erhalten bleibt, anstatt das Textfeld aus einer einfachen Zeichenkette neu zu erstellen.

Das folgende Beispiel standardisiert eine Rechtschreibvariante und ersetzt anschließend Versionsbezeichnungen. Der gleiche Callback zeichnet die ursprünglichen Begriffe auf, die von beiden Vorgängen gefunden wurden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(False)

    shape.getTextFrame().replaceText("colour", "color", search_options, callback)

    version_regex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE)
    shape.getTextFrame().replaceRegex(version_regex, "current version", callback)

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Falls eine Übereinstimmung Abschnitte mit unterschiedlicher Formatierung umfasst, prüfen Sie die Ausgabe, um zu bestätigen, welche Formatierung auf den Ersetzungstext angewendet werden soll.

## **Text in einer gesamten Präsentation ersetzen**

Verwenden Sie [Presentation.replaceText](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#replaceText) und [Presentation.replaceRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#replaceRegex), um dieselben Vorgänge in der gesamten Präsentation anzuwenden. Dies ist nützlich für Vorlagenbereinigung, Terminologie‑Updates und Redaktionen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Übereinstimmungen für Berichte gruppieren**

Da jedes Ergebnis seine Foliennummer und sein Textfeld speichert, können Anwendungen Übereinstimmungen für Prüfungen, Berichte oder Review‑Workflows gruppieren. Das folgende Beispiel gruppiert die gesammelten Ergebnisse zuerst nach Folie und dann nach Textfeld:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Slide, NotesSlide, SlideUtil, TextSearchOptions

Color = jpype.JClass("java.awt.Color")
Pattern = jpype.JClass("java.util.regex.Pattern")

class TextMatch:
    def __init__(self, text_frame, source_text, found_text, text_position, slide_number):
        self.text_frame = text_frame
        self.source_text = source_text
        self.found_text = found_text
        self.text_position = text_position
        self.slide_number = slide_number


class TextSearchCallback:
    def __init__(self):
        self.results = []

    def foundResult(self, text_frame, source_text, found_text, text_position):
        parent_shape = text_frame.getParentShape()
        parent_cell = text_frame.getParentCell()
        if parent_shape is not None:
            parent_slide = parent_shape.getSlide()
        elif parent_cell is not None:
            parent_slide = parent_cell.getSlide()
        else:
            parent_slide = text_frame.getSlide()

        slide_number = None
        if isinstance(parent_slide, Slide):
            slide_number = parent_slide.getSlideNumber()
        elif isinstance(parent_slide, NotesSlide):
            slide_number = parent_slide.getParentSlide().getSlideNumber()

        result = TextMatch(text_frame, str(source_text), str(found_text), text_position, slide_number)
        self.results.append(result)


presentation = Presentation("presentation.pptx")
try:
    callback_handler = TextSearchCallback()
    callback = jpype.JProxy("com.aspose.slides.IFindResultCallback", inst=callback_handler)
    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)

    presentation.replaceText("Contoso", "Example Corp", search_options, callback)

    account_number_regex = Pattern.compile("\\bACCT-\\d{6}\\b")
    presentation.replaceRegex(account_number_regex, "ACCT-REDACTED", callback)

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx)
    matches_by_slide = {}
    for result in callback_handler.results:
        matches_by_text_frame = matches_by_slide.setdefault(result.slide_number, {})
        text_frame_matches = matches_by_text_frame.setdefault(result.text_frame, [])
        text_frame_matches.append(result)

    for slide_number, matches_by_text_frame in matches_by_slide.items():
        slide_label = "Other" if slide_number is None else str(slide_number)
        print(f"Slide: {slide_label}")
        for text_frame, results in matches_by_text_frame.items():
            print(f"  Text frame: {text_frame.getText()}")
            for result in results:
                print(f"    '{result.found_text}' at position {result.text_position}; context: '{result.source_text}'")
finally:
    presentation.dispose()
```

## **FAQ**

**Wie kann ich nur ein Textfeld statt der gesamten Präsentation durchsuchen?**

Rufen Sie das Textfeld der Form ab und verwenden Sie [TextFrame.highlightText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#highlightText), [TextFrame.highlightRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#highlightRegex), [TextFrame.replaceText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#replaceText) oder [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#replaceRegex) auf diesem Textfeld. Methoden auf Präsentationsebene verarbeiten stattdessen alle anwendbaren Textfelder.

**Wie kann ich ganze Wörter mit korrekter Groß-/Kleinschreibung abgleichen?**

Setzen Sie [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/de/python-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) und [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/de/python-java/aspose.slides/textsearchoptions/#setCaseSensitive) auf `True` und übergeben Sie die Optionen an eine Methode zum Hervorheben oder Ersetzen von wörtlichem Text. Für reguläre Ausdrücke definieren Sie Wortgrenzen und Groß-/Kleinschreibung im Java-`Pattern` selbst.

**Können Suche und Ersetzung Text in Foliennotizen einschließen?**

Ja. Setzen Sie [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/de/python-java/aspose.slides/textsearchoptions/#setIncludeNotes) auf `True`, wenn Sie eine wörtliche Text‑Operation auf Präsentationsebene verwenden. Die oben gezeigte Callback‑Implementierung ordnet eine Übereinstimmung in einer Notizfolie ihrer übergeordneten Foliennummer zu.

**Wie kann ich einen Bericht erstellen, ohne die Präsentation ein zweites Mal zu durchsuchen?**

Übergeben Sie eine `IFindResultCallback`‑Implementierung an die Hervorhebungs‑ oder Ersetzungs‑Operation. Der Callback erhält jede Übereinstimmung während der Ausführung, sodass die Anwendung den Quelltext, den gefundenen Text, die Position, das Textfeld und die abgeleitete Foliennummer für spätere Gruppierung oder den Export speichern kann.

**Behält das Ersetzen von Text dessen Formatierung bei?**

[TextFrame.replaceText](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#replaceText) und [TextFrame.replaceRegex](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#replaceRegex) ändern den gefundenen Text innerhalb des bestehenden Textfelds und behalten die umgebende Formatierung bei. Wenn eine Übereinstimmung Abschnitte mit unterschiedlicher Formatierung umfasst, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung den gewünschten Stil verwendet.