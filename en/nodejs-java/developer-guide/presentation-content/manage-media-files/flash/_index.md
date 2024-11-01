---
title: Flash
type: docs
weight: 10
url: /nodejs-java/flash/
description: Extract Flash Objects from PowerPoint Presentation using JavaScript
---

## **Extract Flash Objects from Presentation**

Aspose.Slides for Node.js via Java provides a facility for extracting flash objects from a presentation. You can access the flash control by name and extract it from the presentation and including store SWF object data.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
