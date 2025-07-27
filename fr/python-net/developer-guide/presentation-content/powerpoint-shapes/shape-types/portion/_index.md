---
title: Gérer les parties de texte dans les présentations avec Python
linktitle: Portion de texte
type: docs
weight: 70
url: /fr/python-net/portion/
keywords:
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment gérer les portions de texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides for Python via .NET, afin d'améliorer les performances et la personnalisation."
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