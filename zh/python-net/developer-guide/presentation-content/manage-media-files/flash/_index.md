---
title: 在 Python 中从演示文稿提取 Flash 对象
linktitle: Flash
type: docs
weight: 10
url: /zh/python-net/flash/
keywords:
- 提取 Flash
- Flash 对象
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 Python 中从 PowerPoint 和 OpenDocument 幻灯片中提取 Flash 对象，包含完整的代码示例和最佳实践."
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