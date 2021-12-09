---
title: Portion
type: docs
weight: 70
url: /pythonnet/portion/
keywords: "Portion, PowerPoint shape, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Get portion in PowerPoint presentation in Python"
---

## **Get Position Coordinates of Portion**
**GetCoordinates()** method has been added to IPortion and Portion class which allows retrieving the coordinates of the beginning of the portion:

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame

    for paragraph in textFrame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

