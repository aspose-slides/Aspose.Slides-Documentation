---
title: Флэш
type: docs
weight: 10
url: /net/flash/
keywords: "Извлечение флэш, Презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Извлечение флэш-объекта из презентации PowerPoint на C# или .NET"
---

## **Извлечение флэш-объектов из презентации**
Aspose.Slides для .NET предоставляет возможность извлечения флэш-объектов из презентации. Вы можете получить доступ к флэш-контролю по имени и извлечь его из презентации, включая хранение данных SWF-объекта.

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