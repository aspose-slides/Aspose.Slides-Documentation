---
title: Extract Flash Objects from Presentations on Android
linktitle: Flash
type: docs
weight: 10
url: /androidjava/flash/
keywords:
- extract flash
- flash object
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Learn how to extract Flash objects from PowerPoint and OpenDocument slides in Java with Aspose.Slides for Android, complete code samples and best practices."
---

## **Extract Flash Objects from Presentation**

Aspose.Slides for Android via Java provides a facility for extracting flash objects from a presentation. You can access the flash control by name and extract it from the presentation and including store SWF object data.

```java
// Instantiate Presentation class that represents the PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```
