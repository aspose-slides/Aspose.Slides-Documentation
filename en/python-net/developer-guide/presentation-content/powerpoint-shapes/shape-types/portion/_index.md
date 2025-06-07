---
title: Manage Text Portions in Presentations with Python
linktitle: Text Portion
type: docs
weight: 70
url: /python-net/portion/
keywords:
- text portion
- text part
- text coordinates
- text position
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to manage text portions in PowerPoint and OpenDocument presentations using Aspose.Slides for Python via .NET, boosting performance and customization."
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

