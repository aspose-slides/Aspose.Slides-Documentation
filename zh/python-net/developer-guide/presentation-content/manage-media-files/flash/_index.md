---
title: Flash
type: docs
weight: 10
url: /python-net/flash/
keywords: "提取 Flash，PowerPoint 演示文稿，Python，Aspose.Slides for Python via .NET"
description: "在 Python 中从 PowerPoint 演示文稿中提取 Flash 对象"
---

## **从演示文稿中提取 Flash 对象**
Aspose.Slides for Python via .NET 提供了一种从演示文稿中提取 Flash 对象的功能。您可以通过名称访问 Flash 控件并将其从演示文稿中提取，包括存储 SWF 对象数据。

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```