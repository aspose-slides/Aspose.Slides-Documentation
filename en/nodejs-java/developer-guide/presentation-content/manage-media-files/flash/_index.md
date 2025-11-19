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

## **FAQ**

**What presentation formats are supported when extracting Flash content?**

[Aspose.Slides supports](/slides/nodejs-java/supported-file-formats/) the main PowerPoint formats such as PPT and PPTX, since it can load these containers and access their controls, including Flash-related ActiveX elements.

**Can I convert a presentation with Flash to HTML5 and preserve Flash interactivity?**

No. Aspose.Slides does not execute SWF content or convert its interactivity. While export to [HTML](/slides/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/nodejs-java/export-to-html5/) is supported, Flash will not play in modern browsers due to end of support. The recommended path is to replace Flash with alternatives such as video or HTML5 animations before export.

**From a security perspective, does Aspose.Slides execute SWF files while reading a presentation?**

No. Aspose.Slides treats Flash as binary data embedded in the file and does not execute SWF content during processing.

**How should I handle presentations that include Flash along with other embedded files via OLE?**

Aspose.Slides supports [extracting embedded OLE objects](/slides/nodejs-java/manage-ole/), so you can process all related embedded content in one pass, handling Flash controls and other OLE-embedded documents together.
