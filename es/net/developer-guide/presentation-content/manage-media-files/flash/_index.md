---
title: Flash
type: docs
weight: 10
url: /net/flash/
keywords: "Extraer flash, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Extraer objeto flash de la presentación de PowerPoint en C# o .NET"
---

## **Extraer Objetos Flash de la Presentación**
Aspose.Slides para .NET proporciona una herramienta para extraer objetos flash de la presentación. Puedes acceder al control flash por nombre y extraerlo de la presentación, incluyendo almacenar los datos del objeto SWF.

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