---
title: Flash
type: docs
weight: 10
url: /fr/net/flash/
keywords: "Extraire flash, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Extraire l'objet flash de la présentation PowerPoint en C# ou .NET"
---

## **Extraire des objets Flash de la présentation**
Aspose.Slides pour .NET fournit une fonctionnalité pour extraire des objets flash de la présentation. Vous pouvez accéder au contrôle flash par son nom et l'extraire de la présentation, y compris stocker les données de l'objet SWF.

```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```