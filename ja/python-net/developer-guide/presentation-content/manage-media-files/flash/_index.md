---
title: Python でプレゼンテーションから Flash オブジェクトを抽出する
linktitle: Flash
type: docs
weight: 10
url: /ja/python-net/flash/
keywords:
- Flash 抽出
- Flash オブジェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して、PowerPoint および OpenDocument スライドから Flash オブジェクトを抽出する方法を学び、完全なコード サンプルとベスト プラクティスを提供します。"
---

## **プレゼンテーションからフラッシュオブジェクトを抽出**
Aspose.Slides for Python via .NETは、プレゼンテーションからフラッシュオブジェクトを抽出する機能を提供します。名前でフラッシュコントロールにアクセスし、プレゼンテーションから抽出し、SWFオブジェクトデータを保存できます。

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```