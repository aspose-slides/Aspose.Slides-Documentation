---
title: Convert PowerPoint PPT(X) to SWF Flash
type: docs
weight: 80
url: /java/convert-powerpoint-ppt-and-pptx-to-swf-flash/
keywords: "PPT, PPTX to SWF"
description: "Convert PowerPoint PPT, PPTX to SWF in Java"
---

## **Convert PPT(X) to SWF**
The [Save](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method exposed by [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/presentation) class can be used to convert the whole presentation into **SWF** document. The following example shows how to convert a presentation into **SWF** document by using options provided by [**SWFOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/SwfOptions) class.You can also include comments in generated SWF using [**ISWFOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) class and [**INotesCommentsLayoutingOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) interface.

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
