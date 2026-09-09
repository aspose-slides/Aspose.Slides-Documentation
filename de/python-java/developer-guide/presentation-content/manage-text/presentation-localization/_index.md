---
title: Automatisieren der Präsentationslokalisierung in Python via Java
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/python-java/presentation-localization/
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
- Java
- Aspose.Slides
description: "Legen Sie Korrektursprachen für PowerPoint- und OpenDocument-Präsentationstexte in Python via Java mit Aspose.Slides fest, einschließlich Standardwerte und mehrsprachiger Absätze."
---
## **Übersicht**

Aspose.Slides for Python via Java ermöglicht das Konfigurieren von Korrekturmetadaten für einzelne Textabschnitte. Verwenden Sie [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setLanguageId), um die Korrektursprache zu bestimmen, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setSpellCheck), um Rechtschreibprüfungen zu erlauben oder zu unterdrücken, und [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setProofDisabled), um den umfassenderen „nicht prüfen“-Zustand zu steuern. Da diese Einstellungen auf Abschnittsebene angewendet werden, kann ein Absatz mehrere Sprachen und unterschiedliche Korrekturregeln enthalten.

Dieser Artikel erklärt, wie man einer bestimmten Textstelle eine Sprache zuweist, die Standardsprache für neuen Text mit [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) festlegt, mehrsprachige Absätze erstellt, zwischen [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setSpellCheck) und [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setProofDisabled) wählt und die beabsichtigten Einstellungen beim Einsatz von [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) beibehält. Diese Eigenschaften speichern Metadaten für Präsentations‑Anwendungen; sie übersetzen keinen Text, führen keine wörterbuchbasierte Rechtschreibprüfung durch und geben keine falschen Wörter zurück.

## **Festlegen der Korrektursprache für Text**

Erstellen oder laden Sie eine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/), greifen Sie über [Portion.getPortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#getPortionFormat) auf den gewünschten Textabschnitt zu und weisen Sie dessen Sprachkennzeichen zu. Das folgende Beispiel erstellt eine Form, setzt Britisches Englisch als Korrektursprache und speichert das Ergebnis mit [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Festlegen der Standardsprache für neuen Text**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), um die Korrektursprache anzugeben, die Aspose.Slides neu erstelltem Text zuweist. Diese Einstellung ist nützlich, wenn die meisten oder alle neuen Texte in einer Präsentation dieselbe Sprache verwenden. Sie ändert nicht die Sprachmetadaten von Text, der bereits eine explizite Sprache hat.

Das folgende Beispiel erstellt eine Präsentation, deren neuer Text deutsche Korrekturregeln verwendet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mehrere Sprachen in einem Absatz verwenden**

Ein [Paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/) enthält eine Sammlung von Textabschnitten. Erstellen Sie für jede Sprache einen separaten [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) und setzen Sie dessen [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setLanguageId) unabhängig voneinander.

Dieses Beispiel erstellt einen Absatz mit englischen und französischen Abschnitten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Rechtschreibprüfung für einzelne Abschnitte aktivieren oder unterdrücken**

[PortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/) erbt die allgemeinen Texteigenschaften, die von [BasePortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/) definiert werden. Greifen Sie über [Portion.getPortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/#getPortionFormat) auf das Format eines Abschnitts zu und verwenden Sie [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setSpellCheck), um zu steuern, ob eine Präsentations‑Anwendung die Rechtschreibung für diesen Abschnitt prüfen darf. Der Standardwert ist `False`: `True` erlaubt die Rechtschreibprüfung, während `False` sie unterdrückt.

Die Einstellung gilt für einzelne Textabschnitte. Unterschiedliche Abschnitte im selben Absatz können daher verschiedene Werte verwenden. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setLanguageId) und [setSpellCheck](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setSpellCheck) erfüllen komplementäre Zwecke: [setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setLanguageId) identifiziert die Korrektursprache, während [setSpellCheck](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setSpellCheck) bestimmt, ob Rechtschreibprüfungen für den Abschnitt erlaubt sind.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setProofDisabled) steuert ebenfalls die Korrektur, stellt jedoch den umfassenderen „nicht prüfen“-Zustand als [NullableBool](https://reference.aspose.com/slides/de/python-java/aspose.slides/nullablebool/) dar. Verwenden Sie [setSpellCheck](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setSpellCheck), wenn Sie einen direkten booleschen Schalter speziell für Rechtschreibprüfungen benötigen. Verwenden Sie [setProofDisabled](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setProofDisabled), wenn Sie die „keine Korrektur“-Metadaten der Präsentation erhalten oder explizit steuern möchten, einschließlich ihres [NullableBool.NotDefined](https://reference.aspose.com/slides/de/python-java/aspose.slides/nullablebool/#NotDefined)-Zustands. Wenn Sie beide Eigenschaften setzen, halten Sie deren Werte konsistent; kombinieren Sie nicht [setSpellCheck](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setSpellCheck) `True` mit [setProofDisabled](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setProofDisabled) `NullableBool.True`.

Diese Eigenschaften konfigurieren Korrekturmetadaten, die von PowerPoint und anderen Präsentations‑Anwendungen verwendet werden. Aspose.Slides nutzt sie nicht, um wörterbuchbasierte Rechtschreibprüfungen durchzuführen oder eine Liste falscher Wörter zurückzugeben.

Das folgende vollständige Beispiel erstellt eine Eingabe‑Präsentation, lädt sie, weist zwei Abschnitten im gleichen Absatz unterschiedliche Rechtschreibprüfungs‑ und Korrekturspracheinstellungen zu, speichert das Ergebnis, öffnet es erneut und prüft die gespeicherten Werte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("f
r-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) kombiniert benachbarte Abschnitte, die dieselbe Formatierung besitzen. Ein Unterschied in [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setSpellCheck) allein reicht nicht aus, um solche Abschnitte getrennt zu halten; nach dem Zusammenführen behält der resultierende Abschnitt den [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setSpellCheck)-Wert des ersten Abschnitts. Wenn Abschnitte unterschiedliche Rechtschreibprüfungs‑Einstellungen benötigen, rufen Sie [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) vor dem Setzen dieser Einstellungen auf oder inspectieren Sie die resultierenden Abschnitts‑Grenzen und setzen die Einstellungen danach erneut. Abschnitte mit unterschiedlichen [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setLanguageId)-Werten bleiben getrennt, weil deren Korrektur‑Sprachformatierung verschieden ist.

## **FAQ**

**Wandelt eine Sprach‑ID den Text um?**

Nein. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setLanguageId) speichert Korrektur‑Metadaten für Rechtschreibung und Grammatik; sie ändert den Textinhalt nicht. Übersetzen Sie den Text separat und setzen Sie anschließend das passende Sprachkennzeichen für jeden übersetzten Abschnitt.

**Steuert die Korrektursprache Schriftarten, Silbentrennung oder Zeilenumbruch?**

Nein. Die Sprachkennung dient der Korrektur. Textdarstellung und Layout hängen primär von den verfügbaren [fonts](/slides/de/python-java/powerpoint-fonts/), dem Schriftsystem und den Texte‑Frame‑Einstellungen ab. Für eine zuverlässige Darstellung stellen Sie die erforderlichen Schriftarten bereit, konfigurieren Sie [font substitution](/slides/de/python-java/font-substitution/), oder betten Sie Schriftarten mit [embed fonts](/slides/de/python-java/embedded-font/) in die Präsentation ein.

**Kann ein Absatz mehrere Korrektursprachen verwenden?**

Ja. Weisen Sie jeder Sprache einen separaten Abschnitt zu, wie im mehrsprachigen Absatz‑Beispiel gezeigt.

**Sollte ich [setDefaultTextLanguage](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) oder [setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setLanguageId) verwenden?**

Verwenden Sie [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), wenn Sie einen Standard für neu erstellten Text festlegen möchten. Verwenden Sie [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setLanguageId), wenn ein bestimmter Abschnitt eine explizite Korrektursprache benötigt oder ein Absatz mehrere Sprachen enthält.