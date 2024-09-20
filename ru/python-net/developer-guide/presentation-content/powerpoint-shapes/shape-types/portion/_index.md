---
title: Часть
type: docs
weight: 70
url: /python-net/portion/
keywords: "Часть, Фигура PowerPoint, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Получить часть в презентации PowerPoint на Python"
---

## **Получить координаты позиции части**
Метод **GetCoordinates()** был добавлен в классы IPortion и Portion, который позволяет получать координаты начала части:

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame

    for paragraph in textFrame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Координаты X =" + str(point.x) + " Координаты Y =" + str(point.y))
```