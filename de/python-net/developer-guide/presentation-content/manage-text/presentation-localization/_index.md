---
title: Automatisiere die Lokalisierung von Präsentationen mit Python
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/python-net/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Sprach-ID
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Automatisiere die Lokalisierung von PowerPoint- und OpenDocument-Folien in Python mit Aspose.Slides, unter Verwendung praktischer Codebeispiele und Tipps für eine schnellere globale Einführung."
---

## **Sprache für Präsentation und Text von Formen ändern**
- Erstelle eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Hole die Referenz einer Folie, indem du ihren Index verwendest.
- Füge der Folie ein AutoShape vom Typ Rechteck hinzu.
- Füge dem TextFrame etwas Text hinzu.
- Setze die Sprach-ID für den Text.
- Speichere die Präsentation als PPTX-Datei.

Die Umsetzung der oben genannten Schritte wird unten in einem Beispiel gezeigt.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text to apply spellcheck language")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Löst language_id eine automatische Textübersetzung aus?**

Nein. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, übersetzt jedoch nicht den Textinhalt und ändert ihn nicht. Es handelt sich um Metadaten, die PowerPoint für die Korrektur versteht.

**Beeinflusst language_id die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides dient [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) der Korrektur. Die Qualität der Silbentrennung und der Zeilenumbruch hängen hauptsächlich von der Verfügbarkeit der [richtigen Schriften](/slides/de/python-net/powerpoint-fonts/) sowie von Layout‑/Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Um ein korrektes Rendern zu gewährleisten, stelle die erforderlichen Schriften bereit, konfiguriere die [Schrift­ersatzregeln](/slides/de/python-net/font-substitution/) und/oder [bette Schriften ein](/slides/de/python-net/embedded-font/) in die Präsentation.

**Kann ich verschiedene Sprachen innerhalb eines einzelnen Absatzes festlegen?**

Ja. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Korrektureinstellungen kombinieren kann.