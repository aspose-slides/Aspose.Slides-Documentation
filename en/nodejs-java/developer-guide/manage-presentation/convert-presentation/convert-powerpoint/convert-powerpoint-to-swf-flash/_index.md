---
title: Convert PowerPoint to SWF Flash
type: docs
weight: 80
url: /nodejs-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX to SWF"
description: "Convert PowerPoint PPT, PPTX to SWF in JavaScript"
---

## **Convert PPT(X) to SWF**
The [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) method exposed by [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class can be used to convert the whole presentation into **SWF** document. The following example shows how to convert a presentation into **SWF** document by using options provided by [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) class.You can also include comments in generated SWF using [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) class and [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) class.

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Saving presentation
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I include hidden slides in the SWF?**

Yes. Use the [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) method in [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/). By default, hidden slides are not exported.

**How can I control compression and the final SWF size?**

Use the [setCompressed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setcompressed/) method and [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setjpegquality/) to balance file size and image fidelity.

**What is 'setViewerIncluded' for, and when should I use it?**

[setViewerIncluded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) adds an embedded player UI (navigation controls, panels, search). Use it if you plan to use your own player or need a bare SWF frame without UI.

**What happens if a source font is missing on the export machine?**

Aspose.Slides will substitute the font you specify via [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/) to avoid an unintended fallback.
