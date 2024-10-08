---
title: Portion
type: docs
weight: 70
url: /fr/python-net/portion/
keywords: "Portion, forme PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Obtenir la portion dans une présentation PowerPoint en Python"
---

## **Obtenir les Coordonnées de Position de la Portion**
La méthode **GetCoordinates()** a été ajoutée à l'interface IPortion et à la classe Portion, ce qui permet de récupérer les coordonnées du début de la portion :

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame

    for paragraph in textFrame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Coordonnées X =" + str(point.x) + " Coordonnées Y =" + str(point.y))
```