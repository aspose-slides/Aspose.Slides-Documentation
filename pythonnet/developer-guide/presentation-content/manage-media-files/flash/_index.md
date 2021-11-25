---
title: Flash
type: docs
weight: 10
url: /pythonnet/flash/
keywords: "Extract flash, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Extract flash object from PowerPoint presentation in Python"
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
