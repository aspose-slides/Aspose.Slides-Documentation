---
title: ポーション
type: docs
weight: 70
url: /ja/python-net/portion/
keywords: "ポーション, PowerPoint図形, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションのポーションを取得"
---

## **ポーションの位置座標を取得**
**GetCoordinates()** メソッドがIPortionおよびPortionクラスに追加され、ポーションの開始位置の座標を取得できるようになりました：

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame

    for paragraph in textFrame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("座標 X =" + str(point.x) + " 座標 Y =" + str(point.y))
```