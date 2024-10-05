---
title: フラッシュ
type: docs
weight: 10
url: /python-net/flash/
keywords: "フラッシュ抽出、PowerPointプレゼンテーション、Python、Aspose.Slides for Python via .NET"
description: "PythonでPowerPointプレゼンテーションからフラッシュオブジェクトを抽出"
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