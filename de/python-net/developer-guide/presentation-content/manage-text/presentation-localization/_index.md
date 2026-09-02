---
title: Automatisieren Sie die Lokalisierung von Präsentationen mit Python
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/python-net/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Rechtschreibprüfung unterdrücken
- Korrektursprache
- Sprach-ID
- mehrsprachiger Text
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Legen Sie Korrektursprachen für PowerPoint- und OpenDocument-Präsentationstexte in Python mit Aspose.Slides fest, einschließlich Vorgaben und mehrsprachiger Absätze."
---
## **Übersicht**

Aspose.Slides for Python via .NET ermöglicht das Konfigurieren von Korrektur‑Metadaten für einzelne Textabschnitte. Verwenden Sie [BasePortionFormat.language_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/language_id/), um die Korrektursprache zu bestimmen, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/spell_check/), um Rechtschreibprüfungen zuzulassen oder zu unterdrücken, und [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/proof_disabled/), um den umfassenderen „nicht prüfen“-Zustand zu steuern. Da diese Einstellungen auf Abschnittsebene angewendet werden, kann ein Absatz mehrere Sprachen und unterschiedliche Korrektureinstellungen enthalten.

Dieser Artikel erläutert, wie Sie einer bestimmten Textpassage eine Sprache zuweisen, die Standardsprache für neuen Text mit [LoadOptions.default_text_language](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/default_text_language/) festlegen, mehrsprachige Absätze erstellen, zwischen `spell_check` und `proof_disabled` wählen und die beabsichtigten Einstellungen beim Einsatz von [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) beibehalten. Diese Eigenschaften speichern Metadaten für Präsentations‑Anwendungen; sie übersetzen den Text nicht, führen keine wörterbuchbasierte Rechtschreibprüfung durch und geben keine falschen Wörter zurück.

## **Korrektursprache für Text festlegen**

Erstellen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/), greifen Sie über [Portion.portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/portion_format/) auf den gewünschten Textabschnitt zu und weisen Sie dessen Sprach‑Identifier zu. Das folgende Beispiel erstellt eine Form, legt Britisches Englisch als Korrektursprache fest und speichert das Ergebnis mit [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Standard‑Sprache für neuen Text festlegen**

Verwenden Sie [LoadOptions.default_text_language](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/default_text_language/), um die Korrektursprache anzugeben, die Aspose.Slides neu erstelltem Text zuweist. Diese Einstellung ist nützlich, wenn die meisten oder alle neuen Texte einer Präsentation dieselbe Sprache verwenden. Sie ändert nicht die Sprach‑Metadaten von Text, der bereits eine explizite Sprache hat.

Das folgende Beispiel erstellt eine Präsentation, deren neuer Text deutsche Korrekturregeln verwendet:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Mehrere Sprachen in einem Absatz verwenden**

Ein [Paragraph](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraph/) enthält eine Sammlung von Textabschnitten. Erstellen Sie für jede Sprache einen separaten [Portion](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/) und setzen Sie dessen `language_id` unabhängig voneinander.

Dieses Beispiel erstellt einen Absatz mit englischen und französischen Abschnitten:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Rechtschreibprüfung für einzelne Textteile aktivieren oder unterdrücken**

[PortionFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/portionformat/) erbt die allgemeinen Texteigenschaften von [BasePortionFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/). Greifen Sie über [Portion.portion_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/portion/portion_format/) auf das Format eines Abschnitts zu und setzen Sie [BasePortionFormat.spell_check](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/spell_check/), um zu steuern, ob eine Präsentations‑Anwendung die Rechtschreibung für diesen Abschnitt prüfen darf. Der Standardwert ist `False`: `True` erlaubt die Rechtschreibprüfung, `False` unterdrückt sie.

Die Einstellung gilt für einzelne Textabschnitte. Unterschiedliche Abschnitte im selben Absatz können daher unterschiedliche Werte besitzen. [BasePortionFormat.language_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/language_id/) und `spell_check` erfüllen komplementäre Aufgaben: `language_id` identifiziert die Korrektursprache, während `spell_check` bestimmt, ob Rechtschreibprüfungen für den Abschnitt erlaubt sind.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/proof_disabled/) steuert ebenfalls die Korrektur, repräsentiert jedoch den umfassenderen „nicht prüfen“-Zustand als [NullableBool](https://reference.aspose.com/slides/de/python-net/aspose.slides/nullablebool/). Verwenden Sie `spell_check`, wenn Sie einen direkten booleschen Schalter ausschließlich für Rechtschreibprüfungen benötigen. Verwenden Sie `proof_disabled`, wenn Sie die „nicht prüfen“-Metadaten der Präsentation erhalten oder explizit steuern wollen, einschließlich des `NOT_DEFINED`‑Zustands. Wenn Sie beide Eigenschaften setzen, halten Sie deren Werte konsistent; kombinieren Sie nicht `spell_check = True` mit `proof_disabled = slides.NullableBool.TRUE`.

Diese Eigenschaften konfigurieren Korrektur‑Metadaten, die von PowerPoint und anderen Präsentations‑Anwendungen genutzt werden. Aspose.Slides verwendet sie nicht, um wörterbuchbasierte Rechtschreibprüfungen durchzuführen oder eine Liste falscher Wörter zurückzugeben.

Das folgende vollständige Beispiel erstellt eine Eingabe‑Präsentation, lädt sie, weist zwei Abschnitten im selben Absatz unterschiedliche Rechtschreib‑ und Korrektureinstellungen zu, speichert das Ergebnis, öffnet es erneut und prüft die gespeicherten Werte:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) verbindet benachbarte Abschnitte, die dieselbe Formatierung besitzen. Ein Unterschied nur in `spell_check` reicht nicht aus, um solche Abschnitte getrennt zu halten; nach dem Zusammenführen behält der resultierende Abschnitt den `spell_check`‑Wert des ersten Abschnitts. Wenn Abschnitte unterschiedliche Rechtschreib‑Einstellungen benötigen, rufen Sie `join_portions_with_same_formatting` vor dem Setzen dieser Einstellungen auf oder prüfen Sie die resultierenden Abschnittsgrenzen und setzen die Einstellungen danach erneut. Abschnitte mit unterschiedlichen `language_id`‑Werten bleiben getrennt, weil ihre Korrektur‑Sprachformatierung unterschiedlich ist.

## **FAQ**

**Wird ein Sprach‑Identifier den Text übersetzen?**

Nein. [BasePortionFormat.language_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/language_id/) speichert Korrektur‑Metadaten für Rechtschreibung und Grammatik; es ändert den Textinhalt nicht. Übersetzen Sie den Text separat und setzen Sie anschließend den passenden Sprach‑Identifier für jeden übersetzten Abschnitt.

**Steuert die Korrektursprache Schriften, Silbentrennung oder Zeilenumbruch?**

Nein. Der Sprach‑Identifier dient ausschließlich der Korrektur. Textdarstellung und Layout hängen hauptsächlich von den verfügbaren [fonts](/slides/de/python-net/powerpoint-fonts/), dem Schriftsystem und den Einstellungen des Text‑Frames ab. Für eine zuverlässige Darstellung stellen Sie die erforderlichen Schriften bereit, konfigurieren Sie die [font substitution](/slides/de/python-net/font-substitution/), oder betten Sie Schriften mit [embed fonts](/slides/de/python-net/embedded-font/) in die Präsentation ein.

**Kann ein Absatz mehrere Korrektursprachen verwenden?**

Ja. Weisen Sie jeder Sprache einen separaten Abschnitt zu, wie im mehrsprachigen Absatz‑Beispiel gezeigt.

**Sollte ich `default_text_language` oder `language_id` verwenden?**

Verwenden Sie [LoadOptions.default_text_language](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadoptions/default_text_language/), wenn Sie eine Vorgabe für neu erstellten Text festlegen möchten. Verwenden Sie [BasePortionFormat.language_id](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseportionformat/language_id/), wenn ein bestimmter Abschnitt eine explizite Korrektursprache benötigt oder ein Absatz mehrere Sprachen enthält.