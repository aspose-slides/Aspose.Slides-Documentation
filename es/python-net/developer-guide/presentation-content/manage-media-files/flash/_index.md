---
title: Flash
type: docs
weight: 10
url: /es/python-net/flash/
keywords: "Extraer flash, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Extraer objeto flash de la presentación de PowerPoint en Python"
---

## **Extraer Objetos Flash de la Presentación**
Aspose.Slides para Python a través de .NET proporciona una herramienta para extraer objetos flash de la presentación. Puedes acceder al control flash por nombre y extraerlo de la presentación, incluyendo los datos del objeto SWF.

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```