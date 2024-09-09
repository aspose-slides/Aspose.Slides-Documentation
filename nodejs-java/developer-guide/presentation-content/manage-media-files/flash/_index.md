---
title: Flash
type: docs
weight: 10
url: /java/flash/
description: Extract Flash Objects from PowerPoint Presentation using Java
---

## **Extract Flash Objects from Presentation**

Aspose.Slides for Java provides a facility for extracting flash objects from a presentation. You can access the flash control by name and extract it from the presentation and including store SWF object data.

```javascript
    // Instantiate Presentation class that represents the PPTX
    var pres = new  com.aspose.slides.Presentation();
    try {
        var controls = pres.getSlides().get_Item(0).getControls();
        var flashControl = null;
        for (var control : controls) {
            if (control.getName() == "ShockwaveFlash1") {
                flashControl = control;
            }
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
