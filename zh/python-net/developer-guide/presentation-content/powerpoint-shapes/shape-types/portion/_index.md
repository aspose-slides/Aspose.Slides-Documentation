---
title: 部分
type: docs
weight: 70
url: /python-net/portion/
keywords: "部分, PowerPoint形状, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在Python中获取PowerPoint演示文稿中的部分"
---

## **获取部分的位置信息坐标**
**GetCoordinates()** 方法已添加到 IPortion 和 Portion 类中，可以用来获取部分开始位置的坐标：

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame

    for paragraph in textFrame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("坐标 X =" + str(point.x) + " 坐标 Y =" + str(point.y))
```