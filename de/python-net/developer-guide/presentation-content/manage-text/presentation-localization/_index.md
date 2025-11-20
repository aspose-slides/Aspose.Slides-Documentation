---
title: Automatisieren Sie die Lokalisierung von Präsentationen mit Python
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
description: "Automatisieren Sie die Lokalisierung von PowerPoint- und OpenDocument‑Folien in Python mit Aspose.Slides, mithilfe praktischer Code‑Beispiele und Tipps für eine schnellere globale Einführung."
---

## **Sprache für Präsentation und Text von Formen ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Rufen Sie die Referenz einer Folie ab, indem Sie deren Index verwenden.
- Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- Legen Sie die Language Id für den Text fest.
- Schreiben Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte wird unten in einem Beispiel gezeigt.
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

Nein. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, führt jedoch keine Übersetzung oder Änderung des Textinhalts durch. Es handelt sich um Metadaten, die PowerPoint für die Prüfung versteht.

**Beeinflusst language_id die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides dient [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) der Prüfung. Die Qualität der Silbentrennung und des Zeilenumbruchs hängt hauptsächlich von der Verfügbarkeit geeigneter [Fonts](/slides/de/python-net/powerpoint-fonts/) und den Layout‑/Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Um ein korrektes Rendern sicherzustellen, stellen Sie die erforderlichen Fonts bereit, konfigurieren Sie [Font‑Ersetzungsregeln](/slides/de/python-net/font-substitution/) und/oder [betten Sie Fonts ein](/slides/de/python-net/embedded-font/) in die Präsentation ein.

**Kann ich unterschiedliche Sprachen innerhalb eines einzelnen Absatzes festlegen?**

Ja. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Prüfungseinstellungen mischen kann.