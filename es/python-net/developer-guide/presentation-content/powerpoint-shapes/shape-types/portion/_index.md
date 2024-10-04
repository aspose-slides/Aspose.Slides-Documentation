---
title: Porción
type: docs
weight: 70
url: /es/python-net/portion/
keywords: "Porción, forma de PowerPoint, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Obtener porción en la presentación de PowerPoint en Python"
---

## **Obtener Coordenadas de la Posición de la Porción**
El método **GetCoordinates()** ha sido añadido a la interfaz IPortion y a la clase Portion, lo que permite recuperar las coordenadas del inicio de la porción:

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame

    for paragraph in textFrame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Coordenadas X =" + str(point.x) + " Coordenadas Y =" + str(point.y))
```