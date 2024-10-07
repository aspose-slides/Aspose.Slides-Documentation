---
title: Präsentation erstellen
type: docs
weight: 10
url: /python-net/create-presentation/
keywords: "PowerPoint erstellen, PPTX, PPT, Präsentation erstellen, Präsentation initialisieren, Python, .NET"
description: "PowerPoint-Präsentation in Python öffnen"
---

## **PowerPoint-Präsentation erstellen**
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die untenstehenden Schritte:

1. Erstellen Sie eine Instanz der Klasse Präsentation.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine AutoShape vom Typ `LINE` mit der Methode `add_auto_shape` hinzu, die vom `shapes`-Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im untenstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```py
import aspose.slides as slides

# Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```