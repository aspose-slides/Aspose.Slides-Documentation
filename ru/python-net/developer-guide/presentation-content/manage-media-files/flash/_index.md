---
title: Извлечение объектов Flash из презентаций на Python
linktitle: Flash
type: docs
weight: 10
url: /ru/python-net/flash/
keywords:
- извлечение flash
- объект flash
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как извлекать объекты Flash из слайдов PowerPoint и OpenDocument на Python с помощью Aspose.Slides, с полными примерами кода и лучшими практиками."
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