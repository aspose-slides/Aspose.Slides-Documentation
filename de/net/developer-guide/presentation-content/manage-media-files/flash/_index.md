---
title: Flash
type: docs
weight: 10
url: /de/net/flash/
keywords: "Flash extrahieren, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Flash-Objekt aus PowerPoint-Präsentation in C# oder .NET extrahieren"
---

## **Flash-Objekte aus Präsentationen extrahieren**
Aspose.Slides für .NET bietet eine Möglichkeit, Flash-Objekte aus Präsentationen zu extrahieren. Sie können die Flash-Steuerung nach Name zugreifen und sie aus der Präsentation extrahieren, einschließlich der Speicherung von SWF-Objektdaten.

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