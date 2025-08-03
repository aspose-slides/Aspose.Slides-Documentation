---
title: Extract Flash Objects from Presentations in Python
linktitle: Flash
type: docs
weight: 10
url: /python-net/flash/
keywords:
- extract flash
- flash object
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to extract Flash objects from PowerPoint and OpenDocument slides in Python with Aspose.Slides, complete code samples and best practices."
---

## **Extract Flash Objects from Presentation**
Aspose.Slides for Python via .NET provides a facility for extracting flash objects from presentation. You can access the flash control by name and extract it from presentation and including store SWF object data.

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```
