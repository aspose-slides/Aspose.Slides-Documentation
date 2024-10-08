---
title: Portion
type: docs
weight: 70
url: /de/python-net/portion/
keywords: "Portion, PowerPoint-Form, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Erhalten Sie Portion in PowerPoint-Präsentation in Python"
---

## **Positionkoordinaten der Portion abrufen**
**GetCoordinates()**-Methode wurde zur IPortion- und Portion-Klasse hinzugefügt, die es ermöglicht, die Koordinaten des Beginns der Portion abzurufen:

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame

    for paragraph in textFrame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Koordinaten X =" + str(point.x) + " Koordinaten Y =" + str(point.y))
```