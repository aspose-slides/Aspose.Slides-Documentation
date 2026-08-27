---
title: "Suche und Ersetze Text in PowerPoint‑Präsentationen in Python"
linktitle: "Suche und Ersetze Text"
type: docs
weight: 55
url: /de/python-net/search-and-replace-text/
keywords:
- "Text suchen"
- "Text hervorheben"
- "Text ersetzen"
- "regulärer Ausdruck"
- "Textfeld"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Suchen, hervorheben und ersetzen Sie Text in PowerPoint‑Präsentationen mit Aspose.Slides für Python via .NET."
---
## **Übersicht**

Aspose.Slides for Python via .NET kann Text in einem einzelnen Textfeld oder in einer gesamten Präsentation suchen, hervorheben und ersetzen. Diese Funktionen sind nützlich für Überprüfungen, Schwärzungen, Terminologie‑Prüfungen, Vorlagenbereinigungen und andere automatisierte Dokumentverarbeitungs‑Workflows.

In den nachfolgenden ersten Beispielen verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Suchbereich auswählen**

Verwenden Sie Methoden von [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/), um eine Operation auf ein Textfeld zu beschränken. Verwenden Sie Methoden von [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/), um den gesamten anwendbaren Text in der Präsentation zu verarbeiten.

| Operation | Ein Textfeld | Ganze Präsentation |
|---|---|---|
| Literaltext hervorheben | [TextFrame.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/highlight_text/) |
| Regex‑Übereinstimmungen hervorheben | [TextFrame.highlight_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/highlight_regex/) |
| Literaltext ersetzen | [TextFrame.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/replace_text/) |
| Regex‑Übereinstimmungen ersetzen | [TextFrame.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/replace_regex/) |

## **Textabgleich konfigurieren**

Für Literaltext‑Operationen verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/), um den Abgleich zu steuern:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/whole_words_only/) begrenzt Übereinstimmungen auf ganze Wörter.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/case_sensitive/) steuert, ob die Groß‑ und Kleinschreibung übereinstimmen muss.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/include_notes/) schließt Foliennotizen in Suche, Ersetzungen und Hervorhebungen auf Präsentationsebene ein.

Regex‑Operationen verwenden einen Muster‑String, sodass Regeln wie Groß‑/Kleinschreibung und Wortgrenzen durch den Ausdruck definiert werden.

## **Den Eigentümer eines Textfelds ermitteln**

Generische Textverarbeitungs‑Workflows erhalten häufig ein [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/), während sie Text suchen, ersetzen, validieren oder exportieren. Verwenden Sie [TextFrame.parent_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_shape/) und [TextFrame.parent_cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_cell/), um festzustellen, welches Präsentationsobjekt das Textfeld besitzt.

Die erwarteten Werte hängen vom Eigentümer ab:

| Textfeld‑Eigentümer | `parent_shape` | `parent_cell` |
|---|---|---|
| Ein AutoShape oder eine andere Text‑enthaltende Shape | The owning [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/) | `None` |
| Eine Tabellenzelle | `None` | The owning [Cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/) |

Beide Eigenschaften sind schreibgeschützte Navigations‑Properties. Das Auslesen verschiebt das Textfeld nicht und ändert dessen Eigentümer nicht. Generischer Code sollte beide Werte auf `None` prüfen und die Möglichkeit berücksichtigen, dass kein Eigentümer verfügbar ist.

Das folgende Beispiel verwendet [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/de/python-net/aspose.slides.util/slideutil/get_all_text_frames/), um durch die Textfelder einer Präsentation zu iterieren. Für Shapes gibt es den Shape‑Namen, den Python‑Laufzeit‑Typ und die zugehörige Folie aus. Für Tabellenzellen werden die nullbasierten Spalten‑ und Zeilenkoordinaten sowie die zugehörige Folie ausgegeben.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Für SmartArt‑Inhalte iterieren Sie über die Shapes in [SmartArtNode.shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartartnode/shapes/) und greifen auf jedes [ISmartArtShape.text_frame](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/ismartartshape/text_frame/) zu. Das Textfeld lässt sich über [TextFrame.parent_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_shape/) zu seiner zugehörigen Shape zurückverfolgen, während [TextFrame.parent_cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_cell/) `None` ist. Daher verarbeitet der Shape‑Zweig im Beispiel auch Text aus SmartArt‑Knoten.

## **Text hervorheben**

Verwenden Sie die Methode [TextFrame.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_text/), um Literaltext‑Übereinstimmungen in einem Textfeld hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/), um die Suche zu steuern.

Das nachstehende Code‑Beispiel hebt alle Vorkommen der Zeichenfolge **"try"** hervor und hebt anschließend nur das vollständige Wort **"to"** hervor.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Alle Vorkommen von "try" im Textfeld hervorheben.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Nur das vollständige Wort "to" hervorheben.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Der hervorgehobene Text](highlighted_text.png)

## **Text mit regulären Ausdrücken hervorheben**

Die Methode [TextFrame.highlight_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_regex/) hebt Textübereinstimmungen hervor, die durch einen regulären Ausdruck in einem Textfeld gefunden wurden.

Der folgende Code hebt alle Wörter hervor, die sieben oder mehr Zeichen enthalten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Das Ergebnis:

![Der mit dem regulären Ausdruck hervorgehobene Text](highlighted_text_using_regex.png)

## **Text in einer gesamten Präsentation hervorheben**

Verwenden Sie [Presentation.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/highlight_text/) und [Presentation.highlight_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/highlight_regex/), um alle anwendbaren Textfelder in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen Literalbegriff und alle E‑Mail‑Adressen hervor:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Text in einem Textfeld ersetzen**

Verwenden Sie [TextFrame.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_text/) für Literaltext und [TextFrame.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_regex/) für ersatzbasierte Muster. Diese Methoden aktualisieren den gefundenen Text im bestehenden Textfeld, wobei die umgebende Formatierung erhalten bleibt, anstatt das Textfeld aus einem reinen String neu zu erstellen.

Das folgende Beispiel vereinheitlicht eine Schreibvarianten und ersetzt anschließend Versionsbezeichnungen:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Wenn eine Übereinstimmung Abschnitte mit unterschiedlicher Formatierung umfasst, prüfen Sie die Ausgabe, um zu bestätigen, welche Formatierung auf den ersetzten Text angewendet werden soll.

## **Text in einer gesamten Präsentation ersetzen**

Verwenden Sie [Presentation.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/replace_text/) und [Presentation.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/replace_regex/), um die gleichen Vorgänge über die gesamte Präsentation hinweg anzuwenden. Dies ist nützlich für die Bereinigung von Vorlagen, Terminologie‑Updates und Schwärzungen.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **FAQ**

**Wie kann ich nur ein Textfeld anstelle der gesamten Präsentation durchsuchen?**

Rufen Sie das Textfeld der Shape ab und rufen Sie [TextFrame.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_text/), oder [TextFrame.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_regex/) für dieses Textfeld auf. Methoden auf Präsentationsebene verarbeiten stattdessen alle anwendbaren Textfelder.

**Wie kann ich ganze Wörter mit korrekter Groß‑ und Kleinschreibung abgleichen?**

Setzen Sie [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/whole_words_only/) und [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/case_sensitive/) auf `True` und übergeben Sie die Optionen an eine Literaltext‑Hervorhebungs‑ oder Ersatz‑Methode. Bei regulären Ausdrücken definieren Sie Wortgrenzen und Groß‑/Kleinschreibung im Muster selbst.

**Können Suche und Ersetzung Text in Foliennotizen einbeziehen?**

Ja. Setzen Sie [TextSearchOptions.include_notes](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/include_notes/) auf `True`, wenn Sie eine Literaltext‑Operation auf Präsentationsebene verwenden.

**Behält das Ersetzen von Text dessen Formatierung bei?**

[TextFrame.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_text/) und [TextFrame.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_regex/) ändern den gefundenen Text im bestehenden Textfeld und behalten die umgebende Formatierung bei. Wenn eine Übereinstimmung Abschnitte mit unterschiedlicher Formatierung umfasst, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung den gewünschten Stil verwendet.