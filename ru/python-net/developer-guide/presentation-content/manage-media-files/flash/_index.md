---
title: Флеш
type: docs
weight: 10
url: /python-net/flash/
keywords: "Извлечение флеш, Презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Извлечение флеш-объекта из презентации PowerPoint на Python"
---

## **Извлечение флеш-объектов из презентации**
Aspose.Slides для Python через .NET предоставляет возможность извлекать флеш-объекты из презентации. Вы можете получить доступ к флеш-контролю по имени и извлечь его из презентации, включая хранение данных объекта SWF.

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```