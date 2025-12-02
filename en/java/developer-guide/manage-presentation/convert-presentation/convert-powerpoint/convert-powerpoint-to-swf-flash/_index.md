---
title: Convert PowerPoint Presentations to SWF Flash in Java
linktitle: PowerPoint to SWF
type: docs
weight: 80
url: /java/convert-powerpoint-to-swf-flash/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to SWF
- presentation to SWF
- slide to SWF
- PPT to SWF
- PPTX to SWF
- PowerPoint to Flash
- presentation to Flash
- slide to Flash
- PPT to Flash
- PPTX to Flash
- save PPT as SWF
- save PPTX as SWF
- export PPT to SWF
- export PPTX to SWF
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Convert PowerPoint (PPT/PPTX) to SWF Flash in Java with Aspose.Slides. Step‑by‑step code samples, fast quality output, no PowerPoint automation."
---

## **Convert Presentations to Flash**

The [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method exposed by [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class can be used to convert the whole presentation into **SWF** document. The following example shows how to convert a presentation into **SWF** document by using options provided by [**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions) class.You can also include comments in generated SWF using [**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) class and [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) interface.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Saving presentation
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I include hidden slides in the SWF?**

Yes. Enable the hidden slides using the [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) method in [SwfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/swfoptions/). By default, hidden slides are not exported.

**How can I control compression and the final SWF size?**

Use the [setCompressed](https://reference.aspose.com/slides/java/com.aspose.slides/swfoptions/#setCompressed-boolean-) method and [adjust JPEG quality](https://reference.aspose.com/slides/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) to balance file size and image fidelity.

**What is 'setViewerIncluded' for, and when should I disable it?**

[setViewerIncluded](https://reference.aspose.com/slides/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) adds an embedded player UI (navigation controls, panels, search). Disable it if you plan to use your own player or need a bare SWF frame without UI.

**What happens if a source font is missing on the export machine?**

Aspose.Slides will substitute the font you specify via [setDefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [SwfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/swfoptions/) to avoid an unintended fallback.
