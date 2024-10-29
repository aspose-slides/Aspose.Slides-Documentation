---
title: Flash
type: docs
weight: 10
url: /fr/python-net/flash/
keywords: "Extraire flash, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Extraire l'objet flash d'une présentation PowerPoint en Python"
---

## **Extraire les objets Flash de la présentation**
Aspose.Slides pour Python via .NET fournit une fonctionnalité pour extraire les objets flash de la présentation. Vous pouvez accéder au contrôle flash par son nom et l'extraire de la présentation, y compris stocker les données de l'objet SWF.

```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```