---
title: Flash
type: docs
weight: 10
url: /java/flash/
---

## **Extract Flash Objects from Presentation**

Aspose.Slides for Java provides a facility for extracting flash objects from a presentation. 
You can access the flash control by name and extract it from the presentation and including store SWF object data.

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
