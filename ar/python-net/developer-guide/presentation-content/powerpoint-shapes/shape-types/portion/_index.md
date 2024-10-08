---
title: جزء
type: docs
weight: 70
url: /ar/python-net/portion/
keywords: "جزء، شكل PowerPoint، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "احصل على جزء في عرض PowerPoint باستخدام بايثون"
---

## **احصل على إحداثيات موضع الجزء**
تمت إضافة طريقة **GetCoordinates()** إلى واجهة IPortion وفئة Portion التي تسمح باسترداد إحداثيات بداية الجزء:

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame

    for paragraph in textFrame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("الإحداثيات X =" + str(point.x) + " الإحداثيات Y =" + str(point.y))
```