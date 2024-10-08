---
title: Flash
type: docs
weight: 10
url: /de/python-net/flash/
keywords: "Flash extrahieren, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Flash-Objekt aus PowerPoint-Präsentation in Python extrahieren"
---

## **Flash-Objekte aus Präsentationen extrahieren**
Aspose.Slides für Python über .NET bietet eine Möglichkeit, Flash-Objekte aus Präsentationen zu extrahieren. Sie können auf die Flash-Steuerung über den Namen zugreifen und sie aus der Präsentation extrahieren, einschließlich des Speicherns von SWF-Objektdaten.

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```