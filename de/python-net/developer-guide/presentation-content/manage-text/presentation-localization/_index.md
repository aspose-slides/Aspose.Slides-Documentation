---
title: Automatisiere Präsentationslokalisierung mit Python
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
description: "Automatisiere die Lokalisierung von PowerPoint- und OpenDocument-Folien in Python mit Aspose.Slides, indem du praktische Codebeispiele und Tipps für eine schnellere globale Einführung nutzt."
---

## **Sprache für Präsentation und Text von Formen ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
- Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie der Folie eine AutoShape vom Typ Rectangle hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- Setzen der Language Id für den Text.
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

**Löst die Language ID eine automatische Textübersetzung aus?**

Nein. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, jedoch übersetzt sie nicht und ändert den Textinhalt nicht. Es handelt sich um Metadaten, die PowerPoint für die Korrektur versteht.

**Beeinflusst die Language ID Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides wird [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) für die Korrektur verwendet. Die Qualität der Silbentrennung und des Zeilenumbruchs hängt hauptsächlich von der Verfügbarkeit geeigneter Schriften ([proper fonts](/slides/de/python-net/powerpoint-fonts/)) und den Layout‑/Zeilenumbruch‑Einstellungen für das Schriftsystem ab. Um ein korrektes Rendern sicherzustellen, stellen Sie die erforderlichen Schriften bereit, konfigurieren Sie [font substitution rules](/slides/de/python-net/font-substitution/) und/oder betten Sie Schriften ([embed fonts](/slides/de/python-net/embedded-font/)) in die Präsentation ein.

**Kann ich verschiedene Sprachen innerhalb eines einzelnen Absatzes festlegen?**

Ja. [language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Korrektureinstellungen mischen kann.