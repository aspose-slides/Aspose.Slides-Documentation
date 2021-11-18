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

