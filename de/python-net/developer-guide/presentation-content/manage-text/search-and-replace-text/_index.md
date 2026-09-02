---
title: Suche und ersetze Text in PowerPoint-Präsentationen in Python
linktitle: Suche und ersetze Text
type: docs
weight: 55
url: /de/python-net/search-and-replace-text/
keywords:
- Text suchen
- Text hervorheben
- Text ersetzen
- regulärer Ausdruck
- Textfeld
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Suchen, Hervorheben und Ersetzen von Text in PowerPoint-Präsentationen mit Aspose.Slides für Python via .NET."
---
## **Übersicht**

Aspose.Slides für Python via .NET kann Text in einem einzelnen Textfeld oder in einer gesamten Präsentation suchen, hervorheben und ersetzen. Diese Funktionen sind nützlich für Überprüfungen, Schwärzungen, Terminologieprüfungen, Vorlagenbereinigungen und andere automatisierte Dokumentenverarbeitungs‑Workflows.

In den nachstehenden ersten Beispielen verwenden wir eine Datei namens "sample.pptx", die auf der ersten Folie ein einzelnes Textfeld mit folgendem Text enthält:

![Beispieltext](sample_text.png)

## **Wählen Sie den Suchbereich**

Verwenden Sie Methoden auf [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) um einen Vorgang auf ein Textfeld zu beschränken. Verwenden Sie Methoden auf [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/) um allen anwendbaren Text in der Präsentation zu verarbeiten.

| Vorgang | Ein Textfeld | Gesamte Präsentation |
|---|---|---|
| Literal‑Text hervorheben | [TextFrame.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/highlight_text/) |
| Übereinstimmungen per regulärem Ausdruck hervorheben | [TextFrame.highlight_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/highlight_regex/) |
| Literal‑Text ersetzen | [TextFrame.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/replace_text/) |
| Übereinstimmungen per regulärem Ausdruck ersetzen | [TextFrame.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/replace_regex/) |

## **Textabgleich konfigurieren**

Für Vorgänge mit literalem Text verwenden Sie [TextSearchOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/) zur Steuerung des Abgleichs:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/whole_words_only/) beschränkt Übereinstimmungen auf ganze Wörter.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/case_sensitive/) steuert, ob die Groß‑/Kleinschreibung der Zeichen übereinstimmen muss.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/include_notes/) schließt Foliennotizen in Präsentations‑spezifischen Such-, Ersetz‑ und Hervorhebungs‑Operationen ein.

Operationen mit regulären Ausdrücken verwenden einen Musternstring, sodass Abgleichregeln wie Groß‑/Kleinschreibung und Wortgrenzen durch den Ausdruck definiert werden.

## **Text hervorheben**

Verwenden Sie die Methode [TextFrame.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_text/), um literal‑Text‑Übereinstimmungen in einem Textfeld hervorzuheben. Übergeben Sie [TextSearchOptions](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/), um die Suche zu steuern.

Das nachstehende Code‑Beispiel hebt alle Vorkommen der Zeichen **"try"** hervor und danach nur das ganze Wort **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Hervorheben jedes Vorkommens von "try" im Textfeld.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Nur das komplette Wort "to" hervorheben.
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

Verwenden Sie [Presentation.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/highlight_text/) und [Presentation.highlight_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/highlight_regex/), um alle anwendbaren Textfelder in einer Präsentation zu durchsuchen. Das folgende Beispiel hebt einen literal‑Begriff und alle E‑Mail‑Adressen hervor:

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

Verwenden Sie [TextFrame.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_text/), um literal‑Text zu ersetzen, und [TextFrame.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_regex/), um ersatzbasierte Ersetzungen vorzunehmen. Diese Methoden aktualisieren den übereinstimmenden Text innerhalb des vorhandenen Textfelds, wobei die Formatierung des umgebenden Abschnitts erhalten bleibt, anstatt das Textfeld aus einem einfachen Zeichenketten‑String neu zu erstellen.

Das folgende Beispiel standardisiert eine Schreibvariante und ersetzt anschließend Versionsbezeichnungen:

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

Falls eine Übereinstimmung Bereiche mit unterschiedlicher Formatierung überlappt, überprüfen Sie die Ausgabe, um sicherzustellen, welche Formatierung auf den ersetzten Text angewendet werden soll.

## **Text in einer gesamten Präsentation ersetzen**

Verwenden Sie [Presentation.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/replace_text/) und [Presentation.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/replace_regex/), um dieselben Vorgänge in der gesamten Präsentation anzuwenden. Dies ist nützlich für Vorlagenbereinigung, Terminologie‑Updates und Schwärzungen.

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

Rufen Sie das Textfeld der Form auf und rufen Sie [TextFrame.highlight_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_text/) oder [TextFrame.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_regex/) für dieses Textfeld auf. Methoden auf Präsentationsebene verarbeiten stattdessen alle anwendbaren Textfelder.

**Wie kann ich ganze Wörter mit der korrekten Schreibweise abgleichen?**

Setzen Sie [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/whole_words_only/) und [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/case_sensitive/) auf `True` und übergeben Sie die Optionen an eine literal‑Texthervorhebungs‑ oder Ersetzungsmethode. Bei regulären Ausdrücken definieren Sie Wortgrenzen und Groß‑/Kleinschreibung im Muster selbst.

**Können Suche und Ersetzung Text in Foliennotizen einbeziehen?**

Ja. Setzen Sie [TextSearchOptions.include_notes](https://reference.aspose.com/slides/de/python-net/aspose.slides/textsearchoptions/include_notes/) auf `True`, wenn Sie eine literal‑Text‑Operation auf Präsentationsebene verwenden.

**Behält das Ersetzen von Text dessen Formatierung bei?**

[TextFrame.replace_text](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_text/) und [TextFrame.replace_regex](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/replace_regex/) ändern den übereinstimmenden Text innerhalb des bestehenden Textfelds und behalten die Formatierung des umgebenden Abschnitts bei. Wenn eine Übereinstimmung Bereiche mit unterschiedlicher Formatierung überlappt, prüfen Sie das Ergebnis, um sicherzustellen, dass die Ersetzung den gewünschten Stil verwendet.