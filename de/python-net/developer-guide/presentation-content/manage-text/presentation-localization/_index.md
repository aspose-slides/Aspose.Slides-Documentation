---
title: Präsentationslokalisierung
type: docs
weight: 100
url: /python-net/presentation-localization/
keywords: "Sprache ändern, Rechtschreibprüfung, Rechtschreibprüfung, Rechtschreibprüfer, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Sprache in einer PowerPoint-Präsentation ändern oder überprüfen. Text in Python Rechtschreibung prüfen"
---
## **Sprache für Präsentation und Text von Formen ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
- Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
- Fügen Sie der Folie eine AutoForm des Typs Rechteck hinzu.
- Fügen Sie dem TextFrame Text hinzu.
- Sprache ID für den Text festlegen.
- Speichern Sie die Präsentation als PPTX-Datei.

Die Implementierung der obigen Schritte wird unten in einem Beispiel demonstriert.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Text zur Anwendung der Rechtschreibprüfungsprache")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```