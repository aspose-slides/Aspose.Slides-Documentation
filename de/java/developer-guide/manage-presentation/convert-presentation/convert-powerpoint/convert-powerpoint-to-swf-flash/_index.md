---
title: PowerPoint in SWF Flash konvertieren
type: docs
weight: 80
url: /java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX in SWF"
description: "Konvertieren von PowerPoint PPT, PPTX in SWF in Java"
---

## **PPT(X) in SWF konvertieren**
Die [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) Klasse kann verwendet werden, um die gesamte Präsentation in ein **SWF** Dokument zu konvertieren. Das folgende Beispiel zeigt, wie man eine Präsentation in ein **SWF** Dokument umwandelt, indem man die von der [**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions) Klasse bereitgestellten Optionen verwendet. Sie können auch Kommentare im generierten SWF unter Verwendung der [**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) Klasse und dem [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) Interface einfügen.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Präsentation speichern
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```