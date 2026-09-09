---
title: Verwalten von Hoch- und Tiefgestelltem Text in Präsentationen mit Python via Java
linktitle: Hoch- und Tiefgestellt
type: docs
weight: 80
url: /de/python-java/superscript-and-subscript/
keywords:
- hochgestellt
- tiefgestellt
- hochgestellt hinzufügen
- tiefgestellt hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Meistern Sie Hoch- und Tiefgestellt in Aspose.Slides für Python via Java und verleihen Sie Ihren Präsentationen mit professioneller Textformatierung maximale Wirkung."
---
## **Übersicht**

Aspose.Slides bietet Funktionen zum Einbinden von hoch- und tiefgestelltem Text in Ihre PowerPoint‑ (PPT, PPTX) und OpenDocument‑ (ODP) Präsentationen. Egal, ob Sie chemische Formeln, mathematische Gleichungen hervorheben oder Inhalte mit Fußnoten versehen möchten, diese speziellen Formatierungsoptionen tragen zur Klarheit und Präzision bei. In diesem Artikel lernen Sie, wie Sie hoch- und tiefgestellte Stile nahtlos anwenden und professionelle Ergebnisse in jeder Folie erzielen.

## **Verwalten von hoch- und tiefgestelltem Text**

Sie können hoch- und tiefgestellten Text zu jedem Teil eines Absatzes hinzufügen. Um diese Formatierung in einem Aspose.Slides‑Textfeld anzuwenden, verwenden Sie die [setEscapement](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#setEscapement)‑Methode der [PortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/)‑Klasse.

Der Escapement‑Wert reicht von –100 % (tiefgestellt) bis 100 % (hochgestellt). Beispiel:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.
- Rufen Sie eine Folie anhand ihres Index ab.
- Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) vom Typ [ShapeType.Rectangle](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#Rectangle) hinzu.
- Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) zu, das mit der [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) verknüpft ist.
- Löschen Sie die vorhandenen Absätze.
- Erstellen Sie einen Absatz, der hochgestellten Text enthält, und fügen Sie ihn der TextFrames [paragraph collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParagraphs) hinzu.
- Erstellen Sie eine Portion.
- Verwenden Sie [setEscapement](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#setEscapement), um einen Wert von 0 bis 100 für hochgestellten Text festzulegen (0 bedeutet kein hochgestellter Text).
- Setzen Sie den Text der [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) und fügen Sie ihn der Portion‑Sammlung des Absatzes hinzu.
- Erstellen Sie einen Absatz, der tiefgestellten Text enthält, und fügen Sie ihn der TextFrames [paragraph collection](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParagraphs) hinzu.
- Erstellen Sie eine Portion.
- Verwenden Sie [setEscapement](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/#setEscapement), um einen Wert von –100 bis 0 für tiefgestellten Text festzulegen (0 bedeutet kein tiefgestellter Text).
- Setzen Sie den Text der [Portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) und fügen Sie ihn der Portion‑Sammlung des Absatzes hinzu.
- Speichern Sie die Präsentation als PPTX‑Datei.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Erstelle eine Präsentation.
presentation = Presentation()
try:
    # Hole die Folie.
    slide = presentation.getSlides().get_Item(0)

    # Erstelle ein Textfeld.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Erstelle einen Absatz für hochgestellten Text.
    superscript_paragraph = Paragraph()

    # Erstelle einen Abschnitt mit normalem Text.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Erstelle einen Abschnitt mit hochgestelltem Text.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Erstelle einen Absatz für tiefgestellten Text.
    subscript_paragraph = Paragraph()

    # Erstelle einen Abschnitt mit normalem Text.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Erstelle einen Abschnitt mit tiefgestelltem Text.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Füge die Absätze dem Textfeld hinzu.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wird hoch- und tiefgestellter Text beim Exportieren nach PDF oder anderen Formaten beibehalten?**

Ja, Aspose.Slides behält die hoch- und tiefgestellte Formatierung beim Exportieren von Präsentationen nach PDF, PPT/PPTX, Bildern und anderen unterstützten Formaten korrekt bei. Die spezielle Formatierung bleibt in allen Ausgabedateien erhalten.

**Kann hoch- und tiefgestellter Text mit anderen Formatierungsstilen wie Fett oder Kursiv kombiniert werden?**

Ja, Aspose.Slides ermöglicht das Mischen verschiedener Textstile innerhalb einer einzelnen Portion. Sie können Fett, Kursiv, Unterstreichen aktivieren und gleichzeitig hoch- oder tiefgestellten Text anwenden, indem Sie die entsprechenden Eigenschaften in [PortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/) konfigurieren.

**Funktioniert die hoch- und tiefgestellte Formatierung für Text in Tabellen, Diagrammen oder SmartArt?**

Ja, Aspose.Slides unterstützt die Formatierung in den meisten Objekten, einschließlich Tabellen und Diagrammelementen. Beim Arbeiten mit SmartArt müssen Sie die entsprechenden Elemente (wie [SmartArtNode](https://reference.aspose.com/slides/de/python-java/aspose.slides/smartartnode/)) und deren Textcontainer zugreifen und dann die [PortionFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/portionformat/)‑Eigenschaften auf ähnliche Weise konfigurieren.